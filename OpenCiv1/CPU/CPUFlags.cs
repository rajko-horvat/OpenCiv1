namespace IRB.VirtualCPU
{
    public class CPUFlags
    {
        private ushort usValue = 0x2;

        public bool C
        {
            get
            {
                return (this.usValue & 0x1) != 0;
            }
            set
            {
                this.usValue |= 0x1;
                if (!value)
                    this.usValue ^= 0x1;
            }
        }

        public bool NC
        {
            get
            {
                return (this.usValue & 0x1) == 0;
            }
        }

        public bool Z
        {
            get
            {
                return (this.usValue & 0x40) != 0;
            }
            set
            {
                this.usValue |= 0x40;
                if (!value)
                    this.usValue ^= 0x40;
            }
        }

        public bool E
        {
            get
            {
                return (this.usValue & 0x40) != 0;
            }
            set
            {
                this.usValue |= 0x40;
                if (!value)
                    this.usValue ^= 0x40;
            }
        }

        public bool S
        {
            get
            {
                return (this.usValue & 0x80) != 0;
            }
            set
            {
                this.usValue |= 0x80;
                if (!value)
                    this.usValue ^= 0x80;
            }
        }

        public bool D
        {
            get
            {
                return (this.usValue & 0x400) != 0;
            }
            set
            {
                this.usValue |= 0x400;
                if (!value)
                    this.usValue ^= 0x400;
            }
        }

        public bool O
        {
            get
            {
                return (this.usValue & 0x800) != 0;
            }
            set
            {
                this.usValue |= 0x800;
                if (!value)
                    this.usValue ^= 0x800;
            }
        }

        public bool A
        {
            get { return !this.C && !this.Z; }
        }

        public bool AE
        {
            get { return !this.C; }
        }

        public bool B
        {
            get { return this.C; }
        }

        public bool BE
        {
            get { return this.C || this.Z; }
        }

        public bool NZ
        {
            get { return !this.Z; }
        }

        public bool NE
        {
            get { return !this.Z; }
        }

        public bool G
        {
            get { return !((this.S ^ this.O) | this.Z); }
        }

        public bool GE
        {
            get { return !(this.S ^ this.O); }
        }

        public bool L
        {
            get { return this.S ^ this.O; }
        }

        public bool LE
        {
            get { return (this.S ^ this.O) | this.Z; }
        }

        public bool NO
        {
            get { return !this.O; }
        }

        public bool NS
        {
            get { return !this.S; }
        }

        public ushort Value
        {
            get
            {
                return this.usValue;
            }
            set
            {
                this.usValue = value;
            }
        }
    }
}
