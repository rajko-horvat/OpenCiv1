using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class CheckPlayerTurn
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;

		public CheckPlayerTurn(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// This function handles given Player turn. All unit movements, keyboard and mouse events
		/// </summary>
		/// <param name="playerID"></param>
		public void F0_1403_000e_CheckPlayerTurn(int playerID)
		{
			// This function is referenced 1 time(s)
			// Standard C frame
			//this.oCPU.Log.EnterBlock("'Fn1'(Cdecl, Far, Return) at 0xe");
			// Local variables
			int local_a;
			int local_e = -1;
			int local_12 = 0;
			int local_18;
			int local_1c;
			int local_24 = 0;
			int local_26;
			int local_2c = 0;
			int local_30 = 0;
			int local_3a;
			int local_3e = 0;
			int local_40;
			GPoint direction;

			// function body
			this.oCPU.WriteInt16(this.oCPU.DS.UInt16, 0x6b90, (short)playerID);

			if (playerID == this.oParent.GameData.HumanPlayerID)
			{
				this.oParent.GameData.PlayerFlags = (short)(0x1 << this.oParent.GameData.HumanPlayerID);

				if (this.oParent.GameData.TurnCount == 20 || this.oParent.GameData.TurnCount == 60)
				{
					this.oParent.Help.F4_0000_02d3_ShowInstantAdvicePopup(0x1e60);
				}

				if (this.oParent.GameData.TurnCount == 40 || this.oParent.GameData.TurnCount == 80)
				{
					this.oParent.Help.F4_0000_02d3_ShowInstantAdvicePopup(0x1e67);
				}
			}

			for (int i = 0; i < 128; i++)
			{
				if (this.oParent.GameData.Players[playerID].Units[i].TypeID != -1 && this.oParent.Var_df60 != 1)
				{
					this.oParent.GameData.Players[playerID].Units[i].RemainingMoves =
						(short)(this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[i].TypeID].MoveCount * 3);

					if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[i].TypeID].MovementType != UnitMovementTypeEnum.Water)
					{
						if (this.oParent.CityWorker.F0_1d12_6c97_PlayerHasWonder(playerID, WonderEnum.Lighthouse) ||
							this.oParent.CityWorker.F0_1d12_6c97_PlayerHasWonder(playerID, WonderEnum.MagellansExpedition))
						{
							this.oParent.GameData.Players[playerID].Units[i].RemainingMoves += 3;
						}
					}
				}
			}

			int command;
			int maxUnitID = 127;
			bool flag1 = false;
			bool flag2 = true;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;

		Label17:
			int unitID = 0;
			flag2 = true;
			goto Label19;

		Label18:
			unitID++;

		Label19:
			if (unitID < 128) goto Label20;
			goto Label748;

		Label20:
			if (this.oParent.Var_1ae0 != 0)
			{
				// Instruction address 0x1403:0x0160, size: 5
				this.oParent.Segment_1238.F0_1238_1b44();
			}

			if (this.oParent.Var_dc48_GameEndType != 0)
			{
				unitID = 128;
				goto Label18;
			}

			if (unitID == maxUnitID)
			{
				flag4 = true;
			}

			if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID == -1) goto Label18;

			if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID >= 28)
			{
				this.oParent.GameData.Players[playerID].Units[unitID].TypeID = 1;
			}

			if (!flag6)
			{
				// Instruction address 0x1403:0x01f4, size: 5
				this.oParent.Segment_1866.F0_1866_01dc(
					this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
					this.oParent.GameData.Players[playerID].Units[unitID].Position.Y,
					playerID, unitID, false);
			}

			if ((this.oParent.GameData.Players[playerID].Units[unitID].Status & 0x9) != 0 ||
				this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves == 0) goto Label18;

			if ((this.oParent.GameData.Players[playerID].Units[unitID].Status & 0x4) != 0)
			{
				this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0xfb;
				this.oParent.GameData.Players[playerID].Units[unitID].Status |= 0x8;
				this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;

				// Instruction address 0x1403:0x0265, size: 5
				F0_1403_3f13(playerID, unitID);

				if (playerID != this.oParent.GameData.HumanPlayerID)
				{
					if (this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
						this.oParent.GameData.Players[playerID].Units[unitID].Position.Y).HasFlag(TerrainImprovementFlagsEnum.City))
					{
						local_3a = this.oParent.Segment_2dc4.F0_2dc4_00ba_GetCityID(this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
							this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);

						if (this.oParent.GameData.Cities[local_3a].ActualSize >= 3)
						{
							this.oParent.GameData.Players[playerID].Units[unitID].HomeCityID = (short)local_3a;
						}
					}
				}

				if (this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
					this.oParent.GameData.Players[playerID].Units[unitID].Position.Y).HasFlag(TerrainImprovementFlagsEnum.City))
				{
					local_3a = this.oParent.Segment_2dc4.F0_2dc4_00ba_GetCityID(this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
						this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);

					if (this.oParent.GameData.Players[playerID].Units[unitID].HomeCityID == local_3a)
					{
						if (this.oParent.Segment_1866.F0_1866_18d0(playerID, this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
							this.oParent.GameData.Players[playerID].Units[unitID].Position.Y) == 0)
						{
							this.oParent.Segment_1866.F0_1866_00c6(local_3a);
						}
					}
				}
				goto Label18;
			}

			if (playerID == this.oParent.GameData.HumanPlayerID)
			{
				if ((this.oParent.GameData.Players[playerID].Units[unitID].Status & 0xc2) == 0)
				{
					if (this.oParent.GameData.Players[playerID].Units[unitID].Position.X <= this.oParent.Var_d4cc_MapViewX ||
						this.oParent.GameData.Players[playerID].Units[unitID].Position.X >= this.oParent.Var_d4cc_MapViewX + 14 ||
						this.oParent.GameData.Players[playerID].Units[unitID].Position.Y <= this.oParent.Var_d75e_MapViewY ||
						this.oParent.GameData.Players[playerID].Units[unitID].Position.Y >= this.oParent.Var_d75e_MapViewY + 10)
					{
						if (!flag4)
						{
							flag2 = false;
						}
						else
						{
							// Instruction address 0x1403:0x03dd, size: 5
							this.oParent.CommonTools.F0_1182_0134_WaitTimer(30);

							this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(playerID,
								this.oParent.GameData.Players[playerID].Units[unitID].Position.X - 7,
								this.oParent.GameData.Players[playerID].Units[unitID].Position.Y - 6);

							maxUnitID = unitID - 1;
							if (maxUnitID < 0)
								maxUnitID = 127;

							flag4 = false;

							if (this.oParent.GameData.TurnCount == 0)
							{
								F0_1403_4060(playerID, unitID);
							}

							goto Label54;
						}

						goto Label18;
					}
				}
			}

		Label54:
			if ((this.oParent.GameData.PlayerFlags & (0x1 << playerID)) != 0)
			{
				// Instruction address 0x1403:0x044c, size: 5
				F0_1403_4545();
			}

			local_a = 0;

			if (flag3)
			{
				// Instruction address 0x1403:0x046b, size: 5
				this.oParent.CommonTools.F0_1000_1697(0, 0, this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xd4dc));
			}

			flag3 = false;
			flag7 = false;

		Label59:
			if (((0x1 << playerID) & this.oParent.GameData.PlayerFlags) == 0)
			{
				// Instruction address 0x1403:0x0496, size: 5
				command = this.oParent.Segment_25fb.F0_25fb_0c9d(playerID, unitID);

				if (command != 0)
				{
					this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;
				}

				local_a++;

				if (local_a > 4)
				{
					command = ' ';
					this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;
					this.oParent.GameData.Players[playerID].Units[unitID].GoToNextDirection = -1;
				}
				goto Label152;
			}

			if (unitID >= 128 ||
				((this.oParent.GameData.Players[playerID].Units[unitID].Status & 0xc2) == 0 &&
					this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X == -1)) goto Label79;

			command = 'r';

			if ((this.oParent.GameData.Players[playerID].Units[unitID].Status & 0x40) != 0)
			{
				if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 0)
				{
					command = 'm';
				}
				else
				{
					command = 'i';
				}
			}

			if ((this.oParent.GameData.Players[playerID].Units[unitID].Status & 0x80) != 0)
			{
				command = 'm';

				if ((this.oParent.GameData.Players[playerID].Units[unitID].Status & 0x40) != 0)
				{
					command = 'f';
				}

				if ((this.oParent.GameData.Players[playerID].Units[unitID].Status & 0x2) != 0)
				{
					command = 'p';
				}
			}

			if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Air)
			{
				command = 'h';
			}
			goto Label151;

		Label79:
			// Instruction address 0x1403:0x05d2, size: 5
			F0_1403_4060(playerID, unitID);

			if (this.oParent.GameData.TurnCount == 0)
			{
				if (!flag6)
				{
					this.oParent.CAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x30b8), this.oParent.GameData.Players[playerID].Nation);
					this.oParent.Help.F4_0000_02d3_ShowInstantAdvicePopup(0x1e6e);

					flag6 = true;
				}
			}

			if (unitID < 128 && this.oParent.GameData.Players[playerID].Units[unitID].TypeID == 0)
			{
				if (!flag6)
				{
					this.oParent.Help.F4_0000_00af(playerID, unitID);

					flag6 = true;
				}
			}

			this.oParent.Segment_1866.F0_1866_0ad6(playerID, unitID, local_e, local_12);

			if (unitID < 128)
			{
				flag5 = true;
			}

			if (this.oParent.Var_db3a_MouseButton == 0)
			{
				// Instruction address 0x1403:0x0676, size: 5
				command = this.oParent.ManuBoxDialog.F0_2d05_0ac9_GetNavigationKey();

				if (command == 0xd && flag1)
				{
					local_1c = local_e;
					local_26 = local_12;
					this.oParent.Var_db3c_MouseXPos = 80;
					this.oParent.Var_db3e_MouseYPos = 8;
					this.oParent.Var_db3a_MouseButton = 0x1;
					goto Label114;
				}
				goto Label151;
			}

			local_1c = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(((this.oParent.Var_db3c_MouseXPos - 80) / 16) + this.oParent.Var_d4cc_MapViewX);
			local_26 = ((this.oParent.Var_db3e_MouseYPos - 8) / 16) + this.oParent.Var_d75e_MapViewY;

			if (this.oParent.Var_db3e_MouseYPos < 8)
			{
				// Instruction address 0x1403:0x0707, size: 5
				this.oParent.Segment_2c84.F0_2c84_0000_ShowTopMenu(playerID, unitID, -1);

				// Instruction address 0x1403:0x070f, size: 5
				F0_1403_4545();

				if (this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0xd4ca) != -1)
				{
					command = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xd4ca);

					if (unitID < 128) goto Label152;
					goto Label674;
				}
				goto Label722;
			}

			if (this.oParent.Var_db3c_MouseXPos < 80)
			{
				if (this.oParent.Var_db3e_MouseYPos < 58)
				{
					// Instruction address 0x1403:0x0775, size: 5
					// Instruction address 0x1403:0x0781, size: 5
					this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(playerID,
						this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(this.oParent.Var_db3c_MouseXPos + this.oParent.Var_6ed6 - 7),
						this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_db3e_MouseYPos + this.oParent.Var_70ea - 14, 0, 49));
				}
				else if (this.oParent.Var_db3e_MouseYPos < 72)
				{
					// Instruction address 0x1403:0x0796, size: 5
					this.oParent.Segment_11a8.F0_11a8_0268();

					this.oParent.Palace.F17_0000_07ec(0);

					this.oParent.Var_aa_Rectangle.ScreenID = 0;

					// Instruction address 0x1403:0x07af, size: 5
					this.oParent.Segment_2dc4.F0_2dc4_065f();

					// Instruction address 0x1403:0x07cc, size: 5
					this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

					// Instruction address 0x1403:0x07d8, size: 5
					this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x1e79, 1);

					// Instruction address 0x1403:0x0800, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

					// Instruction address 0x1403:0x0808, size: 5
					this.oParent.Segment_11a8.F0_11a8_0250();

					// Instruction address 0x1403:0x080d, size: 5
					this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

					// Instruction address 0x1403:0x0826, size: 5
					this.oParent.Segment_1238.F0_1238_1b44();

					// Instruction address 0x1403:0x082b, size: 5
					this.oParent.Segment_2dc4.F0_2dc4_0626();
				}
				else if (unitID >= 128)
				{
					goto Label755;
				}

				this.oParent.Var_db3a_MouseButton = 0;
			}

			if (this.oParent.Var_db3a_MouseButton == 2)
			{
				if (unitID < 128)
				{
					while (true)
					{
						// Instruction address 0x1403:0x085a, size: 5
						this.oParent.Segment_11a8.F0_11a8_0223_UpdateMouse();

						if (this.oParent.Var_db3a_MouseButton == 0)
						{
							// Instruction address 0x1403:0x0882, size: 5
							local_1c = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition((this.oParent.Var_db3c_MouseXPos - 80) / 16 + this.oParent.Var_d4cc_MapViewX);
							local_26 = ((this.oParent.Var_db3e_MouseYPos - 8) / 16) + this.oParent.Var_d75e_MapViewY;

							// Instruction address 0x1403:0x08d0, size: 5
							local_18 = this.oParent.Segment_2dc4.F0_2dc4_0208_GetShortestDistance(
								local_1c - this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
								local_26 - this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);

							if (Math.Abs(local_1c - this.oParent.GameData.Players[playerID].Units[unitID].Position.X) == 79)
							{
								if (Math.Abs(local_26 - this.oParent.GameData.Players[playerID].Units[unitID].Position.Y) <= 1)
								{
									local_18 = 1;
								}
							}

							if (local_18 == 1)
							{
								this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = local_1c;
								this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.Y = local_26;
								this.oParent.GameData.Players[playerID].Units[unitID].GoToNextDirection = -1;
								this.oParent.Var_db3a_MouseButton = 0x0;
								flag3 = false;

								// Instruction address 0x1403:0x095b, size: 5
								this.oParent.CommonTools.F0_1000_1697(0, 0, this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xd4dc));
							}
							else
							{
								this.oParent.Var_db3a_MouseButton = 0x2;
							}
							break;
						}
					}
				}
			}

			if (this.oParent.Var_db3a_MouseButton == 2)
			{
				if ((this.oParent.GameData.MapVisibility[local_1c, local_26] & (0x1 << this.oParent.GameData.HumanPlayerID)) != 0 ||
					this.oParent.Var_d806_DebugFlag)
				{
					// Instruction address 0x1403:0x09a5, size: 5
					this.oParent.Segment_11a8.F0_11a8_0268();

					// Instruction address 0x1403:0x09b4, size: 5
					this.oParent.Civilopedia.F8_0000_062a((int)this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(local_1c, local_26), 3);

					// Instruction address 0x1403:0x09c5, size: 5
					this.oParent.Segment_1238.F0_1238_1b44();

					// Instruction address 0x1403:0x09ca, size: 5
					this.oParent.Segment_11a8.F0_11a8_0250();
				}
			}

		Label114:
			if (this.oParent.Var_db3a_MouseButton == 1)
			{
				if (flag3 && unitID < 128)
				{
					local_3e = (int)this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(local_1c, local_26);

					// local_36 == 2 || will never happen, because local_36 has only two values 0 and 1
					if ((this.oParent.GameData.MapVisibility[local_1c, local_26] & (0x1 << this.oParent.GameData.HumanPlayerID)) != 0 &&
						((this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Air && local_3e == 10) ||
						(this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Land && local_3e != 10) ||
						(this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_1c, local_26).HasFlag(TerrainImprovementFlagsEnum.City) ||
							this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Water)))
					{
						this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = local_1c;
						this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.Y = local_26;
						this.oParent.GameData.Players[playerID].Units[unitID].GoToNextDirection = -1;
					}

					flag3 = false;

					this.oParent.CommonTools.F0_1000_1697(0, 0, this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xd4dc));

					if (flag1)
					{
						flag1 = false;

						if ((this.oParent.GameData.MapVisibility[local_e, local_12] & (0x1 << playerID)) != 0)
						{
							this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(local_e, local_12);
						}

						local_e = -1;
					}
				}
				else
				{
					if (this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_1c, local_26).HasFlag(TerrainImprovementFlagsEnum.City) &&
						(this.oParent.MapManagement.F0_2aea_1369_GetCityOwner(local_1c, local_26) == this.oParent.GameData.HumanPlayerID ||
							this.oParent.Var_d806_DebugFlag))
					{
						int cityID = this.oParent.Segment_2dc4.F0_2dc4_00ba_GetCityID(local_1c, local_26);

						// Instruction address 0x1403:0x0b9a, size: 5
						this.oParent.Segment_1ade.F0_1ade_03ea(cityID);
						// Instruction address 0x1403:0x0ba2, size: 5
						this.oParent.Segment_1238.F0_1238_107e();

						flag2 = false;

						if (flag1)
						{
							flag1 = false;

							if ((this.oParent.GameData.MapVisibility[local_e, local_12] & (0x1 << playerID)) != 0)
							{
								this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(local_e, local_12);
							}

							local_e = -1;
						}
					}
					else
					{
						command = this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(local_1c, local_26);

						if (this.oParent.Var_d806_DebugFlag && command != -1)
						{
							this.oParent.Overlay_10.F10_0000_0477(this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0xd7f0), command);
						}

						if (command != -1 && playerID == this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0xd7f0))
						{
							local_3a = (short)this.oParent.Segment_1866.F0_1866_1f69(this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0xd7f0), command);

							if ((this.oParent.GameData.Players[playerID].Units[local_3a].Status & 0x9) == 0)
							{
								unitID = local_3a;
								maxUnitID = local_3a;
								if (maxUnitID < 0)
									maxUnitID = 127;

								flag4 = false;
								flag2 = false;

								if (flag1)
								{
									flag1 = false;

									if ((this.oParent.GameData.MapVisibility[local_e, local_12] & (0x1 << playerID)) != 0)
									{
										// Instruction address 0x1403:0x0cb9, size: 5
										this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(local_e, local_12);
									}

									local_e = -1;
								}
								goto Label722;
							}
						}
						else
						{
							// Instruction address 0x1403:0x0cdd, size: 5
							this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(playerID, local_1c - 7, local_26 - 6);
						}
					}
				}
			}

			command = -1;

			// Instruction address 0x1403:0x0cfb, size: 5
			F0_1403_4545();

		Label151:
			if (unitID < 128) goto Label152;
			goto Label286;

		Label152:
			if (this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X != -1)
			{
				command = this.oParent.UnitGoTo.F0_2e31_000e_GetNextMove(playerID, unitID);
			}
			else
			{
				this.oParent.GameData.Players[playerID].Units[unitID].GoToNextDirection = -1;
			}

			if (unitID < 128)
			{
				local_2c = this.oParent.GameData.Players[playerID].Units[unitID].Position.X;
				local_30 = this.oParent.GameData.Players[playerID].Units[unitID].Position.Y;
			}
			else
			{
				local_2c = 0;
				local_30 = 0;
			}

			switch ((char)command)
			{
				case ' ':
					this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;
					break;

				case 'D':
					this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;

					// Instruction address 0x1403:0x0d90, size: 5
					this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, unitID);
					break;

				case 'P':
					if (!this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_2c, local_30).HasFlag(TerrainImprovementFlagsEnum.City) &&
						this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 14)
					{
						// Instruction address 0x1403:0x0df1, size: 5
						int cityID = this.oParent.Segment_2dc4.F0_2dc4_0102(local_2c, local_30);

						if (this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves != 0)
						{
							if ((short)this.oParent.Segment_29f3.F0_29f3_0c9e(this.oParent.GameData.Cities[cityID].PlayerID) != -1)
							{
								local_3a = (int)this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_2c, local_30);

								if ((local_3a & 0x6) != 0)
								{
									this.oParent.MapManagement.F0_2aea_16ee(6, local_2c, local_30);
								}
								else if ((local_3a & 0x10) != 0)
								{
									this.oParent.MapManagement.F0_2aea_16ee(16, local_2c, local_30);
								}
								else
								{
									this.oParent.MapManagement.F0_2aea_16ee(8, local_2c, local_30);
								}

								if (this.oParent.GameData.Cities[cityID].PlayerID == this.oParent.GameData.HumanPlayerID)
								{
									this.oParent.MapManagement.F0_2aea_1601_UpdateVisbleCellStatus(local_2c, local_30);
								}

								F0_1403_3ed7(local_2c, local_30);
								this.oParent.Segment_2517.F0_2517_0aa1_ClearDiplomacyFlags(this.oParent.GameData.HumanPlayerID,
									this.oParent.GameData.Cities[cityID].PlayerID, 2);

								int local_54 = this.oParent.GameData.Cities[cityID].PlayerID;

								if (playerID != local_54)
								{
									this.oParent.Segment_25fb.F0_25fb_304d(local_54, local_2c, local_30, 1, 4);
								}

								this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;
							}
						}
					}
					else
					{
						// Instruction address 0x1403:0x0ddd, size: 5
						F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1e83);
					}
					break;

				case 'b':
					if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 0)
					{
						// Instruction address 0x1403:0x19dd, size: 5
						F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1ecc);
					}
					else if (this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(local_2c, local_30) != TerrainTypeEnum.Water && local_30 >= 2 && local_30 < 48)
					{
						if (this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_2c, local_30).HasFlag(TerrainImprovementFlagsEnum.City))
						{
							int cityID = this.oParent.MapManagement.F0_2aea_175a(local_2c, local_30);

							if (this.oParent.GameData.Cities[cityID].ActualSize < 10)
							{
								this.oParent.GameData.Cities[cityID].ActualSize++;
								this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;

								// Instruction address 0x1403:0x1a6a, size: 5
								this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, unitID);

								// Instruction address 0x1403:0x1a78, size: 5
								F0_1403_3f13(playerID, unitID);
							}
							else
							{
								// Instruction address 0x1403:0x1a87, size: 5
								F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1ed6);
							}
						}
						else
						{
							this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;

							local_3a = this.oParent.Overlay_20.F20_0000_0000(playerID, local_2c, local_30, 1);

							if (local_3a != -1)
							{
								// Instruction address 0x1403:0x1ad1, size: 5
								this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, unitID);

								// Instruction address 0x1403:0x1adf, size: 5
								F0_1403_3f13(playerID, unitID);
							}
						}
					}
					break;

				case 'f':
					if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Land)
					{
						if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 0)
						{
							this.oParent.GameData.Players[playerID].Units[unitID].Status |= 0x4;
							this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;

							// Instruction address 0x1403:0x12bf, size: 5
							F0_1403_3f13(playerID, unitID);

							if (playerID != this.oParent.GameData.HumanPlayerID &&
								this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_2c, local_30).HasFlag(TerrainImprovementFlagsEnum.City))
							{
								this.oParent.GameData.Players[playerID].Units[unitID].HomeCityID = (short)this.oParent.Segment_2dc4.F0_2dc4_00ba_GetCityID(local_2c, local_30);
							}
						}
						else
						{
							if (this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_2c, local_30).HasFlag(TerrainImprovementFlagsEnum.City) ||
								this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_2c, local_30).HasFlag(TerrainImprovementFlagsEnum.Fortress) ||
								!this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, TechnologyEnum.Construction))
							{
								this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0x3f;
								this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves = 0;

								this.oParent.Segment_1866.F0_1866_16a9(playerID, local_2c, local_30);
							}
							else
							{
								this.oParent.GameData.Players[playerID].Units[unitID].Status |= 0xc0;
								this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;

								// Instruction address 0x1403:0x1388, size: 5
								F0_1403_3f13(playerID, unitID);

								this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves++;

								if ((this.oParent.GameData.Terrains[local_3e].MovementCost + 4) <= this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves)
								{
									// Instruction address 0x1403:0x13bf, size: 5
									this.oParent.MapManagement.F0_2aea_1653_SetTerrainImprovements(TerrainImprovementFlagsEnum.Fortress, local_2c, local_30);

									// Instruction address 0x1403:0x13db, size: 5
									this.oParent.Segment_1866.F0_1866_01dc(local_2c, local_30, playerID, unitID, true);

									this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0x3f;
									this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves = 0;
								}
							}
						}
					}
					break;

				case 'g':
					if (this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x1a3c) == 0)
					{
						if (!flag3)
						{
							if (!flag1)
							{
								flag1 = true;
								local_e = this.oParent.GameData.Players[playerID].Units[unitID].Position.X;
								local_12 = this.oParent.GameData.Players[playerID].Units[unitID].Position.Y;
							}
						}
						else if (flag1)
						{
							flag1 = false;

							if ((this.oParent.GameData.MapVisibility[local_e, local_12] & (0x1 << playerID)) != 0)
							{
								// Instruction address 0x1403:0x107b, size: 5
								this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(local_e, local_12);
							}

							local_e = -1;
						}
					}
					else
					{
						ushort local_56 = 0;

						if (flag3)
						{
							local_56 = 7;
						}
						else
						{
							local_56 = 2;
						}
						
						this.oParent.CommonTools.F0_1000_1697(0, 0, this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xd4ce + (local_56 * 2))));
					}

					flag3 ^= true;
					break;

				case 'h':
					if (this.oParent.Var_6c9a == 0)
					{
						this.oParent.GameData.Players[playerID].Units[unitID].HomeCityID = (short)this.oParent.Segment_2dc4.F0_2dc4_0102(local_2c, local_30);
					}
					else
					{
						if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Water)
						{
							// Instruction address 0x1403:0x1118, size: 5
							local_24 = (short)this.oParent.Segment_1866.F0_1866_226d(playerID, unitID);

							if (local_24 != 0)
							{
								this.oParent.GameData.Players[playerID].Units[unitID].Status |= 2;
								goto Label300;
							}
							else
							{
								if (playerID == this.oParent.GameData.HumanPlayerID)
								{
									this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0xfd;
								}
								else
								{
									this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;

									// Instruction address 0x1403:0x1175, size: 5
									this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, unitID);
								}
							}
						}
					}
					break;

				case 'i':
					if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 0 ||
						(this.oParent.GameData.DebugFlags & 0x2) == 0 ||
						this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_2c, local_30).HasFlag(TerrainImprovementFlagsEnum.Irrigation))
					{
						// Instruction address 0x1403:0x15ce, size: 5
						this.oParent.Segment_1866.F0_1866_16a9(playerID, local_2c, local_30);

						if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 0)
						{
							F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1ea0);
						}
						else
						{
							this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves = 0;
						}

						this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0xbf;
					}
					else
					{
						local_3e = (int)this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(local_2c, local_30);
						local_3a = this.oParent.GameData.TerrainModifications[local_3e].IrrigationEffect;

						if (local_3a == -1)
						{
							// Instruction address 0x1403:0x165e, size: 5
							this.oParent.Segment_1866.F0_1866_16a9(playerID, local_2c, local_30);
							F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1eaa);

							this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0xbf;
						}
						else
						{
							if (local_3a != -2 || F0_1403_3fd0_CanIrrigateCell(local_2c, local_30))
							{
								this.oParent.GameData.Players[playerID].Units[unitID].Status |= 0x40;

								// Instruction address 0x1403:0x16f9, size: 5
								F0_1403_3f13(playerID, unitID);

								this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;
								this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;
								this.oParent.GameData.Players[playerID].Units[unitID].GoToNextDirection = -1;
								this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves++;

								if (this.oParent.GameData.TerrainModifications[local_3e].IrrigationCost <= this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves)
								{
									if (local_3a >= 0)
									{
										// Instruction address 0x1403:0x1743, size: 5
										this.oParent.CommonTools.F0_1000_104f_SetPixel(2, local_2c, local_30, (ushort)local_3a);

										this.oParent.GameData.MapVisibility[local_2c, local_30] |= 1;

										// Instruction address 0x1403:0x176a, size: 5
										this.oParent.MapManagement.F0_2aea_16ee(6, local_2c, local_30);
									}
									else
									{
										// Instruction address 0x1403:0x177f, size: 5
										this.oParent.MapManagement.F0_2aea_16ee(4, local_2c, local_30);
										// Instruction address 0x1403:0x1791, size: 5
										this.oParent.MapManagement.F0_2aea_1653_SetTerrainImprovements(TerrainImprovementFlagsEnum.Irrigation, local_2c, local_30);
									}

									// Instruction address 0x1403:0x179f, size: 5
									F0_1403_3f13(playerID, unitID);

									this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0xbf;
									this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves = 0;
								}
							}
							else
							{
								// Instruction address 0x1403:0x16b2, size: 5
								this.oParent.Segment_1866.F0_1866_16a9(playerID, local_2c, local_30);
								// Instruction address 0x1403:0x16be, size: 5
								F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1eb1);

								this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0xbf;
							}
						}
					}
					break;

				case 'm':
					if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 0 ||
						this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_2c, local_30).HasFlag(TerrainImprovementFlagsEnum.Mines))
					{
						// Instruction address 0x1403:0x17fc, size: 5
						this.oParent.Segment_1866.F0_1866_16a9(playerID, local_2c, local_30);

						if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 0)
						{
							// Instruction address 0x1403:0x1822, size: 5
							F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1eba);
						}
						else
						{
							this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves = 0;
						}

						this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0x7f;
					}
					else
					{
						local_3e = (int)this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(local_2c, local_30);
						local_3a = this.oParent.GameData.TerrainModifications[local_3e].MiningEffect;

						if (local_3a == -1)
						{
							// Instruction address 0x1403:0x188c, size: 5
							this.oParent.Segment_1866.F0_1866_16a9(playerID, local_2c, local_30);
							// Instruction address 0x1403:0x1898, size: 5
							F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1ec4);

							this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0x7f;
						}
						else
						{
							this.oParent.GameData.Players[playerID].Units[unitID].Status |= 0x80;

							// Instruction address 0x1403:0x18d3, size: 5
							F0_1403_3f13(playerID, unitID);

							this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;
							this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;
							this.oParent.GameData.Players[playerID].Units[unitID].GoToNextDirection = -1;
							this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves++;

							if (this.oParent.GameData.TerrainModifications[local_3e].MiningCost <= this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves)
							{
								if (local_3a >= 0)
								{
									this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves++;

									if (this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves > 5)
									{
										// Instruction address 0x1403:0x193e, size: 5
										this.oParent.CommonTools.F0_1000_104f_SetPixel(2, local_2c, local_30, (ushort)local_3a);

										this.oParent.GameData.MapVisibility[local_2c, local_30] |= 1;

										// Instruction address 0x1403:0x1965, size: 5
										this.oParent.MapManagement.F0_2aea_16ee(6, local_2c, local_30);
										// Instruction address 0x1403:0x199a, size: 5
										F0_1403_3f13(playerID, unitID);

										this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0x7f;
										this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves = 0;
									}
								}
								else
								{
									// Instruction address 0x1403:0x197a, size: 5
									this.oParent.MapManagement.F0_2aea_16ee(2, local_2c, local_30);
									// Instruction address 0x1403:0x198c, size: 5
									this.oParent.MapManagement.F0_2aea_1653_SetTerrainImprovements(TerrainImprovementFlagsEnum.Mines, local_2c, local_30);
									// Instruction address 0x1403:0x199a, size: 5
									F0_1403_3f13(playerID, unitID);

									this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0x7f;
									this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves = 0;
								}
							}
						}
					}
					break;

				case 'p':
					if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 0)
					{
						// Instruction address 0x1403:0x119e, size: 5
						F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1e8c);
					}
					else
					{
						local_40 = (int)this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_2c, local_30);

						if ((local_40 & 0x40) == 0)
						{
							this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0x7d;
							this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves = 0;

							// Instruction address 0x1403:0x11e6, size: 5
							this.oParent.Segment_1866.F0_1866_16a9(playerID, local_2c, local_30);
						}
						else
						{
							this.oParent.GameData.Players[playerID].Units[unitID].Status |= 0x82;

							// Instruction address 0x1403:0x120c, size: 5
							F0_1403_3f13(playerID, unitID);

							this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;
							this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;
							this.oParent.GameData.Players[playerID].Units[unitID].GoToNextDirection = -1;
							this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves++;

							if (this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves >= 4)
							{
								// Instruction address 0x1403:0x123e, size: 5
								this.oParent.MapManagement.F0_2aea_16ee(0x40, local_2c, local_30);
								// Instruction address 0x1403:0x124c, size: 5
								this.oParent.MapManagement.F0_2aea_1601_UpdateVisbleCellStatus(local_2c, local_30);

								this.oParent.GameData.PollutedSquareCount--;

								// Instruction address 0x1403:0x125e, size: 5
								F0_1403_3f13(playerID, unitID);

								this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0x7d;
								this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves = 0;
							}
						}
					}
					break;

				case 'r':
					if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 0)
					{
						// Instruction address 0x1403:0x141e, size: 5
						F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1e96);
					}
					else
					{
						local_40 = (int)this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_2c, local_30);

						if (((local_40 & 0x8) != 0 &&
							(!this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, TechnologyEnum.Railroad) || (local_40 & 0x1) != 0)) || (local_40 & 0x10) != 0)
						{
							this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0xfd;
							this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves = 0;

							// Instruction address 0x1403:0x148f, size: 5
							this.oParent.Segment_1866.F0_1866_16a9(playerID, local_2c, local_30);
						}
						else
						{
							local_3e = (int)this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(local_2c, local_30);

							if (local_3e != 11 || this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, TechnologyEnum.BridgeBuilding))
							{
								this.oParent.GameData.Players[playerID].Units[unitID].Status |= 2;
								this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;

								// Instruction address 0x1403:0x14ee, size: 5
								F0_1403_3f13(playerID, unitID);

								int local_58 = this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves;

								this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves++;

								if (((((local_40 & 0x8) != 0) ? 4 : 2) * this.oParent.GameData.Terrains[local_3e].MovementCost) <= local_58)
								{
									// Instruction address 0x1403:0x154b, size: 5
									this.oParent.MapManagement.F0_2aea_1653_SetTerrainImprovements(
										(((local_40 & 0x8) != 0) ? TerrainImprovementFlagsEnum.RailRoad : TerrainImprovementFlagsEnum.Road), local_2c, local_30);
									// Instruction address 0x1403:0x1567, size: 5
									this.oParent.Segment_1866.F0_1866_01dc(local_2c, local_30, playerID, unitID, true);

									this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0xfd;
									this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves = 0;
								}
							}
						}
					}
					break;

				case 's':
					this.oParent.GameData.Players[playerID].Units[unitID].Status |= 1;
					this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;

					// Instruction address 0x1403:0x0f64, size: 5
					F0_1403_3f13(playerID, unitID);

					break;

				case 'u':
					if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].TransportCapacity != 0 ||
						this.oParent.GameData.Players[playerID].Units[unitID].TypeID == 23)
					{
						if (this.oParent.GameData.Players[playerID].Units[unitID].NextUnitID != -1)
						{
							// Instruction address 0x1403:0x0fc8, size: 5
							this.oParent.Segment_1866.F0_1866_144b(playerID, unitID, 0x14f6);

							flag2 = false;
							flag7 = true;
							unitID = F0_1403_4562(playerID, unitID) - 1;
							maxUnitID = unitID;
							if (maxUnitID < 0)
								maxUnitID = 127;

							flag4 = false;
						}
					}
					break;

				case 'w':
					flag7 = true;
					flag4 = true;

					break;
			}

		Label286:
			if (unitID < 128 || flag1)
			{
				switch ((char)command)
				{
					case '\0':
						break;

					case 'c':
						if (flag1)
						{
							this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(playerID, local_e - 7, local_12 - 6);
						}
						else
						{
							this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(playerID, local_2c - 7, local_30 - 6);
						}
						break;

					case '\x001':
					case '\x4800':
						local_24 = 1;
						goto Label300;

					case '\x002':
					case '\x4900':
						local_24 = 2;
						goto Label300;

					case '\x003':
					case '\x4d00':
						local_24 = 3;
						goto Label300;

					case '\x004':
					case '\x5100':
						local_24 = 4;
						goto Label300;

					case '\x005':
					case '\x5000':
						local_24 = 5;
						goto Label300;

					case '\x006':
					case '\x4f00':
						local_24 = 6;
						goto Label300;

					case '\x007':
					case '\x4b00':
						local_24 = 7;
						goto Label300;

					case '\x008':
					case '\x4700':
						local_24 = 8;
						goto Label300;
				}
			}

			goto Label674;

		Label300:
			#region Move Unit
			if (flag1)
			{
				if ((this.oParent.GameData.MapVisibility[local_e, local_12] & (0x1 << playerID)) != 0)
				{
					// Instruction address 0x1403:0x1c43, size: 5
					this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(local_e, local_12);
				}

				local_e = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(this.oParent.MoveOffsets[local_24].X + local_e);
				local_12 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.MoveOffsets[local_24].Y + local_12, 0, 49);

				if (!F0_1403_4508(local_e, local_12))
				{
					// Instruction address 0x1403:0x1ca5, size: 5
					this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(playerID, local_e - 8, local_12 - 7);
				}
				goto Label674;
			}

			if (playerID == 0 && this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 26)
			{
				local_40 = (int)this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_2c, local_30);

				if ((local_40 & 0x1) == 0 && (local_40 & 0x6) != 0 &&
					this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 3 &&
					this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 7 &&
					this.oParent.GameData.Cities[this.oParent.Segment_2dc4.F0_2dc4_0102(local_2c, local_30)].PlayerID == this.oParent.GameData.HumanPlayerID)
				{
					// Instruction address 0x1403:0x1d35, size: 5
					this.oParent.MapManagement.F0_2aea_16ee(6, local_2c, local_30);

					if ((this.oParent.GameData.MapVisibility[local_2c, local_30] & (0x1 << this.oParent.GameData.HumanPlayerID)) != 0)
					{
						// Instruction address 0x1403:0x1d68, size: 5
						this.oParent.MapManagement.F0_2aea_1601_UpdateVisbleCellStatus(local_2c, local_30);
						// Instruction address 0x1403:0x1d76, size: 5
						this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(local_2c, local_30);
					}

					this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;
					goto Label674;
				}
			}

			local_1c = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(this.oParent.MoveOffsets[local_24].X + local_2c);
			local_26 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.MoveOffsets[local_24].Y + local_30, 0, 49);
			TerrainTypeEnum terrainType = this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(local_2c, local_30);
			local_3e = (int)this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(local_1c, local_26);
			local_40 = (int)this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_1c, local_26);
			local_18 = this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(local_1c, local_26);

			if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != -1 &&
				this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Land)
			{
				if (local_18 == -1 && this.oParent.Segment_1866.F0_1866_1725(playerID, local_2c, local_30) != 0 &&
					this.oParent.Segment_1866.F0_1866_1725(playerID, local_1c, local_26) != 0 &&
					this.oParent.GameData.Players[playerID].Units[unitID].TypeID < 26 && terrainType != TerrainTypeEnum.Water)
				{
					if (playerID == this.oParent.GameData.HumanPlayerID)
					{
						// Instruction address 0x1403:0x1e9c, size: 5
						this.oParent.CommonTools.F0_1000_0a32_PlayTune(37, 0);
					}

					if (this.oParent.GameData.GameSettingFlags.InstantAdvice)
					{
						// Instruction address 0x1403:0x1eb2, size: 5
						F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1edf);
					}

					this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;

					goto Label674;
				}

				if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID >= 26)
				{
					int cityID = this.oParent.Segment_2dc4.F0_2dc4_00ba_GetCityID(local_1c, local_26);

					if (cityID != -1)
					{
						if (this.oParent.GameData.Cities[cityID].PlayerID != playerID && terrainType == TerrainTypeEnum.Water) goto Label674;

						if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID == 26 &&
							playerID != this.oParent.GameData.Cities[cityID].PlayerID)
						{
							if (this.oParent.GameData.HumanPlayerID == this.oParent.GameData.Cities[cityID].PlayerID)
							{
								this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer |=
									(ushort)(1 << this.oParent.GameData.HumanPlayerID);

								// Instruction address 0x1403:0x1f7f, size: 5
								this.oParent.Segment_1866.F0_1866_16a9(this.oParent.GameData.HumanPlayerID,
									this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
									this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);
								// Instruction address 0x1403:0x1f8b, size: 5
								this.oParent.CommonTools.F0_1182_0134_WaitTimer(30);
								// Instruction address 0x1403:0x1f9c, size: 5
								this.oParent.Segment_1866.F0_1866_1d55(playerID, unitID, local_24);
							}

							this.oParent.Overlay_22.F22_0000_0000(cityID, playerID, unitID);

							goto Label674;
						}

						if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID == 27)
						{
							local_3a = this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(local_1c,
								this.oParent.GameData.Cities[this.oParent.GameData.Players[playerID].Units[unitID].HomeCityID].Position.X,
								local_26,
								this.oParent.GameData.Cities[this.oParent.GameData.Players[playerID].Units[unitID].HomeCityID].Position.Y);

							if (this.oParent.GameData.Cities[cityID].PlayerID != playerID ||
								this.oParent.GameData.Cities[cityID].CurrentProductionID < -24 || local_3a >= 10 ||
								this.oParent.MapManagement.F0_2aea_1942_GetCellGroupID(local_1c, local_26) != this.oParent.MapManagement.F0_2aea_1942_GetCellGroupID(
									this.oParent.GameData.Cities[this.oParent.GameData.Players[playerID].Units[unitID].HomeCityID].Position.X,
									this.oParent.GameData.Cities[this.oParent.GameData.Players[playerID].Units[unitID].HomeCityID].Position.Y))
							{
								// Instruction address 0x1403:0x206e, size: 5
								this.oParent.CAPI.strcpy(0xba06, "Will you?\n Keep moving\n Establish trade route\n");

								if (this.oParent.GameData.Cities[cityID].PlayerID == playerID)
								{
									if (this.oParent.GameData.Cities[cityID].CurrentProductionID < -24)
									{
										// Instruction address 0x1403:0x209d, size: 5
										this.oParent.CAPI.strcat(0xba06, " Help build WONDER.\n");

										if (local_3a < 10)
										{
											this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0xb276, 2);
										}
									}
								}

								if (this.oParent.GameData.Cities[cityID].PlayerID != playerID)
								{
									local_3a = 1;
								}
								else
								{
									local_3a = this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
								}

								if (local_3a == 1)
								{
									if (this.oParent.Segment_2459.F0_2459_0948(playerID, unitID, cityID) != 0) goto Label674;
								}

								if (local_3a == 2)
								{
									this.oParent.GameData.Cities[cityID].ShieldsCount +=
										(short)(10 * this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].Cost);

									// Instruction address 0x1403:0x2149, size: 5
									this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, unitID);

									goto Label674;
								}
							}
						}
					}
					else
					{
						if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID == 26 &&
							local_18 != -1 && playerID != this.oParent.Var_d20a)
						{
							this.oParent.Overlay_22.F22_0000_0639(this.oParent.Var_d20a, local_18, playerID);

							this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;
						}
					}
				}
			}

			if (local_3e == 10 && this.oParent.GameData.Players[playerID].Units[unitID].TypeID != -1 &&
				this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Land)
			{
				if (playerID != this.oParent.Var_d20a || local_18 == -1 || this.oParent.Segment_1866.F0_1866_13d5(playerID, local_18) <= 0) goto Label674;

				this.oParent.GameData.Players[playerID].Units[unitID].Status |= 1;
				this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0xf3;
				this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 3;
			}
			else if (local_18 != -1 && playerID != this.oParent.Var_d20a)
			{
				if (terrainType == TerrainTypeEnum.Water &&
					this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Land)
				{
					// Instruction address 0x1403:0x224c, size: 5
					F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1f28);

					this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;

					goto Label674;
				}

				if (local_3e != 10 && this.oParent.GameData.Players[playerID].Units[unitID].TypeID == 22) goto Label674;

				if (playerID != this.oParent.GameData.HumanPlayerID &&
					this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].AttackStrength == 0) goto Label674;

				if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID == 26) goto Label674;

				if (this.oParent.GameData.Units[this.oParent.GameData.Players[this.oParent.Var_d20a].Units[local_18].TypeID].MovementType == UnitMovementTypeEnum.Water)
				{
					if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 14)
					{
						if ((local_40 & 0x1) == 0)
						{
							// Instruction address 0x1403:0x2319, size: 5
							F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1f30);

							this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;

							goto Label674;
						}
					}
				}

				if (this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves < 3)
				{
					if (playerID == this.oParent.GameData.HumanPlayerID)
					{
						// Instruction address 0x1403:0x2356, size: 5
						this.oParent.CAPI.strcpy(0xba06, "Attack at\n");
						// Instruction address 0x1403:0x2379, size: 5
						this.oParent.CAPI.strcat(0xba06, this.oParent.CAPI.itoa(this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves, 10));
						// Instruction address 0x1403:0x2389, size: 5
						this.oParent.CAPI.strcat(0xba06, "/3 strength?\n Cancel\n Attack\n");

						if (this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 16) != 1)
						{
							this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;

							goto Label674;
						}
					}
					else
					{
						if (this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves < 2) goto Label674;
					}
				}

				if (this.oParent.Var_d20a == this.oParent.GameData.HumanPlayerID)
				{
					// Instruction address 0x1403:0x23eb, size: 5
					this.oParent.Segment_1866.F0_1866_16a9(this.oParent.GameData.HumanPlayerID, local_1c, local_26);
				}

				local_18 = this.oParent.Segment_1866.F0_1866_1122(this.oParent.Var_d20a, local_18);

				if (playerID == this.oParent.GameData.HumanPlayerID ||
					this.oParent.Var_d20a == this.oParent.GameData.HumanPlayerID)
				{
					this.oCPU.WriteInt16(this.oCPU.DS.UInt16, 0x70d8, 1);
				}

				local_3a = this.oParent.Segment_29f3.F0_29f3_000e(playerID, unitID, this.oParent.Var_d20a, local_18, true);
				this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;
				this.oCPU.WriteInt16(this.oCPU.DS.UInt16, 0x70d8, 0);

				if (local_3a == -1) goto Label674;

				if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID == -1)
				{
					this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;
					goto Label722;
				}

				this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves -= 3;

				if (this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves < 0 || this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves == 15)
				{
					this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;
				}

				if ((local_40 & 0x1) == 0) goto Label674;

				int cityID = this.oParent.Segment_2dc4.F0_2dc4_00ba_GetCityID(local_1c, local_26);

				if (this.oParent.GameData.Cities[cityID].PlayerID != this.oParent.GameData.HumanPlayerID)
				{
					this.oParent.GameData.Cities[cityID].StatusFlag |= 0x10;
				}

				if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != -1)
				{
					if ((this.oParent.GameData.Cities[cityID].ImprovementFlags0 & 0x80) == 0)
					{
						if (terrainType != TerrainTypeEnum.Water)
						{
							if (this.oParent.GameData.DifficultyLevel != 0 ||
								this.oParent.Var_d20a != this.oParent.GameData.HumanPlayerID)
							{
								this.oParent.GameData.Cities[cityID].ActualSize--;
							}
						}
					}
				}

				if (this.oParent.GameData.Cities[cityID].ActualSize == 0)
				{
					// Instruction address 0x1403:0x2576, size: 5
					this.oParent.Segment_1ade.F0_1ade_018e(cityID, local_1c, local_26);
					this.oParent.StartGameMenu.F5_0000_0e6c(this.oParent.Var_d20a, playerID);

					if (playerID == this.oParent.GameData.HumanPlayerID)
					{
						local_18 = this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(local_1c, local_26);

						if (local_18 != -1)
						{
							this.oParent.GameData.Players[this.oParent.Var_d20a].Units[local_18].VisibleByPlayer |=
								(ushort)(1 << this.oParent.GameData.HumanPlayerID);
						}
					}
				}

				if (playerID == this.oParent.GameData.HumanPlayerID ||
					this.oParent.Var_d20a == this.oParent.GameData.HumanPlayerID ||
					this.oParent.Var_d806_DebugFlag)
				{
					this.oParent.GameData.Cities[cityID].VisibleSize = this.oParent.GameData.Cities[cityID].ActualSize;

					// Instruction address 0x1403:0x2606, size: 5
					this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(local_1c, local_26);
				}

				if (this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(local_1c, local_26) == -1)
				{
					if (this.oParent.Var_d20a != this.oParent.GameData.HumanPlayerID)
					{
						// Instruction address 0x1403:0x2641, size: 5
						this.oParent.Segment_25fb.F0_25fb_3459(this.oParent.Var_d20a, this.oParent.MapManagement.F0_2aea_1942_GetCellGroupID(local_1c, local_26));
					}
				}
				goto Label674;
			}

			if (local_3e != 10 && (local_40 & 0x1) == 0 &&
				this.oParent.GameData.Players[playerID].Units[unitID].TypeID != -1 &&
				this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Air)
			{
				this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;
				goto Label674;
			}

			if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != -1 &&
				this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Land &&
				(local_40 & 0x1) != 0 && this.oParent.MapManagement.F0_2aea_1369_GetCityOwner(local_1c, local_26) != playerID)
			{
				if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 25)
				{
					// Instruction address 0x1403:0x2706, size: 5
					F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1f62);

					this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;
				}
				else
				{
					// Instruction address 0x1403:0x271f, size: 5
					this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, unitID);
					// Instruction address 0x1403:0x2730, size: 5
					this.oParent.Segment_29f3.F0_29f3_0d4d(playerID, local_1c, local_26);
				}
				goto Label674;
			}

			if (this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves == 0)
			{
				goto Label674;
			}

			if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Land)
			{
				if ((((int)this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_2c, local_30) & local_40) & 0x8) != 0 &&
					this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves != 0)
				{
					if (!this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_2c, local_30).HasFlag(TerrainImprovementFlagsEnum.RailRoad) ||
						playerID != this.oParent.GameData.HumanPlayerID ||
						this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X != -1)
					{
						this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves -= 1;
					}
				}
				else
				{
					if (this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves != 3 &&
						this.oParent.CAPI.RNG.Next(this.oParent.GameData.Terrains[local_3e].MovementCost * 3) > this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves)
					{
						this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;
						goto Label674;
					}

					this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves -= (short)(this.oParent.GameData.Terrains[local_3e].MovementCost * 3);
				}
			}
			else
			{
				this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves -= 3;
			}

			if (this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves < 0)
			{
				this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;
			}

			if (playerID != this.oParent.GameData.HumanPlayerID)
			{
				if (this.oParent.GameData.Players[playerID].Units[unitID].GoToNextDirection != -1)
				{
					if ((this.oParent.GameData.Players[playerID].Units[unitID].GoToNextDirection ^ 0x4) == local_24)
					{
						if (this.oParent.Segment_1866.F0_1866_1251(playerID, unitID, 2) <= 2)
						{
							this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;
							this.oParent.GameData.Players[playerID].Units[unitID].GoToNextDirection = -1;
							this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;

							goto Label674;
						}
					}
				}
				this.oParent.GameData.Players[playerID].Units[unitID].GoToNextDirection = (short)local_24;
			}

			if (local_18 != -1 &&
				playerID == this.oParent.Var_d20a && playerID != this.oParent.GameData.HumanPlayerID && (local_40 & 0x1) == 0)
			{
				if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Land ||
					(this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Water &&
						this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves != 0))
				{
					local_3a = this.oParent.Segment_1866.F0_1866_1251(playerID, local_18, 2);

					if (((this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves != 0) ? 4 : 2) <= local_3a) goto Label674;
				}
			}

			// Get playerID that owns this land
			int ownerPlayerID = this.oParent.Graphics.F0_VGA_038c_GetPixel(2, local_1c + 80, local_26);

			if (ownerPlayerID != 0)
			{
				if (ownerPlayerID < 8)
				{
					if (local_3e != 10 && terrainType != TerrainTypeEnum.Water &&
						this.oParent.GameData.Players[playerID].Units[unitID].TypeID < 26 &&
						(local_40 & 0xf) != 0 && ownerPlayerID != playerID)
					{
						if ((playerID == this.oParent.GameData.HumanPlayerID || ownerPlayerID == this.oParent.GameData.HumanPlayerID) &&
							this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Land &&
							this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(local_1c, local_26) != playerID)
						{
							if (playerID == this.oParent.GameData.HumanPlayerID)
							{
								this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;

								if ((short)this.oParent.Segment_29f3.F0_29f3_0c9e(ownerPlayerID) != -1)
								{
									// Instruction address 0x1403:0x2a87, size: 5
									this.oParent.Segment_2517.F0_2517_0aa1_ClearDiplomacyFlags(playerID, ownerPlayerID, 2);
								}
								else
								{
									goto Label674;
								}
							}
							else if (ownerPlayerID == this.oParent.GameData.HumanPlayerID &&
								(this.oParent.GameData.Players[ownerPlayerID].Diplomacy[playerID] & 0x2) != 0)
							{
								this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;

								goto Label674;
							}
						}
					}

					if (playerID != ownerPlayerID)
					{
						if (((int)this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_1c, local_26) & 0xe) != 0)
						{
							this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer |= (ushort)(1 << ownerPlayerID);
						}
					}
				}
			}

			int cityPlayerID1 = this.oParent.MapManagement.F0_2aea_1369_GetCityOwner(local_1c, local_26);

			if (playerID == 0 && local_3e != 10 &&
				(this.oParent.GameData.MapVisibility[local_2c, local_30] & (0x1 << this.oParent.GameData.HumanPlayerID)) != 0 &&
				(this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer & (0x1 << this.oParent.GameData.HumanPlayerID)) == 0 &&
				this.oParent.GameData.Cities[this.oParent.Segment_2dc4.F0_2dc4_0102(local_2c, local_30)].PlayerID == this.oParent.GameData.HumanPlayerID)
			{
				this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer |= this.oParent.GameData.MapVisibility[local_2c, local_30];
			}

			if ((local_40 & 0x1) != 0 && cityPlayerID1 != playerID &&
				(this.oParent.GameData.MapVisibility[local_1c, local_26] & (0x1 << this.oParent.GameData.HumanPlayerID)) != 0 &&
				((this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Diplomacy[playerID] & 0x40) != 0 ||
					(this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Diplomacy[cityPlayerID1] & 0x40) != 0))
			{
				this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer |= (ushort)(1 << this.oParent.GameData.HumanPlayerID);
			}

			if (local_3e == 10)
			{
				if (((int)this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(local_1c, local_26) & 0x2) != 0)
				{
					this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer |= (ushort)(1 << cityPlayerID1);
				}
			}

			if ((this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer & (0x1 << this.oParent.GameData.HumanPlayerID)) != 0 ||
				playerID == this.oParent.GameData.HumanPlayerID || (this.oParent.Var_d806_DebugFlag && playerID != 0))
			{
				if (!this.oParent.GameData.GameSettingFlags.EnemyMoves && playerID != this.oParent.GameData.HumanPlayerID)
				{
					// Instruction address 0x1403:0x2cd5, size: 5
					this.oParent.MapManagement.F0_2aea_03ba_DrawCell(local_2c, local_30);
				}
				else
				{
					// Instruction address 0x1403:0x2cb3, size: 5
					this.oParent.Segment_1866.F0_1866_16a9(this.oParent.GameData.HumanPlayerID, local_1c, local_26);
					// Instruction address 0x1403:0x2cc4, size: 5
					this.oParent.Segment_1866.F0_1866_1d55(playerID, unitID, local_24);
				}
			}

			// Instruction address 0x1403:0x2d01, size: 5
			this.oParent.MapManagement.F0_2aea_1412_SetCellActivePlayerID(playerID, unitID, local_2c, local_30);

			// Instruction address 0x1403:0x2d21, size: 5
			this.oParent.MapManagement.F0_2aea_13cb(playerID, unitID, local_1c, local_26);

			this.oParent.GameData.Players[playerID].Units[unitID].Position.X = local_1c;
			this.oParent.GameData.Players[playerID].Units[unitID].Position.Y = local_26;
			this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer = 0;

			if (playerID != this.oParent.GameData.HumanPlayerID &&
				this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Water)
			{
				this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0x30;
			}

			if (ownerPlayerID != 0 && ownerPlayerID < 8 && ownerPlayerID != playerID)
			{
				// Instruction address 0x1403:0x2d9d, size: 5
				this.oParent.CommonTools.F0_1000_104f_SetPixel(2, local_1c + 80, local_26, 0);
			}

			if (this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X == local_1c &&
				this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.Y == local_26)
			{
				this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;
				this.oParent.GameData.Players[playerID].Units[unitID].GoToNextDirection = -1;

				if (playerID != this.oParent.GameData.HumanPlayerID)
				{
					this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;
				}
			}

			if (terrainType == TerrainTypeEnum.Water && local_3e != 10 &&
				this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Water)
			{
				this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;
			}

			int nextUnitID = this.oParent.GameData.Players[playerID].Units[unitID].NextUnitID;

			if (nextUnitID != -1 && this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].TransportCapacity == 0 && 
				this.oParent.GameData.Players[playerID].Units[unitID].TypeID == 23)
			{
				int neededCapacity = 0;

				for (int i = 0; i < 20; i++)
				{
					int nextUnitID1 = this.oParent.GameData.Players[playerID].Units[nextUnitID].NextUnitID;

					if (((this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].TransportCapacity < 1) ? UnitMovementTypeEnum.Water : UnitMovementTypeEnum.Land) == this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[nextUnitID].TypeID].MovementType)
					{
						if (((this.oParent.GameData.Players[playerID].Units[nextUnitID].Status & 0x1) == 0 && terrainType == TerrainTypeEnum.Water) ||
							(playerID != this.oParent.GameData.HumanPlayerID &&
							(this.oParent.GameData.Players[playerID].Units[nextUnitID].Status & 0xc) == 0 &&
							this.oParent.GameData.Players[playerID].Units[nextUnitID].NextUnitID != -1))
						{
							// Instruction address 0x1403:0x2efb, size: 5
							this.oParent.MapManagement.F0_2aea_1412_SetCellActivePlayerID(playerID, nextUnitID, local_2c, local_30);
							// Instruction address 0x1403:0x2f0f, size: 5
							this.oParent.MapManagement.F0_2aea_13cb(playerID, nextUnitID, local_1c, local_26);

							this.oParent.GameData.Players[playerID].Units[nextUnitID].Position.X = local_1c;
							this.oParent.GameData.Players[playerID].Units[nextUnitID].Position.Y = local_26;
							this.oParent.GameData.Players[playerID].Units[nextUnitID].VisibleByPlayer = 0;
							this.oParent.GameData.Players[playerID].Units[nextUnitID].GoToNextDirection = -1;

							if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].TransportCapacity != 0)
							{
								this.oParent.GameData.Players[playerID].Units[nextUnitID].Status |= 0x1;
							}

							if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[nextUnitID].TypeID].TurnsOutside != 0)
							{
								this.oParent.GameData.Players[playerID].Units[nextUnitID].SpecialMoves =
									(short)(this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[nextUnitID].TypeID].TurnsOutside - 1);
							}

							neededCapacity++;
						}
					}

					nextUnitID = nextUnitID1;

					if (nextUnitID == -1 ||
						(this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].TransportCapacity <= neededCapacity && 
						this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 23 && playerID != 0))
						break;
				}
			}

			if ((local_40 & 0x1) != 0 && cityPlayerID1 != playerID)
			{
				this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer |= (ushort)(1 << cityPlayerID1);

				// Instruction address 0x1403:0x303e, size: 5
				this.oParent.Segment_2459.F0_2459_0000(playerID, this.oParent.Segment_2dc4.F0_2dc4_00ba_GetCityID(local_1c, local_26), 0);
				// Instruction address 0x1403:0x304c, size: 5
				this.oParent.MapManagement.F0_2aea_1511_ActiveUnitSetFlag8(local_1c, local_26);
			}

			// Instruction address 0x1403:0x305d, size: 5
			this.oParent.MapManagement.F0_2aea_138c_SetCityOwner(playerID, local_1c, local_26);
			// Instruction address 0x1403:0x3079, size: 5
			this.oParent.Segment_1866.F0_1866_01dc(local_1c, local_26, playerID, unitID, true);

			if (this.oParent.MapManagement.F0_2aea_1894_CellHasMinorTribeHut((TerrainTypeEnum)local_3e, local_1c, local_26))
			{
				// Instruction address 0x1403:0x30a0, size: 5
				this.oParent.Segment_1866.F0_1866_1931(playerID, unitID);

				this.oParent.GameData.MapVisibility[local_1c, local_26] |= 1;
			}

			if (local_3e == 10 &&
				this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Air)
			{
				// Instruction address 0x1403:0x30f6, size: 5
				this.oParent.Segment_1866.F0_1866_144b(playerID, unitID, 0x1560);
			}

			if (playerID == 0 && local_3e != 10)
			{
				if ((this.oParent.GameData.MapVisibility[local_1c, local_26] & (0x1 << this.oParent.GameData.HumanPlayerID)) != 0 &&
					(this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer & (0x1 << this.oParent.GameData.HumanPlayerID)) == 0 &&
					this.oParent.GameData.Cities[this.oParent.Segment_2dc4.F0_2dc4_0102(local_1c, local_26)].PlayerID == this.oParent.GameData.HumanPlayerID)
				{
					this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer |= this.oParent.GameData.MapVisibility[local_1c, local_26];
				}
			}

			if ((this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer & (0x1 << this.oParent.GameData.HumanPlayerID)) != 0 ||
				playerID == this.oParent.GameData.HumanPlayerID || this.oParent.Var_d806_DebugFlag && playerID != 0)
			{
				if (playerID == this.oParent.GameData.HumanPlayerID ||
					this.oParent.GameData.GameSettingFlags.EnemyMoves)
				{
					// Instruction address 0x1403:0x31e6, size: 5
					this.oParent.Segment_1866.F0_1866_16a9(this.oParent.GameData.HumanPlayerID, local_1c, local_26);
					// Instruction address 0x1403:0x31f4, size: 5
					this.oParent.MapManagement.F0_2aea_0e29_DrawUnit(playerID, unitID);

					if (playerID != this.oParent.GameData.HumanPlayerID)
					{
						// Instruction address 0x1403:0x3215, size: 5
						this.oParent.CommonTools.F0_1182_0134_WaitTimer(30);
					}
				}
				else
				{
					if (this.oParent.MapManagement.F0_2aea_0e29_DrawUnit(playerID, unitID))
					{
						// Instruction address 0x1403:0x323a, size: 5
						this.oParent.CommonTools.F0_1182_0134_WaitTimer(10);
					}
				}
			}

			local_a = 0;

			if ((local_40 & 0x1) != 0 &&
				this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].TurnsOutside != 0)
			{
				this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0xfd;
				this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;
				this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;
			}

			if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].TurnsOutside != 0)
			{
				if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Water)
				{
					if (this.oParent.Segment_1866.F0_1866_1331(playerID, unitID, 23) != 0)
					{
						this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0xfd;
						this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;
						this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves =
							this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].TurnsOutside;
					}
				}
			}
			goto Label674;
		#endregion

		Label674:
			switch (command)
			{
				case -2:
					this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0);

					// Instruction address 0x1403:0x354b, size: 5
					this.oParent.LanguageTools.F0_2f4d_044f(0x1f6a);

					if (this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 64, 80) == 1)
					{
						this.oParent.GameData.Players[playerID].GovernmentType = 0;

						// Instruction address 0x1403:0x3585, size: 5
						this.oParent.CAPI.strcpy(0xba06, "The ");
						// Instruction address 0x1403:0x3595, size: 5
						this.oParent.CAPI.strcat(0xba06, this.oParent.GameData.Players[playerID].Nation);
						// Instruction address 0x1403:0x35a5, size: 5
						this.oParent.CAPI.strcat(0xba06, " are\nrevolting! Citizens\ndemand new govt.\n");
						this.oParent.Overlay_21.F21_0000_0000(-1);
						this.oParent.StartGameMenu.F5_0000_1af6();
						// Instruction address 0x1403:0x35be, size: 5
						this.oParent.Segment_1238.F0_1238_1b44();
					}
					break;

				// Tab
				case 0x9:
					if (this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x1a3c) == 0)
					{
						if (flag1)
						{
							if ((this.oParent.GameData.MapVisibility[local_e, local_12] & (0x1 << playerID)) != 0)
							{
								// Instruction address 0x1403:0x3992, size: 5
								this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(local_e, local_12);
							}
							local_e = -1;
							flag1 ^= true;
							goto Label722;
						}
						else
						{
							if (unitID < 128 &&
								F0_1403_4508(this.oParent.GameData.Players[playerID].Units[unitID].Position.X, this.oParent.GameData.Players[playerID].Units[unitID].Position.Y))
							{
								local_e = this.oParent.GameData.Players[playerID].Units[unitID].Position.X;
								local_12 = this.oParent.GameData.Players[playerID].Units[unitID].Position.Y;
							}
							else
							{
								local_e = this.oParent.Var_d4cc_MapViewX + 7;
								local_12 = this.oParent.Var_d75e_MapViewY + 6;
							}

							if ((this.oParent.GameData.MapVisibility[local_e, local_12] & (0x1 << playerID)) != 0)
							{
								// Instruction address 0x1403:0x3a2b, size: 5
								this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(local_e, local_12);
							}

							flag1 ^= true;
						}
					}
					break;

				// Enter
				case 0xd:
				case ' ':
					if (unitID >= 128) goto Label755;
					break;

				// ESC
				case 0x1b:
					if (this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x1a3c) == 0)
					{
						if (flag1)
						{
							flag1 = false;

							if ((this.oParent.GameData.MapVisibility[local_e, local_12] & (0x1 << playerID)) != 0)
							{
								// Instruction address 0x1403:0x3945, size: 5
								this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(local_e, local_12);
							}

							local_e = -1;
						}
					}
					break;

				case '+':
				case '=':
					// Instruction address 0x1403:0x35d6, size: 5
					this.oParent.CAPI.strcpy(0xba06, "Select new Tax rate:\n ");

					for (local_3a = 0; this.oParent.GameData.Players[playerID].TaxRate + this.oParent.GameData.Players[playerID].ScienceTaxRate >= local_3a; local_3a++)
					{
						// Instruction address 0x1403:0x361a, size: 5
						this.oParent.CAPI.strcat(0xba06, this.oParent.CAPI.itoa(local_3a * 10, 0xd80a, 10));
						// Instruction address 0x1403:0x362a, size: 5
						this.oParent.CAPI.strcat(0xba06, "% Tax, (");
						this.oParent.CAPI.strcat(0xba06,
							this.oParent.CAPI.itoa((this.oParent.GameData.Players[playerID].TaxRate + this.oParent.GameData.Players[playerID].ScienceTaxRate - local_3a) * 10, 0xd80a, 10));
						// Instruction address 0x1403:0x3668, size: 5
						this.oParent.CAPI.strcat(0xba06, "% Science)\n ");
					}

					this.oCPU.WriteInt16(this.oCPU.DS.UInt16, 0x2f9a, this.oParent.GameData.Players[playerID].TaxRate);

					// Instruction address 0x1403:0x368b, size: 5
					local_3a = this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

					if (local_3a != -1)
					{
						this.oParent.GameData.Players[playerID].ScienceTaxRate += (short)(this.oParent.GameData.Players[playerID].TaxRate - local_3a);
						this.oParent.GameData.Players[playerID].TaxRate = (short)local_3a;

						// Instruction address 0x1403:0x36b1, size: 5
						this.oParent.Segment_1238.F0_1238_107e();
					}
					break;

				case '-':
				case '_':
					// Instruction address 0x1403:0x36c1, size: 5
					this.oParent.CAPI.strcpy(0xba06, "Select new Luxuries rate:\n ");

					for (local_3a = 0; 10 - this.oParent.GameData.Players[playerID].TaxRate >= local_3a; local_3a++)
					{
						this.oParent.CAPI.strcat(0xba06, this.oParent.CAPI.itoa(local_3a * 10, 0xd80a, 10));
						// Instruction address 0x1403:0x3716, size: 5
						this.oParent.CAPI.strcat(0xba06, "% Luxuries, (");
						this.oParent.CAPI.strcat(0xba06,
							this.oParent.CAPI.itoa((local_3a + this.oParent.GameData.Players[playerID].TaxRate - 10) * -10, 0xd80a, 10));
						// Instruction address 0x1403:0x3753, size: 5
						this.oParent.CAPI.strcat(0xba06, "% Science)\n ");
					}

					this.oCPU.WriteInt16(this.oCPU.DS.UInt16, 0x2f9a,
						(short)(-((this.oParent.GameData.Players[playerID].TaxRate + this.oParent.GameData.Players[playerID].ScienceTaxRate) - 10)));

					local_3a = this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

					if (local_3a != -1)
					{
						this.oParent.GameData.Players[playerID].ScienceTaxRate = (short)(-(this.oParent.GameData.Players[playerID].TaxRate + local_3a - 10));
						// Instruction address 0x1403:0x37a3, size: 5
						this.oParent.Segment_1238.F0_1238_107e();
					}
					break;

				case '/':
				case '?':
					this.oParent.Overlay_23.F23_0000_025b_FindCityDialog();
					break;

				case 'S':
					if (this.oParent.GameData.TurnCount != 0)
					{
						this.oParent.GameLoadAndSave.F11_0000_036a(0xffff);
					}
					break;

				case 't':
					this.oParent.Var_dcfc = 1;

					// Instruction address 0x1403:0x37bc, size: 5
					this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(playerID, this.oParent.Var_d4cc_MapViewX, this.oParent.Var_d75e_MapViewY);
					// Instruction address 0x1403:0x37c4, size: 5
					this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

					this.oParent.Var_dcfc = 0;

					// Instruction address 0x1403:0x37da, size: 5
					this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(playerID, this.oParent.Var_d4cc_MapViewX, this.oParent.Var_d75e_MapViewY);
					break;

				// Alt + Q
				case 0x1000:
					// Instruction address 0x1403:0x38be, size: 5
					this.oParent.CAPI.strcpy(0xba06, "Are you sure you\nwant to Quit?\n Keep Playing\n Yes, Quit\n");

					if (this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80) != 1)
					{
						this.oParent.Var_dc48_GameEndType = 0;
					}
					else
					{
						if (this.oParent.Var_dc48_GameEndType == 0)
						{
							this.oParent.Var_dc48_GameEndType = 1;
						}
						unitID = 128;
					}
					break;

				// Alt + W
				case 0x1100:
					// Instruction address 0x1403:0x3a84, size: 5
					this.oParent.Segment_2c84.F0_2c84_0000_ShowTopMenu(playerID, unitID, 3);

					if (this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0xd4ca) != -1)
					{
						command = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xd4ca);
						goto Label152;
					}
					break;

				// Alt + R
				case 0x1300:
					for (local_3a = 0; local_3a < 16; local_3a++)
					{
						// Instruction address 0x1403:0x3805, size: 5
						this.oParent.GameData.Nations[local_3a].Mood = (short)(this.oParent.CAPI.RNG.Next(3) - 1); // -1 = Friendly, 0 = Neutral, 1 = Aggressive

						// Instruction address 0x1403:0x3816, size: 5
						this.oParent.GameData.Nations[local_3a].Policy = (short)(this.oParent.CAPI.RNG.Next(3) - 1); // -1 = Perfectionist, 0 = Neutral, 1 = Expansionistic

						// Instruction address 0x1403:0x3827, size: 5
						this.oParent.GameData.Nations[local_3a].Ideology = (short)(this.oParent.CAPI.RNG.Next(3) - 1); // -1 = Militaristic, 0 = Neutral, 1 = Civilized
					}

					// Instruction address 0x1403:0x3843, size: 5
					this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0x2003, 100, 80);
					break;

				// Alt + O
				case 0x1800:
					// Instruction address 0x1403:0x3a5a, size: 5
					this.oParent.Segment_2c84.F0_2c84_0000_ShowTopMenu(playerID, unitID, 1);

					if (this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0xd4ca) != -1)
					{
						command = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xd4ca);
						goto Label152;
					}
					break;

				// Alt + A
				case 0x1e00:
					// Instruction address 0x1403:0x3a6f, size: 5
					this.oParent.Segment_2c84.F0_2c84_0000_ShowTopMenu(playerID, unitID, 2);

					if (this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0xd4ca) != -1)
					{
						command = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xd4ca);
						goto Label152;
					}
					break;

				// Alt + D
				case 0x2000:
					this.oParent.Var_d806_DebugFlag = !this.oParent.Var_d806_DebugFlag;

					// Instruction address 0x1403:0x3506, size: 5
					this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(this.oParent.GameData.HumanPlayerID, this.oParent.Var_d4cc_MapViewX, this.oParent.Var_d75e_MapViewY);
					break;

				// Alt + G
				case 0x2200:
					// Instruction address 0x1403:0x3a45, size: 5
					this.oParent.Segment_2c84.F0_2c84_0000_ShowTopMenu(playerID, unitID, 0);

					if (this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0xd4ca) != -1)
					{
						command = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xd4ca);
						goto Label152;
					}
					break;

				// Alt + H
				case 0x2300:
					this.oParent.Help.F4_0000_02d3_ShowInstantAdvicePopup(0x2029);
					this.oParent.Help.F4_0000_02d3_ShowInstantAdvicePopup(0x2030);
					break;

				// Alt + C
				case 0x2e00:
					// Instruction address 0x1403:0x3a99, size: 5
					this.oParent.Segment_2c84.F0_2c84_0000_ShowTopMenu(playerID, unitID, 4);

					if (this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0xd4ca) != -1)
					{
						command = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xd4ca);
						goto Label152;
					}
					break;

				// Alt + V
				case 0x2f00:
					this.oParent.GameData.GameSettingFlags.Sound ^= true;

					// Instruction address 0x1403:0x385c, size: 5
					this.oParent.CAPI.strcpy(0xba06, "Sounds ");

					if (this.oParent.GameData.GameSettingFlags.Sound)
					{
						// Instruction address 0x1403:0x387c, size: 5
						this.oParent.CAPI.strcat(0xba06, "ON\n");
					}
					else
					{
						// Instruction address 0x1403:0x387c, size: 5
						this.oParent.CAPI.strcat(0xba06, "OFF\n");
					}

					// Instruction address 0x1403:0x3890, size: 5
					this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
					break;

				// Alt + M
				case 0x3200:
					// Instruction address 0x1403:0x35c6, size: 5
					this.oParent.CommonTools.F0_1000_163e_InitMouse();
					break;

				// F1
				case 0x3b00:
					if (this.oParent.Var_d806_DebugFlag)
					{
						this.oParent.Overlay_10.F10_0000_0000();
					}
					else
					{
						this.oParent.Overlay_14.F14_0000_186f_CityStatus(this.oParent.GameData.HumanPlayerID);
					}
					break;

				// F2
				case 0x3c00:
					this.oParent.Overlay_14.F14_0000_03ad_MilitaryStatus(this.oParent.GameData.HumanPlayerID);
					break;

				// F3
				case 0x3d00:
					if (this.oParent.Var_d806_DebugFlag)
					{
						// Instruction address 0x1403:0x33a5, size: 5
						this.oParent.Segment_11a8.F0_11a8_0268();

						// Instruction address 0x1403:0x33ae, size: 5
						this.oParent.CommonTools.F0_1000_0846(2);

						// Instruction address 0x1403:0x33b6, size: 5
						this.oParent.CAPI.getch();

						// Instruction address 0x1403:0x33bf, size: 5
						this.oParent.CommonTools.F0_1000_0846(0);

						// Instruction address 0x1403:0x33c7, size: 5
						this.oParent.Segment_11a8.F0_11a8_0250();
					}
					else
					{
						this.oParent.Overlay_14.F14_0000_0d43_IntelligenceReport();
					}
					break;

				// F4
				case 0x3e00:
					this.oParent.Overlay_14.F14_0000_15f4_AttitudeSurvey(this.oParent.GameData.HumanPlayerID);
					break;

				// F5
				case 0x3f00:
					this.oParent.Overlay_14.F14_0000_07f1_TradeReport(this.oParent.GameData.HumanPlayerID);
					break;

				// F6
				case 0x4000:
					this.oParent.Overlay_14.F14_0000_014b_ScienceReport(this.oParent.GameData.HumanPlayerID);
					break;

				// F7
				case 0x4100:
					if (this.oParent.Var_d806_DebugFlag)
					{
						for (int i = 1; i < 8; i++)
						{
							this.oParent.Overlay_13.F13_0000_0000(i);
						}
					}
					else
					{
						this.oParent.WorldMap.F12_0000_080d_ShowWondersOfTheWorldPopup();
					}
					break;

				// F8
				case 0x4200:
					if (this.oParent.Var_d806_DebugFlag)
					{
						this.oParent.WorldMap.F12_0000_0573();
						this.oParent.GameReplay.F9_0000_0000();
					}
					else
					{
						this.oParent.HallOfFame.F3_0000_09ac_ShowTopFiveCitiesPopup();
					}
					break;

				// F9
				case 0x4300:
					if (this.oParent.Var_d806_DebugFlag)
					{
						this.oParent.WorldMap.F12_0000_03ac();
					}
					else
					{
						this.oParent.Overlay_20.F20_0000_0ca9_ShowCivilizationScorePopup(this.oParent.GameData.HumanPlayerID, true);
					}
					break;

				// F10
				case 0x4400:
					this.oParent.WorldMap.F12_0000_0000_ShowWorldMapPopup(1);
					break;

				// Shift + Home
				case 0x4737:
					local_24 = 8;

					direction = this.oParent.MoveOffsets[local_24];
					this.oParent.Var_d4cc_MapViewX += direction.X * 4;
					this.oParent.Var_d75e_MapViewY += direction.Y * 4;

					// Instruction address 0x1403:0x3506, size: 5
					this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(this.oParent.GameData.HumanPlayerID, this.oParent.Var_d4cc_MapViewX, this.oParent.Var_d75e_MapViewY);
					break;

				// Shift + Up
				case 0x4838:
					local_24 = 1;

					direction = this.oParent.MoveOffsets[local_24];
					this.oParent.Var_d4cc_MapViewX += direction.X * 4;
					this.oParent.Var_d75e_MapViewY += direction.Y * 4;

					// Instruction address 0x1403:0x3506, size: 5
					this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(this.oParent.GameData.HumanPlayerID, this.oParent.Var_d4cc_MapViewX, this.oParent.Var_d75e_MapViewY);
					break;

				// Shift + PageUp
				case 0x4939:
					local_24 = 2;

					direction = this.oParent.MoveOffsets[local_24];
					this.oParent.Var_d4cc_MapViewX += direction.X * 4;
					this.oParent.Var_d75e_MapViewY += direction.Y * 4;

					// Instruction address 0x1403:0x3506, size: 5
					this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(this.oParent.GameData.HumanPlayerID, this.oParent.Var_d4cc_MapViewX, this.oParent.Var_d75e_MapViewY);
					break;

				// Shift + Left
				case 0x4b34:
					local_24 = 7;

					direction = this.oParent.MoveOffsets[local_24];
					this.oParent.Var_d4cc_MapViewX += direction.X * 4;
					this.oParent.Var_d75e_MapViewY += direction.Y * 4;

					// Instruction address 0x1403:0x3506, size: 5
					this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(this.oParent.GameData.HumanPlayerID, this.oParent.Var_d4cc_MapViewX, this.oParent.Var_d75e_MapViewY);
					break;

				// Shift + Right
				case 0x4d36:
					local_24 = 3;

					direction = this.oParent.MoveOffsets[local_24];
					this.oParent.Var_d4cc_MapViewX += direction.X * 4;
					this.oParent.Var_d75e_MapViewY += direction.Y * 4;

					// Instruction address 0x1403:0x3506, size: 5
					this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(this.oParent.GameData.HumanPlayerID, this.oParent.Var_d4cc_MapViewX, this.oParent.Var_d75e_MapViewY);
					break;

				// Shift + End
				case 0x4f31:
					local_24 = 6;

					direction = this.oParent.MoveOffsets[local_24];
					this.oParent.Var_d4cc_MapViewX += direction.X * 4;
					this.oParent.Var_d75e_MapViewY += direction.Y * 4;

					// Instruction address 0x1403:0x3506, size: 5
					this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(this.oParent.GameData.HumanPlayerID, this.oParent.Var_d4cc_MapViewX, this.oParent.Var_d75e_MapViewY);
					break;

				// Shift + Down
				case 0x5032:
					local_24 = 5;

					direction = this.oParent.MoveOffsets[local_24];
					this.oParent.Var_d4cc_MapViewX += direction.X * 4;
					this.oParent.Var_d75e_MapViewY += direction.Y * 4;

					// Instruction address 0x1403:0x3506, size: 5
					this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(this.oParent.GameData.HumanPlayerID, this.oParent.Var_d4cc_MapViewX, this.oParent.Var_d75e_MapViewY);
					break;

				// Shift + PageDown
				case 0x5133:
					local_24 = 4;

					direction = this.oParent.MoveOffsets[local_24];
					this.oParent.Var_d4cc_MapViewX += direction.X * 4;
					this.oParent.Var_d75e_MapViewY += direction.Y * 4;

					// Instruction address 0x1403:0x3506, size: 5
					this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(this.oParent.GameData.HumanPlayerID, this.oParent.Var_d4cc_MapViewX, this.oParent.Var_d75e_MapViewY);
					break;
			}

		Label722:
			if (unitID < 128 && (unitID == -1 || this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves > 0) &&
				!flag7 && this.oParent.Var_dc48_GameEndType == 0) goto Label59;

			if (unitID < 128)
			{
				if (unitID != -1 && this.oParent.GameData.Players[playerID].Units[unitID].TypeID != -1)
				{
					if (this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves > 0)
					{
						flag2 = false;
					}
					else
					{
						if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].TurnsOutside != 0)
						{
							if (((int)this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(
								this.oParent.GameData.Players[playerID].Units[unitID].Position.X, this.oParent.GameData.Players[playerID].Units[unitID].Position.Y) & 0x1) != 0 ||
								this.oParent.Segment_1866.F0_1866_1331(playerID, unitID, 23) != 0)
							{
								this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves =
									this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].TurnsOutside;
							}

							this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves--;

							if (this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves < 0)
							{
								// Instruction address 0x1403:0x3d5d, size: 5
								this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, unitID);

								// Instruction address 0x1403:0x3d69, size: 5
								F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x2070);
							}
						}

						if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID == 16 &&
							playerID == this.oParent.GameData.HumanPlayerID && this.oParent.CAPI.RNG.Next(2) != 0)
						{
							bool flag8 = false;

							for (int i = 1; i < 9; i++)
							{
								direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c))];

								if (this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
									this.oParent.GameData.Players[playerID].Units[unitID].Position.X + direction.X,
									this.oParent.GameData.Players[playerID].Units[unitID].Position.Y + direction.Y) != TerrainTypeEnum.Water)
								{
									flag8 = true;
									break;
								}
							}

							if (!flag8)
							{
								// Instruction address 0x1403:0x3e18, size: 5
								this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, unitID);
								// Instruction address 0x1403:0x3e24, size: 5
								F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x2076);
							}
						}
					}
				}
			}
			else if ((this.oParent.GameData.PlayerFlags & (0x1 << playerID)) != 0)
			{
				// Instruction address 0x1403:0x3e43, size: 5
				F0_1403_4060(playerID, unitID);
			}

			goto Label18;

		Label748:
			if (!flag2 && this.oParent.Var_dc48_GameEndType == 0) goto Label17;

			if (this.oParent.Var_dc48_GameEndType == 0 &&
				(this.oParent.GameData.PlayerFlags & (0x1 << playerID)) != 0 &&
				(!flag5 || this.oParent.GameData.GameSettingFlags.EndOfTurn))
			{
				unitID = 128;
				flag2 = false;
				flag6 = true;
				goto Label54;
			}

		Label755:
			if (playerID == this.oParent.GameData.HumanPlayerID)
			{
				// Instruction address 0x1403:0x3eac, size: 5
				this.oParent.Segment_11a8.F0_11a8_0268();
				// Instruction address 0x1403:0x3ec1, size: 5
				this.oParent.Segment_1238.F0_1238_1bb2_FillRectangleWithShadow(0, 97, 80, 103);
				// Instruction address 0x1403:0x3ec9, size: 5
				this.oParent.Segment_11a8.F0_11a8_0250();
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void F0_1403_3ed7(int x, int y)
		{
			// This function is referenced 7 time(s)
			// Standard C frame
			//this.oCPU.Log.EnterBlock("'Fn2'(Cdecl, Far, Return) at 0x3ed7");

			// function body
			if ((this.oParent.GameData.MapVisibility[x, y] & (1 << this.oParent.GameData.HumanPlayerID)) != 0 || this.oParent.Var_d806_DebugFlag)
			{
				// Instruction address 0x1403:0x3f09, size: 5
				this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(x, y);
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_1403_3f13(int playerID, int unitID)
		{
			// This function is referenced 13 time(s)
			// Standard C frame
			//this.oCPU.Log.EnterBlock("'Fn3'(Cdecl, Far, Return) at 0x3f13");

			// function body
			if (playerID == this.oParent.GameData.HumanPlayerID ||
				(this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer & (0x1 << this.oParent.GameData.HumanPlayerID)) != 0)
			{
				// Instruction address 0x1403:0x3f5d, size: 5
				this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(
					this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
					this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int F0_1403_3f68(int x, int y)
		{
			// This function is referenced 2 time(s)
			// Standard C frame
			//this.oCPU.Log.EnterBlock("'Fn4'(Cdecl, Far, Return) at 0x3f68");
			// function body
			if (((int)this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(x, y) & 0x7) == 0)
			{
				// Instruction address 0x1403:0x3f8a, size: 5
				TerrainTypeEnum terrainType = this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(x, y);

				if (this.oParent.GameData.TerrainModifications[(int)terrainType].MiningEffect > -3)
				{
					if (this.oParent.GameData.TerrainModifications[(int)terrainType].IrrigationEffect == -2 && F0_1403_3fd0_CanIrrigateCell(x, y))
					{
						return 1;
					}
				}
				else
				{
					return 2;
				}
			}

			return 0;
		}

		/// <summary>
		/// Checks whether map cell can be irrigated
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public bool F0_1403_3fd0_CanIrrigateCell(int x, int y)
		{
			// This function is referenced 4 time(s)
			// Standard C frame
			//this.oCPU.Log.EnterBlock("'Fn5'(Cdecl, Far, Return) at 0x3fd0");
			// function body
			if (this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(x, y) != TerrainTypeEnum.River)
			{
				for (int Local_8 = 1; Local_8 < 9; Local_8 += 2)
				{
					GPoint direction = this.oParent.MoveOffsets[Local_8];
					int newX = x + direction.X;
					int newY = y + direction.Y;

					TerrainTypeEnum terrainType = this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(newX, newY);
					TerrainImprovementFlagsEnum terrainImprovements = this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(newX, newY);

					if (((int)terrainImprovements & 0x1) == 0)
					{
						if (terrainType == TerrainTypeEnum.Water || terrainType == TerrainTypeEnum.River || ((int)terrainImprovements & 0x2) != 0)
						{
							return true;
						}
					}
				}

				return false;
			}

			return true;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1403_4060(int playerID, int unitID)
		{
			// This function is referenced 4 time(s)
			// Standard C frame
			//this.oCPU.Log.EnterBlock("'Fn6'(Cdecl, Far, Return) at 0x4060");

			// Local variables
			int Local_2;
			int Local_4;
			int Local_6;
			int Local_8;
			int Local_a;
			int Local_c;
			int Local_e;
			int Local_10;
			int Local_12;

			// function body
			// Instruction address 0x1403:0x4068, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			// Instruction address 0x1403:0x407c, size: 5
			this.oParent.Segment_1238.F0_1238_1bb2_FillRectangleWithShadow(0, 97, 80, 103);

			if (unitID == 128)
			{
				// Instruction address 0x1403:0x409a, size: 5
				this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("End of Turn", 4, 124, 0);
				// Instruction address 0x1403:0x40b1, size: 5
				this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("Press Enter", 4, 136, 0);
				// Instruction address 0x1403:0x44f5, size: 5
				this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("to continue", 4, 144, 0);
			}
			else
			{
				if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != -1)
				{
					Local_a = 99;

					// Instruction address 0x1403:0x40dc, size: 5
					this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.Players[playerID].Nationality);
					// Instruction address 0x1403:0x40f3, size: 5
					this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0(0xba06, 4, 99, 0);

					Local_a += 8;

					// Instruction address 0x1403:0x411d, size: 5
					this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].Name);
					// Instruction address 0x1403:0x4133, size: 5
					this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0(0xba06, 4, Local_a, 0);

					Local_a += 8;

					if ((this.oParent.GameData.Players[playerID].Units[unitID].Status & 0x20) != 0)
					{
						// Instruction address 0x1403:0x4154, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("Veteran", 8, Local_a, 0);

						Local_a += 8;
					}

					Local_e = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves / 3, 0, 99);

					// Instruction address 0x1403:0x4197, size: 5
					this.oParent.CAPI.strcpy(0xba06, "Moves: ");
					// Instruction address 0x1403:0x41b7, size: 5
					this.oParent.CAPI.strcat(0xba06, this.oParent.CAPI.itoa(Local_e, 0xd80a, 10));

					Local_c = this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves % 3;

					if (Local_c != 0)
					{
						// Instruction address 0x1403:0x41d8, size: 5
						this.oParent.CAPI.strcat(0xba06, ".");
						// Instruction address 0x1403:0x41f8, size: 5
						this.oParent.CAPI.strcat(0xba06, this.oParent.CAPI.itoa(Local_c, 0xd80a, 10));
					}

					if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].TurnsOutside != 0)
					{
						// Instruction address 0x1403:0x4227, size: 5
						this.oParent.CAPI.strcat(0xba06, "(");

						Local_e += (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MoveCount *
							this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves);

						// Instruction address 0x1403:0x425f, size: 5
						this.oParent.CAPI.strcat(0xba06, this.oParent.CAPI.itoa(Local_e, 10));
						// Instruction address 0x1403:0x426f, size: 5
						this.oParent.CAPI.strcat(0xba06, ")");
					}

					// Instruction address 0x1403:0x4285, size: 5
					this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0(0xba06, 4, Local_a, 0);

					Local_a += 8;

					this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

					// Instruction address 0x1403:0x42ac, size: 5
					this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oParent.GameData.Players[playerID].Units[unitID].HomeCityID);
					// Instruction address 0x1403:0x42c2, size: 5
					this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0(0xba06, 4, Local_a, 0);

					Local_a += 8;

					// Instruction address 0x1403:0x42d6, size: 5
					this.oParent.CAPI.strcpy(0xba06, "(");
					// Instruction address 0x1403:0x42ff, size: 5
					this.oParent.CAPI.strcat(0xba06, this.oParent.GameData.Terrains[(int)this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
						this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
						this.oParent.GameData.Players[playerID].Units[unitID].Position.Y)].Name);
					// Instruction address 0x1403:0x430f, size: 5
					this.oParent.CAPI.strcat(0xba06, ")");
					// Instruction address 0x1403:0x4325, size: 5
					this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0(0xba06, 4, Local_a, 0);

					Local_a += 8;

					Local_10 = (int)this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(
						this.oParent.GameData.Players[playerID].Units[unitID].Position.X, this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);

					if ((Local_10 & 0x10) != 0)
					{
						// Instruction address 0x1403:0x4371, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("(RailRoad)", 4, Local_a, 0);

						Local_a += 8;
					}
					else
					{
						if ((Local_10 & 0x8) != 0)
						{
							// Instruction address 0x1403:0x4371, size: 5
							this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("(Road)", 4, Local_a, 0);

							Local_a += 8;
						}
					}

					if ((Local_10 & 0x2) != 0)
					{
						// Instruction address 0x1403:0x43a6, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("(Irrigation)", 4, Local_a, 0);

						Local_a += 8;
					}
					else
					{
						if ((Local_10 & 0x4) != 0)
						{
							// Instruction address 0x1403:0x43a6, size: 5
							this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("(Mining)", 4, Local_a, 0);

							Local_a += 8;
						}
					}

					if ((Local_10 & 0x40) != 0)
					{
						// Instruction address 0x1403:0x43c6, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("(Pollution)", 4, Local_a, 0);

						Local_a += 8;
					}

					Local_a += 4;
					Local_4 = this.oParent.GameData.Players[playerID].Units[unitID].NextUnitID;
					Local_8 = 8;

					if (((int)this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(
						this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
						this.oParent.GameData.Players[playerID].Units[unitID].Position.Y) & 0x1) != 0)
					{
						Local_2 = this.oParent.Segment_2dc4.F0_2dc4_00ba_GetCityID(
							this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
							this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);

						for (Local_6 = 0; Local_6 < 2; Local_6++)
						{
							Local_12 = this.oParent.GameData.Cities[Local_2].Unknown[Local_6];

							if (Local_12 != -1)
							{
								this.oParent.GameData.Players[playerID].Units[127].TypeID = (short)(Local_12 & 0x3f);
								this.oParent.GameData.Players[playerID].Units[127].Status = 8;
								this.oParent.GameData.Players[playerID].Units[127].GoToDestination.X = -1;

								// Instruction address 0x1403:0x4468, size: 5
								this.oParent.MapManagement.F0_2aea_0fb3_DrawUnitWithStatus(playerID, 127, Local_8, Local_a);

								this.oParent.GameData.Players[playerID].Units[127].TypeID = -1;

								Local_8 += 16;
							}
						}
					}

					while (Local_4 != -1)
					{
						if (Local_4 == unitID || Local_a >= 184)
							break;

						// Instruction address 0x1403:0x449f, size: 5
						this.oParent.MapManagement.F0_2aea_0fb3_DrawUnitWithStatus(playerID, Local_4, Local_8, Local_a);

						Local_8 += 16;

						if (Local_8 > 64)
						{
							Local_8 = 8;
							Local_a += 16;
						}

						Local_4 = this.oParent.GameData.Players[playerID].Units[Local_4].NextUnitID;
					}

					if (Local_4 != -1 && Local_4 != unitID)
					{
						// Instruction address 0x1403:0x44f5, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("+", 74, 192, 0);
					}
				}
			}

			// Instruction address 0x1403:0x44fd, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public bool F0_1403_4508(int x, int y)
		{
			// This function is referenced 4 time(s)
			// Standard C frame
			//this.oCPU.Log.EnterBlock("'Fn7'(Cdecl, Far, Return) at 0x4508");
			// function body
			if (x < 16 && this.oParent.Var_d4cc_MapViewX >= 65)
			{
				x += 80;
			}

			return (x >= this.oParent.Var_d4cc_MapViewX && x < this.oParent.Var_d4cc_MapViewX + 15 &&
				y >= this.oParent.Var_d75e_MapViewY && y < this.oParent.Var_d75e_MapViewY + 12);
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1403_4545()
		{
			// This function is referenced 29 time(s)
			// Assembly
			//this.oCPU.Log.EnterBlock("'Fn8'(Cdecl, Far, Return) at 0x4545");
			// function body
			while (this.oParent.CAPI.kbhit() != 0)
			{
				// Instruction address 0x1403:0x4547, size: 5
				this.oParent.ManuBoxDialog.F0_2d05_0ac9_GetNavigationKey();
			}

			do
			{
				// Instruction address 0x1403:0x4555, size: 5
				this.oParent.Segment_11a8.F0_11a8_0223_UpdateMouse();
			}
			while (this.oParent.Var_db3a_MouseButton != 0x0);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		private int F0_1403_4562(int playerID, int unitID)
		{
			// This function is referenced 1 time(s)
			// Standard C frame
			//this.oCPU.Log.EnterBlock("'Fn9'(Cdecl, Far, Return) at 0x4562");

			// Local variables
			int Local_2;
			int Local_4;
			int Local_6;
			int Local_8;
			int Local_a;

			// function body
			Local_6 = this.oParent.GameData.Players[playerID].Units[unitID].NextUnitID;

			if (Local_6 == -1)
			{
				return unitID;
			}
			else
			{
				Local_2 = unitID;
				Local_8 = 999;

				for (Local_a = 0; Local_a < 16; Local_a++)
				{
					if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[Local_6].TypeID].MovementType != UnitMovementTypeEnum.Air)
					{
						if (Local_6 > unitID)
						{
							Local_4 = Local_6 - unitID;
						}
						else
						{
							Local_4 = (Local_6 - unitID) + 128;
						}

						if (Local_4 < Local_8)
						{
							Local_8 = Local_4;
							Local_2 = Local_6;
						}
					}

					Local_6 = this.oParent.GameData.Players[playerID].Units[Local_6].NextUnitID;

					if (Local_6 == unitID)
						break;
				}

				return Local_2;
			}
		}

		/// <summary>
		/// Shows civilization note warning message if current player is human
		/// </summary>
		/// <param name="stringPtr"></param>
		private void F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(ushort stringPtr)
		{
			// This function is referenced 16 time(s)
			// Standard C frame
			//this.oCPU.Log.EnterBlock("'Fn10'(Cdecl, Far, Return) at 0x461c");
			// function body
			if (this.oParent.Var_6b90 == this.oParent.GameData.HumanPlayerID)
			{
				this.oParent.Help.F4_0000_03aa_ShowInstantWarningPopup(stringPtr);
			}
		}
	}
}
