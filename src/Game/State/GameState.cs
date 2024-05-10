using System;
using IRB.Collections.Generic;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class GameState
	{
		// Game common data
		public short TurnCount = 0;
		public short Year = 0;
		public ushort RandomSeed = 0;
		public short DifficultyLevel = 0;
		public short HumanPlayerID = 0;
		public short PlayerFlags = 0;
		public short PlayerIdentityFlags = 0;
		public short ActiveCivilizations = 0;

		public short PeaceTurnCount = 0;
		public short AIOpponentCount = 0;
		public short NextAnthologyTurn = 80;

		// Game settings
		public short GameSettingFlags = 2;
		public short DebugFlags = 0;

		// Players
		public Player[] Players = new Player[8];

		// Continents
		public short[] PerContinentSizeAndPerOceanSize = new short[128];
		public Continent[] Continents = new Continent[64];
		public Continent[] Oceans = new Continent[64];

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
		public GPoint[] CityPositions = new GPoint[256];

		// Wonders
		public short[] WonderCityID = new short[22];

		// Technology
		public short[] TechnologyFirstDiscoveredBy = new short[72];
		public short MaximumTechnologyCount = 0;
		private TechnologyDefinition[] aTechnologyDefinitions = new TechnologyDefinition[] {
				new TechnologyDefinition(TechnologyEnum.Alphabet, "Alphabet", TechnologyEnum.None, TechnologyEnum.None),
				new TechnologyDefinition(TechnologyEnum.CodeOfLaws, "Code of Laws", TechnologyEnum.Alphabet, TechnologyEnum.None),
				new TechnologyDefinition(TechnologyEnum.Currency, "Currency", TechnologyEnum.BronzeWorking, TechnologyEnum.None),
				new TechnologyDefinition(TechnologyEnum.AtomicTheory, "Atomic Theory", TechnologyEnum.TheoryOfGravity, TechnologyEnum.Physics),
				new TechnologyDefinition(TechnologyEnum.Democracy, "Democracy", TechnologyEnum.Philosophy, TechnologyEnum.Literacy),
				new TechnologyDefinition(TechnologyEnum.Monarchy, "Monarchy", TechnologyEnum.CeremonialBurial, TechnologyEnum.CodeOfLaws),
				new TechnologyDefinition(TechnologyEnum.Astronomy, "Astronomy", TechnologyEnum.Mysticism, TechnologyEnum.Mathematics),
				new TechnologyDefinition(TechnologyEnum.Mapmaking, "MapMaking", TechnologyEnum.Alphabet, TechnologyEnum.None),
				new TechnologyDefinition(TechnologyEnum.Navigation, "Navigation", TechnologyEnum.Mapmaking, TechnologyEnum.Astronomy),
				new TechnologyDefinition(TechnologyEnum.Mathematics, "Mathematics", TechnologyEnum.Alphabet, TechnologyEnum.Masonry),
				new TechnologyDefinition(TechnologyEnum.Medicine, "Medicine", TechnologyEnum.Philosophy, TechnologyEnum.Trade),
				new TechnologyDefinition(TechnologyEnum.Physics, "Physics", TechnologyEnum.Mathematics, TechnologyEnum.Navigation),
				new TechnologyDefinition(TechnologyEnum.Engineering, "Engineering", TechnologyEnum.TheWheel, TechnologyEnum.Construction),
				new TechnologyDefinition(TechnologyEnum.University, "University", TechnologyEnum.Mathematics, TechnologyEnum.Philosophy),
				new TechnologyDefinition(TechnologyEnum.Magnetism, "Magnetism", TechnologyEnum.Navigation, TechnologyEnum.Physics),
				new TechnologyDefinition(TechnologyEnum.Electronics, "Electronics", TechnologyEnum.Engineering, TechnologyEnum.Electricity),
				new TechnologyDefinition(TechnologyEnum.Masonry, "Masonry", TechnologyEnum.None, TechnologyEnum.None),
				new TechnologyDefinition(TechnologyEnum.BronzeWorking, "Bronze Working", TechnologyEnum.None, TechnologyEnum.None),
				new TechnologyDefinition(TechnologyEnum.IronWorking, "Iron Working", TechnologyEnum.BronzeWorking, TechnologyEnum.None),
				new TechnologyDefinition(TechnologyEnum.BridgeBuilding, "Bridge Building", TechnologyEnum.IronWorking, TechnologyEnum.Construction),
				new TechnologyDefinition(TechnologyEnum.Invention, "Invention", TechnologyEnum.Engineering, TechnologyEnum.Literacy),
				new TechnologyDefinition(TechnologyEnum.Computers, "Computers", TechnologyEnum.Mathematics, TechnologyEnum.Electronics),
				new TechnologyDefinition(TechnologyEnum.Writing, "Writing", TechnologyEnum.Alphabet, TechnologyEnum.None),
				new TechnologyDefinition(TechnologyEnum.SteamEngine, "Steam Engine", TechnologyEnum.Physics, TechnologyEnum.Invention),
				new TechnologyDefinition(TechnologyEnum.Trade, "Trade", TechnologyEnum.Currency, TechnologyEnum.CodeOfLaws),
				new TechnologyDefinition(TechnologyEnum.CeremonialBurial, "Ceremonial Burial", TechnologyEnum.None, TechnologyEnum.None),
				new TechnologyDefinition(TechnologyEnum.Mysticism, "Mysticism", TechnologyEnum.CeremonialBurial, TechnologyEnum.None),
				new TechnologyDefinition(TechnologyEnum.NuclearFission, "Nuclear Fission", TechnologyEnum.MassProduction, TechnologyEnum.AtomicTheory),
				new TechnologyDefinition(TechnologyEnum.Philosophy, "Philosophy", TechnologyEnum.Mysticism, TechnologyEnum.Literacy),
				new TechnologyDefinition(TechnologyEnum.Religion, "Religion", TechnologyEnum.Philosophy, TechnologyEnum.Writing),
				new TechnologyDefinition(TechnologyEnum.Literacy, "Literacy", TechnologyEnum.Writing, TechnologyEnum.CodeOfLaws),
				new TechnologyDefinition(TechnologyEnum.HorsebackRiding, "Horseback Riding", TechnologyEnum.None, TechnologyEnum.None),
				new TechnologyDefinition(TechnologyEnum.Feudalism, "Feudalism", TechnologyEnum.Masonry, TechnologyEnum.Monarchy),
				new TechnologyDefinition(TechnologyEnum.TheWheel, "The Wheel", TechnologyEnum.None, TechnologyEnum.None),
				new TechnologyDefinition(TechnologyEnum.Gunpowder, "Gunpowder", TechnologyEnum.Invention, TechnologyEnum.IronWorking),
				new TechnologyDefinition(TechnologyEnum.Industrialization, "Industrialization", TechnologyEnum.Railroad, TechnologyEnum.Banking),
				new TechnologyDefinition(TechnologyEnum.Chemistry, "Chemistry", TechnologyEnum.University, TechnologyEnum.Medicine),
				new TechnologyDefinition(TechnologyEnum.Combustion, "Combustion", TechnologyEnum.Refining, TechnologyEnum.Explosives),
				new TechnologyDefinition(TechnologyEnum.Flight, "Flight", TechnologyEnum.Combustion, TechnologyEnum.Physics),
				new TechnologyDefinition(TechnologyEnum.AdvancedFlight, "Advanced Flight", TechnologyEnum.Flight, TechnologyEnum.Electricity),
				new TechnologyDefinition(TechnologyEnum.SpaceFlight, "Space Flight", TechnologyEnum.Computers, TechnologyEnum.Rocketry),
				new TechnologyDefinition(TechnologyEnum.MassProduction, "Mass Production", TechnologyEnum.Automobile, TechnologyEnum.TheCorporation),
				new TechnologyDefinition(TechnologyEnum.Pottery, "Pottery", TechnologyEnum.None, TechnologyEnum.None),
				new TechnologyDefinition(TechnologyEnum.Communism, "Communism", TechnologyEnum.Philosophy, TechnologyEnum.Industrialization),
				new TechnologyDefinition(TechnologyEnum.TheRepublic, "The Republic", TechnologyEnum.CodeOfLaws, TechnologyEnum.Literacy),
				new TechnologyDefinition(TechnologyEnum.Construction, "Construction", TechnologyEnum.Masonry, TechnologyEnum.Currency),
				new TechnologyDefinition(TechnologyEnum.Rocketry, "Rocketry", TechnologyEnum.AdvancedFlight, TechnologyEnum.Electronics),
				new TechnologyDefinition(TechnologyEnum.TheCorporation, "The Corporation", TechnologyEnum.Banking, TechnologyEnum.Industrialization),
				new TechnologyDefinition(TechnologyEnum.Metallurgy, "Metallurgy", TechnologyEnum.Gunpowder, TechnologyEnum.University),
				new TechnologyDefinition(TechnologyEnum.Railroad, "RailRoad", TechnologyEnum.SteamEngine, TechnologyEnum.BridgeBuilding),
				new TechnologyDefinition(TechnologyEnum.NuclearPower, "Nuclear Power", TechnologyEnum.NuclearFission, TechnologyEnum.Electronics),
				new TechnologyDefinition(TechnologyEnum.TheoryOfGravity, "Theory of Gravity", TechnologyEnum.Astronomy, TechnologyEnum.University),
				new TechnologyDefinition(TechnologyEnum.Steel, "Steel", TechnologyEnum.Metallurgy, TechnologyEnum.Industrialization),
				new TechnologyDefinition(TechnologyEnum.Banking, "Banking", TechnologyEnum.Trade, TechnologyEnum.TheRepublic),
				new TechnologyDefinition(TechnologyEnum.Electricity, "Electricity", TechnologyEnum.Metallurgy, TechnologyEnum.Magnetism),
				new TechnologyDefinition(TechnologyEnum.Refining, "Refining", TechnologyEnum.Chemistry, TechnologyEnum.TheCorporation),
				new TechnologyDefinition(TechnologyEnum.Explosives, "Explosives", TechnologyEnum.Gunpowder, TechnologyEnum.Chemistry),
				new TechnologyDefinition(TechnologyEnum.Superconductor, "SuperConductor", TechnologyEnum.Plastics, TechnologyEnum.MassProduction),
				new TechnologyDefinition(TechnologyEnum.Automobile, "Automobile", TechnologyEnum.Combustion, TechnologyEnum.Steel),
				new TechnologyDefinition(TechnologyEnum.GeneticEngineering, "Genetic Engineering", TechnologyEnum.Medicine, TechnologyEnum.TheCorporation),
				new TechnologyDefinition(TechnologyEnum.Plastics, "Plastics", TechnologyEnum.Refining, TechnologyEnum.SpaceFlight),
				new TechnologyDefinition(TechnologyEnum.Recycling, "Recycling", TechnologyEnum.MassProduction, TechnologyEnum.Democracy),
				new TechnologyDefinition(TechnologyEnum.Chivalry, "Chivalry", TechnologyEnum.Feudalism, TechnologyEnum.HorsebackRiding),
				new TechnologyDefinition(TechnologyEnum.Robotics, "Robotics", TechnologyEnum.Plastics, TechnologyEnum.Computers),
				new TechnologyDefinition(TechnologyEnum.Conscription, "Conscription", TechnologyEnum.TheRepublic, TechnologyEnum.Explosives),
				new TechnologyDefinition(TechnologyEnum.LaborUnion, "Labor Union", TechnologyEnum.MassProduction, TechnologyEnum.Communism),
				new TechnologyDefinition(TechnologyEnum.FusionPower, "Fusion Power", TechnologyEnum.NuclearPower, TechnologyEnum.Superconductor),
				new TechnologyDefinition(TechnologyEnum.FutureTechnology1, "1", TechnologyEnum.NewFutureTechnology, TechnologyEnum.NewFutureTechnology),
				new TechnologyDefinition(TechnologyEnum.FutureTechnology2, "2", TechnologyEnum.NewFutureTechnology, TechnologyEnum.NewFutureTechnology),
				new TechnologyDefinition(TechnologyEnum.FutureTechnology3, "3", TechnologyEnum.NewFutureTechnology, TechnologyEnum.NewFutureTechnology),
				new TechnologyDefinition(TechnologyEnum.FutureTechnology4, "4", TechnologyEnum.NewFutureTechnology, TechnologyEnum.NewFutureTechnology),
				new TechnologyDefinition(TechnologyEnum.FutureTechnology5, "Future Tech.", TechnologyEnum.NewFutureTechnology, TechnologyEnum.NewFutureTechnology)};

		// Map
		public ushort[,] MapVisibility = new ushort[80, 50];
		public short PollutedSquareCount = 0;
		public short PollutionEffectLevel = 0;
		public short GlobalWarmingCount = 0;

		// Replay data
		public short ReplayDataLength = 0;
		public byte[] ReplayData = new byte[4096];

		// Unused GoTo data
		public byte[] LandPathfinding = new byte[260];

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

		// Unit definitions
		private UnitDefinition[] aUnitDefinitions = new UnitDefinition[] {
			new UnitDefinition(UnitEnum.Settlers, "Settlers", TechnologyEnum.NewFutureTechnology, 0, 1, 0, 0, 1, 4, 0, 0, 0, TechnologyEnum.None),	// 0
			new UnitDefinition(UnitEnum.Militia, "Militia", TechnologyEnum.Gunpowder, 0, 1, 0, 1, 1, 1, 0, 0, 2, TechnologyEnum.None),	// 1
			new UnitDefinition(UnitEnum.Phalanx, "Phalanx", TechnologyEnum.Gunpowder, 0, 1, 0, 1, 2, 2, 0, 0, 2, TechnologyEnum.BronzeWorking),	// 2
			new UnitDefinition(UnitEnum.Legion, "Legion", TechnologyEnum.Conscription, 0, 1, 0, 3, 1, 2, 0, 0, 1, TechnologyEnum.IronWorking),	// 3
			new UnitDefinition(UnitEnum.Musketeers, "Musketeers", TechnologyEnum.Conscription, 0, 1, 0, 2, 3, 3, 0, 0, 2, TechnologyEnum.Gunpowder),	// 4
			new UnitDefinition(UnitEnum.Riflemen, "Riflemen", TechnologyEnum.NewFutureTechnology, 0, 1, 0, 3, 5, 3, 0, 0, 2, TechnologyEnum.Conscription),	// 5
			new UnitDefinition(UnitEnum.Cavalry, "Cavalry", TechnologyEnum.Conscription, 0, 2, 0, 2, 1, 2, 0, 0, 1, TechnologyEnum.HorsebackRiding),	// 6
			new UnitDefinition(UnitEnum.Knights, "Knights", TechnologyEnum.Automobile, 0, 2, 0, 4, 2, 4, 0, 0, 1, TechnologyEnum.Chivalry),	// 7
			new UnitDefinition(UnitEnum.Catapult, "Catapult", TechnologyEnum.Metallurgy, 0, 1, 0, 6, 1, 4, 0, 0, 1, TechnologyEnum.Mathematics),	// 8
			new UnitDefinition(UnitEnum.Cannon, "Cannon", TechnologyEnum.Robotics, 0, 1, 0, 8, 1, 4, 0, 0, 1, TechnologyEnum.Metallurgy),	// 9
			new UnitDefinition(UnitEnum.Chariot, "Chariot", TechnologyEnum.Chivalry, 0, 2, 0, 4, 1, 4, 0, 0, 1, TechnologyEnum.TheWheel),	// 10
			new UnitDefinition(UnitEnum.Armor, "Armor", TechnologyEnum.NewFutureTechnology, 0, 3, 0, 10, 5, 8, 0, 0, 1, TechnologyEnum.Automobile),	// 11
			new UnitDefinition(UnitEnum.MechanicInfantry, "Mech. Inf.", TechnologyEnum.NewFutureTechnology, 0, 3, 0, 6, 6, 5, 0, 0, 2, TechnologyEnum.LaborUnion),	// 12
			new UnitDefinition(UnitEnum.Artillery, "Artillery", TechnologyEnum.NewFutureTechnology, 0, 2, 0, 12, 2, 6, 0, 0, 1, TechnologyEnum.Robotics),	// 13
			new UnitDefinition(UnitEnum.Fighter, "Fighter", TechnologyEnum.NewFutureTechnology, 1, 10, 1, 4, 2, 6, 2, 0, 4, TechnologyEnum.Flight),	// 14
			new UnitDefinition(UnitEnum.Bomber, "Bomber", TechnologyEnum.NewFutureTechnology, 1, 8, 2, 12, 1, 12, 2, 0, 1, TechnologyEnum.AdvancedFlight),	// 15
			new UnitDefinition(UnitEnum.Trireme, "Trireme", TechnologyEnum.Navigation, 2, 3, 0, 1, 0, 4, 0, 2, 5, TechnologyEnum.Mapmaking),	// 16
			new UnitDefinition(UnitEnum.Sail, "Sail", TechnologyEnum.Magnetism, 2, 3, 0, 1, 1, 4, 0, 3, 5, TechnologyEnum.Navigation),	// 17
			new UnitDefinition(UnitEnum.Frigate, "Frigate", TechnologyEnum.Industrialization, 2, 3, 0, 2, 2, 4, 0, 4, 5, TechnologyEnum.Magnetism),	// 18
			new UnitDefinition(UnitEnum.Ironclad, "Ironclad", TechnologyEnum.Combustion, 2, 4, 0, 4, 4, 6, 0, 0, 3, TechnologyEnum.SteamEngine),	// 19
			new UnitDefinition(UnitEnum.Cruiser, "Cruiser", TechnologyEnum.NewFutureTechnology, 2, 6, 0, 6, 6, 8, 3, 0, 3, TechnologyEnum.Combustion),	// 20
			new UnitDefinition(UnitEnum.Battleship, "Battleship", TechnologyEnum.NewFutureTechnology, 2, 4, 0, 18, 12, 16, 3, 0, 3, TechnologyEnum.Steel),	// 21
			new UnitDefinition(UnitEnum.Submarine, "Submarine", TechnologyEnum.NewFutureTechnology, 2, 3, 0, 8, 2, 5, 3, 0, 3, TechnologyEnum.MassProduction),	// 22
			new UnitDefinition(UnitEnum.Carrier, "Carrier", TechnologyEnum.NewFutureTechnology, 2, 5, 0, 1, 12, 16, 3, 0, 3, TechnologyEnum.AdvancedFlight),	// 23
			new UnitDefinition(UnitEnum.Transport, "Transport", TechnologyEnum.NewFutureTechnology, 2, 4, 0, 0, 3, 5, 0, 8, 5, TechnologyEnum.Industrialization),	// 24
			new UnitDefinition(UnitEnum.Nuclear, "Nuclear", TechnologyEnum.NewFutureTechnology, 1, 16, 1, 99, 0, 16, 0, 0, 1, TechnologyEnum.Rocketry),	// 25
			new UnitDefinition(UnitEnum.Diplomat, "Diplomat", TechnologyEnum.NewFutureTechnology, 0, 2, 0, 0, 0, 3, 0, 0, 6, TechnologyEnum.Writing),	// 26
			new UnitDefinition(UnitEnum.Caravan, "Caravan", TechnologyEnum.NewFutureTechnology, 0, 1, 0, 0, 1, 5, 0, 0, 6, TechnologyEnum.Trade)}; // 27

		private BuildingDefinition[] aBuildingDefinitions = new BuildingDefinition[]{
			new BuildingDefinition(0, "NONE", 8, 0, TechnologyEnum.None),
			new BuildingDefinition(1, "Palace", 20, 5, TechnologyEnum.Masonry),
			new BuildingDefinition(2, "Barracks", 4, 0, TechnologyEnum.None),
			new BuildingDefinition(3, "Granary", 6, 1, TechnologyEnum.Pottery),
			new BuildingDefinition(4, "Temple", 4, 1, TechnologyEnum.CeremonialBurial),
			new BuildingDefinition(5, "MarketPlace", 8, 1, TechnologyEnum.Currency),
			new BuildingDefinition(6, "Library", 8, 1, TechnologyEnum.Writing),
			new BuildingDefinition(7, "Courthouse", 8, 1, TechnologyEnum.CodeOfLaws),
			new BuildingDefinition(8, "City Walls", 12, 2, TechnologyEnum.Masonry),
			new BuildingDefinition(9, "Aqueduct", 12, 2, TechnologyEnum.Construction),
			new BuildingDefinition(10, "Bank", 12, 3, TechnologyEnum.Banking),
			new BuildingDefinition(11, "Cathedral", 16, 3, TechnologyEnum.Religion),
			new BuildingDefinition(12, "University", 16, 3, TechnologyEnum.University),
			new BuildingDefinition(13, "Mass Transit", 16, 4, TechnologyEnum.MassProduction),
			new BuildingDefinition(14, "Colosseum", 10, 4, TechnologyEnum.Construction),
			new BuildingDefinition(15, "Factory", 20, 4, TechnologyEnum.Industrialization),
			new BuildingDefinition(16, "Mfg. Plant", 32, 6, TechnologyEnum.Robotics),
			new BuildingDefinition(17, "SDI Defense", 20, 4, TechnologyEnum.Superconductor),
			new BuildingDefinition(18, "Recycling Cntr.", 20, 2, TechnologyEnum.Recycling),
			new BuildingDefinition(19, "Power Plant", 16, 4, TechnologyEnum.Refining),
			new BuildingDefinition(20, "Hydro Plant", 24, 4, TechnologyEnum.Electronics),
			new BuildingDefinition(21, "Nuclear Plant", 16, 2, TechnologyEnum.NuclearPower),
			new BuildingDefinition(22, "SS Structural", 8, 0, TechnologyEnum.SpaceFlight),
			new BuildingDefinition(23, "SS Component", 16, 0, TechnologyEnum.Plastics),
			new BuildingDefinition(24, "SS Module", 32, 0, TechnologyEnum.Robotics),
			new BuildingDefinition(25, "Pyramids", 30, 0, TechnologyEnum.Masonry),
			new BuildingDefinition(26, "Hanging Gardens", 30, 0, TechnologyEnum.Pottery),
			new BuildingDefinition(27, "Colossus", 20, 0, TechnologyEnum.BronzeWorking),
			new BuildingDefinition(28, "Lighthouse", 20, 0, TechnologyEnum.Mapmaking),
			new BuildingDefinition(29, "Great Library", 30, 0, TechnologyEnum.Literacy),
			new BuildingDefinition(30, "Oracle", 30, 0, TechnologyEnum.Mysticism),
			new BuildingDefinition(31, "Great Wall", 30, 0, TechnologyEnum.Masonry),
			new BuildingDefinition(32, "Magellan's Expedition", 40, 0, TechnologyEnum.Navigation),
			new BuildingDefinition(33, "Michelangelo's Chapel", 30, 0, TechnologyEnum.Religion),
			new BuildingDefinition(34, "Copernicus' Observatory", 30, 0, TechnologyEnum.Astronomy),
			new BuildingDefinition(35, "Shakespeare's Theatre", 40, 0, TechnologyEnum.Medicine),
			new BuildingDefinition(36, "Isaac Newton's College", 40, 0, TechnologyEnum.TheoryOfGravity),
			new BuildingDefinition(37, "J.S.Bach's Cathedral", 40, 0, TechnologyEnum.Religion),
			new BuildingDefinition(38, "Darwin's Voyage", 30, 0, TechnologyEnum.Railroad),
			new BuildingDefinition(39, "Hoover Dam", 60, 0, TechnologyEnum.Electronics),
			new BuildingDefinition(40, "Women's Suffrage", 60, 0, TechnologyEnum.Industrialization),
			new BuildingDefinition(41, "Manhattan Project", 60, 0, TechnologyEnum.NuclearFission),
			new BuildingDefinition(42, "United Nations", 60, 0, TechnologyEnum.Communism),
			new BuildingDefinition(43, "Apollo Program", 60, 0, TechnologyEnum.SpaceFlight),
			new BuildingDefinition(44, "SETI Program", 60, 0, TechnologyEnum.Computers),
			new BuildingDefinition(45, "Cure for Cancer", 60, 0, TechnologyEnum.GeneticEngineering) };

		public GameState()
		{
			for (int i = 0; i < this.Players.Length; i++)
			{
				this.Players[i] = new Player();
			}

			for (int i = 0; i < this.PerContinentSizeAndPerOceanSize.Length; i++)
			{
				this.PerContinentSizeAndPerOceanSize[i] = 0;
			}

			for (int i = 0; i < 64; i++)
			{
				this.Continents[i] = new Continent();
			}

			for (int i = 0; i < 64; i++)
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
				this.Cities[i] = new City();
			}

			for (int i = 0; i < this.CityPositions.Length; i++)
			{
				this.CityPositions[i] = new GPoint(0, 0);
			}

			for (int i = 0; i < this.WonderCityID.Length; i++)
			{
				this.WonderCityID[i] = 0;
			}

			for (int i = 0; i < this.TechnologyFirstDiscoveredBy.Length; i++)
			{
				this.TechnologyFirstDiscoveredBy[i] = 0;
			}

			for (int i = 0; i < 80; i++)
			{
				for (int j = 0; j < 50; j++)
					this.MapVisibility[i, j] = 0;
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

		public SpaceshipCell[] SpaceshipCells
		{
			get => this.aSpaceshipCells;
		}

		public UnitDefinition[] UnitDefinitions
		{
			get => this.aUnitDefinitions;
		}

		public BuildingDefinition[] BuildingDefinitions
		{
			get => this.aBuildingDefinitions;
		}

		public TechnologyDefinition[] TechnologyDefinitions
		{
			get => this.aTechnologyDefinitions;
		}
	}
}
