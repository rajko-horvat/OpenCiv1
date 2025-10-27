using System;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class HallOfFame
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public HallOfFame(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F3_0000_0000()
		{
			this.oCPU.Log.EnterBlock("F3_0000_0000()");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x0);

		L000b:
			this.oCPU.AX.UInt16 = 0x2e;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.ES.UInt16 = 0x3772; // segment
			this.oCPU.WriteUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x37d2), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 
				this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x6);
			if (this.oCPU.Flags.L) goto L000b;

			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F3_0000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F3_0000_002b()
		{
			this.oCPU.Log.EnterBlock("F3_0000_002b()");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0x2);

			F3_0000_0000();

			// Instruction address 0x0000:0x0041, size: 5
			this.oParent.MSCAPI.open("fame.dta", 0x8102, 0x80);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x0057, size: 5
			this.oParent.MSCAPI.read((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 
				0xba06, 0x114);

			this.oParent.MSCAPI.movedata(
				this.oCPU.DS.UInt16,
				0xba06,
				0x3772,
				0x37d2,
				0x114);

			// Instruction address 0x0000:0x007a, size: 5
			this.oParent.MSCAPI.close((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));

			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F3_0000_002b");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F3_0000_0083()
		{
			this.oCPU.Log.EnterBlock("F3_0000_0083()");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0x2);

			// Instruction address 0x0000:0x0095, size: 5
			this.oParent.MSCAPI.open("fame.dta", 0x8302, 0x80);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);

			this.oParent.MSCAPI.movedata(
				0x3772,
				0x37d2,
				this.oCPU.DS.UInt16,
				0xba06,
				0x114);

			// Instruction address 0x0000:0x00c3, size: 5
			this.oParent.MSCAPI.write((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				0xba06, 0x114);
			
			// Instruction address 0x0000:0x00ce, size: 5
			this.oParent.MSCAPI.close((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));

			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F3_0000_0083");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <returns></returns>
		public ushort F3_0000_00d7(ushort param1)
		{
			this.oCPU.Log.EnterBlock($"F3_0000_00d7({param1})");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0x1c);
			this.oCPU.PUSHUInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSHUInt16(this.oCPU.SI.UInt16);

			// Instruction address 0x0000:0x00f3, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 15);

			// Instruction address 0x0000:0x010a, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToRectAA("CIVILIZATION", 160, 16, 0);

			// Instruction address 0x0000:0x0121, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToRectAA("HALL OF FAME", 160, 24, 0);

			// Instruction address 0x0000:0x013d, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 80, 32, 240, 32, 14);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0x28);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 0x0);
			goto L0160;

		L0151:
			this.oCPU.CMPUInt16(param1, 0x5);
			if (this.oCPU.Flags.NE) goto L01d1;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x4);
			if (this.oCPU.Flags.NE) goto L01d1;

		L015d:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))));

		L0160:
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x6);
			if (this.oCPU.Flags.GE) goto L0174;
			this.oCPU.AX.UInt16 = param1;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0151;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x5);
			if (this.oCPU.Flags.NE) goto L0151;

		L0174:
			this.oCPU.CMPUInt16(param1, 0xffff);
			if (this.oCPU.Flags.E) goto L01ad;

			// Instruction address 0x0000:0x0189, size: 5
			this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA("'C\x0083lear'", 252, 189, 0);

			// Instruction address 0x0000:0x01a5, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(236, 187, 60, 10, 11);

		L01ad:
			// Instruction address 0x0000:0x01ad, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.AX.UInt16);
			this.oCPU.CMPUInt16(param1, 0xffff);
			if (this.oCPU.Flags.NE) goto L01be;
			goto L050b;

		L01be:
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, 0x63);
			if (this.oCPU.Flags.E) goto L01cb;
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, 0x43);
			if (this.oCPU.Flags.E) goto L01cb;
			goto L050b;

		L01cb:
			this.oCPU.AX.UInt16 = 0x1;
			goto L050d;

		L01d1:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x8);
			this.oCPU.AX.UInt16 = 0x2e;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.ES.UInt16 = 0x3772; // segment
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x37d2));
			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.DI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.DI.UInt16, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.DI.UInt16 - 0x1c), this.oCPU.SI.UInt16);
			this.oCPU.SI.UInt16 = this.oCPU.ORUInt16(this.oCPU.SI.UInt16, this.oCPU.SI.UInt16);
			if (this.oCPU.Flags.G) goto L0220;

			// Instruction address 0x0000:0x01fb, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " ---");

			// Instruction address 0x0000:0x0211, size: 5
			this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA(0xba06, 8, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 
				this.oCPU.ADDUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0x1a));
			goto L015d;

		L0220:
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x0000:0x023f, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)) + 1), 10));

			// Instruction address 0x0000:0x024f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ". ");

			this.oCPU.AX.UInt16 = 0x2e;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			this.oParent.MSCAPI.movedata(
				0x3772,
				(ushort)(this.oCPU.SI.UInt16 + 0x37e0),
				this.oCPU.DS.UInt16,
				(ushort)(0xba06 + this.oParent.MSCAPI.strlen(0xba06)),
				16);

			// Instruction address 0x0000:0x028c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ", ");

			this.oCPU.ES.UInt16 = 0x3772; // segment
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37d4));
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);
			// Instruction address 0x0000:0x02a7, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x33a2)));

			// Instruction address 0x0000:0x02b7, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " of the ");

			this.oParent.MSCAPI.movedata(
				0x3772,
				(ushort)(this.oCPU.SI.UInt16 + 0x37f0),
				this.oCPU.DS.UInt16,
				(ushort)(0xba06 + this.oParent.MSCAPI.strlen(0xba06)),
				16);

			// Instruction address 0x0000:0x02e8, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x02fb, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " to ");

			this.oCPU.ES.UInt16 = 0x3772; // segment
										
			// Instruction address 0x0000:0x032a, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(Math.Abs((short)this.oCPU.ReadUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37d8))), 10));

			this.oCPU.ES.UInt16 = 0x3772; // segment
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37d8)), 0x0);
			if (this.oCPU.Flags.GE) goto L0343;
			
			// Instruction address 0x0000:0x034b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " BC.");

			goto L0346;

		L0343:
			// Instruction address 0x0000:0x034b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " AD.");

		L0346:
			// Instruction address 0x0000:0x0357, size: 5
			this.oParent.DrawStringTools.F0_1182_00ef_GetStringWidth(0xba06);

			this.oCPU.AX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, 0x140);
			if (this.oCPU.Flags.L) goto L036f;
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06), 0x0);

		L036f:
			// Instruction address 0x0000:0x037c, size: 5
			this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA(0xba06,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)),
				0);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 
				this.oCPU.ADDUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0x8));

			// Instruction address 0x0000:0x0390, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Population: ");

			this.oCPU.AX.UInt16 = 0x2e;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.ES.UInt16 = 0x3772; // segment
			
			// Instruction address 0x0000:0x03a9, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0337(this.oCPU.ReadInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37de)));

			// Instruction address 0x0000:0x03b9, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ", Score: ");

			this.oCPU.ES.UInt16 = 0x3772; // segment

			// Instruction address 0x0000:0x03df, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37d2)), 10));

			this.oCPU.ES.UInt16 = 0x3772; // segment
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37d4));
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0416;
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.NE) goto L03fc;
			goto L04f3;

		L03fc:
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, 0x2);
			if (this.oCPU.Flags.NE) goto L0404;
			goto L04f9;

		L0404:
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, 0x3);
			if (this.oCPU.Flags.NE) goto L040c;
			goto L04ff;

		L040c:
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, 0x4);
			if (this.oCPU.Flags.NE) goto L0414;
			goto L0505;

		L0414:
			goto L0426;

		L0416:
			// Instruction address 0x0000:0x041e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " (Chieftan)");

		L0426:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.SI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SI.UInt16, 0xc);

			// Instruction address 0x0000:0x0438, size: 5
			this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA(0xba06, (short)this.oCPU.SI.UInt16,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)),
				7);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 
				this.oCPU.ADDUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0x8));

			// Instruction address 0x0000:0x044c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "    --- CIVILIZATION RATING: ");

			this.oCPU.AX.UInt16 = 0x2e;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;
			
			// Instruction address 0x0000:0x0487, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((((short)this.oCPU.ReadUInt16(0x3772, 
					(ushort)(this.oCPU.DI.UInt16 + 0x37d4)) + 1) *
					(short)this.oCPU.ReadUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.DI.UInt16 + 0x37d2))) / 0x32), 10));

			// Instruction address 0x0000:0x0497, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "% ---");

			// Instruction address 0x0000:0x04ab, size: 5
			this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA(0xba06, (short)this.oCPU.SI.UInt16,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)),
				12);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 
				this.oCPU.ADDUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 
				this.oCPU.ADDUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0x2));
			this.oCPU.AX.UInt16 = param1;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L04c6;
			goto L015d;

		L04c6:
			// Instruction address 0x0000:0x04e8, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)) - 4,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)) - 28,
				296, 26, 15, 14);

			goto L015d;

		L04f3:
			// Instruction address 0x0000:0x041e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " (Warlord)");

			goto L0426;

		L04f9:
			// Instruction address 0x0000:0x041e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " (Prince)");

			goto L0426;

		L04ff:
			// Instruction address 0x0000:0x041e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " (King)");

			goto L0426;

		L0505:
			// Instruction address 0x0000:0x041e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " (Emperor)");

			goto L0426;

		L050b:
			this.oCPU.AX.UInt16 = 0;

		L050d:
			this.oCPU.SI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F3_0000_00d7");

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F3_0000_0513()
		{
			this.oCPU.Log.EnterBlock("F3_0000_0513()");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0xe);
			this.oCPU.PUSHUInt16(this.oCPU.SI.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x0);

		L051f:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x0);
			goto L061a;

		L0527:
			this.oCPU.AX.UInt16 = 0x2e;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.AX.UInt16, 0x37d2);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 0x3772);
			this.oCPU.AX.UInt16 = this.oCPU.SI.UInt16;
			this.oCPU.AX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.AX.UInt16, 0x37a4);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), 0x3772);

			// Instruction address 0x0000:0x0557, size: 5
			this.oParent.MSCAPI.movedata(
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				0x2e);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 
				this.oCPU.DECUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))));

		L0562:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.G) goto L0527;

			this.oCPU.AX.UInt16 = 0x2e;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xb77e);
			this.oCPU.ES.UInt16 = 0x3772; // segment
			this.oCPU.WriteUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37d2), this.oCPU.AX.UInt16);

			this.oCPU.WriteString(VCPU.ToLinearAddress(0x3772, (ushort)(this.oCPU.SI.UInt16 + 0x37e0)),
				this.oGameData.Players[this.oGameData.HumanPlayerID].Name, 13);

			this.oCPU.WriteString(VCPU.ToLinearAddress(0x3772, (ushort)(this.oCPU.SI.UInt16 + 0x37f0)),
				this.oGameData.Players[this.oGameData.HumanPlayerID].Nation, 11);

			this.oCPU.AX.UInt16 = (ushort)((short)this.oGameData.DifficultyLevel);
			this.oCPU.ES.UInt16 = 0x3772; // segment
			this.oCPU.WriteUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37d4), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xdc6a);
			this.oCPU.WriteUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37d6), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xd764);
			this.oCPU.WriteUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37da), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xd766);
			this.oCPU.WriteUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37dc), this.oCPU.AX.UInt16);
			this.oCPU.WriteInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37d8), oParent.GameData.Year);
			
			// Instruction address 0x0000:0x05ec, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_02cd(this.oGameData.HumanPlayerID);

			this.oCPU.ES.UInt16 = 0x3772; // segment
			this.oCPU.WriteUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37de), this.oCPU.AX.UInt16);

			F3_0000_00d7(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));

			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0612;

			F3_0000_0000();

			goto L051f;

		L0612:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			goto L0658;

		L0617:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 
				this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))));

		L061a:
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), 0x6);
			if (this.oCPU.Flags.GE) goto L0655;

			this.oCPU.AX.UInt16 = 0x2e;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.ES.UInt16 = 0x3772; // segment
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37d4));
			this.oCPU.AX.UInt16 = this.oCPU.INCUInt16(this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.INCUInt16(this.oCPU.AX.UInt16);
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.ES.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x37d2)));
			this.oCPU.CX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = (ushort)((short)this.oGameData.DifficultyLevel);
			this.oCPU.AX.UInt16 = this.oCPU.INCUInt16(this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.INCUInt16(this.oCPU.AX.UInt16);
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xb77e));
			this.oCPU.CMPUInt16(this.oCPU.CX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.L) goto L064d;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), 0x5);
			if (this.oCPU.Flags.NE) goto L0617;

		L064d:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0x5);
			goto L0562;

		L0655:
			this.oCPU.AX.UInt16 = 0xffff;

		L0658:
			this.oCPU.SI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F3_0000_0513");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		public void F3_0000_065d(ushort param1, ushort param2)
		{
			this.oCPU.Log.EnterBlock($"F3_0000_065d({param1}, {param2})");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0xa);

			this.oCPU.CMPUInt16(param2, 0x0);
			if (this.oCPU.Flags.E) goto L06a6;
			this.oCPU.CX.UInt16 = (ushort)((short)this.oGameData.DifficultyLevel);
			this.oCPU.CX.UInt16 = this.oCPU.INCUInt16(this.oCPU.CX.UInt16);
			this.oCPU.AX.UInt16 = param2;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.UInt16 = 0x32;
			this.oCPU.IDIVUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			param1 = 0xffff;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x1);

		L0686:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.AX.UInt16);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.UInt16 = 0x3;
			this.oCPU.IDIVUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
			if (this.oCPU.Flags.GE) goto L069d;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.AX.UInt16 = this.oCPU.DECUInt16(this.oCPU.AX.UInt16);
			param1 = this.oCPU.AX.UInt16;

		L069d:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 
				this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), 0x14);
			if (this.oCPU.Flags.LE) goto L0686;

		L06a6:
			this.oCPU.CMPUInt16(param1, 0x0);
			if (this.oCPU.Flags.GE) goto L06af;
			goto L09a8;

		L06af:
			this.oCPU.CMPUInt16(param1, 0x13);
			if (this.oCPU.Flags.LE) goto L06ba;

			param1 = 0x13;

		L06ba:
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			// Instruction address 0x0000:0x06c8, size: 5
			this.oParent.CommonTools.F0_1000_0a32_PlayTune(0x22, 0);

			// Instruction address 0x0000:0x06e4, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 15);

			// Instruction address 0x0000:0x06ec, size: 5
			this.oParent.Segment_1866.F0_1866_260e();

			// Instruction address 0x0000:0x070e, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 200, 140, 40, 60, this.oParent.Var_aa_Rectangle, 10, 10);

			// Instruction address 0x0000:0x0736, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 240, 140, 40, 60, this.oParent.Var_aa_Rectangle, 270, 10);

			this.oParent.Var_aa_Rectangle.FontID = 7;

			// Instruction address 0x0000:0x0757, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_03ce_FillRectangleWithPattern(80, 4, 160, 27);

			// Instruction address 0x0000:0x0777, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0a66_DrawShadowRectangle(80, 4, 159, 26, 11, 8);

			this.oCPU.CMPUInt16(param2, 0x0);
			if (this.oCPU.Flags.E) goto L0788;
			goto L0814;

		L0788:
			this.oParent.MSCAPI.movedata(
				0x36d4,
				0x1f4,
				this.oCPU.DS.UInt16,
				0xba06,
				0x20);

			// Instruction address 0x0000:0x07b0, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 6, 15);

			this.oParent.MSCAPI.movedata(
				0x36d4,
				0x20d,
				this.oCPU.DS.UInt16,
				0xba06,
				0x20);

			// Instruction address 0x0000:0x07e0, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 14, 15);

			this.oParent.MSCAPI.movedata(
				0x36d4,
				(ushort)((0x13 - param1) * 0x19),
				this.oCPU.DS.UInt16,
				0xba06,
				0x20);

			// Instruction address 0x0000:0x08d2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!");

			goto L08cd;

		L0814:
			this.oParent.MSCAPI.movedata(
				0x36d4,
				0x226,
				this.oCPU.DS.UInt16,
				0xba06,
				0x20);

			// Instruction address 0x0000:0x083c, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 6, 15);

			this.oParent.MSCAPI.movedata(
				0x36d4,
				0x23f,
				this.oCPU.DS.UInt16,
				0xba06,
				0x20);

			// Instruction address 0x0000:0x0874, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 10));

			// Instruction address 0x0000:0x0884, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "% exceeds even");

			// Instruction address 0x0000:0x089c, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 14, 15);

			this.oParent.MSCAPI.movedata(
				0x36d4,
				(ushort)((0x13 - param1) * 0x19),
				this.oCPU.DS.UInt16,
				0xba06,
				0x20);

			// Instruction address 0x0000:0x08d2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!");

		L08cd:
			// Instruction address 0x0000:0x08ea, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 22, 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x0);
			goto L091d;

		L08f9:
			this.oCPU.AX.UInt16 = 0x7;

		L08fc:
			// Instruction address 0x0000:0x0912, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160,
				-((this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)) * 8) - 184), this.oCPU.AX.LowUInt8);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))));

		L091d:
			this.oCPU.AX.UInt16 = param1;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.G) goto L0957;

			this.oParent.MSCAPI.movedata(
				0x36d4,
				(ushort)((0x13 - this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))) * 0x19),
				this.oCPU.DS.UInt16,
				0xba06,
				0x20);

			this.oCPU.AX.UInt16 = param1;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L08f9;
			this.oCPU.AX.UInt16 = 0;
			goto L08fc;

		L0957:
			// Instruction address 0x0000:0x097c, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, 80, 183 - (short)param1 * 8, 160, 8, 15, 14);

			// Instruction address 0x0000:0x0984, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Instruction address 0x0000:0x098d, size: 5
			this.oParent.CommonTools.F0_1000_0a32_PlayTune(1, 0);

			this.oParent.Var_aa_Rectangle.FontID = 1;

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

		L09a8:
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F3_0000_065d");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F3_0000_09ac()
		{
			this.oCPU.Log.EnterBlock("F3_0000_09ac()");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0x20);
			this.oCPU.PUSHUInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSHUInt16(this.oCPU.SI.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x0);

		L09b9:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.SI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SI.UInt16, this.oCPU.BP.UInt16);
			this.oCPU.AX.UInt16 = 0xffff;
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 - 0x10), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 - 0x20), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x5);
			if (this.oCPU.Flags.L) goto L09b9;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12), 0x0);
			goto L0a0c;

		L09d9:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16));
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.SI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SI.UInt16, this.oCPU.BP.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 - 0x20));
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 - 0x1e), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 - 0x10));
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 - 0xe), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), this.oCPU.DECUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))));

		L09ef:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.GE) goto L09d9;
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.SI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SI.UInt16, this.oCPU.BP.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 - 0x20), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12));
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 - 0x10), this.oCPU.AX.UInt16);

		L0a09:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12), this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))));

		L0a0c:
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)), 0x80);
			if (this.oCPU.Flags.GE) goto L0a8e;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.CMPUInt8(this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L0a09;

			// Instruction address 0x0000:0x0a29, size: 5
			this.oParent.CityWorker.F0_1d12_0045_ProcessCityState(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)), -1);

			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.LowUInt8 = (byte)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.AX.UInt16, (ushort)((short)this.oParent.Var_70e2));
			this.oCPU.AX.UInt16 = this.oCPU.SUBUInt16(this.oCPU.AX.UInt16, (ushort)((short)this.oParent.Var_70e4));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x1);

		L0a4e:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12));
			this.oCPU.CMPUInt16((ushort)this.oGameData.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))], this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L0a60;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 
				this.oCPU.ADDUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0xa));

		L0a60:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 
				this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x15);
			if (this.oCPU.Flags.LE) goto L0a4e;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x0);
			goto L0a73;

		L0a70:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 
				this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));

		L0a73:
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x5);
			if (this.oCPU.Flags.GE) goto L0a09;
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0x20)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.GE) goto L0a70;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 0x3);
			goto L09ef;

		L0a8e:
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			// Instruction address 0x0000:0x0aac, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 3);

			// Instruction address 0x0000:0x0ac4, size: 5
			this.oParent.DrawStringTools.F0_1182_0086_DrawStringWithShadowToRectAA("The Top Five Cities in the World", 80, 12, 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x20);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x0);

		L0ad6:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0x20)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0ae4;
			goto L0c57;

		L0ae4:
			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.DI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.DI.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.DI.UInt16 - 0x10));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x0000:0x0b0e, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)) + 1), 10));

			// Instruction address 0x0000:0x0b1e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ". ");

			// Instruction address 0x0000:0x0b29, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)));

			// Instruction address 0x0000:0x0b39, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " (");

			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			// Instruction address 0x0000:0x0b5a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oGameData.Players[this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))].PlayerID].Nationality);

			// Instruction address 0x0000:0x0b6a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")");

			// Instruction address 0x0000:0x0b8e, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)) + 3,
				(byte)this.oParent.Array_1946[this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))].PlayerID]);

			// Instruction address 0x0000:0x0b9d, size: 5
			this.oParent.CityWorker.F0_1d12_0045_ProcessCityState(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)), -1);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x30);

			// Instruction address 0x0000:0x0bc0, size: 5
			this.oParent.CityWorker.F0_1d12_6ed4_DrawResources(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)),
				48, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)) + 10,
				this.oParent.Var_e8b8, 160);

			// Instruction address 0x0000:0x0bd9, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))].ActualSize * 8, 
				0, 160);

			this.oCPU.AX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.AX.UInt16, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.ADDUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), this.oCPU.AX.UInt16));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 0x1);

		L0bec:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12));
			this.oCPU.CMPUInt16((ushort)this.oGameData.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))], this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L0c1e;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x125);
			if (this.oCPU.Flags.GE) goto L0c1a;

			// Instruction address 0x0000:0x0c12, size: 5
			this.oParent.CityWorker.F0_1d12_7045((short)(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)) + 24),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)) + 12));

		L0c1a:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 
				this.oCPU.ADDUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x13));

		L0c1e:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 
				this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)), 0x15);
			if (this.oCPU.Flags.LE) goto L0bec;

			this.oCPU.BX.UInt16 = (ushort)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))].PlayerID;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			// Instruction address 0x0000:0x0c4b, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(8, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)),
				303, 25, 
				this.oParent.Array_1946[this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))].PlayerID]);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 
				this.oCPU.ADDUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), 0x20));

		L0c57:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 
				this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x5);
			if (this.oCPU.Flags.GE) goto L0c63;
			goto L0ad6;

		L0c63:
			// Instruction address 0x0000:0x0c63, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			this.oCPU.SI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F3_0000_09ac");
		}
	}
}
