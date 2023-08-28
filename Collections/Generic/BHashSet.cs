using System;
using System.Collections.Generic;
using System.Text;
using IRB.Collections.Generic.Trees;

namespace IRB.Collections.Generic
{
	/// <summary>
	/// Implementation of serializable direct replacement for HashSet class which uses BTree indexing implementation
	/// 
	/// Authors:
	/// 	Rajko Horvat (https://github.com/rajko-horvat)
	/// 
	/// License:
	/// 	MIT
	/// 	Copyright (c) 2011-2023, Ruđer Bošković Institute
	///		
	/// 	Permission is hereby granted, free of charge, to any person obtaining a copy of this software 
	/// 	and associated documentation files (the "Software"), to deal in the Software without restriction, 
	/// 	including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, 
	/// 	and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, 
	/// 	subject to the following conditions: 
	/// 	The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
	/// 	The names of authors and contributors may not be used to endorse or promote Software products derived from this software 
	/// 	without specific prior written permission.
	/// 	
	/// 	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
	/// 	INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
	/// 	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
	/// 	IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
	/// 	DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
	/// 	ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
	/// </summary>
	[Serializable]
	public class BHashSet<TValue>
		: IList<TValue>, ICollection<TValue>, IEnumerable<TValue>
	{
		protected List<TValue> aItems = null;
		private BTree oBTree = new BTree();

		public BHashSet()
		{
			this.aItems = new List<TValue>();
		}

		public BHashSet(int capacity)
		{
			this.aItems = new List<TValue>(capacity);
		}

		public BHashSet(IEnumerable<TValue> collection)
		{
			this.aItems = new List<TValue>();
			foreach (TValue item in collection)
			{
				int iHashCode = item.GetHashCode();
				if (this.oBTree.Search(iHashCode) == null)
				{
					this.aItems.Add(item);
					this.oBTree.Add(iHashCode, this.aItems.Count - 1);
				}
			}
		}

		public void AddRange(IEnumerable<TValue> collection)
		{
			foreach (TValue value in collection)
			{
				this.Add(value);
			}
		}

		public TValue[] ToArray()
		{
			return this.aItems.ToArray();
		}

		#region IList<TValue> Members

		public int IndexOf(TValue value)
		{
			BKeyIndexPair pair = oBTree.Find(value.GetHashCode());
			if (pair != null)
			{
				return pair.Index;
			}

			return -1;
		}

		public void Insert(int index, TValue value)
		{
			if (this.Contains(value))
			{
				throw new InvalidOperationException(string.Format("This collection already contains value '{0}'", value));
			}
			this.oBTree.AdjustNodeIndex(index, 1);
			this.aItems.Insert(index, value);
			this.oBTree.Add(value.GetHashCode(), index);
		}

		public void RemoveAt(int index)
		{
			this.oBTree.Delete(this.aItems[index].GetHashCode());
			this.aItems.RemoveAt(index);
			this.oBTree.AdjustNodeIndex(index, -1);
		}

		public TValue this[int index]
		{
			get
			{
				return this.aItems[index];
			}
			set
			{
				if (this.Contains(value))
				{
					throw new InvalidOperationException(string.Format("This collection already contains value '{0}'", value));
				}

				this.oBTree.Delete(this.aItems[index].GetHashCode());
				this.aItems[index] = value;
				this.oBTree.Add(value.GetHashCode(), index);
			}
		}

		#endregion

		#region ICollection<TValue> Members

		public void Add(TValue value)
		{
			if (!this.Contains(value))
			{
				this.aItems.Add(value);
				this.oBTree.Add(value.GetHashCode(), this.aItems.Count - 1);
			}
		}

		public void Clear()
		{
			this.aItems.Clear();
			this.oBTree.Clear();
		}

		public bool Contains(TValue value)
		{
			BKeyIndexPair pair = oBTree.Find(value.GetHashCode());
			if (pair != null)
			{
				return true;
			}

			return false;
		}

		public void CopyTo(TValue[] array, int arrayIndex)
		{
			if (array == null)
				throw new ArgumentNullException("The target array is null");
			if (arrayIndex < 0 || arrayIndex > array.Length)
				throw new ArgumentOutOfRangeException("arrayIndex", "needs non negative value in range of an array");
			if (array.Length - arrayIndex < this.aItems.Count)
			{
				throw new InvalidOperationException("The target array is too small");
			}
			for (int i = 0; i < this.aItems.Count; i++)
			{
				array[arrayIndex + i] = this.aItems[i];
			}
		}

		public int Count
		{
			get { return this.aItems.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public bool Remove(TValue value)
		{
			int iHash = value.GetHashCode();
			BKeyIndexPair pair = oBTree.Find(iHash);
			if (pair != null)
			{
				this.aItems.RemoveAt(pair.Index);
				this.oBTree.Delete(iHash);
				this.oBTree.AdjustNodeIndex(pair.Index, -1);
				return true;
			}

			return false;
		}

		#endregion

		#region IEnumerable<TValue> Members

		public IEnumerator<TValue> GetEnumerator()
		{
			return new Enumerator(this);
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return new Enumerator(this);
		}

		#endregion

		public struct Enumerator : IEnumerator<TValue>
		{
			private BHashSet<TValue> oParent;
			private int iCurrentIndex;
			private TValue oCurrentItem;

			internal Enumerator(BHashSet<TValue> parent)
			{
				this.oParent = parent;
				this.iCurrentIndex = -1;
				this.oCurrentItem = default(TValue);
			}

			#region IEnumerator<TValue> Members

			public TValue Current
			{
				get
				{
					return this.oCurrentItem;
				}
			}

			#endregion

			#region IDisposable Members

			public void Dispose() { }

			#endregion

			#region IEnumerator Members

			object System.Collections.IEnumerator.Current
			{
				get
				{
					return this.oCurrentItem;
				}
			}

			public bool MoveNext()
			{
				//Avoids going beyond the end of the collection. 
				if (++this.iCurrentIndex >= this.oParent.aItems.Count)
				{
					this.oCurrentItem = default(TValue);
					return false;
				}
				else
				{
					// Set current box to next aItems in collection.
					this.oCurrentItem = this.oParent.aItems[this.iCurrentIndex];
				}
				return true;
			}

			public void Reset()
			{
				this.iCurrentIndex = -1;
				this.oCurrentItem = default(TValue);
			}

			#endregion
		}
	}
}
