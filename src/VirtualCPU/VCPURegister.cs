namespace IRB.VirtualCPU
{
	public class VCPURegister
	{
		private uint uiValue = 0;

		public VCPURegister()
		{ }

		public VCPURegister(uint value)
		{
			this.uiValue = value;
		}

		public byte LowUInt8
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

		public sbyte LowInt8
		{
			get
			{
				return (sbyte)(this.uiValue & 0xff);
			}
			set
			{
				this.uiValue = (uint)((this.uiValue & 0xffffff00) | (byte)value);
			}
		}

		public byte HighUInt8
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

		public sbyte HighInt8
		{
			get
			{
				return (sbyte)((this.uiValue & 0xff00) >> 8);
			}
			set
			{
				this.uiValue = (uint)((this.uiValue & 0xffff00ff) | ((uint)value << 8));
			}
		}

		public ushort UInt16
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

		public short Int16
		{
			get
			{
				return (short)((ushort)(this.uiValue & 0xffff));
			}
			set
			{
				this.uiValue = (uint)((this.uiValue & 0xffff0000) | (ushort)value);
			}
		}


		public ushort HighUInt16
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

		public short HighInt16
		{
			get
			{
				return (short)((ushort)((this.uiValue & 0xffff0000) >> 16));
			}
			set
			{
				this.uiValue = (uint)((this.uiValue & 0xffff) | ((uint)value << 16));
			}
		}

		public uint UInt32
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

		public int Int32
		{
			get
			{
				return (int)this.uiValue;
			}
			set
			{
				this.uiValue = (uint)value;
			}
		}

		public override string ToString()
		{
			return $"0x{this.UInt32:x8}";
		}
	}
}
