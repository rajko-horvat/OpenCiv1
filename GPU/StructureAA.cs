using Disassembler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civilization1.GPU
{
	public class StructureAA
	{
		private CPU oCPU;
		private uint uiStructPtr;

		public StructureAA(CPU cpu, uint structPtr)
		{
			this.oCPU = cpu;
			this.uiStructPtr = structPtr;
		}

		public ushort ScreenID
		{
			get { return this.oCPU.Memory.ReadWord(this.uiStructPtr); }
			set { this.oCPU.Memory.WriteWord(this.uiStructPtr, value); }
		}

		public short X
		{
			get { return (short)this.oCPU.Memory.ReadWord(this.uiStructPtr + 2); }
			set { this.oCPU.Memory.WriteWord(this.uiStructPtr + 2, (ushort)value); }
		}

		public short Y
		{
			get { return (short)this.oCPU.Memory.ReadWord(this.uiStructPtr + 4); }
			set { this.oCPU.Memory.WriteWord(this.uiStructPtr + 4, (ushort)value); }
		}

		public short Width
		{
			get { return (short)this.oCPU.Memory.ReadWord(this.uiStructPtr + 6); }
			set { this.oCPU.Memory.WriteWord(this.uiStructPtr + 6, (ushort)value); }
		}

		public short Height
		{
			get { return (short)this.oCPU.Memory.ReadWord(this.uiStructPtr + 8); }
			set { this.oCPU.Memory.WriteWord(this.uiStructPtr + 8, (ushort)value); }
		}

		public ushort Flags
		{
			get { return this.oCPU.Memory.ReadWord(this.uiStructPtr + 0xa); }
			set { this.oCPU.Memory.WriteWord(this.uiStructPtr + 0xa, value); }
		}

		public byte FrontColor
		{
			get { return this.oCPU.Memory.ReadByte(this.uiStructPtr + 0xc); }
			set { this.oCPU.Memory.WriteByte(this.uiStructPtr + 0xc, value); }
		}

		public byte PixelMode
		{
			get { return this.oCPU.Memory.ReadByte(this.uiStructPtr + 0xd); }
			set { this.oCPU.Memory.WriteByte(this.uiStructPtr + 0xd, value); }
		}

		public byte BackColor
		{
			get { return this.oCPU.Memory.ReadByte(this.uiStructPtr + 0xe); }
			set { this.oCPU.Memory.WriteByte(this.uiStructPtr + 0xe, value); }
		}

		public ushort FontID
		{
			get { return this.oCPU.Memory.ReadWord(this.uiStructPtr + 0x10); }
			set { this.oCPU.Memory.WriteWord(this.uiStructPtr + 0x10, value); }
		}
	}
}
