using IRB.VirtualCPU;

namespace OpenCiv1.GPU
{
    public class CivRectangle
    {
        private CPU oCPU;
        private uint uiStructPtr;

        public CivRectangle(CPU cpu, uint structPtr)
        {
            this.oCPU = cpu;
            this.uiStructPtr = structPtr;
        }

        public ushort ScreenID
        {
            get { return this.oCPU.Memory.ReadUInt16(this.uiStructPtr); }
            set { this.oCPU.Memory.WriteUInt16(this.uiStructPtr, value); }
        }

        public short X
        {
            get { return (short)this.oCPU.Memory.ReadUInt16(this.uiStructPtr + 2); }
            set { this.oCPU.Memory.WriteUInt16(this.uiStructPtr + 2, (ushort)value); }
        }

        public short Y
        {
            get { return (short)this.oCPU.Memory.ReadUInt16(this.uiStructPtr + 4); }
            set { this.oCPU.Memory.WriteUInt16(this.uiStructPtr + 4, (ushort)value); }
        }

        public short Width
        {
            get { return (short)this.oCPU.Memory.ReadUInt16(this.uiStructPtr + 6); }
            set { this.oCPU.Memory.WriteUInt16(this.uiStructPtr + 6, (ushort)value); }
        }

        public short Height
        {
            get { return (short)this.oCPU.Memory.ReadUInt16(this.uiStructPtr + 8); }
            set { this.oCPU.Memory.WriteUInt16(this.uiStructPtr + 8, (ushort)value); }
        }

        public ushort Flags
        {
            get { return this.oCPU.Memory.ReadUInt16(this.uiStructPtr + 0xa); }
            set { this.oCPU.Memory.WriteUInt16(this.uiStructPtr + 0xa, value); }
        }

        public byte FrontColor
        {
            get { return this.oCPU.Memory.ReadUInt8(this.uiStructPtr + 0xc); }
            set { this.oCPU.Memory.WriteUInt8(this.uiStructPtr + 0xc, value); }
        }

        public byte PixelMode
        {
            get { return this.oCPU.Memory.ReadUInt8(this.uiStructPtr + 0xd); }
            set { this.oCPU.Memory.WriteUInt8(this.uiStructPtr + 0xd, value); }
        }

        public byte BackColor
        {
            get { return this.oCPU.Memory.ReadUInt8(this.uiStructPtr + 0xe); }
            set { this.oCPU.Memory.WriteUInt8(this.uiStructPtr + 0xe, value); }
        }

        public ushort FontID
        {
            get { return this.oCPU.Memory.ReadUInt16(this.uiStructPtr + 0x10); }
            set { this.oCPU.Memory.WriteUInt16(this.uiStructPtr + 0x10, value); }
        }
    }
}
