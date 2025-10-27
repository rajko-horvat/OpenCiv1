using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Segment_2517
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public Segment_2517(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F0_2517_0004(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F0_2517_0004({playerID})");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0x6);
			this.oCPU.PUSHUInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSHUInt16(this.oCPU.SI.UInt16);
			
			if (this.oGameData.Players[playerID].GovernmentType != 0)
				goto L0088;

			this.oCPU.AX.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMPUInt16((ushort)playerID, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L004c;

			this.oCPU.TESTUInt8((byte)(this.oGameData.TurnCount & 0xff), 0x3);
			if (this.oCPU.Flags.NE) goto L004c;

			this.oCPU.SI.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);
			
			if ((this.oGameData.Players[playerID].Diplomacy[0] & 4) == 0)
				goto L003c;

			this.oGameData.Players[playerID].Diplomacy[0] &= 0xfffb;
			goto L0088;

		L003c:
			// Instruction address 0x2517:0x0044, size: 3
			F0_2517_04a1(playerID, 1);
			
			goto L0088;

		L004c:
			this.oCPU.TESTUInt8((byte)(this.oGameData.TurnCount & 0xff), 0x3);
			if (this.oCPU.Flags.E) goto L0066;

			// Instruction address 0x2517:0x005a, size: 5
			this.oParent.CityWorker.F0_1d12_6c97_PlayerHasWonder(playerID, (int)WonderEnum.Pyramids);
			
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0088;

		L0066:
			// Instruction address 0x2517:0x006e, size: 3
			F0_2517_04a1(playerID, 1);
			
			this.oCPU.AX.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMPUInt16((ushort)playerID, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L0088;
			
			this.oCPU.BX.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			this.oGameData.Players[playerID].Diplomacy[0] &= 0xfffb;

		L0088:
			this.oCPU.AX.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMPUInt16((ushort)playerID, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L00b1;
			
			this.oCPU.BX.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oGameData.Players[playerID].Diplomacy[0] & 4) == 0)
				goto L00b1;

			// Instruction address 0x2517:0x00ab, size: 3
			F0_2517_04a1(playerID, this.oGameData.Players[playerID].GovernmentType);

		L00b1:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x1);

		L00b6:
			this.oCPU.SI.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.AX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.SI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			if ((this.oGameData.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))] & 0x100) == 0)
				goto L00e9;

			// Instruction address 0x2517:0x00d2, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.MSCAPI.RNG.Next(3));

			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L00e9;

			this.oGameData.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))] &= 0xfefd;
			this.oGameData.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))] |= 0x200;
			
		L00e9:
			this.oCPU.TESTUInt8((byte)(this.oGameData.TurnCount & 0xff), 0xf);
			if (this.oCPU.Flags.E) goto L00f3;
			goto L0202;

		L00f3:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.BX.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oGameData.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))] & 0x10) != 0)
				goto L01e2;

			if ((this.oGameData.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))] & 1) == 0)
				goto L01c2;

			if ((this.oGameData.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))] & 2) != 0)
				goto L01c2;

			this.oCPU.DI.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.DI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.DI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = (ushort)playerID;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			if ((this.oGameData.Players[this.oGameData.HumanPlayerID].Diplomacy[playerID] & 0x40) != 0)
				goto L0141;

			this.oCPU.BX.UInt16 = this.oCPU.SI.UInt16;
			this.oCPU.BX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.BX.UInt16, this.oCPU.DI.UInt16);

			if ((this.oGameData.Players[this.oGameData.HumanPlayerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))] & 0x40) == 0)
				goto L01c2;

		L0141:
			this.oCPU.AX.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMPUInt16((ushort)playerID, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L01c2;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L01c2;

			// Instruction address 0x2517:0x0156, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "The war between\nthe ");

			// Instruction address 0x2517:0x016b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[playerID].Nation);

			// Instruction address 0x2517:0x017b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " and the\n");

			// Instruction address 0x2517:0x0190, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Nation);

			// Instruction address 0x2517:0x01a0, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " has ended.\n");

			this.oParent.Var_2f9e = 1;

			// Instruction address 0x2517:0x01ba, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

		L01c2:
			this.oCPU.SI.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			this.oGameData.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))] &= 0xfffe;

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = (ushort)playerID;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			this.oGameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Diplomacy[playerID] &= 0xfffe;

		L01e2:
			this.oCPU.SI.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			this.oGameData.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))] &= 0xffef;

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = (ushort)playerID;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			this.oGameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Diplomacy[playerID] &= 0xffef;

		L0202:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x8);
			if (this.oCPU.Flags.GE) goto L020e;
			goto L00b6;

		L020e:
			this.oCPU.CMPUInt16((ushort)playerID, 0x0);
			if (this.oCPU.Flags.NE) goto L0217;
			goto L049b;

		L0217:
			this.oCPU.AX.LowUInt8 = (byte)(this.oGameData.TurnCount & 0xff);
			this.oCPU.AX.HighUInt8 = 0;
			this.oCPU.AX.UInt16 = this.oCPU.ANDUInt16(this.oCPU.AX.UInt16, 0x1f);
			this.oCPU.CX.UInt16 = (ushort)playerID;
			this.oCPU.CX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.CX.UInt16, 0x1);
			this.oCPU.CX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.CX.UInt16, 0x1);
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, this.oCPU.CX.UInt16);
			if (this.oCPU.Flags.E) goto L022d;
			goto L049b;

		L022d:
			this.oCPU.AX.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMPUInt16((ushort)playerID, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L0238;
			goto L049b;

		L0238:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x1);
			goto L02db;

		L0240:
			// Instruction address 0x2517:0x0248, size: 5
			this.oParent.Array_30b8[3] = "agree to a";

		L0243:
			// Instruction address 0x2517:0x0254, size: 5
			this.oParent.LanguageTools.F0_2f4d_044f_GetAndAdjustLanguageItemFromKingSection(0x29a6);

			this.oParent.Var_3936 = 1;
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0xd76c, 0xc);

			this.oParent.MeetWithKing.F6_0000_251d(0xba06, 0x14, 0x8b);

			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.NE) goto L02c2;

			// Instruction address 0x2517:0x028d, size: 3
			F0_2517_0a30_SetDiplomacyFlags(playerID, this.oGameData.HumanPlayerID, 2);

			// Instruction address 0x2517:0x029f, size: 3
			F0_2517_0aa1_ClearDiplomacyFlags(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), this.oGameData.HumanPlayerID, 2);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.AX.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.AX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.BX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.BX.UInt16, this.oCPU.AX.UInt16);

			this.oGameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Diplomacy[this.oGameData.HumanPlayerID] |= 8;

			this.oGameData.Players[playerID].ContactPlayerCountdown = 
				(short)(oParent.GameData.TurnCount + 16);

		L02c2:
			this.oParent.MeetWithKing.F6_0000_16ac();

		L02c7:
			this.oCPU.SI.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			this.oGameData.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))] &= 0xffdf;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 
				this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))));

		L02db:
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x8);
			if (this.oCPU.Flags.L) goto L02e4;
			goto L049b;

		L02e4:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.DI.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.DI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.DI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = this.oCPU.DI.UInt16;
			this.oCPU.BX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.BX.UInt16, this.oCPU.SI.UInt16);

			if ((this.oGameData.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))] & 0x20) == 0)
				goto L02c7;

			this.oCPU.BX.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oGameData.Players[this.oGameData.HumanPlayerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))] & 2) == 0)
				goto L02c7;

			this.oCPU.BX.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			if ((this.oGameData.Players[playerID].Diplomacy[this.oGameData.HumanPlayerID] & 0x20) != 0)
				goto L02c7;

			this.oCPU.AX.UInt16 = (ushort)this.oGameData.Players[playerID].MilitaryPower;
			this.oCPU.AX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, (ushort)this.oGameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].MilitaryPower);
			if (this.oCPU.Flags.L) goto L0329;
			goto L042d;

		L0329:
			this.oParent.MeetWithKing.F6_0000_16cd(playerID, -1, 0);
			
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0342;
			goto L042d;

		L0342:
			// Instruction address 0x2517:0x0355, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oGameData.Players[playerID].Coins / 100, 1, 10);

			this.oCPU.CX.UInt16 = 0x32;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);

			// Instruction address 0x2517:0x036d, size: 5
			this.oParent.Array_30b8[1] = this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Nation;

			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x2517:0x0392, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), 10));

			// Instruction address 0x2517:0x03a2, size: 5
			this.oParent.Array_30b8[2] = this.oCPU.ReadString(this.oCPU.DS.UInt16, 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x2517:0x03b3, size: 5
			this.oParent.LanguageTools.F0_2f4d_044f_GetAndAdjustLanguageItemFromKingSection(0x2988);

			this.oParent.Var_3936 = 1;
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0xd76c, 0xc);

			this.oParent.MeetWithKing.F6_0000_251d(0xba06, 0x14, 0x8b);
			
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.NE) goto L0428;

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oGameData.Players[this.oGameData.HumanPlayerID].Coins += (short)this.oCPU.AX.UInt16;
			this.oGameData.Players[playerID].Coins += (short)this.oCPU.AX.UInt16;

			// Instruction address 0x2517:0x03fd, size: 3
			F0_2517_0a30_SetDiplomacyFlags(playerID, this.oGameData.HumanPlayerID, 2);

			// Instruction address 0x2517:0x040f, size: 3
			F0_2517_0aa1_ClearDiplomacyFlags(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), this.oGameData.HumanPlayerID, 2);
			
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.AX.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.AX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.BX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.BX.UInt16, this.oCPU.AX.UInt16);

			this.oGameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Diplomacy[this.oGameData.HumanPlayerID] |= 8;

		L0428:
			this.oParent.MeetWithKing.F6_0000_16ac();

		L042d:
			if (this.oGameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].MilitaryPower <=
				this.oGameData.Players[playerID].MilitaryPower)
				goto L02c7;

			this.oCPU.AX.UInt16 = (ushort)this.oGameData.Players[playerID].MilitaryPower;
			this.oCPU.AX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, (ushort)this.oGameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].MilitaryPower);
			if (this.oCPU.Flags.L)
				goto L02c7;

			this.oParent.MeetWithKing.F6_0000_16cd(playerID, -1, 0);
			
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0468;
			goto L02c7;

		L0468:
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x2517:0x0475, size: 5
			this.oParent.Array_30b8[1] = this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Nation;

			this.oCPU.BX.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.AX.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.AX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.BX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.BX.UInt16, this.oCPU.AX.UInt16);

			if ((this.oGameData.Players[playerID].Diplomacy[this.oGameData.HumanPlayerID] & 2) == 0)
				goto L0240;

			// Instruction address 0x2517:0x0248, size: 5
			this.oParent.Array_30b8[3] = "extend our";

			goto L0243;

		L049b:
			this.oCPU.SI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2517_0004");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="governmentType"></param>
		public void F0_2517_04a1(short playerID, short governmentType)
		{
			this.oCPU.Log.EnterBlock($"F0_2517_04a1({playerID}, {governmentType})");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0x14);
			this.oCPU.PUSHUInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSHUInt16(this.oCPU.SI.UInt16);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12),
				(ushort)this.oGameData.Players[playerID].GovernmentType);

			this.oCPU.AX.UInt16 = 0x1;
			this.oCPU.CX.LowUInt8 = (byte)playerID;
			this.oCPU.AX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.AX.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.TESTUInt16(this.oCPU.AX.UInt16, (ushort)this.oGameData.HumanPlayerBitFlag);
			if (this.oCPU.Flags.NE) goto L04c6;
			goto L05e9;

		L04c6:
			// Instruction address 0x2517:0x04ce, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Select type of\nGovernment...\n ");

			this.oCPU.AX.UInt16 = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), 0x1);

		L04e3:
			// Instruction address 0x2517:0x04ea, size: 5
			this.oParent.CityWorker.F0_1d12_6c97_PlayerHasWonder(playerID, (int)WonderEnum.Pyramids);
			
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L055a;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)), 0x2);
			if (this.oCPU.Flags.NE) goto L050f;

			// Instruction address 0x2517:0x0503, size: 5
			this.oCPU.AX.UInt16 = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Monarchy);
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E)
				goto L058d;

		L050f:
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)), 0x3);
			if (this.oCPU.Flags.NE) goto L0528;

			// Instruction address 0x2517:0x051c, size: 5
			this.oCPU.AX.UInt16 = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Communism);
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E)
				goto L058d;

		L0528:
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)), 0x4);
			if (this.oCPU.Flags.NE) goto L0541;

			// Instruction address 0x2517:0x0535, size: 5
			this.oCPU.AX.UInt16 = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.TheRepublic);
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E)
				goto L058d;

		L0541:
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)), 0x5);
			if (this.oCPU.Flags.NE) goto L055a;

			// Instruction address 0x2517:0x054e, size: 5
			this.oCPU.AX.UInt16 = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Democracy);
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E)
				goto L058d;

		L055a:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))));
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0xe), this.oCPU.AX.UInt16);

			// Instruction address 0x2517:0x0575, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.Array_1966[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10))]);

			// Instruction address 0x2517:0x0585, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n ");

		L058d:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10))));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)), 0x6);
			if (this.oCPU.Flags.GE) goto L0599;
			goto L04e3;

		L0599:
			this.oCPU.CMPUInt16((ushort)governmentType, 0x0);
			if (this.oCPU.Flags.E) goto L05cb;

			// Instruction address 0x2517:0x05ab, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 64);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.GE) goto L05bd;
			goto L04c6;

		L05bd:
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0xe));
			goto L05d3;

		L05cb:
			this.oCPU.AX.UInt16 = (ushort)governmentType;

		L05d3:
			this.oGameData.Players[playerID].GovernmentType = (short)this.oCPU.AX.UInt16;

			this.oParent.StartGameMenu.F5_0000_1af6_LoadGovernmentImage();

			// Instruction address 0x2517:0x05dc, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			this.oParent.StartGameMenu.F5_0000_1ba2_ChangeGovernment();

			goto L06f0;

		L05e9:
			this.oCPU.AX.UInt16 = (ushort)governmentType;
			this.oCPU.CMPUInt16((ushort)this.oGameData.Players[playerID].GovernmentType, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L0608;

			this.oCPU.BX.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oGameData.Players[playerID].Diplomacy[0] & 4) == 0)
				goto L06d6;

		L0608:
			this.oCPU.SI.UInt16 = (ushort)playerID;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.BX.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oGameData.Players[this.oGameData.HumanPlayerID].Diplomacy[playerID] & 0x40) == 0)
				goto L06d6;

			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			this.oCPU.DI.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.DI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.DI.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oGameData.Players[playerID].Diplomacy[0] & 4) == 0)
				goto L067c;

			// Instruction address 0x2517:0x063a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[playerID].Nationality);

			// Instruction address 0x2517:0x064a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " government\nchanged to ");

			// Instruction address 0x2517:0x065f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.Array_1966[governmentType]);

			// Instruction address 0x2517:0x066f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\n");

			this.oGameData.Players[playerID].Diplomacy[0] &= 0xfffb;

			goto L06bc;

		L067c:
			// Instruction address 0x2517:0x0684, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "The ");

			// Instruction address 0x2517:0x0699, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[playerID].Nationality);

			// Instruction address 0x2517:0x06a9, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " government\nhas been overthrown!\n");

			this.oCPU.BX.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			this.oGameData.Players[playerID].Diplomacy[0] |= 4;

		L06bc:
			this.oParent.Var_2f9e = 1;

			// Instruction address 0x2517:0x06ce, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 64);

		L06d6:
			this.oCPU.AX.UInt16 = (ushort)governmentType;
			this.oGameData.Players[playerID].GovernmentType = (short)this.oCPU.AX.UInt16;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.UInt16 = this.oCPU.SUBUInt16(this.oCPU.AX.UInt16, this.oCPU.DX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.SARUInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.SUBUInt16(this.oCPU.AX.UInt16, 0x4);
			this.oCPU.AX.UInt16 = this.oCPU.NEGUInt16(this.oCPU.AX.UInt16);
			this.oGameData.Players[playerID].TaxRate = (short)this.oCPU.AX.UInt16;

		L06f0:
			this.oCPU.SI.UInt16 = (ushort)this.oGameData.Players[playerID].GovernmentType;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)), this.oCPU.SI.UInt16);
			if (this.oCPU.Flags.E) goto L0731;

			// Instruction address 0x2517:0x070a, size: 5
			this.oParent.Segment_1866.F0_1866_250e_AddReplayData(8, (byte)playerID, (byte)this.oGameData.Players[playerID].GovernmentType);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), 0x0);

		L0717:
			this.oCPU.SI.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10));
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			this.oGameData.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10))] &= 0xfff7;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), 
				this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10))));

			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)), 0x8);
			if (this.oCPU.Flags.L) goto L0717;

		L0731:
			this.oCPU.SI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2517_04a1");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID1"></param>
		/// <param name="playerID2"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2517_0737(short playerID1, short playerID2, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2517_0737({playerID1}, {playerID2}, {xPos}, {yPos})");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0x8);
			this.oCPU.PUSHUInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSHUInt16(this.oCPU.SI.UInt16);

			this.oCPU.CMPUInt16((ushort)playerID1, 0x0);
			if (this.oCPU.Flags.NE) goto L0748;
			goto L0a2a;

		L0748:
			this.oCPU.CMPUInt16((ushort)playerID2, 0x0);
			if (this.oCPU.Flags.NE) goto L0751;
			goto L0a2a;

		L0751:
			this.oCPU.AX.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMPUInt16((ushort)playerID1, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L078d;

			this.oCPU.SI.UInt16 = (ushort)playerID2;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.BX.UInt16 = (ushort)playerID1;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oGameData.Players[playerID1].Diplomacy[playerID2] & 1) == 0)
				goto L0778;

			this.oCPU.AX.UInt16 = (ushort)oParent.GameData.TurnCount;
			this.oCPU.AX.UInt16 -= (ushort)this.oGameData.Players[playerID2].ContactPlayerCountdown;
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, 0x10);
			if (this.oCPU.Flags.L) goto L078d;

		L0778:
			this.oParent.MeetWithKing.F6_0000_0000(playerID2, xPos, yPos, 0);

		L078d:
			this.oCPU.AX.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMPUInt16((ushort)playerID2, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L07ce;
			
			this.oCPU.SI.UInt16 = (ushort)playerID1;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = (ushort)playerID2;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			if ((this.oGameData.Players[playerID1].Diplomacy[playerID2] & 1) == 0)
				goto L07b9;

			this.oCPU.AX.UInt16 = (ushort)oParent.GameData.TurnCount;
			this.oCPU.AX.UInt16 -= (ushort)this.oGameData.Players[playerID1].ContactPlayerCountdown;
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, 0x10);
			if (this.oCPU.Flags.L) goto L07ce;

		L07b9:
			this.oParent.MeetWithKing.F6_0000_0000(playerID1, xPos, yPos, 0);

		L07ce:
			this.oCPU.SI.UInt16 = (ushort)playerID1;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.AX.UInt16 = (ushort)playerID2;
			this.oCPU.AX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.SI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);
			
			this.oGameData.Players[playerID1].Diplomacy[playerID2] |= 0x11;

			this.oCPU.DI.UInt16 = (ushort)playerID2;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.DI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.DI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = (ushort)playerID1;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			this.oGameData.Players[playerID2].Diplomacy[playerID1] |= 0x11;

			this.oCPU.AX.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMPUInt16((ushort)playerID1, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L0802;
			goto L0a2a;

		L0802:
			this.oCPU.CMPUInt16((ushort)playerID2, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L080a;
			goto L0a2a;

		L080a:
			this.oCPU.AX.LowUInt8 = (byte)playerID1;
			this.oCPU.AX.LowUInt8 = this.oCPU.ADDUInt8(this.oCPU.AX.LowUInt8, (byte)playerID2);
			this.oCPU.AX.LowUInt8 = this.oCPU.ADDUInt8(this.oCPU.AX.LowUInt8, (byte)(oParent.GameData.TurnCount & 0xff));
			this.oCPU.TESTUInt8(this.oCPU.AX.LowUInt8, 0x3);
			if (this.oCPU.Flags.E) goto L0821;

			if ((this.oGameData.Players[playerID1].Diplomacy[playerID2] & 1) != 0)
				goto L0a2a;

		L0821:
			this.oCPU.SI.UInt16 = (ushort)playerID1;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = (ushort)playerID2;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			if ((this.oGameData.Players[playerID1].Diplomacy[playerID2] & 0x8) != 0)
				goto L0a2a;

			this.oCPU.SI.UInt16 = (ushort)playerID2;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = (ushort)playerID1;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			if ((this.oGameData.Players[playerID2].Diplomacy[playerID1] & 8) != 0)
				goto L0a2a;

			// Instruction address 0x2517:0x0852, size: 3
			F0_2517_0b1d(playerID1, playerID2);
			
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L087e;

			// Instruction address 0x2517:0x0863, size: 5
			this.oParent.CityWorker.F0_1d12_6c97_PlayerHasWonder(playerID2, (int)WonderEnum.GreatWall);
			
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L087e;
			if (this.oGameData.Players[playerID1].GovernmentType >= 4)
				goto L087e;
			goto L0966;

		L087e:
			// Instruction address 0x2517:0x0885, size: 3
			F0_2517_0b1d(playerID2, playerID1);
			
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L08b1;

			// Instruction address 0x2517:0x0896, size: 5
			this.oParent.CityWorker.F0_1d12_6c97_PlayerHasWonder(playerID1, (int)WonderEnum.GreatWall);

			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L08b1;
			
			if (this.oGameData.Players[playerID2].GovernmentType >= 4)
				goto L08b1;
			goto L0966;

		L08b1:
			// Instruction address 0x2517:0x08b8, size: 3
			F0_2517_0cef(playerID1, playerID2);

			this.oCPU.SI.UInt16 = (ushort)playerID2;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.BX.UInt16 = (ushort)playerID1;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oGameData.Players[playerID1].Diplomacy[playerID2] & 2) != 0)
				goto L0a2a;

			this.oCPU.DI.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.DI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.DI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = (ushort)playerID1;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			if ((this.oGameData.Players[this.oGameData.HumanPlayerID].Diplomacy[playerID1] & 0x40) != 0)
				goto L08f1;

			this.oCPU.BX.UInt16 = this.oCPU.SI.UInt16;
			this.oCPU.BX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.BX.UInt16, this.oCPU.DI.UInt16);

			if ((this.oGameData.Players[this.oGameData.HumanPlayerID].Diplomacy[playerID2] & 0x40) == 0)
				goto L0955;

		L08f1:
			// Instruction address 0x2517:0x08fe, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[playerID1].Nation);

			// Instruction address 0x2517:0x090e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " and\n");

			// Instruction address 0x2517:0x0923, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[playerID2].Nation);

			// Instruction address 0x2517:0x0933, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " sign\na peace treaty.\n");

			this.oParent.Var_2f9e = 1;

			// Instruction address 0x2517:0x094d, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

		L0955:
			// Instruction address 0x2517:0x0960, size: 3
			F0_2517_0a30_SetDiplomacyFlags(playerID1, playerID2, 2);
			
			goto L0a2a;

		L0966:
			this.oCPU.SI.UInt16 = (ushort)playerID1;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = (ushort)playerID2;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			if ((this.oGameData.Players[playerID1].Diplomacy[playerID2] & 2) != 0)
				goto L0982;

			if ((this.oGameData.Players[playerID1].Diplomacy[playerID2] & 1) != 0)
				goto L0a2a;

		L0982:
			this.oCPU.SI.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = (ushort)playerID1;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			if ((this.oGameData.Players[this.oGameData.HumanPlayerID].Diplomacy[playerID1] & 0x40) != 0)
				goto L09a2;

			this.oCPU.BX.UInt16 = (ushort)playerID2;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			if ((this.oGameData.Players[this.oGameData.HumanPlayerID].Diplomacy[playerID2] & 0x40) == 0)
				goto L0a19;

		L09a2:
			// Instruction address 0x2517:0x09af, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[playerID1].Nation);

			// Instruction address 0x2517:0x09bf, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " and\n");

			this.oCPU.SI.UInt16 = (ushort)playerID2;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);

			// Instruction address 0x2517:0x09d4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[playerID2].Nation);

			this.oCPU.BX.UInt16 = (ushort)playerID1;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oGameData.Players[playerID1].Diplomacy[playerID2] & 2) != 0)
			{
				// Instruction address 0x2517:0x09f7, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " cancel\npeace treaty.\n");
			}
			else
			{
				// Instruction address 0x2517:0x09f7, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " declare\nwar on each other.\n");
			}

			this.oParent.Var_2f9e = 1;

			// Instruction address 0x2517:0x0a11, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

		L0a19:
			// Instruction address 0x2517:0x0a24, size: 3
			F0_2517_0aa1_ClearDiplomacyFlags(playerID1, playerID2, 2);

		L0a2a:
			this.oCPU.SI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2517_0737");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID1"></param>
		/// <param name="playerID2"></param>
		/// <param name="flags"></param>
		public void F0_2517_0a30_SetDiplomacyFlags(short playerID1, short playerID2, ushort flags)
		{
			this.oCPU.Log.EnterBlock($"F0_2517_0a30_SetDiplomacyFlags({playerID1}, {playerID2}, {flags})");

			// function body
			if (flags == 2 &&
				(this.oGameData.Players[playerID1].Diplomacy[playerID2] & flags) == 0)
			{
				// Instruction address 0x2517:0x0a5e, size: 5
				this.oParent.Segment_1866.F0_1866_250e_AddReplayData(3, (byte)(((ushort)playerID1 << 4) | (ushort)playerID2));
			}

			this.oGameData.Players[playerID1].Diplomacy[playerID2] |= flags;
			this.oGameData.Players[playerID2].Diplomacy[playerID1] |= flags;

			if (flags == 2)
			{
				this.oGameData.Players[playerID1].Diplomacy[playerID2] &= 0xffdf;
				this.oGameData.Players[playerID2].Diplomacy[playerID1] &= 0xffdf;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2517_0a30_SetDiplomacyFlags");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID1"></param>
		/// <param name="playerID2"></param>
		/// <param name="flags"></param>
		public void F0_2517_0aa1_ClearDiplomacyFlags(short playerID1, short playerID2, ushort flags)
		{
			this.oCPU.Log.EnterBlock($"F0_2517_0aa1_ClearDiplomacyFlags({playerID1}, {playerID2}, {flags})");

			// function body
			if (flags == 2 &&
				(this.oGameData.Players[playerID1].Diplomacy[playerID2] & flags) != 0)
			{
				// Instruction address 0x2517:0x0ad2, size: 5
				this.oParent.Segment_1866.F0_1866_250e_AddReplayData(2, (byte)((short)(playerID1 << 4) | playerID2));
			}
		
			this.oGameData.Players[playerID1].Diplomacy[playerID2] &= (ushort)(~flags);
			this.oGameData.Players[playerID2].Diplomacy[playerID1] &= (ushort)(~flags);

			if ((flags & 2) != 0)
			{
				this.oGameData.Players[playerID1].Diplomacy[playerID2] &= 0xfffb;
				this.oGameData.Players[playerID2].Diplomacy[playerID1] &= 0xfffb;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2517_0aa1_ClearDiplomacyFlags");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID1"></param>
		/// <param name="playerID2"></param>
		/// <returns></returns>
		public ushort F0_2517_0b1d(short playerID1, short playerID2)
		{
			this.oCPU.Log.EnterBlock($"F0_2517_0b1d({playerID1}, {playerID2})");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0xc);
			this.oCPU.PUSHUInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSHUInt16(this.oCPU.SI.UInt16);

			this.oCPU.TESTUInt8((byte)(this.oGameData.DebugFlags & 0xff), 0x1);
			if (this.oCPU.Flags.NE) goto L0b32;

		L0b2c:
			this.oCPU.AX.UInt16 = 0x1;
			goto L0ce9;

		L0b32:
			this.oCPU.SI.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.BX.UInt16 = (ushort)playerID1;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oGameData.Players[playerID1].Diplomacy[this.oGameData.HumanPlayerID] & 3) != 1)
				goto L0b69;

			if (this.oGameData.Players[playerID2].MilitaryPower >=
				this.oGameData.Players[this.oGameData.HumanPlayerID].MilitaryPower)
				goto L0b69;

			this.oCPU.BX.UInt16 = (ushort)playerID2;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oGameData.Players[playerID2].Diplomacy[this.oGameData.HumanPlayerID] & 4) != 0)
				goto L0b69;

		L0b64:
			this.oCPU.AX.UInt16 = 0;
			goto L0ce9;

		L0b69:
			this.oCPU.SI.UInt16 = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.BX.UInt16 = (ushort)playerID2;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oGameData.Players[playerID2].Diplomacy[this.oGameData.HumanPlayerID] & 3) != 1)
				goto L0b9b;

			if (this.oGameData.Players[playerID1].MilitaryPower >=
				this.oGameData.Players[this.oGameData.HumanPlayerID].MilitaryPower)
				goto L0b9b;

			this.oCPU.BX.UInt16 = (ushort)playerID1;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oGameData.Players[playerID1].Diplomacy[this.oGameData.HumanPlayerID] & 4) == 0)
				goto L0b64;

		L0b9b:
			this.oCPU.AX.UInt16 = (ushort)this.oGameData.Players[playerID2].ActiveUnits[25];

			this.oCPU.CX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0x38;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;

			if (this.oGameData.Players[playerID1].ActiveUnits[25] < (short)this.oCPU.CX.UInt16)
				goto L0b64;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 0x1);

		L0bbf:
			this.oCPU.AX.UInt16 = (ushort)playerID1;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0be8;
			this.oCPU.AX.UInt16 = (ushort)playerID2;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0be8;
			
			this.oCPU.SI.UInt16 = (ushort)playerID1;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			if ((this.oGameData.Players[playerID1].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))] & 3) == 1)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa),
					this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))));
			}

		L0be8:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 
				this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x8);
			if (this.oCPU.Flags.L) goto L0bbf;
			
			this.oCPU.SI.UInt16 = (ushort)playerID1;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = (ushort)playerID2;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, 0x1);

			if ((this.oGameData.Players[playerID1].Diplomacy[playerID2] & 2) != 0)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa),
					this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))));
			}
		
			this.oCPU.AX.UInt16 = (ushort)this.oGameData.Static.Nations[this.oGameData.Players[playerID1].NationalityID].Mood;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 
				this.oCPU.SUBUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)), this.oCPU.AX.UInt16));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 0x1);

		L0c2e:
			this.oCPU.SI.UInt16 = (ushort)playerID1;
			this.oCPU.CX.LowUInt8 = 0x5;
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.AX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.SI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			if (this.oGameData.Players[playerID1].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].CityCount == 0)
				goto L0c69;

			this.oCPU.AX.UInt16 = (ushort)this.oGameData.Players[playerID2].Continents[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].Defense;

			this.oCPU.CX.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.AX.UInt16 = (ushort)this.oGameData.Players[playerID1].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].Defense;

			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.UInt16 = this.oCPU.SUBUInt16(this.oCPU.AX.UInt16, this.oCPU.DX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.SARUInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.AX.UInt16, 
				(ushort)this.oGameData.Players[playerID1].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].Attack);
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, this.oCPU.CX.UInt16);
			if (this.oCPU.Flags.GE) goto L0c69;
			goto L0b64;

		L0c69:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.DI.UInt16 = (ushort)playerID1;
			this.oCPU.CX.LowUInt8 = 0x5;
			this.oCPU.DI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.DI.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.DI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.DI.UInt16, this.oCPU.SI.UInt16);

			if (this.oGameData.Players[playerID1].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].Defense == 0)
				goto L0cb7;

			this.oCPU.BX.UInt16 = (ushort)playerID2;
			this.oCPU.CX.LowUInt8 = 0x5;
			this.oCPU.BX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.AX.UInt16 = (ushort)this.oGameData.Players[playerID2].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].Attack;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0cb7;

			this.oCPU.AX.UInt16 = (ushort)this.oGameData.Players[playerID1].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].Defense;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 
				this.oCPU.ADDUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), this.oCPU.AX.UInt16));

			this.oCPU.AX.UInt16 = (ushort)this.oGameData.Players[playerID2].Continents[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].Defense;

			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.UInt16 = this.oCPU.SUBUInt16(this.oCPU.AX.UInt16, this.oCPU.DX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.SARUInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.ADDUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), this.oCPU.AX.UInt16));
			this.oCPU.AX.UInt16 = (ushort)this.oGameData.Players[playerID1].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].CityCount;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.ADDUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), this.oCPU.AX.UInt16));

		L0cb7:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0xf);
			if (this.oCPU.Flags.GE) goto L0cc3;
			goto L0c2e;

		L0cc3:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6));
			this.oCPU.AX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.IDIVUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.CX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));
			this.oCPU.CX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.CX.UInt16, 0x4);
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, this.oCPU.CX.UInt16);
			if (this.oCPU.Flags.L) goto L0cdd;
			goto L0b2c;

		L0cdd:
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L0ce6;
			goto L0b64;

		L0ce6:
			goto L0b2c;

		L0ce9:
			this.oCPU.SI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2517_0b1d");

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID1"></param>
		/// <param name="playerID2"></param>
		public void F0_2517_0cef(short playerID1, short playerID2)
		{
			this.oCPU.Log.EnterBlock($"F0_2517_0cef({playerID1}, {playerID2})");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0x8);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0x0);

		L0cff:
			// Instruction address 0x2517:0x0d05, size: 5
			this.oCPU.AX.UInt16 = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE)
				goto L0d2d;

			// Instruction address 0x2517:0x0d17, size: 5
			this.oCPU.AX.UInt16 = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID2,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E)
				goto L0d2d;

			this.oCPU.WriteUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.ORUInt8(this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x1));
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);

		L0d2d:
			// Instruction address 0x2517:0x0d33, size: 5
			this.oCPU.AX.UInt16 = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID2,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE)
				goto L0d5b;

			// Instruction address 0x2517:0x0d45, size: 5
			this.oCPU.AX.UInt16 = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));
			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E)
				goto L0d5b;

			this.oCPU.WriteUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.ORUInt8(this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x2));
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);

		L0d5b:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0x48);
			if (this.oCPU.Flags.L) goto L0cff;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x3);
			if (this.oCPU.Flags.NE) goto L0d91;
			
			// Instruction address 0x2517:0x0d73, size: 5
			this.oParent.Segment_1ade.F0_1ade_1d2e(playerID1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				playerID2);
			
			// Instruction address 0x2517:0x0d84, size: 5
			this.oParent.Segment_1ade.F0_1ade_1d2e(playerID2,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)),
				playerID1);
			
			this.oCPU.AX.UInt16 = 0x1;
			goto L0d93;

		L0d91:
			this.oCPU.AX.UInt16 = 0;

		L0d93:
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2517_0cef");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2517_0d97(short playerID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2517_0d97({playerID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0x6);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x10);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0x0);

			do
			{
				if (this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].StatusFlag != 0xff &&
					this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].PlayerID == playerID &&
					(this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].ImprovementFlags0 & 0x1) != 0)
				{
					// Instruction address 0x2517:0x0dda, size: 5
					this.oCPU.AX.UInt16 = (ushort)((short)this.oGameData.Map.GetDistance(
						this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].Position.X,
						this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].Position.Y,
						xPos,
						yPos));

					this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
					this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
					this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), this.oCPU.AX.UInt16);
					if (this.oCPU.Flags.L)
					{
						this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4),
							this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
					}
				}

				this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6),
					this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))));
			}
			while (this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)) < 128);

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));

			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2517_0d97");

			return this.oCPU.AX.UInt16;
		}
	}
}
