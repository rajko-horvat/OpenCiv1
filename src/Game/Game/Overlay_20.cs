using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class Overlay_20
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public Overlay_20(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="param2"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="citySize"></param>
		/// <returns></returns>
		public ushort F20_0000_0000(short playerID, ushort param2, int xPos, int yPos, ushort citySize)
		{
			this.oCPU.Log.EnterBlock($"F20_0000_0000({playerID}, {param2}, {xPos}, {yPos}, {citySize})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x14);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			TerrainTypeEnum local_e;

			// Instruction address 0x0000:0x0017, size: 5
			this.oParent.Segment_25fb.F0_25fb_3401(playerID, 0, xPos, yPos, 4);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L0029;

		L0026:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L0029:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x80);
			if (this.oCPU.Flags.L) goto L0033;
			goto L0502;

		L0033:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8(this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].StatusFlag, 0xff);
			if (this.oCPU.Flags.NE) goto L0026;
			this.oCPU.AX.Word = (ushort)this.oGameData.Players[playerID].NationalityID;
			this.oCPU.AX.Word = this.oCPU.DEC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x7);
			if (this.oCPU.Flags.L) goto L0057;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));

		L0057:
			this.oCPU.CX.Low = 0x4;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.SHL_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.CX.Low));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

		L0062:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);

			if (this.oGameData.CityNameFlags[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].X == -1)
				goto L00ab;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x10);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			if (this.oCPU.Flags.NE) goto L008e;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0xe0);

		L008e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x100);
			if (this.oCPU.Flags.NE) goto L00ab;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3e7);
			if (this.oCPU.Flags.NE) goto L00a6;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);

		L00a6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x3e7);

		L00ab:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x0);
			if (this.oCPU.Flags.E) goto L0062;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].NameID = this.oCPU.AX.Low;

			this.oGameData.CityNameFlags[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))] = new GPoint(xPos, yPos);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.PlayerFlags);
			if (this.oCPU.Flags.E) goto L0118;
			
			this.oParent.Overlay_23.F23_0000_0000(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L00fe;

		L00f8:
			this.oCPU.AX.Word = 0xffff;
			goto L053b;

		L00fe:
			byte ubCityNameID = this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].NameID;
			char[] acCityName = this.oGameData.CityNames[ubCityNameID].ToCharArray();
			acCityName[12] = '\0';
			this.oGameData.CityNames[ubCityNameID] = new string(acCityName);

		L0118:
			ubCityNameID = this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].NameID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0xb);

			while (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) > 0 &&
				this.oGameData.CityNames[ubCityNameID][this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] == ' ')
			{
				acCityName = this.oGameData.CityNames[ubCityNameID].ToCharArray();
				acCityName[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] = '\0';
				this.oGameData.CityNames[ubCityNameID] = new string(acCityName);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc),
					this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			}

			// Instruction address 0x0000:0x016f, size: 5
			this.oParent.Segment_1866.F0_1866_250e_AddReplayData(1, (byte)playerID,
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].NameID,
				(byte)xPos, (byte)yPos);

			// Instruction address 0x0000:0x0181, size: 5
			this.oParent.MapManagement.F0_2aea_16ee_RemoveImprovement(xPos, yPos, 4, 2);

			// Instruction address 0x0000:0x0193, size: 5
			this.oParent.MapManagement.F0_2aea_1653_ClearOrSetImprovements(xPos, yPos, 9, 0);

			// Instruction address 0x0000:0x01a1, size: 5
			if (this.oGameData.Map[xPos, yPos].Multi1 < -1)
			{
				// Instruction address 0x0000:0x01c1, size: 5
				this.oParent.MapManagement.F0_2aea_1653_ClearOrSetImprovements(xPos, yPos, 2, 0);
			}
		
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].StatusFlag = 0;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.X = xPos;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.Y = yPos;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].ActualSize = (sbyte)citySize;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].VisibleSize = 0;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].WorkerFlags = 0;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].BaseTrade = 0;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].FoodCount = 0;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].ShieldsCount = 0;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].ImprovementFlags = 0;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].CurrentProductionID = 1;

			// Instruction address 0x0000:0x021d, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Gunpowder);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].CurrentProductionID = 4;
			}
		
			// Instruction address 0x0000:0x0235, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Conscription);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.AX.Word = 0x1c;
				this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
				this.oCPU.BX.Word = this.oCPU.AX.Word;
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].CurrentProductionID = 5;
			}
		
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Unknown[0] = -1;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Unknown[1] = -1;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);

		L026a:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].PlayerID != playerID) goto L0289;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0289;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L0289:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x80);
			if (this.oCPU.Flags.L) goto L026a;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x0);
			if (this.oCPU.Flags.E) goto L02ad;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].ImprovementFlags = 1;

		L02ad:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].BaseTrade = 0;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].PlayerID = playerID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);

		L02c6:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));

			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].TradeCityIDs[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] = -1;
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x3);
			if (this.oCPU.Flags.L) goto L02c6;

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].SpecialWorkerFlags = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);

		L02f2:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			GPoint direction = TerrainMap.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))];

			// Instruction address 0x0000:0x0307, size: 5
			local_e = this.oGameData.Map[xPos + direction.X, yPos + direction.Y].TerrainType;
			
			if (local_e != TerrainTypeEnum.Water) goto L0349;

			// Instruction address 0x0000:0x0327, size: 5
			this.oParent.MapManagement.F0_2aea_195d_GetGroupSize(xPos + direction.X, yPos + direction.Y);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x100);
			if (this.oCPU.Flags.G) goto L033c;

			if (playerID != this.oGameData.HumanPlayerID)
				goto L0349;

		L033c:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].StatusFlag |= 2;

		L0349:
			if (local_e == TerrainTypeEnum.River) goto L0355;

			if (local_e != TerrainTypeEnum.Mountains) goto L0362;

		L0355:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].StatusFlag |= 8;

		L0362:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8);
			if (this.oCPU.Flags.LE) goto L02f2;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x0);
			if (this.oCPU.Flags.E) goto L0385;

			if (playerID != this.oGameData.HumanPlayerID) goto L0385;

			this.oParent.Help.F4_0000_02d3(0x4f66);

		L0385:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);
			goto L0411;

		L038d:
			// Instruction address 0x0000:0x039b, size: 5
			//this.oParent.Graphics.F0_VGA_038c_GetPixel(2,
			//	this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 80,
			//	this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10),
				(short)this.oGameData.Map[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Layer2_PlayerOwnership);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x8);
			if (this.oCPU.Flags.L) goto L03bf;

			// Instruction address 0x0000:0x03b7, size: 5
			//this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 80,
			//	this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 8);

			this.oGameData.Map[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Layer2_PlayerOwnership = 8;

		L03bf:
			if (playerID == this.oGameData.HumanPlayerID) goto L040e;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x18);
			if (this.oCPU.Flags.G) goto L040e;

			// Instruction address 0x0000:0x03d3, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L040e;

			// Instruction address 0x0000:0x03e5, size: 5
			this.oParent.MapManagement.F0_2aea_1369_GetCellUnitPlayerID(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.HumanPlayerID);
			if (this.oCPU.Flags.NE) goto L040e;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].VisibleSize = 1;
			
			// Instruction address 0x0000:0x0406, size: 5
			this.oParent.MapManagement.F0_2aea_1601_UpdateVisiblemprovements(xPos, yPos);

		L040e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

		L0411:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x2d);
			if (this.oCPU.Flags.GE) goto L0456;
			
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			direction = TerrainMap.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))];

			// Instruction address 0x0000:0x0424, size: 5
			this.oCPU.AX.Word = (ushort)((short)this.oGameData.Map.WrapXPosition(xPos + direction.X));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), (ushort)((short)(yPos + direction.Y)));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x14);
			if (this.oCPU.Flags.LE) goto L0442;
			goto L038d;

		L0442:
			// Instruction address 0x0000:0x03b7, size: 5
			//this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 80,
			//	this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
			//	(ushort)playerID);

			this.oGameData.Map[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Layer2_PlayerOwnership = playerID;

			goto L03bf;

		L0456:
			if (playerID != this.oGameData.HumanPlayerID) goto L0499;

			this.oCPU.TEST_UInt8((byte)(this.oGameData.GameSettingFlags & 0xff), 0x8);
			if (this.oCPU.Flags.E) goto L0484;

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0484;
			
			this.oParent.Overlay_22.F22_0000_0eaf(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

		L0484:
			// Instruction address 0x0000:0x048a, size: 5
			this.oParent.Segment_1ade.F0_1ade_03ea(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			// Instruction address 0x0000:0x0492, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			goto L04fd;

		L0499:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x04a7, size: 5
			this.oParent.Segment_1ade.F0_1ade_0421(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			
			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].CurrentProductionID = (sbyte)this.oCPU.AX.Low;

			// Instruction address 0x0000:0x04bb, size: 5
			this.oParent.CityWorker.F0_1d12_6c97_PlayerHasWonder(this.oGameData.HumanPlayerID, (int)WonderEnum.ApolloProgram);
			
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L04fd;

			this.oGameData.Map[this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.X,
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.Y].SetVisiblity(this.oGameData.HumanPlayerID, true);

			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].VisibleSize = 1;

			// Instruction address 0x0000:0x04f5, size: 5
			this.oParent.MapManagement.F0_2aea_1601_UpdateVisiblemprovements(
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.X,
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.Y);

		L04fd:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			goto L053b;

		L0502:
			if (playerID != this.oGameData.HumanPlayerID)
				goto L00f8;

			this.oParent.Var_2f9e = 4;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x051c, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4f74);

			// Instruction address 0x0000:0x0530, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 64, 80);

			goto L00f8;

		L053b:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F20_0000_0000");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		public void F20_0000_0540(short cityID)
		{
			this.oCPU.Log.EnterBlock($"F20_0000_0540({cityID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x10);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			int local_c;

			local_c = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L0552:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			GPoint direction = TerrainMap.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))];

			// Instruction address 0x0000:0x0575, size: 5
			local_c |= 1 << TerrainMap.TerrainTypeEnumToValue(this.oGameData.Map[this.oGameData.Cities[cityID].Position.X + direction.X,
				this.oGameData.Cities[cityID].Position.Y + direction.Y].TerrainType);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8);
			if (this.oCPU.Flags.LE) goto L0552;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0598, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x0000:0x05a8, size: 5
			this.oParent.Array_30b8[3] = this.oCPU.ReadString(this.oCPU.DS.Word, 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x05b9, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(10));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x9);
			if (this.oCPU.Flags.BE) goto L05c9;
			goto L0bc6;

		L05c9:
			switch (this.oCPU.AX.Word)
			{
				case 0:
					goto L05d1;
				case 1:
					goto L0698;
				case 2:
					goto L0703;
				case 3:
					goto L0750;
				case 4:
					goto L07a4;
				case 5:
					goto L07fe;
				case 6:
					goto L08b1;
				case 7:
					goto L08e8;
				case 8:
					goto L08e8;
				case 9:
					goto L08e8;
			}

		L05d1:
			if ((local_c & 0x10) != 0) goto L05da;
			goto L0bc6;

		L05da:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0xfffe);
			if (this.oCPU.Flags.NE) goto L05ed;
			goto L0bc6;

		L05ed:
			// Instruction address 0x0000:0x05f1, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(24));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L05ed;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oGameData.Cities[cityID].ImprovementFlags0;
			this.oCPU.DX.Word = this.oGameData.Cities[cityID].ImprovementFlags1;
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.BX.Word = this.oCPU.AND_UInt16(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.AND_UInt16(this.oCPU.CX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = this.oCPU.OR_UInt16(this.oCPU.CX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L05ed;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.NOT_UInt16(this.oCPU.AX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oGameData.Cities[cityID].ImprovementFlags0 &= this.oCPU.AX.Word;
			this.oGameData.Cities[cityID].ImprovementFlags1 &= this.oCPU.DX.Word;

			// Instruction address 0x0000:0x064c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Earthquake in ");

			// Instruction address 0x0000:0x0657, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x0000:0x0667, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\n");

			// Instruction address 0x0000:0x067d, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oGameData.Static.ImprovementDefinitions(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)) + 1).Name);

			// Instruction address 0x0000:0x068d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " destroyed.\n");

			goto L0bc6;

		L0698:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x06aa, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oGameData.Cities[cityID].PlayerID, (int)TechnologyEnum.Medicine);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L06b9;

			goto L0bc6;

		L06b9:
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x100);
			if (this.oCPU.Flags.E) goto L06c4;
			goto L0bc6;

		L06c4:
			// Instruction address 0x0000:0x06ce, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oGameData.Cities[cityID].PlayerID, 
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xcc4));
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L06dd;

			goto L0bc6;

		L06dd:
			// Instruction address 0x0000:0x06e1, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4f99);

			this.oCPU.CMP_UInt8((byte)this.oGameData.Cities[cityID].ActualSize, 0x0);
			if (this.oCPU.Flags.NE) goto L06f3;
			goto L0bc6;

		L06f3:
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Low = 0x4;

		L06fa:
			this.oCPU.IDIV_UInt8(this.oCPU.AX, this.oCPU.CX.Low);
			this.oGameData.Cities[cityID].ActualSize -= (sbyte)this.oCPU.AX.Low;
			goto L0bc6;

		L0703:
			if ((local_c & 0x800) != 0) goto L070d;
			goto L0bc6;

		L070d:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x80);
			if (this.oCPU.Flags.E) goto L071f;
			goto L0bc6;

		L071f:
			// Instruction address 0x0000:0x0729, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oGameData.Cities[cityID].PlayerID, 
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xca6));
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L0738;

			goto L0bc6;

		L0738:
			// Instruction address 0x0000:0x073c, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4f9d);

			if (this.oGameData.Cities[cityID].ActualSize > 1)
				goto L06f3;

			goto L0bc6;

		L0750:
			if ((local_c & 0x20) != 0) goto L0759;
			goto L0bc6;

		L0759:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x8);
			if (this.oCPU.Flags.E) goto L076b;
			goto L0bc6;

		L076b:
			// Instruction address 0x0000:0x0775, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oGameData.Cities[cityID].PlayerID, 
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xc2e));
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L0784;

			goto L0bc6;

		L0784:
			// Instruction address 0x0000:0x0788, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4fa1);

			if (this.oGameData.Cities[cityID].ActualSize > 1)
				goto L079a;

			goto L0bc6;

		L079a:
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Low = 0x3;
			goto L06fa;

		L07a4:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8((byte)this.oGameData.Cities[cityID].ActualSize, 0x0);
			if (this.oCPU.Flags.NE) goto L07b6;
			goto L0bc6;

		L07b6:
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x4);
			if (this.oCPU.Flags.E) goto L07c0;
			goto L0bc6;

		L07c0:
			// Instruction address 0x0000:0x07ca, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oGameData.Cities[cityID].PlayerID, 
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xc10));
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L07d9;

			goto L0bc6;

		L07d9:
			// Instruction address 0x0000:0x07dd, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4fa5);

			this.oGameData.Cities[cityID].FoodCount = 0;
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.IDIV_UInt8(this.oCPU.AX, this.oCPU.CX.Low);
			this.oGameData.Cities[cityID].ActualSize -= (sbyte)this.oCPU.AX.Low;

			// Instruction address 0x0000:0x068d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "Citizens demand GRANARY.\n");

			goto L0bc6;

		L07fe:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0xfffe);
			if (this.oCPU.Flags.NE) goto L0811;
			goto L0bc6;

		L0811:
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x100);
			if (this.oCPU.Flags.E) goto L081c;
			goto L0bc6;

		L081c:
			// Instruction address 0x0000:0x0826, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oGameData.Cities[cityID].PlayerID, 
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xcc4));
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L0835;

			goto L0bc6;

		L0835:
			// Instruction address 0x0000:0x0839, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(24));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L0835;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oGameData.Cities[cityID].ImprovementFlags0;
			this.oCPU.DX.Word = this.oGameData.Cities[cityID].ImprovementFlags1;
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.BX.Word = this.oCPU.AND_UInt16(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.AND_UInt16(this.oCPU.CX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = this.oCPU.OR_UInt16(this.oCPU.CX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L0835;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.NOT_UInt16(this.oCPU.AX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oGameData.Cities[cityID].ImprovementFlags0 &= this.oCPU.AX.Word;
			this.oGameData.Cities[cityID].ImprovementFlags1 &= this.oCPU.DX.Word;

			// Instruction address 0x0000:0x089a, size: 5
			this.oParent.Array_30b8[0] = this.oGameData.Static.ImprovementDefinitions(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)) + 1).Name;

			// Instruction address 0x0000:0x08a6, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4fc3);

			goto L0bc6;

		L08b1:
			if ((local_c & 0x400) != 0) goto L08bb;
			goto L0bc6;

		L08bb:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x2);
			if (this.oCPU.Flags.E) goto L08cd;
			goto L0bc6;

		L08cd:
			// Instruction address 0x0000:0x08d1, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4fc7);

			this.oGameData.Cities[cityID].FoodCount = 0;
			this.oGameData.Cities[cityID].ShieldsCount = 0;
			goto L0bc6;

		L08e8:
			// Instruction address 0x0000:0x08ef, size: 5
			this.oParent.CityWorker.F0_1d12_0045_ProcessCityState(cityID, -1);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70e4);
			
			if (this.oParent.Var_70e2 >= this.oParent.Var_70e4)
				goto L0bc6;

			// Instruction address 0x0000:0x090c, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(3));

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0924;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L0963;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.E) goto L0968;
			goto L0934;

		L0924:
			// Instruction address 0x0000:0x092c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Rioting in ");

		L0934:
			// Instruction address 0x0000:0x0937, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x0000:0x0947, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\nCitizens demand ");

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x8);
			if (this.oCPU.Flags.NE) goto L096d;
			
			// Instruction address 0x0000:0x09c8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "TEMPLE\n");

			goto L09c3;

		L0963:
			// Instruction address 0x0000:0x092c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Corruption in ");

			goto L0934;

		L0968:
			// Instruction address 0x0000:0x092c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Scandal in ");

			goto L0934;

		L096d:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x40);
			if (this.oCPU.Flags.NE) goto L0981;
			
			// Instruction address 0x0000:0x09c8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "COURTHOUSE\n");

			goto L09c3;

		L0981:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x10);
			if (this.oCPU.Flags.NE) goto L0995;
			
			// Instruction address 0x0000:0x09c8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "MARKETPLACE\n");

			goto L09c3;

		L0995:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oGameData.Cities[cityID].PlayerID, (int)TechnologyEnum.Religion) != 0 &&
				(this.oGameData.Cities[cityID].ImprovementFlags0 & 0x400) == 0)
			{
				// Instruction address 0x0000:0x09c8, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "CATHEDRAL\n");
			}
			else
			{
				// Instruction address 0x0000:0x09c8, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "lower taxes.\n");
			}

		L09c3:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.oGameData.Cities[cityID].PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.PlayerFlags);
			if (this.oCPU.Flags.E) goto L0a14;

			// Instruction address 0x0000:0x09f3, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			// Instruction address 0x0000:0x0a07, size: 5
			this.oParent.Segment_1403.F0_1403_3ed7(this.oGameData.Cities[cityID].Position.X, this.oGameData.Cities[cityID].Position.Y);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

		L0a14:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oGameData.Cities[cityID].FoodCount = 0;
			this.oGameData.Cities[cityID].ShieldsCount = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70e4);
			
			if (this.oParent.Var_70e2 > this.oParent.Var_70e4)
				goto L0bc6;

			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x1);
			if (this.oCPU.Flags.E) goto L0a48;
			goto L0bc6;

		L0a48:
			if (this.oGameData.Players[this.oGameData.Cities[cityID].PlayerID].CityCount > 3)
				goto L0a5b;
			goto L0bc6;

		L0a5b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L0acd;

		L0a62:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x0a88, size: 5
			this.oCPU.AX.Word = (ushort)((short)this.oGameData.Map.GetDistance(
				this.oGameData.Cities[cityID].Position.X,
				this.oGameData.Cities[cityID].Position.Y,
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.X,
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.Y));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0a9a, size: 5
			this.oParent.CityWorker.F0_1d12_0045_ProcessCityState(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), -1);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70e2);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70e4));
			this.oCPU.CX.Low = 0x5;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L0aca;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

		L0aca:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L0acd:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.GE) goto L0aee;
			this.oCPU.AX.Word = (ushort)cityID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0aee;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8(this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L0aee;
			goto L0a62;

		L0aee:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0af7;
			goto L0bc6;

		L0af7:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			if (this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].PlayerID !=
				this.oGameData.Cities[cityID].PlayerID) goto L0b14;
			goto L0bc6;

		L0b14:
			if (!this.oGameData.Map[this.oGameData.Cities[cityID].Position.X, this.oGameData.Cities[cityID].Position.Y].IsVisibleTo(this.oGameData.HumanPlayerID)) goto L0b92;

			// Instruction address 0x0000:0x0b43, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Residents of ");

			// Instruction address 0x0000:0x0b4e, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x0000:0x0b5e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " admire\nthe prosperity of ");

			// Instruction address 0x0000:0x0b69, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));

			// Instruction address 0x0000:0x0b79, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			// Instruction address 0x0000:0x0b8a, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

		L0b92:
			this.oParent.Overlay_22.F22_0000_0af5(cityID, 
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].PlayerID);
			
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

		L0bc6:
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba06), 0x0);
			if (this.oCPU.Flags.NE) goto L0bd0;
			goto L0ca3;

		L0bd0:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.oGameData.Cities[cityID].PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.PlayerFlags);
			if (this.oCPU.Flags.E) goto L0c18;

			this.oParent.Var_2f9e = 4;

			// Instruction address 0x0000:0x0bf9, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			// Instruction address 0x0000:0x0c0d, size: 5
			this.oParent.Segment_1403.F0_1403_3ed7(this.oGameData.Cities[cityID].Position.X, this.oGameData.Cities[cityID].Position.Y);

			goto L0ca3;

		L0c18:
			if (!this.oGameData.Map[this.oGameData.Cities[cityID].Position.X, this.oGameData.Cities[cityID].Position.Y].IsVisibleTo(this.oGameData.HumanPlayerID)) goto L0ca3;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);

		L0c4c:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06)), 0xa);
			if (this.oCPU.Flags.NE) goto L0c4c;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

			this.oParent.Var_2f9e = 2;

			// Instruction address 0x0000:0x0c73, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 64);

			// Instruction address 0x0000:0x0c9b, size: 5
			this.oParent.MapManagement.F0_2aea_0008(oParent.GameData.HumanPlayerID,
				this.oGameData.Cities[cityID].Position.X - 10,
				this.oGameData.Cities[cityID].Position.Y - 6);

		L0ca3:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F20_0000_0540");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="flag"></param>
		/// <returns></returns>
		public ushort F20_0000_0ca9(short playerID, bool flag)
		{
			this.oCPU.Log.EnterBlock($"F20_0000_0ca9({playerID}, {flag})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x1a);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			
			if (!flag) goto L0cc3;

			this.oParent.Var_aa_Rectangle.ScreenID = 1;

		L0cc3:
			if (!flag) goto L0cd9;

			this.oParent.Overlay_14.F14_0000_0000(0x506b, 3);

		L0cd9:
			this.oGameData.Players[0].Score = 0;
			
			if (!flag) goto L0d3e;

			this.oCPU.TEST_UInt16((ushort)this.oGameData.SpaceshipFlags, 0x100);
			if (this.oCPU.Flags.E) goto L0d3e;

			// Instruction address 0x0000:0x0cfd, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA("SCORING COMPLETED", 160, 100, 15);

			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			// Instruction address 0x0000:0x0d22, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x0000:0x0d2a, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Instruction address 0x0000:0x0d34, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			this.oCPU.AX.Word = 0;
			goto L13f3;

		L0d3e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x1a);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1a);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x3e7);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb25c, 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb2bc, 0x1a);
			this.oCPU.AX.Word = (ushort)this.oGameData.Players[playerID].TaxRate;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oGameData.Players[playerID].TaxRate = (short)(6 - this.oGameData.Players[playerID].ScienceTaxRate);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);
			goto L0e3c;

		L0d85:
			F20_0000_13f8((ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) & 1));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L0d96:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70e2);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0d85;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L0db8;

		L0da5:
			F20_0000_13f8((ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) & 1) + 2));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L0db8:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70e2));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70e4));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_e8b8));
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			if (this.oCPU.Flags.G) goto L0da5;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L0df1;

		L0ddd:
			F20_0000_13f8((ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) & 1) + 4));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L0df1:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70e4);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0ddd;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L0e19;

		L0e00:
			// Instruction address 0x0000:0x0e03, size: 5
			this.oParent.CityWorker.F0_1d12_6da1_GetSpecialWorkerFlags(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));

			F20_0000_13f8((ushort)(this.oCPU.AX.Word + 5));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L0e19:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_e8b8);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0e00;

		L0e21:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70e2));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70e4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));

		L0e39:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));

		L0e3c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x80);
			if (this.oCPU.Flags.GE) goto L0e79;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8(this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L0e39;
			
			if (this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID != playerID)
				goto L0e39;

			// Instruction address 0x0000:0x0e63, size: 5
			this.oParent.CityWorker.F0_1d12_0045_ProcessCityState(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), -1);

			if (!flag) goto L0e21;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L0d96;

		L0e79:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oGameData.Players[playerID].TaxRate = (short)this.oCPU.AX.Word;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd766, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0e93, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[playerID].Nationality);

			// Instruction address 0x0000:0x0ea3, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Citizens (");

			// Instruction address 0x0000:0x0ec4, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd766), 10));

			// Instruction address 0x0000:0x0ed4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")");

			if (!flag) goto L0ef9;

			// Instruction address 0x0000:0x0ef1, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadowToRectAA(0xba06,
				16,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				15);

		L0ef9:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb2bc);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x10);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd764, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x1);

		L0f15:
			this.oCPU.SI.Word = (ushort)this.oGameData.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))];
			this.oCPU.CMP_UInt16(this.oCPU.SI.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L0f26;
			goto L0fb9;

		L0f26:
			this.oCPU.CMP_UInt16(this.oCPU.SI.Word, 0x80);
			if (this.oCPU.Flags.NE) goto L0f2f;
			goto L0fb9;

		L0f2f:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.SI.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			
			if (this.oGameData.Cities[this.oCPU.SI.Word].PlayerID != playerID) goto L0fb9;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x98));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x12c);
			if (this.oCPU.Flags.LE) goto L0f6a;

			// Instruction address 0x0000:0x0f5a, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x5116) + 2, 8, 99);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x10);

		L0f6a:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x18);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);

			if (!flag) goto L0fb4;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xb4);
			if (this.oCPU.Flags.GE) goto L0fb4;

			// Instruction address 0x0000:0x0f8c, size: 5
			this.oParent.CityWorker.F0_1d12_7045(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) - 2));

			// Instruction address 0x0000:0x0fac, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA(
				this.oGameData.Static.Wonders[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].Name,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)) + 20,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				11);

		L0fb4:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd764, this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd764), 0x14));

		L0fb9:
			if (this.oGameData.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))] != -1)
				goto L0fca;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);

		L0fca:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x15);
			if (this.oCPU.Flags.G) goto L0fd6;
			goto L0f15;

		L0fd6:
			// Instruction address 0x0000:0x0fe3, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[playerID].Nationality);

			// Instruction address 0x0000:0x0ff3, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Achievements (");

			// Instruction address 0x0000:0x1014, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd764), 10));

			// Instruction address 0x0000:0x1024, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")");

			if (!flag) goto L1049;

			// Instruction address 0x0000:0x1041, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadowToRectAA(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 15);

		L1049:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd764);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd766));
			this.oGameData.Players[0].Score = (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xa));
			this.oCPU.SI.Word = (ushort)this.oGameData.Players[oParent.GameData.HumanPlayerID].SpaceshipPopulation;
			this.oCPU.SI.Word = this.oCPU.OR_UInt16(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.NE) goto L1068;
			goto L1118;

		L1068:
			if (this.oGameData.Players[this.oGameData.HumanPlayerID].SpaceshipSuccessRate != 0) goto L1072;
			goto L1118;

		L1072:
			this.oCPU.AX.Word = (ushort)this.oGameData.Players[this.oGameData.HumanPlayerID].SpaceshipSuccessRate;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.SI.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L1088;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);

		L1088:
			// Instruction address 0x0000:0x1090, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "SpaceShip: (");

			// Instruction address 0x0000:0x10b0, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 10));
			
			if (this.oGameData.Players[oParent.GameData.HumanPlayerID].SpaceshipETAYear != oParent.GameData.Year) goto L10d0;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oGameData.Players[0].Score += (short)this.oCPU.AX.Word;
			goto L10e0;

		L10d0:
			// Instruction address 0x0000:0x10d8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " possible");

		L10e0:
			// Instruction address 0x0000:0x10e8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")");

			if (!flag) goto L1114;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xb8);
			if (this.oCPU.Flags.GE) goto L1114;

			// Instruction address 0x0000:0x110c, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadowToRectAA(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 15);

		L1114:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xa));

		L1118:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			if (this.oGameData.PollutedSquareCount == 0) goto L1174;

			// Instruction address 0x0000:0x112c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Pollution: (");

			// Instruction address 0x0000:0x1151, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)(-10 * this.oGameData.PollutedSquareCount), 10));

			// Instruction address 0x0000:0x1161, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")   ");

			this.oCPU.AX.Word = 0xa;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)this.oGameData.PollutedSquareCount);
			this.oGameData.Players[0].Score -= (short)this.oCPU.AX.Word;

		L1174:
			if (oParent.GameData.Year <= 0) goto L11e3;
			if (this.oGameData.PeaceTurnCount == 0) goto L11e3;

			// Instruction address 0x0000:0x1191, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oGameData.PeaceTurnCount * 3, 0, 100);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x11a4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "Peace: (+");

			// Instruction address 0x0000:0x11c4, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 10));

			// Instruction address 0x0000:0x11d4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ") ");

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oGameData.Players[0].Score += (short)this.oCPU.AX.Word;

		L11e3:
			if (this.oGameData.Players[this.oGameData.HumanPlayerID].FutureTechnologyCount == 0) goto L123a;

			// Instruction address 0x0000:0x11f2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "Future Tech: (+");

			// Instruction address 0x0000:0x1217, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)(5 * this.oGameData.Players[this.oGameData.HumanPlayerID].FutureTechnologyCount), 10));

			// Instruction address 0x0000:0x1227, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")");

			this.oCPU.AX.Word = 0x5;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)this.oGameData.Players[this.oGameData.HumanPlayerID].FutureTechnologyCount);
			this.oGameData.Players[0].Score += (short)this.oCPU.AX.Word;

		L123a:
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba06), 0x0);
			if (this.oCPU.Flags.E) goto L1269;
			
			if (!flag) goto L1269;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xb8);
			if (this.oCPU.Flags.GE) goto L1269;

			// Instruction address 0x0000:0x125d, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadowToRectAA(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xa));

		L1269:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0xffff);
			
			if (this.oParent.Var_b884 == 0) goto L128e;

			this.oCPU.AX.Word = 0x64;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)((short)this.oGameData.MaximumPlayers));
			this.oCPU.CX.Word = 0x226;
			this.oCPU.CX.Word = this.oCPU.SUB_UInt16(this.oCPU.CX.Word, (ushort)this.oGameData.TurnCount);
			this.oCPU.CX.Word = this.oCPU.SHL_UInt16(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.ADD_UInt16(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.ADD_UInt16(this.oCPU.CX.Word, 0x190);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.CX.Word);

		L128e:
			if (this.oGameData.Players[0].Score < 0)
			{
				this.oGameData.Players[0].Score = 0;
			}

			this.oCPU.AX.Word = (ushort)this.oGameData.Players[0].Score;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L12d6;

			// Instruction address 0x0000:0x12ab, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Total Score: ");

			// Instruction address 0x0000:0x12cc, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oGameData.Players[0].Score, 10));
			goto L130c;

		L12d6:
			// Instruction address 0x0000:0x12de, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Bonus Score: ");

			// Instruction address 0x0000:0x12fe, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 10));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
			this.oGameData.Players[0].Score = (short)this.oCPU.AX.Word;

		L130c:
			if (!flag) goto L1330;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xba);
			if (this.oCPU.Flags.GE) goto L1330;

			// Instruction address 0x0000:0x1328, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadowToRectAA(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 15);

		L1330:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xba);
			if (this.oCPU.Flags.L) goto L1348;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5116, this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5116)));

			goto L0cc3;

		L1348:
			this.oCPU.AX.Word = (ushort)this.oGameData.Players[0].Score;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb77e, this.oCPU.AX.Word);

			if (!flag)
				goto L13f0;

			// Instruction address 0x0000:0x136f, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 35, 192, 250, 7, 8);

			if (this.oGameData.Players[0].Score > 0)
			{
				// Instruction address 0x0000:0x139f, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oGameData.Players[0].Score / 4, 0, 250);

				// Instruction address 0x0000:0x13b4, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 35, 192, (short)this.oCPU.AX.Word, 7, 11);
			}

			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			// Instruction address 0x0000:0x13d9, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x0000:0x13e1, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Instruction address 0x0000:0x13eb, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

		L13f0:
			this.oCPU.AX.Word = (ushort)this.oGameData.Players[0].Score;

		L13f3:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F20_0000_0ca9");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		public void F20_0000_13f8(ushort param1)
		{
			this.oCPU.Log.EnterBlock($"F20_0000_13f8({param1})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb25c, this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb25c), 0x8));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb25c), 0x124);
			if (this.oCPU.Flags.LE) goto L141d;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5116);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb2bc, this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb2bc), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb2bc);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x10);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb25c, this.oCPU.AX.Word);

		L141d:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb2bc), 0xa0);
			if (this.oCPU.Flags.G) goto L1442;

			// Instruction address 0x0000:0x143a, size: 5
			this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(
				this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xb25c),
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xb2bc),
				this.oParent.Array_6e96[param1]);

		L1442:
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F20_0000_13f8");
		}
	}
}
