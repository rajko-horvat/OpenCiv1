using System;
using Avalonia.Media;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Segment_1238
	{
		private CivGame oParent;
		private VCPU oCPU;

		public Segment_1238(CivGame parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// Shows message box. Size of message box is determined by its text contents.
		/// Text can be formatted in order to show list of options to choose for the player.
		/// Each option should take a single line and start with one or multiple spaces.
		/// Option lines shouldn't be mixed with non-option lines in order for selection to render properly.
		/// Value at address 0xb276 (ushort) can be used as a bitmask indicating disabled options.
		/// </summary>
		/// <param name="stringPtr">Address of a message string</param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns>Index of selected option in AX register or 0xffff if no options provided</returns>
		public ushort F0_1238_001e_ShowDialog(ushort stringPtr, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_1238_001e_ShowDialog(0x{stringPtr:x4}, {xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x1238:0x0024, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x1238:0x0041, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			// Instruction address 0x1238:0x0049, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x1238:0x0058, size: 3
			this.oParent.Segment_2d05.F0_2d05_0031(stringPtr, xPos, yPos, 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			// Instruction address 0x1238:0x0061, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x1238:0x007e, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x1238:0x0086, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1238_001e_ShowDialog");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1238_0092()
		{
			this.oCPU.Log.EnterBlock("F0_1238_0092()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x1a);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x1238:0x009a, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x1238:0x009f, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0626();

			this.oCPU.AX.Word = (ushort)this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Coins;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd760, 0);
			this.oParent.Var_6b92 = 0;
			this.oParent.CivState.MaximumTechnologyCount = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xde20, 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0);

		L00c2:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.ActiveCivilizations);
			if (this.oCPU.Flags.E) goto L00e7;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xde20, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xde20)));
			this.oCPU.SI.Word = (ushort)this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].DiscoveredTechnologyCount;

			if (this.oParent.CivState.MaximumTechnologyCount < (short)this.oCPU.SI.Word)
			{
				this.oParent.CivState.MaximumTechnologyCount = (short)this.oCPU.SI.Word;
			}

		L00e7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8);
			if (this.oCPU.Flags.L) goto L00c2;
			if (this.oParent.CivState.TurnCount != 0) goto L0147;
			
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.CivState.HumanPlayerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oParent.Var_d4cc_MapXCenter = this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Units[0].Position.X - 7;
			this.oParent.Var_d75e_MapYCenter = this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Units[0].Position.Y - 6;

			// Instruction address 0x1238:0x0119, size: 3
			F0_1238_1b44();
			
			if (this.oParent.CivState.DifficultyLevel != 0) goto L013b;

			// Instruction address 0x1238:0x012a, size: 5
			this.oParent.Segment_1403.F0_1403_4060(this.oParent.CivState.HumanPlayerID, 0);

			this.oParent.MainIntro.F2_0000_17d9();

			// Instruction address 0x1238:0x0138, size: 3
			F0_1238_1b44();

		L013b:
			// Instruction address 0x1238:0x013f, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

		L0147:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L026a;

		L014f:
			// Instruction address 0x1238:0x0164, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 2, 192, 6, 6, 8);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 0x0);
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0183;

			// Instruction address 0x1238:0x0179, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 0x1);

		L0183:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdf60), 0x0);
			if (this.oCPU.Flags.NE) goto L0195;
			
			// Instruction address 0x1238:0x018d, size: 5
			this.oParent.Segment_1ade.F0_1ade_0006(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			
		L0195:
			if (this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Coins > 0x7530)
			{
				this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Coins = 0x7530;
			}

			// Instruction address 0x1238:0x01ab, size: 5
			this.oParent.Segment_2517.F0_2517_0004(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			// Instruction address 0x1238:0x01b6, size: 5
			this.oParent.Segment_25fb.F0_25fb_0004(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			// Instruction address 0x1238:0x01c1, size: 5
			this.oParent.Segment_25fb.F0_25fb_2fd7(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			// Instruction address 0x1238:0x01de, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 2, 192, 6, 6, 15);

			this.oCPU.AX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0225;

			// Instruction address 0x1238:0x01ef, size: 3
			F0_1238_107e();

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			
			if (this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].CityCount != 0 ||
				this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].SettlerCount != 0)
				goto L021a;

			// Instruction address 0x1238:0x0205, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.MainIntro.F2_0000_152a();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdc48, 0xffff);

			// Instruction address 0x1238:0x0215, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

		L021a:
			if (this.oParent.CivState.Year <= 0) goto L0225;
			oParent.CivState.PeaceTurnCount++;

		L0225:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdc48), 0x0);
			if (this.oCPU.Flags.NE) goto L0237;

			// Instruction address 0x1238:0x022f, size: 5
			this.oParent.Segment_1403.F0_1403_000e(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

		L0237:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdf60, 0x0);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x0);
			if (this.oCPU.Flags.E) goto L0248;

			// Instruction address 0x1238:0x0243, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

		L0248:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdc48), 0x0);
			if (this.oCPU.Flags.E) goto L0267;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb884), 0x0);
			if (this.oCPU.Flags.NE) goto L0267;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdc48), 0x2);
			if (this.oCPU.Flags.E) goto L0260;
			goto L089a;

		L0260:
			// Instruction address 0x1238:0x0261, size: 3
			F0_1238_08a0();

			goto L0896;

		L0267:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L026a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8);
			if (this.oCPU.Flags.GE) goto L02a0;
			this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Score = 0;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.ActiveCivilizations);
			if (this.oCPU.Flags.E) goto L0267;
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0294;
			goto L014f;

		L0294:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdf60), 0x0);
			if (this.oCPU.Flags.NE) goto L029e;
			goto L014f;

		L029e:
			goto L0267;

		L02a0:
			// Instruction address 0x1238:0x02a0, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x1238:0x02a6, size: 3
			F0_1238_0980();

			// Instruction address 0x1238:0x02aa, size: 3
			F0_1238_1767();

			if (this.oParent.CivState.TurnCount <= 50) goto L0306;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L02c9;

		L02bb:
			this.oParent.Overlay_20.F20_0000_0540(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

		L02c6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L02c9:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2);
			if (this.oCPU.Flags.GE) goto L0306;

			// Instruction address 0x1238:0x02d3, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(128));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			
			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].StatusFlag == 0xff ||
				this.oParent.CivState.Players[this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].PlayerID].CityCount <= 1)
				goto L02c6;

			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].ActualSize >= 5) goto L02bb;
			goto L02c6;

		L0306:
			// Instruction address 0x1238:0x0307, size: 3
			F0_1238_0da1();

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdc48), 0x0);
			if (this.oCPU.Flags.NE) goto L036d;
			this.oCPU.SI.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			
			if (this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].CityCount <= 1 ||
				this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Coins >= 100) goto L036d;

			this.oCPU.AX.Word = (ushort)this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Coins;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)));
			this.oCPU.CX.Word = 0xa;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Coins);
			if (this.oCPU.Flags.NS) goto L036d;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.CivState.HumanPlayerID & 0xff);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.PlayerFlags);
			if (this.oCPU.Flags.E) goto L036d;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1238:0x034f, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x1c2a);

			this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.DomesticAdvisor;

			// Instruction address 0x1238:0x0367, size: 3
			F0_1238_001e_ShowDialog(0xba06, 80, 80);

		L036d:
			oParent.CivState.TurnCount++;
			if (this.oParent.CivState.Year >= 1000) goto L0380;
			this.oParent.CivState.Year += 20;
			goto L03b8;

		L0380:
			if (this.oParent.CivState.Year >= 1500) goto L038f;
			this.oParent.CivState.Year += 10;
			goto L03b8;

		L038f:
			if (this.oParent.CivState.Year >= 1750) goto L039e;
			this.oParent.CivState.Year += 5;
			goto L03b8;

		L039e:
			if (this.oParent.CivState.Year >= 1850) goto L03b4;
			this.oCPU.TEST_UInt8((byte)(this.oParent.CivState.SpaceshipFlags & 0xff), 0xfe);
			if (this.oCPU.Flags.NE) goto L03b4;
			this.oParent.CivState.Year += 2;
			goto L03b8;

		L03b4:
			this.oParent.CivState.Year += 1;

		L03b8:
			if (oParent.CivState.Year != 0) goto L03dc;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L03c4:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].ResearchProgress <<= 1;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8);
			if (this.oCPU.Flags.L) goto L03c4;
			this.oParent.CivState.Year = 1;

		L03dc:
			if (this.oParent.CivState.Year != 21) goto L03e9;
			this.oParent.CivState.Year = 20;

		L03e9:
			this.oCPU.AX.Word = (ushort)oParent.CivState.TurnCount;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x32;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.DX.Word = this.oCPU.OR_UInt16(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L03f9;
			goto L055e;

		L03f9:
			this.oCPU.CMP_UInt16((ushort)this.oParent.CivState.HumanPlayerID, 0xffff);
			if (this.oCPU.Flags.NE) goto L0416;
			goto L055e;
			
		L0416:
			if (!this.oParent.CivState.GameSettingFlags.AutoSave) goto L0439;

			this.oParent.GameLoadAndSave.F11_0000_036a((ushort)((((this.oParent.CivState.TurnCount / 50) - 1) % 6) + 4));

		L0439:
			this.oParent.CivState.MaximumTechnologyCount = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);

		L0444:
			this.oCPU.SI.Word = (ushort)this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].DiscoveredTechnologyCount;
			if (this.oParent.CivState.MaximumTechnologyCount < (short)this.oCPU.SI.Word)
			{
				this.oParent.CivState.MaximumTechnologyCount = (short)this.oCPU.SI.Word;
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8);
			if (this.oCPU.Flags.L) goto L0444;

			this.oParent.Var_d2de = 0;
			
			if (this.oParent.CivState.Year < 0) goto L048f;

			// Instruction address 0x1238:0x0484, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oParent.CivState.MaximumTechnologyCount - (this.oParent.CivState.TurnCount / 9),
				0, 6);

			this.oParent.Var_d2de = (short)this.oCPU.AX.Word;

		L048f:
			// Instruction address 0x1238:0x0493, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_02cd(this.oParent.CivState.HumanPlayerID);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);

			// Instruction address 0x1238:0x04c8, size: 5
			this.oParent.Segment_1866.F0_1866_250e_AddReplayData(11,
				(byte)this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].CityCount,
				(byte)((this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)) & 0xff00) >> 8),
				(byte)(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)) & 0xff));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L04d5:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x14), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x4);
			if (this.oCPU.Flags.L) goto L04d5;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);
			goto L050a;

		L04ef:
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Ranking;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x14), 
				this.oCPU.OR_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x14)), this.oCPU.AX.Word));

		L0507:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L050a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8);
			if (this.oCPU.Flags.GE) goto L0542;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.ActiveCivilizations);
			if (this.oCPU.Flags.E) goto L0507;
			this.oCPU.SI.Word = (ushort)this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Ranking;
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L04ef;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x14), 
				this.oCPU.OR_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x14)), this.oCPU.AX.Word));
			goto L0507;

		L0542:
			// Instruction address 0x1238:0x0556, size: 5
			this.oParent.Segment_1866.F0_1866_250e_AddReplayData(12,
				this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));

		L055e:
			if (this.oParent.CivState.TurnCount < this.oParent.CivState.NextAnthologyTurn) goto L0582;

			// Instruction address 0x1238:0x056b, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(40));

			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.TurnCount);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x14);
			oParent.CivState.NextAnthologyTurn = (short)this.oCPU.AX.Word;

			this.oParent.WorldMap.F12_0000_09e2();

		L0582:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);

		L0587:
			this.oCPU.SI.Word = (ushort)this.oParent.CivState.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))];
			this.oCPU.CMP_UInt16(this.oCPU.SI.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L05b0;

			this.oCPU.CMP_UInt16(this.oCPU.SI.Word, 0x80);
			if (this.oCPU.Flags.E) goto L05b0;

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.SI.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oParent.CivState.Players[this.oParent.CivState.Cities[this.oCPU.SI.Word].PlayerID].Score += 25;

		L05b0:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x15);
			if (this.oCPU.Flags.LE) goto L0587;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3484), 0xfffd);
			if (this.oCPU.Flags.NE) goto L05c8;

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3484, 0xfffe);
			goto L05e6;

		L05c8:
			this.oCPU.AX.Word = 0xa;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.CivState.PollutedSquareCount);
			this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Score -= (short)this.oCPU.AX.Word;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3484), 0xfffe);
			if (this.oCPU.Flags.NE) goto L05e6;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3484, 0x0);

		L05e6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L05f0:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].StatusFlag == 0xff ||
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].PlayerID != this.oParent.CivState.HumanPlayerID)
				goto L0616;
			this.oCPU.TEST_UInt16(this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].ImprovementFlags0, 0x1);
			if (this.oCPU.Flags.E) goto L0616;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);

		L0616:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x80);
			if (this.oCPU.Flags.L) goto L05f0;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x0);
			if (this.oCPU.Flags.E) goto L066e;

			if (!this.oParent.CivState.GameSettingFlags.Palace) goto L066e;

			this.oCPU.TEST_UInt16((ushort)this.oParent.CivState.SpaceshipFlags, 0x100);
			if (this.oCPU.Flags.NE) goto L066e;

			// Instruction address 0x1238:0x063b, size: 3
			F0_1238_16e7((short)(this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].PalaceLevel + 1));

			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oParent.Overlay_20.F20_0000_0ca9_ShowCivilizationScorePopup(this.oParent.CivState.HumanPlayerID, false);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.L) goto L066e;

			this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].PalaceLevel++;
			if (this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].PalaceLevel > 37)
				goto L066e;
			
			this.oParent.Palace.F17_0000_0000();

		L066e:
			// Instruction address 0x1238:0x066f, size: 3
			F0_1238_107e();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x1cf6, 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);

		L067d:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.SpaceshipFlags);
			if (this.oCPU.Flags.E) goto L069f;

			if (this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].SpaceshipETAYear == this.oParent.CivState.Year)
			{
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x1cf6, this.oCPU.AX.Word);
			}

		L069f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8);
			if (this.oCPU.Flags.L) goto L067d;
			this.oCPU.AX.Word = 0x14;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.CivState.DifficultyLevel);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x820);
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			if ((short)this.oCPU.AX.Word != this.oParent.CivState.Year) goto L0718;

			this.oCPU.BX.Word = (ushort)this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x1238:0x06ce, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19b2)));

			// Instruction address 0x1238:0x06de, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " ");

			// Instruction address 0x1238:0x06f4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Name);

			// Instruction address 0x1238:0x0704, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\nplans retirement\nin 20 years.\n");

			this.oParent.Overlay_21.F21_0000_0000(-1);

		L0718:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1cf6), 0xffff);
			if (this.oCPU.Flags.NE) goto L073b;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb884), 0x0);
			if (this.oCPU.Flags.NE) goto L073b;

			this.oCPU.AX.Word = 0x14;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.CivState.DifficultyLevel);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x834);
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			if ((short)this.oCPU.AX.Word == this.oParent.CivState.Year) goto L073b;
			goto L089a;

		L073b:
			// Instruction address 0x1238:0x073b, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x1238:0x0748, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "*** GAME OVER ***\n");

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb884), 0x0);
			if (this.oCPU.Flags.E) goto L077e;

			// Instruction address 0x1238:0x075f, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Your civilization\nhas conquered\nthe entire planet!\n");

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x1cf6, 0xffff);

			this.oParent.Overlay_21.F21_0000_0000(-1);

			this.oParent.GameReplay.F9_0000_0dde();

		L077e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1cf6), 0xffff);
			if (this.oCPU.Flags.E) goto L07c7;

			this.oParent.MainIntro.F2_0000_0bd7(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x1cf6));

			// Instruction address 0x1238:0x0792, size: 3
			F0_1238_1b44();

			// Instruction address 0x1238:0x07a3, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oParent.CivState.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x1cf6)].Nationality);

			// Instruction address 0x1238:0x07b3, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " spaceship\narrives at Alpha Centauri.\n");

			this.oParent.Overlay_21.F21_0000_0000(-1);

		L07c7:
			this.oCPU.AX.Word = 0x14;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.CivState.DifficultyLevel);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x834);
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			if ((short)this.oCPU.AX.Word != this.oParent.CivState.Year) goto L0836;

			// Instruction address 0x1238:0x07e7, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Name);

			// Instruction address 0x1238:0x07f7, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " dynasty\nends after glorious\n6000 year reign!\n");

			// Instruction address 0x1238:0x0816, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(
				this.oParent.CivState.Nations[this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].NationalityID].LongTune, 3);

			this.oParent.Overlay_21.F21_0000_0000(-1);
			
			// Instruction address 0x1238:0x082e, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

		L0836:
			// Instruction address 0x1238:0x0836, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.TEST_UInt16((ushort)this.oParent.CivState.SpaceshipFlags, 0x100);
			if (this.oCPU.Flags.NE) goto L084e;

			// Instruction address 0x1238:0x0848, size: 3
			F0_1238_08a0();

		L084e:
			// Instruction address 0x1238:0x084f, size: 3
			F0_1238_1b44();

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x4cd9, this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x4cd9), 0x1));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb884), 0x0);
			if (this.oCPU.Flags.NE) goto L0889;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1238:0x0867, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x1cf0);
			
			// Instruction address 0x1238:0x0879, size: 3
			F0_1238_001e_ShowDialog(0xba06, 80, 80);

			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdc48, this.oCPU.AX.Word);
			goto L088f;

		L0889:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdc48, 0x1);

		L088f:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdc48), 0x0);
			if (this.oCPU.Flags.E) goto L089a;

		L0896:
			// Instruction address 0x1238:0x0897, size: 3
			F0_1238_090a();

		L089a:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1238_0092");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1238_08a0()
		{
			this.oCPU.Log.EnterBlock("F0_1238_08a0()");

			// function body
			this.oParent.WorldMap.F12_0000_0573();

			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdc48) != 2)
			{
				this.oParent.GameReplay.F9_0000_0000();
			}

			// Instruction address 0x1238:0x08b7, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			if ((this.oParent.CivState.SpaceshipFlags & 0x100) == 0)
			{
				this.oParent.HallOfFame.F3_0000_065d((ushort)((this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].PalaceLevel >> 1) - 1),
					this.oParent.Overlay_20.F20_0000_0ca9_ShowCivilizationScorePopup(this.oParent.CivState.HumanPlayerID, true));

				this.oParent.HallOfFame.F3_0000_002b();

				this.oParent.HallOfFame.F3_0000_0513();

				this.oParent.HallOfFame.F3_0000_0083();
			}
		
			// Instruction address 0x1238:0x0901, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Far return
			this.oCPU.Log.ExitBlock("F0_1238_08a0");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1238_090a()
		{
			this.oCPU.Log.EnterBlock("F0_1238_090a()");

			// function body
			// Instruction address 0x1238:0x090a, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x1238:0x0916, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(1, 1);

			// Instruction address 0x1238:0x0926, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x1cf8, 0);

			// Instruction address 0x1238:0x092e, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x1238:0x0946, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x1238:0x0952, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x1d05, 1);

			// Instruction address 0x1238:0x0972, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x1238:0x097a, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Far return
			this.oCPU.Log.ExitBlock("F0_1238_090a");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1238_0980()
		{
			this.oCPU.Log.EnterBlock("F0_1238_0980()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x1c);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.AX.Word = 0x5;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.DifficultyLevel);
			this.oCPU.CX.Word = 0x1e;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			if (this.oCPU.AX.Word <= this.oParent.CivState.TurnCount) goto L099d;
			goto L0d9b;

		L099d:
			this.oCPU.AX.Low = (byte)(oParent.CivState.TurnCount & 0xff);
			this.oCPU.AX.Low = this.oCPU.INC_UInt8(this.oCPU.AX.Low);
			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x7);
			if (this.oCPU.Flags.E) goto L09a9;
			goto L0aa6;

		L09a9:
			this.oCPU.TEST_UInt16((ushort)this.oParent.CivState.TechnologyFirstDiscoveredBy[58], 0x7);
			if (this.oCPU.Flags.E) goto L09b8;
			goto L0aa6;

		L09b8:
			// Instruction address 0x1238:0x09bc, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(80));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

			// Instruction address 0x1238:0x09cb, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(44));

			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x3);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

			// Instruction address 0x1238:0x09dd, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L09b8;

			// Instruction address 0x1238:0x09f0, size: 5
			this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L09b8;

			// Instruction address 0x1238:0x0a01, size: 5
			this.oParent.MapManagement.F0_2aea_195d_GetMapGroupSize(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x10);
			if (this.oCPU.Flags.L) goto L09b8;

			// Instruction address 0x1238:0x0a21, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(this.oParent.CivState.TurnCount / 150) + 1, 1, 3);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);

			// Instruction address 0x1238:0x0a43, size: 5
			this.oParent.Segment_1866.F0_1866_0cf5(
				0,
				(short)((this.oCPU.AX.Word < 3) ? 0x11 : 0x12),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L0a8b;

		L0a52:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x7);

		L0a57:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0a64;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1a);

		L0a64:
			// Instruction address 0x1238:0x0a70, size: 5
			this.oParent.Segment_1866.F0_1866_0cf5(
				0,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oParent.CivState.Players[0].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))].Status |= 1;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L0a8b:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L0aa6;
			this.oCPU.TEST_UInt16((ushort)this.oParent.CivState.TechnologyFirstDiscoveredBy[56], 0x7);
			if (this.oCPU.Flags.NE) goto L0a52;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x3);
			goto L0a57;

		L0aa6:
			// Instruction address 0x1238:0x0aaa, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(128));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8(this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].StatusFlag, 0xff);
			if (this.oCPU.Flags.NE) goto L0ac7;
			goto L0d9b;

		L0ac7:
			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].PlayerID != this.oParent.CivState.HumanPlayerID)
				goto L0d9b;

			// Instruction address 0x1238:0x0ad8, size: 5
			this.oParent.Segment_2459.F0_2459_0687(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);

			// Instruction address 0x1238:0x0ae7, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(100));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			if (this.oCPU.Flags.L) goto L0af7;
			goto L0d9b;

		L0af7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), 0x0);

		L0afc:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1238:0x0b08, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(13));

			this.oCPU.CX.Word = (ushort)((short)this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.X);
			this.oCPU.CX.Word = this.oCPU.ADD_UInt16(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.SUB_UInt16(this.oCPU.CX.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.CX.Word);

			// Instruction address 0x1238:0x0b22, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(13));

			this.oCPU.CX.Word = (ushort)((short)this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.Y);
			this.oCPU.CX.Word = this.oCPU.ADD_UInt16(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.SUB_UInt16(this.oCPU.CX.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.CX.Word);

			// Instruction address 0x1238:0x0b3c, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1238:0x0b61, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.X,
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), 0x63);
			if (this.oCPU.Flags.GE) goto L0bef;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x6);
			if (this.oCPU.Flags.L) goto L0afc;

			// Instruction address 0x1238:0x0b83, size: 5
			this.oParent.Segment_1866.F0_1866_1750(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0b92;
			goto L0afc;

		L0b92:
			// Instruction address 0x1238:0x0b98, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L0ba8;
			goto L0afc;

		L0ba8:
			// Instruction address 0x1238:0x0bae, size: 5
			this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0bbc;
			goto L0afc;

		L0bbc:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1238:0x0bd0, size: 5
			this.oParent.MapManagement.F0_2aea_1942(
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.X,
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.Y);

			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1238:0x0be0, size: 5
			this.oParent.MapManagement.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.E) goto L0bef;
			goto L0afc;

		L0bef:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), 0x63);
			if (this.oCPU.Flags.L) goto L0bf8;
			goto L0d9b;

		L0bf8:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].PlayerID != this.oParent.CivState.HumanPlayerID)
				goto L0cc5;

			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))];
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.CivState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L0c33;
			goto L0cc5;

		L0c33:
			// Instruction address 0x1238:0x0c4b, size: 5
			this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(this.oParent.CivState.HumanPlayerID,
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.X - 8,
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.Y - 6);

			// Instruction address 0x1238:0x0c5b, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Travellers report:\n");

			if ((this.oParent.CivState.TechnologyFirstDiscoveredBy[35] & 7) == 0)
				goto L0c74;

			// Instruction address 0x1238:0x0c89, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "Guerrilla uprising\nnear ");

			goto L0c84;

		L0c74:
			if ((this.oParent.CivState.TechnologyFirstDiscoveredBy[68] & 7) == 0)
				goto L0c81;

			// Instruction address 0x1238:0x0c89, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "Native unrest\nnear ");

			goto L0c84;

		L0c81:
			// Instruction address 0x1238:0x0c89, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "Barbarian uprising\nnear ");

		L0c84:
			// Instruction address 0x1238:0x0c94, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));

			// Instruction address 0x1238:0x0ca4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\n");

			this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.TravelersReport;

			// Instruction address 0x1238:0x0cbf, size: 3
			F0_1238_001e_ShowDialog(0xba06, 100, 32);

		L0cc5:
			// Instruction address 0x1238:0x0ce9, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oParent.MSCAPI.RNG.Next(
					this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, 
					(ushort)(this.oCPU.BP.Word - 0x14))].ActualSize / 2),
				2, 99);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);
			goto L0d75;

		L0cfb:
			this.oCPU.AX.Word = 0x4;
			goto L0d0e;

		L0d00:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0x4);
			if (this.oCPU.Flags.E) goto L0d0b;
			this.oCPU.AX.Word = 0xa;
			goto L0d0e;

		L0d0b:
			this.oCPU.AX.Word = 0x6;

		L0d0e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0d1e;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1a);

		L0d1e:
			// Instruction address 0x1238:0x0d2a, size: 5
			this.oParent.Segment_1866.F0_1866_0cf5(
				0,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			
			this.oParent.CivState.Players[0].Units[(short)this.oCPU.AX.Word].VisibleByPlayer |=
				this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
					this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))];

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			
			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].PlayerID != this.oParent.CivState.HumanPlayerID)
				goto L0d72;

			// Instruction address 0x1238:0x0d6a, size: 5
			this.oParent.MapManagement.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L0d72:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

		L0d75:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L0d9b;
			this.oCPU.TEST_UInt16((ushort)this.oParent.CivState.TechnologyFirstDiscoveredBy[35], 0x7);
			if (this.oCPU.Flags.NE) goto L0d8c;
			goto L0d00;

		L0d8c:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0x4);
			if (this.oCPU.Flags.NE) goto L0d95;
			goto L0cfb;

		L0d95:
			this.oCPU.AX.Word = 0x9;
			goto L0d0e;

		L0d9b:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1238_0980");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1238_0da1()
		{
			this.oCPU.Log.EnterBlock("F0_1238_0da1()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x1a);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

		L0db3:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Coins;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x5;
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.DX.Word = (ushort)this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].TotalCitySize;
			this.oCPU.CX.Low = 0x3;
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word += this.oCPU.DX.Word;
			this.oCPU.AX.Word += (ushort)this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].DiscoveredTechnologyCount;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L0de0:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.UnitDefinitions[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Cost);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].ActiveUnits[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))]);
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x16), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x16)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x1c);
			if (this.oCPU.Flags.L) goto L0de0;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.ActiveCivilizations);
			if (this.oCPU.Flags.NE) goto L0e26;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x16), 0x0);

		L0e26:
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0e3e;
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x16));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.SI.Word);
			if (this.oCPU.Flags.GE) goto L0e3e;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SI.Word);

		L0e3e:
			if (this.oParent.CivState.TurnCount >= 600) goto L0e99;

			// Instruction address 0x1238:0x0e64, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) << 1) - 0x16)) / 8,
				0, 255);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.TurnCount;
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x96;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.SI.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Low = 0x3;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			
			this.oParent.CivState.ScoreGraphData[this.oCPU.SI.Word] = this.oCPU.BX.Low;

		L0e99:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L0ea3:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))] & 3) == 1)
			{
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
				this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18),
					this.oCPU.OR_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), this.oCPU.AX.Word));
			}
		
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8);
			if (this.oCPU.Flags.L) goto L0ea3;
			if (this.oParent.CivState.TurnCount >= 600) goto L0f05;
			this.oCPU.BX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
			this.oCPU.AX.Word = (ushort)oParent.CivState.TurnCount;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x96;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.SI.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Low = 0x3;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oParent.CivState.PeaceGraphData[this.oCPU.SI.Word] = this.oCPU.BX.Low;

		L0f05:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8);
			if (this.oCPU.Flags.GE) goto L0f11;
			goto L0db3;

		L0f11:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);

		L0f16:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

		L0f20:
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x16));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.SI.Word);
			if (this.oCPU.Flags.GE) goto L0f36;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SI.Word);

		L0f36:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8);
			if (this.oCPU.Flags.L) goto L0f20;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x8;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)) < this.oParent.CivState.Players.Length)
			{
				this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a))].Ranking = (short)this.oCPU.AX.Word;
			}
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x16), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8);
			if (this.oCPU.Flags.L) goto L0f16;
			
			this.oParent.Var_8078 = 0;

			if (this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Ranking != 7 ||
				this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].CityCount <= 4) goto L0fe4;

			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.CivState.HumanPlayerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			
			if (this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].ActiveUnits[(int)UnitTypeEnum.Nuclear] != 0 ||
				oParent.CivState.TurnCount <= 200) goto L0fe4;

			this.oParent.Var_8078 = 1;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);
			goto L0fb0;

		L0f9b:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Diplomacy[this.oParent.CivState.HumanPlayerID] |= 1;

		L0fad:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L0fb0:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8);
			if (this.oCPU.Flags.GE)
				goto L0fe4;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), (ushort)this.oParent.CivState.HumanPlayerID);
			if (this.oCPU.Flags.E)
				goto L0fad;

			if (this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].CityCount <= 1)
				goto L0fad;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16((ushort)this.oParent.CivState.HumanPlayerID, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if ((this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Diplomacy[this.oParent.CivState.HumanPlayerID] & 2) == 0)
				goto L0f9b;

			this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Diplomacy[this.oParent.CivState.HumanPlayerID] |= 0x100;
			goto L0fad;

		L0fe4:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1238_0da1");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1238_0fea()
		{
			this.oCPU.Log.EnterBlock("F0_1238_0fea()");

			// function body
			// Instruction address 0x1238:0x0ffd, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 8, 0);

			// Instruction address 0x1238:0x1015, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("G\x0087AME", 8, 1, 15);

			// Instruction address 0x1238:0x102d, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("O\x0087RDERS", 64, 1, 15);

			// Instruction address 0x1238:0x1045, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("A\x0087DVISORS", 128, 1, 15);

			// Instruction address 0x1238:0x105d, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("W\x0087ORLD", 192, 1, 15);

			// Instruction address 0x1238:0x1075, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("C\x0087IVILOPEDIA", 240, 1, 15);

			// Far return
			this.oCPU.Log.ExitBlock("F0_1238_0fea");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1238_107e()
		{
			this.oCPU.Log.EnterBlock("F0_1238_107e()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x8);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			
			// Instruction address 0x1238:0x109f, size: 3
			F0_1238_1bb2_FillRectangleWithShadow(0, 58, 80, 39);

			// Instruction address 0x1238:0x10ba, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 3, 60, 74, 11, 11);

			if (this.oParent.CivState.PeaceTurnCount <= 1) goto L10fb;

			// Instruction address 0x1238:0x10de, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.CivState.PeaceTurnCount * 2, 0, 60);

			// Instruction address 0x1238:0x10f3, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 3, 60, (short)this.oCPU.AX.Word, 2, 15);

		L10fb:
			// Instruction address 0x1238:0x110c, size: 3
			F0_1238_14a3(this.oParent.CivState.HumanPlayerID, this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].PalaceLevel, 8, 58);

			if (!this.oParent.Var_d806_DebugFlag) goto L115d;

			this.oCPU.PUSH_UInt16(0); // stack management - push return segment, ignored
			this.oCPU.PUSH_UInt16(0x111e); // stack management - push return offset
			// Instruction address 0x1238:0x1119, size: 5
			this.oParent.Graphics.F0_VGA_0492_GetFreeMemory();
			this.oCPU.POP_UInt32(); // stack management - pop return offset and segment
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1238:0x113e, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 10));

			// Instruction address 0x1238:0x1155, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 2, 59, 0);

		L115d:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			
			// Instruction address 0x1238:0x1166, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_02cd(this.oParent.CivState.HumanPlayerID);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

			// Instruction address 0x1238:0x1179, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "#");

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x0);
			if (this.oCPU.Flags.E) goto L119e;

			// Instruction address 0x1238:0x1196, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 2, 73, 0);

		L119e:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1238:0x11a4, size: 3
			F0_1238_1720_GetCurrentYearAsString();

			// Instruction address 0x1238:0x11b6, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 2, 81, 0);

			if (this.oParent.CivState.Year < 0)
			{
				this.oCPU.CX.Word = 0x1;
			}
			else
			{
				this.oCPU.CX.Word = 0x2;
			}

			this.oCPU.AX.Word = (ushort)oParent.CivState.DifficultyLevel;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_d2de));
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x6);
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].DiscoveredTechnologyCount);
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.INC_UInt16(this.oCPU.CX.Word);
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].ResearchProgress;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 2);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			
			// Instruction address 0x1238:0x1215, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0, 3);

			// Instruction address 0x1238:0x1229, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 
				((short)this.oCPU.AX.Word << 3) + 160, 120, 8, 8, this.oParent.Var_aa_Rectangle, 48, 80);

			if (this.oParent.CivState.PollutionEffectLevel == 0) goto L1288;

			// Instruction address 0x1238:0x1251, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oParent.CivState.PollutionEffectLevel / 4, 0, 3);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			// Instruction address 0x1238:0x1280, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 3) + 160, 128, 8, 8, this.oParent.Var_aa_Rectangle, 56, 80);

		L1288:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1238:0x12ac, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Coins, 10));

			// Instruction address 0x1238:0x12bc, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "$");

			// Instruction address 0x1238:0x12cc, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " ");

			// Instruction address 0x1238:0x12fd, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)(-(this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].TaxRate +
					this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].ScienceTaxRate - 10)), 10));

			// Instruction address 0x1238:0x130d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".");

			// Instruction address 0x1238:0x1334, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].TaxRate, 10));

			// Instruction address 0x1238:0x1344, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".");

			// Instruction address 0x1238:0x136b, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].ScienceTaxRate, 10));

			// Instruction address 0x1238:0x1382, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 2, 89, 0);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1c28), 0x0);
			if (this.oCPU.Flags.E) goto L1394;
			goto L149e;

		L1394:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1c24);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			// Instruction address 0x1238:0x13a2, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "The population of the\nfertile ");

			// Instruction address 0x1238:0x13b8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Nationality);

			// Instruction address 0x1238:0x13c8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " empire now\nexceeds ");

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x64);
			if (this.oCPU.Flags.GE) goto L1413;
			this.oCPU.AX.Word = 0xa;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1c24));
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			if (this.oCPU.Flags.L) goto L13e5;
			goto L1466;

		L13e5:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, 10);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1238:0x1405, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oParent.MSCAPI.itoa((short)this.oCPU.SI.Word, 10));

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x1c24, this.oCPU.SI.Word);
			goto L1466;

		L1413:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1c24);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x9);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x64;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			if (this.oCPU.Flags.GE) goto L1466;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, 0x64);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1238:0x1448, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oParent.MSCAPI.itoa((short)this.oCPU.SI.Word, 10));

			// Instruction address 0x1238:0x1458, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ",0");

			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.SI.Word + 0x9);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x1c24, this.oCPU.AX.Word);

		L1466:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1c24);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L149e;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3484), 0xffff);
			if (this.oCPU.Flags.L) goto L149e;

			// Instruction address 0x1238:0x147d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "00,000 citizens.\n");

			this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.DomesticAdvisor;

			// Instruction address 0x1238:0x1498, size: 3
			F0_1238_001e_ShowDialog(0xba06, 100, 80);

		L149e:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1238_107e");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="palaceLevel"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_1238_14a3(short playerID, short palaceLevel, short xPos, short yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_1238_14a3({playerID}, {palaceLevel}, {xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x36);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x1238:0x14c5, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos - 5, yPos + 13, xPos + 68, yPos + 13, 2);

			if (this.oParent.CivState.Players[playerID].CityCount != 0) goto L14dc;
			goto L16e1;

		L14dc:
			// Instruction address 0x1238:0x14eb, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(palaceLevel + 3, 3, 36);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), this.oCPU.AX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x5;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);

		L1504:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x32), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x9);
			if (this.oCPU.Flags.L) goto L1504;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x3);

		L151c:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x32), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x5);
			if (this.oCPU.Flags.LE) goto L151c;

			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oParent.CivState.RandomSeed);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			
			if (playerID != this.oParent.CivState.HumanPlayerID)
				goto L1569;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L154b;

		L1548:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L154b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x9);
			if (this.oCPU.Flags.L) goto L1554;
			goto L1630;

		L1554:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x32),
				(short)this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)) + 2]);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20),
				(short)this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].PalaceData2[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))]);

			goto L1548;

		L1569:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L1625;

		L1571:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L1576:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);
			this.oCPU.AX.Word = 0x5;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.High = 0;
			this.oCPU.DX.Word = 0;
			this.oCPU.CX.Word = 0x9;
			this.oCPU.DIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.DX.Word);
			this.oCPU.SI.Word = this.oCPU.DX.Word;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x32));
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.DX.Word, 0x4);
			if (this.oCPU.Flags.GE) goto L15bd;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x30)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L15b8;
			this.oCPU.DI.Word = 0x7;
			this.oCPU.DI.Word = this.oCPU.SUB_UInt16(this.oCPU.DI.Word, this.oCPU.DX.Word);
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x32)), 0xffff);
			if (this.oCPU.Flags.NE) goto L15bd;

		L15b8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L15bd:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x4);
			if (this.oCPU.Flags.LE) goto L15e3;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x34)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L15de;
			this.oCPU.SI.Word = 0x9;
			this.oCPU.SI.Word = this.oCPU.SUB_UInt16(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x32)), 0xffff);
			if (this.oCPU.Flags.NE) goto L15e3;

		L15de:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L15e3:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L15f1;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x3);
			if (this.oCPU.Flags.LE) goto L15f6;

		L15f1:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L15f6:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x0);
			if (this.oCPU.Flags.NE) goto L1609;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3e7);
			if (this.oCPU.Flags.GE) goto L1609;
			goto L1576;

		L1609:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x32), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x20), this.oCPU.DX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L1625:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L1630;
			goto L1571;

		L1630:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);

		L1635:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x32)), 0x0);
			if (this.oCPU.Flags.G) goto L1645;
			goto L16d5;

		L1645:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x2);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x4);
			if (this.oCPU.Flags.GE) goto L1666;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x34)), 0xffff);
			if (this.oCPU.Flags.E) goto L1661;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x1);
			if (this.oCPU.Flags.NE) goto L1666;

		L1661:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);

		L1666:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x4);
			if (this.oCPU.Flags.LE) goto L1687;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x3);
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x30)), 0xffff);
			if (this.oCPU.Flags.E) goto L1682;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x7);
			if (this.oCPU.Flags.NE) goto L1687;

		L1682:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x4);

		L1687:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.BP.Word);

			// Instruction address 0x1238:0x169a, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x32)) - 1, 0, 3);
			
			this.oCPU.CX.Word = 0x5;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADD_UInt16(this.oCPU.DI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);
			this.oCPU.AX.Word = 0x28;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x20)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			// Instruction address 0x1238:0x16cd, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				(7 * this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))) + xPos, yPos - 1,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0xd21c)));

		L16d5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x9);
			if (this.oCPU.Flags.GE) goto L16e1;
			goto L1635;

		L16e1:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1238_14a3");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="palaceLevel"></param>
		public ushort F0_1238_16e7(short palaceLevel)
		{
			this.oCPU.Log.EnterBlock($"F0_1238_16e7({palaceLevel})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L170b;

		L16f9:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Word = 0x7;
			this.oCPU.CX.Word = this.oCPU.SUB_UInt16(this.oCPU.CX.Word, (ushort)this.oParent.CivState.DifficultyLevel);
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L170b:
			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) <= palaceLevel)
				goto L16f9;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F0_1238_16e7");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// Gets current year as a String, appends buffer at 0xba06
		/// </summary>
		public void F0_1238_1720_GetCurrentYearAsString()
		{
			// Instruction address 0x1238:0x1742, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.MSCAPI.itoa(Math.Abs(this.oParent.CivState.Year), 10));

			// Instruction address 0x1238:0x175e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, (this.oParent.CivState.Year >= 0) ? " AD" : " BC");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1238_1767()
		{
			this.oCPU.Log.EnterBlock("F0_1238_1767()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0xe);

			this.oCPU.AX.Word = (ushort)this.oParent.CivState.PollutedSquareCount;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = (ushort)this.oParent.CivState.GlobalWarmingCount;
			this.oCPU.CX.Word = this.oCPU.SHL_UInt16(this.oCPU.CX.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.PollutionEffectLevel);
			this.oCPU.AX.Word = (ushort)Math.Sign((short)this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.PollutionEffectLevel);
			
			// Instruction address 0x1238:0x1797, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((short)this.oCPU.AX.Word, 0, 99);

			oParent.CivState.PollutionEffectLevel = (short)this.oCPU.AX.Word;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xc);
			if (this.oCPU.Flags.NE) goto L17ca;
			if (this.oParent.CivState.PollutedSquareCount <= 6) goto L17ca;

			// Instruction address 0x1238:0x17b6, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Scientists alarmed by\nrising temperatures.\nGlobal Warming feared!\n");

			this.oParent.Overlay_21.F21_0000_0000(-1);

		L17ca:
			if (this.oParent.CivState.PollutionEffectLevel <= 16) goto L17e7;
			
			this.oParent.GameInitAndIntro.F7_0000_1be3(this.oParent.CivState.GlobalWarmingCount);

			this.oParent.CivState.GlobalWarmingCount++;
			this.oParent.CivState.PollutionEffectLevel = 0;

		L17e7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			goto L18a0;

		L17ef:
			this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.TravelersReport;

		L17f2:
			// Instruction address 0x1238:0x1802, size: 3
			F0_1238_001e_ShowDialog(0xba06, 100, 80);

			this.oParent.Civilopedia.F8_0000_062a((ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)) + 0x18), 1);
			
			// Instruction address 0x1238:0x181c, size: 3
			F0_1238_1b44();

			// Instruction address 0x1238:0x1823, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0xe);
			if (this.oCPU.Flags.NE) goto L184d;

			// Instruction address 0x1238:0x1837, size: 5
			this.oParent.Segment_1ade.F0_1ade_1584(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0);
			
			// Instruction address 0x1238:0x1845, size: 5
			this.oParent.Segment_1ade.F0_1ade_1584(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0);

		L184d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L1857;

		L1854:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L1857:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.L) goto L1861;
			goto L1b3e;

		L1861:			
			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].StatusFlag == 0xff ||
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].PlayerID != this.oParent.CivState.HumanPlayerID)
				goto L1854;

			this.oCPU.AX.Low = (byte)this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CX.Word = this.oCPU.ADD_UInt16(this.oCPU.CX.Word, 0x18);
			this.oCPU.CX.Word = this.oCPU.NEG_UInt16(this.oCPU.CX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1854;
			
			// Instruction address 0x1238:0x1893, size: 5
			this.oParent.Segment_1ade.F0_1ade_03ea(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			
			goto L1854;

		L189d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L18a0:
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.DifficultyLevel;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L18ab;
			goto L1b3e;

		L18ab:
			// Instruction address 0x1238:0x18af, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(21));

			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			
			if (this.oParent.CivState.DifficultyLevel != 0) goto L18de;

			// Instruction address 0x1238:0x18d2, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.CivState.HumanPlayerID,
				(int)this.oParent.CivState.ImprovementDefinitions(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))).RequiresTechnology);

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L189d;

		L18de:
			if (this.oParent.CivState.DifficultyLevel >= 2) goto L1924;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L18ea:
			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].StatusFlag == 0xff ||
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].PlayerID != this.oParent.CivState.HumanPlayerID)
				goto L191a;

			this.oCPU.AX.Low = (byte)this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CX.Word = this.oCPU.ADD_UInt16(this.oCPU.CX.Word, 0x18);
			this.oCPU.CX.Word = this.oCPU.NEG_UInt16(this.oCPU.CX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L191a;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x11);

		L191a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.L) goto L18ea;

		L1924:
			// Instruction address 0x1238:0x1928, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(128));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8(this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].StatusFlag, 0xff);
			if (this.oCPU.Flags.NE) goto L1945;
			goto L189d;

		L1945:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].PlayerID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.CivState.Players[this.oCPU.AX.Word].Diplomacy[0] & 0x4) != 0)
				goto L189d;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x11);
			if (this.oCPU.Flags.NE) goto L1981;

			// Instruction address 0x1238:0x1972, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), (int)TechnologyEnum.Rocketry);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L1981;

			goto L189d;

		L1981:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x0);
			if (this.oCPU.Flags.NE) goto L19ba;

			// Instruction address 0x1238:0x198e, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), (int)TechnologyEnum.Rocketry);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L19ba;
	
			// Instruction address 0x1238:0x19a2, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.CivState.HumanPlayerID, (int)TechnologyEnum.Rocketry);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L19ba;

			this.oCPU.CMP_UInt16((ushort)this.oParent.CivState.WonderCityID[17], 0xffff);
			if (this.oCPU.Flags.NE) goto L19ba;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x11);

		L19ba:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x11);
			if (this.oCPU.Flags.NE) goto L19ec;

			// Instruction address 0x1238:0x19c8, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.CivState.HumanPlayerID, (int)TechnologyEnum.Rocketry);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L19ec;

			if (this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].MilitaryPower <=
				this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].MilitaryPower)
				goto L19ec;

			goto L189d;

		L19ec:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xffff);
			if (this.oCPU.Flags.NE) goto L19f5;
			goto L189d;

		L19f5:
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1a00;
			goto L189d;

		L1a00:
			if (this.oParent.CivState.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))] == -1)
				goto L1a11;
			goto L189d;

		L1a11:			
			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].ActualSize <= 
				(this.oParent.CivState.WonderDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Price / 10))
				goto L189d;

			// Instruction address 0x1238:0x1a44, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				(int)this.oParent.CivState.WonderDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].RequiresTechnology);

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L1a53;

			goto L189d;

		L1a53:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oParent.CivState.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))] = (short)this.oCPU.AX.Word;
			
			this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].ShieldsCount = 0;

			// Instruction address 0x1238:0x1a6f, size: 5
			this.oParent.Segment_1866.F0_1866_250e_AddReplayData(10,
				this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1238:0x1a7f, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			// Instruction address 0x1238:0x1a8f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " (");

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x1238:0x1aa4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.CivState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Nationality);

			// Instruction address 0x1238:0x1ab4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")\nbuilds ");

			// Instruction address 0x1238:0x1ac6, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.CivState.WonderDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Name);

			// Instruction address 0x1238:0x1ad6, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			// Instruction address 0x1238:0x1afb, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Coins / 3, 
				0,
				(10 * this.oParent.CivState.WonderDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Price) -
					this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].ShieldsCount);

			this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Coins -= (short)this.oCPU.AX.Word;

			// Instruction address 0x1238:0x1b1e, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(
				this.oParent.CivState.Nations[this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].NationalityID].ShortTune, 0);

			this.oCPU.BX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] & 0x40) == 0)
				goto L17ef;

			this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.ForeignMinister;

			goto L17f2;

		L1b3e:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1238_1767");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1238_1b44()
		{
			this.oCPU.Log.EnterBlock("F0_1238_1b44()");

			// function body
			// Instruction address 0x1238:0x1b48, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x1c28, 0x1);
			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L1b6e;

			// Instruction address 0x1238:0x1b66, size: 5
			this.oParent.Segment_1000.F0_1000_04d4_TransformPaletteToColor(5, Color.FromRgb(0, 0, 0));

		L1b6e:
			// Instruction address 0x1238:0x1b6e, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x1238:0x1b7f, size: 5
			this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(this.oParent.CivState.HumanPlayerID, this.oParent.Var_d4cc_MapXCenter, this.oParent.Var_d75e_MapYCenter);

			// Instruction address 0x1238:0x1b97, size: 3
			F0_1238_1bb2_FillRectangleWithShadow(0, 97, 80, 103);

			// Instruction address 0x1238:0x1b9d, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x1238:0x1ba3, size: 3
			F0_1238_1beb();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x1c28, 0x0);

			// Instruction address 0x1238:0x1bac, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0626();

			// Far return
			this.oCPU.Log.ExitBlock("F0_1238_1b44");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		public void F0_1238_1bb2_FillRectangleWithShadow(int xPos, int yPos, int width, int height)
		{
			// function body
			// Instruction address 0x1238:0x1bc1, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_03ce_FillRectangleWithPattern(xPos, yPos, width, height);

			// Instruction address 0x1238:0x1be1, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a66_DrawShadowRectangle(xPos, yPos, width - 1, height - 1, 15, 8);
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1238_1beb()
		{
			this.oCPU.Log.EnterBlock("F0_1238_1beb()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x10);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.NE) goto L1bfc;
			goto L1c93;

		L1bfc:
			// Instruction address 0x1238:0x1bfc, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x1238:0x1c09, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10), "back0a.pal");

			this.oCPU.SI.Word = (ushort)this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].GovernmentType;
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Low = this.oCPU.ADD_UInt8(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Low);
			this.oCPU.CMP_UInt16(this.oCPU.SI.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L1c32;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x33);
			goto L1c4a;

		L1c32:
			// Instruction address 0x1238:0x1c3a, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.CivState.HumanPlayerID, (int)TechnologyEnum.Invention);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb), 0x6d);
			}

		L1c4a:
			// Instruction address 0x1238:0x1c52, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0xc1d6);

			// Instruction address 0x1238:0x1c62, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x1e56, 0xc5be);

			// Instruction address 0x1238:0x1c76, size: 5
			this.oParent.MSCAPI.memcpy(0xc744, 0xc35c, 0x180);

			// Instruction address 0x1238:0x1c86, size: 5
			this.oParent.Segment_1000.F0_1000_04aa_TransformPalette(5, 0xc5be);
			
			// Instruction address 0x1238:0x1c8e, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0626();

		L1c93:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1238_1beb");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="score"></param>
		public short F0_1238_1c98_GetPalacelLevel(short score)
		{
			// function body
			short palaceLevel = 0;

			do
			{
				palaceLevel += 5;
				score -= palaceLevel;
			} while (score > 0);

			palaceLevel /= 5;
			palaceLevel--;

			return palaceLevel;
		}
	}
}
