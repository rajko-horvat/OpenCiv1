using System;
using System.IO;
using System.Text;

namespace IRB.Collections.Generic.Trees
{
    /// <summary>
    /// The class that holds Key-Index pair for BTree algorithm
    /// </summary>
    /// <license>
    /// 	MIT
    /// 	Copyright (c) 2023, Ruđer Bošković Institute
    ///
    /// Authors:
    /// 	Rajko Horvat (https://github.com/rajko-horvat)
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
    /// </license>
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
    /// An implementation of BTree algorithm
    /// 
    /// Authors:
    ///		Rajko Horvat (https://github.com/rajko-horvat)
    /// 
    /// License:
    ///		MIT
    ///		Copyright (c) 2023, Ruđer Bošković Institute
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
    ///		THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
    ///		INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
    ///		FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
    ///		IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, 
    ///		DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, 
    ///		ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
    /// </summary>
    public class BTree : IDisposable
    {
        BTreeNode oRootNode; // Pointer to root node
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
        }

        #endregion

        public void Clear()
        {
            this.oRootNode.Clear();
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
        public BTreeNode? Search(int key)
        {
            // Call the search function for root
            return this.oRootNode.Search(key);
        }

        /// <summary>
        /// Find a key in this B-Tree and return BKeyIndexPair
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public BKeyIndexPair? Find(int key)
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
            BTreeNode? node = this.oRootNode.Search(key);
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
