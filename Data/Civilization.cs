using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Documents;
using System.Windows;

namespace OpenCiv1.Data
{
	public class Civilization
	{
		public string Name;
		public string Nationality;
		public string LeaderName;
		public short LeaderIdentity;
		public short Coins;
		public short GovernmentType;
		public short TaxRate;
		public short[] PerCivilizationDiplomacyFlags = new short[8];
		public short MilitaryPower;
		public short ContactPlayerCountdown;
		public short XStart;
		public short CityCount;
		public short TotalCitySize;
		public short LandCount;
		public short[] PerContinentCityCount = new short[16];
		public short[] PerContinentStrategy = new short[16];
		public short[] PerContinentAttack = new short[16];
		public short[] PerContinentDefense = new short[16];
		public short Ranking;
		public ushort CumulativeEpicRanking;
		public short Score;

		// Technology
		public short ScienceRate;
		public ushort CurrentResearchID = 0;
		public short ResearchProgress;
		public ushort DiscoveredTechnologyCount;
		public short[] DiscoveredTechnologyFlags = new short[5];
		public sbyte[] TechnologyAcquiredFrom = new sbyte[72];

		// Units
		public short UnitCount;
		public short SettlerCount;
		public short[] ActiveUnits = new short[28];
		public ushort[] UnitsDestroyed = new ushort[8];
		public Unit[] Units = new Unit[128];
		public short[] UnitsInProduction = new short[28];
		public short[] LostUnits = new short[28];

		// Strategic locations
		public StrategicLocation[] StrategicLocations = new StrategicLocation[16];

		// Spaceship
		public sbyte[] SpaceshipData = new sbyte[180];
		public short SpaceshipPopulation;
		public short SpaceshipETAYear;
		public short SpaceshipLaunchYear;

	}
}
