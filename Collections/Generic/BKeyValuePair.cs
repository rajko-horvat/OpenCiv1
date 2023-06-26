using System;
using System.Collections.Generic;
using System.Text;

namespace IRB.Collections.Generic
{
	/// <summary>
	/// Implementation of serializable Key-Value pair class
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
	public struct BKeyValuePair<TKey, TValue>
	{
		private TKey key;
		private TValue value;

		public BKeyValuePair(TKey key, TValue value)
		{
			this.key = key;
			this.value = value;
		}

		public TKey Key
		{
			get
			{
				return this.key;
			}
			set
			{
				this.key = value;
			}
		}

		public TValue Value
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
			}
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();

			builder.Append('[');
			if (this.key != null)
			{
				builder.Append(this.key.ToString());
			}
			builder.Append(", ");
			if (this.value != null)
			{
				builder.Append(this.value.ToString());
			}
			builder.Append(']');

			return builder.ToString();
		}
	}
}
