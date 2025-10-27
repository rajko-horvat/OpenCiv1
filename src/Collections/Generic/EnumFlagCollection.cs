using IRB.Collections.Generic;
using OpenCiv1;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Xml.Serialization;

namespace IRB.Collections.Generic
{
	/// <summary>
	/// This serializable class replaces the need for Enum bitwise [Flags] operator
	/// It encapsulates all methods needed for such purpose
	/// </summary>
	/// <typeparam name="T">The base Enum type for this class</typeparam>
	public sealed class EnumFlagCollection<T> : IEnumerable<T>, IEquatable<EnumFlagCollection<T>>
		where T : struct, Enum
	{
		private bool collectionAssigned = false; // we need this for serialization
		private BHashSet<T> flagCollection = new();

		private object hashCodeLock = new(); // ensure that we are thread safe
		private bool hasHashCode = false;
		private int hashCode = 0;

		public EnumFlagCollection()
		{ }

		public EnumFlagCollection(params T[] flags)
		{
			foreach (T flag in flags)
			{
				this.flagCollection.Add(flag);
			}

			this.collectionAssigned = true;
		}

		public EnumFlagCollection(IEnumerable<T> flags)
		{
			foreach (T flag in flags)
			{
				this.flagCollection.Add(flag);
			}

			this.collectionAssigned = true;
		}

		/// <summary>
		/// The array that contains declared flag(s) (used for serialization)
		/// This object needs to be created with empty constructor for assignment to work
		/// </summary>
		public T[] Flags
		{
			get => this.flagCollection.ToArray();
			set
			{
				if (!this.collectionAssigned)
				{
					this.collectionAssigned = true;
					this.flagCollection = new BHashSet<T>(value);
				}
				else
				{
					throw new Exception("This object has already been assigned");
				}
			}
		}

		public bool IsEmpty()
		{
			return this.flagCollection.Count == 0;
		}

		/// <summary>
		/// Tests if this enum collection contains all of the required flags
		/// </summary>
		/// <param name="flags">The list of flags to test</param>
		/// <returns>True if the enum collection contains all of the required flags</returns>
		public bool ContainAllFlags(params T[] flags)
		{
			bool hasAllValues = true;

			foreach (T flag in flags)
			{
				if (!this.flagCollection.Contains(flag))
				{
					hasAllValues = false;
					break;
				}
			}

			return hasAllValues;
		}

		/// <summary>
		/// Tests if this enum collection contains all of the required flags
		/// </summary>
		/// <param name="flags">The list of flags to test</param>
		/// <returns>True if the enum collection contains all of the required flags</returns>
		public bool ContainAllFlags(IEnumerable<T> flags)
		{
			bool hasAllValues = true;

			foreach (T flag in flags)
			{
				if (!this.flagCollection.Contains(flag))
				{
					hasAllValues = false;
					break;
				}
			}

			return hasAllValues;
		}

		/// <summary>
		/// Tests if this enum collection contains any of the required flags
		/// </summary>
		/// <param name="flags">The list of flags to test</param>
		/// <returns>True if the enum collection contains any of the required flags</returns>
		public bool ContainsAnyFlag(params T[] flags)
		{
			foreach (T flag in flags)
			{
				if (this.flagCollection.Contains(flag))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Tests if this enum collection contains any of the required flags
		/// </summary>
		/// <param name="flags">The list of flags to test</param>
		/// <returns>True if the enum collection contains any of the required flags</returns>
		public bool ContainsAnyFlag(IEnumerable<T> flags)
		{
			foreach (T flag in flags)
			{
				if (this.flagCollection.Contains(flag))
				{
					return true;
				}
			}

			return false;
		}

		public static EnumFlagCollection<T> operator +(EnumFlagCollection<T> value1, T value2)
		{
			EnumFlagCollection<T> newValue = new(value1);
			newValue.flagCollection.Add(value2);

			return newValue;
		}

		public static EnumFlagCollection<T> operator |(EnumFlagCollection<T> value1, T value2)
		{
			EnumFlagCollection<T> newValue = new(value1);
			newValue.flagCollection.Add(value2);

			return newValue;
		}

		public static EnumFlagCollection<T> operator +(EnumFlagCollection<T> value1, IEnumerable<T> value2)
		{
			EnumFlagCollection<T> newValue = new(value1);

			foreach (T flag in value2)
			{
				newValue.flagCollection.Add(flag);
			}

			return newValue;
		}

		public static EnumFlagCollection<T> operator |(EnumFlagCollection<T> value1, IEnumerable<T> value2)
		{
			EnumFlagCollection<T> newValue = new(value1);

			foreach (T flag in value2)
			{
				newValue.flagCollection.Add(flag);
			}

			return newValue;
		}

		public static EnumFlagCollection<T> operator -(EnumFlagCollection<T> value1, T value2)
		{
			EnumFlagCollection<T> newValue = new(value1);
			newValue.flagCollection.Remove(value2);

			return newValue;
		}

		public static EnumFlagCollection<T> operator -(EnumFlagCollection<T> value1, IEnumerable<T> value2)
		{
			EnumFlagCollection<T> newValue = new(value1);

			foreach (T flag in value2)
			{
				newValue.flagCollection.Remove(flag);
			}

			return newValue;
		}

		public static EnumFlagCollection<T> operator &(EnumFlagCollection<T> value1, T value2)
		{
			EnumFlagCollection<T> newValue = new([]);

			if (value1.flagCollection.Contains(value2))
			{
				newValue.flagCollection.Add(value2);
			}

			return newValue;
		}

		public static EnumFlagCollection<T> operator &(EnumFlagCollection<T> value1, IEnumerable<T> value2)
		{
			EnumFlagCollection<T> newValue = new([]);
			BHashSet<T> flags1 = value1.flagCollection;

			foreach (T flag in value2)
			{
				if (flags1.Contains(flag))
				{
					newValue.flagCollection.Add(flag);
				}
			}

			return newValue;
		}

		public static EnumFlagCollection<T> operator ^(EnumFlagCollection<T> value1, T value2)
		{
			EnumFlagCollection<T> newValue = new(value1);
			
			if (newValue.flagCollection.Contains(value2))
			{
				newValue.flagCollection.Remove(value2);
			}
			else
			{
				newValue.flagCollection.Add(value2);
			}

			return newValue;
		}

		public static EnumFlagCollection<T> operator ^(EnumFlagCollection<T> value1, IEnumerable<T> value2)
		{
			EnumFlagCollection<T> newValue = new(value1);

			foreach (T flag in value2)
			{
				if (newValue.flagCollection.Contains(flag))
				{
					newValue.flagCollection.Remove(flag);
				}
				else
				{
					newValue.flagCollection.Add(flag);
				}
			}

			return newValue;
		}

		public static EnumFlagCollection<T> operator ~(EnumFlagCollection<T> value)
		{
			EnumFlagCollection<T> newValue = new([]);
			T[] allFlags = Enum.GetValues<T>();

			foreach (T flag in allFlags)
			{
				if (!value.flagCollection.Contains(flag))
				{
					newValue.flagCollection.Add(flag);
				}
			}

			return newValue;
		}

		private static bool IsEqual(EnumFlagCollection<T>? value1, EnumFlagCollection<T>? value2)
		{
			if (value1 == null && value2 == null)
				return true;

			if ((value1 == null && value2 != null) || (value1 != null && value2 == null))
				return false;

			bool bEqual = false;

			if (value1!.flagCollection.Count == value2!.flagCollection.Count)
			{
				bEqual = true;

				foreach (T flag in value1.flagCollection)
				{
					if (!value2.flagCollection.Contains(flag))
					{
						bEqual = false;
						break;
					}
				}
			}

			return bEqual;
		}

		public static bool operator ==(EnumFlagCollection<T>? value1, EnumFlagCollection<T>? value2)
		{
			return IsEqual(value1, value2);
		}

		public static bool operator !=(EnumFlagCollection<T>? value1, EnumFlagCollection<T>? value2)
		{
			return !IsEqual(value1, value2);
		}

		public bool Equals(EnumFlagCollection<T>? other)
		{
			return IsEqual(this, other);
		}

		public override bool Equals(object? obj)
		{
			return obj != null && (obj is EnumFlagCollection<T>) && this.Equals(obj as EnumFlagCollection<T>);
		}

		/// <summary>Returns the hash code for this instance.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		public override int GetHashCode()
		{
			// ensure that we are thread safe
			lock (this.hashCodeLock)
			{
				if (!this.hasHashCode)
				{
					// For speed we need to calculate CRC32 only once since this object is immutable
					List<uint> values = new();

					foreach (T flag in this.flagCollection)
					{
						values.Add(Convert.ToUInt32(flag));
					}

					this.hashCode = (int)CRC32.GetCRC32(values);
					this.hasHashCode = true;
				}
			}

			return this.hashCode;
		}

		#region IEnumerator<T> implementation
		public IEnumerator<T> GetEnumerator()
		{
			return this.flagCollection.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.flagCollection.GetEnumerator();
		}
		#endregion
	}
}
