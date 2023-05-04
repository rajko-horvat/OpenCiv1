using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Disassembler
{
	public class MemoryBlock
	{
		private MemoryRegion oRegion;
		private byte[] abData;

		public MemoryBlock(ushort segment, ushort offset, uint size)
			: this(MemoryRegion.ToLinearAddress(segment, offset), size)
		{ }

		public MemoryBlock(uint start, uint size)
		{
			this.oRegion = new MemoryRegion(start, size);
			this.abData = new byte[size];
		}

		public MemoryRegion Region
		{
			get
			{
				return this.oRegion;
			}
		}

		public byte[] Data
		{
			get { return this.abData; }
		}

		public byte ReadByte(ushort segment, ushort offset)
		{
			return this.ReadByte(MemoryRegion.ToLinearAddress(segment, offset));
		}

		public byte ReadByte(uint address)
		{
			if (!this.oRegion.CheckBounds(address))
			{
				throw new Exception("Memory block address outside bounds");
			}

			return this.abData[this.oRegion.MapAddress(address)];
		}

		public ushort ReadWord(ushort segment, ushort offset)
		{
			return this.ReadWord(MemoryRegion.ToLinearAddress(segment, offset));
		}

		public ushort ReadWord(uint address)
		{
			if (!this.oRegion.CheckBounds(address))
			{
				throw new Exception("Memory block address outside bounds");
			}
			uint uiLocation = this.oRegion.MapAddress(address);

			return (ushort)((ushort)this.abData[uiLocation] | (ushort)((ushort)this.abData[uiLocation + 1] << 8));
		}

		public uint ReadDWord(uint address)
		{
			if (!this.oRegion.CheckBounds(address))
			{
				throw new Exception("Memory block address outside bounds");
			}
			uint uiLocation = this.oRegion.MapAddress(address);

			return (uint)((uint)this.abData[uiLocation] | (uint)((uint)this.abData[uiLocation + 1] << 8) |
				(uint)((uint)this.abData[uiLocation + 2] << 16) | (uint)((uint)this.abData[uiLocation + 3] << 24));
		}

		public void WriteByte(ushort segment, ushort offset, byte value)
		{
			this.WriteByte(MemoryRegion.ToLinearAddress(segment, offset), value);
		}

		public void WriteByte(uint address, byte value)
		{
			if (!this.oRegion.CheckBounds(address))
			{
				throw new Exception("Memory block address outside bounds");
			}

			this.abData[this.oRegion.MapAddress(address)] = value;
		}

		public void WriteWord(ushort segment, ushort offset, ushort value)
		{
			this.WriteWord(MemoryRegion.ToLinearAddress(segment, offset), value);
		}

		public void WriteWord(uint address, ushort value)
		{
			if (!this.oRegion.CheckBounds(address))
			{
				throw new Exception("Memory block address outside bounds");
			}
			uint uiLocation = this.oRegion.MapAddress(address);

			this.abData[uiLocation] = (byte)(value & 0xff);
			this.abData[uiLocation + 1] = (byte)((value & 0xff00) >> 8);
		}

		public void WriteDWord(uint address, uint value)
		{
			if (!this.oRegion.CheckBounds(address))
			{
				throw new Exception("Memory block address outside bounds");
			}
			uint uiLocation = this.oRegion.MapAddress(address);

			this.abData[uiLocation] = (byte)(value & 0xff);
			this.abData[uiLocation + 1] = (byte)((value & 0xff00) >> 8);
			this.abData[uiLocation + 2] = (byte)((value & 0xff0000) >> 16);
			this.abData[uiLocation + 3] = (byte)((value & 0xff000000) >> 24);
		}

		public void Resize(uint size)
		{
			this.oRegion = new MemoryRegion(this.oRegion.Start, size);
			Array.Resize(ref this.abData, (int)size);
		}
	}
}
