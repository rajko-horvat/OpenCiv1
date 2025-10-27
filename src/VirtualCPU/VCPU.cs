using System.Reflection;
using System.Text;
using OpenCiv1;
using IRB.Collections.Generic;
using OpenCiv1.Graphics;
using System.Threading;

namespace IRB.VirtualCPU
{
	public class VCPU
	{
		// state
		private bool bPause = false;

		// flags
		private VCPUFlags oFlags = new VCPUFlags();

		// registers
		private VCPURegister oAX = new VCPURegister();
		private VCPURegister oBX = new VCPURegister();
		private VCPURegister oCX = new VCPURegister();
		private VCPURegister oDX = new VCPURegister();
		private VCPURegister oBP = new VCPURegister();
		private VCPURegister oSP = new VCPURegister();
		private VCPURegister oSI = new VCPURegister();
		private VCPURegister oDI = new VCPURegister();
		private VCPURegister oDS = new VCPURegister();
		private VCPURegister oES = new VCPURegister();
		private VCPURegister oSS = new VCPURegister();
		private VCPURegister oCS = new VCPURegister();

		// temporary registers
		private VCPURegister oTemp = new VCPURegister();

		// memory
		private VCPUMemory oMemory;

		// Timer(s)
		private bool bEnableInterrupt = true;
		private bool bEnableTimer = false;
		private bool bTimerFlag = false;
		private bool bInTimer = false;
		private bool bApplicationExit = false;
		private Timer oTimer;

		// Keyboard
		public static readonly object KeyboardLock = new();
		private Queue<int> aKeys = new Queue<int>();

		// Mouse
		private GPoint oMouseLocation = new GPoint(-1, -1);
		private GPoint oOldMouseLocation = new GPoint(-1, -1);
		private MouseButtonsEnum oMouseButtons = MouseButtonsEnum.None;
		private MouseButtonsEnum oOldMouseButtons = MouseButtonsEnum.None;

		// Graphics
		public static readonly object GraphicsLock = new();

		// DOS file stuff
		private uint uiDOSDTA = 0;
		private int iFileCount = 0;
		private FileStream?[] aFileHandles = new FileStream?[256];

		private short sFileHandleCount = 0x20;
		private BDictionary<short, FileStreamItem> aOpenFiles = new BDictionary<short, FileStreamItem>();

		private OpenCiv1Game oParent;
		private LogWrapper oLog;

		public static string AssemblyPath;
		public static string DefaultCIVPath;

		static VCPU()
		{
			// We need this because of different paths between Debug and Release versions
			// The Release executable is intended to be put directly into DOS Cilization game directory
			// For Debug there are different paths on different platforms
			string? assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			AssemblyPath = (!string.IsNullOrEmpty(assemblyPath)) ? assemblyPath + Path.DirectorySeparatorChar : "";

#if DEBUG
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				DefaultCIVPath = string.Format("C:{0}Dos{0}Civ1{0}", Path.DirectorySeparatorChar);
			}
			else
			{
				DefaultCIVPath = string.Format("{0}{1}Dos{1}Civ1{1}",
					Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), Path.DirectorySeparatorChar);
			}
#else
			DefaultCIVPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}";
#endif
		}

		public VCPU(OpenCiv1.OpenCiv1Game parent, LogWrapper log)
		{
			this.oParent = parent;
			this.oLog = log;
			this.oMemory = new VCPUMemory(this);
			this.oTimer = new Timer(oTimer_Tick, null, 10, 10);

			for (int i = 0; i < this.aFileHandles.Length; i++)
			{
				this.aFileHandles[i] = null;
			}
		}

		public OpenCiv1.OpenCiv1Game Parent
		{
			get { return this.oParent; }
		}

		public LogWrapper Log
		{
			get => this.oLog;
			set => this.oLog = value;
		}

		public bool EnableTimer
		{
			get { return this.bEnableTimer; }
			set { this.bEnableTimer = value; this.bTimerFlag = false; }
		}

		public bool Pause
		{
			get { return this.bPause; }
			set { this.bPause = value; }
		}

		public Queue<int> Keys
		{
			get { return this.aKeys; }
		}

		public GPoint MouseLocation
		{
			get => this.oMouseLocation;
			set => this.oMouseLocation = value;
		}

		public GPoint OldMouseLocation
		{
			get => this.oOldMouseLocation;
			set => this.oOldMouseLocation = value;
		}

		public MouseButtonsEnum MouseButtons
		{
			get => this.oMouseButtons;
			set => this.oMouseButtons = value;
		}

		public MouseButtonsEnum OldMouseButtons
		{
			get => this.oOldMouseButtons;
			set => this.oOldMouseButtons = value;
		}

		private void oTimer_Tick(object? state)
		{
			if (this.bEnableTimer && !this.bTimerFlag)
			{
				this.bTimerFlag = true;
			}
		}

		#region Interrupts and events
		public void PauseCPU()
		{
			this.bPause = true;
			this.DoEvents();
		}

		public void STI()
		{
			this.bEnableInterrupt = true;
		}

		public void CLI()
		{
			this.bEnableInterrupt = false;
		}

		public void DoEvents()
		{
			if (this.bApplicationExit)
			{
				throw new ApplicationExitException();
			}

			while (this.bPause)
			{
				if (this.bApplicationExit)
				{
					throw new ApplicationExitException();
				}

				Thread.Sleep(200);
			}

			if (this.bEnableInterrupt && this.bEnableTimer && this.bTimerFlag && !this.bInTimer)
			{
				this.bInTimer = true;

				if (this.oOldMouseLocation != this.oMouseLocation ||
					this.oOldMouseButtons != this.oMouseButtons)
				{
					/*if (this.oOldMouseButtons != this.oMouseButtons)
					{
						this.oLog.WriteLine($"Mouse buttons changed from {this.oOldMouseButtons} to {this.oMouseButtons}");
					}*/

					this.PUSHUInt16(this.oAX.UInt16);
					this.PUSHUInt16(this.oCX.UInt16);
					this.PUSHUInt16(this.oDX.UInt16);
					this.PUSHUInt16(this.oBX.UInt16);
					this.PUSHUInt16(this.oBP.UInt16);
					this.PUSHUInt16(this.oSI.UInt16);
					this.PUSHUInt16(this.oDI.UInt16);
					this.PUSHUInt16(this.oDS.UInt16);
					this.PUSHUInt16(this.oES.UInt16);
					this.PUSHFUInt16();

					this.oAX.UInt16 = 0;
					if (this.oOldMouseLocation != this.oMouseLocation)
					{
						this.oAX.UInt16 |= 1;
					}
					this.oCX.UInt16 = (ushort)this.oMouseLocation.X;
					this.oDX.UInt16 = (ushort)this.oMouseLocation.Y;

					this.oBX.UInt16 = 0;
					ushort usLeft = (ushort)((this.oMouseButtons & MouseButtonsEnum.Left) == MouseButtonsEnum.Left ? 1 : 0);
					this.oBX.UInt16 |= usLeft;

					if ((this.oOldMouseButtons & MouseButtonsEnum.Left) != (this.oMouseButtons & MouseButtonsEnum.Left))
					{
						if (usLeft != 0)
							this.oAX.UInt16 |= 2;
						else
							this.oAX.UInt16 |= 4;
					}

					ushort usRight = (ushort)((this.oMouseButtons & MouseButtonsEnum.Right) == MouseButtonsEnum.Right ? 2 : 0);
					this.oBX.UInt16 |= usRight;

					if ((this.oOldMouseButtons & MouseButtonsEnum.Right) != (this.oMouseButtons & MouseButtonsEnum.Right))
					{
						if (usRight != 0)
							this.oAX.UInt16 |= 8;
						else
							this.oAX.UInt16 |= 0x10;
					}

					this.oOldMouseLocation = this.oMouseLocation;
					this.oOldMouseButtons = this.oMouseButtons;

					this.oParent.CommonTools.F0_1000_17db_MouseEvent();

					this.POPFUInt16();
					this.oES.UInt16 = this.POPUInt16();
					this.oDS.UInt16 = this.POPUInt16();
					this.oDI.UInt16 = this.POPUInt16();
					this.oSI.UInt16 = this.POPUInt16();
					this.oBP.UInt16 = this.POPUInt16();
					this.oBX.UInt16 = this.POPUInt16();
					this.oDX.UInt16 = this.POPUInt16();
					this.oCX.UInt16 = this.POPUInt16();
					this.oAX.UInt16 = this.POPUInt16();
				}

				/*LogWrapper oLogTemp = this.oLog;
				this.oLog = this.oParent.InterruptLog;

				this.PushF();
				this.oParent.Segment_1000.F0_1000_01a7_Timer();
				this.PopF();

				this.oLog = oLogTemp;*/

				this.bTimerFlag = false;
				this.bInTimer = false;
			}
		}
		#endregion

		#region Flags & registers
		public VCPUFlags Flags
		{
			get { return this.oFlags; }
		}

		public VCPURegister AX
		{
			get { return this.oAX; }
		}

		public VCPURegister BX
		{
			get { return this.oBX; }
		}

		public VCPURegister CX
		{
			get { return this.oCX; }
		}

		public VCPURegister DX
		{
			get { return this.oDX; }
		}

		public VCPURegister BP
		{
			get { return this.oBP; }
		}

		public VCPURegister SP
		{
			get { return this.oSP; }
		}

		public VCPURegister SI
		{
			get { return this.oSI; }
		}

		public VCPURegister DI
		{
			get { return this.oDI; }
		}

		public VCPURegister DS
		{
			get { return this.oDS; }
		}

		public VCPURegister ES
		{
			get { return this.oES; }
		}

		public VCPURegister SS
		{
			get { return this.oSS; }
		}

		public VCPURegister CS
		{
			get { return this.oCS; }
		}

		public VCPURegister Temp
		{
			get { return this.oTemp; }
		}
		#endregion

		#region Conversion functions
		public void UInt32ToTwoUInt16(VCPURegister regLow, VCPURegister regHigh, uint value)
		{
			regLow.UInt16 = (ushort)(value & 0xffff);
			regHigh.UInt16 = (ushort)((value & 0xffff0000) >> 16);
		}

		public uint TwoUInt16ToUInt32(ushort lowValue, ushort highValue)
		{
			return ((uint)highValue << 16) | (uint)lowValue;
		}

		/*public static ushort ToUInt16(int value)
		{
			if (value < 0 || value > UInt16.MaxValue)
				throw new Exception($"ReturnValue {value} out of range for UInt16");

			return (ushort)value;
		}

		public static ushort ToUInt16(sbyte value)
		{
			return (ushort)((short)value);
		}

		public static short ToInt16(int value)
		{
			if (value < Int16.MinValue || value > Int16.MaxValue)
				throw new Exception($"ReturnValue {value} out of range for Int16");

			return (short)value;
		}

		public static byte ForceUInt8(int value)
		{
			return (byte)(value & 0xff);
		}

		public static sbyte ForceInt8(int value)
		{
			return (sbyte)((byte)(value & 0xff));
		}

		public static ushort ForceUInt16(int value)
		{
			return (ushort)(value & 0xffff);
		}

		public static short ForceInt16(int value)
		{
			return (short)((ushort)(value & 0xffff));
		}*/
		#endregion

		#region Memory
		public VCPUMemory Memory
		{
			get { return this.oMemory; }
		}

		public byte ReadUInt8(ushort segment, ushort offset)
		{
			this.DoEvents();
			return this.oMemory.ReadUInt8(segment, offset);
		}

		public sbyte ReadInt8(ushort segment, ushort offset)
		{
			this.DoEvents();
			return this.oMemory.ReadInt8(segment, offset);
		}

		public ushort ReadUInt16(ushort segment, ushort offset)
		{
			this.DoEvents();
			return this.oMemory.ReadUInt16(segment, offset);
		}

		public short ReadInt16(ushort segment, ushort offset)
		{
			this.DoEvents();
			return this.oMemory.ReadInt16(segment, offset);
		}

		public uint ReadUInt32(ushort segment, ushort offset)
		{
			this.DoEvents();
			return this.oMemory.ReadUInt32(segment, offset);
		}

		public int ReadInt32(ushort segment, ushort offset)
		{
			this.DoEvents();
			return this.oMemory.ReadInt32(segment, offset);
		}

		public void WriteUInt8(ushort segment, ushort offset, byte value)
		{
			this.DoEvents();
			this.oMemory.WriteUInt8(segment, offset, value);
		}

		public void WriteInt8(ushort segment, ushort offset, sbyte value)
		{
			this.DoEvents();
			this.oMemory.WriteInt8(segment, offset, value);
		}

		public void WriteUInt16(ushort segment, ushort offset, ushort value)
		{
			this.DoEvents();
			this.oMemory.WriteUInt16(segment, offset, value);
		}

		public void WriteInt16(ushort segment, ushort offset, short value)
		{
			this.DoEvents();
			this.oMemory.WriteInt16(segment, offset, value);
		}

		public void WriteUInt32(ushort segment, ushort offset, uint value)
		{
			this.DoEvents();
			this.oMemory.WriteUInt32(segment, offset, value);
		}

		public void WriteInt32(ushort segment, ushort offset, int value)
		{
			this.DoEvents();
			this.oMemory.WriteInt32(segment, offset, value);
		}

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
		#endregion

		#region String instructions
		public string ReadString(ushort segment, ushort offset)
		{
			return ReadString(VCPU.ToLinearAddress(segment, offset));
		}

		public string ReadString(uint address)
		{
			if (address == 0)
				return "";

			StringBuilder sb = new StringBuilder();
			byte ch;

			while ((ch = this.oMemory.ReadUInt8(address)) != 0)
			{
				sb.Append((char)ch);
				address++;
			}

			return sb.ToString();
		}

		public string ReadDosString(uint address)
		{
			if (address == 0)
				return "";

			StringBuilder sb = new StringBuilder();
			byte ch;

			while ((ch = this.oMemory.ReadUInt8(address)) != (byte)'$')
			{
				sb.Append((char)ch);
				address++;
			}

			return sb.ToString();
		}

		public void WriteString(uint address, string text)
		{
			if (address == 0)
				return;

			for (int i = 0; i < text.Length; i++)
			{
				this.oMemory.WriteUInt8(address, (byte)text[i]);
				address++;
			}

			this.oMemory.WriteUInt8(address, 0);
		}

		public void WriteString(uint address, string text, int maxLength)
		{
			if (address == 0)
				return;

			for (int i = 0; i < text.Length && i < maxLength; i++)
			{
				this.oMemory.WriteUInt8(address, (byte)text[i]);
				address++;
			}

			this.oMemory.WriteUInt8(address, 0);
		}
		#endregion

		#region File operations
		public short FileHandleCount
		{
			get => this.sFileHandleCount;
			set => this.sFileHandleCount = value;
		}

		public BDictionary<short, FileStreamItem> Files
		{
			get { return this.aOpenFiles; }
		}
		#endregion

		#region CPU stack
		public void PUSHAUInt16()
		{
			ushort uiTemp = this.oSP.UInt16;
			this.PUSHUInt16(this.oAX.UInt16);
			this.PUSHUInt16(this.oCX.UInt16);
			this.PUSHUInt16(this.oDX.UInt16);
			this.PUSHUInt16(this.oBX.UInt16);
			this.PUSHUInt16(uiTemp);
			this.PUSHUInt16(this.oBP.UInt16);
			this.PUSHUInt16(this.oSI.UInt16);
			this.PUSHUInt16(this.oDI.UInt16);
		}

		public void PUSHFUInt16()
		{
			PUSHUInt16(this.oFlags.Value);
		}

		public void PUSHUInt16(ushort value)
		{
			if ((int)this.oSP.UInt16 - 2 < 0)
			{
				throw new Exception("Stack overflow");
				//return;
			}
			this.oSP.UInt16 -= 1;
			this.oMemory.WriteUInt8(this.oSS.UInt16, this.oSP.UInt16, (byte)((value & 0xff00) >> 8));
			this.oSP.UInt16 -= 1;
			this.oMemory.WriteUInt8(this.oSS.UInt16, this.oSP.UInt16, (byte)(value & 0xff));
		}

		public void PUSHUInt32(uint value)
		{
			if ((int)this.oSP.UInt16 - 4 < 0)
			{
				throw new Exception("Stack overflow");
				//return;
			}
			this.oSP.UInt16 -= 1;
			this.oMemory.WriteUInt8(this.oSS.UInt16, this.oSP.UInt16, (byte)((value & 0xff000000) >> 24));
			this.oSP.UInt16 -= 1;
			this.oMemory.WriteUInt8(this.oSS.UInt16, this.oSP.UInt16, (byte)((value & 0xff0000) >> 16));
			this.oSP.UInt16 -= 1;
			this.oMemory.WriteUInt8(this.oSS.UInt16, this.oSP.UInt16, (byte)((value & 0xff00) >> 8));
			this.oSP.UInt16 -= 1;
			this.oMemory.WriteUInt8(this.oSS.UInt16, this.oSP.UInt16, (byte)(value & 0xff));
		}

		public void POPAUInt16()
		{
			this.oDI.UInt16 = this.POPUInt16();
			this.oSI.UInt16 = this.POPUInt16();
			this.oBP.UInt16 = this.POPUInt16();
			this.POPUInt16();
			this.oBX.UInt16 = this.POPUInt16();
			this.oDX.UInt16 = this.POPUInt16();
			this.oCX.UInt16 = this.POPUInt16();
			this.oAX.UInt16 = this.POPUInt16();
		}

		public void POPFUInt16()
		{
			this.oFlags.Value = POPUInt16();
		}

		public ushort POPUInt16()
		{
			if ((int)this.oSP.UInt16 + 2 >= 0x10000)
			{
				throw new Exception("Stack underflow");
				//return 0;
			}

			return (ushort)((ushort)this.oMemory.ReadUInt8(this.oSS.UInt16, this.oSP.UInt16++) |
				((ushort)this.oMemory.ReadUInt8(this.oSS.UInt16, this.oSP.UInt16++) << 8));
		}

		public uint POPUInt32()
		{
			if ((int)this.oSP.UInt16 + 4 >= 0x10000)
			{
				throw new Exception("Stack underflow");
				//return 0;
			}

			return (uint)(((uint)this.oMemory.ReadUInt8(this.oSS.UInt16, this.oSP.UInt16++)) |
				((uint)this.oMemory.ReadUInt8(this.oSS.UInt16, this.oSP.UInt16++) << 8) |
				((uint)this.oMemory.ReadUInt8(this.oSS.UInt16, this.oSP.UInt16++) << 16) |
				((uint)this.oMemory.ReadUInt8(this.oSS.UInt16, this.oSP.UInt16++) << 24));
		}
		#endregion

		#region CPU instructions
		public byte ADCUInt8(byte value1, byte value2)
		{
			byte bCFlag = (byte)((this.oFlags.C) ? 1 : 0);
			byte res = (byte)(value1 + value2 + bCFlag);
			// Modifies flags: AF CF OF PF SF ZF
			this.oFlags.C = (res < value1) || (bCFlag != 0 && (res == value1));
			this.oFlags.O = (((value1 ^ value2 ^ 0x80) & (res ^ value2)) & 0x80) != 0;
			this.oFlags.S = (res & 0x80) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public ushort ADCUInt16(ushort value1, ushort value2)
		{
			ushort bCFlag = (ushort)((this.oFlags.C) ? 1 : 0);
			ushort res = (ushort)(value1 + value2 + bCFlag);
			// Modifies flags: AF CF OF PF SF ZF
			this.oFlags.C = (res < value1) || (bCFlag != 0 && (res == value1));
			this.oFlags.O = (((value1 ^ value2 ^ 0x8000) & (res ^ value2)) & 0x8000) != 0;
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public byte ADDUInt8(byte value1, byte value2)
		{
			byte res = (byte)(value1 + value2);
			// Modifies flags: AF CF OF PF SF ZF
			this.oFlags.C = (res < value1);
			this.oFlags.O = (((value1 ^ value2 ^ 0x80) & (res ^ value2)) & 0x80) != 0;
			this.oFlags.S = (res & 0x80) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public ushort ADDUInt16(ushort value1, ushort value2)
		{
			ushort res = (ushort)(value1 + value2);
			// Modifies flags: AF CF OF PF SF ZF
			this.oFlags.C = (res < value1);
			this.oFlags.O = (((value1 ^ value2 ^ 0x8000) & (res ^ value2)) & 0x8000) != 0;
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public byte ANDUInt8(byte value1, byte value2)
		{
			byte res = (byte)(value1 & value2);
			// Modifies flags: CF OF PF SF ZF (AF undefined)
			this.oFlags.C = false;
			this.oFlags.O = false;
			this.oFlags.S = (res & 0x80) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public ushort ANDUInt16(ushort value1, ushort value2)
		{
			ushort res = (ushort)(value1 & value2);
			// Modifies flags: CF OF PF SF ZF (AF undefined)
			this.oFlags.C = false;
			this.oFlags.O = false;
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public void CMPUInt8(byte value1, byte value2)
		{
			byte res = (byte)(value1 - value2);
			// Modifies flags: AF CF OF PF SF ZF
			this.oFlags.C = (value1 < value2);
			this.oFlags.O = (((value1 ^ value2) & (value1 ^ res)) & 0x80) != 0;
			this.oFlags.S = (res & 0x80) != 0;
			this.oFlags.Z = (res == 0);
		}

		public void CMPUInt16(ushort value1, ushort value2)
		{
			ushort res = (ushort)(value1 - value2);
			// Modifies flags: AF CF OF PF SF ZF
			this.oFlags.C = (value1 < value2);
			this.oFlags.O = (((value1 ^ value2) & (value1 ^ res)) & 0x8000) != 0;
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.Z = (res == 0);
		}

		public void CMPSUInt8(VCPURegister regES, VCPURegister regDI, VCPURegister sReg, VCPURegister regSI)
		{
			CMPUInt8(this.oMemory.ReadUInt8(regES.UInt16, regDI.UInt16), this.oMemory.ReadUInt8(sReg.UInt16, regSI.UInt16));

			if (this.oFlags.D)
			{
				this.oSI.UInt16--;
				this.oDI.UInt16--;
			}
			else
			{
				this.oSI.UInt16++;
				this.oDI.UInt16++;
			}
		}

		public void REPE_CMPSUInt8(VCPURegister regES, VCPURegister regDI, VCPURegister sReg, VCPURegister regSI)
		{
			while (this.oCX.UInt16 != 0)
			{
				CMPSUInt8(regES, regDI, sReg, regSI);
				this.oCX.UInt16--;

				if (this.oFlags.Z)
					break;
			}
		}

		public void CBW(VCPURegister regAX)
		{
			if ((regAX.LowUInt8 & 0x80) != 0)
				regAX.HighUInt8 = 0xff;
			else
				regAX.HighUInt8 = 0;
		}

		public void CWD(VCPURegister regAX, VCPURegister regDX)
		{
			if ((regAX.UInt16 & 0x8000) != 0)
				regDX.UInt16 = 0xffff;
			else
				regDX.UInt16 = 0;
		}

		public void DASUInt8()
		{
			byte osigned = (byte)(this.oAX.LowUInt8 & 0x80);
			if (((this.oAX.LowUInt8 & 0x0f) > 9))
			{
				if ((this.oAX.LowUInt8 > 0x99) || this.oFlags.C)
				{
					this.oAX.LowUInt8 -= 0x60;
					this.oFlags.C = true;
				}
				else
				{
					this.oFlags.C = this.oAX.LowUInt8 <= 0x05;
				}
				this.oAX.LowUInt8 -= 6;
			}
			else
			{
				if ((this.oAX.LowUInt8 > 0x99) || this.oFlags.C)
				{
					this.oAX.LowUInt8 -= 0x60;
					this.oFlags.C = true;
				}
				else
				{
					this.oFlags.C = false;
				}
			}
			this.oFlags.O = osigned != 0 && (this.oAX.LowUInt8 & 0x80) == 0;
			this.oFlags.S = (this.oAX.LowUInt8 & 0x80) != 0;
			this.oFlags.Z = this.oAX.LowUInt8 == 0;
		}

		public byte DECUInt8(byte value1)
		{
			byte res = (byte)(value1 - 1);
			// Modifies flags: AF OF PF SF ZF
			this.oFlags.O = (res == 0x7f);
			this.oFlags.S = (res & 0x80) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public ushort DECUInt16(ushort value1)
		{
			ushort res = (ushort)(value1 - 1);
			// Modifies flags: AF OF PF SF ZF
			this.oFlags.O = (res == 0x7fff);
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public void DIVUInt16(VCPURegister regAX, VCPURegister regDX, ushort value)
		{
			if (value == 0)
				throw new Exception("Division by zero");
			uint num = ((uint)regDX.UInt16 << 16) | (uint)regAX.UInt16;
			uint quo = num / value;
			ushort rem = (ushort)(num % value);
			ushort quo16 = (ushort)(quo & 0xffff);
			if (quo != quo16)
				throw new Exception("Division error");
			regDX.UInt16 = rem;
			regAX.UInt16 = quo16;
		}

		public void IDIVUInt8(VCPURegister regAX, byte value)
		{
			if (value == 0)
				throw new Exception("Division by zero");
			short valuea = (sbyte)value;
			short num = (short)regAX.UInt16;
			short quo = (short)(num / valuea);
			sbyte rem = (sbyte)(num % valuea);
			sbyte quo8 = (sbyte)((ushort)quo & 0xff);
			if (quo != quo8)
				throw new Exception("Division error");
			regAX.HighUInt8 = (byte)rem;
			regAX.LowUInt8 = (byte)quo8;
		}

		public void IDIVUInt16(VCPURegister regAX, VCPURegister regDX, ushort value)
		{
			if (value == 0)
				throw new Exception("Division by zero");
			int valuea = (short)value;
			int num = (int)(((uint)regDX.UInt16 << 16) | (uint)regAX.UInt16);
			int quo = num / valuea;
			short rem = (short)(num % valuea);
			short quo16 = (short)((uint)quo & 0xffff);
			if (quo != quo16)
				throw new Exception("Division error");
			regDX.UInt16 = (ushort)rem;
			regAX.UInt16 = (ushort)quo16;
		}

		public void IMULUInt8(VCPURegister regAX, byte value1)
		{
			ushort res = (ushort)((short)((sbyte)regAX.LowUInt8) * (short)((sbyte)value1));
			regAX.UInt16 = res;

			if ((res & 0xff80) == 0xff80 || (res & 0xff80) == 0x0)
			{
				this.oFlags.C = false;
				this.oFlags.O = false;
			}
			else
			{
				this.oFlags.C = true;
				this.oFlags.O = true;
			}
		}

		public void IMULUInt16(VCPURegister regAX, VCPURegister regDX, ushort value1)
		{
			uint res = (uint)((int)((short)regAX.UInt16) * (int)((short)value1));
			regAX.UInt16 = (ushort)(res & 0xffff);
			regDX.UInt16 = (ushort)((res & 0xffff0000) >> 16);

			if ((res & 0xffff8000) == 0xffff8000 || (res & 0xffff8000) == 0x0)
			{
				this.oFlags.C = false;
				this.oFlags.O = false;
			}
			else
			{
				this.oFlags.C = true;
				this.oFlags.O = true;
			}
		}

		public ushort IMUL1UInt16(ushort value1, ushort value2)
		{
			uint res = (uint)((uint)value1 * (uint)value2);

			if ((res & 0xffff8000) == 0xffff8000 || (res & 0xffff8000) == 0x0)
			{
				this.oFlags.C = false;
				this.oFlags.O = false;
			}
			else
			{
				this.oFlags.C = true;
				this.oFlags.O = true;
			}

			return (ushort)(res & 0xffff);
		}

		public byte INCUInt8(byte value1)
		{
			byte res = (byte)(value1 + 1);
			// Modifies flags: AF OF PF SF ZF
			this.oFlags.O = (res == 0x80);
			this.oFlags.S = (res & 0x80) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public ushort INCUInt16(ushort value1)
		{
			ushort res = (ushort)(value1 + 1);
			// Modifies flags: AF OF PF SF ZF
			this.oFlags.O = (res == 0x8000);
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public bool LoopUInt16(VCPURegister regCX)
		{
			regCX.UInt16--;

			return regCX.UInt16 != 0;
		}

		/// <summary>
		/// LODS - Load String (Byte, Word or Double) from DS:SI
		/// </summary>
		public void LODSUInt8()
		{
			this.oAX.LowUInt8 = oMemory.ReadUInt8(this.oDS.UInt16, this.oSI.UInt16);

			// Modifies flags: None
			if (this.oFlags.D)
			{
				this.oSI.UInt16--;
			}
			else
			{
				this.oSI.UInt16++;
			}
		}

		/// <summary>
		/// LODS - Load String (Byte, Word or Double) from DS:SI
		/// </summary>
		public void LODSUInt16()
		{
			this.oAX.UInt16 = oMemory.ReadUInt16(this.oDS.UInt16, this.oSI.UInt16);

			// Modifies flags: None
			if (this.oFlags.D)
			{
				this.oSI.UInt16 -= 2;
			}
			else
			{
				this.oSI.UInt16 += 2;
			}
		}

		public ushort MOVSXUInt16(ushort value1)
		{
			value1 &= 0xff;
			if ((value1 & 0x80) != 0)
				return (ushort)(0xff00 | value1);

			return value1;
		}

		public uint MOVSXUInt32(uint value1)
		{
			value1 &= 0xffff;
			if ((value1 & 0x8000) != 0)
				return 0xffff0000 | value1;

			return value1;
		}

		public ushort MOVZXUInt16(ushort value1)
		{
			return (ushort)(value1 & 0xff);
		}

		public uint MOVZXUInt32(uint value1)
		{
			return value1 & 0xffff;
		}

		/// <summary>
		/// MOVS - Move String (Byte or Word) ES:DI = DS:SI
		/// </summary>
		public void MOVSUInt8(VCPURegister sReg, VCPURegister regSI, VCPURegister regES, VCPURegister regDI)
		{
			oMemory.WriteUInt8(regES.UInt16, regDI.UInt16, oMemory.ReadUInt8(sReg.UInt16, regSI.UInt16));
			// Modifies flags: None
			if (this.oFlags.D)
			{
				regSI.UInt16--;
				regDI.UInt16--;
			}
			else
			{
				regSI.UInt16++;
				regDI.UInt16++;
			}
		}

		/// <summary>
		/// MOVS - Move String (Byte or Word) ES:DI = DS:SI
		/// </summary>
		public void REPE_MOVSUInt8(VCPURegister sReg, VCPURegister regSI, VCPURegister regES, VCPURegister regDI, VCPURegister regCX)
		{
			while (regCX.UInt16 != 0)
			{
				MOVSUInt8(sReg, regSI, regES, regDI);

				regCX.UInt16--;
			}
		}

		/// <summary>
		/// MOVS - Move String (Byte or Word) ES:DI = DS:SI
		/// </summary>
		public void MOVSUInt16(VCPURegister sReg, VCPURegister regSI, VCPURegister regES, VCPURegister regDI)
		{
			oMemory.WriteUInt16(regES.UInt16, regDI.UInt16, oMemory.ReadUInt16(sReg.UInt16, regSI.UInt16));
			// Modifies flags: None
			if (this.oFlags.D)
			{
				regSI.UInt16 -= 2;
				regDI.UInt16 -= 2;
			}
			else
			{
				regSI.UInt16 += 2;
				regDI.UInt16 += 2;
			}
		}

		/// <summary>
		/// MOVS - Move String (Byte or Word) ES:DI = DS:SI
		/// </summary>
		public void REPE_MOVSUInt16(VCPURegister sReg, VCPURegister regSI, VCPURegister regES, VCPURegister regDI, VCPURegister regCX)
		{
			while (regCX.UInt16 != 0)
			{
				MOVSUInt16(sReg, regSI, regES, regDI);

				regCX.UInt16--;
			}
		}

		public void MULUInt8(VCPURegister regAX, byte value)
		{
			regAX.UInt16 = (ushort)((ushort)regAX.LowUInt8 * (ushort)value);
			oFlags.Z = regAX.LowUInt8 == 0;
			if (regAX.HighUInt8 != 0)
			{
				oFlags.C = true;
				oFlags.O = true;
			}
			else
			{
				oFlags.C = false;
				oFlags.O = false;
			}
		}

		public void MULUInt16(VCPURegister regDX, VCPURegister regAX, ushort value)
		{
			uint tempu = (uint)regAX.UInt16 * (uint)value;
			regAX.UInt16 = (ushort)(tempu & 0xfffful);
			regDX.UInt16 = (ushort)((tempu & 0xffff0000ul) >> 16);
			oFlags.Z = regAX.UInt16 == 0;
			if (regDX.UInt16 != 0)
			{
				oFlags.C = true;
				oFlags.O = true;
			}
			else
			{
				oFlags.C = false;
				oFlags.O = false;
			}
		}

		public byte NEGUInt8(byte value1)
		{
			byte res = (byte)(((ushort)0x100 - (ushort)value1) & 0xff);

			this.oFlags.C = value1 != 0;
			this.oFlags.Z = res == 0;
			this.oFlags.S = (value1 & 0x80) != 0;
			this.oFlags.O = (value1 == 0x80);

			return res;
		}

		public ushort NEGUInt16(ushort value1)
		{
			ushort res = (ushort)(((uint)0x10000 - (uint)value1) & 0xffff);

			this.oFlags.C = value1 != 0;
			this.oFlags.Z = res == 0;
			this.oFlags.S = (value1 & 0x8000) != 0;
			this.oFlags.O = (value1 == 0x8000);

			return res;
		}

		public byte NOTUInt8(byte value1)
		{
			byte res = (byte)(~value1);
			// Modifies flags: None

			return res;
		}

		public ushort NOTUInt16(ushort value1)
		{
			ushort res = (ushort)(~value1);
			// Modifies flags: None

			return res;
		}

		public byte ORUInt8(byte value1, byte value2)
		{
			byte res = (byte)(value1 | value2);
			// Modifies flags: CF OF PF SF ZF (AF undefined)
			this.oFlags.C = false;
			this.oFlags.O = false;
			this.oFlags.S = (res & 0x80) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public ushort ORUInt16(ushort value1, ushort value2)
		{
			ushort res = (ushort)(value1 | value2);
			// Modifies flags: CF OF PF SF ZF (AF undefined)
			this.oFlags.C = false;
			this.oFlags.O = false;
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public byte RCLUInt8(byte value1, byte value2)
		{
			if ((value2 % 9) == 0) return value1;
			value2 %= 9;
			byte cf = (byte)((oFlags.C) ? 1 : 0);
			byte res = (byte)((value1 << value2) |
				(cf << (value2 - 1)) |
				(value1 >> (9 - value2)));
			oFlags.O = ((oFlags.C ? 1 : 0) ^ (res >> 7)) != 0;
			oFlags.C = (((value1 >> (8 - value2)) & 1)) != 0;

			return res;
		}

		public ushort RCLUInt16(ushort value1, byte value2)
		{
			if ((value2 % 17) == 0) return value1;
			value2 %= 17;
			ushort cf = (ushort)((oFlags.C) ? 1 : 0);
			ushort res = (ushort)((value1 << value2) |
				(cf << (value2 - 1)) |
				(value1 >> (17 - value2)));
			oFlags.O = ((oFlags.C ? 1 : 0) ^ (res >> 15)) != 0;
			oFlags.C = (((value1 >> (16 - value2)) & 1)) != 0;

			return res;
		}

		public byte RCRUInt8(byte value1, byte value2)
		{
			if ((value2 % 9) == 0) return value1;
			value2 %= 9;
			byte cf = (oFlags.C) ? (byte)1 : (byte)0;
			byte res = (byte)((value1 >> value2) |
				(cf << (8 - value2)) |
				(value1 << (9 - value2)));

			this.oFlags.C = ((value1 >> (value2 - 1)) & 1) != 0;
			this.oFlags.O = ((res ^ (res << 1)) & 0x80) != 0;

			return res;
		}

		public ushort RCRUInt16(ushort value1, ushort value2)
		{
			if ((value2 % 17) == 0) return value1;
			value2 %= 17;
			ushort cf = (oFlags.C) ? (ushort)1 : (ushort)0;
			ushort res = (ushort)((value1 >> value2) |
				(cf << (16 - value2)) |
				(value1 << (17 - value2)));

			this.oFlags.C = ((value1 >> (value2 - 1)) & 1) != 0;
			this.oFlags.O = ((res ^ (res << 1)) & 0x8000) != 0;

			return res;
		}

		public byte ROLUInt8(byte value1, byte value2)
		{
			if ((value2 & 0x7) == 0)
			{
				if ((value2 & 0x18) != 0)
				{
					oFlags.C = (value1 & 1) != 0;
					oFlags.O = ((value1 & 1) ^ (value1 >> 7)) != 0;
				}
				return value1;
			}
			value2 &= 0x7;
			byte res = (byte)((value1 << value2) | (value1 >> (8 - value2)));
			oFlags.C = (res & 1) != 0;
			oFlags.O = ((res & 1) ^ (res >> 7)) != 0;

			return res;
		}

		public ushort ROLUInt16(ushort value1, byte value2)
		{
			if ((value2 & 0xf) == 0)
			{
				if ((value2 & 0x10) != 0)
				{
					oFlags.C = (value1 & 1) != 0;
					oFlags.O = ((value1 & 1) ^ (value1 >> 15)) != 0;
				}
				return value1;
			}
			value2 &= 0xf;
			ushort res = (ushort)((value1 << value2) | (value1 >> (16 - value2)));
			oFlags.C = (res & 1) != 0;
			oFlags.O = ((res & 1) ^ (res >> 15)) != 0;

			return res;
		}

		public byte RORUInt8(byte value1, byte value2)
		{
			if ((value2 & 0x7) == 0)
			{
				if ((value2 & 0x18) != 0)
				{
					oFlags.C = (value1 >> 7) != 0;
					oFlags.O = ((value1 >> 7) ^ ((value1 >> 6) & 0x1)) != 0;
				}
				return value1;
			}
			value2 &= 0x7;
			byte res = (byte)((value1 >> value2) | (value1 << (8 - value2)));
			oFlags.C = (res & 0x80) != 0;
			oFlags.O = ((res ^ (res << 1)) & 0x80) != 0;

			return res;
		}

		public ushort RORUInt16(ushort value1, byte value2)
		{
			if ((value2 & 0xf) == 0)
			{
				if ((value2 & 0x10) != 0)
				{
					oFlags.C = (value1 >> 15) != 0;
					oFlags.O = ((value1 >> 15) ^ ((value1 >> 14) & 0x1)) != 0;
				}
				return value1;
			}
			value2 &= 0xf;
			ushort res = (ushort)((value1 >> value2) | (value1 << (16 - value2)));
			oFlags.C = (res & 0x8000) != 0;
			oFlags.O = ((res ^ (res << 1)) & 0x8000) != 0;

			return res;
		}

		public byte SARUInt8(byte value1, byte value2)
		{
			byte res;

			if (value2 == 0)
				return value1;

			if (value2 > 8) value2 = 8;
			if ((value1 & 0x80) != 0)
			{
				res = (byte)((value1 >> value2) | (0xff << (8 - value2)));
			}
			else
			{
				res = (byte)(value1 >> value2);
			}
			this.oFlags.C = (((byte)(value1) >> (value2 - 1)) & 1) != 0;
			this.oFlags.Z = (res == 0);
			this.oFlags.S = (res & 0x80) != 0;
			this.oFlags.O = false;

			return res;
		}

		public ushort SARUInt16(ushort value1, byte value2)
		{
			ushort res;

			if (value2 == 0)
				return value1;

			if (value2 > 16) value2 = 16;
			if ((value1 & 0x8000) != 0)
			{
				res = (ushort)((value1 >> value2) | (0xffff << (16 - value2)));
			}
			else
			{
				res = (ushort)(value1 >> value2);
			}
			this.oFlags.C = (((ushort)(value1) >> (value2 - 1)) & 1) != 0;
			this.oFlags.Z = (res == 0);
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.O = false;

			return res;
		}

		public byte SBBUInt8(byte value1, byte value2)
		{
			byte bCFlag = (byte)((this.oFlags.C) ? 1 : 0);
			byte res = (byte)(value1 - (value2 + bCFlag));

			// Modifies flags: AF CF OF PF SF ZF
			this.oFlags.C = (value1 < res) || (this.oFlags.C && (value2 == 0xff));
			this.oFlags.O = (((value1 ^ value2) & (value1 ^ res)) & 0x80) != 0;
			this.oFlags.S = (res & 0x80) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public ushort SBBUInt16(ushort value1, ushort value2)
		{
			ushort bCFlag = (ushort)((this.oFlags.C) ? 1 : 0);
			ushort res = (ushort)(value1 - (value2 + bCFlag));

			// Modifies flags: AF CF OF PF SF ZF
			this.oFlags.C = (value1 < res) || (this.oFlags.C && (value2 == 0xffff));
			this.oFlags.O = (((value1 ^ value2) & (value1 ^ res)) & 0x8000) != 0;
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public void SCASUInt8()
		{
			CMPUInt8(this.oAX.LowUInt8, oMemory.ReadUInt8(this.oES.UInt16, this.oDI.UInt16));
			if (this.oFlags.D)
			{
				this.oDI.UInt16--;
			}
			else
			{
				this.oDI.UInt16++;
			}
		}

		public void REPNE_SCASUInt8()
		{
			while (this.oCX.UInt16 != 0)
			{
				CMPUInt8(this.oAX.LowUInt8, oMemory.ReadUInt8(this.oES.UInt16, this.oDI.UInt16));
				if (this.oFlags.D)
				{
					this.oDI.UInt16--;
				}
				else
				{
					this.oDI.UInt16++;
				}
				this.oCX.UInt16--;

				if (!this.oFlags.Z)
					break;
			}
		}

		public byte SHLUInt8(byte value1, byte value2)
		{
			if (value2 == 0)
				return value1;

			byte res = (byte)(value1 << value2);
			// Modifies flags: CF OF PF SF ZF (AF undefined)
			this.oFlags.C = (value2 > 8) ? false : ((value1 >> (8 - value2)) & 1) != 0;
			this.oFlags.O = ((res ^ value1) & 0x80) != 0;
			this.oFlags.S = (res & 0x80) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public ushort SHLUInt16(ushort value1, byte value2)
		{
			if (value2 == 0)
				return value1;

			ushort res = (ushort)(value1 << value2);
			// Modifies flags: CF OF PF SF ZF (AF undefined)
			this.oFlags.C = (value2 > 16) ? false : ((value1 >> (16 - value2)) & 1) != 0;
			this.oFlags.O = ((res ^ value1) & 0x8000) != 0;
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public ushort SHLD1UInt16(ushort value1, ushort value2, byte value3)
		{
			if (value3 == 0)
				return value1;

			uint res = (uint)((uint)value1 << value3) | (uint)(value2 & ((uint)Math.Pow(2.0, value3) - 1));

			// Modifies flags: SF, ZF, PF, CF (AF, OF undefined)
			this.oFlags.C = (res & 0x10000) != 0;
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.Z = (res & 0xffff) == 0;

			return (ushort)(res & 0xffff);
		}

		public byte SHRUInt8(byte value1, byte value2)
		{
			if (value2 == 0)
				return value1;

			byte res = (byte)(value1 >> value2);
			// Modifies flags: CF OF PF SF ZF (AF undefined)
			this.oFlags.C = (value2 > 8) ? false : ((value1 >> (value2 - 1)) & 1) != 0;
			this.oFlags.O = ((value2 & 0x1f) == 1) ? (value1 > 0x80) : false;
			this.oFlags.S = (res & 0x80) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public ushort SHRUInt16(ushort value1, byte value2)
		{
			if (value2 == 0)
				return value1;

			ushort res = (ushort)(value1 >> value2);
			// Modifies flags: CF OF PF SF ZF (AF undefined)
			this.oFlags.C = (value2 > 16) ? false : ((value1 >> (value2 - 1)) & 1) != 0;
			this.oFlags.O = ((value2 & 0x1f) == 1) ? (value1 > 0x8000) : false;
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		/// <summary>
		/// STOS - Store String (Byte, Word or Doubleword) to ES:DI
		/// </summary>
		public void STOSUInt8()
		{
			oMemory.WriteUInt8(this.oES.UInt16, this.oDI.UInt16, this.oAX.LowUInt8);
			// Modifies flags: None
			if (this.oFlags.D)
			{
				this.oDI.UInt16--;
			}
			else
			{
				this.oDI.UInt16++;
			}
		}

		/// <summary>
		/// STOS - Store String (Byte, Word or Doubleword) to ES:DI
		/// </summary>
		public void REPE_STOSUInt8()
		{
			while (this.oCX.UInt16 != 0)
			{
				STOSUInt8();
				this.oCX.UInt16--;
			}
		}

		/// <summary>
		/// STOS - Store String (Byte, Word or Doubleword) to ES:DI
		/// </summary>
		public void STOSUInt16()
		{
			oMemory.WriteUInt16(this.oES.UInt16, this.oDI.UInt16, this.oAX.UInt16);
			// Modifies flags: None
			if (this.oFlags.D)
			{
				this.oDI.UInt16 -= 2;
			}
			else
			{
				this.oDI.UInt16 += 2;
			}
		}

		/// <summary>
		/// STOS - Store String (Byte, Word or Doubleword) to ES:DI
		/// </summary>
		public void REPE_STOSUInt16()
		{
			while (this.oCX.UInt16 != 0)
			{
				STOSUInt16();
				this.oCX.UInt16--;
			}
		}

		public byte SUBUInt8(byte value1, byte value2)
		{
			byte res = (byte)(value1 - value2);
			// Modifies flags: AF CF OF PF SF ZF
			this.oFlags.C = (value1 < value2);
			this.oFlags.O = (((value1 ^ value2) & (value1 ^ res)) & 0x80) != 0;
			this.oFlags.S = (res & 0x80) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public ushort SUBUInt16(ushort value1, ushort value2)
		{
			ushort res = (ushort)(value1 - value2);
			// Modifies flags: AF CF OF PF SF ZF
			this.oFlags.C = (value1 < value2);
			this.oFlags.O = (((value1 ^ value2) & (value1 ^ res)) & 0x8000) != 0;
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public void TESTUInt8(byte value1, byte value2)
		{
			byte res = (byte)(value1 & value2);
			// Modifies flags: CF OF PF SF ZF (AF undefined)
			this.oFlags.C = false;
			this.oFlags.O = false;
			this.oFlags.S = (res & 0x80) != 0;
			this.oFlags.Z = (res == 0);
		}

		public void TESTUInt16(ushort value1, ushort value2)
		{
			ushort res = (ushort)(value1 & value2);
			// Modifies flags: CF OF PF SF ZF (AF undefined)
			this.oFlags.C = false;
			this.oFlags.O = false;
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.Z = (res == 0);
		}

		public byte XLATUInt8(VCPURegister sReg)
		{
			return this.oMemory.ReadUInt8(sReg.UInt16, (ushort)(this.oBX.UInt16 + this.oAX.LowUInt8));
		}

		public byte XORUInt8(byte value1, byte value2)
		{
			byte res = (byte)(value1 ^ value2);
			// Modifies flags: CF OF PF SF ZF (AF undefined)
			this.oFlags.C = false;
			this.oFlags.O = false;
			this.oFlags.S = (res & 0x80) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}

		public ushort XORUInt16(ushort value1, ushort value2)
		{
			ushort res = (ushort)(value1 ^ value2);
			// Modifies flags: CF OF PF SF ZF (AF undefined)
			this.oFlags.C = false;
			this.oFlags.O = false;
			this.oFlags.S = (res & 0x8000) != 0;
			this.oFlags.Z = (res == 0);

			return res;
		}
		#endregion

		#region IO instructions
		public byte INUInt8(ushort port)
		{
			switch (port)
			{
				case 0x40:
					// 8253 or 8254 Programmable Interval Timer
					break;

				case 0x61:
					// 8255 Port B output - reset keyboard
					break;

				/*case 0x3c7:
					// DAC Status
					return this.oGPU.DACReadAddress;

				case 0x3c8:
					// DAC Palette Address, write
					return this.oGPU.DACWriteAddress;

				case 0x3c9:
					// DAC Palette Data
					return this.oGPU.DACPalette;

				case 0x3d5:
					// CRT Controller data, read
					this.oLog.WriteLine($"Input byte from port 0x{port:x4} (CRT Controller data, read)");
					break;

				case 0x3da:
					// Status Register
					return this.oGPU.HWStatus;*/

				default:
					this.oLog.WriteLine($"Input byte from port 0x{port:x4}");
					break;
			}

			return 0;
		}

		public void OUTUInt8(byte port, byte value)
		{
			this.OUTUInt8((ushort)port, value);
		}

		public void OUTUInt8(ushort port, byte value)
		{
			//this.oLog.WriteLine($"Output to port 0x{port:x4}, byte value 0x{value:x2}");

			switch (port)
			{
				case 0x20:
					// 8259A Master Programmable Interrupt Controller
					break;

				case 0x40:
				case 0x43:
					// 8253 or 8254 Programmable Interval Timer
					break;

				case 0x61:
					// system control port (for compatibility with 8255)
					break;

				/*case 0x3c0:
					// Attribute controller
					//this.oLog.WriteLine($"Output to port 0x{port:x4} (Old palette register), byte value 0x{value:x2}");
					this.oGPU.AttributeControllerWrite(value);
					break;

				case 0x3c4:
					this.oGPU.HWSequencerAddress = value;
					break;

				case 0x3c5:
					this.oGPU.SetSequencerValue(value);
					break;

				case 0x3c7:
					// DAC Palette Address, read
					this.oGPU.DACReadAddress = value;
					break;

				case 0x3c8:
					// DAC Palette Address, write
					this.oGPU.DACWriteAddress = value;
					break;

				case 0x3c9:
					// DAC Palette data, write
					this.oGPU.DACPalette = value;
					break;

				case 0x3ce:
					this.oGPU.HWGraphicsAddress = value;
					break;

				case 0x3cf:
					this.oGPU.SetGraphicsValue(value);
					break;

				case 0x3d0:
				case 0x3d2:
				case 0x3d6:
					// ignore this port
					break;

				case 0x3d4:
					// CRT Controller address
					this.oLog.WriteLine($"Output to port 0x{port:x4} (CRT Controller address), byte value 0x{value:x2}");
					break;

				case 0x3d1:
				case 0x3d3:
				case 0x3d7:
					// ignore this port
					break;

				case 0x3d5:
					// CRT Controller data, write
					this.oLog.WriteLine($"Output to port 0x{port:x4} (CRT Controller data, write), byte value 0x{value:x2}");
					break;*/

				default:
					this.oLog.WriteLine($"Output to port 0x{port:x4}, byte value 0x{value:x2}");
					break;
			}
		}

		public void OUTUInt16(ushort port, ushort value)
		{
			OUTUInt8(port, (byte)(value & 0xff));
			OUTUInt8((ushort)(port + 1), (byte)((value & 0xff00) >> 8));
		}

		public void REPE_OUTSUInt8(VCPURegister regSeg, VCPURegister regSI, VCPURegister regCX)
		{
			while (this.oCX.UInt16 != 0)
			{
				OUTUInt8(this.oDX.UInt16, this.oMemory.ReadUInt8(regSeg.UInt16, regSI.UInt16));
				this.oCX.UInt16--;
			}
		}
		#endregion

		#region Flow control instructions

		public void OnApplicationExit()
		{
			this.bApplicationExit = true;
		}

		public void Exit(int code)
		{
			this.EnableTimer = false;

			this.oParent.Log.WriteLine($"Exiting program with code {code}");

			throw new ApplicationExitException();
			//Environment.Exit(code);
			//System.Windows.Forms.Application.Exit();
		}

		public void CallUInt16(ushort offset)
		{
			this.oLog.WriteLine($"Trying to call function at 0x{this.oCS.UInt16:x4}:0x{offset:x4}");
		}

		public void CallUInt32(uint address)
		{
			this.oLog.WriteLine($"Trying to call function at 0x{address:x8}");
		}

		public void JmpUInt16(ushort offset)
		{
			this.oLog.WriteLine($"Trying to jump to 0x{this.CS.UInt16:x4}:0x{offset:x4}");
		}

		public void JmpUInt32(uint address)
		{
			this.oLog.WriteLine($"Trying to jump to 0x{address:x8}");
		}
		#endregion

		#region Interrupt instruction
		private byte bVGAMode = 3;

		public void INTUInt8(byte value)
		{
			int iCount;
			int iLeft;
			int iTop;

			switch (value)
			{
				case 0x10:
					switch (this.oAX.HighUInt8)
					{
						case 0x0:
							this.bVGAMode = this.oAX.LowUInt8;
							this.oFlags.C = false;
							break;

						case 0x2:
							Console.CursorLeft = this.oDX.LowUInt8;
							Console.CursorTop = this.oDX.HighUInt8;
							this.oFlags.C = false;
							break;

						case 0x9:
							iLeft = Console.CursorLeft;
							iTop = Console.CursorTop;
							iCount = this.oCX.UInt16;
							for (; iCount > 0; iCount--)
							{
								//this.oGPU.PrintStdOut((char)this.oAX.Low, this.oBX.Low);
								Console.Write((char)this.oAX.LowUInt8);
							}
							Console.CursorLeft = iLeft;
							Console.CursorTop = iTop;
							this.oFlags.C = false;
							break;

						case 0xe:
							Console.Write((char)this.oAX.LowUInt8);
							this.oFlags.C = false;
							break;

						case 0xf:
							this.oAX.HighUInt8 = 80;
							this.oAX.LowUInt8 = this.bVGAMode;
							this.oBX.HighUInt8 = 0;
							this.oFlags.C = false;
							break;

						default:
							throw new Exception($"Unknown 0x10 interrupt 0x{this.oAX.HighUInt8:x2}");
					}
					break;

				case 0x11:
					this.oAX.UInt16 = 0x22;
					break;

				case 0x16:
					switch (this.oAX.HighUInt8)
					{
						case 0:
							this.oParent.MSCAPI.getch();
							if (this.oAX.UInt16 == 0)
							{
								this.oParent.MSCAPI.getch();
								switch (this.oAX.UInt16)
								{
									case 0x4b:
										this.oAX.UInt16 = 0x4b00; // Left
										break;

									case 0x48:
										this.oAX.UInt16 = 0x4800; // Up
										break;

									case 0x4d:
										this.oAX.UInt16 = 0x4d00; // Right
										break;

									case 0x50:
										this.oAX.UInt16 = 0x5000; // Down
										break;
								}
							}
							break;

						default:
							throw new Exception($"Unknown 0x16 interrupt 0x{this.oAX.HighUInt8:x2}");
					}
					break;

				case 0x21:
					switch (this.oAX.HighUInt8)
					{
						case 0:
							DOSTerminateProcess();
							break;

						case 1:
							DOSKeyboardInputWithEcho();
							break;

						case 2:
							DOSPrintChar();
							break;

						case 5:
							DOSPrinterOutput();
							break;

						case 6:
							DOSDirectConsoleIO();
							break;

						case 9:
							DOSPrintString();
							break;

						case 0xe:
							this.oAX.LowUInt8 = 3;
							break;

						case 0xf:
							DOSOpenFile();
							break;

						case 0x10:
							DOSCloseFile();
							break;

						case 0x11:
							DOSSearchForFirstEntryUsingFCB();
							break;

						case 0x16:
							DOSCreateFile();
							break;

						case 0x19:
							DOSGetCurrentDefaultDrive();
							break;

						case 0x1a:
							DOSSetFileTransferArea();
							break;

						case 0x21:
							DOSRandomFileRead();
							break;

						case 0x22:
							DOSRandomFileWrite();
							break;

						case 0x25:
							DOSSetInterruptVector();
							break;

						case 0x29:
							DOSParseAFilenameForFCB();
							break;

						case 0x2c:
							DOSGetCurrentTime();
							break;

						case 0x30:
							// DOS version 6.33
							this.oAX.UInt16 = 0x1606;
							this.oFlags.C = false;
							break;

						case 0x35:
							DOSGetInterruptVector();
							break;

						case 0x3c:
							DOSCreateFileUsingHandle();
							break;

						case 0x3d:
							DOSOpenFileUsingHandle();
							break;

						case 0x3e:
							DOSCloseFileUsingHandle();
							break;

						case 0x3f:
							DOSReadFromFileOrDeviceUsingHandle();
							break;

						case 0x40:
							DOSWriteFileUsingHandle();
							break;

						case 0x42:
							DOSMoveFilePointerUsingHandle();
							break;

						case 0x44:
							DOSIOControlForDevices();
							break;

						case 0x47:
							DosGetCurrentDirectory();
							break;

						case 0x48:
							DOSAllocateBlock();
							break;

						case 0x49:
							DOSFreeBlock();
							break;

						case 0x4a:
							DOSAdjustBlockSize();
							break;

						case 0x4b:
							DOSLoadOrExecuteProgram();
							break;

						case 0x4c:
							DOSTerminateProcessWithReturnCode();
							break;

						default:
							throw new Exception($"Unknown 0x21 interrupt 0x{this.oAX.HighUInt8:x2}");
					}
					break;

				case 0x33:
					break;

				default:
					throw new Exception(string.Format("Unknown 0x{0:x2} interrupt", value));
			}
		}

		private void DOSKeyboardInputWithEcho()
		{
			while (this.aKeys.Count == 0)
			{
				Thread.Sleep(200);
				this.DoEvents();
			}

			lock (VCPU.KeyboardLock)
			{
				int iTemp = this.aKeys.Dequeue();
				if (iTemp < 0x80)
				{
					this.oAX.LowUInt8 = (byte)(iTemp & 0xff);
					Console.Write((char)this.oAX.LowUInt8);
				}
				else
				{
					this.oAX.LowUInt8 = 0;
				}
			}
		}

		private void DOSLoadOrExecuteProgram()
		{
			if (this.oAX.LowUInt8 == 3)
			{
				string sName = MSCAPI.GetDOSFileName(this.ReadString(VCPU.ToLinearAddress(this.DS.UInt16, this.DX.UInt16)).ToUpper());
				string sPath = $"{VCPU.DefaultCIVPath}{sName}";
				ushort usSegment = ReadUInt16(this.oES.UInt16, this.oBX.UInt16);
				ushort usRelocationSegment = ReadUInt16(this.oES.UInt16, (ushort)(this.oBX.UInt16 + 2));

				this.oLog.WriteLine($"Loading overlay '{sPath}' at segment 0x{usSegment:x4}");
				MZExecutable oOverlay = new MZExecutable(sPath);
				oOverlay.ApplyRelocations(usRelocationSegment);
				this.oMemory.WriteBlock(usSegment, 0, oOverlay.Data, 0, oOverlay.Data.Length);
				this.oFlags.C = false;
			}
			else
			{
				throw new Exception("Load and Execute Program");
			}
		}

		private void DOSSetInterruptVector()
		{
			this.oLog.WriteLine($"Setting interrupt vector 0x{this.oAX.LowUInt8:x2} to address 0x{this.oDS.UInt16:x4}:0x{this.oDX.UInt16:x4}");
			this.oFlags.C = false;
		}

		private void DOSGetInterruptVector()
		{
			this.oLog.WriteLine($"Getting interrupt vector 0x{this.oAX.LowUInt8:x2} address");
			this.oES.UInt16 = 0;
			this.oBX.UInt16 = 0;
			this.oFlags.C = false;
		}

		/// <summary>
		/// <para>INT 21,2 - Display Output</para>
		/// <para>Parameters: AH = 02; DL = character to output</para>
		/// <para>Returns: nothing</para>
		/// <para>Remarks: Outputs character to STDOUT.
		/// Backspace is treated as non-destructive cursor left.
		/// If Ctrl-Break is detected, INT 23 is executed.</para>
		/// </summary>
		private void DOSPrintChar()
		{
			Console.Write((char)this.oDX.LowUInt8);
			this.oFlags.C = false;
		}

		/// <summary>
		/// <para>INT 21,5 - Printer Output</para>
		/// <para>Parameters: AH = 05; DL = character to output</para>
		/// <para>Returns: nothing</para>
		/// <para>Remarks: Sends character in DL to STDPRN.
		/// Waits until STDPRN device is ready before output.</para>
		/// </summary>
		private void DOSPrinterOutput()
		{
			throw new Exception("Printer output");
		}

		private void DOSIOControlForDevices()
		{
			// I/O Control for Devices
			if (this.oAX.LowUInt8 == 0)
			{
				this.oLog.WriteLine($"Get Device Information for handle 0x{this.oBX.UInt16:x4}");
				switch (this.oBX.UInt16)
				{
					case 0:
					case 1:
					case 2:
						this.oDX.UInt16 = 0x80d3;
						this.oFlags.C = false;
						break;

					case 3:
						this.oDX.UInt16 = 0x80c0;
						this.oFlags.C = false;
						break;

					case 4:
						this.oDX.UInt16 = 0xa8c0;
						this.oFlags.C = false;
						break;

					default:
						this.oDX.UInt16 = 0xa8c0;
						this.oFlags.C = false;
						break;
				}
			}
		}

		///<summary>
		/// <para>INT 21,6 - Direct Console I/O</para>
		/// <para>Parameters: DL = (0-0xFE) character to output; 0xFF if console input request</para>
		/// <para>Returns: AL = input character if console input request (DL=FF)</para>
		/// <para>ZF = 0 if console request character available (in AL); 
		/// 1 if no character is ready, and function request was console input</para>
		/// <para>Remarks: reads from or writes to the console device depending on the value of DL, 
		/// cannot output character FF (DL=FF indicates read function), 
		/// for console read, no echo is produced,
		/// returns 0 for extended keystroke, then function must be called again to return scan code,
		/// ignores Ctrl-Break and Ctrl-PrtSc</para>
		///</summary>
		private void DOSDirectConsoleIO()
		{
			if (this.oDX.LowUInt8 != 0xff)
			{
				Console.Write((char)this.oDX.LowUInt8);
			}
			else
			{
				if (this.aKeys.Count > 0)
				{
					oFlags.Z = false;
					lock (VCPU.KeyboardLock)
					{
						int iTemp = this.aKeys.Dequeue();
						if (iTemp < 0x80)
						{
							this.oAX.LowUInt8 = (byte)(iTemp & 0xff);
						}
						else
						{
							this.oAX.LowUInt8 = 0;
						}
					}
				}
				else
				{
					oFlags.Z = true;
				}
			}
			this.oFlags.C = false;
		}

		/// <summary>
		/// <para>INT 21,9 - Print String</para>
		/// <para>Parameters: DS:DX = pointer to string ending in "$"</para>
		/// <para>Returns: nothing</para>
		/// <para>Remarks: outputs character string to STDOUT up to "$",
		/// backspace is treated as non-destructive,
		/// if Ctrl-Break is detected, INT 23 is executed</para>
		/// </summary>
		private void DOSPrintString()
		{
			string sTemp = this.ReadDosString(VCPU.ToLinearAddress(this.oDS.UInt16, this.oDX.UInt16));
			if (sTemp.Length > 0)
			{
				Console.Write(sTemp);
			}
			this.oFlags.C = false;
		}

		private void DOSCreateFileUsingHandle()
		{
			// open file
			string sName = MSCAPI.GetDOSFileName(this.ReadString(VCPU.ToLinearAddress(this.DS.UInt16, this.DX.UInt16)).ToUpper());
			string sPath = $"{VCPU.DefaultCIVPath}{sName}";
			FileAccess access = FileAccess.ReadWrite;

			/*switch (this.oCX.Low & 0x7)
			{
				case 0:
					access = FileAccess.Read;
					break;

				case 1:
					access = FileAccess.Write;
					break;

				case 2:
					access = FileAccess.ReadWrite;
					break;

				default:
					break;

			}*/
			if (this.sFileHandleCount > 0x7fff)
			{
				this.oFlags.C = true;
			}
			else
			{
				try
				{
					this.oLog.WriteLine($"Creating file '{sPath}'");
					this.aOpenFiles.Add(this.sFileHandleCount, new FileStreamItem(new FileStream(sPath, FileMode.Create, access), FileStreamTypeEnum.Binary));
					this.oAX.UInt16 = (ushort)this.sFileHandleCount;
					this.sFileHandleCount++;
					this.oFlags.C = false;
				}
				catch
				{
					this.oFlags.C = true;
				}
			}
		}

		private void DOSWriteFileUsingHandle()
		{
			if (this.aOpenFiles.ContainsKey((short)this.oBX.UInt16))
			{
				FileStreamItem fileItem = this.aOpenFiles.GetValueByKey((short)this.oBX.UInt16);
				ushort length = this.oCX.UInt16;
				uint address = VCPU.ToLinearAddress(this.oDS.UInt16, this.oDX.UInt16);

				for (int i = 0; i < length; i++)
				{
					fileItem.Stream.WriteByte(this.oMemory.ReadUInt8(address));
					address++;
				}

				this.oAX.UInt16 = length;
				this.oFlags.C = false;
			}
			else
			{
				this.oFlags.C = true;
			}
		}

		private void DOSMoveFilePointerUsingHandle()
		{
			if (this.aOpenFiles.ContainsKey((short)this.oBX.UInt16))
			{
				FileStreamItem fileItem = this.aOpenFiles.GetValueByKey((short)this.oBX.UInt16);
				SeekOrigin origin = SeekOrigin.Begin;

				switch (this.oAX.LowUInt8)
				{
					case 0:
						origin = SeekOrigin.Begin;
						break;

					case 1:
						origin = SeekOrigin.Current;
						break;

					case 2:
						origin = SeekOrigin.End;
						break;
				}

				int position = (int)(((uint)this.oCX.UInt16 << 16) | (uint)this.oDX.UInt16);

				fileItem.Stream.Seek(position, origin);

				this.oDX.UInt16 = (ushort)((fileItem.Stream.Position & 0xffff0000) >> 16);
				this.oAX.UInt16 = (ushort)(fileItem.Stream.Position & 0xffff);
				this.oFlags.C = false;
			}
			else
			{
				this.oFlags.C = true;
			}
		}

		private void DOSOpenFileUsingHandle()
		{
			// open file
			string sName = this.ReadString(VCPU.ToLinearAddress(this.DS.UInt16, this.DX.UInt16)).ToUpper();
			string sPath = $"{VCPU.DefaultCIVPath}{sName}";
			FileAccess access = FileAccess.Read;

			switch (this.oAX.LowUInt8 & 0x7)
			{
				case 0:
					access = FileAccess.Read;
					break;

				case 1:
					access = FileAccess.Write;
					break;

				case 2:
					access = FileAccess.ReadWrite;
					break;

				default:
					break;

			}
			if (this.sFileHandleCount > 0x7fff)
			{
				this.oFlags.C = true;
			}
			else
			{
				try
				{
					this.oLog.WriteLine($"Opening file '{sPath}'");
					this.aOpenFiles.Add(this.sFileHandleCount, new FileStreamItem(new FileStream(sPath, FileMode.Open, access), FileStreamTypeEnum.Binary));
					this.oAX.UInt16 = (ushort)this.sFileHandleCount;
					this.sFileHandleCount++;
					this.oFlags.C = false;
				}
				catch
				{
					this.oFlags.C = true;
				}
			}
		}

		private void DOSCloseFileUsingHandle()
		{
			short handle = (short)this.oBX.UInt16;
			if (this.aOpenFiles.ContainsKey(handle))
			{
				this.aOpenFiles.GetValueByKey(handle).Stream.Close();
				this.aOpenFiles.RemoveByKey(handle);

				this.oFlags.C = false;
			}
			else
			{
				this.oFlags.C = true;
			}
		}

		private void DOSReadFromFileOrDeviceUsingHandle()
		{
			short handle = (short)this.oBX.UInt16;
			if (this.aOpenFiles.ContainsKey(handle))
			{
				byte[] aBuffer = new byte[this.oCX.UInt16];
				int iReadBytes = this.aOpenFiles.GetValueByKey(handle).Stream.Read(aBuffer, 0, aBuffer.Length);
				if (iReadBytes >= 0)
				{
					this.oMemory.WriteBlock(this.oDS.UInt16, this.oDX.UInt16, aBuffer, 0, iReadBytes);
					this.oAX.UInt16 = (ushort)iReadBytes;
					this.oFlags.C = false;
				}
				else
				{
					this.oFlags.C = true;
				}
			}
			else
			{
				this.oFlags.C = true;
			}
		}

		/// <summary>
		/// <para>INT 21,F - Open a File Using FCB</para>
		/// <para>Parameters: AH = 0F;
		/// DS:DX = pointer to unopened FCB</para>
		/// <para>Returns: AL = 00 if file opened; = FF if unable to open</para>
		/// <para>Remarks: Opens an existing file using a previously setup FCB.
		/// The FCB fields drive identifier, filename and extension
		/// must be filled in before call.
		/// Sets default FCB fields; current block number is set to 0;
		/// record size is set to 80h; file size, date and time are set
		/// to the values from the directory.
		/// Does not create file, see  INT 21,16.
		/// DOS 2.x allows opening of subdirectories, DOS 3.x does not.</para>
		/// </summary>
		private void DOSOpenFile()
		{
			if (DOS_FCBOpen(this.oDS.UInt16, this.oDX.UInt16))
			{
				this.oAX.LowUInt8 = 0;
			}
			else
			{
				this.oAX.LowUInt8 = 0xff;
			}
		}

		private void DOSGetCurrentDefaultDrive()
		{
			// Force C drive
			//string sTemp = Path.GetPathRoot(sDefaultCIVPath).ToUpper();
			this.oAX.LowUInt8 = 2; // (byte)(sTemp[0] - 'A');
			this.oFlags.C = false;
		}

		private void DosGetCurrentDirectory()
		{
			if (this.oDX.LowUInt8 != 0 && this.oDX.LowUInt8 != 2)
			{
				this.oLog.WriteLine($"Wrong drive number {this.oDX.LowUInt8}");
			}
			string sTemp = VCPU.DefaultCIVPath.Substring(3).ToUpper();
			this.WriteString(VCPU.ToLinearAddress(this.oDS.UInt16, this.oSI.UInt16), sTemp);
			this.oFlags.C = false;
		}

		bool DOS_FCBOpen(ushort seg, ushort offset)
		{
			DOS_FCB fcb = new DOS_FCB(this.oMemory, seg, offset);
			string shortname;
			int handle = -1;
			FileStream? file;
			shortname = fcb.GetName();

			// First check if the name is correct
			if (!File.Exists(shortname))
				return false;

			// Check, if file is already opened
			for (int i = 0; i < this.aFileHandles.Length; i++)
			{
				file = this.aFileHandles[i];
				if (file != null && file.Name.Equals(shortname, StringComparison.CurrentCultureIgnoreCase))
				{
					handle = i;
					fcb.FileOpen((byte)handle);
					return true;
				}
			}

			if (!File.Exists(shortname) || this.iFileCount > 255)
				return false;
			file = new FileStream(shortname, FileMode.Open, FileAccess.ReadWrite);
			for (int i = 0; i < this.aFileHandles.Length; i++)
			{
				if (this.aFileHandles[i] == null)
				{
					handle = i;
					this.iFileCount++;
					break;
				}
			}
			if (handle < 0)
				return false;

			this.aFileHandles[handle] = file;
			fcb.FileOpen((byte)handle);

			return true;
		}

		/// <summary>
		/// <para>INT 21,10 - Close a File Using FCB</para>
		/// <para>Parameters: AH = 10h;
		/// DS:DX = pointer to an opened FCB</para>
		/// <para>Returns: AL = 00  if file closed;
		/// = FF  if file not closed</para>
		/// <para>Remarks: Closes a previously opened file opened with an FCB
		/// FCB must be setup with drive id, filename, and extension
		/// before call.</para>
		/// </summary>
		private void DOSCloseFile()
		{
			if (DOS_FCBClose(this.oDS.UInt16, this.oDX.UInt16))
			{
				this.oAX.LowUInt8 = 0;
			}
			else
			{
				this.oAX.LowUInt8 = 0xff;
			}
			this.oFlags.C = false;
		}

		void DOSParseAFilenameForFCB()
		{
			DOS_FCB fcb = new DOS_FCB(this.oMemory, this.oES.UInt16, this.oDI.UInt16);
			string sFilename = MSCAPI.GetDOSFileName(this.ReadString(VCPU.ToLinearAddress(this.oDS.UInt16, this.oSI.UInt16)).ToUpper());
			string sName = Path.GetFileNameWithoutExtension(sFilename);
			string sExtension = Path.GetExtension(sFilename).Substring(1);
			string sPath = $"{VCPU.DefaultCIVPath}{sFilename}";

			if (File.Exists(sPath))
			{
				fcb.SetName(2, ref sName, ref sExtension);

				this.oSI.UInt16 = (ushort)(this.oSI.UInt16 + sFilename.Length);
				this.oAX.LowUInt8 = 0;
			}
			else
			{
				sName = "";
				fcb.SetName(2, ref sName, ref sExtension);
				this.oSI.UInt16 = (ushort)(this.oSI.UInt16 + sFilename.Length);
				this.oAX.LowUInt8 = 0;
			}
		}

		void DOSSearchForFirstEntryUsingFCB()
		{
			DOS_FCB fcb = new DOS_FCB(this.oMemory, this.oDS.UInt16, this.oDX.UInt16);
			string sFileName = fcb.GetName();
			string sPath = $"{VCPU.DefaultCIVPath}{sFileName.ToUpper()}";

			if (File.Exists(sPath))
			{
				this.oAX.LowUInt8 = 0;
			}
			else
			{
				this.oAX.LowUInt8 = 0xff;
			}
		}

		bool DOS_FCBClose(ushort seg, ushort offset)
		{
			DOS_FCB fcb = new DOS_FCB(this.oMemory, seg, offset);
			if (!fcb.Valid())
				return false;

			byte fhandle;
			fcb.FileClose(out fhandle);
			if (fhandle >= this.iFileCount)
				return false;

			if (this.aFileHandles[fhandle] != null)
			{
				this.aFileHandles[fhandle]!.Close();
			}

			this.aFileHandles[fhandle] = null;

			return true;
		}


		/// <summary>
		/// <para>INT 21,16 - Create a File Using FCB</para>
		/// <para>Parameters: AH = 16h;
		/// DS:DX = pointer to an unopened FCB</para>
		/// <para>Returns: AL = 00 if file created;
		/// = FF if file creation failed</para>
		/// <para>Remarks: Creates file using FCB and leaves open for later output.
		/// FCB must be setup with drive id, filename, and extension before call.</para>
		/// </summary>
		private void DOSCreateFile()
		{
			throw new Exception("Create file");
		}

		/// <summary>
		/// <para>INT 21,1A - Set Disk Transfer Address (DTA)</para>
		/// <para>Parameters: AH = 1A;
		/// DS:DX = pointer to disk transfer address (DTA)</para>
		/// <para>Returns: nothing</para>
		/// <para>Remarks: Specifies the disk transfer address to DOS.
		/// DTA cannot overlap 64K segment boundary.
		/// Offset 80h in the PSP is a 128 byte default DTA supplied
		/// by DOS upon program load. 
		/// Use of the DTA provided by DOS will result in the loss
		/// of the program command tail which also occupies the 128
		/// bytes starting at offset 80h of the PSP.</para>
		/// </summary>
		private void DOSSetFileTransferArea()
		{
			this.uiDOSDTA = VCPU.ToLinearAddress(this.oDS.UInt16, this.oDX.UInt16);
		}

		/// <summary>
		/// <para>INT 21,21 - Random Read Using FCB</para>
		/// <para>Parameters: AH = 21h;
		/// DS:DX = pointer to an opened FCB</para>
		/// <para>Returns: AL = 00 if read successful;
		/// = 01 if EOF (no data read);
		/// = 02 if DTA is too small;
		/// = 03 if EOF (partial record read)</para>
		/// <para>Remarks: Reads random records from a file opened with an FCB
		/// to the DTA.
		/// FCB must be setup with drive id, filename, extension,
		/// record position and record length before call.
		/// Current record position field in FCB is not updated.</para>
		/// </summary>
		private void DOSRandomFileRead()
		{
			this.oAX.LowUInt8 = DOS_FCBRandomRead(this.oDS.UInt16, this.oDX.UInt16, 1, true);
		}

		byte DOS_FCBRandomRead(ushort seg, ushort offset, ushort numRec, bool restore)
		{
			/* if restore is true :random read else random block read. 
			 * random read updates old block and old record to reflect the random data
			 * before the read!!!!!!!!! and the random data is not updated! (user must do this)
			 * Random block read updates these fields to reflect the state after the read!
			 */

			/* BUG: numRec should return the amount of records read! 
			 * Not implemented yet as I'm unsure how to count on error states (partial/failed) 
			 */

			DOS_FCB fcb = new DOS_FCB(this.oMemory, seg, offset);
			uint random;
			ushort old_block = 0;
			byte old_rec = 0;
			byte error = 0;

			// Set the correct record from the random data
			fcb.GetRandom(out random);
			fcb.SetRecord((ushort)(random / 128), (byte)(random & 127));
			if (restore)
				fcb.GetRecord(out old_block, out old_rec); //store this for after the read.

			// Read records
			for (int i = 0; i < numRec; i++)
			{
				error = DOS_FCBRead(seg, offset, (ushort)i);
				if (error != 0x0) break;
			}

			ushort new_block;
			byte new_rec;
			fcb.GetRecord(out new_block, out new_rec);
			if (restore)
				fcb.SetRecord(old_block, old_rec);
			// Update the random record pointer with new position only when restore is false
			if (!restore)
				fcb.SetRandom((uint)new_block * 128 + (uint)new_rec);

			return error;
		}

		byte DOS_FCBRead(ushort seg, ushort offset, ushort recno)
		{
			DOS_FCB fcb = new DOS_FCB(this.oMemory, seg, offset);
			byte fhandle, cur_rec;
			ushort cur_block, rec_size;
			fcb.GetSeqData(out fhandle, out rec_size);
			fcb.GetRecord(out cur_block, out cur_rec);

			uint pos = (((uint)cur_block * 128) + (uint)cur_rec) * (uint)rec_size;
			byte[] dos_copybuf = new byte[rec_size];
			FileStream? file = this.aFileHandles[fhandle];
			if (file == null)
				return 1;

			long newpos = file.Seek(pos, SeekOrigin.Current);

			ushort toread = rec_size;
			toread = (ushort)file.Read(dos_copybuf, 0, toread);
			if (toread == 0)
				return 0x1;
			if (toread < rec_size)
			{
				//Zero pad copybuffer to rec_size
				ushort i = toread;
				while (i < rec_size)
					dos_copybuf[i++] = 0;
			}
			for (int i = 0; i < dos_copybuf.Length; i++)
			{
				this.oMemory.WriteUInt8((uint)(this.uiDOSDTA + ((uint)recno * (uint)rec_size) + i), dos_copybuf[i]);
			}
			if (++cur_rec > 127)
			{
				cur_block++;
				cur_rec = 0;
			}
			fcb.SetRecord(cur_block, cur_rec);

			if (toread == rec_size)
				return 0;

			if (toread == 0)
				return 1;

			return 3;
		}

		/// <summary>
		/// <para>INT 21,22 - Random Write Using FCB</para>
		/// <para>Parameters: AH = 21h;
		/// DS:DX = pointer to an opened FCB</para>
		/// <para>Returns: AL = 00 if write successful; 
		/// = 01 if diskette full or read only; 
		/// = 02 if DTA is too small</para>
		/// <para>Remarks: Write records to random location in file opened with FCB.
		/// FCB must be setup with drive id, filename, extension,
		/// record position and record length before call.
		/// Current record position field in FCB is not updated.</para>
		/// </summary>
		private void DOSRandomFileWrite()
		{
			throw new Exception("File write");
		}

		/// <summary>
		/// <para>INT 21,2C - Get Time</para>
		/// <para>Parameters: -</para>
		/// <para>Returns: CH = hour (0-23); CL = minutes (0-59); DH = seconds (0-59); DL = hundredths (0-99)</para>
		/// <para>Remarks: retrieves DOS maintained clock time</para>
		/// </summary>
		private void DOSGetCurrentTime()
		{
			DateTime value = DateTime.Now;
			this.oCX.HighUInt8 = (byte)value.Hour;
			this.oCX.LowUInt8 = (byte)value.Minute;
			this.oDX.HighUInt8 = (byte)value.Second;
			this.oDX.LowUInt8 = (byte)(value.Millisecond / 10);
			this.oFlags.C = false;
		}

		/// <summary>
		/// <para>INT 21,48 - Allocate Memory</para>
		/// <para>Parameters: BX = number of memory paragraphs requested</para>
		/// <para>Returns: AX = segment address of allocated memory block (MCB + 1para), 
		/// or error code if CF set;
		/// BX = size in paras of the largest block of memory available, or 
		/// if CF set, and AX = 08 (Not Enough Mem); 
		/// CF = 0 if successful, 1 if error</para>
		/// <para>Remarks: returns segment address of allocated memory block AX:0000,
		/// each allocation requires a 16 byte overhead for the MCB,
		/// returns maximum block size available if error</para>
		/// </summary>
		private void DOSAllocateBlock()
		{
			ushort usTemp;
			if (this.oBX.UInt16 == 0xffff)
			{
				this.oBX.UInt16 = (ushort)((this.oMemory.FreeMemory.Size >> 4) & 0xffff);
				this.oFlags.C = true;
			}
			else if (this.oMemory.AllocateMemoryBlock(this.oBX.UInt16, out usTemp))
			{
				oFlags.C = false;
				this.oAX.UInt16 = usTemp;
			}
			else
			{
				oFlags.C = true;
				this.oBX.UInt16 = usTemp;
				this.oAX.UInt16 = 8; // Insufficient memory
			}
		}

		/// <summary>
		/// <para>INT 21,49 - Free Allocated Memory</para>
		/// <para>Parameters: ES = segment of the block to be returned (MCB + 1para)</para>
		/// <para>Returns: AX = error code if CF set</para>
		/// <para>Remarks: releases memory and MCB allocated by INT 21,48. 
		/// May cause unpredictable results if memory wasn't allocated using 
		/// INT 21,48 or if memory wasn't allocated by the current process. 
		/// Checks for valid MCB id, but does NOT check for process ownership. 
		/// Care must be taken when freeing the memory of another process, to 
		/// assure the segment isn't in use by a TSR or ISR. 
		/// This function is unreliable in a TSR once resident, since 
		/// COMMAND.COM and many other .COM files take all available memory 
		/// when they load.</para>
		/// </summary>
		private void DOSFreeBlock()
		{
			if (this.oMemory.FreeMemoryBlock(this.oES.UInt16))
			{
				oFlags.C = false;
			}
			else
			{
				oFlags.C = true;
				this.oAX.UInt16 = 9; // Invalid memory block address
			}
		}

		/// <summary>
		/// <para>INT 21,4A - Modify Allocated Memory Block (SETBLOCK)</para>
		/// <para>Parameters: BX = new requested block size in paragraphs,
		/// ES = segment of the block (MCB + 1 para)</para>
		/// <para>Returns: AX = error code if CF set; 
		/// BX = maximum block size possible, if CF set and AX = 8</para>
		/// <para>Remarks: modifies memory blocks allocated by  INT 21,48,
		/// can be used by programs to shrink or increase the size of allocated memory, 
		/// PC-DOS version 2.1 and DOS 3.x will actually allocate the largest
		/// available block if CF is set.  BX will equal the size allocated.</para>
		/// </summary>
		private void DOSAdjustBlockSize()
		{
			if (this.oMemory.ResizeMemoryBlock(this.oES.UInt16, this.oBX.UInt16))
			{
				oFlags.C = false;
				this.oAX.UInt16 = 0;
			}
			else
			{
				oFlags.C = true;
				this.oAX.UInt16 = 8;
				this.oBX.UInt16 = 0;
			}
		}

		private void DOSTerminateProcessWithReturnCode()
		{
			this.Exit(this.oAX.LowUInt8);
		}

		private void DOSTerminateProcess()
		{
			this.Exit(-1);
		}

		public class DOS_FCB
		{
			private bool extended;
			private uint pt;
			private VCPUMemory oMemory;

			// struct sFCB
			private byte drive;         // Drive number 0=default, 1=A, etc.
			private string filename;        // 8 Space padded name
			private string ext;         // 3 Space padded extension
			private ushort cur_block;       // Current Block
			private ushort rec_size;        // Logical record size
			private uint filesize;      // File Size
			private ushort date;
			private ushort time;
			// Reserved Block should be 8 bytes
			private byte sft_entries;
			private byte share_attributes;
			private byte extra_info;
			private byte file_handle;
			private byte[] reserved = new byte[4];  // 4
													// end
			private byte cur_rec;           // Current record in current block
			private uint rndm;          // Current relative record number

			// -7   byte	if FF this is an extended FCB 0
			// -6  5bytes	reserved  0
			// -1   byte	file attribute if extended FCB 0
			// 00   byte	drive number (0 for default drive, 1=A:, 2=B:, ...)
			// 01  8bytes	filename, left justified with trailing blanks
			// 09  3bytes	filename extension, left justified w/blanks
			// 0C   word	current block number relative to beginning of the file, starting with zero
			// 0E   word	logical record size in bytes
			// 10   dword	file size in bytes
			// 14   word	date the file was created or last updated
			// |F|E|D|C|B|A|9|8|7|6|5|4|3|2|1|0| 15,14 (Intel reverse order)
			// | | | | | | | | | | | `--------- day 1-31
			// | | | | | | | `---------------- month 1-12
			// `----------------------------- year + 1980

			// 16   word	time of last write
			// |F|E|D|C|B|A|9|8|7|6|5|4|3|2|1|0| 17,16 (Intel reverse order)
			// | | | | | | | | | | | `---------- secs in 2 second increments
			// | | | | | `--------------------- minutes (0-59)
			// `------------------------------ hours (0-23)

			// 18  8bytes	see below for version specific information  Ø
			// 1A   dword	address of device header if character device  Ø
			// 20   byte	current relative record number within current BLOCK
			// 21   dword	relative record number relative to the beginning of
			// 		the file, starting with zero; high bit omitted if
			// 		record length is 64 bytes

			public DOS_FCB(VCPUMemory mem, ushort seg, ushort off) :
				this(mem, seg, off, true)
			{ }

			public DOS_FCB(VCPUMemory mem, ushort seg, ushort off, bool allow_extended)
			{
				this.oMemory = mem;
				this.pt = VCPU.ToLinearAddress(seg, off);
				this.extended = false;
				this.filename = "";
				this.ext = "";

				ReadFCBFromMemory();

				if (allow_extended)
				{
					if (this.drive == 0xff)
					{
						this.pt += 7;
						this.extended = true;
						ReadFCBFromMemory();
					}
				}
			}

			private void ReadFCBFromMemory()
			{
				this.drive = oMemory.ReadUInt8(pt);
				this.filename = ReadString(pt + 1, 8);
				this.ext = ReadString(pt + 9, 3);
				this.cur_block = oMemory.ReadUInt16(pt + 0xc);
				this.rec_size = oMemory.ReadUInt16(pt + 0xe);
				this.filesize = (uint)oMemory.ReadUInt16(pt + 0x10) |
					((uint)oMemory.ReadUInt16(pt + 0x12) << 16);
				this.date = oMemory.ReadUInt16(pt + 0x14);
				this.time = oMemory.ReadUInt16(pt + 0x16);
				this.sft_entries = oMemory.ReadUInt8(pt + 0x18);
				this.share_attributes = oMemory.ReadUInt8(pt + 0x19);
				this.extra_info = oMemory.ReadUInt8(pt + 0x1a);
				this.file_handle = oMemory.ReadUInt8(pt + 0x1b);
				this.reserved[0] = oMemory.ReadUInt8(pt + 0x1c);
				this.reserved[1] = oMemory.ReadUInt8(pt + 0x1d);
				this.reserved[2] = oMemory.ReadUInt8(pt + 0x1e);
				this.reserved[3] = oMemory.ReadUInt8(pt + 0x1f);
				this.cur_rec = oMemory.ReadUInt8(pt + 0x20);
				this.rndm = (uint)oMemory.ReadUInt16(pt + 0x21) |
						((uint)oMemory.ReadUInt16(pt + 0x23) << 16);
			}

			private string ReadString(uint address, int size)
			{
				StringBuilder text = new StringBuilder();

				for (int i = 0; i < size; i++)
				{
					byte ch = oMemory.ReadUInt8((uint)(address + i));
					if (ch == 0x20 || ch == 0)
						break;
					text.Append((char)ch);
				}

				return text.ToString();
			}

			private void WriteString(uint address, int size, string text)
			{
				for (int i = 0; i < size; i++)
				{
					byte ch;
					if (i >= text.Length)
						ch = 0x20;
					else
						ch = (byte)text[i];
					oMemory.WriteUInt8((uint)(address + i), ch);
				}
			}

			//public void Create(bool _extended);
			//public void SetSizeDateTime(uint _size, ushort _date, ushort _time);
			//public void GetSizeDateTime(ref uint _size, ref ushort _date, ref ushort _time);
			public void SetName(byte _drive, ref string _fname, ref string _ext)
			{
				this.drive = _drive;
				oMemory.WriteUInt8(pt, this.drive);
				this.filename = _fname;
				WriteString(pt + 1, 8, this.filename);
				this.ext = _ext;
				WriteString(pt + 9, 3, this.ext);
			}

			public string GetName()
			{
				StringBuilder name = new StringBuilder();
				//name.Append((char)((byte)'A' + GetDrive()));
				//name.Append(':');
				name.Append(this.filename);
				name.Append('.');
				name.Append(this.ext);

				return name.ToString();
			}

			public void FileOpen(byte _fhandle)
			{
				this.drive = (byte)(GetDrive() + 1);
				oMemory.WriteUInt8(pt, this.drive);
				this.file_handle = _fhandle;
				oMemory.WriteUInt8(pt + 0x1b, this.file_handle);
				this.cur_block = 0;
				oMemory.WriteUInt16(pt + 0xc, this.cur_block);
				this.rec_size = 128;
				oMemory.WriteUInt16(pt + 0xe, this.rec_size);
				//	this.rndm = 0; // breaks Jewels of darkness. 
				FileInfo info = new FileInfo(this.GetName());
				this.filesize = (uint)(info.Length & 0xffffffffu);
				oMemory.WriteUInt16(pt + 0x10, (ushort)(this.filesize & 0xffff));
				oMemory.WriteUInt16(pt + 0x12, (ushort)((this.filesize & 0xffff0000) >> 16));
				this.date = ToDosDate(info.LastWriteTime);
				oMemory.WriteUInt16(pt + 0x14, this.date);
				this.time = ToDosTime(info.LastWriteTime);
				oMemory.WriteUInt16(pt + 0x16, this.time);
			}

			// 16   word	time of last write
			// |F|E|D|C|B|A|9|8|7|6|5|4|3|2|1|0| 17,16 (Intel reverse order)
			// | | | | | | | | | | | `---------- secs in 2 second increments
			// | | | | | `--------------------- minutes (0-59)
			// `------------------------------ hours (0-23)
			private ushort ToDosTime(DateTime time)
			{
				ushort val = 0;
				val |= (ushort)((time.Second / 2) & 0x1f);
				val |= (ushort)(((time.Minute) & 0x3f) << 5);
				val |= (ushort)(((time.Hour) & 0x1f) << 11);

				return val;
			}

			// |F|E|D|C|B|A|9|8|7|6|5|4|3|2|1|0| 15,14 (Intel reverse order)
			// | | | | | | | | | | | `--------- day 1-31
			// | | | | | | | `---------------- month 1-12
			// `----------------------------- year + 1980
			private ushort ToDosDate(DateTime time)
			{
				ushort val = 0;
				val |= (ushort)((time.Day) & 0x1f);
				val |= (ushort)(((time.Minute) & 0xf) << 5);
				val |= (ushort)(((time.Year - 1980) & 0x7f) << 9);

				return val;
			}

			public void FileClose(out byte _fhandle)
			{
				_fhandle = this.file_handle;
				this.file_handle = 0xff;
				oMemory.WriteUInt8(pt + 0x1b, this.file_handle);

			}

			public void GetRecord(out ushort _cur_block, out byte _cur_rec)
			{
				_cur_block = this.cur_block;
				_cur_rec = this.cur_rec;
			}

			public void SetRecord(ushort _cur_block, byte _cur_rec)
			{
				this.cur_block = _cur_block;
				oMemory.WriteUInt16(pt + 0xc, this.cur_block);
				this.cur_rec = _cur_rec;
				oMemory.WriteUInt8(pt + 0x20, this.cur_rec);
			}

			public void GetSeqData(out byte _fhandle, out ushort _rec_size)
			{
				_fhandle = this.file_handle;
				_rec_size = this.rec_size;
			}

			public void GetRandom(out uint _random)
			{
				_random = this.rndm;
			}

			public void SetRandom(uint _random)
			{
				this.rndm = _random;
				oMemory.WriteUInt16(pt + 0x21, (ushort)(this.rndm & 0xffff));
				oMemory.WriteUInt16(pt + 0x23, (ushort)((this.rndm & 0xffff0000) >> 16));
			}

			public byte GetDrive()
			{
				if (this.drive == 0)
				{
					byte drv = 2;
					string? sRoot = Path.GetPathRoot(Assembly.GetExecutingAssembly().Location);

					if (sRoot != null && sRoot.Length == 3 && sRoot[1] == ':' && sRoot[2] == Path.PathSeparator)
					{
						drv = (byte)((byte)char.ToUpper(sRoot[0]) - (byte)'A');
					}

					return drv;
				}
				else
				{
					return (byte)(this.drive - 1);
				}
			}

			public bool Extended()
			{
				return this.extended;
			}

			public void GetAttr(ref byte attr)
			{
				if (this.extended)
				{
					attr = oMemory.ReadUInt8(pt - 1);
				}
			}

			public void SetAttr(byte attr)
			{
				if (this.extended)
				{
					oMemory.WriteUInt8(pt - 1, attr);
				}
			}

			public bool Valid()
			{
				//Very simple check for Oubliette
				if (this.filename[0] == 0 && this.file_handle == 0)
					return false;

				return true;
			}
		}
		#endregion
	}
}
