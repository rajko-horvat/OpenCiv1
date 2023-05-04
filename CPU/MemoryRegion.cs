using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disassembler
{
	[Flags]
	public enum MemoryFlagsEnum
	{
		None = 0,
		Write = 1,
		Read = 2
	}

	public class MemoryRegion
	{
		private uint uiStart;
		private uint uiSize;
		private MemoryFlagsEnum eAccessFlags;

		public MemoryRegion(ushort segment, ushort offset, uint size)
			: this(MemoryRegion.ToLinearAddress(segment, offset), size, MemoryFlagsEnum.None)
		{
		}

		public MemoryRegion(ushort segment, ushort offset, uint size, MemoryFlagsEnum access)
			: this(MemoryRegion.ToLinearAddress(segment, offset), size, access)
		{
		}

		public MemoryRegion(uint start, uint size)
			: this(start, size, MemoryFlagsEnum.None)
		{
		}

		public MemoryRegion(uint start, uint size, MemoryFlagsEnum access)
		{
			this.uiStart = start;
			this.uiSize = size;
			this.eAccessFlags = access;
		}

		public MemoryFlagsEnum AccessFlags
		{
			get { return eAccessFlags; }
			set { eAccessFlags = value; }
		}

		public uint Start
		{
			get
			{
				return this.uiStart;
			}
		}

		public uint Size
		{
			get
			{
				return this.uiSize;
			}
		}

		public uint End
		{
			get
			{
				return (uint)(this.uiStart + this.uiSize - 1);
			}
		}

		public bool CheckBounds(ushort segment, ushort offset)
		{
			return this.CheckBounds(MemoryRegion.ToLinearAddress(segment, offset), 1);
		}

		public bool CheckBounds(ushort segment, ushort offset, uint size)
		{
			return this.CheckBounds(MemoryRegion.ToLinearAddress(segment, offset), size);
		}

		public bool CheckBounds(uint address)
		{
			return this.CheckBounds(address, 1);
		}

		public bool CheckBounds(uint address, uint size)
		{
			if (address >= this.uiStart && address + size - 1 < this.uiStart + this.uiSize)
			{
				return true;
			}

			return false;
		}

		public bool CheckOverlap(ushort segment, ushort offset, uint size)
		{
			return this.CheckOverlap(MemoryRegion.ToLinearAddress(segment, offset), size);
		}

		public bool CheckOverlap(uint address, uint size)
		{
			if (address >= this.uiStart || address < this.uiStart + this.uiSize ||
				(address + size - 1) >= this.uiStart || (address + size - 1) < this.uiStart + this.uiSize)
			{
				return true;
			}
			return false;
		}

		public uint MapAddress(ushort segment, ushort offset)
		{
			return this.MapAddress(MemoryRegion.ToLinearAddress(segment, offset));
		}

		public uint MapAddress(uint address)
		{
			return (uint)(address - this.uiStart);
		}

		public static uint ToLinearAddress(ushort segment, ushort offset)
		{
			// 1MB limit!
			return ((uint)((uint)segment << 4) + (uint)offset) & 0xfffff;
		}

		public static void AlignBlock(ref uint address)
		{
			if ((address & 0xf) != 0)
			{
				address &= 0xffff0;
				address += 0x10;
			}
		}
	}
}
