using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCiv1
{
	public class Player
	{
		public string Name = "";
		public string Nationality = "";
		public string LeaderName = "";
		public short LeaderGraphics = 0;
		public short Coins = 0;
		public short GovernmentType = 0;
		public short TaxRate = 0;
		public short MilitaryPower = 0;
		public short ContactPlayerCountdown = 0;
		public short XStart = 0;
		public short CityCount = 0;
		public short TotalCitySize = 0;
		public short LandCount = 0;

		public short[] PerCivilizationDiplomacyFlags = new short[8];
		public short[] PerContinentCityCount = new short[16];
		public short[] PerContinentStrategy = new short[16];
		public short[] PerContinentAttack = new short[16];
		public short[] PerContinentDefense = new short[16];
		public short Ranking = 0;
		public short CumulativeEpicRanking = 0;
		public short Score = 0;

		// Technology
		public short ScienceRate = 0;
		public short ResearchProgress = 0;
		public short DiscoveredTechnologyCount = 0;
		public short CurrentResearchID = 0;
		public short FutureTechnologyCount = 0;
		public short[] DiscoveredTechnologyFlags = new short[5];
		public sbyte[] TechnologyAcquiredFrom = new sbyte[72];

		// Units
		public short UnitCount = 0;
		public short SettlerCount = 0;
		public short[] ActiveUnits = new short[28];
		public short[] UnitsDestroyed = new short[8];
		public Unit[] Units = new Unit[128];
		public short[] UnitsInProduction = new short[28];
		public short[] LostUnits = new short[28];

		// Strategic locations
		public StrategicLocation[] StrategicLocations = new StrategicLocation[16];

		// Spaceship
		public sbyte[] SpaceshipData = new sbyte[180];
		public short SpaceshipPopulation = 0;
		public short SpaceshipETAYear = 0;
		public short SpaceshipLaunchYear = 0;
		public short SpaceshipSuccessRate = 0;

		public Player()
		{
			for (int i = 0; i < this.PerCivilizationDiplomacyFlags.Length; i++)
			{
				this.PerCivilizationDiplomacyFlags[i] = 0;
			}

			for (int i = 0; i < this.PerContinentCityCount.Length; i++)
			{
				this.PerContinentCityCount[i] = 0;
			}

			for (int i = 0; i < this.PerContinentStrategy.Length; i++)
			{
				this.PerContinentStrategy[i] = 0;
			}

			for (int i = 0; i < this.PerContinentAttack.Length; i++)
			{
				this.PerContinentAttack[i] = 0;
			}

			for (int i = 0; i < this.PerContinentDefense.Length; i++)
			{
				this.PerContinentDefense[i] = 0;
			}

			for (int i = 0; i < this.DiscoveredTechnologyFlags.Length; i++)
			{
				this.DiscoveredTechnologyFlags[i] = 0;
			}

			for (int i = 0; i < this.TechnologyAcquiredFrom.Length; i++)
			{
				this.TechnologyAcquiredFrom[i] = 0;
			}

			for (int i = 0; i < this.ActiveUnits.Length; i++)
			{
				this.ActiveUnits[i] = 0;
			}

			for (int i = 0; i < this.UnitsDestroyed.Length; i++)
			{
				this.UnitsDestroyed[i] = 0;
			}

			for (int i = 0; i < this.Units.Length; i++)
			{
				this.Units[i] = new Unit();
			}

			for (int i = 0; i < this.UnitsInProduction.Length; i++)
			{
				this.UnitsInProduction[i] = 0;
			}

			for (int i = 0; i < this.LostUnits.Length; i++)
			{
				this.LostUnits[i] = 0;
			}

			for (int i = 0; i < this.StrategicLocations.Length; i++)
			{
				this.StrategicLocations[i] = new StrategicLocation();
			}

			for (int i = 0; i < this.SpaceshipData.Length; i++)
			{
				this.SpaceshipData[i] = 0;
			}
		}
	}
}
