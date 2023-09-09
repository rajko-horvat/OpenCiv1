using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCiv1.Compression
{
	public class LZWWord : IEquatable<LZWWord>, IEquatable<List<byte>>,
		IComparable<LZWWord>, IComparable<List<byte>>
	{
		protected byte[] aItems = new byte[] { };
		protected int iHashCode = 0;
		private static LZWWord oEmpty = new LZWWord();

		public LZWWord()
		{ }

		public LZWWord(byte value)
		{
			this.aItems = new byte[] { value };
			this.iHashCode = (int)CRC32.GetCRC32(this.aItems);
		}

		public LZWWord(byte[] collection)
		{
			this.aItems = new byte[collection.Length];
			Array.Copy(collection, this.aItems, collection.Length);
			this.iHashCode = (int)CRC32.GetCRC32(this.aItems);
		}

		public LZWWord(List<byte> collection)
		{
			this.aItems = collection.ToArray();
			this.iHashCode = (int)CRC32.GetCRC32(this.aItems);
		}

		public LZWWord(IEnumerable<byte> collection)
		{
			this.aItems = (new List<byte>(collection)).ToArray();
			this.iHashCode = (int)CRC32.GetCRC32(this.aItems);
		}

		public static LZWWord Empty
		{
			get { return oEmpty; }
		}

		public byte this[int index]
		{
			get { return this.aItems[index]; }
		}

		public int Length
		{
			get { return this.aItems.Length; }
		}

		public static LZWWord operator +(LZWWord a, LZWWord b)
		{
			List<byte> result = new List<byte>(a.aItems);
			result.AddRange(b.aItems);

			return new LZWWord(result);
		}

		public static LZWWord operator +(LZWWord a, byte b)
		{
			List<byte> result = new List<byte>(a.aItems);
			result.Add(b);

			return new LZWWord(result);
		}

		public static bool operator ==(LZWWord a, LZWWord b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(LZWWord a, LZWWord b)
		{
			return !a.Equals(b);
		}

		public int CompareTo(LZWWord other)
		{
			if (this.aItems.Length != other.aItems.Length)
				return this.aItems.Length.CompareTo(other.aItems.Length);

			for (int i = 0; i < this.aItems.Length; i++)
			{
				if (this.aItems[i] != other.aItems[i])
					return this.aItems[i].CompareTo(other.aItems[i]);
			}

			return 0;
		}

		public int CompareTo(List<byte> other)
		{
			if (this.aItems.Length != other.Count)
				return this.aItems.Length.CompareTo(other.Count);

			for (int i = 0; i < this.aItems.Length; i++)
			{
				if (this.aItems[i] != other[i])
					return this.aItems[i].CompareTo(other[i]);
			}

			return 0;
		}

		public bool Equals(LZWWord other)
		{
			return this.CompareTo(other) == 0;
		}

		public bool Equals(List<byte> other)
		{
			return this.CompareTo(other) == 0;
		}

		public override bool Equals(object obj)
		{
			if (obj is LZWWord)
			{
				return this.CompareTo((LZWWord)obj) == 0;
			}
			else if (obj is List<byte>)
			{
				return this.CompareTo((List<byte>)obj) == 0;
			}

			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return iHashCode;
		}
	}
}
