using OpenCiv1.Properties;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCiv1
{
	public class GameState
	{
		public ushort TurnCount = 0;
		public short Year = 0;
		public ushort RandomSeed = 0;
		public short DifficultyLevel = 0;
		public ushort HumanPlayerID = 0;
		public short PlayerFlags = 0;
		public short CivilizationIdentityFlags = 0;
		public short ActiveCivilizations = 0;

		public short PeaceTurnCount = 0;
		public short AIOpponentCount = 0;
		public short NextAnthologyTurn = 80;

		public Player[] Players = new Player[8];
		public short PalaceLevel = 0;
		public short[] PalaceData1 = new short[13];
		public short[] PalaceData2 = new short[13];

		public short[] PerContinentSizeAndPerOceanSize = new short[128];
		public short[] PerContinentCityBuildSitesCount = new short[16];
		public byte[] ScoreGraphData = new byte[1200];
		public byte[] PeaceGraphData = new byte[1200];

		public City[] Cities = new City[128];
		public string[] CityNames = new string[] {
			"Rome        ", "Caesarea    ", "Carthage    ", "Nicopolis   ", "Byzantium   ",
			"Brundisium  ", "Syracuse    ", "Antioch     ", "Palmyra     ", "Cyrene      ",
			"Gordion     ", "Tyrus       ", "Jerusalem   ", "Seleucia    ", "Ravenna     ",
			"Artaxata    ", "Babylon     ", "Sumer       ", "Uruk        ", "Nineveh     ",
			"Ashur       ", "Ellipi      ", "Akkad       ", "Eridu       ", "Kish        ",
			"Nippur      ", "Shuruppak   ", "Zariqum     ", "Izibia      ", "Nimrud      ",
			"Arbela      ", "Zamua       ", "Berlin      ", "Leipzig     ", "Hamburg     ",
			"Bremen      ", "Frankfurt   ", "Bonn        ", "Nuremberg   ", "Cologne     ",
			"Hannover    ", "Munich      ", "Stuttgart   ", "Heidelburg  ", "Salzburg    ",
			"Konigsberg  ", "Dortmund    ", "Brandenburg ", "Thebes      ", "Memphis     ",
			"Oryx        ", "Heliopolis  ", "Gaza        ", "Alexandria  ", "Byblos      ",
			"Cairo       ", "Coptos      ", "Edfu        ", "Pithom      ", "Busiris     ",
			"Athribis    ", "Mendes      ", "Tanis       ", "Abydos      ", "Washington  ",
			"New York    ", "Boston      ", "Philadelphia", "Atlanta     ", "Chicago     ",
			"Buffalo     ", "St.Louis    ", "Detroit     ", "New Orleans ", "Baltimore   ",
			"Denver      ", "Cincinnati  ", "Dallas      ", "Los Angeles ", "Las Vegas   ",
			"Athens      ", "Sparta      ", "Corinth     ", "Delphi      ", "Eretria     ",
			"Pharsalos   ", "Argos       ", "Mycenae     ", "Herakleia   ", "Antioch     ",
			"Ephesos     ", "Rhodes      ", "Knossos     ", "Troy        ", "Pergamon    ",
			"Miletos     ", "Delhi       ", "Bombay      ", "Madras      ", "Bangalore   ",
			"Calcutta    ", "Lahore      ", "Karachi     ", "Kolhapur    ", "Jaipur      ",
			"Hyderabad   ", "Bengal      ", "Chittagong  ", "Punjab      ", "Dacca       ",
			"Indus       ", "Ganges      ", "Moscow      ", "Leningrad   ", "Kiev        ",
			"Minsk       ", "Smolensk    ", "Odessa      ", "Sevastopol  ", "Tblisi      ",
			"Sverdlovsk  ", "Yakutsk     ", "Vladivostok ", "Novograd    ", "Krasnoyarsk ",
			"Riga        ", "Rostov      ", "Astrakhan   ", "Zimbabwe    ", "Ulundi      ",
			"Bapedi      ", "Hlobane     ", "Isandhlwana ", "Intombe     ", "Mpondo      ",
			"Ngome       ", "Swazi       ", "Tugela      ", "Umtata      ", "Umfolozi    ",
			"Ibabanago   ", "Isipezi     ", "Amatikulu   ", "Zunguin     ", "Paris       ",
			"Orleans     ", "Lyons       ", "Tours       ", "Chartres    ", "Bordeaux    ",
			"Rouen       ", "Avignon     ", "Marseilles  ", "Grenoble    ", "Dijon       ",
			"Amiens      ", "Cherbourg   ", "Poitiers    ", "Toulouse    ", "Bayonne     ",
			"Tenochtitlan", "Chiauhtia   ", "Chapultepec ", "Coatepec    ", "Ayotzinco   ",
			"Itzapalapa  ", "Iztapam     ", "Mitxcoac    ", "Tacubaya    ", "Tecamac     ",
			"Tepezinco   ", "Ticoman     ", "Tlaxcala    ", "Xaltocan    ", "Xicalango   ",
			"Zumpanco    ", "Peking      ", "Shanghai    ", "Canton      ", "Nanking     ",
			"Tsingtao    ", "Hangchow    ", "Tientsin    ", "Tatung      ", "Macao       ",
			"Anyang      ", "Shantung    ", "Chinan      ", "Kaifeng     ", "Ningpo      ",
			"Paoting     ", "Yangchow    ", "London      ", "Coventry    ", "Birmingham  ",
			"Dover       ", "Nottingham  ", "York        ", "Liverpool   ", "Brighton    ",
			"Oxford      ", "Reading     ", "Exeter      ", "Cambridge   ", "Hastings    ",
			"Canterbury  ", "Banbury     ", "Newcastle   ", "Samarkand   ", "Bokhara     ",
			"Nishapur    ", "Karakorum   ", "Kashgar     ", "Tabriz      ", "Aleppo      ",
			"Kabul       ", "Ormuz       ", "Basra       ", "Khanbalyk   ", "Khorasan    ",
			"Shangtu     ", "Kazan       ", "Quinsay     ", "Kerman      ", "Mecca       ",
			"Naples      ", "Sidon       ", "Tyre        ", "Tarsus      ", "Issus       ",
			"Cunaxa      ", "Cremona     ", "Cannae      ", "Capua       ", "Turin       ",
			"Genoa       ", "Utica       ", "Crete       ", "Damascus    ", "Verona      ",
			"Salamis     ", "Lisbon      ", "Hamburg     ", "Prague      ", "Salzburg    ",
			"Bergen      ", "Venice      ", "Milan       ", "Ghent       ", "Pisa        ",
			"Cordoba     ", "Seville     ", "Dublin      ", "Toronto     ", "Melbourne   ",
			"Sydney      " };
		public sbyte[,] CityXPosition = new sbyte[16, 16];
		public sbyte[,] CityYPosition = new sbyte[16, 16];

		public short[] WonderCityID = new short[22];

		public short CurrentResearchID = 0;
		public short[] TechnologyFirstDiscoveredBy = new short[72];
		public short MaximumTechnologyCount = 0;
		public short PlayerFutureTechnology = 0;

		public UnitDefinition[] aUnitDefinitions = new UnitDefinition[]{
			new UnitDefinition("Settlers", 127, 0, 1, 0, 0, 1, 4, 0, 0, 0, -1),
			new UnitDefinition("Militia", 34, 0, 1, 0, 1, 1, 1, 0, 0, 2, -1),
			new UnitDefinition("Phalanx", 34, 0, 1, 0, 1, 2, 2, 0, 0, 2, 17),
			new UnitDefinition("Legion", 64, 0, 1, 0, 3, 1, 2, 0, 0, 1, 18),
			new UnitDefinition("Musketeers", 64, 0, 1, 0, 2, 3, 3, 0, 0, 2, 34),
			new UnitDefinition("Riflemen", 127, 0, 1, 0, 3, 5, 3, 0, 0, 2, 64),
			new UnitDefinition("Cavalry", 64, 0, 2, 0, 2, 1, 2, 0, 0, 1, 31),
			new UnitDefinition("Knights", 58, 0, 2, 0, 4, 2, 4, 0, 0, 1, 62),
			new UnitDefinition("Catapult", 48, 0, 1, 0, 6, 1, 4, 0, 0, 1, 9),
			new UnitDefinition("Cannon", 63, 0, 1, 0, 8, 1, 4, 0, 0, 1, 48),
			new UnitDefinition("Chariot", 62, 0, 2, 0, 4, 1, 4, 0, 0, 1, 33),
			new UnitDefinition("Armor", 127, 0, 3, 0, 10, 5, 8, 0, 0, 1, 58),
			new UnitDefinition("Mech. Inf.", 127, 0, 3, 0, 6, 6, 5, 0, 0, 2, 65),
			new UnitDefinition("Artillery", 127, 0, 2, 0, 12, 2, 6, 0, 0, 1, 63),
			new UnitDefinition("Fighter", 127, 1, 10, 1, 4, 2, 6, 2, 0, 4, 38),
			new UnitDefinition("Bomber", 127, 1, 8, 2, 12, 1, 12, 2, 0, 1, 39),
			new UnitDefinition("Trireme", 8, 2, 3, 0, 1, 0, 4, 0, 2, 5, 7),
			new UnitDefinition("Sail", 14, 2, 3, 0, 1, 1, 4, 0, 3, 5, 8),
			new UnitDefinition("Frigate", 35, 2, 3, 0, 2, 2, 4, 0, 4, 5, 14),
			new UnitDefinition("Ironclad", 37, 2, 4, 0, 4, 4, 6, 0, 0, 3, 23),
			new UnitDefinition("Cruiser", 127, 2, 6, 0, 6, 6, 8, 3, 0, 3, 37),
			new UnitDefinition("Battleship", 127, 2, 4, 0, 18, 12, 16, 3, 0, 3, 52),
			new UnitDefinition("Submarine", 127, 2, 3, 0, 8, 2, 5, 3, 0, 3, 41),
			new UnitDefinition("Carrier", 127, 2, 5, 0, 1, 12, 16, 3, 0, 3, 39),
			new UnitDefinition("Transport", 127, 2, 4, 0, 0, 3, 5, 0, 8, 5, 35),
			new UnitDefinition("Nuclear", 127, 1, 16, 1, 99, 0, 16, 0, 0, 1, 46),
			new UnitDefinition("Diplomat", 127, 0, 2, 0, 0, 0, 3, 0, 0, 6, 22),
			new UnitDefinition("Caravan", 127, 0, 1, 0, 0, 1, 5, 0, 0, 6, 24)};

		public byte[] MapVisibility = new byte[4000];

		public short PollutedSquareCount = 0;
		public short PollutionEffectLevel = 0;
		public short GlobalWarmingCount = 0;

		public short ReplayDataLength = 0;
		public byte[] ReplayData = new byte[4096];

		public byte[] LandPathfinding = new byte[260];

		public short GameSettingFlags = 2;
		public short DebugFlags = 0;

		public short SpaceshipFlags = 0;
		public short PlayerSpaceshipSuccessRate = 0;
		public short AISpaceshipSuccessRate = 0;

		public GameState()
		{
			for (int i = 0; i < this.Players.Length; i++)
			{
				this.Players[i] = new Player();
			}

			for (int i = 0; i < this.PalaceData1.Length; i++)
			{
				this.PalaceData1[i] = 0;
			}

			for (int i = 0; i < this.PalaceData2.Length; i++)
			{
				this.PalaceData2[i] = 0;
			}

			for (int i = 0; i < this.PerContinentSizeAndPerOceanSize.Length; i++)
			{
				this.PerContinentSizeAndPerOceanSize[i] = 0;
			}

			for (int i = 0; i < this.PerContinentCityBuildSitesCount.Length; i++)
			{
				this.PerContinentCityBuildSitesCount[i] = 0;
			}

			for (int i = 0; i < this.ScoreGraphData.Length; i++)
			{
				this.ScoreGraphData[i] = 0;
			}

			for (int i = 0; i < this.PeaceGraphData.Length; i++)
			{
				this.PeaceGraphData[i] = 0;
			}

			for (int i = 0; i < this.Cities.Length; i++)
			{
				this.Cities[i] = new City();
			}

			for (int i = 0; i < this.CityXPosition.GetLength(0); i++)
			{
				for (int j = 0; j < this.CityXPosition.GetLength(1); j++)
				{
					this.CityXPosition[i, j] = 0;
				}
			}

			for (int i = 0; i < this.CityYPosition.GetLength(0); i++)
			{
				for (int j = 0; j < this.CityYPosition.GetLength(1); j++)
				{
					this.CityYPosition[i, j] = 0;
				}
			}

			for (int i = 0; i < this.WonderCityID.Length; i++)
			{
				this.WonderCityID[i] = 0;
			}

			for (int i = 0; i < this.TechnologyFirstDiscoveredBy.Length; i++)
			{
				this.TechnologyFirstDiscoveredBy[i] = 0;
			}

			for (int i = 0; i < this.MapVisibility.Length; i++)
			{
				this.MapVisibility[i] = 0;
			}

			for (int i = 0; i < this.ReplayData.Length; i++)
			{
				this.ReplayData[i] = 0;
			}

			for (int i = 0; i < this.LandPathfinding.Length; i++)
			{
				this.LandPathfinding[i] = 0;
			}
		}
	}
}
