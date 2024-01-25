using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Civilopedia
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public Civilopedia(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		public void F8_0000_0000(ushort param1)
		{
			this.oCPU.Log.EnterBlock($"F8_0000_0000({param1})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);

			// Instruction address 0x0000:0x0006, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x000b, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L0015:
			F8_0000_0066(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), param1);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L003c;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6808), 0x0);
			if (this.oCPU.Flags.E) goto L0037;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x4e));
			goto L003c;

		L0037:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L003c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xfffe);
			if (this.oCPU.Flags.NE) goto L0015;

			// Instruction address 0x0000:0x004b, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			// Instruction address 0x0000:0x0053, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			// Instruction address 0x0000:0x0058, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0626();

			// Instruction address 0x0000:0x005d, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F8_0000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <returns></returns>
		public ushort F8_0000_0066(ushort param1, ushort param2)
		{
			this.oCPU.Log.EnterBlock($"F8_0000_0066({param1}, {param2})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x5c);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x0082, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200, 14);

			// Instruction address 0x0000:0x0092, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x4c), OpenCiv1.String_3c8e);

			// Instruction address 0x0000:0x00b2, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 60, 2, 200, 9, 15);

			// Instruction address 0x0000:0x00c9, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0x3c90, 161, 4, 0);

			// Instruction address 0x0000:0x00e1, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0x3cae, 160, 3, 10);

			// Instruction address 0x0000:0x00f9, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x3ccc, 286, 4, 12);
			
			this.oCPU.CMPWord(param2, 0xffff);
			if (this.oCPU.Flags.NE) goto L011f;

			// Instruction address 0x0000:0x0117, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x3cd1, 8, 4, 12);

		L011f:
			// Instruction address 0x0000:0x0137, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 2, 14, 316, 184, 15);

			this.oCPU.CMPWord(param2, 0x0);
			if (this.oCPU.Flags.G) goto L014a;
			this.oCPU.AX.Word = 0x64;
			goto L014d;

		L014a:
			this.oCPU.AX.Word = 0x96;

		L014d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), 0xa);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 0x10);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), 0x0);

		L015f:
			// Instruction address 0x0000:0x0167, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x32), OpenCiv1.String_3cd6);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), 0xffff);
			this.oCPU.CMPWord(param2, 0x0);
			if (this.oCPU.Flags.E) goto L0185;
			this.oCPU.CMPWord(param2, 0xffff);
			if (this.oCPU.Flags.NE) goto L01d9;

		L0185:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), 0x0);

		L018a:
			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x4da);
			// Instruction address 0x0000:0x019b, size: 5
			this.oParent.MSCAPI.stricmp(this.oCPU.SI.Word, (ushort)(this.oCPU.BP.Word - 0x4c));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L01d0;

			// Instruction address 0x0000:0x01ac, size: 5
			this.oParent.MSCAPI.stricmp(this.oCPU.SI.Word, (ushort)(this.oCPU.BP.Word - 0x32));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L01d0;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), 0x0);

			// Instruction address 0x0000:0x01c8, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x32), this.oCPU.SI.Word);

		L01d0:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)), 0x43);
			if (this.oCPU.Flags.L) goto L018a;

		L01d9:
			this.oCPU.CMPWord(param2, 0x1);
			if (this.oCPU.Flags.E) goto L01e5;
			this.oCPU.CMPWord(param2, 0xffff);
			if (this.oCPU.Flags.NE) goto L0239;

		L01e5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), 0x1);

		L01ea:
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0xb9a);
			// Instruction address 0x0000:0x01fb, size: 5
			this.oParent.MSCAPI.stricmp(this.oCPU.SI.Word, (ushort)(this.oCPU.BP.Word - 0x4c));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L0230;

			// Instruction address 0x0000:0x020c, size: 5
			this.oParent.MSCAPI.stricmp(this.oCPU.SI.Word, (ushort)(this.oCPU.BP.Word - 0x32));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0230;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), 0x1);

			// Instruction address 0x0000:0x0228, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x32), this.oCPU.SI.Word);

		L0230:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)), 0x2d);
			if (this.oCPU.Flags.LE) goto L01ea;

		L0239:
			this.oCPU.CMPWord(param2, 0x2);
			if (this.oCPU.Flags.E) goto L0245;
			this.oCPU.CMPWord(param2, 0xffff);
			if (this.oCPU.Flags.NE) goto L0299;

		L0245:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), 0x0);

		L024a:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x112a);
			// Instruction address 0x0000:0x025b, size: 5
			this.oParent.MSCAPI.stricmp(this.oCPU.SI.Word, (ushort)(this.oCPU.BP.Word - 0x4c));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L0290;

			// Instruction address 0x0000:0x026c, size: 5
			this.oParent.MSCAPI.stricmp(this.oCPU.SI.Word, (ushort)(this.oCPU.BP.Word - 0x32));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0290;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), 0x2);

			// Instruction address 0x0000:0x0288, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x32), this.oCPU.SI.Word);

		L0290:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)), 0x1c);
			if (this.oCPU.Flags.L) goto L024a;

		L0299:
			this.oCPU.CMPWord(param2, 0x3);
			if (this.oCPU.Flags.E) goto L02a5;
			this.oCPU.CMPWord(param2, 0xffff);
			if (this.oCPU.Flags.NE) goto L02f9;

		L02a5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), 0x0);

		L02aa:
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x282);
			// Instruction address 0x0000:0x02bb, size: 5
			this.oParent.MSCAPI.stricmp(this.oCPU.SI.Word, (ushort)(this.oCPU.BP.Word - 0x4c));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L02f0;

			// Instruction address 0x0000:0x02cc, size: 5
			this.oParent.MSCAPI.stricmp(this.oCPU.SI.Word, (ushort)(this.oCPU.BP.Word - 0x32));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L02f0;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), 0x3);

			// Instruction address 0x0000:0x02e8, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x32), this.oCPU.SI.Word);

		L02f0:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)), 0xc);
			if (this.oCPU.Flags.L) goto L02aa;

		L02f9:
			this.oCPU.CMPWord(param2, 0x4);
			if (this.oCPU.Flags.E) goto L0305;
			this.oCPU.CMPWord(param2, 0xffff);
			if (this.oCPU.Flags.NE) goto L0359;

		L0305:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), 0x0);

		L030a:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x3c64);
			// Instruction address 0x0000:0x0319, size: 5
			this.oParent.MSCAPI.stricmp(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word), (ushort)(this.oCPU.BP.Word - 0x4c));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L0350;

			// Instruction address 0x0000:0x032b, size: 5
			this.oParent.MSCAPI.stricmp(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word), (ushort)(this.oCPU.BP.Word - 0x32));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0350;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), 0x4);

			// Instruction address 0x0000:0x0348, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x32), this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word));

		L0350:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)), 0x15);
			if (this.oCPU.Flags.L) goto L030a;

		L0359:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0362;
			goto L03f1;

		L0362:
			this.oCPU.AX.Word = param1;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L03d4;

			// Instruction address 0x0000:0x0372, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x18), (ushort)(this.oCPU.BP.Word - 0x32));

			// Instruction address 0x0000:0x0381, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_04f7(
				(ushort)(this.oCPU.BP.Word - 0x18),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)));

			// Instruction address 0x0000:0x0396, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(
				(ushort)(this.oCPU.BP.Word - 0x18),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)),
				0);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, param1);
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.ES.Word = 0x3772; // segment
			this.oCPU.WriteUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x1c80), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34));
			this.oCPU.ES.Word = 0x3772; // segment
			this.oCPU.WriteUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x36fc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), 0x7));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), 0xc0);
			if (this.oCPU.Flags.LE) goto L03d4;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 0x10);

		L03d4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))));

			// Instruction address 0x0000:0x03df, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x4c), (ushort)(this.oCPU.BP.Word - 0x32));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)), 0x12c);
			if (this.oCPU.Flags.GE) goto L03f1;
			goto L015f;

		L03f1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)), 0x12c);
			if (this.oCPU.Flags.L) goto L03fd;
			this.oCPU.AX.Word = 0x1;
			goto L03ff;

		L03fd:
			this.oCPU.AX.Word = 0;

		L03ff:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6808, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3c), 0x0);
			if (this.oCPU.Flags.NE) goto L040c;
			goto L0492;

		L040c:
			// Instruction address 0x0000:0x040c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

		L0411:
			// Instruction address 0x0000:0x0411, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();

			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.NE) goto L0426;

			// Instruction address 0x0000:0x041d, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0411;

		L0426:
			this.oCPU.AX.Word = this.oParent.Var_db3c;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0xa);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oParent.Var_db3e, 0x10);
			if (this.oCPU.Flags.L) goto L044d;
			this.oCPU.AX.Word = this.oParent.Var_db3e;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x10);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x7;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), this.oCPU.AX.Word);
			goto L0452;

		L044d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 0xffff);

		L0452:
			this.oCPU.AX.Word = 0x1a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x045e, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x2);
			if (this.oCPU.Flags.NE) goto L0474;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), 0x2);

		L0474:
			// Instruction address 0x0000:0x0474, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0480;
			goto L05b7;

		L0480:
			// Instruction address 0x0000:0x0480, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), 0x2);
			goto L05b7;

		L0492:
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), this.oCPU.AX.Word);

		L049a:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x8);
			
			this.oCPU.AX.Word = 0x7;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0xf);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x04cd, size: 5
			this.oParent.VGADriver.F0_VGA_009a_ReplaceColor(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 
				(short)this.oCPU.SI.Word, (short)this.oCPU.DI.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c)), 8, 15, 10);

			// Instruction address 0x0000:0x04d5, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x04f2, size: 5
			this.oParent.VGADriver.F0_VGA_009a_ReplaceColor(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 
				(short)this.oCPU.SI.Word, (short)this.oCPU.DI.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c)), 8, 10, 15);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54));
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4800);
			if (this.oCPU.Flags.E) goto L0513;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4b00);
			if (this.oCPU.Flags.E) goto L057f;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4d00);
			if (this.oCPU.Flags.E) goto L0538;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5000);
			if (this.oCPU.Flags.E) goto L0553;
			goto L052c;

		L0513:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), 0x0);
			if (this.oCPU.Flags.E) goto L051e;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50))));
			goto L052c;

		L051e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)), 0x0);
			if (this.oCPU.Flags.E) goto L052c;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e))));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 0x19);

		L052c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0x6d);
			if (this.oCPU.Flags.NE) goto L058a;
			this.oCPU.AX.Word = 0xffff;
			goto L0624;

		L0538:
			this.oCPU.AX.Word = 0x1a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x1a);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, param1);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.GE) goto L052c;

		L054e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e))));
			goto L052c;

		L0553:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, param1);
			this.oCPU.AX.Word = 0x1a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)));
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.CMPWord(this.oCPU.DI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.GE) goto L052c;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), 0x19);
			if (this.oCPU.Flags.GE) goto L0578;
			this.oCPU.CMPWord(this.oCPU.DI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.GE) goto L0578;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50))));
			goto L052c;

		L0578:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 0x0);
			goto L054e;

		L057f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)), 0x0);
			if (this.oCPU.Flags.E) goto L052c;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e))));
			goto L052c;

		L058a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0x1b);
			if (this.oCPU.Flags.E) goto L0596;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0x78);
			if (this.oCPU.Flags.NE) goto L059c;

		L0596:
			this.oCPU.AX.Word = 0xfffe;
			goto L0624;

		L059c:
			this.oCPU.AX.Word = 0x1a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0xd);
			if (this.oCPU.Flags.E) goto L05b7;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0x20);
			if (this.oCPU.Flags.E) goto L05b7;
			goto L049a;

		L05b7:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), 0x0);
			if (this.oCPU.Flags.L) goto L05cc;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, param1);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)));
			if (this.oCPU.Flags.G) goto L05cc;
			this.oCPU.AX.Word = 0;
			goto L0624;

		L05cc:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), 0x0);
			if (this.oCPU.Flags.L) goto L060b;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe17c), 0x3);
			if (this.oCPU.Flags.E) goto L05eb;

			// Instruction address 0x0000:0x05e3, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(3, 1);

		L05eb:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.ES.Word = 0x3772; // segment
			F8_0000_062a(this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x1c80)),
				this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x36fc)));
			
			goto L061c;

		L060b:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)), 0x0);
			if (this.oCPU.Flags.E) goto L0616;
			this.oCPU.AX.Word = 0xfffe;
			goto L0619;

		L0616:
			this.oCPU.AX.Word = 0xffff;

		L0619:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), this.oCPU.AX.Word);

		L061c:
			// Instruction address 0x0000:0x061c, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));

		L0624:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F8_0000_0066");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="technologyID"></param>
		/// <param name="param2"></param>
		public void F8_0000_062a(ushort technologyID, ushort param2)
		{
			this.oCPU.Log.EnterBlock($"F8_0000_062a({technologyID}, {param2})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x34);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Low = (byte)param2;
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x3fa9, this.oCPU.AX.Low);

			// Instruction address 0x0000:0x063a, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x063f, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0xffff);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe17c), 0x3);
			if (this.oCPU.Flags.E) goto L066d;

			// Instruction address 0x0000:0x0658, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(3, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L066d;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3c62, 0x1);

		L066d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0xf);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L069e;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3c62), 0x0);
			if (this.oCPU.Flags.E) goto L0687;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0xff);
			goto L069e;

		L0687:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0xfd);

			// Instruction address 0x0000:0x0696, size: 5
			this.oParent.VGADriver.SetColor(0xfd, VGABitmap.Color18ToColor(0x3d, 0x3d, 0x3d));

		L069e:
			// Instruction address 0x0000:0x06b1, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			// Instruction address 0x0000:0x06b9, size: 5
			this.oParent.Segment_1866.F0_1866_260e();

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x7);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), 0xcc);
			this.oCPU.CMPWord(param2, 0x2);
			if (this.oCPU.Flags.NE) goto L06dc;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), 0xe0);

		L06dc:
			this.oCPU.CMPWord(param2, 0x4);
			if (this.oCPU.Flags.E) goto L06f5;
			this.oCPU.CMPWord(param2, 0x1);
			if (this.oCPU.Flags.NE) goto L06ee;
			this.oCPU.CMPWord(technologyID, 0x18);
			if (this.oCPU.Flags.G) goto L06f5;

		L06ee:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3c62), 0x0);
			if (this.oCPU.Flags.E) goto L06fa;

		L06f5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), 0xa0);

		L06fa:
			this.oCPU.AX.Word = param2;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0724;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L0709;
			goto L08ea;

		L0709:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L0711;
			goto L09d8;

		L0711:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L0719;
			goto L0aac;

		L0719:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4);
			if (this.oCPU.Flags.NE) goto L0721;
			goto L0b8f;

		L0721:
			goto L07e2;

		L0724:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3c62), 0x0);
			if (this.oCPU.Flags.E) goto L072e;
			goto L07b5;

		L072e:
			F8_0000_16c4(technologyID);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0743, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3cda);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x9;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba0c, this.oCPU.ADDByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba0c), this.oCPU.AX.Low));

			// Instruction address 0x0000:0x0760, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0xba06, 0);

			// Instruction address 0x0000:0x076c, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_047d_ReadAndSetPalette(0x3ce6);

			F8_0000_16f7(
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)) % 3) * 111) + 1),
				(ushort)((((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)) % 9) / 3) * 69) + 1),
				110, 68, 62, 42);

		L07b5:
			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x07c3, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x07da, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0x3cf2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 36, 7);

		L07e2:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x6);

			// Instruction address 0x0000:0x07f9, size: 5
			this.oParent.MSCAPI.strupr(0xba06);

			// Instruction address 0x0000:0x0802, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 20, 0);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x7);

			// Instruction address 0x0000:0x081b, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x2c), OpenCiv1.String_3d99);

			// Instruction address 0x0000:0x082b, size: 5
			this.oParent.MSCAPI.strcat((ushort)(this.oCPU.BP.Word - 0x2c), 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x4c);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x0);
			if (this.oCPU.Flags.NE) goto L0846;
			goto L08e4;

		L0846:
			this.oCPU.TESTByte((byte)(this.oParent.GameState.GameSettingFlags & 0xff), 0x40);
			if (this.oCPU.Flags.E) goto L089c;

			// Instruction address 0x0000:0x0855, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_01ad(0x3fa4, (ushort)(this.oCPU.BP.Word - 0x2c));

			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L089c;

			// Instruction address 0x0000:0x0870, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_0088_DrawTextBlock(37, 12, 76, 1);

			// Instruction address 0x0000:0x0878, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Instruction address 0x0000:0x0894, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 8, 76, 304, 116,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

		L089c:
			// Instruction address 0x0000:0x08a4, size: 5
			this.oParent.MSCAPI.strcat((ushort)(this.oCPU.BP.Word - 0x2c), OpenCiv1.String_3d9b);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.CMPWord(param2, 0x0);
			if (this.oCPU.Flags.E) goto L08e4;

			// Instruction address 0x0000:0x08bf, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_01ad(0x3fa4, (ushort)(this.oCPU.BP.Word - 0x2c));

			// Instruction address 0x0000:0x08d6, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_0088_DrawTextBlock(36, 12, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 1);

			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

		L08e4:
			this.oCPU.AX.Word = param2;
			goto L1636;

		L08ea:
			// Instruction address 0x0000:0x08f2, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(1, 0);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0904;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3c62, 0x1);

		L0904:
			this.oCPU.CMPWord(technologyID, 0x1);
			if (this.oCPU.Flags.G) goto L090d;
			goto L09a5;

		L090d:
			this.oCPU.CMPWord(technologyID, 0x15);
			if (this.oCPU.Flags.LE) goto L0916;
			goto L09a5;

		L0916:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3c62), 0x0);
			if (this.oCPU.Flags.E) goto L0920;
			goto L09a5;

		L0920:
			// Instruction address 0x0000:0x0928, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x3d07, 0);

			// Instruction address 0x0000:0x0934, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_047d_ReadAndSetPalette(0x3d14);

			this.oCPU.SI.Word = technologyID;
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, 0x2);
			
			// Instruction address 0x0000:0x0973, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.SI.Word >> 2) * 0x32) + 1),
				(ushort)(((this.oCPU.SI.Word & 3) * 0x32) + 1),
				0x31, 0x31);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0992, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				37, 17,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			// Instruction address 0x0000:0x099d, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0);

		L09a5:
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xb9a);
			// Instruction address 0x0000:0x09b3, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			this.oCPU.CMPWord(technologyID, 0x18);
			if (this.oCPU.Flags.G)
			{
				// Instruction address 0x0000:0x07da, size: 5
				this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0x3d2e, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 36, 7);
			}
			else
			{
				// Instruction address 0x0000:0x07da, size: 5
				this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0x3d1d, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 36, 7);
			}

			goto L07e2;

		L09d8:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3c62), 0x0);
			if (this.oCPU.Flags.E) goto L09e2;
			goto L0a62;

		L09e2:
			F8_0000_1790(technologyID);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x09f7, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3d42);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x6;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba0c, this.oCPU.ADDByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba0c), this.oCPU.AX.Low));

			// Instruction address 0x0000:0x0a14, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0xba06, 0);

			// Instruction address 0x0000:0x0a20, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_047d_ReadAndSetPalette(0x3d4e);

			F8_0000_16f7(
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)) & 1) * 160) + 1),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)) % 6) >> 1) * 61),
				158, 61, 88, 42);

		L0a62:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x112a);
			// Instruction address 0x0000:0x0a70, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0a87, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0x3d5a, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 36, 7);

			// Instruction address 0x0000:0x0aa4, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				216, 48,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((technologyID << 1) + 0xd58e)));
			goto L07e2;

		L0aac:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3c62), 0x0);
			if (this.oCPU.Flags.E) goto L0ab6;
			goto L0b68;

		L0ab6:
			F8_0000_17c3(technologyID);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0acb, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3d68);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x6;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba0d, this.oCPU.ADDByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba0d), this.oCPU.AX.Low));

			// Instruction address 0x0000:0x0ae8, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0xba06, 0);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0b25;

			// Instruction address 0x0000:0x0aff, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x3d75, 0xc5be);

			// Instruction address 0x0000:0x0b0b, size: 5
			this.oParent.VGADriver.F0_VGA_0162_SetColorsFromColorStruct(0xc5be);
			
			// Instruction address 0x0000:0x0b1d, size: 5
			this.oParent.VGADriver.SetColor(0xfd, VGABitmap.Color18ToColor(0x3d, 0x3d, 0x3d));

		L0b25:
			F8_0000_16f7(
				(ushort)(((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)) % 3) * 107) + 1),
				(ushort)((((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)) % 6) / 3) * 87) + 5),
				106, 77, 76, 46);

		L0b68:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0);
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x282);
			// Instruction address 0x0000:0x0b76, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word); // !!! was strcat

			// Instruction address 0x0000:0x07da, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0x3d7f, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 36, 7);

			goto L07e2;

		L0b8f:
			this.oCPU.BX.Word = technologyID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0b9c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x3c64)));

			// Instruction address 0x0000:0x07da, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0x3d8c, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 36, 7);

			goto L07e2;

		L0bb5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x4ee);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word), 0xff);
			if (this.oCPU.Flags.E) goto L0bf3;

			// Instruction address 0x0000:0x0bd7, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3d9d);

			this.oCPU.AX.Low = 0x16;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x0beb, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

		L0bf3:
			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x4ef);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word), 0xff);
			if (this.oCPU.Flags.E) goto L0c28;

			// Instruction address 0x0000:0x0c0c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3da7);

			this.oCPU.AX.Low = 0x16;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x0c20, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

		L0c28:
			// Instruction address 0x0000:0x0c37, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 32, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x10));

			// Instruction address 0x0000:0x0c52, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x3dad, 32, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x0);

		L0c69:
			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4ee));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, technologyID);
			if (this.oCPU.Flags.NE) goto L0ce5;

			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x0c85, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4ef)), 0xff);
			if (this.oCPU.Flags.E) goto L0cca;

			// Instruction address 0x0000:0x0c9c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3db6);

			this.oCPU.AX.Low = 0x16;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4ef)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x0cb2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0cc2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3dbe);

		L0cca:
			// Instruction address 0x0000:0x0cd9, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 40, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));

		L0ce5:
			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4ef));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, technologyID);
			if (this.oCPU.Flags.NE) goto L0d61;

			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x0d01, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4ee)), 0xff);
			if (this.oCPU.Flags.E) goto L0d46;

			// Instruction address 0x0000:0x0d18, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3dc0);

			this.oCPU.AX.Low = 0x16;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4ee)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x0d2e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0d3e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3dc8);

		L0d46:
			// Instruction address 0x0000:0x0d55, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 40, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));

		L0d61:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x48);
			if (this.oCPU.Flags.GE) goto L0d6d;
			goto L0c69;

		L0d6d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x0);

		L0d76:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = technologyID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x114a)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0de8;

			// Instruction address 0x0000:0x0da3, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				40,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) - 4,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)((((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)) +
					(this.oParent.GameState.HumanPlayerID << 5)) + 0x40) << 1) + 0xd4ce)));

			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x112a);
			// Instruction address 0x0000:0x0db5, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0dc5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3dca);

			// Instruction address 0x0000:0x0ddc, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 60, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 12);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xc));

		L0de8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x1c);
			if (this.oCPU.Flags.L) goto L0d76;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x1);
			goto L0e26;

		L0df8:
			this.oCPU.AX.Word = 0x3ddd;

		L0dfb:
			// Instruction address 0x0000:0x0e00, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0e17, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 60, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 2);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xc));

		L0e23:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))));

		L0e26:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x2d);
			if (this.oCPU.Flags.G) goto L0e6f;
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = technologyID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xbb6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0e23;

			// Instruction address 0x0000:0x0e4a, size: 5
			this.oParent.Segment_1d12.F0_1d12_7045(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)),
				40, (short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) - 2));

			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xb9a);
			// Instruction address 0x0000:0x0e5c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x18);
			if (this.oCPU.Flags.G) goto L0df8;
			this.oCPU.AX.Word = 0x3dd0;
			goto L0dfb;

		L0e6f:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			if (this.oCPU.Flags.NE) goto L0e94;

			// Instruction address 0x0000:0x0e8c, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x3de5, 
				32, 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) - 12,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

		L0e94:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].TechnologyAcquiredFrom[technologyID];
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xfffe);
			if (this.oCPU.Flags.E) goto L0f01;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L0f2b;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0f32;

			// Instruction address 0x0000:0x0ec0, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3e10);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].TechnologyAcquiredFrom[technologyID];
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0eea, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			// Instruction address 0x0000:0x0efa, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3e1d);
			goto L0f11;

		L0f01:
			this.oCPU.AX.Word = 0x3dee;

		L0f04:
			// Instruction address 0x0000:0x0f09, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

		L0f11:
			// Instruction address 0x0000:0x0f20, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 48, 7);

			goto L1655;

		L0f2b:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			goto L0f11;

		L0f32:
			this.oCPU.AX.Word = 0x3e03;
			goto L0f04;

		L0f37:
			// Instruction address 0x0000:0x0f3f, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3e1f);

			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xbb6)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x0f5e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0f75, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 12, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));

			// Instruction address 0x0000:0x0f89, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3e29);

			// Instruction address 0x0000:0x0fae, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)(0xa * (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xbb2))), 10));

			// Instruction address 0x0000:0x0fbe, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3e30);

			// Instruction address 0x0000:0x0fd5, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 12, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));

			// Instruction address 0x0000:0x0fe9, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3e3a);

			// Instruction address 0x0000:0x100a, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xbb4)), 10));

		L1005:
			// Instruction address 0x0000:0x101e, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 12, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 12);

		L1019:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));
			goto L1655;

		L102d:
			// Instruction address 0x0000:0x1035, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3e49);

			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x114a)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x1054, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			this.oCPU.CMPWord(technologyID, 0x19);
			if (this.oCPU.Flags.NE) goto L1072;

			// Instruction address 0x0000:0x106a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3e53);

		L1072:
			// Instruction address 0x0000:0x1081, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));

			// Instruction address 0x0000:0x1095, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3e68);

			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x10c2, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)(0xa * (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1142))), 10));

			// Instruction address 0x0000:0x10d2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3e6f);

			// Instruction address 0x0000:0x10e9, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));

			// Instruction address 0x0000:0x10fd, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3e7b);

			// Instruction address 0x0000:0x111e, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x113e)), 10));

			// Instruction address 0x0000:0x1135, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 12);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));

			// Instruction address 0x0000:0x1149, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3e8d);

			// Instruction address 0x0000:0x116a, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1140)), 10));

			// Instruction address 0x0000:0x1181, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 12);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));

			// Instruction address 0x0000:0x1195, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3ea0);

			// Instruction address 0x0000:0x11b6, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x113a)), 10));

			// Instruction address 0x0000:0x101e, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0);

			goto L1019;

		L11ca:
			this.oCPU.AX.Word = technologyID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			goto L1552;

		L11d3:
			this.oCPU.AX.Word = technologyID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L11ed;
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x290)), 0x2);
			if (this.oCPU.Flags.NE) goto L11ed;
			goto L154e;

		L11ed:
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x1206, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(
				(ushort)(this.oCPU.SI.Word + 0x282), 12, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x290)), 0x0);
			if (this.oCPU.Flags.NE) goto L122b;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x44a)), 0xffff);
			if (this.oCPU.Flags.L) goto L122b;
			goto L131e;

		L122b:
			// Instruction address 0x0000:0x1233, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3eb0);

			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x290);

			// Instruction address 0x0000:0x1260, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((sbyte)this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word), 10));

			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word), 0x3);
			if (this.oCPU.Flags.L) goto L127d;

			// Instruction address 0x0000:0x1275, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3eb7);

		L127d:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x44a);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word), 0xffff);
			if (this.oCPU.Flags.GE) goto L12f3;

			// Instruction address 0x0000:0x1296, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3eb9);

			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x290);

			// Instruction address 0x0000:0x12c6, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)((sbyte)this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.DI.Word)) -
					(short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word) - 1), 10));

			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.DI.Word), 0x2);
			if (this.oCPU.Flags.L) goto L12e3;

			// Instruction address 0x0000:0x12db, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3ebc);

		L12e3:
			// Instruction address 0x0000:0x12eb, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3ebe);

		L12f3:
			// Instruction address 0x0000:0x12fb, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3ed0);

			// Instruction address 0x0000:0x1312, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));

		L131e:
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x291)), 0x0);
			if (this.oCPU.Flags.NE) goto L133f;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x44e)), 0xffff);
			if (this.oCPU.Flags.L) goto L133f;
			goto L1433;

		L133f:
			// Instruction address 0x0000:0x1347, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3ed8);

			this.oCPU.CMPWord(technologyID, 0x2);
			if (this.oCPU.Flags.E) goto L135b;
			this.oCPU.CMPWord(technologyID, 0xb);
			if (this.oCPU.Flags.NE) goto L136b;

		L135b:
			// Instruction address 0x0000:0x1363, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3ee5);

		L136b:
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x291);

			// Instruction address 0x0000:0x1390, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((sbyte)this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word), 10));

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x44e);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.DI.Word), 0xffff);
			if (this.oCPU.Flags.GE) goto L1408;

			// Instruction address 0x0000:0x13b1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3ee8);

			// Instruction address 0x0000:0x13d5, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)((sbyte)this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word)) -
						(short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.DI.Word) - 1), 10));

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.DI.Word));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.L) goto L13f8;

			// Instruction address 0x0000:0x13f0, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3eeb);

		L13f8:
			// Instruction address 0x0000:0x1400, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3eed);

		L1408:
			// Instruction address 0x0000:0x1410, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3efb);

			// Instruction address 0x0000:0x1427, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));

		L1433:
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x292)), 0x0);
			if (this.oCPU.Flags.NE) goto L144b;
			this.oCPU.CMPWord(technologyID, 0x2);
			if (this.oCPU.Flags.LE) goto L144b;
			goto L1529;

		L144b:
			// Instruction address 0x0000:0x1453, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3f03);

			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x292);

			// Instruction address 0x0000:0x1480, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((sbyte)this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word), 10));

			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word), 0x0);
			if (this.oCPU.Flags.E) goto L149d;

			// Instruction address 0x0000:0x1495, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3f0b);

		L149d:
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x292)), 0x3);
			if (this.oCPU.Flags.L) goto L14bc;

			// Instruction address 0x0000:0x14b4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3f0d);

		L14bc:
			this.oCPU.CMPWord(technologyID, 0x2);
			if (this.oCPU.Flags.G) goto L150e;

			// Instruction address 0x0000:0x14ca, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3f0f);

			// Instruction address 0x0000:0x14f6, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)((sbyte)this.oCPU.ReadUInt8(this.oCPU.DS.Word,
					(ushort)(0x13 * (short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + 0x292))) + 1), 10));

			// Instruction address 0x0000:0x1506, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3f12);

		L150e:
			// Instruction address 0x0000:0x151d, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));

		L1529:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x7);
			if (this.oCPU.Flags.NE) goto L154a;

			// Instruction address 0x0000:0x153e, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x3f20, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));

		L154a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x4));

		L154e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xc));

		L1552:
			this.oCPU.AX.Word = technologyID;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xc);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.L) goto L1560;
			goto L11d3;

		L1560:
			// Instruction address 0x0000:0x156f, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x3f28, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));

			// Instruction address 0x0000:0x158a, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x3f52, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xc));

			// Instruction address 0x0000:0x159e, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3f7d);

			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, technologyID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x15c9, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((sbyte)this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x28e)), 10));

			// Instruction address 0x0000:0x15d9, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3f8d);

			// Instruction address 0x0000:0x15ed, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 12, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 12);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8));

			// Instruction address 0x0000:0x1601, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3f91);

			// Instruction address 0x0000:0x1628, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((0x32 * (short)((sbyte)this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x28f)))) - 0x64),
					10));

			// Instruction address 0x0000:0x100a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3fa2);
			goto L1005;

		L1636:
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L163d;
			goto L0bb5;

		L163d:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L1645;
			goto L0f37;

		L1645:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L164d;
			goto L102d;

		L164d:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L1655;
			goto L11ca;

		L1655:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x1);

			// Instruction address 0x0000:0x165e, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x1663, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Instruction address 0x0000:0x1668, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L168b;
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L168b;

			// Instruction address 0x0000:0x1683, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

		L168b:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3c62, 0x0);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3934), 0xffff);
			if (this.oCPU.Flags.NE) goto L16b9;

			// Instruction address 0x0000:0x16ac, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 8, 8, 304, 184,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			// Instruction address 0x0000:0x16b4, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0626();

		L16b9:
			// Instruction address 0x0000:0x16b9, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F8_0000_062a");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="technologyID"></param>
		/// <returns></returns>
		public ushort F8_0000_16c4(ushort technologyID)
		{
			this.oCPU.Log.EnterBlock($"F8_0000_16c4({technologyID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L16d4;

		L16d1:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L16d4:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x48);
			if (this.oCPU.Flags.GE) goto L16f0;

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.ES.Word = 0x371e; // segment
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, technologyID);
			if (this.oCPU.Flags.NE) goto L16d1;

			this.oCPU.AX.Word = this.oCPU.BX.Word;
			goto L16f3;

		L16f0:
			this.oCPU.AX.Word = 0xffff;

		L16f3:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F8_0000_16c4");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		/// <param name="param4"></param>
		/// <param name="param5"></param>
		/// <param name="param6"></param>
		public void F8_0000_16f7(ushort param1, ushort param2, ushort param3, ushort param4, ushort param5, ushort param6)
		{
			this.oCPU.Log.EnterBlock($"F8_0000_16f7({param1}, {param2}, {param3}, {param4}, {param5}, {param6})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = param1;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, param3);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x13f);
			if (this.oCPU.Flags.LE) goto L171a;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x13f);
			this.oCPU.AX.Word = 0x13f;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, param1);
			param3 = this.oCPU.AX.Word;

		L171a:
			this.oCPU.AX.Word = param2;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, param4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xc7);
			if (this.oCPU.Flags.LE) goto L1736;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0xc7);
			this.oCPU.AX.Word = 0xc7;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, param2);
			param4 = this.oCPU.AX.Word;

		L1736:
			this.oCPU.AX.Word = param3;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(param5, this.oCPU.SI.Word);
			if (this.oCPU.Flags.GE) goto L1753;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, param5);
			param1 += this.oCPU.AX.Word;
			this.oCPU.AX.Word = param5;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			param3 = this.oCPU.AX.Word;

		L1753:
			// Instruction address 0x0000:0x1783, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				param1,
				param2,
				param3,
				param4,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(ushort)(param5 - (param3 >> 1)),
				(ushort)(param6 - (param4 >> 1)));

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F8_0000_16f7");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="technologyID"></param>
		/// <returns></returns>
		public ushort F8_0000_1790(ushort technologyID)
		{
			this.oCPU.Log.EnterBlock($"F8_0000_1790({technologyID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L17a0;

		L179d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L17a0:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x1c);
			if (this.oCPU.Flags.GE) goto L17bc;

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.ES.Word = 0x371e; // segment
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x44));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, technologyID);
			if (this.oCPU.Flags.NE) goto L179d;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			goto L17bf;

		L17bc:
			this.oCPU.AX.Word = 0xffff;

		L17bf:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F8_0000_1790");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="technologyID"></param>
		/// <returns></returns>
		public ushort F8_0000_17c3(ushort technologyID)
		{
			this.oCPU.Log.EnterBlock($"F8_0000_17c3({technologyID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L17d3;

		L17d0:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L17d3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xc);
			if (this.oCPU.Flags.GE) goto L17ef;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.ES.Word = 0x371e; // segment
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x61));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, technologyID);
			if (this.oCPU.Flags.NE) goto L17d0;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			goto L17f2;

		L17ef:
			this.oCPU.AX.Word = 0xffff;

		L17f2:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F8_0000_17c3");

			return this.oCPU.AX.Word;
		}
	}
}
