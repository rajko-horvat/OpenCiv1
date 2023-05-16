using Civilization1;
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

		private CPUMemoryRegion oGPURegion_B0 = new CPUMemoryRegion((ushort)0xa000, 0, 0xffff);
		private VGACard oGPU;

		private CPU oParent;

		public CPUMemory(CPU cpu, VGACard gpu)
		{
			this.oParent = cpu;
			this.oGPU = gpu;
			this.aMemoryRegions.Add(new CPUMemoryRegion(0, uiMaxFreeAddress, CPUMemoryFlagsEnum.ReadWrite | 
				CPUMemoryFlagsEnum.ReadWarning | CPUMemoryFlagsEnum.WriteWarning));
		}

		public CPU Parent
		{
			get { return this.oParent; }
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
		public byte ReadByte(ushort segment, ushort offset)
		{
			return this.ReadByte(CPUMemory.ToLinearAddress(segment, offset));
		}

		public byte ReadByte(uint address)
		{
			if (!this.HasAccess(address, 1, CPUMemoryFlagsEnum.Read))
			{
				this.oParent.Parent.LogWriteLine($"Attempt to read byte from protected area at 0x{address:x8}");
				return 0;
			}

			for (int i = 0; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].CheckBounds(address, 1))
				{
					if ((this.aMemoryRegions[i].AccessFlags & CPUMemoryFlagsEnum.ReadWarning) == CPUMemoryFlagsEnum.ReadWarning)
						this.oParent.Parent.LogWriteLine($"Warning: Read byte at 0x{address:x8}");

					return this.aMemory[address];
				}
			}

			if (this.oGPURegion_B0.CheckBounds(address, 1))
			{
				return this.oGPU.ReadByte(this.oGPURegion_B0.MapAddress(address));
			}

			this.oParent.Parent.LogWriteLine($"Error: Attempt to read byte at undefined address 0x{address:x8}");
			return 0;
		}

		public ushort ReadWord(ushort segment, ushort offset)
		{
			return this.ReadWord(CPUMemory.ToLinearAddress(segment, offset));
		}

		public ushort ReadWord(uint address)
		{
			if (!this.HasAccess(address, 2, CPUMemoryFlagsEnum.Read))
			{
				this.oParent.Parent.LogWriteLine($"Attempt to read word from protected area at 0x{address:x8}");
				return 0;
			}

			for (int i = 0; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].CheckBounds(address, 2))
				{
					if ((this.aMemoryRegions[i].AccessFlags & CPUMemoryFlagsEnum.ReadWarning) == CPUMemoryFlagsEnum.ReadWarning)
						this.oParent.Parent.LogWriteLine($"Warning: Read word at 0x{address:x8}");

					uint uiLocation = address;

					return (ushort)((ushort)this.aMemory[uiLocation] |
						(ushort)((ushort)this.aMemory[uiLocation + 1] << 8));
				}
			}

			if (this.oGPURegion_B0.CheckBounds(address))
			{
				return this.oGPU.ReadWord(this.oGPURegion_B0.MapAddress(address));
			}

			this.oParent.Parent.LogWriteLine($"Error: Attempt to read word at undefined address 0x{address:x8}");
			return 0;
		}

		public uint ReadDWord(ushort segment, ushort offset)
		{
			return this.ReadDWord(CPUMemory.ToLinearAddress(segment, offset));
		}

		public uint ReadDWord(uint address)
		{
			if (!this.HasAccess(address, 4, CPUMemoryFlagsEnum.Read))
			{
				this.oParent.Parent.LogWriteLine($"Attempt to read dword from protected area at 0x{address:x8}");
				return 0;
			}

			for (int i = 0; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].CheckBounds(address, 4))
				{
					if ((this.aMemoryRegions[i].AccessFlags & CPUMemoryFlagsEnum.ReadWarning) == CPUMemoryFlagsEnum.ReadWarning)
						this.oParent.Parent.LogWriteLine($"Warning: Read dword at 0x{address:x8}");

					uint uiLocation = address;

					return (uint)((uint)this.aMemory[uiLocation] |
						(uint)((uint)this.aMemory[uiLocation + 1] << 8) |
						(uint)((uint)this.aMemory[uiLocation + 2] << 16) |
						(uint)((uint)this.aMemory[uiLocation + 3] << 24));
				}
			}

			if (this.oGPURegion_B0.CheckBounds(address))
			{
				return this.oGPU.ReadDWord(this.oGPURegion_B0.MapAddress(address));
			}

			this.oParent.Parent.LogWriteLine($"Error: Attempt to read dword at undefined address 0x{address:x8}");
			return 0;
		}
		#endregion

		#region Write instructions
		public void WriteByte(ushort segment, ushort offset, byte value)
		{
			this.WriteByte(CPUMemory.ToLinearAddress(segment, offset), value);
		}

		public void WriteByte(uint address, byte value)
		{
			if (!this.HasAccess(address, 1, CPUMemoryFlagsEnum.Write))
			{
				this.oParent.Parent.LogWriteLine($"Attempt to write to protected area at 0x{address:x8}");
				return;
			}

			bool bFound = false;
			for (int i = 0; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].CheckBounds(address, 1))
				{
					if ((this.aMemoryRegions[i].AccessFlags & CPUMemoryFlagsEnum.WriteWarning) == CPUMemoryFlagsEnum.WriteWarning)
						this.oParent.Parent.LogWriteLine($"Warning: Write byte at 0x{address:x8}");

					this.aMemory[address] = value;
					bFound = true;
					break;
				}
			}

			if (this.oGPURegion_B0.CheckBounds(address))
			{
				this.oGPU.WriteByte(this.oGPURegion_B0.MapAddress(address), value);
				bFound = true;
			}

			if (!bFound)
				this.oParent.Parent.LogWriteLine($"Error: Attempt to write byte at undefined address 0x{address:x8}");
		}

		public void WriteWord(ushort segment, ushort offset, ushort value)
		{
			this.WriteWord(CPUMemory.ToLinearAddress(segment, offset), value);
		}

		public void WriteWord(uint address, ushort value)
		{
			if (!this.HasAccess(address, 2, CPUMemoryFlagsEnum.Write))
			{
				this.oParent.Parent.LogWriteLine($"Attempt to write to protected area at 0x{address:x8}");
				return;
			}

			bool bFound = false;
			for (int i = 0; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].CheckBounds(address, 2))
				{
					if ((this.aMemoryRegions[i].AccessFlags & CPUMemoryFlagsEnum.WriteWarning) == CPUMemoryFlagsEnum.WriteWarning)
						this.oParent.Parent.LogWriteLine($"Warning: Write word at 0x{address:x8}");

					uint uiLocation = address;

					this.aMemory[uiLocation] = (byte)(value & 0xff);
					this.aMemory[uiLocation + 1] = (byte)((value & 0xff00) >> 8);
					bFound = true;
					break;
				}
			}

			if (this.oGPURegion_B0.CheckBounds(address))
			{
				this.oGPU.WriteWord(this.oGPURegion_B0.MapAddress(address), value);
				bFound = true;
			}

			if (!bFound)
				this.oParent.Parent.LogWriteLine($"Error: Attempt to write word at undefined address 0x{address:x8}");
		}

		public void WriteDWord(ushort segment, ushort offset, uint value)
		{
			this.WriteDWord(CPUMemory.ToLinearAddress(segment, offset), value);
		}

		public void WriteDWord(uint address, uint value)
		{
			if (!this.HasAccess(address, 4, CPUMemoryFlagsEnum.Write))
			{
				this.oParent.Parent.LogWriteLine($"Attempt to write to protected area at 0x{address:x8}");
				return;
			}

			bool bFound = false;
			for (int i = 0; i < this.aMemoryRegions.Count; i++)
			{
				if (this.aMemoryRegions[i].CheckBounds(address, 4))
				{
					if ((this.aMemoryRegions[i].AccessFlags & CPUMemoryFlagsEnum.WriteWarning) == CPUMemoryFlagsEnum.WriteWarning)
						this.oParent.Parent.LogWriteLine($"Warning: Write dword at 0x{address:x8}");

					uint uiLocation = address;

					this.aMemory[uiLocation] = (byte)(value & 0xff);
					this.aMemory[uiLocation + 1] = (byte)((value & 0xff00) >> 8);
					this.aMemory[uiLocation + 2] = (byte)((value & 0xff0000) >> 16);
					this.aMemory[uiLocation + 3] = (byte)((value & 0xff000000) >> 24);
					bFound = true;
					break;
				}
			}
			if (this.oGPURegion_B0.CheckBounds(address))
			{
				this.oGPU.WriteDWord(this.oGPURegion_B0.MapAddress(address), value);
				bFound = true;
			}

			if (!bFound)
				this.oParent.Parent.LogWriteLine($"Error: Attempt to write dword at undefined address 0x{address:x8}");
		}

		public void WriteBlock(ushort segment, ushort offset, byte[] srcData, int pos, int length)
		{
			WriteBlock(CPUMemory.ToLinearAddress(segment, offset), srcData, pos, length);
		}

		public void WriteBlock(uint address, byte[] srcData, int pos, int length)
		{
			for (int i = 0; i < length; i++)
			{
				WriteByte((uint)(address + i), srcData[pos + i]);
			}
		}
		#endregion

		#region Memory allocation
		public bool AllocateMemoryBlock(uint address, uint size)
		{
			return AllocateMemoryBlock(address, size, CPUMemoryFlagsEnum.ReadWrite);
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

			this.aMemoryRegions.Add(new CPUMemoryRegion(address, size, CPUMemoryFlagsEnum.ReadWrite));

			AdjustFreeMemoryRange();

			return true;
		}

		public bool AllocateMemoryBlock(ushort segmentCount, out ushort startSegment)
		{
			uint uiSize = CPUMemory.ToLinearAddress(segmentCount, 0);

			// Just allocate next available block, don't search between blocks for now
			// Is there enough room for allocation?
			if (this.aMemoryRegions[0].Size < uiSize)
			{
				startSegment = (ushort)((this.aMemoryRegions[0].Size >> 4) & 0xffff);
				return false;
			}

			// allocate block
			startSegment = (ushort)((this.aMemoryRegions[0].Start >> 4) & 0xffff);
			this.aMemoryRegions.Add(new CPUMemoryRegion(this.aMemoryRegions[0].Start, uiSize, CPUMemoryFlagsEnum.ReadWrite));

			AdjustFreeMemoryRange();

			return true;
		}

		public bool ResizeMemoryBlock(ushort blockSegment, ushort segmentCount)
		{
			return ResizeMemoryBlock(CPUMemory.ToLinearAddress(blockSegment, 0),
				CPUMemory.ToLinearAddress(segmentCount, 0));
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
			uint uiAddress = CPUMemory.ToLinearAddress(segment, 0);

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

		public static uint ToLinearAddress(ushort segment, ushort offset)
		{
			// 1MB limit!
			return ((uint)((uint)segment << 4) + (uint)offset) & 0xfffff;
		}

		public static void AlignToSegment(ref uint address)
		{
			if ((address & 0xf) != 0)
			{
				address &= 0xffff0;
				address += 0x10;
			}
		}
	}
}
