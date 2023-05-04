using System;
using System.Collections.Generic;
using System.Text;

namespace IRB.Collections.Generic
{
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
