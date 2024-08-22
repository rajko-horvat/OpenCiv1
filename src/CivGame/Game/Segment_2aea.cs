using System;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class Segment_2aea
	{
		private CivGame oParent;
		private VCPU oCPU;
		private CivStateData oGameData;
		private CivStaticData oStaticGameData;

		public Segment_2aea(CivGame parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
			this.oStaticGameData = parent.StaticGameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_0008(short playerID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_0008({playerID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x1c);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x2aea:0x000f, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x1ae0, 0x0);

			// Instruction address 0x2aea:0x001a, size: 5
			this.oParent.Segment_1238.F0_1238_0fea();

			// Instruction address 0x2aea:0x001f, size: 5
			this.oParent.Segment_1238.F0_1238_107e();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd20a));

			// Instruction address 0x2aea:0x002d, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(xPos);

			this.oParent.Var_d4cc_XPos = (short)this.oCPU.AX.Word;

			// Instruction address 0x2aea:0x0042, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(yPos, 0, 38);
			this.oParent.Var_d75e_YPos = (short)this.oCPU.AX.Word;

			// Another error, the code modified first parameter (playerID) to a
			// Visibility Mask and that conflicts with other code which expects playerID.
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			ushort usMapVisibilityMask = this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6c96, 0x0);

			// Instruction address 0x2aea:0x0062, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(256));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			goto L00ac;

		L0074:
			// Instruction address 0x2aea:0x0094, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)) * 16) + 80,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) * 16) + 8,
				16, 16, 0);

		L009c:
			this.oCPU.AX.Word = 0x5;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.AX.Low = this.oCPU.INC_UInt8(this.oCPU.AX.Low);
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L00ac:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x100);
			if (this.oCPU.Flags.GE) goto L012b;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0xf);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xc);
			if (this.oCPU.Flags.GE) goto L009c;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xf);
			if (this.oCPU.Flags.GE) goto L009c;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L0108;

			// Instruction address 0x2aea:0x00e0, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)) + this.oParent.Var_d4cc_XPos);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));
			this.oCPU.BX.Word = this.oCPU.ADD_UInt16(this.oCPU.BX.Word, (ushort)this.oParent.Var_d75e_YPos);

			this.oCPU.AX.Word = (ushort)this.oGameData.Map[this.oCPU.AX.Word, this.oCPU.BX.Word].Visibility;
			
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, usMapVisibilityMask);
			if (this.oCPU.Flags.NE) goto L0108;
			goto L0074;

		L0108:
			// Instruction address 0x2aea:0x0118, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)) + this.oParent.Var_d4cc_XPos);

			// Instruction address 0x2aea:0x0122, size: 3
			F0_2aea_11d4((short)this.oCPU.AX.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) + this.oParent.Var_d75e_YPos);

			goto L009c;

		L012b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			goto L0198;

		L0132:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6e3e)), 0xb8);
			if (this.oCPU.Flags.GE) goto L0195;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			
			// Instruction address 0x2aea:0x0148, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xdf20)));
			
			// Instruction address 0x2aea:0x015c, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06,
				(ushort)(327 - this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6dac))));

			// Instruction address 0x2aea:0x018d, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(0xba06,
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6dac)) - 8, 80, 999),
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6e3e)) + 16,
				11);

		L0195:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L0198:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c96);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0132;
			this.oCPU.AX.Word = (ushort)xPos;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x20);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)yPos;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x13);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

			// Instruction address 0x2aea:0x01b9, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Navigation);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);
			}
		
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x0);
			if (this.oCPU.Flags.L) goto L01d5;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			goto L01db;

		L01d5:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x50);

		L01db:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x50);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L01ea;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word));

		L01ea:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L01f3;
			this.oCPU.AX.Word = 0;

		L01f3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x32;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x0);
			if (this.oCPU.Flags.LE) goto L0211;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), this.oCPU.AX.Word));

		L0211:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6ed6, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x70ea, this.oCPU.AX.Word);

			// Instruction address 0x2aea:0x0233, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 8, 80, 50, 0);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE)
			{
				// Instruction address 0x2aea:0x024c, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0, 16);

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6ed6, this.oCPU.AX.Word);

				// Instruction address 0x2aea:0x0264, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0, 65530);

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x70ea, this.oCPU.AX.Word);

				// Instruction address 0x2aea:0x02da, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
					80, 50, this.oParent.Var_aa_Rectangle, 0, 8);
			}
			else
			{
				// Instruction address 0x2aea:0x02af, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)) + 240,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
					this.oParent.Var_aa_Rectangle, 0, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) + 8);

				this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x50);
				if (this.oCPU.Flags.B)
				{
					// Instruction address 0x2aea:0x02da, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
						240, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)),
						80 - this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
						this.oParent.Var_aa_Rectangle,
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) + 8);
				}
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L02e7:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8(this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L035b;
			this.oCPU.CMP_UInt8((byte)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].VisibleSize, 0x0);
			if (this.oCPU.Flags.NE) goto L0308;

			if (this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].PlayerID != this.oGameData.HumanPlayerID)
				goto L035b;

		L0308:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x2aea:0x031a, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].Position.X -
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)((short)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].Position.Y);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)));
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L035b;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x32);
			if (this.oCPU.Flags.GE) goto L035b;

			this.oCPU.BX.Word = (ushort)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].PlayerID;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x2aea:0x0355, size: 3
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) + 8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1946)));

		L035b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x80);
			if (this.oCPU.Flags.L) goto L02e7;

			// Instruction address 0x2aea:0x037c, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a66_DrawShadowRectangle(0, 8, 79, 49, 15, 8);

			// Instruction address 0x2aea:0x03a2, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(
				xPos - this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) - 1,
				yPos - this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) + 7,
				17, 10, 15);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd20a, this.oCPU.AX.Word);

			// Instruction address 0x2aea:0x03b0, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_0008");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2aea_03ba(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_03ba({xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x26);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb278), 0x1);
			if (this.oCPU.Flags.NE) goto L0430;

			// Instruction address 0x2aea:0x03d0, size: 3
			F0_2aea_1585_GetImprovements(xPos, yPos);

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L0413;

			// Instruction address 0x2aea:0x03e1, size: 3
			F0_2aea_1369(xPos, yPos);

			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x2aea:0x0408, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos * 4, yPos * 4, 4, 4,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1946)));

			goto L0e23;

		L0413:
			// Instruction address 0x2aea:0x041a, size: 3
			if (F0_2aea_134a_GetMapLayer1_TerrainType(xPos, yPos) != TerrainTypeEnum.Water) goto L042a;
			
			// Instruction address 0x2aea:0x0408, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos * 4, yPos * 4, 4, 4, 1);

			goto L0e23;

		L042a:
			this.oCPU.AX.Word = 0x2;
			// Instruction address 0x2aea:0x0408, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos * 4, yPos * 4, 4, 4, 2);

			goto L0e23;

		L0430:
			// Instruction address 0x2aea:0x0438, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(xPos - this.oParent.Var_d4cc_XPos);

			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x50);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)yPos;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.Var_d75e_YPos);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x50);
			if (this.oCPU.Flags.L) goto L0470;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x140);
			if (this.oCPU.Flags.GE) goto L0470;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.L) goto L0470;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xc0);
			if (this.oCPU.Flags.LE) goto L0475;

		L0470:
			this.oCPU.AX.Word = 0;
			goto L0e23;

		L0475:
			// Instruction address 0x2aea:0x047c, size: 3
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), (ushort)((short)F0_2aea_134a_GetMapLayer1_TerrainType(xPos, yPos)));

			// Instruction address 0x2aea:0x048c, size: 3
			F0_2aea_15c1_GetVisibleImprovements(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.E) goto L04ac;

			// Instruction address 0x2aea:0x04a3, size: 3
			F0_2aea_1585_GetImprovements(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);

		L04ac:
			// Instruction address 0x2aea:0x04ac, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xa);
			if (this.oCPU.Flags.E) goto L04ba;
			goto L0789;

		L04ba:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);
			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L04c9;
			goto L0549;

		L04c9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);

		L04ce:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.SAR_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x1));
			
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			GPoint direction = this.oStaticGameData.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))];

			// Instruction address 0x2aea:0x04e6, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(xPos + direction.X);

			// Instruction address 0x2aea:0x04f0, size: 3
			if (F0_2aea_134a_GetMapLayer1_TerrainType((short)this.oCPU.AX.Word, yPos + direction.Y) == TerrainTypeEnum.Water) goto L0515;

			// Instruction address 0x2aea:0x0507, size: 3
			F0_2aea_1326_CheckMapBounds(0, yPos + direction.Y);

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0515;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x8));

		L0515:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x2));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x9);
			if (this.oCPU.Flags.L) goto L04ce;

			// Instruction address 0x2aea:0x053e, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19fc_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) << 4, 64, 16, 16,
				this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			goto L0789;

		L0549:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);

		L054e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.SAR_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x1));
			
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			direction = this.oStaticGameData.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))];

			// Instruction address 0x2aea:0x0566, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(xPos + direction.X);

			// Instruction address 0x2aea:0x0570, size: 3
			if (F0_2aea_134a_GetMapLayer1_TerrainType((short)this.oCPU.AX.Word, yPos + direction.Y) == TerrainTypeEnum.Water) goto L0595;

			// Instruction address 0x2aea:0x0587, size: 3
			F0_2aea_1326_CheckMapBounds(0, yPos + direction.Y);

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0595;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x80));

		L0595:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x9);
			if (this.oCPU.Flags.L) goto L054e;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.CX.Low = 0x6;
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0x3);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.CX.Word = this.oCPU.SHL_UInt16(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHL_UInt16(this.oCPU.CX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);
			goto L05ff;

		L05be:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.CX.Low = this.oCPU.SHL_UInt8(this.oCPU.CX.Low, 0x1);
			this.oCPU.SI.Word = this.oCPU.SAR_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.AND_UInt16(this.oCPU.SI.Word, 0x7);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.PUSH_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xd294)));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x8);
			this.oCPU.PUSH_UInt16(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.DX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.DX.Word = this.oCPU.AND_UInt16(this.oCPU.DX.Word, 0x1);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x8);

		L05ef:
			// Instruction address 0x2aea:0x05f4, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				(short)this.oCPU.AX.Word, (short)this.oCPU.POP_UInt16(), this.oCPU.POP_UInt16());

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

		L05ff:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x4);
			if (this.oCPU.Flags.GE) goto L0635;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x2);
			if (this.oCPU.Flags.GE) goto L05be;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.CX.Low = this.oCPU.SHL_UInt8(this.oCPU.CX.Low, 0x1);
			this.oCPU.SI.Word = this.oCPU.SAR_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.AND_UInt16(this.oCPU.SI.Word, 0x7);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.PUSH_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xd294)));
			this.oCPU.PUSH_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			goto L05ef;

		L0635:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x1c);
			if (this.oCPU.Flags.NE) goto L065e;

			// Instruction address 0x2aea:0x0656, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
				224, 100, 16, 16, this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

		L065e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xc1);
			if (this.oCPU.Flags.NE) goto L0688;

			// Instruction address 0x2aea:0x0680, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
				240, 100, 16, 16, this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

		L0688:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x7);
			if (this.oCPU.Flags.NE) goto L06b1;

			// Instruction address 0x2aea:0x06a9, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
				256, 100, 16, 16, this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

		L06b1:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x70);
			if (this.oCPU.Flags.NE) goto L06da;

			// Instruction address 0x2aea:0x06d2, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
				272, 100, 16, 16, this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

		L06da:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x8f);
			if (this.oCPU.Flags.NE) goto L0704;

			// Instruction address 0x2aea:0x06fc, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
				288, 100, 16, 16, this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

		L0704:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xf8);
			if (this.oCPU.Flags.NE) goto L072e;

			// Instruction address 0x2aea:0x0726, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
				304, 100, 16, 16, this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

		L072e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);

		L0733:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			direction = this.oStaticGameData.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))];

			// Instruction address 0x2aea:0x0748, size: 5
			// Instruction address 0x2aea:0x0752, size: 3
			if (F0_2aea_134a_GetMapLayer1_TerrainType(this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(xPos + direction.X), yPos + direction.Y) != TerrainTypeEnum.River) goto L077f;
			
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x2aea:0x0777, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd2d4)));

		L077f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x2));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x9);
			if (this.oCPU.Flags.L) goto L0733;

		L0789:
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)) != 0xa)
			{
				if (this.oParent.Var_d762 == 0x0)
				{
					// Instruction address 0x2aea:0x07cd, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19fc_Rectangle, 0, 80, 16, 16, this.oParent.Var_aa_Rectangle,
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
				}
				else
				{
					// Instruction address 0x2aea:0x07cd, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
						256, 120, 16, 16, this.oParent.Var_aa_Rectangle,
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
				}
			}
			
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x2);
			if (this.oCPU.Flags.E) goto L0800;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xa);
			if (this.oCPU.Flags.E) goto L0800;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdcfc), 0x0);
			if (this.oCPU.Flags.NE) goto L0800;
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x1);
			if (this.oCPU.Flags.NE) goto L0800;

			// Instruction address 0x2aea:0x07f8, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((4 << 1) + 0xd4ce)));

		L0800:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xb);
			if (this.oCPU.Flags.E) goto L0809;
			goto L088d;

		L0809:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);

		L0813:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 
				this.oCPU.SAR_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x1));

			direction = this.oStaticGameData.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))];

			// Instruction address 0x2aea:0x082c, size: 3
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				(ushort)((short)F0_2aea_134a_GetMapLayer1_TerrainType(this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(xPos + direction.X), yPos + direction.Y)));

			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) == 11) goto L083f;

			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) != 10) goto L0843;

		L083f:
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x8));

		L0843:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x2));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x9);
			if (this.oCPU.Flags.L) goto L0813;
			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L086e;

			// Instruction address 0x2aea:0x0862, size: 5
			//if ((this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150) & 0x8) == 0) goto L0872;
			if ((this.oGameData.Map[xPos, yPos].Layer7_TerrainImprovements2 & 0x8) == 0) goto L0872;

		L086e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x10));

		L0872:
			// Instruction address 0x2aea:0x0885, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) << 1) + 0x6dfe)));

		L088d:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xa);
			if (this.oCPU.Flags.NE) goto L0896;
			goto L099e;

		L0896:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xb);
			if (this.oCPU.Flags.NE) goto L089f;
			goto L099e;

		L089f:
			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.NE) goto L08a9;
			goto L0955;

		L08a9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);

		L08b3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.SAR_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x1));
			
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			direction = this.oStaticGameData.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))];

			// Instruction address 0x2aea:0x08ec, size: 3
			if (F0_2aea_1326_CheckMapBounds(0, yPos + direction.Y) == 0) goto L08fa;

			// Instruction address 0x2aea:0x08cb, size: 5
			// Instruction address 0x2aea:0x08d5, size: 3
			if ((int)F0_2aea_134a_GetMapLayer1_TerrainType(this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(xPos + direction.X), yPos + direction.Y) !=
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))) goto L08fa;

			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x8));

		L08fa:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x2));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x9);
			if (this.oCPU.Flags.L) goto L08b3;
			
			// Instruction address 0x2aea:0x091e, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) << 1) +
					(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)) << 5) + 0xb886)));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0x2);
			if (this.oCPU.Flags.NE) goto L099e;
			this.oCPU.AX.Word = 0x7;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)xPos);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xb;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)yPos);
			this.oCPU.CX.Low = this.oCPU.ADD_UInt8(this.oCPU.CX.Low, this.oCPU.AX.Low);
			this.oCPU.TEST_UInt8(this.oCPU.CX.Low, 0x2);
			if (this.oCPU.Flags.NE) goto L099e;
			this.oCPU.PUSH_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb880));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x4);
			this.oCPU.PUSH_UInt16(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x4);
			this.oCPU.PUSH_UInt16(this.oCPU.AX.Word);
			goto L0992;

		L0955:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0x2);
			if (this.oCPU.Flags.NE) goto L0976;
			this.oCPU.AX.Word = 0xb;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)yPos);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x7;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)xPos);
			this.oCPU.AX.Low = this.oCPU.ADD_UInt8(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.AX.High = 0;
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.AND_UInt16(this.oCPU.SI.Word, 0x2);
			this.oCPU.SI.Word = this.oCPU.SHR_UInt16(this.oCPU.SI.Word, 0x1);
			goto L097f;

		L0976:
			this.oCPU.SI.Word = (ushort)xPos;
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, (ushort)yPos);
			this.oCPU.SI.Word = this.oCPU.AND_UInt16(this.oCPU.SI.Word, 0x1);

		L097f:
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
			this.oCPU.CX.Low = 0x5;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.PUSH_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xb886)));
			this.oCPU.PUSH_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.PUSH_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

		L0992:
			// Instruction address 0x2aea:0x0996, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				(short)this.oCPU.POP_UInt16(), (short)this.oCPU.POP_UInt16(), this.oCPU.POP_UInt16());

		L099e:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x40);
			if (this.oCPU.Flags.NE) goto L09a7;
			goto L0a40;

		L09a7:
			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L09c6;

			// Instruction address 0x2aea:0x09bc, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4da));
			goto L0a40;

		L09c6:
			// Instruction address 0x2aea:0x09dc, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				16, 16, 2, 0);

			// Instruction address 0x2aea:0x09fb, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				16, 16, 10, 15);

			// Instruction address 0x2aea:0x0a1a, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				16, 16, 9, 8);

			// Instruction address 0x2aea:0x0a38, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				16, 16, 11, 0);

		L0a40:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x8);
			if (this.oCPU.Flags.NE) goto L0a49;
			goto L0ae8;

		L0a49:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x10);
			if (this.oCPU.Flags.E) goto L0a53;
			this.oCPU.AX.Word = 0;
			goto L0a56;

		L0a53:
			this.oCPU.AX.Word = 0x6;

		L0a56:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);
			goto L0a7e;

		L0a60:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.PUSH_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb278)));

		L0a69:
			// Instruction address 0x2aea:0x0a73, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.POP_UInt16());

		L0a7b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

		L0a7e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8);
			if (this.oCPU.Flags.G) goto L0ac0;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			direction = this.oStaticGameData.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))];

			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(xPos + direction.X);

			// Instruction address 0x2aea:0x0a9a, size: 3
			F0_2aea_15c1_GetVisibleImprovements((short)this.oCPU.AX.Word, yPos + direction.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Word);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), 0x8);
			if (this.oCPU.Flags.E) goto L0a7b;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), 0xffff);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x11);
			if (this.oCPU.Flags.E) goto L0a60;
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), 0x11);
			if (this.oCPU.Flags.E) goto L0a60;
			this.oCPU.PUSH_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb298)));
			goto L0a69;

		L0ac0:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0xffff);
			if (this.oCPU.Flags.E) goto L0ae8;

			// Instruction address 0x2aea:0x0ae0, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 7,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) + 7,
				2, 2,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));

		L0ae8:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x4);
			if (this.oCPU.Flags.E) goto L0b07;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdcfc), 0x0);
			if (this.oCPU.Flags.NE) goto L0b07;

			// Instruction address 0x2aea:0x0aff, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((5 << 1) + 0xd4ce)));

		L0b07:
			// Instruction address 0x2aea:0x0b11, size: 3
			if (this.oGameData.Map[xPos, yPos].HasSpecialResource)
			{
				// Instruction address 0x2aea:0x0b28, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
					this.oCPU.ReadUInt16(this.oCPU.DS.Word,
						(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)) + 0x10) << 1) + 0xd4ce)));
			}
		
			// Instruction address 0x2aea:0x0b3a, size: 3
			F0_2aea_1894(
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)),
				xPos, yPos);

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0b56;

			// Instruction address 0x2aea:0x0b4e, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x1f << 1) + 0xd4ce)));

		L0b56:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x20);
			if (this.oCPU.Flags.E) goto L0b6e;

			// Instruction address 0x2aea:0x0b66, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x1e << 1) + 0xd4ce)));

		L0b6e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L0be0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);

		L0b7a:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			direction = this.oStaticGameData.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))];

			// Instruction address 0x2aea:0x0b87, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(xPos + direction.X);

			int yTemp = (ushort)((short)(yPos + direction.Y));

			if (yTemp >= 0 && yTemp < 50)
			{
				this.oCPU.AX.Word = (ushort)this.oGameData.Map[(short)this.oCPU.AX.Word, yTemp].Visibility;
			}
			else
			{
				this.oCPU.AX.Word = 0;
			}
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oGameData.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L0bd6;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x2aea:0x0bce, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x7eec)));

		L0bd6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x2));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8);
			if (this.oCPU.Flags.LE) goto L0b7a;

		L0be0:
			// Instruction address 0x2aea:0x0be7, size: 3
			F0_2aea_1369(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.AX.Word);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x1);
			if (this.oCPU.Flags.NE) goto L0bf9;
			goto L0e1b;

		L0bf9:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdcfc), 0x0);
			if (this.oCPU.Flags.E) goto L0c03;
			goto L0e1b;

		L0c03:
			// Instruction address 0x2aea:0x0c09, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].PlayerID != this.oGameData.HumanPlayerID &&
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].VisibleSize == 0 && 
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806) == 0)
				goto L0e1b;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.DI.Word = this.oCPU.INC_UInt16(this.oCPU.DI.Word);

			// Instruction address 0x2aea:0x0c4b, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 1,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) + 1,
				13, 13, 15);

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
			this.oCPU.BX.Word = (ushort)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)) / 28].PlayerID;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			// Instruction address 0x2aea:0x0c7d, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) + 1,
				12, 12, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1956)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);

			this.oCPU.BX.Word = (ushort)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)) / 28].PlayerID;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x2aea:0x0cac, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				12, 12,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1946)));

			// Instruction address 0x2aea:0x0cba, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				(short)this.oCPU.DI.Word, (short)this.oCPU.SI.Word,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x1c << 1) + 0xd4ce)));

			this.oCPU.BX.Word = (ushort)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)) / 28].PlayerID;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			// Instruction address 0x2aea:0x0ce5, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				12, 12, 5,
				(byte)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1956)));

			if (this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].PlayerID == this.oGameData.HumanPlayerID)
				goto L0d07;
			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806) == 0)
				goto L0d15;

		L0d07:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].ActualSize;
			goto L0d21;

		L0d15:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].VisibleSize;

		L0d21:
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x2aea:0x0d42, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 10));

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
			this.oCPU.TEST_UInt8(this.oGameData.Cities[this.oCPU.BX.Word / 28].StatusFlag, 0x1);
			if (this.oCPU.Flags.E) goto L0d6d;

			// Instruction address 0x2aea:0x0d66, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 5,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6e9e));
			goto L0d92;

		L0d6d:
			// Instruction address 0x2aea:0x0d8d, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06,
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)) < 10) ? 6 : 3) +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) + 5,
				0);

		L0d92:
			// Instruction address 0x2aea:0x0d9c, size: 3
			F0_2aea_1458(xPos, yPos);

			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0db4;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8((byte)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Unknown[0], 0xff);
			if (this.oCPU.Flags.E) goto L0dca;

		L0db4:
			// Instruction address 0x2aea:0x0dc2, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				15, 15, 0);

		L0dca:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].ImprovementFlags0, 0x80);
			if (this.oCPU.Flags.E) goto L0def;

			// Instruction address 0x2aea:0x0de7, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 1,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) + 1,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x1d << 1) + 0xd4ce)));

		L0def:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c96), 0x20);
			if (this.oCPU.Flags.GE) goto L0e1b;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c96);
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6dac), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6e3e), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c96);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6c96, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c96)));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xdf20), this.oCPU.AX.Word);

		L0e1b:
			// Instruction address 0x2aea:0x0e1b, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.AX.Word = 0x1;

		L0e23:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_03ba");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public ushort F0_2aea_0e29(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_0e29({playerID}, {unitID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0xe);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb278), 0x1);
			if (this.oCPU.Flags.NE) goto L0eb2;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oGameData.Players[playerID].Units[unitID].TypeID != 0)
				goto L0e53;

			// Instruction address 0x2aea:0x0e77, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				(this.oGameData.Players[playerID].Units[unitID].Position.X * 4) + 1,
				(this.oGameData.Players[playerID].Units[unitID].Position.Y * 4) + 1,
				3, 3, 6);
			goto L0e55;

		L0e53:
			// Instruction address 0x2aea:0x0e77, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				(this.oGameData.Players[playerID].Units[unitID].Position.X * 4) + 1,
				(this.oGameData.Players[playerID].Units[unitID].Position.Y * 4) + 1,
				3, 3, 0);

		L0e55:
			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			// Instruction address 0x2aea:0x0ea7, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oGameData.Players[playerID].Units[unitID].Position.X * 4,
				this.oGameData.Players[playerID].Units[unitID].Position.Y * 4,
				3, 3,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1946)));
			goto L0fae;

		L0eb2:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x2aea:0x0ecd, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
				this.oGameData.Players[playerID].Units[unitID].Position.X - this.oParent.Var_d4cc_XPos);

			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oGameData.Players[playerID].Units[unitID].Position.Y);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.Var_d75e_YPos);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x50));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x50);
			if (this.oCPU.Flags.L) goto L0f09;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x140);
			if (this.oCPU.Flags.GE) goto L0f09;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.L) goto L0f09;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xc0);
			if (this.oCPU.Flags.LE) goto L0f0e;

		L0f09:
			this.oCPU.AX.Word = 0;
			goto L0fae;

		L0f0e:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				(short)this.oGameData.Players[playerID].Units[unitID].TypeID);

			// Instruction address 0x2aea:0x0f33, size: 3
			F0_2aea_134a_GetMapLayer1_TerrainType(this.oGameData.Players[playerID].Units[unitID].Position.X, this.oGameData.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L0f57;

			if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x1) == 0)
				goto L0f57;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oGameData.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Air)
				goto L0f09;

		L0f57:
			// Instruction address 0x2aea:0x0f57, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			if (this.oGameData.Players[playerID].Units[unitID].NextUnitID != -1)
			{
				// Instruction address 0x2aea:0x0f8b, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + 1,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 1,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((((playerID << 5) +
						this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 0x40) << 1) + 0xd4ce)));
			}

			// Instruction address 0x2aea:0x0fa0, size: 3
			F0_2aea_0fb3(playerID, unitID, 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			// Instruction address 0x2aea:0x0fa6, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.AX.Word = 0x1;

		L0fae:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_0e29");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_0fb3(short playerID, short unitID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_0fb3({playerID}, {unitID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x4);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x2aea:0x0fe2, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oGameData.Players[playerID].Units[unitID].TypeID + (playerID << 5) + 0x40) << 1) + 0xd4ce)));

			if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x8) == 0)
				goto L1005;

			// Instruction address 0x2aea:0x0ffb, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x1d << 1) + 0xd4ce)));
			goto L1045;

		L1005:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x4) == 0)
				goto L1045;

			if (playerID != 1)
				goto L1027;

			this.oCPU.AX.Word = 0x9;
			goto L102a;

		L1027:
			this.oCPU.AX.Word = 0xf;

		L102a:
			// Instruction address 0x2aea:0x103d, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow("F", xPos + 4, yPos + 7, this.oCPU.AX.Low);

		L1045:
			this.oCPU.AX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMP_UInt16((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L108d;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oGameData.Players[playerID].Units[unitID].GoToPosition.X != -1)
			{
				if (playerID == 1)
				{
					this.oCPU.AX.Word = 0x9;
				}
				else
				{
					this.oCPU.AX.Word = 0xf;
				}

				// Instruction address 0x2aea:0x1085, size: 5
				this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow("G", xPos + 4, yPos + 7, this.oCPU.AX.Low);
			}

		L108d:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if ((this.oGameData.Players[playerID].Units[unitID].Status & 0xc2) == 0)
				goto L117a;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oGameData.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Sea)
				goto L117a;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x52);

			if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x40) == 0)
				goto L10d7;

			if (this.oGameData.Players[playerID].Units[unitID].TypeID == 0)
				goto L10d1;

			this.oCPU.AX.Word = 0x3f;

			goto L10d4;

		L10d1:
			this.oCPU.AX.Word = 0x49;

		L10d4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

		L10d7:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x80) != 0)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4d);

				if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x40) != 0)
				{
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x46);
				}

				this.oCPU.AX.Word = 0xc;
				this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
				this.oCPU.BX.Word = this.oCPU.AX.Word;

				this.oCPU.AX.Word = 0x600;
				this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
				this.oCPU.SI.Word = this.oCPU.AX.Word;

				if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x2) != 0)
				{
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x50);
				}
			}

			// Instruction address 0x2aea:0x1128, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " ");

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, this.oCPU.AX.Low);
			this.oCPU.CMP_UInt16((ushort)playerID, 0x1);
			if (this.oCPU.Flags.NE) goto L1141;
			this.oCPU.AX.Word = 0x9;
			goto L1144;

		L1141:
			this.oCPU.AX.Word = 0xf;

		L1144:
			// Instruction address 0x2aea:0x1157, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(0xba06, xPos + 4, yPos + 7, this.oCPU.AX.Low);

			// Instruction address 0x2aea:0x1172, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(xPos - 1, yPos - 1, 15, 15, 7);

		L117a:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x1) != 0)
			{
				// Instruction address 0x2aea:0x11a8, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, xPos, yPos, 16, 16, 5, 7);

				// Instruction address 0x2aea:0x11c7, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, xPos, yPos, 16, 16, 8, 7);
			}

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_0fb3");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_11d4(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_11d4({xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x2aea:0x11e2, size: 3
			F0_2aea_03ba(xPos, yPos);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdcfc), 0x0);
			if (this.oCPU.Flags.NE) goto L1256;

			// Instruction address 0x2aea:0x11f6, size: 3
			F0_2aea_1458(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L1256;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L1237;
			this.oCPU.AX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd20a), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1237;
			
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd20a));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a)].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].VisibleByPlayer;
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oGameData.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L1256;

		L1237:
			// Instruction address 0x2aea:0x123e, size: 3
			F0_2aea_1585_GetImprovements(xPos, yPos);

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L1256;

			// Instruction address 0x2aea:0x1250, size: 3
			F0_2aea_125b(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

		L1256:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_11d4");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_2aea_125b(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_125b({playerID}, {unitID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x6);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x2aea:0x127f, size: 3
			F0_2aea_134a_GetMapLayer1_TerrainType(this.oGameData.Players[playerID].Units[unitID].Position.X, this.oGameData.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1308;

			if (this.oGameData.Players[playerID].Units[unitID].NextUnitID == -1)
				goto L1308;
			
			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oGameData.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Air)
				goto L1308;

			this.oCPU.AX.Word = (ushort)unitID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

		L12ac:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				(short)this.oGameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].NextUnitID);

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oGameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].TypeID].MovementType != UnitMovementTypeEnum.Air)
				goto L12ed;

			// Instruction address 0x2aea:0x12e2, size: 3
			F0_2aea_0e29(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0xffff);

		L12ed:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xffff);
			if (this.oCPU.Flags.E) goto L12fb;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L12ac;

		L12fb:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1321;

			// Instruction address 0x2aea:0x131b, size: 3
			F0_2aea_0e29(playerID, unitID);

			goto L1321;

		L1308:
			// Instruction address 0x2aea:0x131b, size: 3
			F0_2aea_0e29(playerID, (short)this.oParent.Segment_1866.F0_1866_1122(playerID, unitID));

		L1321:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_125b");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2aea_1326_CheckMapBounds(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1326_CheckMapBounds({xPos}, {yPos})");

			// function body
			if (xPos < 0 || xPos >= 80 || yPos < 0 || yPos >= 50)
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.AX.Word = 1;
			}

			this.oCPU.Log.ExitBlock("F0_2aea_1326_CheckMapBounds");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public TerrainTypeEnum F0_2aea_134a_GetMapLayer1_TerrainType(int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x1357, size: 5
			//this.oCPU.AX.Word = (ushort)((short)this.oParent.Array_2ba6[this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos)]);

			TerrainTypeEnum eValue = this.oGameData.Map[xPos, yPos].TerrainType;
			this.oCPU.AX.Word = (ushort)((short)eValue);

			return eValue;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_1369(int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x137d, size: 5
			//this.oCPU.AX.Word = (ushort)(this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 160, yPos) & 0x7);

			int iValue = this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits & 0x7;
			this.oCPU.AX.Word = (ushort)((short)iValue);

			return iValue;
		}

		/// <summary>
		/// Sets the city owner on map
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="playerID"></param>
		public void F0_2aea_138c_MapSetCityOwner(int xPos, int yPos, short playerID)
		{
			// function body
			// Instruction address 0x2aea:0x13a2, size: 5
			// Instruction address 0x2aea:0x13c0, size: 3
			//this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 160, yPos, (byte)((this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 160, yPos) & 0x8) + playerID), 0);

			this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits &= 0x8;
			this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits += playerID;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_13cb(short playerID, short unitID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_13cb({playerID}, {unitID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x2aea:0x13d8, size: 3
			F0_2aea_1458(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L13f5;

			// Instruction address 0x2aea:0x13ed, size: 5
			this.oParent.Segment_29f3.F0_29f3_0b66(playerID, unitID, (short)this.oCPU.AX.Word);

		L13f5:
			// Instruction address 0x2aea:0x140b, size: 3
			//this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, xPos + 160, yPos, (ushort)(playerID + 8));
			this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits = playerID + 0x8;

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_13cb");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_1412(short playerID, short unitID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1412({playerID}, {unitID}, {xPos}, {yPos})");

			// function body			
			if (this.oGameData.Players[playerID].Units[unitID].NextUnitID != -1)
			{
				// Instruction address 0x2aea:0x1433, size: 5
				this.oParent.Segment_29f3.F0_29f3_0bc9(playerID, unitID);
			}
			else
			{
				// Instruction address 0x2aea:0x144f, size: 3
				//this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, xPos + 160, yPos, (byte)playerID);
				this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits = playerID;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_1412");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2aea_1458(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1458({xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x4);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x2aea:0x1466, size: 3
			F0_2aea_14e0(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1477;

		L1472:
			this.oCPU.AX.Word = 0xffff;
			goto L14db;

		L1477:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L1481;

		L147e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L1481:
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) >= 128)
				goto L14c1;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) == -1 ||
				(this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].TypeID == -1) ||
				(this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.X != xPos) ||
				(this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.Y != yPos))
				goto L147e;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd7f0, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd20a, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			goto L14db;

		L14c1:
			// Instruction address 0x2aea:0x14d3, size: 3
			//this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, xPos + 160, yPos, 0);
			this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits = 0;

			goto L1472;

		L14db:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_1458");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_14e0(int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x14f4, size: 5
			/*this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 160, yPos);

			if ((this.oCPU.AX.Word & 0x8) != 0)
			{
				this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0x7);
			}
			else
			{
				this.oCPU.AX.Word = 0xffff;
			}*/

			int iRetVal = (this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits & 0x8) != 0 ? (this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits & 0x7) : -1;
			this.oCPU.AX.Word = (ushort)((short)iRetVal);

			return iRetVal;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_1511_ActiveUnitsSetFlag8(int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x1525, size: 5
			// Instruction address 0x2aea:0x1539, size: 3
			//this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 160, yPos, (byte)((this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 160, yPos) & 7) + 0x8));

			this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits &= 0x7;
			this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits |= 0x8;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_1570(int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x157a, size: 3
			int iRetVal = F0_2aea_1585_GetImprovements(xPos, yPos);
			iRetVal &= 0x8;

			this.oCPU.AX.Word = (ushort)((short)iRetVal);

			return iRetVal;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_1585_GetImprovements(int xPos, int yPos)
		{
			// function body
			/*// Instruction address 0x2aea:0x1597, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100);

			this.oCPU.BX.Word = this.oCPU.AX.Word;

			// Instruction address 0x2aea:0x15b0, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150);

			this.oCPU.AX.Word <<= 4;
			this.oCPU.AX.Word |= this.oCPU.BX.Word;*/

			int iRetVal = this.oGameData.Map[xPos, yPos].Layer5_TerrainImprovements1 | (this.oGameData.Map[xPos, yPos].Layer7_TerrainImprovements2 << 4);
			this.oCPU.AX.Word = (ushort)(iRetVal & 0xff);

			return iRetVal;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_15c1_GetVisibleImprovements(int xPos, int yPos)
		{
			// function body
			/*// Instruction address 0x2aea:0x15d8, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 80, yPos + 100);

			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x2aea:0x15ef, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 80, yPos + 150);

			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.DI.Word);*/

			int iRetVal = this.oGameData.Map[xPos, yPos].Layer6_VisibleTerrainImprovements1 | (this.oGameData.Map[xPos, yPos].Layer8_VisibleTerrainImprovements2 << 4);
			this.oCPU.AX.Word = (ushort)(iRetVal & 0xff);

			return iRetVal;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_1601_UpdateVisiblemprovements(int xPos, int yPos)
		{
			// function body			
			// Instruction address 0x2aea:0x161b, size: 5
			// Instruction address 0x2aea:0x1627, size: 3
			//this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 80, yPos + 100, (byte)this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100));

			// Instruction address 0x2aea:0x163d, size: 5
			// Instruction address 0x2aea:0x1649, size: 3
			//this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 80, yPos + 150, (byte)this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150));

			this.oGameData.Map[xPos, yPos].Layer6_VisibleTerrainImprovements1 = this.oGameData.Map[xPos, yPos].Layer5_TerrainImprovements1;
			this.oGameData.Map[xPos, yPos].Layer8_VisibleTerrainImprovements2 = this.oGameData.Map[xPos, yPos].Layer7_TerrainImprovements2;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="mask1"></param>
		public void F0_2aea_1653_ClearOrSetImprovements(int xPos, int yPos, int mask1, int mask2)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1653({xPos}, {yPos}, {mask1}, {mask2})");

			// function body
			/*if (mask1 == 0)
			{
				// Instruction address 0x2aea:0x16b7, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 100, 0);

				// Instruction address 0x2aea:0x16cf, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 150, 0);
			}
			else if (mask1 >= 0x10)
			{
				// Instruction address 0x2aea:0x1691, size: 5
				// Instruction address 0x2aea:0x16cf, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 150, (byte)(this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150) | (mask1 >> 4)));
			}
			else
			{
				// Instruction address 0x2aea:0x1672, size: 5
				// Instruction address 0x2aea:0x16cf, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 100, (byte)(this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100) | mask1));
			}*/

			if (mask1 == 0 && mask2 == 0)
			{
				this.oGameData.Map[xPos, yPos].Layer5_TerrainImprovements1 = 0;
				this.oGameData.Map[xPos, yPos].Layer7_TerrainImprovements2 = 0;
			}
			else
			{
				this.oGameData.Map[xPos, yPos].Layer5_TerrainImprovements1 |= mask1;
				this.oGameData.Map[xPos, yPos].Layer7_TerrainImprovements2 |= mask2;
			}

			if (this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6b90) == this.oGameData.HumanPlayerID)
			{
				// Instruction address 0x2aea:0x16e5, size: 3
				F0_2aea_1601_UpdateVisiblemprovements(xPos, yPos);
			}
		
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_1653");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="mask1"></param>
		public void F0_2aea_16ee_RemoveImprovement(int xPos, int yPos, int mask1, int mask2)
		{
			// function body
			/*if ((mask & 0xf) != 0)
			{
				// Instruction address 0x2aea:0x1707, size: 5
				// Instruction address 0x2aea:0x171c, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 100, (byte)(((~mask) & this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100)) & 0xff));
			}

			if (((mask & 0xf0) != 0))
			{
				// Instruction address 0x2aea:0x1738, size: 5
				// Instruction address 0x2aea:0x1751, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 150, (byte)(((~(mask >> 4)) & this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150)) & 0xff));
			}*/

			this.oGameData.Map[xPos, yPos].Layer5_TerrainImprovements1 |= mask1;
			this.oGameData.Map[xPos, yPos].Layer5_TerrainImprovements1 ^= mask1;

			this.oGameData.Map[xPos, yPos].Layer7_TerrainImprovements2 |= mask2;
			this.oGameData.Map[xPos, yPos].Layer7_TerrainImprovements2 ^= mask2;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_175a(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_175a({xPos}, {yPos})");

			// function body
			// Instruction address 0x2aea:0x1768, size: 3
			int iRetVal = -1;

			for (int i = 0; i < 128; i++)
			{
				if (this.oGameData.Cities[i].StatusFlag != 0xff &&
					this.oGameData.Cities[i].Position.X == xPos && this.oGameData.Cities[i].Position.Y == yPos)
				{
					int local_2 = F0_2aea_1369(xPos, yPos);

					this.oCPU.WriteInt16(this.oCPU.DS.Word, 0xd7f0, (short)local_2);
					this.oCPU.WriteInt16(this.oCPU.DS.Word, 0xd20a, (short)local_2);
					break;
				}
			}

			if (iRetVal == -1)
			{
				// Instruction address 0x2aea:0x17bf, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0x2bc6, 100, 80);
			}

			this.oCPU.AX.Word = (ushort)((short)iRetVal);

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_175a");

			return iRetVal;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public bool F0_2aea_1836_HasSpecialResource(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1836_HasSpecialResource({xPos}, {yPos})");

			// function body
			/*if (yPos <= 1 || yPos >= 48 || (((xPos & 3) * 4) + (yPos & 3)) != ((((xPos / 4) * 13) + ((yPos / 4) * 11) + this.oGameData.RandomSeed) & 0xf))
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.AX.Word = 1;
			}*/
			bool bTemp = this.oGameData.Map[xPos, yPos].HasSpecialResource;

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_1836_HasSpecialResource");

			return bTemp;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public ushort F0_2aea_1894(ushort param1, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1894({param1}, {xPos}, {yPos})");

			// function body
			if (param1 == 10 || (this.oGameData.Map[xPos, yPos].Visibility & 1) != 0 ||
				yPos <= 1 || yPos >= 48)
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				if (((xPos & 3) * 4 + (yPos & 3)) == ((((xPos / 4) * 13) + ((yPos / 4) * 11) + this.oGameData.RandomSeed + 8) & 0x1f) &&
					(F0_2aea_1585_GetImprovements(xPos, yPos) & 1) == 0)
				{
					this.oCPU.AX.Word = 1;
				}
				else
				{
					this.oCPU.AX.Word = 0;
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_1894");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_1942_GetGroupID(int xPos, int yPos)
		{
			// Instruction address 0x2aea:0x1953, size: 5
			//this.oCPU.AX.Word = this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 50);

			int iTemp = this.oGameData.Map[xPos, yPos].Layer3_GroupID;
			this.oCPU.AX.Word = (ushort)((short)iTemp);

			return iTemp;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_195d_GetGroupSize(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_195d_GetGroupSize({xPos}, {yPos})");

			// function body
			/*// Instruction address 0x2aea:0x1967, size: 3
			if (F0_2aea_134a_GetMapLayer1_TerrainType(xPos, yPos) != 10)
			{
				// Instruction address 0x2aea:0x1979, size: 3
				// Land
				this.oCPU.AX.Word = (ushort)this.oGameData.Continents[F0_2aea_1942_GetContinentID(xPos, yPos)].Size;
			}
			else
			{
				// Instruction address 0x2aea:0x1990, size: 3
				// Oceans
				this.oCPU.AX.Word = (ushort)this.oGameData.Oceans[F0_2aea_1942_GetContinentID(xPos, yPos)].Size;
			}*/

			int iTemp = this.oGameData.Map.Groups[this.oGameData.Map[xPos, yPos].Layer3_GroupID].Size;
			this.oCPU.AX.Word = (ushort)((short)iTemp);

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_195d_GetGroupSize");

			return iTemp;
		}
	}
}
