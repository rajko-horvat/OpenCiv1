using OpenCiv1.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class CivStaticData
	{
		public readonly GPoint[] CityOffsets = new GPoint[] {
			new GPoint(0, -1), new GPoint(1, 0), new GPoint(0, 1), new GPoint(-1, 0),
			new GPoint(1, -1), new GPoint(1, 1), new GPoint(-1, 1), new GPoint(-1, -1),
			new GPoint(0, -2), new GPoint(2, 0), new GPoint(0, 2), new GPoint(-2, 0),
			new GPoint(-1, -2), new GPoint(1, -2), new GPoint(2, -1), new GPoint(2, 1), new GPoint(1, 2), new GPoint(-1, 2), new GPoint(-2, 1), new GPoint(-2, -1),
			new GPoint(0, 0) };

		public readonly GPoint[] MoveOffsets = new GPoint[] {
			new GPoint(0, 0), new GPoint(0, -1), new GPoint(1, -1),
			new GPoint(1, 0), new GPoint(1, 1), new GPoint(0, 1),
			new GPoint(-1, 1), new GPoint(-1, 0), new GPoint(-1, -1),
			new GPoint(0, -2), new GPoint(1, -2), new GPoint(2, -1),
			new GPoint(2, 0), new GPoint(2, 1), new GPoint(1, 2),
			new GPoint(0, 2), new GPoint(-1, 2), new GPoint(-2, 1),
			new GPoint(-2, 0), new GPoint(-2, -1), new GPoint(-1, -2),
			new GPoint(2, 2), new GPoint(2, -2), new GPoint(-2, -2),
			new GPoint(-2, 2), new GPoint(0, -3), new GPoint(1, -3),
			new GPoint(2, -3), new GPoint(3, -2), new GPoint(3, -1),
			new GPoint(3, 0), new GPoint(3, 1), new GPoint(3, 2),
			new GPoint(2, 3), new GPoint(1, 3), new GPoint(0, 3),
			new GPoint(-1, 3), new GPoint(-2, 3), new GPoint(-3, 2),
			new GPoint(-3, 1), new GPoint(-3, 0), new GPoint(-3, -1),
			new GPoint(-3, -2), new GPoint(-2, -3), new GPoint(-1, -3),
			new GPoint(3, 3), new GPoint(3, -3), new GPoint(-3, 3),
			new GPoint(-3, -3)};

		// Nations
		public readonly NationDefinition[] Nations = new NationDefinition[] {
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

		// Terrains
		public readonly TerrainDefinition[] Terrains = new TerrainDefinition[]{
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

		public readonly TerrainMultiplierDefinition[] TerrainMultipliers = new TerrainMultiplierDefinition[] {
			new TerrainMultiplierDefinition(0, -2, 5, -2, 5, 0, 0),
			new TerrainMultiplierDefinition(1, -2, 5, 2, 15, 1, 1),
			new TerrainMultiplierDefinition(2, -2, 5, 2, 10, 0, 1),
			new TerrainMultiplierDefinition(3, 6, 5, -1, 5, 0, 0),
			new TerrainMultiplierDefinition(4, -2, 10, -4, 10, 1, 1),
			new TerrainMultiplierDefinition(5, -1, 0, -2, 10, 0, 0),
			new TerrainMultiplierDefinition(6, -1, 0, -1, 0, 0, 0),
			new TerrainMultiplierDefinition(7, -1, 0, -1, 0, 0, 0),
			new TerrainMultiplierDefinition(8, 10, 15, 2, 15, 0, 0),
			new TerrainMultiplierDefinition(9, 10, 15, 2, 15, 0, 0),
			new TerrainMultiplierDefinition(10, -1, 0, -1, 0, 0, 0),
			new TerrainMultiplierDefinition(11, -2, 5, -1, 0, 0, 1) };

		// Technology
		public readonly TechnologyDefinition[] Technologies = new TechnologyDefinition[] {
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

		// Units
		public readonly UnitDefinition[] UnitDefinitions = new UnitDefinition[] {
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

		// Improvements
		public readonly ImprovementDefinition[] Improvements = new ImprovementDefinition[] {
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

		// Wonders
		public readonly ImprovementDefinition[] Wonders = new ImprovementDefinition[] {
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

		/// <summary>
		/// Returns the Improvement or Wonder, depending on the index (0 - 24 are city improvements, 25 - are world Wonders)
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public ImprovementDefinition ImprovementDefinitions(int index)
		{
			if (index < 25)
			{
				return Improvements[index];
			}
			else
			{
				return Wonders[index - 24];
			}
		}
	}
}
