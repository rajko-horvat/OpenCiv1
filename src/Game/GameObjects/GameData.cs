using System;
using IRB.Collections.Generic;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class GameData
	{
		private OpenCiv1Game oParent;

		// Static Data
		private GameStaticData oStaticData;

		// Game settings
		public short GameSettingFlags = 2;
		public short DebugFlags = 0;

		// Game common data
		public short TurnCount = 0;
		public short Year = 0;
		public ushort RandomSeed = 0;
		public short DifficultyLevel = 0;
		public short HumanPlayerID = 0;
		public short PlayerFlags = 0;
		public short PlayerIdentityFlags = 0;
		public short ActiveCivilizations = 0;
		public int BarbarianPlayerID = 0;

		public short PeaceTurnCount = 0;
		public short AIOpponentCount = 0;
		public short NextAnthologyTurn = 80;

		// Players
		public Player[] Players = new Player[8];

		// Continents
		public Continent[] Continents = new Continent[16];
		public Continent[] Oceans = new Continent[16];

		// Graphs
		public byte[] ScoreGraphData = new byte[1200];
		public byte[] PeaceGraphData = new byte[1200];

		// Cities
		public City[] Cities = new City[128];
		public string[] CityNames = new string[] {
			"Rome        \0", "Caesarea    \0", "Carthage    \0", "Nicopolis   \0", "Byzantium   \0",
			"Brundisium  \0", "Syracuse    \0", "Antioch     \0", "Palmyra     \0", "Cyrene      \0",
			"Gordion     \0", "Tyrus       \0", "Jerusalem   \0", "Seleucia    \0", "Ravenna     \0",
			"Artaxata    \0", "Babylon     \0", "Sumer       \0", "Uruk        \0", "Nineveh     \0",
			"Ashur       \0", "Ellipi      \0", "Akkad       \0", "Eridu       \0", "Kish        \0",
			"Nippur      \0", "Shuruppak   \0", "Zariqum     \0", "Izibia      \0", "Nimrud      \0",
			"Arbela      \0", "Zamua       \0", "Berlin      \0", "Leipzig     \0", "Hamburg     \0",
			"Bremen      \0", "Frankfurt   \0", "Bonn        \0", "Nuremberg   \0", "Cologne     \0",
			"Hannover    \0", "Munich      \0", "Stuttgart   \0", "Heidelburg  \0", "Salzburg    \0",
			"Konigsberg  \0", "Dortmund    \0", "Brandenburg \0", "Thebes      \0", "Memphis     \0",
			"Oryx        \0", "Heliopolis  \0", "Gaza        \0", "Alexandria  \0", "Byblos      \0",
			"Cairo       \0", "Coptos      \0", "Edfu        \0", "Pithom      \0", "Busiris     \0",
			"Athribis    \0", "Mendes      \0", "Tanis       \0", "Abydos      \0", "Washington  \0",
			"New York    \0", "Boston      \0", "Philadelphia\0", "Atlanta     \0", "Chicago     \0",
			"Buffalo     \0", "St.Louis    \0", "Detroit     \0", "New Orleans \0", "Baltimore   \0",
			"Denver      \0", "Cincinnati  \0", "Dallas      \0", "Los Angeles \0", "Las Vegas   \0",
			"Athens      \0", "Sparta      \0", "Corinth     \0", "Delphi      \0", "Eretria     \0",
			"Pharsalos   \0", "Argos       \0", "Mycenae     \0", "Herakleia   \0", "Antioch     \0",
			"Ephesos     \0", "Rhodes      \0", "Knossos     \0", "Troy        \0", "Pergamon    \0",
			"Miletos     \0", "Delhi       \0", "Bombay      \0", "Madras      \0", "Bangalore   \0",
			"Calcutta    \0", "Lahore      \0", "Karachi     \0", "Kolhapur    \0", "Jaipur      \0",
			"Hyderabad   \0", "Bengal      \0", "Chittagong  \0", "Punjab      \0", "Dacca       \0",
			"Indus       \0", "Ganges      \0", "Moscow      \0", "Leningrad   \0", "Kiev        \0",
			"Minsk       \0", "Smolensk    \0", "Odessa      \0", "Sevastopol  \0", "Tblisi      \0",
			"Sverdlovsk  \0", "Yakutsk     \0", "Vladivostok \0", "Novograd    \0", "Krasnoyarsk \0",
			"Riga        \0", "Rostov      \0", "Astrakhan   \0", "Zimbabwe    \0", "Ulundi      \0",
			"Bapedi      \0", "Hlobane     \0", "Isandhlwana \0", "Intombe     \0", "Mpondo      \0",
			"Ngome       \0", "Swazi       \0", "Tugela      \0", "Umtata      \0", "Umfolozi    \0",
			"Ibabanago   \0", "Isipezi     \0", "Amatikulu   \0", "Zunguin     \0", "Paris       \0",
			"Orleans     \0", "Lyons       \0", "Tours       \0", "Chartres    \0", "Bordeaux    \0",
			"Rouen       \0", "Avignon     \0", "Marseilles  \0", "Grenoble    \0", "Dijon       \0",
			"Amiens      \0", "Cherbourg   \0", "Poitiers    \0", "Toulouse    \0", "Bayonne     \0",
			"Tenochtitlan\0", "Chiauhtia   \0", "Chapultepec \0", "Coatepec    \0", "Ayotzinco   \0",
			"Itzapalapa  \0", "Iztapam     \0", "Mitxcoac    \0", "Tacubaya    \0", "Tecamac     \0",
			"Tepezinco   \0", "Ticoman     \0", "Tlaxcala    \0", "Xaltocan    \0", "Xicalango   \0",
			"Zumpanco    \0", "Peking      \0", "Shanghai    \0", "Canton      \0", "Nanking     \0",
			"Tsingtao    \0", "Hangchow    \0", "Tientsin    \0", "Tatung      \0", "Macao       \0",
			"Anyang      \0", "Shantung    \0", "Chinan      \0", "Kaifeng     \0", "Ningpo      \0",
			"Paoting     \0", "Yangchow    \0", "London      \0", "Coventry    \0", "Birmingham  \0",
			"Dover       \0", "Nottingham  \0", "York        \0", "Liverpool   \0", "Brighton    \0",
			"Oxford      \0", "Reading     \0", "Exeter      \0", "Cambridge   \0", "Hastings    \0",
			"Canterbury  \0", "Banbury     \0", "Newcastle   \0", "Samarkand   \0", "Bokhara     \0",
			"Nishapur    \0", "Karakorum   \0", "Kashgar     \0", "Tabriz      \0", "Aleppo      \0",
			"Kabul       \0", "Ormuz       \0", "Basra       \0", "Khanbalyk   \0", "Khorasan    \0",
			"Shangtu     \0", "Kazan       \0", "Quinsay     \0", "Kerman      \0", "Mecca       \0",
			"Naples      \0", "Sidon       \0", "Tyre        \0", "Tarsus      \0", "Issus       \0",
			"Cunaxa      \0", "Cremona     \0", "Cannae      \0", "Capua       \0", "Turin       \0",
			"Genoa       \0", "Utica       \0", "Crete       \0", "Damascus    \0", "Verona      \0",
			"Salamis     \0", "Lisbon      \0", "Hamburg     \0", "Prague      \0", "Salzburg    \0",
			"Bergen      \0", "Venice      \0", "Milan       \0", "Ghent       \0", "Pisa        \0",
			"Cordoba     \0", "Seville     \0", "Dublin      \0", "Toronto     \0", "Melbourne   \0",
			"Sydney      \0" };
		public GPoint[] CityNameFlags = new GPoint[256];

		// Wonders
		public short[] WonderCityID = new short[22];

		// Technology
		public short[] TechnologyFirstDiscoveredBy = new short[72];
		public short MaximumTechnologyCount = 0;

		// Map
		public short PollutedSquareCount = 0;
		public short PollutionEffectLevel = 0;
		public short GlobalWarmingCount = 0;
		public TerrainMap Map = new TerrainMap();

		// Replay data
		public short ReplayDataLength = 0;
		public byte[] ReplayData = new byte[4096];

		// Unused GoTo data
		public byte[,] PathFind = new byte[20, 13];

		// Spaceship
		public short SpaceshipFlags = 0;
		public short AISpaceshipSuccessRate = 0;
		private SpaceshipCell[] aSpaceshipCells = new SpaceshipCell[] {
			new SpaceshipCell(11, 5, 1), new SpaceshipCell(11, 4, 2), new SpaceshipCell(11, 6, 1),
			new SpaceshipCell(11, 7, 2), new SpaceshipCell(12, 4, 0), new SpaceshipCell(13, 4, 0),
			new SpaceshipCell(12, 5, 4), new SpaceshipCell(13, 5, 3), new SpaceshipCell(12, 7, 0),
			new SpaceshipCell(13, 7, 0), new SpaceshipCell(12, 6, 4), new SpaceshipCell(13, 6, 3),
			new SpaceshipCell(12, 8, 4), new SpaceshipCell(13, 8, 3), new SpaceshipCell(12, 3, 4),
			new SpaceshipCell(13, 3, 3), new SpaceshipCell(11, 9, 1), new SpaceshipCell(11, 10, 2),
			new SpaceshipCell(12, 10, 0), new SpaceshipCell(13, 10, 0), new SpaceshipCell(12, 9, 4),
			new SpaceshipCell(13, 9, 3), new SpaceshipCell(11, 3, 2), new SpaceshipCell(11, 2, 1),
			new SpaceshipCell(11, 1, 2), new SpaceshipCell(12, 1, 0), new SpaceshipCell(13, 1, 0),
			new SpaceshipCell(12, 2, 4), new SpaceshipCell(13, 2, 3), new SpaceshipCell(12, 11, 4),
			new SpaceshipCell(13, 11, 3), new SpaceshipCell(12, 0, 4), new SpaceshipCell(13, 0, 3),
			new SpaceshipCell(11, 5, 1), new SpaceshipCell(11, 4, 2), new SpaceshipCell(11, 6, 1),
			new SpaceshipCell(11, 7, 2), new SpaceshipCell(9, 6, 6), new SpaceshipCell(9, 4, 7),
			new SpaceshipCell(11, 3, 2), new SpaceshipCell(10, 3, 0), new SpaceshipCell(9, 3, 0),
			new SpaceshipCell(8, 1, 8), new SpaceshipCell(11, 8, 2), new SpaceshipCell(10, 8, 0),
			new SpaceshipCell(9, 8, 0), new SpaceshipCell(8, 8, 0), new SpaceshipCell(7, 8, 0),
			new SpaceshipCell(7, 6, 7), new SpaceshipCell(8, 3, 0), new SpaceshipCell(7, 3, 0),
			new SpaceshipCell(8, 9, 8), new SpaceshipCell(7, 4, 6), new SpaceshipCell(6, 3, 0),
			new SpaceshipCell(5, 3, 0), new SpaceshipCell(5, 4, 7), new SpaceshipCell(6, 8, 0),
			new SpaceshipCell(5, 8, 0), new SpaceshipCell(4, 9, 8), new SpaceshipCell(5, 6, 6),
			new SpaceshipCell(4, 3, 0), new SpaceshipCell(3, 3, 0), new SpaceshipCell(3, 6, 7),
			new SpaceshipCell(4, 8, 0), new SpaceshipCell(3, 8, 0), new SpaceshipCell(4, 1, 8),
			new SpaceshipCell(3, 4, 6), new SpaceshipCell(-1, -1, -1), new SpaceshipCell(0, 0, 0)};

		public GameData(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oStaticData = new GameStaticData();

			for (int i = 0; i < this.Players.Length; i++)
			{
				this.Players[i] = new Player(this, i);
			}

			for (int i = 0; i < 16; i++)
			{
				this.Continents[i] = new Continent();
			}

			for (int i = 0; i < 16; i++)
			{
				this.Oceans[i] = new Continent();
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
				this.Cities[i] = new City(i);
			}

			for (int i = 0; i < this.CityNameFlags.Length; i++)
			{
				this.CityNameFlags[i] = new GPoint(-1, -1);
			}

			for (int i = 0; i < this.WonderCityID.Length; i++)
			{
				this.WonderCityID[i] = -1;
			}

			for (int i = 0; i < this.TechnologyFirstDiscoveredBy.Length; i++)
			{
				this.TechnologyFirstDiscoveredBy[i] = 0;
			}

			for (int i = 0; i < this.ReplayData.Length; i++)
			{
				this.ReplayData[i] = 0;
			}

			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < 13; j++)
				{
					this.PathFind[i, j] = 0;
				}
			}
		}

		public GameStaticData Static
		{
			get => this.oStaticData;
		}

		public SpaceshipCell[] SpaceshipCells
		{
			get => this.aSpaceshipCells;
		}
	}
}
