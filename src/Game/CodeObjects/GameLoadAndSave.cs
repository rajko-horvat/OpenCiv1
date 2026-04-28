using Avalonia.Threading;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;
using OpenCiv1.UI;
using System.Text;

namespace OpenCiv1
{
	public class GameLoadAndSave
	{
		private OpenCiv1Game parent;
		private VCPU CPU;

		private bool loadingGame = false;
		private int gameIndex = 0;

		public GameLoadAndSave(OpenCiv1Game parent)
		{
			this.parent = parent;
			this.CPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public int F11_0000_0000_LoadGameDialog()
		{
			//this.oCPU.Log.EnterBlock($"F11_0000_0000({flag})");

			// function body

			/*LoadGameDialog? dialog = null;
			bool creatingWindow = true;

			Dispatcher.UIThread.Invoke(() => { try { dialog = new LoadGameDialog(this.parent); dialog.ShowDialog(this.parent.MainWindow); } finally { creatingWindow = false; } });

			while (creatingWindow) { Thread.Sleep(1); }

			while (dialog != null && !dialog.IsClosed) { Thread.Sleep(1); }//*/

			this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 0, 0, 320, 200, 15);

			int availableGameIndexesBitmap = 0;
			StringBuilder loadGameList = new();

			loadGameList.Append("\x008cSelect Load File...\n");

			for (int i = 0; i < 10; i++)
			{
				bool success;

				loadGameList.Append(F11_0000_0103_ReadGameInfo($"CIVIL{i}.SVE", out success));

				if (success)
				{
					availableGameIndexesBitmap |= (0x1 << i);
				}
			}

			// Instruction address 0x0000:0x0087, size: 5
			this.gameIndex = this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(loadGameList.ToString(), 48, 65, false, false, true);

			if (((0x1 << this.gameIndex) & availableGameIndexesBitmap) == 0)
			{
				this.gameIndex = -1;
			}

			if (this.gameIndex != -1 && !F11_0000_0103_LoadGame($"CIVIL{gameIndex}.SVE", this.gameIndex))
			{
				this.gameIndex = -1;
			}

			return this.gameIndex;
		}

		/// <summary>
		/// Reads an information from a saved game
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="success"></param>
		/// <returns>True if command succeeded</returns>
		public string F11_0000_0103_ReadGameInfo(string filename, out bool success)
		{
			//this.oCPU.Log.EnterBlock($"F11_0000_0103_ReadGameData(0x{filename:x4}, {flag})");

			// function body
			try
			{
				FileStream reader = new FileStream($"{this.parent.ResourcePath}{filename}", FileMode.Open, FileAccess.Read);

				reader.Seek(2, SeekOrigin.Begin);
				int humanPlayerID = ReadInt16(reader);

				reader.Seek(8, SeekOrigin.Begin);
				int currentYear = ReadInt16(reader);

				reader.Seek(10, SeekOrigin.Begin);
				int gameDifficulty = ReadInt16(reader);

				reader.Seek(16 + (humanPlayerID * 14), SeekOrigin.Begin);
				string humanPlayerName = ReadString(reader, 14);

				reader.Seek(128 + (humanPlayerID * 12), SeekOrigin.Begin);
				string humanNationName = ReadString(reader, 12);

				reader.Close();

				success = true;

				return $" {this.parent.Array_33a2_GameDifficultyNames[gameDifficulty]} {humanPlayerName}, {humanNationName}/{Math.Abs(currentYear)}" + 
					((currentYear < 0) ? " BC\n" : " AD\n");
			}
			catch
			{
				success = false;

				return " (Empty)\n";
			}
		}

		/// <summary>
		/// Loads a data from a save game
		/// </summary>
		/// <param name="filename"></param>
		/// <returns>True if command succeeded</returns>
		public bool F11_0000_0103_LoadGame(string filename, int gameIndex)
		{
			//this.oCPU.Log.EnterBlock($"F11_0000_0103_LoadGame(0x{filename:x4}, {flag})");

			// function body
			bool result = F11_0000_083b_LoadGameData(filename);

			//this.oParent.GameInitAndIntro.F7_0000_1440_ConstructWaterPath();

			if (gameIndex < 4)
			{
				this.parent.Var_df60 = 1;
			}
			else
			{
				this.parent.Var_df60 = 2;
			}

			this.parent.Var_3484 = -3;
			this.parent.GameData.SpaceshipFlags &= 0x7ffe;

			return result;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="autoSave"></param>
		public void F11_0000_036a_SaveGameDialog(bool autoSave)
		{
			//this.CPU.Log.EnterBlock($"F11_0000_036a({autoSave})");

			// function body
			this.loadingGame = false;

			// Instruction address 0x0000:0x0378, size: 5
			this.parent.MainCode.F0_11a8_0268_HideMouse();

			this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 0, 0, 320, 200, 15);

			// Instruction address 0x0000:0x03d3, size: 5
			this.parent.Var_2f9a_MenuBoxDefaultOptionIndex = this.parent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.gameIndex, 0, 3);

			if (!autoSave)
			{
				StringBuilder saveGameList = new();

				saveGameList.Append("\x008cSelect Save File...\n");

				for (int i = 0; i < 4; i++)
				{
					bool temp;
					saveGameList.Append(F11_0000_0103_ReadGameInfo($"CIVIL{i}.SVE", out temp));
				}

				// Instruction address 0x0000:0x03e4, size: 5
				this.parent.MainCode.F0_11a8_0250_ShowMouse();

				// Instruction address 0x0000:0x03f5, size: 5
				this.gameIndex = this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(saveGameList.ToString(), 48, 33, false, false, true);

				// Instruction address 0x0000:0x0400, size: 5
				this.parent.MainCode.F0_11a8_0268_HideMouse();
			}
			else
			{
				// autosave function
				this.gameIndex = 4 + (((this.parent.GameData.TurnCount / 50) - 1) % 6);
			}

			this.parent.Var_db38 = 1;

			StringBuilder saveGameText = new();

			saveGameText.Append($" CIVIL{this.gameIndex}.SVE\n {this.parent.Array_33a2_GameDifficultyNames[this.parent.GameData.DifficultyLevel]} ");
			saveGameText.Append($"{this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Name}\n {this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Nation}");
			saveGameText.Append($"/{Math.Abs(this.parent.GameData.Year)}" + ((this.parent.GameData.Year < 0) ? " BC\n" : " AD\n"));
			saveGameText.Append("\n ... save in progress.\n");

			// Instruction address 0x0000:0x05c3, size: 5
			this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(saveGameText.ToString(), 64, 86, true, false, true);

			if (F11_0000_08f6_SaveGameData($"CIVIL{this.gameIndex}.SVE"))
			{
				MessageBox.Show(this.parent.MainWindow, "The current game has been saved.", "Result", MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show(this.parent.MainWindow, "The current game was NOT saved.", "Error", MessageBoxIcon.Error);
			}

			this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 0, 0, 320, 200, this.parent.Var_aa_Screen0_Rectangle, 0, 0);

			// Instruction address 0x0000:0x04e6, size: 5
			this.parent.MainCode.F0_11a8_0250_ShowMouse();
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public bool F11_0000_083b_LoadGameData(string filename)
		{
			filename = filename.ToUpper();

			//this.CPU.Log.EnterBlock($"F11_0000_083b_LoadGameData('{path}')");

			// function body
			bool bSuccess = false;
			string filenameWithoutExtension = Path.GetFileNameWithoutExtension(CAPI.GetDOSFileName(filename));

			try
			{
				// read map file
				GBitmap? map;

				if ((map = GBitmap.FromPICFile($"{this.parent.ResourcePath}{filenameWithoutExtension}.MAP", true)) == null)
					throw new Exception($"Can't read Map file '{filenameWithoutExtension}.MAP'");

				this.parent.GameData.Map = map;

				if (this.parent.Graphics.Screens.ContainsKey(3))
				{
					this.parent.Graphics.Screens.RemoveByKey(3);
				}

				this.parent.Graphics.Screens.Add(3, this.parent.GameData.Map);

				// read sve file
				FileStream reader = new FileStream($"{this.parent.ResourcePath}{filenameWithoutExtension}.SVE", FileMode.Open);
				this.parent.GameData.TurnCount = ReadInt16(reader);
				this.parent.GameData.HumanPlayerID = ReadInt16(reader);
				this.parent.GameData.PlayerFlags = ReadInt16(reader);
				this.parent.GameData.RandomSeed = ReadUInt16(reader);
				this.parent.GameData.Year = ReadInt16(reader);
				this.parent.GameData.DifficultyLevel = ReadInt16(reader);
				this.parent.GameData.ActiveCivilizations = ReadInt16(reader);
				this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].ResearchTechnologyID = ReadInt16(reader);

				for (int i = 0; i < 8; i++)
				{
					this.parent.GameData.Players[i].Name = ReadString(reader, 14);
				}

				for (int i = 0; i < 8; i++)
				{
					this.parent.GameData.Players[i].Nation = ReadString(reader, 12);
				}

				for (int i = 0; i < 8; i++)
				{
					this.parent.GameData.Players[i].Nationality = ReadString(reader, 11);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].Coins = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].ResearchProgress = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].ActiveUnits.Length; j++)
					{
						this.parent.GameData.Players[i].ActiveUnits[j] = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].UnitsInProduction.Length; j++)
					{
						this.parent.GameData.Players[i].UnitsInProduction[j] = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].DiscoveredTechnologyCount = ReadInt16(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 5; j++)
					{
						this.parent.GameData.Players[i].DiscoveredTechnologyFlags[j] = ReadUInt16(reader);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].GovernmentType = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].Continents.Length; j++)
					{
						this.parent.GameData.Players[i].Continents[j].Strategy = ReadInt16(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						this.parent.GameData.Players[i].Diplomacy[j] = ReadUInt16(reader);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].CityCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].UnitCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].LandCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].SettlerCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].TotalCitySize = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].MilitaryPower = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].Ranking = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].TaxRate = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].Score = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].ContactPlayerCountdown = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].XStart = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].NationalityID = ReadInt16(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.parent.GameData.Players[i].Continents[j].Attack = ReadInt16(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.parent.GameData.Players[i].Continents[j].Defense = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].Continents.Length; j++)
					{
						this.parent.GameData.Players[i].Continents[j].CityCount = ReadInt16(reader);
					}
				}

				for (int i = 0; i < 16; i++)
				{
					this.parent.GameData.Continents[i].Size = ReadInt16(reader);
				}
				reader.Seek(48 * 2, SeekOrigin.Current);

				for (int i = 0; i < 16; i++)
				{
					this.parent.GameData.Oceans[i].Size = ReadInt16(reader);
				}
				reader.Seek(48 * 2, SeekOrigin.Current);

				for (int i = 0; i < 16; i++)
				{
					this.parent.GameData.Continents[i].BuildSiteCount = ReadInt16(reader);
				}

				for (int i = 0; i < 1200; i++)
				{
					this.parent.GameData.ScoreGraphData[i] = ReadUInt8(reader);
				}

				for (int i = 0; i < this.parent.GameData.PeaceGraphData.Length; i++)
				{
					this.parent.GameData.PeaceGraphData[i] = ReadUInt8(reader);
				}

				for (int i = 0; i < this.parent.GameData.Cities.Length; i++)
				{
					this.parent.GameData.Cities[i] = City.FromStream(i, reader);
				}

				for (int i = 0; i < 28; i++)
				{
					this.parent.GameData.Units[i] = UnitDefinition.FromStream(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 128; j++)
					{
						this.parent.GameData.Players[i].Units[j] = Unit.FromStream(reader);
					}
				}

				for (int i = 0; i < 80; i++)
				{
					for (int j = 0; j < 50; j++)
					{
						this.parent.GameData.MapVisibility[i, j] = (ushort)((short)((sbyte)ReadUInt8(reader)));
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.parent.GameData.Players[i].StrategicLocations[j].Active = (sbyte)ReadUInt8(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.parent.GameData.Players[i].StrategicLocations[j].Policy = ReadUInt8(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.parent.GameData.Players[i].StrategicLocations[j].Position.X = (sbyte)ReadUInt8(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.parent.GameData.Players[i].StrategicLocations[j].Position.Y = (sbyte)ReadUInt8(reader);
					}
				}

				for (int i = 0; i < this.parent.GameData.TechnologyFirstDiscoveredBy.Length; i++)
				{
					this.parent.GameData.TechnologyFirstDiscoveredBy[i] = ReadInt16(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						this.parent.GameData.Players[i].UnitsDestroyed[j] = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.parent.GameData.CityNames.Length; i++)
				{
					this.parent.GameData.CityNames[i] = ReadString(reader, 13);
				}

				this.parent.GameData.ReplayDataLength = ReadInt16(reader);

				for (int i = 0; i < this.parent.GameData.ReplayData.Length; i++)
				{
					this.parent.GameData.ReplayData[i] = ReadUInt8(reader);
				}

				for (int i = 0; i < this.parent.GameData.WonderCityID.Length; i++)
				{
					this.parent.GameData.WonderCityID[i] = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].LostUnits.Length; j++)
					{
						this.parent.GameData.Players[i].LostUnits[j] = ReadInt16(reader);

					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].TechnologyAcquiredFrom.Length; j++)
					{
						this.parent.GameData.Players[i].TechnologyAcquiredFrom[j] = (sbyte)ReadUInt8(reader);
					}
				}

				this.parent.GameData.PollutedSquareCount = ReadInt16(reader);
				this.parent.GameData.PollutionEffectLevel = ReadInt16(reader);
				this.parent.GameData.GlobalWarmingCount = ReadInt16(reader);
				this.parent.GameData.GameSettingFlags.Value = ReadInt16(reader);

				//reader.Seek(260, SeekOrigin.Current); // Skip corrupted Land path data
				int[,] landPath = this.parent.UnitGoTo.Arr_db44_LandPath;

				for (int i = 0; i < 20; i++)
				{
					for (int j = 0; j < 13; j++)
					{
						landPath[i, j] = ReadUInt8(reader);
					}
				}

				this.parent.GameData.MaximumTechnologyCount = ReadInt16(reader);
				this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].FutureTechnologyCount = ReadInt16(reader);
				this.parent.GameData.DebugFlags = ReadInt16(reader);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].ScienceTaxRate = ReadInt16(reader);
				}
				
				this.parent.GameData.NextAnthologyTurn = ReadInt16(reader);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].CumulativeEpicRanking = ReadInt16(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					byte[] buffer = new byte[180];
					reader.Read(buffer, 0, 180);

					for (int j = 0; j < 180; j++)
					{
						this.parent.GameData.Players[i].SpaceshipData[j] = (sbyte)buffer[j];
					}
				}

				this.parent.GameData.SpaceshipFlags = ReadInt16(reader);
				this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].SpaceshipSuccessRate = ReadInt16(reader);
				this.parent.GameData.AISpaceshipSuccessRate = ReadInt16(reader);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].SpaceshipETAYear = ReadInt16(reader);
				}

				for (int i = 0; i < 12; i++)
				{
					this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].PalaceData1[i + 2] = ReadInt16(reader);
				}

				for (int i = 0; i < 12; i++)
				{
					this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].PalaceData2[i] = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.CityPositions.Length; i++)
				{
					this.parent.GameData.CityPositions[i].X = (sbyte)ReadUInt8(reader);
				}

				for (int i = 0; i < this.parent.GameData.CityPositions.Length; i++)
				{
					this.parent.GameData.CityPositions[i].Y = (sbyte)ReadUInt8(reader);
				}

				this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].PalaceLevel = ReadInt16(reader);
				this.parent.GameData.PeaceTurnCount = ReadInt16(reader);
				this.parent.GameData.AIOpponentCount = ReadInt16(reader);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].SpaceshipPopulation = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].SpaceshipLaunchYear = ReadInt16(reader);
				}

				this.parent.GameData.PlayerIdentityFlags = ReadInt16(reader);

				reader.Close();

				bSuccess = true;
			}
			catch (Exception ex)
			{
				this.parent.CAPI.strcpy(0xba06, ex.Message);

				// Instruction address 0x0000:0x08a3, size: 5
				this.parent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

				bSuccess = false;
			}

			return bSuccess;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static byte ReadUInt8(Stream reader)
		{
			int byte0 = reader.ReadByte();

			if (byte0 >= 0)
			{
				return (byte)byte0;
			}

			return 0;
		}

		/// <summary>
		/// Reads a UInt16 from a Stream
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static ushort ReadUInt16(Stream reader)
		{
			int byte0 = reader.ReadByte();
			int byte1 = reader.ReadByte();

			if (byte0 >= 0 && byte1 >= 0)
			{
				return (ushort)(byte0 | (byte1 << 8));
			}

			return 0;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static short ReadInt16(Stream reader)
		{
			int byte0 = reader.ReadByte();
			int byte1 = reader.ReadByte();

			if (byte0 >= 0 && byte1 >= 0)
			{
				return (short)(byte0 | (byte1 << 8));
			}

			return 0;
		}

		/// <summary>
		/// Reads a UInt32 from a Stream
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static uint ReadUInt32(Stream reader)
		{
			int byte0 = reader.ReadByte();
			int byte1 = reader.ReadByte();
			int byte2 = reader.ReadByte();
			int byte3 = reader.ReadByte();

			if (byte0 >= 0 && byte1 >= 0 && byte2 >= 0 && byte3 >= 0)
			{
				return (uint)(byte0 | (byte1 << 8) | (byte2 << 16) | (byte3 << 24));
			}

			return 0;
		}

		/// <summary>
		/// Reads a null terminated string from the stream (null character included)
		/// </summary>
		/// <param name="reader">Reading stream</param>
		/// <param name="length">Full string length, including null character</param>
		/// <returns></returns>
		public static string ReadString(Stream reader, int length)
		{
			int len = 0;
			char[] str = new char[length];
			bool end = false;

			for (int i = 0; i < length - 1; i++)
			{
				int ch = reader.ReadByte();

				if (!end && ch >= 0)
				{
					if (ch == 0)
					{
						end = true;
					}
					else
					{
						str[len] = (char)ch;
						len++;
					}
				}
			}

			reader.ReadByte();

			return new string(str, 0, len);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="filename"></param>
		/// <returns></returns>
		public bool F11_0000_08f6_SaveGameData(string filename)
		{
			filename = filename.ToUpper();

			//this.CPU.Log.EnterBlock($"F11_0000_08f6_SaveGameData('{filename}')");

			// function body
			bool bSuccess = false;
			string filenameWithoutExtension = Path.GetFileNameWithoutExtension(CAPI.GetDOSFileName(filename));

			try
			{
				// write map file
				this.parent.GameData.Map.SaveToPIC($"{this.parent.ResourcePath}{filenameWithoutExtension}.MAP", false);

				// write sve file
				FileStream writer = new FileStream($"{this.parent.ResourcePath}{filenameWithoutExtension}.SVE", FileMode.Create);
				WriteInt16(writer, this.parent.GameData.TurnCount);
				WriteInt16(writer, this.parent.GameData.HumanPlayerID);
				WriteInt16(writer, this.parent.GameData.PlayerFlags);
				WriteUInt16(writer, this.parent.GameData.RandomSeed);
				WriteInt16(writer, this.parent.GameData.Year);
				WriteInt16(writer, this.parent.GameData.DifficultyLevel);
				WriteInt16(writer, this.parent.GameData.ActiveCivilizations);
				WriteInt16(writer, this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].ResearchTechnologyID);

				for (int i = 0; i < 8; i++)
				{
					WriteString(writer, this.parent.GameData.Players[i].Name, 14);
				}

				for (int i = 0; i < 8; i++)
				{
					WriteString(writer, this.parent.GameData.Players[i].Nation, 12);
				}

				for (int i = 0; i < 8; i++)
				{
					WriteString(writer, this.parent.GameData.Players[i].Nationality, 11);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].Coins);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].ResearchProgress);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].ActiveUnits.Length; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].ActiveUnits[j]);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].UnitsInProduction.Length; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].UnitsInProduction[j]);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].DiscoveredTechnologyCount);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 5; j++)
					{
						WriteUInt16(writer, this.parent.GameData.Players[i].DiscoveredTechnologyFlags[j]);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].GovernmentType);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].Continents.Length; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].Continents[j].Strategy);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						WriteUInt16(writer, this.parent.GameData.Players[i].Diplomacy[j]);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].CityCount);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].UnitCount);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].LandCount);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].SettlerCount);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].TotalCitySize);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].MilitaryPower);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].Ranking);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].TaxRate);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].Score);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].ContactPlayerCountdown);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].XStart);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].NationalityID);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].Continents[j].Attack);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].Continents[j].Defense);
					}
				}
				
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].Continents[j].CityCount);
					}
				}

				for (int i = 0; i < 16; i++)
				{
					WriteInt16(writer, this.parent.GameData.Continents[i].Size);
				}

				for (int i = 0; i < 48; i++)
				{
					WriteInt16(writer, 0);
				}

				for (int i = 0; i < 16; i++)
				{
					WriteInt16(writer, this.parent.GameData.Oceans[i].Size);
				}

				for (int i = 0; i < 48; i++)
				{
					WriteInt16(writer, 0);
				}

				for (int i = 0; i < 16; i++)
				{
					WriteInt16(writer, this.parent.GameData.Continents[i].BuildSiteCount);
				}

				for (int i = 0; i < 1200; i++)
				{
					writer.WriteByte(this.parent.GameData.ScoreGraphData[i]);
				}

				for (int i = 0; i < this.parent.GameData.PeaceGraphData.Length; i++)
				{
					writer.WriteByte(this.parent.GameData.PeaceGraphData[i]);
				}

				for (int i = 0; i < this.parent.GameData.Cities.Length; i++)
				{
					this.parent.GameData.Cities[i].ToStream(writer);
				}

				for (int i = 0; i < 28; i++)
				{
					this.parent.GameData.Units[i].ToStream(writer);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 128; j++)
					{
						this.parent.GameData.Players[i].Units[j].ToStream(writer);
					}
				}

				for (int i = 0; i < 80; i++)
				{
					for (int j = 0; j < 50; j++)
					{
						writer.WriteByte((byte)((sbyte)((short)this.parent.GameData.MapVisibility[i, j])));
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						writer.WriteByte((byte)this.parent.GameData.Players[i].StrategicLocations[j].Active);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						writer.WriteByte(this.parent.GameData.Players[i].StrategicLocations[j].Policy);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						writer.WriteByte((byte)this.parent.GameData.Players[i].StrategicLocations[j].Position.X);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						writer.WriteByte((byte)this.parent.GameData.Players[i].StrategicLocations[j].Position.Y);
					}
				}

				for (int i = 0; i < this.parent.GameData.TechnologyFirstDiscoveredBy.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.TechnologyFirstDiscoveredBy[i]);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].UnitsDestroyed[j]);
					}
				}

				for (int i = 0; i < this.parent.GameData.CityNames.Length; i++)
				{
					WriteString(writer, this.parent.GameData.CityNames[i], 13);
				}

				WriteInt16(writer, this.parent.GameData.ReplayDataLength);
				for (int i = 0; i < this.parent.GameData.ReplayData.Length; i++)
				{
					writer.WriteByte(this.parent.GameData.ReplayData[i]);
				}

				for (int i = 0; i < this.parent.GameData.WonderCityID.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.WonderCityID[i]);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].LostUnits.Length; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].LostUnits[j]);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].TechnologyAcquiredFrom.Length; j++)
					{
						writer.WriteByte((byte)((sbyte)this.parent.GameData.Players[i].TechnologyAcquiredFrom[j]));
					}
				}

				WriteInt16(writer, this.parent.GameData.PollutedSquareCount);
				WriteInt16(writer, this.parent.GameData.PollutionEffectLevel);
				WriteInt16(writer, this.parent.GameData.GlobalWarmingCount);
				WriteInt16(writer, (short)this.parent.GameData.GameSettingFlags.Value);

				int[,] landPath = this.parent.UnitGoTo.Arr_db44_LandPath;

				for (int i = 0; i < 20; i++)
				{
					for (int j = 0; j < 13; j++)
					{
						writer.WriteByte((byte)landPath[i, j]);
					}
				}

				WriteInt16(writer, this.parent.GameData.MaximumTechnologyCount);
				WriteInt16(writer, this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].FutureTechnologyCount);
				WriteInt16(writer, this.parent.GameData.DebugFlags);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].ScienceTaxRate);
				}
				
				WriteInt16(writer, this.parent.GameData.NextAnthologyTurn);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].CumulativeEpicRanking);
				}

				for (int i = 0; i < 8; i++)
				{
					byte[] buffer = new byte[180];

					for (int j = 0; j < 180; j++)
					{
						buffer[j] = (byte)this.parent.GameData.Players[i].SpaceshipData[j];
					}

					writer.Write(buffer, 0, 180);
				}

				WriteInt16(writer, this.parent.GameData.SpaceshipFlags);
				WriteInt16(writer, this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].SpaceshipSuccessRate);
				WriteInt16(writer, this.parent.GameData.AISpaceshipSuccessRate);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].SpaceshipETAYear);
				}

				for (int i = 0; i < 12; i++)
				{
					WriteInt16(writer, (short)this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].PalaceData1[i + 2]);
				}

				for (int i = 0; i < 12; i++)
				{
					WriteInt16(writer, (short)this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].PalaceData2[i]);
				}

				for (int i = 0; i < 256; i++)
				{
					writer.WriteByte((byte)((sbyte)this.parent.GameData.CityPositions[i].X));
				}
				for (int i = 0; i < 256; i++)
				{
					writer.WriteByte((byte)((sbyte)this.parent.GameData.CityPositions[i].Y));
				}

				WriteInt16(writer, this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].PalaceLevel);
				WriteInt16(writer, this.parent.GameData.PeaceTurnCount);
				WriteInt16(writer, this.parent.GameData.AIOpponentCount);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].SpaceshipPopulation);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].SpaceshipLaunchYear);
				}

				WriteInt16(writer, this.parent.GameData.PlayerIdentityFlags);

				writer.Close();

				bSuccess = true;
			}
			catch (Exception ex)
			{
				this.parent.CAPI.strcpy(0xba06, ex.Message);
				this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 4, 64, true, false, true);

				bSuccess = false;
			}

			return bSuccess;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		public static void WriteUInt16(Stream writer, ushort value)
		{
			writer.WriteByte((byte)(value & 0xff));
			writer.WriteByte((byte)((value & 0xff00) >> 8));
		}

		/// <summary>
		/// Writes an Int16 to a Stream
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		public static void WriteInt16(Stream writer, short value)
		{
			writer.WriteByte((byte)((ushort)value & 0xff));
			writer.WriteByte((byte)(((ushort)value & 0xff00) >> 8));
		}

		/// <summary>
		/// Writes an UInt32 to a Stream
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		public static void WriteUInt32(Stream writer, uint value)
		{
			writer.WriteByte((byte)(value & 0xff));
			writer.WriteByte((byte)((value & 0xff00) >> 8));
			writer.WriteByte((byte)((value & 0xff0000) >> 16));
			writer.WriteByte((byte)((value & 0xff000000) >> 24));
		}

		/// <summary>
		/// Writes a null terminated string to a stream. Null character is included in the string length
		/// </summary>
		/// <param name="writer">Writer</param>
		/// <param name="text">String to write</param>
		/// <param name="length">maximum string length including the null character</param>
		public static void WriteString(Stream writer, string text, int length)
		{
			bool end = false;

			for (int i = 0; i < length - 1; i++)
			{
				if (!end && i < text.Length)
				{
					if (text[i] == 0)
					{
						end = true;
						writer.WriteByte(0);
					}
					else
					{
						writer.WriteByte((byte)text[i]);
					}
				}
				else
				{
					writer.WriteByte(0);
				}
			}

			writer.WriteByte(0);
		}
	}
}
