using System;
using Avalonia.Media;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class GameReplay
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public GameReplay(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F9_0000_0000()
		{
			this.oCPU.Log.EnterBlock("F9_0000_0000()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x24);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			TerrainTypeEnum local_22;

		L0007:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680e), 0x0);
			if (this.oCPU.Flags.NE) goto L0027;

			// Instruction address 0x0000:0x001a, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0x3fb0, 100, 80);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x680a, this.oCPU.AX.Word);
			goto L002d;

		L0027:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x680a, 0x4);

		L002d:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680a), 0x0);
			if (this.oCPU.Flags.G) goto L0037;
			goto L089e;

		L0037:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680a), 0x3);
			if (this.oCPU.Flags.NE) goto L0085;

			// Instruction address 0x0000:0x004a, size: 5
			this.oParent.MSCAPI.open("replay.txt", 0x8301, 0x80);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x680c, this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L0081;

			// Instruction address 0x0000:0x0062, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "File Error\n");

			// Instruction address 0x0000:0x0076, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			goto L089e;

		L0081:
			F9_0000_0c30();

		L0085:
			// Instruction address 0x0000:0x0085, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);

		L0094:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.ES.Word = 0x3725; // segment
			this.oCPU.WriteUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x80);
			if (this.oCPU.Flags.L) goto L0094;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x1);

		L00b3:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			this.oCPU.AX.Word = (ushort)this.oGameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].NationalityID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x8);
			if (this.oCPU.Flags.L) goto L00b3;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x1);
			goto L00e8;

		L00cf:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));

		L00d2:
			this.oGameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].NationalityID = (short)this.oCPU.AX.Word;

			F9_0000_0d5d(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));

		L00e5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));

		L00e8:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x8);
			if (this.oCPU.Flags.GE) goto L010c;

			this.oCPU.AX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L00e5;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.PlayerIdentityFlags);
			if (this.oCPU.Flags.E) goto L00cf;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x8);
			goto L00d2;

		L010c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680a), 0x4);
			if (this.oCPU.Flags.E) goto L0191;

			// Instruction address 0x0000:0x0126, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);
			goto L0184;

		L0135:
			// Instruction address 0x0000:0x0155, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) * 4,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) * 4) + 4,
				4, 4, 8);

		L0138:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L0160:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x50);
			if (this.oCPU.Flags.GE) goto L0181;

			// Instruction address 0x0000:0x016c, size: 5
			local_22 = this.oGameData.Map[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].TerrainType;

			if (local_22 != TerrainTypeEnum.Water) goto L0135;

			// Instruction address 0x0000:0x0155, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) * 4,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) * 4) + 4,
				4, 4, 1);

			goto L0138;

		L0181:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

		L0184:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x31);
			if (this.oCPU.Flags.GE) goto L0191;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			goto L0160;

		L0191:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L0196:
			this.oCPU.AX.Word = (ushort)this.oGameData.ReplayDataLength;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L01a1;
			goto L083d;

		L01a1:
			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0xf);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.AX.High = 0;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.AX.High = 0;
			this.oCPU.CX.High = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.CX.Low = 0;
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			F9_0000_097c(this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6810, 0xffff);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0214, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(Math.Abs((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))), 10));

			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) < 0)
			{
				// Instruction address 0x0000:0x022f, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " BC");
			}
			else
			{
				// Instruction address 0x0000:0x022f, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " AD");
			}

			// Instruction address 0x0000:0x023f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ": ");

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xc);
			if (this.oCPU.Flags.BE) goto L0255;
			goto L0826;

		L0255:
			switch(this.oCPU.AX.Word)
			{
				case 0:
					goto L025d;
				case 1:
					goto L03ae;
				case 2:
					goto L0414;
				case 3:
					goto L0826;
				case 4:
					goto L0453;
				case 5:
					goto L04a8;
				case 6:
					goto L0826;
				case 7:
					goto L04fb;
				case 8:
					goto L025d;
				case 9:
					goto L054f;
				case 10:
					goto L05b9;
				case 11:
					goto L065c;
				case 12:
					goto L0779;
			}

		L025d:
			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6810, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6810), 0xff);
			if (this.oCPU.Flags.NE) goto L02a6;
			goto L0336;

		L02a6:
			// Instruction address 0x0000:0x02b4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6810)].Nation);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x1);
			if (this.oCPU.Flags.NE) goto L02e2;

			// Instruction address 0x0000:0x02ca, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " found the city of ");

			F9_0000_09dc(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6810),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

			goto L0300;

		L02e2:
			// Instruction address 0x0000:0x02ea, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " capture ");

			F9_0000_0a22(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6810),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

		L0300:
			uint uiCityNameID = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			ushort usStringOffset = (ushort)(0xba06 + this.oParent.MSCAPI.strlen(0xba06));

			for (int i = 0; i < 0xd; i++)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(usStringOffset + i), (byte)this.oGameData.CityNames[uiCityNameID][i]);
			}

			F9_0000_08a3();

			goto L0388;

		L0336:
			uiCityNameID = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			usStringOffset = (ushort)(0xba06 + this.oParent.MSCAPI.strlen(0xba06));

			for (int i = 0; i < 0xd; i++)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(usStringOffset + i), (byte)this.oGameData.CityNames[uiCityNameID][i]);
			}

			// Instruction address 0x0000:0x036b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " destroyed");

			F9_0000_08a3();

			F9_0000_0a22(
				0xffff,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

		L0388:
			F9_0000_0ac8(
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680a), 0x1);
			if (this.oCPU.Flags.E) goto L039f;
			goto L0826;

		L039f:
			// Instruction address 0x0000:0x03a3, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(30);

			goto L0826;

		L03ae:
			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.AX.High = 0;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0xf);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			// Instruction address 0x0000:0x03e0, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].Nation);

			// Instruction address 0x0000:0x03f0, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " declare war on ");

		L03eb:
			// Instruction address 0x0000:0x0405, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Nation);

		L040d:
			F9_0000_08a3();

			goto L0826;

		L0414:
			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.AX.High = 0;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0xf);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			// Instruction address 0x0000:0x0446, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].Nation);

			// Instruction address 0x0000:0x03f0, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " make peace with ");

			goto L03eb;

		L0453:
			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6810, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			// Instruction address 0x0000:0x0483, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6810)].Nation);

			// Instruction address 0x0000:0x0493, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " discover ");

			this.oParent.MSCAPI.strcat(0xba06, 
				this.oGameData.Static.Technologies[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Name);

			goto L040d;

		L04a8:
			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6810, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			// Instruction address 0x0000:0x04d8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6810)].Nation);

			// Instruction address 0x0000:0x04e8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " produce first ");

			// Instruction address 0x0000:0x0405, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Name);

			goto L040d;

		L04fb:
			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6810, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			// Instruction address 0x0000:0x052b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6810)].Nation);

			// Instruction address 0x0000:0x053b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " form ");

			// Instruction address 0x0000:0x0405, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.Array_1966[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))]);

			goto L040d;

		L054f:
			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6810, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			// Instruction address 0x0000:0x057f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6810)].Nation);

			// Instruction address 0x0000:0x058f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " build ");

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x7);
			if (this.oCPU.Flags.G) goto L05ad;

			// Instruction address 0x0000:0x05a5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "the ");

		L05ad:
			// Instruction address 0x0000:0x0405, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oGameData.Static.Wonders[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Name);

			goto L040d;

		L05b9:
			this.oCPU.AX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6810, this.oCPU.AX.Word);

			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			// Instruction address 0x0000:0x05fd, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[this.oGameData.HumanPlayerID].Nation);

			// Instruction address 0x0000:0x060d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ": ");

			// Instruction address 0x0000:0x062d, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 10));

			// Instruction address 0x0000:0x063d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " cities; ");

			// Instruction address 0x0000:0x064e, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0337(
				this.oCPU.ReadInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));

			// Instruction address 0x0000:0x0405, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " population");

			goto L040d;

		L065c:
			// Instruction address 0x0000:0x0664, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "*** ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L0671:
			this.oCPU.TEST_UInt8(this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))], 0xf0);
			if (this.oCPU.Flags.E) goto L06e8;

			// Instruction address 0x0000:0x069c, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) << 1) + 1), 10));

			// Instruction address 0x0000:0x06ac, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ":");

			// Instruction address 0x0000:0x06d0, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oGameData.Players[this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))] >> 4].Nation);

			// Instruction address 0x0000:0x06e0, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " ");

		L06e8:
			this.oCPU.TEST_UInt8(this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))], 0xf);
			if (this.oCPU.Flags.E) goto L075d;

			// Instruction address 0x0000:0x0714, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) << 1) + 2), 10));

			// Instruction address 0x0000:0x0724, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ":");

			// Instruction address 0x0000:0x0745, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oGameData.Players[this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))] & 0xf].Nation);

			// Instruction address 0x0000:0x0755, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " ");

		L075d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x4);
			if (this.oCPU.Flags.GE) goto L076c;
			goto L0671;

		L076c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680a), 0x3);
			if (this.oCPU.Flags.E) goto L0776;
			goto L0826;

		L0776:
			goto L040d;

		L0779:
			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6810, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.AX.Low = this.oGameData.ReplayData[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			// Instruction address 0x0000:0x07a9, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6810)].Nationality);

			// Instruction address 0x0000:0x07b9, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " civilization destroyed by ");

			// Instruction address 0x0000:0x07ce, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].Nation);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680a), 0x4);
			if (this.oCPU.Flags.NE) goto L07f3;
			this.oCPU.AX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L07f3;

			F9_0000_0f79(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6810),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

		L07f3:
			this.oGameData.Players[this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6810)].NationalityID ^= 8;

			F9_0000_0d5d(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6810));
			
			goto L040d;

		L0826:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680a), 0x2);
			if (this.oCPU.Flags.E) goto L0830;
			goto L0196;

		L0830:
			// Instruction address 0x0000:0x0830, size: 5
			this.oParent.MSCAPI.getch();

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1b);
			if (this.oCPU.Flags.E) goto L083d;
			goto L0196;

		L083d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x1);

		L0842:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20));
			this.oGameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].NationalityID = (short)this.oCPU.AX.Word;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x8);
			if (this.oCPU.Flags.L) goto L0842;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x1);

		L085c:
			this.oCPU.AX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L086e;

			F9_0000_0d5d(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));

		L086e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x8);
			if (this.oCPU.Flags.L) goto L085c;

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x0000:0x087c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680a), 0x3);
			if (this.oCPU.Flags.NE) goto L0894;
			
			// Instruction address 0x0000:0x088c, size: 5
			this.oParent.MSCAPI.close((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680c));

		L0894:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680a), 0x3);
			if (this.oCPU.Flags.GE) goto L089e;
			goto L0007;

		L089e:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F9_0000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F9_0000_08a3()
		{
			this.oCPU.Log.EnterBlock("F9_0000_08a3()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680a), 0x4);
			if (this.oCPU.Flags.NE) goto L08b3;
			goto L0978;

		L08b3:
			this.oCPU.AX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6810), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L08c8;

			// Instruction address 0x0000:0x08c0, size: 5
			this.oParent.MSCAPI.strupr(0xba06);

		L08c8:
			// Instruction address 0x0000:0x08dc, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 8, 15);

			// Instruction address 0x0000:0x08f3, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA(0xba06, 4, 1, 0);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680a), 0x3);
			if (this.oCPU.Flags.NE) goto L0935;

			// Instruction address 0x0000:0x0906, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0xd);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba07), 0xa);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba08), 0x0);
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);

			// Instruction address 0x0000:0x092d, size: 5
			this.oParent.MSCAPI.write((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680c), 0xba06, this.oCPU.AX.Word);

		L0935:
			// Instruction address 0x0000:0x093d, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06, 312);

			// Instruction address 0x0000:0x0959, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 8, 15);

			// Instruction address 0x0000:0x0970, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA(0xba06, 4, 1, 0);

		L0978:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F9_0000_08a3");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <returns></returns>
		public ushort F9_0000_097c(ushort param1)
		{
			this.oCPU.Log.EnterBlock($"F9_0000_097c({param1})");

			// function body
			if (param1 > 250)
			{
				param1 -= 250;

				if (param1 > 50)
				{
					param1 -= 50;

					if (param1 > 50)
					{
						param1 -= 50;

						if (param1 > 50)
						{
							param1 -= 50;

							this.oCPU.AX.Word = (ushort)(param1 + 1850);
						}
						else
						{
							this.oCPU.AX.Word = (ushort)((param1 << 1) + 1750);
						}
					}
					else
					{
						this.oCPU.AX.Word = (ushort)((param1 * 5) + 1500);
					}
				}
				else
				{
					this.oCPU.AX.Word = (ushort)((param1 * 10) + 1000);
				}
			}
			else
			{
				this.oCPU.AX.Word = (ushort)((param1 * 20) - 4000);
			}

			// Far return
			this.oCPU.Log.ExitBlock("F9_0000_097c");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		public void F9_0000_09dc(ushort param1, ushort param2, ushort param3)
		{
			this.oCPU.Log.EnterBlock($"F9_0000_09dc({param1}, {param2}, {param3})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L09ed;

		L09ea:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L09ed:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.GE) goto L0a1d;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.ES.Word = 0x3725; // segment
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x0)), 0xffff);
			if (this.oCPU.Flags.NE) goto L09ea;

			this.oCPU.WriteUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x0), param1);
			this.oCPU.WriteUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x100), param2);
			this.oCPU.WriteUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x200), param3);

		L0a1d:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F9_0000_09dc");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		public void F9_0000_0a22(ushort param1, ushort param2, ushort param3)
		{
			this.oCPU.Log.EnterBlock($"F9_0000_0a22({param1}, {param2}, {param3})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L0a33;

		L0a30:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L0a33:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.GE) goto L0a5f;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.ES.Word = 0x3725; // segment
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x100)), param2);
			if (this.oCPU.Flags.NE) goto L0a30;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x200)), param3);
			if (this.oCPU.Flags.NE) goto L0a30;

			this.oCPU.WriteUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x0), param1);

		L0a5f:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F9_0000_0a22");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F9_0000_0a64(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F9_0000_0a64({xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x6);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6812, 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L0a76:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.ES.Word = 0x3725; // segment
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x0)), 0xffff);
			if (this.oCPU.Flags.E) goto L0ab6;

			// Instruction address 0x0000:0x0a97, size: 5
			this.oCPU.AX.Word = (ushort)((short)this.oGameData.Map.GetDistance(
				xPos, yPos,
				this.oCPU.ReadInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x100)), 
				this.oCPU.ReadInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x200))));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6812);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0ab6;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6812, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

		L0ab6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x80);
			if (this.oCPU.Flags.L) goto L0a76;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F9_0000_0a64");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F9_0000_0ac8(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F9_0000_0ac8({xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0xc);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			TerrainTypeEnum local_c;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680a), 0x4);
			if (this.oCPU.Flags.NE) goto L0ada;
			goto L0c2a;

		L0ada:
			// Instruction address 0x0000:0x0ae8, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(xPos - 5, 0, 80);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0b01, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(xPos + 5, 0, 80);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0b1b, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(yPos - 5, 2, 49);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0b35, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(yPos + 5, 2, 49);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

			yPos = this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));

			goto L0c19;

		L0b49:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.ES.Word = 0x3725; // segment
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0)), 0x1);
			if (this.oCPU.Flags.NE) goto L0b5f;

			// Instruction address 0x0000:0x0b84, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos * 4, (yPos * 4) + 4, 4, 4, 7);
			goto L0b8c;

		L0b5f:
			// Instruction address 0x0000:0x0b84, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos * 4, (yPos * 4) + 4, 4, 4, 15);
			goto L0b8c;

		L0b64:
			// Instruction address 0x0000:0x0b84, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos * 4, (yPos * 4) + 4, 4, 4, 8);

		L0b8c:
			xPos++;

		L0b8f:
			if (xPos >= this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)))
				goto L0c16;

			// Instruction address 0x0000:0x0b9d, size: 5
			local_c = this.oGameData.Map[xPos, yPos].TerrainType;

			if (local_c == TerrainTypeEnum.Water) goto L0b8c;

			F9_0000_0a64(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6812), 0x6);
			if (this.oCPU.Flags.GE) goto L0b64;
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.ES.Word = 0x3725; // segment

			// Instruction address 0x0000:0x0bd6, size: 5
			this.oParent.MapManagement.F0_2aea_1942_GetGroupID(
				this.oCPU.ReadInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x100)),
				this.oCPU.ReadInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x200)));

			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x0be6, size: 5
			this.oParent.MapManagement.F0_2aea_1942_GetGroupID(xPos, yPos);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.E) goto L0bf5;
			goto L0b64;

		L0bf5:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6812), 0x0);
			if (this.oCPU.Flags.NE) goto L0bff;
			goto L0b49;

		L0bff:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.ES.Word = 0x3725; // segment
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0b84, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos * 4, (yPos * 4) + 4, 4, 4,
				this.oParent.Array_1946[this.oCPU.BX.Word / 2]);
			goto L0b8c;

		L0c16:
			yPos++;

		L0c19:
			if (yPos >= this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)))
				goto L0c2a;

			xPos = this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			goto L0b8f;

		L0c2a:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F9_0000_0ac8");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F9_0000_0c30()
		{
			this.oCPU.Log.EnterBlock("F9_0000_0c30()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x8);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L0d3b;

		L0c3f:
			this.oCPU.AX.Low = 0x2e;

		L0c41:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), this.oCPU.AX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L0c4b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x50);
			if (this.oCPU.Flags.GE) goto L0c68;

			// Instruction address 0x0000:0x0c57, size: 5
			if (this.oGameData.Map[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].TerrainType != TerrainTypeEnum.Water) goto L0c3f;

			this.oCPU.AX.Low = 0x20;
			goto L0c41;

		L0c68:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L0cbf;

		L0c6f:
			this.oCPU.AX.Low = 0x2b;

		L0c71:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), this.oCPU.AX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L0c7d:
			this.oCPU.AX.Low = (byte)this.oGameData.CityNames[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))][this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xba07), this.oCPU.AX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x50);
			if (this.oCPU.Flags.GE) goto L0cbc;

			if (this.oGameData.CityNames[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))][this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))] != '\0')
				goto L0c7d;

		L0cbc:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L0cbf:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x50);
			if (this.oCPU.Flags.GE) goto L0d24;

			// Instruction address 0x0000:0x0ccb, size: 5
			if (this.oGameData.Map[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].TerrainType == TerrainTypeEnum.Water) goto L0cbc;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L0ce2;

		L0cdf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L0ce2:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x100);
			if (this.oCPU.Flags.GE) goto L0cbc;
			this.oCPU.AX.Low = (byte)((sbyte)this.oGameData.CityNameFlags[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].X);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.NE) goto L0cdf;
			this.oCPU.AX.Low = (byte)((sbyte)this.oGameData.CityNameFlags[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Y);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			if (this.oCPU.Flags.NE) goto L0cdf;

			// Instruction address 0x0000:0x0d10, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L0d1f;
			goto L0c6f;

		L0d1f:
			this.oCPU.AX.Low = 0x2a;
			goto L0c71;

		L0d24:
			// Instruction address 0x0000:0x0d30, size: 5
			this.oParent.MSCAPI.write((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x680c), 0xba06, 0x52);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L0d3b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x32);
			if (this.oCPU.Flags.GE) goto L0d58;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba56, 0xd);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba57, 0xa);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba58, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L0c4b;

		L0d58:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F9_0000_0c30");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F9_0000_0d5d(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F9_0000_0d5d({playerID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x10);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x0000:0x0d78, size: 5
			this.oGameData.Players[playerID].Nationality = 
				this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].Nationality;

			// Instruction address 0x0000:0x0d8f, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10),
				this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].Nation);

			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x0);
			if (this.oCPU.Flags.NE) goto L0dc4;

			// Instruction address 0x0000:0x0dac, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10),
				this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].Nationality);

			// Instruction address 0x0000:0x0dbc, size: 5
			this.oParent.MSCAPI.strcat((ushort)(this.oCPU.BP.Word - 0x10), "s");

		L0dc4:
			// Instruction address 0x0000:0x0dd1, size: 5
			this.oGameData.Players[playerID].Nation = this.oCPU.ReadString(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F9_0000_0d5d");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F9_0000_0dde()
		{
			this.oCPU.Log.EnterBlock("F9_0000_0dde()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x680e, 0x1);

			// Instruction address 0x0000:0x0dea, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x0def, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xb1d4, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L0dfe:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.ES.Word = 0x3772; // segment
			this.oCPU.WriteUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x37c4), 0xff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xe);
			if (this.oCPU.Flags.L) goto L0dfe;

			// Instruction address 0x0000:0x0e27, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			this.oParent.Var_aa_Rectangle.FontID = 6;

			F9_0000_0000();

			// Instruction address 0x0000:0x0e53, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(
				this.oGameData.Static.Nations[this.oGameData.Players[this.oGameData.HumanPlayerID].NationalityID].LongTune, 3);

			// Instruction address 0x0000:0x0e7f, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 18, 150, 284, 32, 34);

			// Instruction address 0x0000:0x0e8f, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "The entire world hails");

			// Instruction address 0x0000:0x0ea7, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 152, 20);

			// Instruction address 0x0000:0x0ecb, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 151, 23);
			
			// Instruction address 0x0000:0x0ee1, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[this.oGameData.HumanPlayerID].Name);

			// Instruction address 0x0000:0x0ef1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " the CONQUEROR!");

			// Instruction address 0x0000:0x0f09, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 168, 20);

			// Instruction address 0x0000:0x0f2d, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 167, 23);

			// Instruction address 0x0000:0x0f35, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			// Instruction address 0x0000:0x0f3a, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Instruction address 0x0000:0x0f43, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x0000:0x0f65, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x0f6a, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x680e, 0x0);
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F9_0000_0dde");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="param2"></param>
		public void F9_0000_0f79(short playerID, ushort param2)
		{
			this.oCPU.Log.EnterBlock($"F9_0000_0f79({playerID}, {param2})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x36);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.BX.Word = (ushort)this.oGameData.Players[playerID].NationalityID;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x3938));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0f9e, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10), "king00.pic");

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0xa;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb), this.oCPU.ADD_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb)), this.oCPU.DX.Low));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ADD_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), this.oCPU.AX.Low));

			// Instruction address 0x0000:0x0ff5, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0);

			// Instruction address 0x0000:0x1011, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 0xb5, 0x43, 0x8b, 0x85);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x102d, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 1, 0x33, 0x3b, 0x31);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x1049, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,1,0x97,0x3b,0x31);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x1061, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4112, 0);

			// Instruction address 0x0000:0x1079, size: 5
			this.oParent.Segment_1000.F0_1000_04d4_TransformPaletteToColor(5, Color.FromRgb(0, 0, 0));

			// Instruction address 0x0000:0x1099, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x0000:0x10a9, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x24), "slam2.pic");

			// Instruction address 0x0000:0x10ce, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0x85, (ushort)(this.oCPU.BP.Word - 0x24), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x0);

		L10db:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));
			this.oCPU.ES.Word = 0x3772; // segment
			if (this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x37c4)) != 0xff)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a),
					this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x37c4)));

				// Instruction address 0x0000:0x114d, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)) % 7) * 28) + 1,
					((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)) / 7) * 34) + 133,
					27, 33,
					this.oParent.Var_aa_Rectangle,
					((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)) % 7) * 46) + 8,
					((-(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)) / 7)) * 42) + 49);
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0xe);
			if (this.oCPU.Flags.GE) goto L1161;
			goto L10db;

		L1161:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0x5a);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), 0x0);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Low = 0x2;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.ES.Word = 0x36fa; // segment
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x10));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0xb4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x12));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)), this.oCPU.AX.Word));
			this.oCPU.ES.Word = 0x36fa; // segment
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x48));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x40);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x4a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), this.oCPU.AX.Word));
			
			// Instruction address 0x0000:0x11b3, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				90, 0,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			// Instruction address 0x0000:0x11cb, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)) - 2,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			// Instruction address 0x0000:0x11e9, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].LongTune, 3);

			// Instruction address 0x0000:0x1200, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x9), "pal");

			// Instruction address 0x0000:0x1210, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0xc1d6);

			// Instruction address 0x0000:0x1220, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, "slam1.pal", out this.oParent.Var_bdee);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0xc0);

		L122d:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));
			this.oCPU.SI.Word = this.oCPU.BX.Word;

			this.oParent.Var_bdee[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)) + 6] =
				this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xc1dc));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x1b0);
			if (this.oCPU.Flags.L) goto L122d;

			// Instruction address 0x0000:0x124c, size: 5
			this.oParent.Segment_1000.F0_1000_04aa_TransformPalette(8, this.oParent.Var_bdee);

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xb1d4);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Low = 0x7;
			this.oCPU.IDIV_UInt8(this.oCPU.AX, this.oCPU.CX.Low);
			this.oCPU.AX.Low = this.oCPU.AX.High;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)), 0x1);
			if (this.oCPU.Flags.E) goto L1274;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			goto L127d;

		L1274:
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);

		L127d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xb1d4);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xb1d4, this.oCPU.INC_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xb1d4)));
			this.oCPU.CMP_UInt8(this.oCPU.AX.Low, 0x7);
			if (this.oCPU.Flags.L) goto L128f;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)), 0x7));

		L128f:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32));
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
			this.oCPU.ES.Word = 0x3772; // segment
			this.oCPU.WriteUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x37c4), this.oCPU.AX.Low);

			// Instruction address 0x0000:0x129e, size: 5
			this.oParent.Segment_1000.F0_1000_033e_ResetWaitTimer();

			// Instruction address 0x0000:0x12ab, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4134, 0);

			// Instruction address 0x0000:0x12c5, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0x85, (ushort)(this.oCPU.BP.Word - 0x24), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x0);

		L12d2:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));
			this.oCPU.ES.Word = 0x3772; // segment

			if (this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x37c4)) != 0xff)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a),
					this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x37c4)));

				// Instruction address 0x0000:0x1344, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)) % 7) * 28) + 1,
					((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)) / 7) * 34) + 133,
					27, 33,
					this.oParent.Var_19d4_Rectangle,
					((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)) % 7) * 46) + 8,
					((-(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)) / 7)) * 42) + 49);
			}
		
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0xe);
			if (this.oCPU.Flags.GE) goto L1358;
			goto L12d2;

		L1358:
			goto L135f;

		L135a:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

		L135f:
			this.oCPU.AX.Word = this.oParent.Var_5c_TickCount;
			this.oCPU.DoEvents();
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xf0);
			if (this.oCPU.Flags.L) goto L135a;

			// Instruction address 0x0000:0x138a, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(Math.Abs((short)param2), 10));

			if ((short)param2 < 0)
			{
				// Instruction address 0x0000:0x13a5, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " BC");
			}
			else
			{
				// Instruction address 0x0000:0x13a5, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " AD");
			}

			// Instruction address 0x0000:0x13b5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ": ");

			// Instruction address 0x0000:0x13cb, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[this.oGameData.HumanPlayerID].Nation);

			// Instruction address 0x0000:0x13db, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " destroy");

			// Instruction address 0x0000:0x13f3, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 152, 20);

			// Instruction address 0x0000:0x1417, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 151, 23);
			
			// Instruction address 0x0000:0x1427, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "the ");

			// Instruction address 0x0000:0x143c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[playerID].Nationality);

			// Instruction address 0x0000:0x144c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " civilization!");

			// Instruction address 0x0000:0x1464, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 168, 20);

			// Instruction address 0x0000:0x1488, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 167, 23);

			// Instruction address 0x0000:0x14ae, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 133, 320, 67, this.oParent.Var_19d4_Rectangle, 0, 133);

			// Instruction address 0x0000:0x14c6, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)) - 2,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			// Instruction address 0x0000:0x14d1, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0);

			// Instruction address 0x0000:0x14dd, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			// Instruction address 0x0000:0x14e9, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(60);

			// Instruction address 0x0000:0x1508, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(
				this.oGameData.Static.Nations[this.oGameData.Players[this.oGameData.HumanPlayerID].NationalityID].LongTune, 3);

			// Instruction address 0x0000:0x1518, size: 5
			this.oParent.Graphics.F0_VGA_06b7_DrawScreenToMainScreenWithEffect(1);

			// Instruction address 0x0000:0x1538, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x0000:0x1543, size: 5
			this.oParent.Segment_1000.F0_1000_0846(0);
			
			// Instruction address 0x0000:0x154f, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F9_0000_0f79");
		}
	}
}
