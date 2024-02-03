namespace IRB.VirtualCPU
{
    public class CPURegister
    {
        private uint uiValue = 0;

        public CPURegister()
        { }

        public CPURegister(uint value)
        {
            this.uiValue = value;
        }

        public byte Low
        {
            get
            {
                return (byte)(this.uiValue & 0xff);
            }
            set
            {
                this.uiValue = (uint)((this.uiValue & 0xffffff00) | value);
            }
        }

        public byte High
        {
            get
            {
                return (byte)((this.uiValue & 0xff00) >> 8);
            }
            set
            {
                this.uiValue = (uint)((this.uiValue & 0xffff00ff) | ((uint)value << 8));
            }
        }

        public ushort Word
        {
            get
            {
                return (ushort)(this.uiValue & 0xffff);
            }
            set
            {
                this.uiValue = (uint)((this.uiValue & 0xffff0000) | (uint)value);
            }
        }

        public ushort HighWord
        {
            get
            {
                return (ushort)((this.uiValue & 0xffff0000) >> 16);
            }
            set
            {
                this.uiValue = (uint)((this.uiValue & 0xffff) | ((uint)value << 16));
            }
        }

        public uint DWord
        {
            get
            {
                return this.uiValue;
            }
            set
            {
                this.uiValue = value;
            }
        }

        public override string ToString()
        {
            return $"0x{this.HighWord:x4}:0x{this.Word:x4}";
        }
    }
}
