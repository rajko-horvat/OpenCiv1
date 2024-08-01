﻿using System;
using IRB.Collections.Generic;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class CivState
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

		// Nations
		private NationDefinition[] aNations = new NationDefinition[] {
			new NationDefinition(0, "Attila", "", "Barbarian", 0, 0, 0, 36, 36,
				new string[] {"Mecca", "Naples", "Sidon", "Tyre", "Tarsus", "Issus", "Cunaxa", "Cremona", "Cannae", "Capua",
					"Turin", "Genoa", "Utica", "Crete", "Damascus", "Verona" }),
			new NationDefinition(1, "Caesar", "", "Roman", 0, 1, 1, 24, 10, 
				new string[] {"Rome", "Caesarea", "Carthage", "Nicopolis", "Byzantium", "Brundisium", "Syracuse", "Antioch", "Palmyra", "Cyrene",
					"Gordion", "Tyrus", "Jerusalem", "Seleucia", "Ravenna", "Artaxata" }),
			new NationDefinition(2, "Hammurabi", "", "Babylonian", -1, -1, 1, 28, 14,
				new string[] {"Babylon", "Sumer", "Uruk", "Nineveh", "Ashur", "Ellipi", "Akkad", "Eridu", "Kish", "Nippur",
					"Shuruppak", "Zariqum", "Izibia", "Nimrud", "Arbela", "Zamua" }),
			new NationDefinition(3, "Frederick", "Germans", "German", 1, -1, 1, 32, 18,
				new string[] {"Berlin", "Leipzig", "Hamburg", "Bremen", "Frankfurt", "Bonn", "Nuremberg", "Cologne", "Hannover", "Munich",
					"Stuttgart", "Heidelburg", "Salzburg", "Konigsberg", "Dortmund", "Brandenburg" }),
			new NationDefinition(4, "Ramesses", "", "Egyptian", 0, 0, 1, 21, 7,
				new string[] {"Thebes", "Memphis", "Oryx", "Heliopolis", "Gaza", "Alexandria", "Byblos", "Cairo", "Coptos", "Edfu",
					"Pithom", "Busiris", "Athribis", "Mendes", "Tanis", "Abydos" }),
			new NationDefinition(5, "Abe Lincoln", "", "American", -1, 0, 1, 19, 5,
				new string[] {"Washington", "New York", "Boston", "Philadelphia", "Atlanta", "Chicago", "Buffalo", "St.Louis", "Detroit", "New Orleans",
					"Baltimore", "Denver", "Cincinnati", "Dallas", "Los Angeles", "Las Vegas" }),
			new NationDefinition(6, "Alexander", "", "Greek", 0, 1, -1, 26, 12,
				new string[] {"Athens", "Sparta", "Corinth", "Delphi", "Eretria", "Pharsalos", "Argos", "Mycenae", "Herakleia", "Antioch",
					"Ephesos", "Rhodes", "Knossos", "Troy", "Pergamon", "Miletos" }),
			new NationDefinition(7, "M.Gandhi", "", "Indian", -1, -1, 0, 31, 17,
				new string[] {"Delhi", "Bombay", "Madras", "Bangalore", "Calcutta", "Lahore", "Karachi", "Kolhapur", "Jaipur", "Hyderabad",
					"Bengal", "Chittagong", "Punjab", "Dacca", "Indus", "Ganges" }),
			new NationDefinition(8, "", "", "", 0, 0, 0, 36, 36,
				new string[] {"Salamis", "Lisbon", "Hamburg", "Prague", "Salzburg", "Bergen", "Venice", "Milan", "Ghent", "Pisa",
					"Cordoba", "Seville", "Dublin", "Toronto", "Melbourne", "Sydney" }),
			new NationDefinition(9, "Stalin", "", "Russian", 1, 0, -1, 25, 11,
				new string[] {"Moscow", "Leningrad", "Kiev", "Minsk", "Smolensk", "Odessa", "Sevastopol", "Tblisi", "Sverdlovsk", "Yakutsk",
					"Vladivostok", "Novograd", "Krasnoyarsk", "Riga", "Rostov", "Astrakhan" }),
			new NationDefinition(10, "Shaka", "", "Zulu", 1, 0, 0, 22, 8,
				new string[] {"Zimbabwe", "Ulundi", "Bapedi", "Hlobane", "Isandhlwana", "Intombe", "Mpondo", "Ngome", "Swazi", "Tugela",
					"Umtata", "Umfolozi", "Ibabanago", "Isipezi", "Amatikulu", "Zunguin" }),
			new NationDefinition(11, "Napoleon", "French", "French", 1, 1, 1, 23, 9,
				new string[] {"Paris", "Orleans", "Lyons", "Tours", "Chartres", "Bordeaux", "Rouen", "Avignon", "Marseilles", "Grenoble",
					"Dijon", "Amiens", "Cherbourg", "Poitiers", "Toulouse", "Bayonne" }),
			new NationDefinition(12, "Montezuma", "", "Aztec", 0, -1, 1, 20, 6,
				new string[] {"Tenochtitlan", "Chiauhtia", "Chapultepec", "Coatepec", "Ayotzinco", "Itzapalapa", "Iztapam", "Mitxcoac", "Tacubaya", "Tecamac",
					"Tepezinco", "Ticoman", "Tlaxcala", "Xaltocan", "Xicalango", "Zumpanco" }),
			new NationDefinition(13, "Mao Tse Tung", "Chinese", "Chinese", 0, 0, 1, 29, 15,
				new string[] {"Peking", "Shanghai", "Canton", "Nanking", "Tsingtao", "Hangchow", "Tientsin", "Tatung", "Macao", "Anyang",
					"Shantung", "Chinan", "Kaifeng", "Ningpo", "Paoting", "Yangchow" }),
			new NationDefinition(14, "Elizabeth I", "English", "English", 0, 1, 0, 27, 13,
				new string[] {"London", "Coventry", "Birmingham", "Dover", "Nottingham", "York", "Liverpool", "Brighton", "Oxford", "Reading",
					"Exeter", "Cambridge", "Hastings", "Canterbury", "Banbury", "Newcastle" }),
			new NationDefinition(15, "Genghis Khan", "", "Mongol", 1, 1, -1, 30, 16,
				new string[] {"Samarkand", "Bokhara", "Nishapur", "Karakorum", "Kashgar", "Tabriz", "Aleppo", "Kabul", "Ormuz", "Basra",
					"Khanbalyk", "Khorasan", "Shangtu", "Kazan", "Quinsay", "Kerman" })};

		// Continents
		public short[] PerContinentSizeAndPerOceanSize = new short[128];
		public Continent[] Continents = new Continent[64];
		public Continent[] Oceans = new Continent[64];

		// Terrains
		private TerrainDefinition[] aTerrains = new TerrainDefinition[]{
			new TerrainDefinition(0, "Desert", 1, 2, 0, 1, 0, 1, 14),
			new TerrainDefinition(1, "Plains", 1, 2, 1, 1, 0, 1, 6),
			new TerrainDefinition(2, "Grassland", 1, 2, 2, 1, 0, 1, 10),
			new TerrainDefinition(3, "Forest", 2, 3, 1, 2, 0, 2, 2),
			new TerrainDefinition(4, "Hills", 2, 4, 1, 0, 0, 2, 12),
			new TerrainDefinition(5, "Mountains", 3, 6, 0, 1, 0, 3, 13),
			new TerrainDefinition(6, "Tundra", 1, 2, 1, 0, 0, 0, 7),
			new TerrainDefinition(7, "Arctic", 2, 2, 0, 0, 0, 0, 15),
			new TerrainDefinition(8, "Swamp", 2, 3, 1, 0, 0, 0, 3),
			new TerrainDefinition(9, "Jungle", 2, 3, 1, 0, 0, 0, 11),
			new TerrainDefinition(10, "Ocean", 1, 2, 1, 0, 2, 0, 1),
			new TerrainDefinition(11, "River", 1, 3, 2, 1, 1, 2, 9),
			// Terrain addons
			new TerrainDefinition(12, "Oasis", 1, 2, 3, 1, 0, 1, 14),
			new TerrainDefinition(13, "Horses", 1, 2, 1, 3, 0, 1, 6),
			new TerrainDefinition(14, "Grassland", 1, 2, 2, 1, 0, 1, 10),
			new TerrainDefinition(15, "Game", 2, 3, 3, 2, 0, 2, 2),
			new TerrainDefinition(16, "Coal", 2, 4, 1, 2, 0, 2, 12),
			new TerrainDefinition(17, "Gold", 3, 6, 0, 1, 6, 3, 13),
			new TerrainDefinition(18, "Game", 1, 2, 3, 0, 0, 0, 7),
			new TerrainDefinition(19, "Seals", 2, 2, 2, 0, 0, 0, 15),
			new TerrainDefinition(20, "Oil", 2, 3, 1, 4, 0, 0, 3),
			new TerrainDefinition(21, "Gems", 2, 3, 1, 0, 4, 0, 11),
			new TerrainDefinition(22, "Fish", 1, 2, 3, 0, 2, 0, 1),
			new TerrainDefinition(23, "River", 1, 3, 2, 1, 1, 2, 9)};

		private TerrainMultiplier[] aTerrainMultipliers = new TerrainMultiplier[] {
			new TerrainMultiplier(0, -2, 5, -2, 5, 0, 0),
			new TerrainMultiplier(1, -2, 5, 2, 15, 1, 1),
			new TerrainMultiplier(2, -2, 5, 2, 10, 0, 1),
			new TerrainMultiplier(3, 6, 5, -1, 5, 0, 0),
			new TerrainMultiplier(4, -2, 10, -4, 10, 1, 1),
			new TerrainMultiplier(5, -1, 0, -2, 10, 0, 0),
			new TerrainMultiplier(6, -1, 0, -1, 0, 0, 0),
			new TerrainMultiplier(7, -1, 0, -1, 0, 0, 0),
			new TerrainMultiplier(8, 10, 15, 2, 15, 0, 0),
			new TerrainMultiplier(9, 10, 15, 2, 15, 0, 0),
			new TerrainMultiplier(10, -1, 0, -1, 0, 0, 0),
			new TerrainMultiplier(11, -2, 5, -1, 0, 0, 1) };

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
		public Map Map = new Map(80, 50);

		// Replay data
		public short ReplayDataLength = 0;
		public byte[] ReplayData = new byte[4096];

		// Unused GoTo data
		public byte[,] LandPathfinding = new byte[20, 13];

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
			new UnitDefinition(UnitTypeEnum.Settlers, "Settlers", 4, UnitMovementTypeEnum.Land, 1, 0, 1, 0, 0, 0, 0, TechnologyEnum.None, TechnologyEnum.NewFutureTechnology),	// 0
			new UnitDefinition(UnitTypeEnum.Militia, "Militia", 1, UnitMovementTypeEnum.Land, 1, 1, 1, 0, 0, 0, 2, TechnologyEnum.None, TechnologyEnum.Gunpowder),	// 1
			new UnitDefinition(UnitTypeEnum.Phalanx, "Phalanx", 2, UnitMovementTypeEnum.Land, 1, 1, 2, 0, 0, 0, 2, TechnologyEnum.BronzeWorking, TechnologyEnum.Gunpowder),	// 2
			new UnitDefinition(UnitTypeEnum.Legion, "Legion", 2, UnitMovementTypeEnum.Land, 1, 3, 1, 0, 0, 0, 1, TechnologyEnum.IronWorking, TechnologyEnum.Conscription),	// 3
			new UnitDefinition(UnitTypeEnum.Musketeers, "Musketeers", 3, UnitMovementTypeEnum.Land, 1, 2, 3, 0, 0, 0, 2, TechnologyEnum.Gunpowder, TechnologyEnum.Conscription),	// 4
			new UnitDefinition(UnitTypeEnum.Riflemen, "Riflemen", 3, UnitMovementTypeEnum.Land, 1, 3, 5, 0, 0, 0, 2, TechnologyEnum.Conscription, TechnologyEnum.NewFutureTechnology),	// 5
			new UnitDefinition(UnitTypeEnum.Cavalry, "Cavalry", 2, UnitMovementTypeEnum.Land, 2, 2, 1, 0, 0, 0, 1, TechnologyEnum.HorsebackRiding, TechnologyEnum.Conscription),	// 6
			new UnitDefinition(UnitTypeEnum.Knights, "Knights", 4, UnitMovementTypeEnum.Land, 2, 4, 2, 0, 0, 0, 1, TechnologyEnum.Chivalry, TechnologyEnum.Automobile),	// 7
			new UnitDefinition(UnitTypeEnum.Catapult, "Catapult", 4, UnitMovementTypeEnum.Land, 1, 6, 1, 0, 0, 0, 1, TechnologyEnum.Mathematics, TechnologyEnum.Metallurgy),	// 8
			new UnitDefinition(UnitTypeEnum.Cannon, "Cannon", 4, UnitMovementTypeEnum.Land, 1, 8, 1, 0, 0, 0, 1, TechnologyEnum.Metallurgy, TechnologyEnum.Robotics),	// 9
			new UnitDefinition(UnitTypeEnum.Chariot, "Chariot", 4, UnitMovementTypeEnum.Land, 2, 4, 1, 0, 0, 0, 1, TechnologyEnum.TheWheel, TechnologyEnum.Chivalry),	// 10
			new UnitDefinition(UnitTypeEnum.Armor, "Armor", 8, UnitMovementTypeEnum.Land, 3, 10, 5, 0, 0, 0, 1, TechnologyEnum.Automobile, TechnologyEnum.NewFutureTechnology),	// 11
			new UnitDefinition(UnitTypeEnum.MechanicInfantry, "Mech. Inf.", 5, UnitMovementTypeEnum.Land, 3, 6, 6, 0, 0, 0, 2, TechnologyEnum.LaborUnion, TechnologyEnum.NewFutureTechnology),	// 12
			new UnitDefinition(UnitTypeEnum.Artillery, "Artillery", 6, UnitMovementTypeEnum.Land, 2, 12, 2, 0, 0, 0, 1, TechnologyEnum.Robotics, TechnologyEnum.NewFutureTechnology),	// 13
			new UnitDefinition(UnitTypeEnum.Fighter, "Fighter", 6, UnitMovementTypeEnum.Air, 10, 4, 2, 1, 2, 0, 4, TechnologyEnum.Flight, TechnologyEnum.NewFutureTechnology),	// 14
			new UnitDefinition(UnitTypeEnum.Bomber, "Bomber", 12, UnitMovementTypeEnum.Air, 8, 12, 1, 2, 2, 0, 1, TechnologyEnum.AdvancedFlight, TechnologyEnum.NewFutureTechnology),	// 15
			new UnitDefinition(UnitTypeEnum.Trireme, "Trireme", 4, UnitMovementTypeEnum.Sea, 3, 1, 0, 0, 0, 2, 5, TechnologyEnum.Mapmaking, TechnologyEnum.Navigation),	// 16
			new UnitDefinition(UnitTypeEnum.Sail, "Sail", 4, UnitMovementTypeEnum.Sea, 3, 1, 1, 0, 0, 3, 5, TechnologyEnum.Navigation, TechnologyEnum.Magnetism),	// 17
			new UnitDefinition(UnitTypeEnum.Frigate, "Frigate", 4, UnitMovementTypeEnum.Sea, 3, 2, 2, 0, 0, 4, 5, TechnologyEnum.Magnetism, TechnologyEnum.Industrialization),	// 18
			new UnitDefinition(UnitTypeEnum.Ironclad, "Ironclad", 6, UnitMovementTypeEnum.Sea, 4, 4, 4, 0, 0, 0, 3, TechnologyEnum.SteamEngine, TechnologyEnum.Combustion),	// 19
			new UnitDefinition(UnitTypeEnum.Cruiser, "Cruiser", 8, UnitMovementTypeEnum.Sea, 6, 6, 6, 0, 3, 0, 3, TechnologyEnum.Combustion, TechnologyEnum.NewFutureTechnology),	// 20
			new UnitDefinition(UnitTypeEnum.Battleship, "Battleship", 16, UnitMovementTypeEnum.Sea, 4, 18, 12, 0, 3, 0, 3, TechnologyEnum.Steel, TechnologyEnum.NewFutureTechnology),	// 21
			new UnitDefinition(UnitTypeEnum.Submarine, "Submarine", 5, UnitMovementTypeEnum.Sea, 3, 8, 2, 0, 3, 0, 3, TechnologyEnum.MassProduction, TechnologyEnum.NewFutureTechnology),	// 22
			new UnitDefinition(UnitTypeEnum.Carrier, "Carrier", 16, UnitMovementTypeEnum.Sea, 5, 1, 12, 0, 3, 0, 3, TechnologyEnum.AdvancedFlight, TechnologyEnum.NewFutureTechnology),	// 23
			new UnitDefinition(UnitTypeEnum.Transport, "Transport", 5, UnitMovementTypeEnum.Sea, 4, 0, 3, 0, 0, 8, 5, TechnologyEnum.Industrialization, TechnologyEnum.NewFutureTechnology),	// 24
			new UnitDefinition(UnitTypeEnum.Nuclear, "Nuclear", 16, UnitMovementTypeEnum.Air, 16, 99, 0, 1, 0, 0, 1, TechnologyEnum.Rocketry, TechnologyEnum.NewFutureTechnology),	// 25
			new UnitDefinition(UnitTypeEnum.Diplomat, "Diplomat", 3, UnitMovementTypeEnum.Land, 2, 0, 0, 0, 0, 0, 6, TechnologyEnum.Writing, TechnologyEnum.NewFutureTechnology),	// 26
			new UnitDefinition(UnitTypeEnum.Caravan, "Caravan", 5, UnitMovementTypeEnum.Land, 1, 0, 1, 0, 0, 0, 6, TechnologyEnum.Trade, TechnologyEnum.NewFutureTechnology)}; // 27

		private ImprovementDefinition[] aImprovementDefinitions = new ImprovementDefinition[] {
			new ImprovementDefinition(0, "NONE", 8, 0, TechnologyEnum.None, TechnologyEnum.None),
			new ImprovementDefinition(1, "Palace", 20, 5, TechnologyEnum.Masonry, TechnologyEnum.None),
			new ImprovementDefinition(2, "Barracks", 4, 0, TechnologyEnum.None, TechnologyEnum.None),
			new ImprovementDefinition(3, "Granary", 6, 1, TechnologyEnum.Pottery, TechnologyEnum.None),
			new ImprovementDefinition(4, "Temple", 4, 1, TechnologyEnum.CeremonialBurial, TechnologyEnum.None),
			new ImprovementDefinition(5, "MarketPlace", 8, 1, TechnologyEnum.Currency, TechnologyEnum.None),
			new ImprovementDefinition(6, "Library", 8, 1, TechnologyEnum.Writing, TechnologyEnum.None),
			new ImprovementDefinition(7, "Courthouse", 8, 1, TechnologyEnum.CodeOfLaws, TechnologyEnum.None),
			new ImprovementDefinition(8, "City Walls", 12, 2, TechnologyEnum.Masonry, TechnologyEnum.None),
			new ImprovementDefinition(9, "Aqueduct", 12, 2, TechnologyEnum.Construction, TechnologyEnum.None),
			new ImprovementDefinition(10, "Bank", 12, 3, TechnologyEnum.Banking, TechnologyEnum.None),
			new ImprovementDefinition(11, "Cathedral", 16, 3, TechnologyEnum.Religion, TechnologyEnum.None),
			new ImprovementDefinition(12, "University", 16, 3, TechnologyEnum.University, TechnologyEnum.None),
			new ImprovementDefinition(13, "Mass Transit", 16, 4, TechnologyEnum.MassProduction, TechnologyEnum.None),
			new ImprovementDefinition(14, "Colosseum", 10, 4, TechnologyEnum.Construction, TechnologyEnum.None),
			new ImprovementDefinition(15, "Factory", 20, 4, TechnologyEnum.Industrialization, TechnologyEnum.None),
			new ImprovementDefinition(16, "Mfg. Plant", 32, 6, TechnologyEnum.Robotics, TechnologyEnum.None),
			new ImprovementDefinition(17, "SDI Defense", 20, 4, TechnologyEnum.Superconductor, TechnologyEnum.None),
			new ImprovementDefinition(18, "Recycling Cntr.", 20, 2, TechnologyEnum.Recycling, TechnologyEnum.None),
			new ImprovementDefinition(19, "Power Plant", 16, 4, TechnologyEnum.Refining, TechnologyEnum.None),
			new ImprovementDefinition(20, "Hydro Plant", 24, 4, TechnologyEnum.Electronics, TechnologyEnum.None),
			new ImprovementDefinition(21, "Nuclear Plant", 16, 2, TechnologyEnum.NuclearPower, TechnologyEnum.None),
			new ImprovementDefinition(22, "SS Structural", 8, 0, TechnologyEnum.SpaceFlight, TechnologyEnum.None),
			new ImprovementDefinition(23, "SS Component", 16, 0, TechnologyEnum.Plastics, TechnologyEnum.None),
			new ImprovementDefinition(24, "SS Module", 32, 0, TechnologyEnum.Robotics, TechnologyEnum.None) };

		private ImprovementDefinition[] aWonderDefinitions = new ImprovementDefinition[] {
			new ImprovementDefinition(0, "NONE", 8, 0, TechnologyEnum.None, TechnologyEnum.None),
			new ImprovementDefinition(1, "Pyramids", 30, 0, TechnologyEnum.Masonry, TechnologyEnum.Communism),
			new ImprovementDefinition(2, "Hanging Gardens", 30, 0, TechnologyEnum.Pottery, TechnologyEnum.Invention),
			new ImprovementDefinition(3, "Colossus", 20, 0, TechnologyEnum.BronzeWorking, TechnologyEnum.Electricity),
			new ImprovementDefinition(4, "Lighthouse", 20, 0, TechnologyEnum.Mapmaking, TechnologyEnum.Magnetism),
			new ImprovementDefinition(5, "Great Library", 30, 0, TechnologyEnum.Literacy, TechnologyEnum.University),
			new ImprovementDefinition(6, "Oracle", 30, 0, TechnologyEnum.Mysticism, TechnologyEnum.Religion),
			new ImprovementDefinition(7, "Great Wall", 30, 0, TechnologyEnum.Masonry, TechnologyEnum.Gunpowder),
			new ImprovementDefinition(8, "Magellan's Expedition", 40, 0, TechnologyEnum.Navigation, TechnologyEnum.None),
			new ImprovementDefinition(9, "Michelangelo's Chapel", 30, 0, TechnologyEnum.Religion, TechnologyEnum.Communism),
			new ImprovementDefinition(10, "Copernicus' Observatory", 30, 0, TechnologyEnum.Astronomy, TechnologyEnum.Automobile), // !!! By manual it should obsolete after the development of Automobile
			new ImprovementDefinition(11, "Shakespeare's Theatre", 40, 0, TechnologyEnum.Medicine, TechnologyEnum.Electronics),
			new ImprovementDefinition(12, "Isaac Newton's College", 40, 0, TechnologyEnum.TheoryOfGravity, TechnologyEnum.NuclearFission),
			new ImprovementDefinition(13, "J.S.Bach's Cathedral", 40, 0, TechnologyEnum.Religion, TechnologyEnum.None),
			new ImprovementDefinition(14, "Darwin's Voyage", 30, 0, TechnologyEnum.Railroad, TechnologyEnum.None),
			new ImprovementDefinition(15, "Hoover Dam", 60, 0, TechnologyEnum.Electronics, TechnologyEnum.None),
			new ImprovementDefinition(16, "Women's Suffrage", 60, 0, TechnologyEnum.Industrialization, TechnologyEnum.None),
			new ImprovementDefinition(17, "Manhattan Project", 60, 0, TechnologyEnum.NuclearFission, TechnologyEnum.None),
			new ImprovementDefinition(18, "United Nations", 60, 0, TechnologyEnum.Communism, TechnologyEnum.None),
			new ImprovementDefinition(19, "Apollo Program", 60, 0, TechnologyEnum.SpaceFlight, TechnologyEnum.None),
			new ImprovementDefinition(20, "SETI Program", 60, 0, TechnologyEnum.Computers, TechnologyEnum.None),
			new ImprovementDefinition(21, "Cure for Cancer", 60, 0, TechnologyEnum.GeneticEngineering, TechnologyEnum.None) };

		public CivState()
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
				this.Cities[i] = new City(i);
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

			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < 13; j++)
				{
					this.LandPathfinding[i, j] = 0;
				}
			}
		}

		public SpaceshipCell[] SpaceshipCells
		{
			get => this.aSpaceshipCells;
		}

		public NationDefinition[] Nations
		{
			get => this.aNations;
		}

		public TerrainDefinition[] Terrains
		{
			get => this.aTerrains;
		}

		public TerrainMultiplier[] TerrainMultipliers
		{
			get => this.aTerrainMultipliers;
		}

		public UnitDefinition[] UnitDefinitions
		{
			get => this.aUnitDefinitions;
		}

		/// <summary>
		/// Returns the Improvement or Wonder, depending on the index (0 - 24 are city improvements, 25 - are world Wonders)
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public ImprovementDefinition ImprovementDefinitions(int index)
		{
			if (index < 25)
			{
				return this.aImprovementDefinitions[index];
			}
			else
			{
				return this.aWonderDefinitions[index - 24];
			}
		}

		public ImprovementDefinition[] WonderDefinitions
		{
			get => this.aWonderDefinitions;
		}

		public TechnologyDefinition[] TechnologyDefinitions
		{
			get => this.aTechnologyDefinitions;
		}
	}
}
