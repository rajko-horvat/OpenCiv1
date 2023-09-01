using OpenCiv1;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Disassembler
{
	public class CPUMemory
	{
		private static uint uiMinFreeAddress = 0x0;
		private static uint uiMaxFreeAddress = 0x9ffff;
		private static uint uiMemorySize = 0xa0000;

		private byte[] aMemory = new byte[uiMemorySize];
		private List<CPUMemoryRegion> aMemoryRegions = new List<CPUMemoryRegion>();

		private CPUMemoryRegion oGPURegion = new CPUMemoryRegion((ushort)0xa000, 0, 0x10000);
		private CPU oCPU;

		public CPUMemory(CPU cpu)
		{
			this.oCPU = cpu;
			this.aMemoryRegions.Add(new CPUMemoryRegion(0, uiMaxFreeAddress, CPUMemoryFlagsEnum.ReadWrite | 
				CPUMemoryFlagsEnum.ReadWarning | CPUMemoryFlagsEnum.WriteWarning));
		}

		public CPU Parent
		{
			get { return this.oCPU; }
		}

		public byte[] MemoryContent
		{
			get { return this.aMemory; }
		}

		public CPUMemoryRegion FreeMemory
		{
			get { return this.aMemoryRegions[0]; }
		}

		public List<CPUMemoryRegion> MemoryRegions
		{
			get
			{
				return this.aMemoryRegions;
			}
		}

		#region Check Access
		public bool HasAccess(uint address, uint size, CPUMemoryFlagsEnum access)
		{
			uint uiCount = 0;

			for (int i = 0; i < size; i++)
			{
				bool bFound = false;
				for (int j = 0; j < this.aMemoryRegions.Count; j++)
				{
					if (this.aMemoryRegions[j].CheckBounds(address, 1))
					{
						bFound = true;
						if ((this.aMemoryRegions[j].AccessFlags & access) == access)
						{
							uiCount++;
							break;
						}
					}
				}
				// if address is not found in any region, assume full rights
				if (!bFound)
					uiCount++;
			}
			if (uiCount == size)
				return true;

			return false;
		}
		#endregion

		#region Read instructions
		public sbyte ReadInt8(ushort segment, ushort offset)
		{
			return (sbyte)this.ReadUInt8(CPU.ToLinearAddress(segment, offset));
		}

		public sbyte ReadInt8(uint address)
		{
			return (sbyte)this.ReadUInt8(address);
		}

		public byte ReadUInt8(ushort segment, ushort offset)
		{
			return this.ReadUInt8(CPU.ToLinearAddress(segment, offset));
		}

		public byte ReadUInt8(uint address)
		{
			if (!this.HasAccess(address, 1, CPUMemoryFlagsEnum.Read))
			{
				this.oCPU.Log.WriteLine($"// Attempt to read byte from protected area at 0x{address:x8}");
				return 0;
			}

			for (int i = 0; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].CheckBounds(address, 1))
				{
					if ((this.aMemoryRegions[i].AccessFlags & CPUMemoryFlagsEnum.ReadWarning) == CPUMemoryFlagsEnum.ReadWarning)
						this.oCPU.Log.WriteLine($"// Warning: Read byte at 0x{address:x8}");

					return this.aMemory[address];
				}
			}

			if (this.oGPURegion.CheckBounds(address, 1))
			{
				this.oCPU.Log.WriteLine($"// Error: Attempt to read byte in VGA memory at address 0x{address:x8}");
				return 0;
			}

			this.oCPU.Log.WriteLine($"// Error: Attempt to read byte at undefined address 0x{address:x8}");
			return 0;
		}

		public short ReadInt16(ushort segment, ushort offset)
		{
			return (short)this.ReadUInt16(CPU.ToLinearAddress(segment, offset));
		}

		public short ReadInt16(uint address)
		{
			return (short)this.ReadUInt16(address);
		}

		public ushort ReadUInt16(ushort segment, ushort offset)
		{
			return this.ReadUInt16(CPU.ToLinearAddress(segment, offset));
		}

		public ushort ReadUInt16(uint address)
		{
			if (!this.HasAccess(address, 2, CPUMemoryFlagsEnum.Read))
			{
				this.oCPU.Log.WriteLine($"// Attempt to read word from protected area at 0x{address:x8}");
				return 0;
			}

			for (int i = 0; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].CheckBounds(address, 2))
				{
					if ((this.aMemoryRegions[i].AccessFlags & CPUMemoryFlagsEnum.ReadWarning) == CPUMemoryFlagsEnum.ReadWarning)
						this.oCPU.Log.WriteLine($"// Warning: Read word at 0x{address:x8}");

					uint uiLocation = address;

					return (ushort)((ushort)this.aMemory[uiLocation] |
						(ushort)((ushort)this.aMemory[uiLocation + 1] << 8));
				}
			}

			if (this.oGPURegion.CheckBounds(address))
			{
				this.oCPU.Log.WriteLine($"// Error: Attempt to read word in VGA memory at address 0x{address:x8}");
				return 0;
			}

			this.oCPU.Log.WriteLine($"// Error: Attempt to read word at undefined address 0x{address:x8}");
			return 0;
		}

		public int ReadInt32(ushort segment, ushort offset)
		{
			return (int)this.ReadUInt32(CPU.ToLinearAddress(segment, offset));
		}

		public int ReadInt32(uint address)
		{
			return (int)this.ReadUInt32(address);
		}

		public uint ReadUInt32(ushort segment, ushort offset)
		{
			return this.ReadUInt32(CPU.ToLinearAddress(segment, offset));
		}

		public uint ReadUInt32(uint address)
		{
			if (!this.HasAccess(address, 4, CPUMemoryFlagsEnum.Read))
			{
				this.oCPU.Log.WriteLine($"// Attempt to read dword from protected area at 0x{address:x8}");
				return 0;
			}

			for (int i = 0; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].CheckBounds(address, 4))
				{
					if ((this.aMemoryRegions[i].AccessFlags & CPUMemoryFlagsEnum.ReadWarning) == CPUMemoryFlagsEnum.ReadWarning)
						this.oCPU.Log.WriteLine($"// Warning: Read dword at 0x{address:x8}");

					uint uiLocation = address;

					return (uint)((uint)this.aMemory[uiLocation] |
						(uint)((uint)this.aMemory[uiLocation + 1] << 8) |
						(uint)((uint)this.aMemory[uiLocation + 2] << 16) |
						(uint)((uint)this.aMemory[uiLocation + 3] << 24));
				}
			}

			if (this.oGPURegion.CheckBounds(address))
			{
				this.oCPU.Log.WriteLine($"// Error: Attempt to read dword in VGA memory at address 0x{address:x8}");
				return 0;
			}

			this.oCPU.Log.WriteLine($"Error: Attempt to read dword at undefined address 0x{address:x8}");
			return 0;
		}
		#endregion

		#region Write instructions
		#region 8 bit
		public void WriteInt8(ushort segment, ushort offset, sbyte value)
		{
			this.WriteUInt8(CPU.ToLinearAddress(segment, offset), (byte)value);
		}

		public void WriteInt8(uint address, sbyte value)
		{
			this.WriteUInt8(address, (byte)value);
		}

		public void WriteInt8(ushort segment, ushort offset, int value)
		{
			if (value < SByte.MinValue || value > SByte.MaxValue)
				throw new Exception($"Value {value} out of range for Int8");

			this.WriteUInt8(CPU.ToLinearAddress(segment, offset), (byte)((sbyte)value));
		}

		public void WriteInt8(uint address, int value)
		{
			if (value < SByte.MinValue || value > SByte.MaxValue)
				throw new Exception($"Value {value} out of range for Int8");

			this.WriteUInt8(address, (byte)((sbyte)value));
		}

		public void WriteUInt8(ushort segment, ushort offset, int value)
		{
			if (value < 0 || value > Byte.MaxValue)
				throw new Exception($"Value {value} out of range for UInt8");

			this.WriteUInt8(CPU.ToLinearAddress(segment, offset), (byte)value);
		}

		public void WriteUInt8(uint address, int value)
		{
			if (value < 0 || value > Byte.MaxValue)
				throw new Exception($"Value {value} out of range for UInt8");

			this.WriteUInt8(address, (byte)value);
		}

		public void WriteUInt8(ushort segment, ushort offset, byte value)
		{
			this.WriteUInt8(CPU.ToLinearAddress(segment, offset), value);
		}

		public void WriteUInt8(uint address, byte value)
		{
			if (!this.HasAccess(address, 1, CPUMemoryFlagsEnum.Write))
			{
				this.oCPU.Log.WriteLine($"// Attempt to write to protected area at 0x{address:x8}");
				return;
			}

			bool bFound = false;
			for (int i = 0; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].CheckBounds(address, 1))
				{
					if ((this.aMemoryRegions[i].AccessFlags & CPUMemoryFlagsEnum.WriteWarning) == CPUMemoryFlagsEnum.WriteWarning)
						this.oCPU.Log.WriteLine($"// Warning: Write byte at 0x{address:x8}");

					this.aMemory[address] = value;
					bFound = true;
					break;
				}
			}

			if (this.oGPURegion.CheckBounds(address))
			{
				this.oCPU.Log.WriteLine($"// Error: Attempt to write byte to VGA memory at address 0x{address:x8}");
				bFound = true;
			}

			if (!bFound)
				this.oCPU.Log.WriteLine($"// Error: Attempt to write byte at undefined address 0x{address:x8}");
		}
		#endregion

		#region 16 bit
		public void WriteInt16(ushort segment, ushort offset, short value)
		{
			this.WriteUInt16(CPU.ToLinearAddress(segment, offset), (ushort)value);
		}

		public void WriteInt16(uint address, short value)
		{
			this.WriteUInt16(address, (ushort)value);
		}

		public void WriteInt16(ushort segment, ushort offset, int value)
		{
			if (value < Int16.MinValue || value > Int16.MaxValue)
				throw new Exception($"Value {value} out of range for Int16");

			this.WriteUInt16(CPU.ToLinearAddress(segment, offset), (ushort)((short)value));
		}

		public void WriteInt16(uint address, int value)
		{
			if (value < Int16.MinValue || value > Int16.MaxValue)
				throw new Exception($"Value {value} out of range for Int16");

			this.WriteUInt16(address, (ushort)((short)value));
		}

		public void WriteUInt16(ushort segment, ushort offset, int value)
		{
			if (value < 0 || value > UInt16.MaxValue)
				throw new Exception($"Value {value} out of range for UInt16");

			this.WriteUInt16(CPU.ToLinearAddress(segment, offset), (ushort)value);
		}

		public void WriteUInt16(uint address, int value)
		{
			if (value < 0 || value > UInt16.MaxValue)
				throw new Exception($"Value {value} out of range for UInt16");

			this.WriteUInt16(address, (ushort)value);
		}

		public void WriteUInt16(ushort segment, ushort offset, ushort value)
		{
			this.WriteUInt16(CPU.ToLinearAddress(segment, offset), value);
		}

		public void WriteUInt16(uint address, ushort value)
		{
			if (!this.HasAccess(address, 2, CPUMemoryFlagsEnum.Write))
			{
				this.oCPU.Log.WriteLine($"// Attempt to write to protected area at 0x{address:x8}");
				return;
			}

			bool bFound = false;
			for (int i = 0; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].CheckBounds(address, 2))
				{
					if ((this.aMemoryRegions[i].AccessFlags & CPUMemoryFlagsEnum.WriteWarning) == CPUMemoryFlagsEnum.WriteWarning)
						this.oCPU.Log.WriteLine($"// Warning: Write word at 0x{address:x8}");

					uint uiLocation = address;

					this.aMemory[uiLocation] = (byte)(value & 0xff);
					this.aMemory[uiLocation + 1] = (byte)((value & 0xff00) >> 8);
					bFound = true;
					break;
				}
			}

			if (this.oGPURegion.CheckBounds(address))
			{
				this.oCPU.Log.WriteLine($"// Error: Attempt to write word to VGA memory at address 0x{address:x8}");
				bFound = true;
			}

			if (!bFound)
				this.oCPU.Log.WriteLine($"// Error: Attempt to write word at undefined address 0x{address:x8}");
		}
		#endregion

		#region 32 bit
		public void WriteInt32(ushort segment, ushort offset, int value)
		{
			this.WriteUInt32(CPU.ToLinearAddress(segment, offset), (uint)value);
		}

		public void WriteInt32(uint address, int value)
		{
			this.WriteUInt32(address, (uint)value);
		}

		public void WriteUInt32(ushort segment, ushort offset, uint value)
		{
			this.WriteUInt32(CPU.ToLinearAddress(segment, offset), value);
		}

		public void WriteUInt32(uint address, uint value)
		{
			if (!this.HasAccess(address, 4, CPUMemoryFlagsEnum.Write))
			{
				this.oCPU.Log.WriteLine($"// Attempt to write to protected area at 0x{address:x8}");
				return;
			}

			bool bFound = false;
			for (int i = 0; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].CheckBounds(address, 4))
				{
					if ((this.aMemoryRegions[i].AccessFlags & CPUMemoryFlagsEnum.WriteWarning) == CPUMemoryFlagsEnum.WriteWarning)
						this.oCPU.Log.WriteLine($"// Warning: Write dword at 0x{address:x8}");

					uint uiLocation = address;

					this.aMemory[uiLocation] = (byte)(value & 0xff);
					this.aMemory[uiLocation + 1] = (byte)((value & 0xff00) >> 8);
					this.aMemory[uiLocation + 2] = (byte)((value & 0xff0000) >> 16);
					this.aMemory[uiLocation + 3] = (byte)((value & 0xff000000) >> 24);
					bFound = true;
					break;
				}
			}
			if (this.oGPURegion.CheckBounds(address))
			{
				this.oCPU.Log.WriteLine($"// Error: Attempt to write dword to VGA memory at address 0x{address:x8}");
				bFound = true;
			}

			if (!bFound)
				this.oCPU.Log.WriteLine($"// Error: Attempt to write dword at undefined address 0x{address:x8}");
		}
		#endregion
		#endregion

		#region Block instructions
		public void WriteBlock(ushort segment, ushort offset, byte[] srcData, int pos, int length)
		{
			WriteBlock(CPU.ToLinearAddress(segment, offset), srcData, pos, length);
		}

		public void WriteBlock(uint address, byte[] srcData, int pos, int length)
		{
			Array.Copy(srcData, pos, this.aMemory, address, length);
			/*for (int i = 0; i < length; i++)
			{
				WriteUInt8((uint)(address + i), srcData[pos + i]);
			}*/
		}
		#endregion

		#region Memory allocation
		public bool AllocateMemoryBlock(uint address, uint size)
		{
			return AllocateMemoryBlock(address, size, CPUMemoryFlagsEnum.ReadWrite | CPUMemoryFlagsEnum.WriteWarning);
		}

		public bool AllocateMemoryBlock(uint address, uint size, CPUMemoryFlagsEnum flags)
		{
			for (int i = 1; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].CheckBounds(address, size))
				{
					return false;
				}
			}

			this.aMemoryRegions.Add(new CPUMemoryRegion(address, size, flags));

			AdjustFreeMemoryRange();

			return true;
		}

		public bool AllocateMemoryBlock(ushort segmentCount, out ushort startSegment)
		{
			uint uiSize = CPU.ToLinearAddress(segmentCount, 0);

			// Just allocate next available block, don't search between blocks for now
			// Is there enough room for allocation?
			if (this.aMemoryRegions[0].Size < uiSize)
			{
				startSegment = (ushort)((this.aMemoryRegions[0].Size >> 4) & 0xffff);
				return false;
			}

			// allocate block
			startSegment = (ushort)((this.aMemoryRegions[0].Start >> 4) & 0xffff);
			this.aMemoryRegions.Add(new CPUMemoryRegion(this.aMemoryRegions[0].Start, uiSize, CPUMemoryFlagsEnum.ReadWrite | CPUMemoryFlagsEnum.WriteWarning));

			AdjustFreeMemoryRange();

			return true;
		}

		public bool ResizeMemoryBlock(ushort blockSegment, ushort segmentCount)
		{
			return ResizeMemoryBlock(CPU.ToLinearAddress(blockSegment, 0),
				CPU.ToLinearAddress(segmentCount, 0));
		}

		public bool ResizeMemoryBlock(uint address, uint size)
		{
			for (int i = 1; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].Start == address)
				{
					// found the block
					// check for overlapping
					for (int j = 1; j < this.aMemoryRegions.Count; j++)
					{
						if (j != i && this.aMemoryRegions[j].CheckOverlap(address, size))
							return false;
					}

					this.aMemoryRegions[i].Size = size;

					AdjustFreeMemoryRange();

					return true;
				}
			}

			return false;
		}

		public bool FreeMemoryBlock(ushort segment)
		{
			uint uiAddress = CPU.ToLinearAddress(segment, 0);

			for (int i = 1; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].Start == uiAddress)
				{
					// found the block
					this.aMemoryRegions.RemoveAt(i);
					return true;
				}
			}

			return false;
		}

		private void AdjustFreeMemoryRange()
		{
			CPUMemoryRegion oFree = this.aMemoryRegions[0];
			oFree.Start = uiMinFreeAddress;

			// adjust free memory
			for (int i = 1; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].End + 1 >= oFree.Start)
				{
					oFree.Start = this.aMemoryRegions[i].End + 1;
					oFree.End = uiMaxFreeAddress;
				}
			}
		}
		#endregion
	}
}
