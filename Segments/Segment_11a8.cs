using Disassembler;

namespace Civilization1
{
	public class Segment_11a8
	{
		private Civilization oParent;
		private CPU oCPU;

		public Segment_11a8(Civilization parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F0_11a8_0008_Main()
		{
			this.oCPU.Log.EnterBlock("'F0_11a8_0008'(Cdecl, Far) at 0x11a8:0x0008");
			this.oCPU.CS.Word = 0x11a8; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x267;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x001a); // stack management - push return offset
			// Instruction address 0x11a8:0x0015, size: 5
			this.oParent.Segment_1000.F0_1000_0a76();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0023); // stack management - push return offset
			// Instruction address 0x11a8:0x001e, size: 5
			this.oParent.Segment_1000.F0_1000_0b70();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			
			// Main menu
			// Call to overlay
			/*this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x002b); // stack management - push return offset
			this.oParent.Overlay_1.F1_0000_0000_MainMenu();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment*/
			
			// main menu auto selection
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x1a22, 0x4d); // '1' - VGA
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x1a30, 0x4e); // '1' - No sound 0x4e, '4' - Sound blaster 0x41, '5' - Roland MIDI board 0x52
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x1a3c, 0x1); // '1' - mouse and Keyboard

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x003b); // stack management - push return offset
			// Instruction address 0x11a8:0x0038, size: 3
			F0_11a8_03f4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0040); // stack management - push return offset
			this.oParent.Overlay_2.F2_0000_0000();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x004d); // stack management - push return offset
			// Instruction address 0x11a8:0x004a, size: 3
			F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0055); // stack management - push return offset
			// Instruction address 0x11a8:0x0050, size: 5
			this.oParent.VGADriver.F0_VGA_0492_GetFreeMemory();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6dfc), 0x0);
			if (this.oCPU.Flags.E) goto L0064;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L0064:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0070;
			this.oCPU.AX.Word = 0x1f40;
			goto L0073;

		L0070:
			this.oCPU.AX.Word = 0xfa0;

		L0073:
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.LE) goto L00ee;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc8; // Segment
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x140;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0091); // stack management - push return offset
			// Instruction address 0x11a8:0x008c, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x11a8:0x00b1, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 10));

			// Instruction address 0x11a8:0x00c1, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x30be), 0xba06);

			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.AX.Word = 0x270;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00d7); // stack management - push return offset
			// Instruction address 0x11a8:0x00d2, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = 0x31;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x40;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00eb); // stack management - push return offset
			// Instruction address 0x11a8:0x00e6, size: 5
			this.oParent.Segment_1238.F0_1238_0008();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

		L00ee:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0102;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x23be);
			if (this.oCPU.Flags.GE) goto L0102;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x1a3e, 0x1);

		L0102:
			// Instruction address 0x11a8:0x0102, size: 5
			//this.oParent.VGADriver.F0_VGA_0a1e_AllocateMemory();

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0110); // stack management - push return offset
			// Instruction address 0x11a8:0x010b, size: 5
			this.oParent.Segment_2fa1.F0_2fa1_044c_LoadIcon(0x277);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6e92, this.oCPU.AX.Word);

			// Instruction address 0x11a8:0x0116, size: 5
			//this.oParent.VGADriver.F0_VGA_0a4a_FreeMemory();

			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x1a3c), 0x0);
			if (this.oCPU.Flags.E) goto L012a;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0127); // stack management - push return offset
			// Instruction address 0x11a8:0x0122, size: 5
			this.oParent.Segment_1000.F0_1000_163e_InitMouse();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x1a3c, this.oCPU.AX.Word);

		L012a:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x1a3c), 0x0);
			if (this.oCPU.Flags.E) goto L0145;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6e92));
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x013e); // stack management - push return offset
			// Instruction address 0x11a8:0x0139, size: 5
			this.oParent.Segment_1000.F0_1000_1697();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0145); // stack management - push return offset
			// Instruction address 0x11a8:0x0142, size: 3
			F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment

		L0145:
			// Game type, load, etc. menu
			// And then after menu Intro
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0149); // stack management - push return offset
			// Instruction address 0x11a8:0x0146, size: 3
			F0_11a8_0486_LogoAndMainGameMenu();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment

			// Start Game menu, level, tribe, name
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x014d); // stack management - push return offset
			// Instruction address 0x11a8:0x014a, size: 3
			F0_11a8_087c_NewGameMenu();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment

			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b32), 0x1);
			if (this.oCPU.Flags.NE) goto L016f;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7ee);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x2314));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x7);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xd4cc, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xd75e, 0x13);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x016f); // stack management - push return offset
			// Instruction address 0x11a8:0x016a, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment

		L016f:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xdc48, 0x0);

		L0175:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x017a); // stack management - push return offset
			// Instruction address 0x11a8:0x0175, size: 5
			this.oParent.Segment_1238.F0_1238_0092();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdc48), 0x0);
			if (this.oCPU.Flags.E) goto L0175;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x1a3c), 0x0);
			if (this.oCPU.Flags.E) goto L018d;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x018d); // stack management - push return offset
			// Instruction address 0x11a8:0x0188, size: 5
			this.oParent.Segment_1000.F0_1000_1687();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment

		L018d:
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0194); // stack management - push return offset
			// Instruction address 0x11a8:0x0191, size: 3
			F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x019c); // stack management - push return offset
			// Instruction address 0x11a8:0x0197, size: 5
			this.oParent.Segment_1000.F0_1000_0a39();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x01a1); // stack management - push return offset
			// Instruction address 0x11a8:0x019c, size: 5
			this.oParent.Segment_1000.F0_1000_0051();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x01a5); // stack management - push return offset
			// Instruction address 0x11a8:0x01a2, size: 3
			F0_11a8_0443();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xd751, 0x0);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xd750, 0x3);
			this.oCPU.AX.Word = 0xd750;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x10;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x01bd); // stack management - push return offset
			// Instruction address 0x11a8:0x01b8, size: 5
			this.oParent.MSCAPI.int86();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_11a8_0008'");
		}

		public void F0_11a8_0223()
		{
			this.oCPU.Log.EnterBlock("'F0_11a8_0223'(Cdecl, Far) at 0x11a8:0x0223");
			this.oCPU.CS.Word = 0x11a8; // set this function segment

			// function body
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x1a3c), 0x0);
			if (this.oCPU.Flags.E) goto L0244;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x022f); // stack management - push return offset
			// Instruction address 0x11a8:0x022a, size: 5
			this.oParent.Segment_1000.F0_1000_16d4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5872));
			this.oParent.Var_db3a = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x586e);
			this.oParent.Var_db3c = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5870);
			this.oParent.Var_db3e = this.oCPU.AX.Word;
			goto L024f;

		L0244:
			this.oCPU.AX.Word = 0;
			this.oParent.Var_db3e = 0;
			this.oParent.Var_db3c = 0;
			this.oParent.Var_db3a = 0;

		L024f:
			// Far return
			this.oCPU.Log.ExitBlock("'F0_11a8_0223'");
		}

		public void F0_11a8_0250()
		{
			this.oCPU.Log.EnterBlock("'F0_11a8_0250'(Cdecl, Far) at 0x11a8:0x0250");
			this.oCPU.CS.Word = 0x11a8; // set this function segment

			// function body
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xdeea, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdeea)));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x1a3c), 0x0);
			if (this.oCPU.Flags.E) goto L0267;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdeea), 0x1);
			if (this.oCPU.Flags.NE) goto L0267;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0267); // stack management - push return offset
			// Instruction address 0x11a8:0x0262, size: 5
			this.oParent.Segment_1000.F0_1000_16db();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment

		L0267:
			// Far return
			this.oCPU.Log.ExitBlock("'F0_11a8_0250'");
		}

		public void F0_11a8_0268()
		{
			this.oCPU.Log.EnterBlock("'F0_11a8_0268'(Cdecl, Far) at 0x11a8:0x0268");
			this.oCPU.CS.Word = 0x11a8; // set this function segment

			// function body
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x1a3c), 0x0);
			if (this.oCPU.Flags.E) goto L027b;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdeea), 0x1);
			if (this.oCPU.Flags.NE) goto L027b;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x027b); // stack management - push return offset
			// Instruction address 0x11a8:0x0276, size: 5
			this.oParent.Segment_1000.F0_1000_170b();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment

		L027b:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xdeea, this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdeea)));
			// Far return
			this.oCPU.Log.ExitBlock("'F0_11a8_0268'");
		}

		public void F0_11a8_0280()
		{
			this.oCPU.Log.EnterBlock("'F0_11a8_0280'(Cdecl, Far) at 0x11a8:0x0280");
			this.oCPU.CS.Word = 0x11a8; // set this function segment

			// function body
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdeea);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x652e, this.oCPU.AX.Word);
			goto L028c;

		L0288:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x028c); // stack management - push return offset
			// Instruction address 0x11a8:0x0289, size: 3
			F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment

		L028c:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdeea), 0x1);
			if (this.oCPU.Flags.L) goto L0288;
			// Far return
			this.oCPU.Log.ExitBlock("'F0_11a8_0280'");
		}

		public void F0_11a8_0294()
		{
			this.oCPU.Log.EnterBlock("'F0_11a8_0294'(Cdecl, Far) at 0x11a8:0x0294");
			this.oCPU.CS.Word = 0x11a8; // set this function segment

			// function body
			goto L029a;

		L0296:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x029a); // stack management - push return offset
			// Instruction address 0x11a8:0x0297, size: 3
			F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment

		L029a:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x652e);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdeea), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L0296;
			// Far return
			this.oCPU.Log.ExitBlock("'F0_11a8_0294'");
		}

		public void F0_11a8_02a4()
		{
			this.oCPU.Log.EnterBlock("'F0_11a8_02a4'(Cdecl, Far) at 0x11a8:0x02a4");
			this.oCPU.CS.Word = 0x11a8; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x102);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), 0x0);
			if (this.oCPU.Flags.NE) goto L02d9;
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1ace)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x02c2); // stack management - push return offset
			// Instruction address 0x11a8:0x02bd, size: 5
			this.oParent.Segment_1000.F0_1000_066a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L02d4;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xe17c, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			goto L03d5;

		L02d4:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), 0x0);

		L02d9:
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1ace)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x02ea); // stack management - push return offset
			// Instruction address 0x11a8:0x02e5, size: 5
			this.oParent.Segment_1000.F0_1000_066a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L02f9;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), 0xffff);
			if (this.oCPU.Flags.E) goto L02f9;
			goto L03cc;

		L02f9:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0304); // stack management - push return offset
			// Instruction address 0x11a8:0x02ff, size: 5
			this.oParent.Segment_1000.F0_1000_0846(this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0312;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8), 0x1);

		L0312:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0316); // stack management - push return offset
			// Instruction address 0x11a8:0x0313, size: 3
			F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.AX.Word = 0xf;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x140;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x032f); // stack management - push return offset
			// Instruction address 0x11a8:0x032a, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdeba);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x31);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x1ade, this.oCPU.AX.Low);

			// Instruction address 0x11a8:0x034a, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x100), 0x1a93);

			// Instruction address 0x11a8:0x035b, size: 5
			this.oParent.MSCAPI.strcat((ushort)(this.oCPU.BP.Word - 0x100), 0x1ade);

			// Instruction address 0x11a8:0x036c, size: 5
			this.oParent.MSCAPI.strcat((ushort)(this.oCPU.BP.Word - 0x100), 0x1aa7);

			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x3936);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x3936, 0xffff);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xd206, 0x1);
			this.oCPU.AX.Word = 0x51;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x64;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x100));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0399); // stack management - push return offset
			// Instruction address 0x11a8:0x0394, size: 5
			this.oParent.Segment_1238.F0_1238_0008();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x3936, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xf;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x140;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x03bc); // stack management - push return offset
			// Instruction address 0x11a8:0x03b7, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x1ae0, 0x1);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x03c9); // stack management - push return offset
			// Instruction address 0x11a8:0x03c6, size: 3
			F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			goto L02d9;

		L03cc:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xe17c, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));

		L03d5:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_11a8_02a4'");
		}

		public void F0_11a8_03f4()
		{
			this.oCPU.Log.EnterBlock("'F0_11a8_03f4'(Cdecl, Far) at 0x11a8:0x03f4");
			this.oCPU.CS.Word = 0x11a8; // set this function segment

			// function body
			this.oCPU.AX.Word = 0x1b;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x03fd); // stack management - push return offset
			// Instruction address 0x11a8:0x03f8, size: 5
			this.oParent.MSCAPI._dos_getvect();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xb270, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xb272, this.oCPU.DX.Word);
			this.oCPU.AX.Word = 0x23;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0410); // stack management - push return offset
			// Instruction address 0x11a8:0x040b, size: 5
			this.oParent.MSCAPI._dos_getvect();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xe2be, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xe2c0, this.oCPU.DX.Word);
			this.oCPU.AX.Word = 0x3d9;
			this.oCPU.DX.Word = 0x11a8;
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1b; // Segment
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x042b); // stack management - push return offset
			// Instruction address 0x11a8:0x0426, size: 5
			this.oParent.MSCAPI._dos_setvect();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = 0x3d9;
			this.oCPU.DX.Word = 0x11a8;
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x23;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x043f); // stack management - push return offset
			// Instruction address 0x11a8:0x043a, size: 5
			this.oParent.MSCAPI._dos_setvect();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			// Far return
			this.oCPU.Log.ExitBlock("'F0_11a8_03f4'");
		}

		public void F0_11a8_0443()
		{
			this.oCPU.Log.EnterBlock("'F0_11a8_0443'(Cdecl, Far) at 0x11a8:0x0443");
			this.oCPU.CS.Word = 0x11a8; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb272));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb270));
			this.oCPU.AX.Word = 0x1b;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0454); // stack management - push return offset
			// Instruction address 0x11a8:0x044f, size: 5
			this.oParent.MSCAPI._dos_setvect();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xe2c0));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xe2be));
			this.oCPU.AX.Word = 0x23;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0468); // stack management - push return offset
			// Instruction address 0x11a8:0x0463, size: 5
			this.oParent.MSCAPI._dos_setvect();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			// Far return
			this.oCPU.Log.ExitBlock("'F0_11a8_0443'");
		}

		public void F0_11a8_046c()
		{
			this.oCPU.Log.EnterBlock("'F0_11a8_046c'(Cdecl, Far) at 0x11a8:0x046c");
			this.oCPU.CS.Word = 0x11a8; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x19c0), 0x10);
			if (this.oCPU.Flags.E) goto L0484;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0481); // stack management - push return offset
			// Instruction address 0x11a8:0x047c, size: 5
			this.oParent.Segment_1000.F0_1000_0a32();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

		L0484:
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_11a8_046c'");
		}

		public void F0_11a8_0486_LogoAndMainGameMenu()
		{
			this.oCPU.Log.EnterBlock("'F0_11a8_0486'(Cdecl, Far) at 0x11a8:0x0486");
			this.oCPU.CS.Word = 0x11a8; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xd76a, 0x0); // Segment
			goto L04bb;

		L0494:
			// Instruction address 0x11a8:0x049c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, 0x1ae2);

			this.oCPU.AX.Word = 0x8c;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x64;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x04b5); // stack management - push return offset
			// Instruction address 0x11a8:0x04b0, size: 5
			this.oParent.Segment_1238.F0_1238_0008();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b32, this.oCPU.AX.Word);

		L04bb:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b32), 0xffff);
			if (this.oCPU.Flags.E) goto L0494;

		L04c2:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x04c7); // stack management - push return offset
			// Instruction address 0x11a8:0x04c2, size: 5
			this.oParent.Segment_1000.F0_1000_0a4e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1495);
			if (this.oCPU.Flags.LE) goto L04dc;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x1495);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x120; // Segment
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L04c2;

		L04dc:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x04e4); // stack management - push return offset
			// Instruction address 0x11a8:0x04e1, size: 3
			F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b32);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0511;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L04f6;
			goto L07bd;

		L04f6:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L04fe;
			goto L0795;

		L04fe:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L0506;
			goto L0591;

		L0506:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4);
			if (this.oCPU.Flags.NE) goto L050e;
			goto L07ee;

		L050e:
			goto L0810;

		L0511:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0515); // stack management - push return offset
			// Instruction address 0x11a8:0x0512, size: 3
			F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L051a:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x7ef6), 0x1);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x4);
			if (this.oCPU.Flags.L) goto L051a;

			L052e:
			// Intro...
			// Call to overlay
			this.oCPU.Log = this.oParent.IntroLog;
			this.oCPU.Log.EnterBlock("'Intro start'");
			this.oParent.VGADriverLog.EnterBlock("'Intro start'");
			this.oParent.InterruptLog.EnterBlock("'Intro start'");
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0533); // stack management - push return offset
			this.oParent.Overlay_7.F7_0000_0012_GameIntro();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oParent.InterruptLog.ExitBlock("'Intro end'");
			this.oParent.VGADriverLog.ExitBlock("'Intro end'");
			this.oCPU.Log.ExitBlock("'Intro end'");
			this.oCPU.Log = this.oParent.Log;

			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);
			
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0543); // stack management - push return offset
			// Instruction address 0x11a8:0x053e, size: 5
			this.oParent.Segment_1000.F0_1000_0846(0);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0553); // stack management - push return offset
			// Instruction address 0x11a8:0x054e, size: 5
			this.oParent.Segment_2fa1.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x1b33, 0);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

		L0549:
			// Instruction address 0x11a8:0x0576, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19d4),
				0xa0, 0x32, 0xa0, 0x96,
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19e8),
				0xa0, 0x32);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x058b); // stack management - push return offset
			// Instruction address 0x11a8:0x0588, size: 3
			F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			goto L0810;

		L0591:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0595); // stack management - push return offset
			// Instruction address 0x11a8:0x0592, size: 3
			F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x7;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x05a3); // stack management - push return offset
			// Instruction address 0x11a8:0x05a0, size: 3
			F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L05be;
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x5;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x05bb); // stack management - push return offset
			// Instruction address 0x11a8:0x05b6, size: 5
			this.oParent.Segment_1000.F0_1000_04d4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);

		L05be:
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x140;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x05d6); // stack management - push return offset
			// Instruction address 0x11a8:0x05d1, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);

			//this.oCPU.PushWord(0x1b3d);
			//this.oCPU.PushWord(1);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x05e6); // stack management - push return offset
			// Instruction address 0x11a8:0x05e1, size: 5
			//this.oParent.Segment_2fa1.F0_2fa1_0220(1, 0x1b3d);
			this.oParent.Segment_2fa1.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x1b3d, 1);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x05f6); // stack management - push return offset
			// Instruction address 0x11a8:0x05f3, size: 3
			F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

			// Instruction address 0x11a8:0x0611, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				0, 0);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x061d); // stack management - push return offset
			// Instruction address 0x11a8:0x061a, size: 3
			F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2f9a, 0x1);

		L0623:
			this.oCPU.AX.Word = 0xb;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xd2;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0630); // stack management - push return offset
			// Instruction address 0x11a8:0x062b, size: 5
			this.oParent.Segment_1000.F0_1000_16ae();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

			// Instruction address 0x11a8:0x063b, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, 0x1b48);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0654); // stack management - push return offset
			// Instruction address 0x11a8:0x064f, size: 5
			this.oParent.Segment_1238.F0_1238_0008();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x7ef6, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L0623;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f9c), 0x0);
			if (this.oCPU.Flags.E) goto L067a;
			this.oCPU.AX.Word = 0x1b6a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x066f); // stack management - push return offset
			this.oParent.Overlay_4.F4_0000_0000();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x7ef6);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2f9a, this.oCPU.AX.Word);
			goto L0623;

		L067a:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2f9a, 0x1);

		L0680:
			this.oCPU.AX.Word = 0x3d;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xd2;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x068d); // stack management - push return offset
			// Instruction address 0x11a8:0x0688, size: 5
			this.oParent.Segment_1000.F0_1000_16ae();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

			// Instruction address 0x11a8:0x0698, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, 0x1b6f);

			this.oCPU.AX.Word = 0x33;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x06b1); // stack management - push return offset
			// Instruction address 0x11a8:0x06ac, size: 5
			this.oParent.Segment_1238.F0_1238_0008();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x7ef8, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L0680;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f9c), 0x0);
			if (this.oCPU.Flags.E) goto L06d7;
			this.oCPU.AX.Word = 0x1b94;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x06cc); // stack management - push return offset
			this.oParent.Overlay_4.F4_0000_0000();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x7ef8);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2f9a, this.oCPU.AX.Word);
			goto L0680;

		L06d7:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2f9a, 0x1);

		L06dd:
			this.oCPU.AX.Word = 0x6f;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xd2;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x06ea); // stack management - push return offset
			// Instruction address 0x11a8:0x06e5, size: 5
			this.oParent.Segment_1000.F0_1000_16ae();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

			// Instruction address 0x11a8:0x06f5, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, 0x1ba0);

			this.oCPU.AX.Word = 0x65;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x070e); // stack management - push return offset
			// Instruction address 0x11a8:0x0709, size: 5
			this.oParent.Segment_1238.F0_1238_0008();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x7efa, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L06dd;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f9c), 0x0);
			if (this.oCPU.Flags.E) goto L0734;
			this.oCPU.AX.Word = 0x1bbd;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0729); // stack management - push return offset
			this.oParent.Overlay_4.F4_0000_0000();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x7efa);

		L072f:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2f9a, this.oCPU.AX.Word);
			goto L06dd;

		L0734:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2f9a, 0x1); // Segment

		L073a:
			this.oCPU.AX.Word = 0xa1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xd2;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0747); // stack management - push return offset
			// Instruction address 0x11a8:0x0742, size: 5
			this.oParent.Segment_1000.F0_1000_16ae();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

			// Instruction address 0x11a8:0x0752, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, 0x1bc5);

			this.oCPU.AX.Word = 0x97;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc8; // Segment
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x076b); // stack management - push return offset
			// Instruction address 0x11a8:0x0766, size: 5
			this.oParent.Segment_1238.F0_1238_0008();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x7efc, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L073a;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f9c), 0x0);
			if (this.oCPU.Flags.E) goto L078e;
			this.oCPU.AX.Word = 0x1bfe;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0786); // stack management - push return offset
			this.oParent.Overlay_4.F4_0000_0000();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x7efc);
			goto L072f;

		L078e:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0792); // stack management - push return offset
			// Instruction address 0x11a8:0x078f, size: 3
			F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			goto L052e;

		L0795:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0799); // stack management - push return offset
			// Instruction address 0x11a8:0x0796, size: 3
			F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xd76a, 0x1);
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07a4); // stack management - push return offset
			this.oParent.Overlay_7.F7_0000_0012_GameIntro();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07b4); // stack management - push return offset
			// Instruction address 0x11a8:0x07af, size: 5
			this.oParent.Segment_1000.F0_1000_0846(0);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0553); // stack management - push return offset
			// Instruction address 0x11a8:0x054e, size: 5
			this.oParent.Segment_2fa1.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x1c02, 0);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

			goto L0549;

		L07bd:
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07c6); // stack management - push return offset
			this.oParent.Overlay_11.F11_0000_0000();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0807;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07d0); // stack management - push return offset
			// Instruction address 0x11a8:0x07cd, size: 3
			F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.AX.Word = 0x7;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x140;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07e9); // stack management - push return offset
			// Instruction address 0x11a8:0x07e4, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			goto L0810;

		L07ee:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07f2); // stack management - push return offset
			// Instruction address 0x11a8:0x07ef, size: 3
			F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07f7); // stack management - push return offset
			this.oParent.Overlay_3.F3_0000_002b();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0800); // stack management - push return offset
			this.oParent.Overlay_3.F3_0000_00d7();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0807); // stack management - push return offset
			// Instruction address 0x11a8:0x0804, size: 3
			F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment

		L0807:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b32, 0xffff);
			goto L04bb;

		L0810:
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0815); // stack management - push return offset
			this.oParent.Overlay_5.F5_0000_1455();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2f98, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0848;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b32), 0x0);
			if (this.oCPU.Flags.E) goto L0837;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b32), 0x2);
			if (this.oCPU.Flags.E) goto L0837;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b32), 0x3);
			if (this.oCPU.Flags.NE) goto L0848;

		L0837:
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x5;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0845); // stack management - push return offset
			// Instruction address 0x11a8:0x0840, size: 5
			this.oParent.Segment_1000.F0_1000_04d4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);

		L0848:
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x140;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0860); // stack management - push return offset
			// Instruction address 0x11a8:0x085b, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x086c); // stack management - push return offset
			// Instruction address 0x11a8:0x0867, size: 5
			this.oParent.Segment_2fa1.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x1c0c, 1);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0874); // stack management - push return offset
			// Instruction address 0x11a8:0x086f, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_05dd();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0878); // stack management - push return offset
			// Instruction address 0x11a8:0x0875, size: 3
			F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_11a8_0486'");
		}

		public void F0_11a8_087c_NewGameMenu()
		{
			this.oCPU.Log.EnterBlock("'F0_11a8_087c'(Cdecl, Far) at 0x11a8:0x087c");
			this.oCPU.CS.Word = 0x11a8; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x1a3c), 0x0);
			if (this.oCPU.Flags.E) goto L0899;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd4dc));
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0896); // stack management - push return offset
			// Instruction address 0x11a8:0x0891, size: 5
			this.oParent.Segment_1000.F0_1000_1697();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

		L0899:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x81d2), 0x0);
			if (this.oCPU.Flags.NE) goto L08c5;

			//this.oCPU.PushWord(0x1c16);
			//this.oCPU.PushWord(1);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x08ad); // stack management - push return offset
			// Instruction address 0x11a8:0x08a8, size: 5
			//this.oParent.Segment_2fa1.F0_2fa1_0220(1, 0x1c16);
			this.oParent.Segment_2fa1.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x1c16, 1);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x08bd); // stack management - push return offset
			// Instruction address 0x11a8:0x08ba, size: 3
			F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x08c5); // stack management - push return offset
			this.oParent.Overlay_5.F5_0000_0000();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment

		L08c5:
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x08ca); // stack management - push return offset
			this.oParent.Overlay_5.F5_0000_1af6();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x08d7); // stack management - push return offset
			// Instruction address 0x11a8:0x08d4, size: 3
			F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_11a8_087c'");
		}

		public void F0_11a8_08db()
		{
			this.oCPU.Log.EnterBlock("'F0_11a8_08db'(Cdecl, Far) at 0x11a8:0x08db");
			this.oCPU.CS.Word = 0x11a8; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xd751, 0x2);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xd753, 0x0);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xd757, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xd756, this.oCPU.AX.Low);
			this.oCPU.AX.Word = 0xd750;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x10; // Segment
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0902); // stack management - push return offset
			// Instruction address 0x11a8:0x08fd, size: 5
			this.oParent.MSCAPI.int86();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x11a8; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_11a8_08db'");
		}
	}
}
