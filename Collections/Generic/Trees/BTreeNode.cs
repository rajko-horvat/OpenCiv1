using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IRB.Collections.Generic.Trees
{
	/// <summary>
	/// A BTree node
	/// </summary>
	public class BTreeNode : IDisposable
	{
		protected BTreeNode oParentNode = null;
		private int iMaxCapacity;				// Minimum degree (defines the maximum capacity of this node)
		private int iMinCapacity;				// A minimum keys this node can have
		protected List<BKeyIndexPair> aKeys;	// An array of keys
		protected List<BTreeNode> aChildNodes;	// An array of child nodes

		public BTreeNode(int capacity)
			: this(null, capacity)
		{ }

		public BTreeNode(BTreeNode parent, int capacity)
		{
			this.iMaxCapacity = capacity;
			this.iMinCapacity = Math.Max((capacity / 2) - 1, 1);

			// Allocate for maximum number of possible keys and child nodes
			this.aKeys = new List<BKeyIndexPair>(iMaxCapacity); // we need one more for insertions and splitting
			this.aChildNodes = new List<BTreeNode>(iMaxCapacity + 1);
			this.oParentNode = parent;
		}

		#region IDisposable Members

		public void Dispose()
		{
			if (!this.IsLeafNode)
			{
				BTreeNode child = this.aChildNodes[this.aChildNodes.Count - 1];

				while (child != this)
				{
					if (child.IsLeafNode)
					{
						BTreeNode parent = child.Parent;
						child.Dispose();
						child = null;

						if (parent != null)
						{
							parent.aChildNodes.RemoveAt(parent.aChildNodes.Count - 1);

							if (parent.aChildNodes.Count > 0)
							{
								child = parent.aChildNodes[parent.aChildNodes.Count - 1];
							}
							else
							{
								child = parent;
							}
						}
					}
					else
					{
						child = child.aChildNodes[child.aChildNodes.Count - 1];
					}
				}
			}

			this.oParentNode = null;
			this.aKeys.Clear();
		}

		#endregion

		public BTreeNode Parent
		{
			get
			{
				return this.oParentNode;
			}
		}

		protected BTreeNode ParentProtected
		{
			get
			{
				return this.oParentNode;
			}
			set
			{
				this.oParentNode = value;
			}
		}

		public bool IsLeafNode
		{
			get
			{
				return this.aChildNodes.Count == 0;
			}
		}

		/// <summary>
		/// A function to traverse all nodes in a subtree rooted with this node
		/// </summary>
		public void Traverse(StreamWriter writer)
		{
			writer.Write("[");
			// There are n keys and n+1 children, traverse through keys first
			for (int i = 0; i < this.aKeys.Count; i++)
			{
				if (i > 0)
					writer.Write(", ");
				writer.Write(string.Format(" {0}", aKeys[i]));
			}

			// Traverse through children, if this is not a leaf node
			writer.Write(" {");
			for (int i = 0; i < this.aChildNodes.Count; i++)
			{
				if (i > 0)
					writer.Write(", ");
				// Print the subtree
				aChildNodes[i].Traverse(writer);
			}
			writer.Write("}");
			writer.WriteLine("]");
		}

		/// <summary>
		/// This function searches the array of keys by Binary Search method which is much faster O(log n) 
		/// instead of O(n) for standard search method
		/// </summary>
		/// <param name="key"></param>
		/// The value to be searched in the array of keys
		/// <returns></returns>
		private int BinarySearchKey(int key)
		{
			int iPos = 0;
			int iKeyCount = this.aKeys.Count;
			int iLength = iKeyCount;

			while (iPos < iKeyCount)
			{
				int iPivot = iLength / 2;
				if (iPivot == 0 && key <= this.aKeys[iPos].Key)
				{
					break;
				}
				if (key > this.aKeys[iPos + iPivot].Key)
				{
					iPos += iPivot + 1;
					iLength = iKeyCount - iPos;
				}
				else
				{
					iLength = iPivot;
				}
			}

			// sanity check for now, to be removed later for speed!!!
			// Find the first key greater than or equal to key
			/*int index = 0;
			while (index < this.aKeys.Count && key > this.aKeys[index].Key)
				index++;

			if (index != iPos)
			{
				throw new Exception("Index matching not identical.");
			}*/

			return iPos;
		}

		/// <summary>
		/// A function to search a key in subtree rooted with this node.
		/// returns null if key is not present.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public BTreeNode Search(int key)
		{
			// Find the first key greater than or equal to key
			int index = BinarySearchKey(key);

			// If the found key is equal to key, return this node
			if (index < this.aKeys.Count && this.aKeys[index].Key == key)
				return this;

			// Go to the appropriate child
			if (this.aChildNodes.Count > 0)
				return this.aChildNodes[index].Search(key);

			// If key is not found here and this is a leaf node
			return null;
		}

		/// <summary>
		/// A function to find a key in subtree rooted with this node.
		/// returns null if key is not present.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public BKeyIndexPair Find(int key)
		{
			// Find the first key greater than or equal to key
			int index = BinarySearchKey(key);

			// If the found key is equal to key, return this node
			if (index < this.aKeys.Count && this.aKeys[index].Key == key)
				return this.aKeys[index];

			// Go to the appropriate child
			if (this.aChildNodes.Count > 0)
				return this.aChildNodes[index].Find(key);

			// If key is not found here and this is a leaf node
			return null;
		}

		public void Add(int key, int index)
		{
			// If node is a leaf node
			if (this.aChildNodes.Count == 0)
			{
				// Find the first key greater than or equal to key
				int pos = BinarySearchKey(key);

				if (pos >= this.aKeys.Count)
				{
					this.aKeys.Add(new BKeyIndexPair(key, index));
				}
				else
				{
					this.aKeys.Insert(pos, new BKeyIndexPair(key, index));
				}

				// check if this node needs splitting (has maximum elements)
				if (this.aKeys.Count >= this.iMaxCapacity)
				{
					this.SplitNode();
				}
			}
			else
			{
				// Find the first key greater than or equal to key
				int pos = BinarySearchKey(key);

				this.aChildNodes[pos].Add(key, index);
			}
		}

		private void SplitNode()
		{
			int iMedian = this.aKeys.Count / 2;
			BKeyIndexPair oMedianKey = this.aKeys[iMedian];

			if (this.oParentNode == null)
			{
				// if this is a root node, split the root node to two children and leave only median value
				BTreeNode left = new BTreeNode(this, this.iMaxCapacity);
				left.AddKeys(this.aKeys, 0, iMedian);

				BTreeNode right = new BTreeNode(this, this.iMaxCapacity);
				right.AddKeys(this.aKeys, iMedian + 1, this.aKeys.Count - (iMedian + 1));

				if (this.aChildNodes.Count > 0)
				{
					left.AddChildNodes(this.aChildNodes, 0, iMedian + 1);
					right.AddChildNodes(this.aChildNodes, iMedian + 1, this.aChildNodes.Count - (iMedian + 1));
					this.aChildNodes.Clear();
				}

				this.aKeys.Clear();
				this.aKeys.Add(oMedianKey);
				this.aChildNodes.Add(left);
				this.aChildNodes.Add(right);
			}
			else
			{
				// if this is a child node remove the median key,
				// split this node by copying right children to a new node,
				// propagate this median key and new right node to the parent to rebalance the tree
				BTreeNode right = new BTreeNode(this.oParentNode, this.iMaxCapacity);
				right.AddKeys(this.aKeys, iMedian + 1, this.aKeys.Count - (iMedian + 1));
				if (this.aChildNodes.Count > 0)
				{
					right.AddChildNodes(this.aChildNodes, iMedian + 1, this.aChildNodes.Count - (iMedian + 1));
					this.aChildNodes.RemoveRange(iMedian + 1, this.aChildNodes.Count - (iMedian + 1));
				}
				this.aKeys.RemoveRange(iMedian, this.aKeys.Count - iMedian);

				this.oParentNode.InsertNewNode(oMedianKey, right);
			}
		}

		protected void AddKeys(List<BKeyIndexPair> keys, int start, int count)
		{
			for (int i = start; i < start + count; i++)
			{
				this.aKeys.Add(keys[i]);
			}
		}

		protected void AddChildNodes(List<BTreeNode> childNodes, int start, int count)
		{
			for (int i = start; i < start + count; i++)
			{
				this.aChildNodes.Add(childNodes[i]);
				this.aChildNodes[this.aChildNodes.Count - 1].ParentProtected = this;
			}
		}

		protected void InsertNewNode(BKeyIndexPair key, BTreeNode rightNode)
		{
			// Find the first key greater than or equal to key
			int index = BinarySearchKey(key.Key);

			// add or insert new key
			if (index >= this.aKeys.Count)
			{
				this.aKeys.Add(key);
			}
			else
			{
				this.aKeys.Insert(index, key);
			}

			// add or insert new child
			if (index + 1 >= this.aChildNodes.Count)
			{
				this.aChildNodes.Add(rightNode);
			}
			else
			{
				this.aChildNodes.Insert(index + 1, rightNode);
			}

			// check if this node needs splitting (has maximum elements)
			if (this.aKeys.Count >= this.iMaxCapacity)
			{
				SplitNode();
			}
		}

		/// <summary>
		/// A function to remove the key from this node
		/// </summary>
		/// <param name="key"></param>
		public void Delete(int key)
		{
			// Find the first key greater than or equal to key
			int index = BinarySearchKey(key);

			if (index < this.aKeys.Count && this.aKeys[index].Key == key)
			{
				// The key to be removed is present in this node, delete it
				if (this.aChildNodes.Count == 0)
				{
					// this is a leaf node, we need to check 
					// if after deletion rebalance should occur
					//writer.WriteLine("Removing key {0}, at position {1}", this.aKeys[index], index);
					//writer.Flush();
					this.aKeys.RemoveAt(index);
					if (this.oParentNode != null && this.aKeys.Count < this.iMinCapacity)
					{
						this.oParentNode.RebalanceChildren();
					}
				}
				else
				{
					BTreeNode oChild = this.aChildNodes[index + 1];
					while (!oChild.IsLeafNode)
					{
						//oChild.aKeys[0] = oChild.aChildNodes[0].aKeys[0];
						oChild = oChild.aChildNodes[0];
					}
					//writer.WriteLine("Replacing key {0} with {1}, at position {2}", this.aKeys[index], oChild.aKeys[0], index);
					//writer.Flush();
					this.aKeys[index] = oChild.aKeys[0];
					oChild.aKeys.RemoveAt(0);
					if (oChild.aKeys.Count < oChild.iMinCapacity)
					{
						oChild.oParentNode.RebalanceChildren();
					}
				}
			}
		}

		protected void RebalanceChildren()
		{
			if (this.aChildNodes.Count == 0)
			{
				// this is a leaf node, do nothing
				return;
			}

			/*writer.Write("Rebalancing node with keys: {");
			for (int i = 0; i < this.aKeys.Count; i++)
			{
				if (i > 0)
					writer.Write(", ");
				writer.Write("{0}", this.aKeys[i]);
			}
			writer.WriteLine("}");
			writer.Flush();*/

			for (int i = 0; i < this.aChildNodes.Count; i++)
			{
				if (this.aChildNodes[i].IsLeafNode &&
					this.aChildNodes[i].aKeys.Count < this.aChildNodes[i].iMinCapacity)
				{
					BTreeNode child = this.aChildNodes[i];
					bool bLeft = i > 0;
					bool bRight = (i + 1) < this.aChildNodes.Count;

					//writer.WriteLine("Rebalancing leaf child {0}", i);
					//writer.Flush();

					// handle three cases: right borrow, left borrow or merge
					BTreeNode right = bRight ? this.aChildNodes[i + 1] : null;
					BTreeNode left = bLeft ? this.aChildNodes[i - 1] : null;
					if (bRight && right.IsLeafNode && right.aKeys.Count - 1 >= right.iMinCapacity)
					{
						// right sibling is a leaf node and we can borrow one element
						//writer.WriteLine("Borrowing one key from right leaf child");
						//writer.Flush();
						child.aKeys.Add(this.aKeys[i]);
						this.aKeys[i] = right.aKeys[0];
						right.aKeys.RemoveAt(0);
					}
					else if (bRight && right.IsLeafNode && (child.aKeys.Count + right.aKeys.Count + 1) < child.iMaxCapacity)
					{
						// merge child with right sibling
						//writer.WriteLine("Merging with right leaf child");
						//writer.Flush();
						child.aKeys.Add(this.aKeys[i]);
						child.aKeys.AddRange(right.aKeys);

						this.aKeys.RemoveAt(i);
						this.aChildNodes.RemoveAt(i + 1);

						right.Dispose();
					}
					else if (bRight && !right.IsLeafNode)
					{
						// just borrow from right children and invoke leaf parent RebalanceChildren procedure if needed
						//writer.WriteLine("Borrowing from right node");
						//writer.Flush();
						BTreeNode oBorrowChild = right;
						child.aKeys.Add(this.aKeys[i]);
						while (!oBorrowChild.IsLeafNode)
						{
							oBorrowChild = oBorrowChild.aChildNodes[0];
						}
						this.aKeys[i] = oBorrowChild.aKeys[0];
						oBorrowChild.aKeys.RemoveAt(0);
						if (oBorrowChild.aKeys.Count < oBorrowChild.iMinCapacity)
						{
							oBorrowChild.oParentNode.RebalanceChildren();
						}
					}
					else if (bLeft && left.IsLeafNode && left.aKeys.Count - 1 >= left.iMinCapacity)
					{
						// left sibling is a leaf node and we can borrow one element
						//writer.WriteLine("Borrowing one key from left leaf child");
						//writer.Flush();
						child.aKeys.Insert(0, this.aKeys[i - 1]);
						this.aKeys[i - 1] = left.aKeys[left.aKeys.Count - 1];
						left.aKeys.RemoveAt(left.aKeys.Count - 1);
					}
					else if (bLeft && left.IsLeafNode && (left.aKeys.Count + child.aKeys.Count + 1) < left.iMaxCapacity)
					{
						// delete child and add key to a left sibling
						//writer.WriteLine("Merging with left leaf child");
						//writer.Flush();
						left.aKeys.Add(this.aKeys[i - 1]);
						left.aKeys.AddRange(child.aKeys);

						this.aKeys.RemoveAt(i - 1);
						this.aChildNodes.RemoveAt(i);

						child.Dispose();
					}
					else if (bLeft && !left.IsLeafNode)
					{
						// just borrow from left children and invoke leaf parent RebalanceChildren procedure if needed
						//writer.WriteLine("Borrowing from left node");
						//writer.Flush();
						BTreeNode oBorrowChild = left;
						child.aKeys.Insert(0, this.aKeys[i - 1]);
						while (!oBorrowChild.IsLeafNode)
						{
							oBorrowChild = oBorrowChild.aChildNodes[oBorrowChild.aChildNodes.Count - 1];
						}
						this.aKeys[i - 1] = oBorrowChild.aKeys[oBorrowChild.aKeys.Count - 1];
						oBorrowChild.aKeys.RemoveAt(oBorrowChild.aKeys.Count - 1);
						if (oBorrowChild.aKeys.Count < oBorrowChild.iMinCapacity)
						{
							oBorrowChild.oParentNode.RebalanceChildren();
						}
					}
					else
					{
						//writer.WriteLine("Can't rebalance node");
						//writer.Flush();
						throw new InvalidOperationException("Can't rebalance nodes after remove operation");
					}
					break;
				}
			}
			if (this.aKeys.Count < 1)
			{
				// When we delete children, at some point this node will contain less than iMinCapacity keys
				// but, we will not rebalance non-leaf node as this would be way too complicated
				// so, leave things as they are until we run out of keys, and then this node will become leaf node.
				
				// Sanity check, just to make sure everything is OK.
				if (this.aChildNodes.Count == 1 && this.aChildNodes[0].IsLeafNode)
				{
					BTreeNode child = this.aChildNodes[0];
					this.aKeys.AddRange(child.aKeys);
					this.aChildNodes.Clear();

					child.Dispose();
				}
				else
				{
					//writer.WriteLine("Can't rebalance non-leaf node");
					//writer.Flush();
					throw new InvalidOperationException("Can't rebalance non-leaf node after remove operation");
				}
			}
		}

		public void AdjustNodeIndex(int index, int offset)
		{
			// adjust index of keys
			for (int i = 0; i < this.aKeys.Count; i++)
			{
				if (aKeys[i].Index >= index)
					aKeys[i].Index += offset;
			}

			// adjust index of child nodes
			for (int i = 0; i < this.aChildNodes.Count; i++)
			{
				aChildNodes[i].AdjustNodeIndex(index, offset);
			}
		}
	}
}
