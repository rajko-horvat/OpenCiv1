using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Overlay_18
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public Overlay_18(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F18_0000_0000()
		{
			this.oCPU.Log.EnterBlock("F18_0000_0000()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x000c, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x0038, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x0000:0x0048, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4bc4, 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L0055:
			this.oCPU.AX.Word = 0x1a;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x0071, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4be2)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4be4)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4be6)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4be8)));

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x682a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xa);
			if (this.oCPU.Flags.L) goto L0055;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L0095:
			// Instruction address 0x0000:0x0099, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(240));

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x683e), this.oCPU.AX.Low);

			// Instruction address 0x0000:0x00ac, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(192));

			this.oCPU.AX.Low = this.oCPU.ADD_UInt8(this.oCPU.AX.Low, 0x8);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6852), this.oCPU.AX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6866), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x14);
			if (this.oCPU.Flags.L) goto L0095;

			// Instruction address 0x0000:0x00e0, size: 5
			this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(1, 30, 208, 223);

			// Instruction address 0x0000:0x00f8, size: 5
			this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(2, 11, 192, 207);

			// Instruction address 0x0000:0x0110, size: 5
			this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(3, 20, 224, 239);

			// Instruction address 0x0000:0x0128, size: 5
			this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(4, 8, 144, 159);

			// Instruction address 0x0000:0x0140, size: 5
			this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(5, 150, 128, 129);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

		L0154:
			// Instruction address 0x0000:0x0157, size: 5
			this.oParent.Segment_1000.F0_1000_03fa_StartPaletteCycleSlot(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x5);
			if (this.oCPU.Flags.LE) goto L0154;

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F18_0000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F18_0000_016d()
		{
			this.oCPU.Log.EnterBlock("F18_0000_016d()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x12);

			// Instruction address 0x0000:0x017b, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x682a), 0x4cda);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x1);

		L018f:
			// Instruction address 0x0000:0x0192, size: 5
			this.oParent.Segment_1000.F0_1000_042b_StopPaletteCycleSlot(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x5);
			if (this.oCPU.Flags.LE) goto L018f;

			// Instruction address 0x0000:0x01bc, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10), "back0a.pal");

			this.oCPU.AX.Word = (ushort)this.oGameData.Players[this.oGameData.HumanPlayerID].GovernmentType;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Low = this.oCPU.ADD_UInt8(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Low);

			// Instruction address 0x0000:0x01e0, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oGameData.HumanPlayerID, (int)TechnologyEnum.Invention);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb), 0x6d);
			}
		
			// Instruction address 0x0000:0x01f8, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0xc1d6);

			// Instruction address 0x0000:0x0208, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x4cea, 0xc5be);

			// Instruction address 0x0000:0x021c, size: 5
			this.oParent.MSCAPI.memcpy(0xc744, 0xc35c, 0x180);

			// Instruction address 0x0000:0x0237, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x0000:0x0243, size: 5
			this.oParent.Graphics.F0_VGA_0162_SetColorsFromColorStruct(0xc5be);
			
			// Instruction address 0x0000:0x024b, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_05dd();

			// Instruction address 0x0000:0x0250, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F18_0000_016d");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		/// <returns></returns>
		public ushort F18_0000_0259(short playerID, short param2, short param3)
		{
			this.oCPU.Log.EnterBlock($"F18_0000_0259({playerID}, {param2}, {param3})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x20);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.AX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMP_UInt16((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0275;
			this.oCPU.TEST_UInt8((byte)(this.oGameData.GameSettingFlags & 0xff), 0x20);
			if (this.oCPU.Flags.E) goto L027a;

		L0275:
			this.oCPU.AX.Word = 0x1;
			goto L027c;

		L027a:
			this.oCPU.AX.Word = 0;

		L027c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0286;
			goto L0325;

		L0286:
			// Instruction address 0x0000:0x0299, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			this.oCPU.SI.Word = (ushort)(playerID << 1);

			// Instruction address 0x0000:0x02ba, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 8,
				this.oParent.Array_1946[playerID]);

			// Instruction address 0x0000:0x02ca, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[playerID].Nationality);

			// Instruction address 0x0000:0x02da, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " SpaceShip: X.S.S. ");

			// Instruction address 0x0000:0x02e6, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x02f9, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[playerID].Name);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb9ff),
				(byte)this.oGameData.Players[playerID].Nationality[0]);

			// Instruction address 0x0000:0x031d, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 1, 0);

		L0325:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);

		L032a:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xdea2), 0x0);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 10);
			if (this.oCPU.Flags.L) goto L032a;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);

		L0343:
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].XPos);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10),
				this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].YPos);

			this.oCPU.AX.Word = 0xb4;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.BX.Word = this.oCPU.ADD_UInt16(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ADD_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));

			int iPos = (12 * this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].XPos) +
				this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].YPos;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8),
				(ushort)((short)this.oGameData.Players[playerID].SpaceshipData[iPos]));

			if (this.oGameData.Players[playerID].SpaceshipData[iPos] == -1)
				goto L04b0;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L03b7;

			// Instruction address 0x0000:0x03af, size: 5
			this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) * 16) - 16,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)) * 16) + 8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.AX.Word << 1 + 0x682a)));

		L03b7:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x6);
			if (this.oCPU.Flags.GE) goto L03c8;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x3);
			if (this.oCPU.Flags.E) goto L03c8;
			this.oCPU.AX.Word = 0x1;
			goto L03cb;

		L03c8:
			this.oCPU.AX.Word = 0x2;

		L03cb:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x6);
			if (this.oCPU.Flags.GE) goto L03d9;
			this.oCPU.AX.Word = 0x1;
			goto L03dc;

		L03d9:
			this.oCPU.AX.Word = 0x2;

		L03dc:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x3);
			if (this.oCPU.Flags.GE) goto L03ea;
			this.oCPU.AX.Word = 0x1;
			goto L03ec;

		L03ea:
			this.oCPU.AX.Word = 0;

		L03ec:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);
			goto L045a;

		L03f6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))));

		L03f9:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0457;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)));
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.DI.Word = this.oCPU.ADD_UInt16(this.oCPU.DI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)));
			
			F18_0000_0c11_GetSpaceShipData(playerID, (short)((ushort)(this.oCPU.SI.Word + 0x1)), (short)this.oCPU.DI.Word);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word));

			F18_0000_0c11_GetSpaceShipData(playerID, (short)((ushort)(this.oCPU.SI.Word - 0x1)), (short)this.oCPU.DI.Word);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word));
			
			F18_0000_0c11_GetSpaceShipData(playerID, (short)this.oCPU.SI.Word, (short)((ushort)(this.oCPU.DI.Word + 0x1)));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word));
			
			F18_0000_0c11_GetSpaceShipData(playerID, (short)this.oCPU.SI.Word, (short)((ushort)(this.oCPU.DI.Word - 0x1)));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word));

			goto L03f6;

		L0457:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

		L045a:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0469;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), 0x0);
			goto L03f9;

		L0469:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x0);
			if (this.oCPU.Flags.E) goto L047a;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xdea2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xdea2))));
			goto L04c9;

		L047a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L04c9;

			// Instruction address 0x0000:0x04a6, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(
				(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) << 4) - 16,
				(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)) << 4) + 8,
				(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)) << 4) - 1,
				(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)) << 4) - 1,
				12);

			goto L04c9;

		L04b0:
			if (this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].BitmapID < 3)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);
			}

		L04c9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));

			if (this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].XPos != -1)
				goto L0343;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);

		L04ef:
			this.oCPU.AX.Word = 0x1a;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4be0));
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xdea2)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xa);
			if (this.oCPU.Flags.L) goto L04ef;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x50);
			if (this.oCPU.Flags.L) goto L0534;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L0534;

			// Instruction address 0x0000:0x052c, size: 5
			this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, 152, 88, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6834));

		L0534:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L0592;

			this.oCPU.SI.Word = (ushort)(playerID << 1);

			// Instruction address 0x0000:0x0559, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 240, 8, 80, 192, 
				this.oParent.Array_1946[playerID]);

			// Instruction address 0x0000:0x0571, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 0, 8, 0, 199, this.oParent.Array_1946[playerID]);

			// Instruction address 0x0000:0x058a, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 0, 199, 240, 199, this.oParent.Array_1946[playerID]);

		L0592:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x64);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x10);

			// Instruction address 0x0000:0x05ab, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA("Population:", 242, 16, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x8));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x05d5, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeae), 10));

			// Instruction address 0x0000:0x05e5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "0,000");

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L0609;

			// Instruction address 0x0000:0x0601, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA(0xba06, 242, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0);

		L0609:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x8));

			// Instruction address 0x0000:0x0619, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xdeae), 1, 99);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x64;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeb0));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0638, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Support: ");

			// Instruction address 0x0000:0x0658, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 10));

			// Instruction address 0x0000:0x0668, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "%");

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x64);
			if (this.oCPU.Flags.GE) goto L067b;
			this.oCPU.AX.Word = 0x4;
			goto L067d;

		L067b:
			this.oCPU.AX.Word = 0;

		L067d:
			// Instruction address 0x0000:0x0689, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA(0xba06, 
				242, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 
				this.oCPU.AX.Low);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x8));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L06b9;

			// Instruction address 0x0000:0x06a5, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0, 100);

			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x64;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

		L06b9:
			// Instruction address 0x0000:0x06c9, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xdeae) + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xdeb0), 
				1, 99);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc8;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeb2));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x06e8, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Energy: ");

			// Instruction address 0x0000:0x0708, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 10));

			// Instruction address 0x0000:0x0718, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "%");

			// Instruction address 0x0000:0x072a, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0, 100);

			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x64;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L0764;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.CX.Word);
			if (this.oCPU.Flags.GE) goto L074e;
			this.oCPU.AX.Word = 0x4;
			goto L0750;

		L074e:
			this.oCPU.AX.Word = 0;

		L0750:
			// Instruction address 0x0000:0x075c, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA(0xba06, 
				242,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 
				this.oCPU.AX.Low);

		L0764:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x10));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L0784;
			
			// Instruction address 0x0000:0x077c, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA("Mass:", 242, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0);

		L0784:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x8));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x07ac, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) / 10), 10));

			// Instruction address 0x0000:0x07bc, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ",");

			// Instruction address 0x0000:0x07e3, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) / 10), 10));

			// Instruction address 0x0000:0x07f3, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "00 tons");

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L0817;

			// Instruction address 0x0000:0x080f, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA(0xba06, 242, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0);

		L0817:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x8));

			// Instruction address 0x0000:0x0827, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xdea8), 1, 99);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x64;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeaa));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0846, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Fuel: ");

			// Instruction address 0x0000:0x0866, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 10));

			// Instruction address 0x0000:0x0876, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "%");

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L08a5;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x64);
			if (this.oCPU.Flags.GE) goto L088f;
			this.oCPU.AX.Word = 0x4;
			goto L0891;

		L088f:
			this.oCPU.AX.Word = 0;

		L0891:
			// Instruction address 0x0000:0x089d, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA(0xba06, 
				242, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Low);

		L08a5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x8));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L08c5;

			// Instruction address 0x0000:0x08bd, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA("Flight Time:", 242, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0);

		L08c5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x8));

			// Instruction address 0x0000:0x08dc, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				10 * this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xdea8), 
				0, 10 * this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xdeaa));

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.INC_UInt16(this.oCPU.CX.Word);
			this.oCPU.AX.Word = 0x32;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x96);
			if (this.oCPU.Flags.LE) goto L0904;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x96);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0xa;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), this.oCPU.AX.Word));

		L0904:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0928, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) / 10), 10));

			// Instruction address 0x0000:0x0938, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".");

			// Instruction address 0x0000:0x095f, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) / 10), 10));

			// Instruction address 0x0000:0x096f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Years");

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L0993;

			// Instruction address 0x0000:0x098b, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA(0xba06, 242, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0);

		L0993:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x10));

			// Instruction address 0x0000:0x09a1, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0, 100);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L09c8;

			// Instruction address 0x0000:0x09c0, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA("Prob. of Success", 242, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0);

		L09c8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x8));

			// Instruction address 0x0000:0x09d4, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "--- ");

			// Instruction address 0x0000:0x09f4, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 10));

			// Instruction address 0x0000:0x0a04, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "% ---");

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L0a28;

			// Instruction address 0x0000:0x0a20, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA(0xba06, 242, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0);

		L0a28:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x10));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeae), 0x0);
			if (this.oCPU.Flags.NE) goto L0a38;
			param3 = 0;

		L0a38:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.SpaceshipFlags);
			if (this.oCPU.Flags.E) goto L0a7e;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L0a4f;
			goto L0ada;

		L0a4f:
			// Instruction address 0x0000:0x0a70, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA(((this.oGameData.Players[playerID].SpaceshipETAYear < oParent.GameData.Year) ? "Landed!" : "Launched!"),
				242,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x10));
			goto L0ada;

		L0a7e:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0xa;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.Year);
			this.oGameData.Players[playerID].SpaceshipETAYear = (short)this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMP_UInt16((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0ada;
			
			if (param2 >= 0) goto L0ada;
			
			if (param3 == 0) goto L0ada;

			// Instruction address 0x0000:0x0ab7, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA("LAUNCH", 256, 190, 0);

			// Instruction address 0x0000:0x0ad2, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(242, 188, 76, 9, 0);

		L0ada:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L0ae5;

			// Instruction address 0x0000:0x0ae0, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

		L0ae5:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L0af3;
			goto L0bfc;

		L0af3:
			F18_0000_0c49();

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.SpaceshipFlags);
			if (this.oCPU.Flags.E) goto L0b14;
			this.oCPU.AX.Word = 0x2;
			goto L0b17;

		L0b14:
			this.oCPU.AX.Word = 0x4;

		L0b17:
			// Instruction address 0x0000:0x0b18, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer((short)this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0b20, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();

			// Instruction address 0x0000:0x0b25, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0b3a;

			param2--;
			if (param2 == 0) goto L0b3a;

			if (this.oParent.Var_db3a == 0) goto L0af3;

		L0b3a:
			if (param2 == 0 || this.oParent.Var_db3a != 0) goto L0b4f;

			// Instruction address 0x0000:0x0b47, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0ac9_GetNavigationKey();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);

		L0b4f:
			this.oCPU.AX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMP_UInt16((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0b5a;
			goto L0bfc;

		L0b5a:
			if (param3 != 0) goto L0b63;
			goto L0bfc;

		L0b63:
			if (param2 < 0) goto L0b6c;
			goto L0bfc;

		L0b6c:
			if (this.oParent.Var_db3a == 0 || this.oParent.Var_db3c <= 242) goto L0b83;

			this.oCPU.CMP_UInt16(this.oParent.Var_db3e, 0xbe);
			if (this.oCPU.Flags.GE) goto L0b89;

		L0b83:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x6c);
			if (this.oCPU.Flags.NE) goto L0bfc;

		L0b89:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oGameData.HumanPlayerID & 0xff);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.SpaceshipFlags);
			if (this.oCPU.Flags.NE) goto L0bfc;

			// Instruction address 0x0000:0x0ba0, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Confirm spaceship launch.\n(");

			// Instruction address 0x0000:0x0bc0, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 10));

			// Instruction address 0x0000:0x0bd0, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "% chance of success)\n No Launch\n Launch CONFIRMED!\n");

			// Instruction address 0x0000:0x0be4, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 100);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L0bfc;

			F18_0000_15c3(this.oGameData.HumanPlayerID);

		L0bfc:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeae);
			this.oGameData.Players[playerID].SpaceshipPopulation = (short)this.oCPU.AX.Word;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F18_0000_0259");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// Gets data about Space Ship
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F18_0000_0c11_GetSpaceShipData(short playerID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F18_0000_0c11_GetSpaceShipData({playerID}, {xPos}, {yPos})");

			// function body
			sbyte sdata = this.oGameData.Players[playerID].SpaceshipData[(12 * xPos) + yPos];

			if (sdata == -1 || sdata >= 0x3)
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.AX.Word = 1;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F18_0000_0c11_GetSpaceShipData");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F18_0000_0c49()
		{
			this.oCPU.Log.EnterBlock("F18_0000_0c49()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L0cff;

		L0c57:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x683e), this.oCPU.ADD_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x683e)), 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x7);

		L0c64:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x683e)), 0xf0);
			if (this.oCPU.Flags.B) goto L0c8d;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x683e), 0x1);

			// Instruction address 0x0000:0x0c77, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(192));

			this.oCPU.AX.Low = this.oCPU.ADD_UInt8(this.oCPU.AX.Low, 0x8);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6852), this.oCPU.AX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6866), 0x0);

		L0c8d:
			// Instruction address 0x0000:0x0c9c, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(0, 
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(0x683e + this.oCPU.BX.Word)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(0x6852 + this.oCPU.BX.Word)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0cf4;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6866), 0x1);

			// Instruction address 0x0000:0x0cc6, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x683e)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6852)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			goto L0cfc;

		L0cd0:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x683e), this.oCPU.INC_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x683e))));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x3);
			goto L0c64;

		L0cde:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x687a), 0x1);
			if (this.oCPU.Flags.E) goto L0cec;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x683e), this.oCPU.INC_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x683e))));

		L0cec:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x8);
			goto L0c64;

		L0cf4:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6866), 0x0);

		L0cfc:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L0cff:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x14);
			if (this.oCPU.Flags.GE) goto L0d47;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6866)), 0x0);
			if (this.oCPU.Flags.E) goto L0d2a;

			// Instruction address 0x0000:0x0d22, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x683e)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6852)),
				0);

		L0d2a:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L0d35;
			goto L0c57;

		L0d35:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L0cd0;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.E) goto L0cde;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.E) goto L0cde;
			goto L0c64;

		L0d47:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x687a, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x687a)));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F18_0000_0c49");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="param2"></param>
		/// <returns></returns>
		public ushort F18_0000_0d4f(short playerID, short param2)
		{
			this.oCPU.Log.EnterBlock($"F18_0000_0d4f({playerID}, {param2})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x6);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0;
			this.oGameData.AISpaceshipSuccessRate = (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x3e7);
			this.oCPU.CMP_UInt16((ushort)param2, 0x2);
			if (this.oCPU.Flags.E) goto L0d9b;
			this.oCPU.SI.Word = (ushort)this.oGameData.Players[playerID].SpaceshipETAYear;
			this.oCPU.CMP_UInt16(this.oCPU.SI.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L0da0;
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.Year);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xf);
			if (this.oCPU.Flags.GE) goto L0da0;
			this.oCPU.DI.Word = (ushort)this.oGameData.Players[this.oGameData.HumanPlayerID].SpaceshipETAYear;
			this.oCPU.CMP_UInt16(this.oCPU.SI.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.L) goto L0d9b;
			this.oCPU.CMP_UInt16(this.oCPU.DI.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L0da0;

		L0d9b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x21);

		L0da0:
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			int iPos = (12 * this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].XPos) +
				this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].YPos;

			if (this.oGameData.Players[playerID].SpaceshipData[iPos] != -1)
				goto L0e1a;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3e7);
			if (this.oCPU.Flags.NE) goto L0df7;

			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)param2);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x3);
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			if (this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].BitmapID >= (short)this.oCPU.CX.Word)
			{
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			}

		L0df7:
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			
			this.oCPU.AX.Word = (ushort)((short)this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].BitmapID);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.IDIV_UInt8(this.oCPU.AX, this.oCPU.CX.Low);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, (ushort)param2);
			if (this.oCPU.Flags.NE) goto L0e1a;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L0e68;

		L0e1a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].XPos == -1)
				goto L0e68;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4);
			if (this.oCPU.Flags.GE) goto L0e41;
			goto L0da0;

		L0e41:
			this.oCPU.CMP_UInt16((ushort)param2, 0x2);
			if (this.oCPU.Flags.NE) goto L0e4a;
			goto L0da0;

		L0e4a:
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)param2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			// Instruction address 0x0000:0x0e59, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xe68)));
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L0e68;

			goto L0da0;

		L0e68:
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].XPos != -1)
				goto L0e89;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3e7);
			if (this.oCPU.Flags.NE) goto L0e89;
			this.oCPU.AX.Word = 0x2;
			goto L0f7d;

		L0e89:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.E) goto L0e95;

		L0e8f:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			goto L0f7d;

		L0e95:
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].XPos != -1)
				goto L0eb6;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3e7);
			if (this.oCPU.Flags.E) goto L0eb6;

			this.oCPU.AX.Word = 0x1;
			goto L0f7d;

		L0eb6:
			// Instruction address 0x0000:0x0ec9, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x0000:0x0ede, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[playerID].Nation);

			// Instruction address 0x0000:0x0eee, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " build space ship.\n");

			// Instruction address 0x0000:0x0f06, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 96, 15);

			// Instruction address 0x0000:0x0f0e, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			F18_0000_0000();

			// Instruction address 0x0000:0x0f17, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			iPos = (12 * this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].XPos) +
				this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].YPos;

			this.oGameData.Players[playerID].SpaceshipData[iPos] =
				this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].BitmapID;

			F18_0000_0259(playerID, -1, 0);

			this.oGameData.AISpaceshipSuccessRate = (short)this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.CX.Low = this.oCPU.ADD_UInt8(this.oCPU.CX.Low, 0x8);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oGameData.SpaceshipFlags |= (short)this.oCPU.AX.Word;

			// Instruction address 0x0000:0x0f71, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			F18_0000_016d();

			goto L0e8f;

		L0f7d:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F18_0000_0d4f");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="param2"></param>
		public void F18_0000_0f83(short playerID, ushort param2)
		{
			this.oCPU.Log.EnterBlock($"F18_0000_0f83({playerID}, {param2})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x16);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x0f9d, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			F18_0000_0000();

			F18_0000_0259(playerID, 15, 0);

			// Instruction address 0x0000:0x0fbb, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

		L0fc0:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 0x2);

			this.oCPU.CMP_UInt16(param2, 0x1);
			if (this.oCPU.Flags.NE) goto L1000;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x687c);
			this.oParent.Var_b276 = (short)this.oCPU.AX.Word;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L0fde;
			goto L12c2;

		L0fde:
			// Instruction address 0x0000:0x0fea, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0x4df9, 100, 80);

			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x3);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L1000;
			goto L12de;

		L1000:
			this.oCPU.CMP_UInt16(param2, 0x2);
			if (this.oCPU.Flags.NE) goto L1036;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x687e);
			this.oParent.Var_b276 = (short)this.oCPU.AX.Word;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x7);
			if (this.oCPU.Flags.NE) goto L1014;
			goto L12c2;

		L1014:
			// Instruction address 0x0000:0x1020, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0x4e12, 100, 80);

			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x5);
			if (this.oCPU.Flags.NE) goto L1036;
			goto L12de;

		L1036:
			this.oCPU.CMP_UInt16(param2, 0x0);
			if (this.oCPU.Flags.E) goto L1044;
			goto L1169;

		L1044:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x63);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);
			goto L1078;

		L1055:
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].BitmapID >= 3)
				goto L1075;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x63);
			if (this.oCPU.Flags.NE) goto L1075;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);

		L1075:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

		L1078:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x21);
			if (this.oCPU.Flags.GE) goto L10c3;
			
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			int iPos = (12 * this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].XPos) +
				this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].YPos;
			
			if (this.oGameData.Players[playerID].SpaceshipData[iPos] == -1)
				goto L1055;

			if (this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].BitmapID < 3)
				goto L1075;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			goto L1075;

		L10c3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x63);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x21);

		L10d2:
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			iPos = (12 * this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].XPos) +
				this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].YPos;

			if (this.oGameData.Players[playerID].SpaceshipData[iPos] == -1)
				goto L1117;

			if (this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].BitmapID < 3)
				goto L1137;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			goto L1137;

		L1117:
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].BitmapID >= 3)
				goto L1137;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x63);
			if (this.oCPU.Flags.NE) goto L1137;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

		L1137:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0)), 0xff);
			if (this.oCPU.Flags.NE) goto L10d2;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CX.Word = this.oCPU.SUB_UInt16(this.oCPU.CX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.GE) goto L1164;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));

		L115f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			goto L11cf;

		L1164:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			goto L115f;

		L1169:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);

		L116e:
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			iPos = (12 * this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].XPos) +
				this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].YPos;
			
			if (this.oGameData.Players[playerID].SpaceshipData[iPos] != -1)
				goto L11b6;

			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].BitmapID == this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)))
				goto L11cf;

		L11b6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].XPos != -1)
				goto L116e;

		L11cf:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xffff);
			if (this.oCPU.Flags.E) goto L120c;
			
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			iPos = (12 * this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].XPos) +
				this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].YPos;

			this.oGameData.Players[playerID].SpaceshipData[iPos] =
				this.oGameData.SpaceshipCells[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].BitmapID;

			goto L1278;

		L120c:
			this.oCPU.CMP_UInt16(param2, 0x0);
			if (this.oCPU.Flags.E) goto L1278;
			this.oCPU.BX.Word = param2;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x687a), this.oCPU.OR_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x687a)), this.oCPU.AX.Word));

			// Instruction address 0x0000:0x122b, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "No further ");

			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, param2);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			this.oCPU.CX.Word = 0x1a;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x4bd0);
			// Instruction address 0x0000:0x1249, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x1259, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " required.\n");

			// Instruction address 0x0000:0x126d, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 120, 80);

			goto L0fc0;

		L1278:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.CX.Low = this.oCPU.ADD_UInt8(this.oCPU.CX.Low, 0x8);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.SpaceshipFlags);
			if (this.oCPU.Flags.NE) goto L12c2;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L128e:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = this.oCPU.ADD_UInt8(this.oCPU.CX.Low, 0x8);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.SpaceshipFlags);
			if (this.oCPU.Flags.NE)
			{
				this.oGameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].ContactPlayerCountdown = 0;
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L128e;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.CX.Low = this.oCPU.ADD_UInt8(this.oCPU.CX.Low, 0x8);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oGameData.SpaceshipFlags |= (short)this.oCPU.AX.Word;

		L12c2:
			F18_0000_0259(playerID, -1, 1);
			
			this.oGameData.Players[this.oGameData.HumanPlayerID].SpaceshipSuccessRate = (short)this.oCPU.AX.Word;

		L12de:
			F18_0000_016d();

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F18_0000_0f83");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F18_0000_1527()
		{
			this.oCPU.Log.EnterBlock("F18_0000_1527()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x4);
			this.oCPU.TEST_UInt16((ushort)this.oGameData.SpaceshipFlags, 0xfe00);
			if (this.oCPU.Flags.NE) goto L1538;
			goto L15bf;

		L1538:
			// Instruction address 0x0000:0x1540, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Which nation?\n ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L154d:
			// Instruction address 0x0000:0x155a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Nationality);

			// Instruction address 0x0000:0x156a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L154d;
			this.oCPU.AX.Word = (ushort)this.oGameData.SpaceshipFlags;
			this.oCPU.CX.Low = 0x9;
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Low = this.oCPU.XOR_UInt8(this.oCPU.AX.Low, 0xff);
			this.oParent.Var_b276 = (short)this.oCPU.AX.Word;

			// Instruction address 0x0000:0x1593, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L15bf;

			F18_0000_0000();

			F18_0000_0259(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), -1, 1);

			F18_0000_016d();

		L15bf:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F18_0000_1527");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F18_0000_15c3(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F18_0000_15c3({playerID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oGameData.SpaceshipFlags |= (short)this.oCPU.AX.Word;

			// Instruction address 0x0000:0x15eb, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x0000:0x15f3, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x1605, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[playerID].Nation);

			// Instruction address 0x0000:0x1615, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " LAUNCH space ship!");

			// Instruction address 0x0000:0x162d, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 92, 15);

			// Instruction address 0x0000:0x163d, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Estimate arrival in ");

			// Instruction address 0x0000:0x165e, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oGameData.Players[playerID].SpaceshipETAYear, 10));

			// Instruction address 0x0000:0x166e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			// Instruction address 0x0000:0x1686, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 100, 15);

			this.oGameData.Players[playerID].SpaceshipLaunchYear = oParent.GameData.Year;

			if (playerID == this.oGameData.HumanPlayerID)
				goto L16a1;

			F18_0000_0000();

		L16a1:
			// Instruction address 0x0000:0x16a1, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			// Instruction address 0x0000:0x16a6, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			F18_0000_0259(playerID, -1, 0);
			
			if (playerID == this.oGameData.HumanPlayerID) goto L16ce;

			F18_0000_016d();

		L16ce:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F18_0000_15c3");
		}
	}
}
