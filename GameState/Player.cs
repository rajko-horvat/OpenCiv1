using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCiv1.GameState
{
	public class Player
	{
		public string Name;
		public string Nationality;
		public string LeaderName;
		public short LeaderGraphics;
		public short Coins = 0;
		public short GovernmentType = 0;
		public short TaxRate;
		public short MilitaryPower;
		public short ContactPlayerCountdown;
		public short XStart;
		public short CityCount;
		public short TotalCitySize;
		public short LandCount;

		public short[] PerCivilizationDiplomacyFlags = new short[8];
		public short[] PerContinentCityCount = new short[16];
		public short[] PerContinentStrategy = new short[16];
		public short[] PerContinentAttack = new short[16];
		public short[] PerContinentDefense = new short[16];
		public short Ranking;
		public ushort CumulativeEpicRanking;
		public short Score;

		// Technology
		public short ScienceRate;
		public short ResearchProgress = 0;
		public ushort DiscoveredTechnologyCount = 0;
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


		public Player()
		{
			for (int i = 0; i < Units.Length; i++)
			{
				this.Units[i] = new Unit();
			}

			for (int i = 0; i < StrategicLocations.Length; i++)
			{
				this.StrategicLocations[i] = new StrategicLocation();
			}

			for (int i = 0; i < DiscoveredTechnologyFlags.Length; i++)
			{
				this.DiscoveredTechnologyFlags[i] = 0;
			}

			for (int i = 0; i < ActiveUnits.Length; i++)
			{
				this.ActiveUnits[i] = 0;
			}

			for (int i = 0; i < UnitsInProduction.Length; i++)
			{
				this.UnitsInProduction[i] = 0;
			}
		}
	}
}
