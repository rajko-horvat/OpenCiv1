﻿using System;

namespace IRB.VirtualCPU
{
    [Flags]
    public enum CPUMemoryFlagsEnum
    {
        None = 0,
        Write = 1,
        Read = 2,
        ReadWrite = 3,
        ReadWarning = 4,
        WriteWarning = 8,
        AccessNotAllowed = 16
    }

    public class CPUMemoryRegion
    {
        private uint uiStart;
        private uint uiSize;
        private CPUMemoryFlagsEnum eAccessFlags;

        public CPUMemoryRegion(ushort segment, ushort offset, uint size)
            : this(CPU.ToLinearAddress(segment, offset), size, CPUMemoryFlagsEnum.ReadWrite)
        {
        }

        public CPUMemoryRegion(ushort segment, ushort offset, uint size, CPUMemoryFlagsEnum access)
            : this(CPU.ToLinearAddress(segment, offset), size, access)
        {
        }

        public CPUMemoryRegion(uint start, uint size)
            : this(start, size, CPUMemoryFlagsEnum.ReadWrite)
        {
        }

        public CPUMemoryRegion(uint start, uint size, CPUMemoryFlagsEnum access)
        {
            this.uiStart = start;
            this.uiSize = size;
            this.eAccessFlags = access;
        }

        public CPUMemoryFlagsEnum AccessFlags
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
            set
            {
                this.uiStart = value;
            }
        }

        public uint Size
        {
            get
            {
                return this.uiSize;
            }
            set
            {
                this.uiSize = value;
            }
        }

        public uint End
        {
            get
            {
                return (uint)(this.uiStart + this.uiSize - 1);
            }
            set
            {
                this.uiSize = (value - this.uiStart) + 1;
            }
        }

        public bool CheckBounds(ushort segment, ushort offset)
        {
            return this.CheckBounds(CPU.ToLinearAddress(segment, offset), 1);
        }

        public bool CheckBounds(ushort segment, ushort offset, uint size)
        {
            return this.CheckBounds(CPU.ToLinearAddress(segment, offset), size);
        }

        public bool CheckBounds(uint address)
        {
            return this.CheckBounds(address, 1);
        }

        public bool CheckBounds(uint address, uint size)
        {
            if (address >= this.uiStart && ((address + size) - 1) < (this.uiStart + this.uiSize))
            {
                return true;
            }

            return false;
        }

        public bool CheckOverlap(ushort segment, ushort offset, uint size)
        {
            return this.CheckOverlap(CPU.ToLinearAddress(segment, offset), size);
        }

        public bool CheckOverlap(uint address, uint size)
        {
            if ((address >= this.uiStart && address < this.uiStart + this.uiSize) ||
                (address <= (this.uiStart + this.uiSize - 1) && (address + size - 1) >= this.uiStart))
            {
                return true;
            }
            return false;
        }

        public uint MapAddress(ushort segment, ushort offset)
        {
            return this.MapAddress(CPU.ToLinearAddress(segment, offset));
        }

        public uint MapAddress(uint address)
        {
            return (uint)(address - this.uiStart);
        }

        public override string ToString()
        {
            return $"0x{this.Start:x8} - {this.End:x8} ({this.Size:x8})";
        }
    }
}
