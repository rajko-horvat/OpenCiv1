using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Xml.Serialization;
using IRB.Collections.Generic.Trees;

namespace IRB.Collections.Generic
{
	[Serializable]
	public class BDictionary<TKey, TValue>
		: IList<BKeyValuePair<TKey, TValue>>, ICollection<BKeyValuePair<TKey, TValue>>, IEnumerable<BKeyValuePair<TKey, TValue>>
	{
		protected List<BKeyValuePair<TKey, TValue>> aItems = null;
		private BTree oBTree = new BTree();
		private KeyCollection oKeyCollection = null;
		private ValueCollection oValueCollection = null;

		public BDictionary()
		{
			this.aItems = new List<BKeyValuePair<TKey, TValue>>();
			this.oKeyCollection = new KeyCollection(this);
			this.oValueCollection = new ValueCollection(this);
		}

		public BDictionary(int capacity)
		{
			this.aItems = new List<BKeyValuePair<TKey, TValue>>(capacity);
			this.oKeyCollection = new KeyCollection(this);
			this.oValueCollection = new ValueCollection(this);
		}

		public BDictionary(IEnumerable<BKeyValuePair<TKey, TValue>> collection)
		{
			this.aItems = new List<BKeyValuePair<TKey, TValue>>();

			foreach (BKeyValuePair<TKey, TValue> item in collection)
			{
				int iHashCode = item.Key.GetHashCode();
				BKeyIndexPair pair = oBTree.Find(iHashCode);
				if (pair == null)
				{
					this.aItems.Add(item);
					this.oBTree.Add(iHashCode, this.aItems.Count - 1);
				}
				else
				{
					this.aItems[pair.Index] = new BKeyValuePair<TKey, TValue>(item.Key, item.Value);
				}
			}

			this.oKeyCollection = new KeyCollection(this);
			this.oValueCollection = new ValueCollection(this);
		}

		[XmlIgnore]
		public BDictionary<TKey, TValue>.KeyCollection Keys
		{
			get
			{
				return this.oKeyCollection;
			}
		}

		[XmlIgnore]
		public BDictionary<TKey, TValue>.ValueCollection Values
		{
			get
			{
				return this.oValueCollection;
			}
		}

		public void Add(TKey key, TValue value)
		{
			int iKeyHash = key.GetHashCode();
			BKeyIndexPair pair = oBTree.Find(iKeyHash);
			if (pair != null)
			{
				this.aItems[pair.Index] = new BKeyValuePair<TKey,TValue>(key, value);
			}
			else
			{
				this.aItems.Add(new BKeyValuePair<TKey, TValue>(key, value));
				oBTree.Add(iKeyHash, this.aItems.Count - 1);
			}
		}

		public void Insert(int index, TKey key, TValue value)
		{
			if (this.ContainsKey(key))
			{
				throw new InvalidOperationException(string.Format("This collection already contains key '{0}'", key));
			}
			this.aItems.Insert(index, new BKeyValuePair<TKey, TValue>(key, value));
			oBTree.AdjustNodeIndex(index, 1);
			oBTree.Add(key.GetHashCode(), index);
		}

		public void RemoveByKey(TKey key)
		{
			int iKeyHash = key.GetHashCode();
			BKeyIndexPair pair = oBTree.Find(iKeyHash);
			if (pair == null)
			{
				throw new InvalidOperationException(string.Format("This collection doesn't contain key '{0}'", key));
			}
			this.aItems.RemoveAt(pair.Index);
			this.oBTree.Delete(iKeyHash);
			oBTree.AdjustNodeIndex(pair.Index, -1);
		}

		public bool ContainsKey(TKey key)
		{
			BKeyIndexPair pair = oBTree.Find(key.GetHashCode());
			if (pair != null)
			{
				return true;
			}

			return false;
		}

		public bool ContainsValue(TValue value)
		{
			for (int i = 0; i < this.aItems.Count; i++)
			{
				if (this.aItems[i].Value.Equals(value))
				{
					return true;
				}
			}

			return false;			
		}

		public int IndexOfKey(TKey key)
		{
			BKeyIndexPair pair = oBTree.Find(key.GetHashCode());
			if (pair != null)
			{
				return pair.Index;
			}

			return -1;
		}

		public int IndexOfValue(TValue value)
		{
			int index = -1;

			for (int i = 0; i < this.aItems.Count; i++)
			{
				if (this.aItems[i].Value.Equals(value))
				{
					index = i;
					break;
				}
			}

			return index;
		}

		public TValue GetValueByKey(TKey key)
		{
			BKeyIndexPair pair = oBTree.Find(key.GetHashCode());
			if (pair != null)
			{
				return this.aItems[pair.Index].Value;
			}

			throw new InvalidOperationException(string.Format("This collection doesn't contain key '{0}'", key));
		}

		public void SetValueByKey(TKey key, TValue value)
		{
			BKeyIndexPair pair = oBTree.Find(key.GetHashCode());
			if (pair == null)
			{
				throw new InvalidOperationException(string.Format("This collection doesn't contain key '{0}'", key));
			}

			this.aItems[pair.Index] = new BKeyValuePair<TKey, TValue>(key, value);
		}

		#region IList<KeyValuePair<TKey, TValue>> Members

		public int IndexOf(BKeyValuePair<TKey, TValue> item)
		{
			BKeyIndexPair pair = oBTree.Find(item.Key.GetHashCode());
			if (pair != null)
			{
				return pair.Index;
			}

			return -1;
		}

		public void Insert(int index, BKeyValuePair<TKey, TValue> item)
		{
			if (this.ContainsKey(item.Key))
			{
				throw new InvalidOperationException(string.Format("This collection already contains key '{0}'", item.Key));
			}
			this.aItems.Insert(index, item);
			oBTree.AdjustNodeIndex(index, 1);
			oBTree.Add(item.Key.GetHashCode(), index);
		}

		public void RemoveAt(int index)
		{
			this.oBTree.Delete(this.aItems[index].Key.GetHashCode());
			this.aItems.RemoveAt(index);
			oBTree.AdjustNodeIndex(index, -1);
		}

		public BKeyValuePair<TKey, TValue> this[int index]
		{
			get
			{
				return this.aItems[index];
			}
			set
			{
				if (value.Key.Equals(this.aItems[index].Key))
				{
					this.aItems[index] = value;
				}
				else
				{
					BKeyIndexPair pair = oBTree.Find(value.Key.GetHashCode());
					if (pair != null)
					{
						throw new InvalidOperationException(string.Format("This collection already contains key '{0}'", value.Key));
					}

					this.oBTree.Delete(this.aItems[index].Key.GetHashCode());
					this.aItems[index] = value;
					this.oBTree.Add(value.Key.GetHashCode(), index);
				}
			}
		}

		#endregion

		#region ICollection<KeyValuePair<TKey, TValue>> Members

		public void Add(BKeyValuePair<TKey, TValue> item)
		{
			int iKeyHash = item.Key.GetHashCode();
			BKeyIndexPair pair = oBTree.Find(iKeyHash);
			if (pair != null)
			{
				this.aItems[pair.Index] = item;
			}
			else
			{
				this.aItems.Add(item);
				oBTree.Add(iKeyHash, this.aItems.Count - 1);
			}
		}

		public void Clear()
		{
			this.aItems.Clear();
			this.oBTree.Clear();
		}

		public bool Contains(BKeyValuePair<TKey, TValue> item)
		{
			BKeyIndexPair pair = oBTree.Find(item.Key.GetHashCode());
			if (pair != null)
			{
				return true;
			}

			return false;
		}

		public void CopyTo(BKeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			this.aItems.CopyTo(array, arrayIndex);
		}

		public int Count
		{
			get { return this.aItems.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public bool Remove(BKeyValuePair<TKey, TValue> item)
		{
			int iKeyHash = item.Key.GetHashCode();
			BKeyIndexPair pair = oBTree.Find(iKeyHash);
			if (pair != null)
			{
				this.aItems.Remove(item);
				this.oBTree.Delete(iKeyHash);
				oBTree.AdjustNodeIndex(pair.Index, -1);

				return true;
			}

			return false;
		}

		#endregion

		#region IEnumerable<KeyValuePair<TKey, TValue>> Members

		public IEnumerator<BKeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return this.aItems.GetEnumerator();
		}

		#endregion

		#region IEnumerable Members

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.aItems.GetEnumerator();
		}

		#endregion

		public class KeyCollection : ICollection<TKey>, IEnumerable<TKey>
		{
			private BDictionary<TKey, TValue> oParent;

			internal KeyCollection(BDictionary<TKey, TValue> parent)
			{
				if (parent == null)
					throw new ArgumentNullException("The parent can't be null");

				this.oParent = parent;
			}

			public TKey[] ToArray()
			{
				TKey[] array = new TKey[this.oParent.aItems.Count];

				for (int i = 0; i < this.oParent.aItems.Count; i++)
				{
					array[i] = this.oParent.aItems[i].Key;
				}

				return array;
			}

			#region IEnumerable<TKey> Members

			public IEnumerator<TKey> GetEnumerator()
			{
				return new Enumerator(this.oParent);
			}

			#endregion

			#region IEnumerable Members

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return new Enumerator(this.oParent);
			}

			#endregion

			#region ICollection<TKey> Members

			public void Add(TKey item)
			{
				throw new NotImplementedException();
			}

			public void Clear()
			{
				throw new NotImplementedException();
			}

			public bool Contains(TKey item)
			{
				return this.oParent.ContainsKey(item);
			}

			public void CopyTo(TKey[] array, int arrayIndex)
			{
				if (array == null)
					throw new ArgumentNullException("The target array is null");
				if (arrayIndex < 0 || arrayIndex > array.Length)
					throw new ArgumentOutOfRangeException("arrayIndex", "needs non negative value in range of an array");
				if (array.Length - arrayIndex < this.oParent.aItems.Count)
				{
					throw new InvalidOperationException("The target array is too small");
				}
				for (int i = 0; i < this.oParent.aItems.Count; i++)
				{
					array[arrayIndex + i] = this.oParent.aItems[i].Key;
				}
			}

			public int Count
			{
				get { return this.oParent.aItems.Count; }
			}

			public bool IsReadOnly
			{
				get { return true; }
			}

			public bool Remove(TKey item)
			{
				throw new NotImplementedException();
			}

			#endregion

			public struct Enumerator : IEnumerator<TKey>
			{
				private BDictionary<TKey, TValue> oParent;
				private int iCurrentIndex;
				private BKeyValuePair<TKey, TValue> oCurrentItem;

				internal Enumerator(BDictionary<TKey, TValue> parent)
				{
					this.oParent = parent;
					this.iCurrentIndex = -1;
					this.oCurrentItem = default(BKeyValuePair<TKey, TValue>);
				}

				#region IEnumerator<TKey> Members

				public TKey Current
				{
					get
					{
						return this.oCurrentItem.Key;
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
						return Current;
					}
				}

				public bool MoveNext()
				{
					//Avoids going beyond the end of the collection. 
					if (++this.iCurrentIndex >= this.oParent.aItems.Count)
					{
						this.oCurrentItem = default(BKeyValuePair<TKey, TValue>);
						return false;
					}
					else
					{
						// Set current box to next item in collection.
						this.oCurrentItem = this.oParent.aItems[this.iCurrentIndex];
					}
					return true;
				}

				public void Reset()
				{
					this.iCurrentIndex = -1;
					this.oCurrentItem = default(BKeyValuePair<TKey, TValue>);
				}

				#endregion
			}
		}

		public sealed class ValueCollection : ICollection<TValue>, IEnumerable<TValue>
		{
			private BDictionary<TKey, TValue> oParent;

			internal ValueCollection(BDictionary<TKey, TValue> parent)
			{
				if (parent == null)
					throw new ArgumentNullException("The parent can't be null");

				this.oParent = parent;
			}

			public TValue[] ToArray()
			{
				TValue[] array = new TValue[this.oParent.aItems.Count];

				for (int i = 0; i < this.oParent.aItems.Count; i++)
				{
					array[i] = this.oParent.aItems[i].Value;
				}

				return array;
			}

			#region IEnumerable<TValue> Members

			public IEnumerator<TValue> GetEnumerator()
			{
				return new Enumerator(this.oParent);
			}

			#endregion

			#region IEnumerable Members

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return new Enumerator(this.oParent);
			}

			#endregion

			#region ICollection<TValue> Members

			public void Add(TValue item)
			{
				throw new NotImplementedException();
			}

			public void Clear()
			{
				throw new NotImplementedException();
			}

			public bool Contains(TValue item)
			{
				return this.oParent.ContainsValue(item);
			}

			public void CopyTo(TValue[] array, int arrayIndex)
			{
				if (array == null)
					throw new ArgumentNullException("The target array is null");
				if (arrayIndex < 0 || arrayIndex > array.Length)
					throw new ArgumentOutOfRangeException("arrayIndex", "needs non negative value in range of an array");
				if (array.Length - arrayIndex < this.oParent.aItems.Count)
				{
					throw new InvalidOperationException("The target array is too small");
				}

				for (int i = 0; i < this.oParent.aItems.Count; i++)
				{
					array[arrayIndex + i] = this.oParent.aItems[i].Value;
				}
			}

			public int Count
			{
				get { return this.oParent.aItems.Count; }
			}

			public bool IsReadOnly
			{
				get { return true; }
			}

			public bool Remove(TValue item)
			{
				throw new NotImplementedException();
			}

			#endregion

			public struct Enumerator : IEnumerator<TValue>
			{
				private BDictionary<TKey, TValue> oParent;
				private int iCurrentIndex;
				private BKeyValuePair<TKey, TValue> oCurrentItem;

				internal Enumerator(BDictionary<TKey, TValue> parent)
				{
					this.oParent = parent;
					this.iCurrentIndex = -1;
					this.oCurrentItem = default(BKeyValuePair<TKey, TValue>);
				}

				#region IEnumerator<TValue> Members

				public TValue Current
				{
					get
					{
						return this.oCurrentItem.Value;
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
						return this.oCurrentItem.Value;
					}
				}

				public bool MoveNext()
				{
					//Avoids going beyond the end of the collection. 
					if (++this.iCurrentIndex >= this.oParent.aItems.Count)
					{
						this.oCurrentItem = default(BKeyValuePair<TKey, TValue>);
						return false;
					}
					else
					{
						// Set current box to next item in collection.
						this.oCurrentItem = this.oParent.aItems[this.iCurrentIndex];
					}
					return true;
				}

				public void Reset()
				{
					this.iCurrentIndex = -1;
					this.oCurrentItem = default(BKeyValuePair<TKey, TValue>);
				}

				#endregion
			}
		}
	}
}
