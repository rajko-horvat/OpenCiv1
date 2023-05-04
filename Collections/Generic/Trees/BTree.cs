using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IRB.Collections.Generic.Trees
{
	public class BKeyIndexPair
	{
		private int iKey;
		private int iIndex;

		public BKeyIndexPair(int key, int index)
		{
			this.iKey = key;
			this.iIndex = index;
		}

		public int Key
		{
			get
			{
				return this.iKey;
			}
			set
			{
				this.iKey = value;
			}
		}

		public int Index
		{
			get
			{
				return this.iIndex;
			}
			set
			{
				this.iIndex = value;
			}
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();

			builder.Append('[');
			builder.Append(this.iKey);
			builder.Append(", ");
			builder.Append(this.iIndex);
			builder.Append(']');

			return builder.ToString();
		}
	}

	/// <summary>
	/// An implementation of a B-Tree algorithm
	/// </summary>
	public class BTree : IDisposable
	{
		BTreeNode oRootNode = null; // Pointer to root node
		int iMaxNodeSize;  // Minimum degree

		public BTree()
			: this(128)
		{ }

		public BTree(int maxNodeSize)
		{
			if (maxNodeSize < 3)
				throw new ArgumentException("B-Tree minimum degree (order) can't be less than 3");

			this.iMaxNodeSize = maxNodeSize;
			this.oRootNode = new BTreeNode(this.iMaxNodeSize);
		}

		#region IDisposable Members

		public void Dispose()
		{
			this.oRootNode.Dispose();
			this.oRootNode = null;
		}

		#endregion

		public void Clear()
		{
			this.oRootNode.Dispose();
		}

		/// <summary>
		/// Traverse this B-Tree (used for debugging)
		/// </summary>
		public void Traverse(StreamWriter writer)
		{
			this.oRootNode.Traverse(writer);
		}

		/// <summary>
		/// Search a key in this B-Tree
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public BTreeNode Search(int key)
		{
			// Call the search function for root
			return this.oRootNode.Search(key);
		}

		/// <summary>
		/// Find a key in this B-Tree and return BKeyIndexPair
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public BKeyIndexPair Find(int key)
		{
			// Call the search function for root
			return this.oRootNode.Find(key);
		}

		/// <summary>
		/// Insert a new key in this B-Tree
		/// </summary>
		/// <param name="key"></param>
		public void Add(int key, int index)
		{
			// Call the insert function for root
			this.oRootNode.Add(key, index);
		}

		/// <summary>
		/// Remove an existing key in this B-Tree
		/// </summary>
		/// <param name="key"></param>
		public void Delete(int key)
		{
			BTreeNode node = this.oRootNode.Search(key);
			// if key not found, no need to remove
			if (node != null)
			{
				// Call the remove function for containing node
				node.Delete(key);
			}
		}

		public void AdjustNodeIndex(int index, int offset)
		{
			this.oRootNode.AdjustNodeIndex(index, offset);
		}
	}
}
