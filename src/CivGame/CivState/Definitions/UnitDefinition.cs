using System;

namespace OpenCiv1
{
	public class UnitDefinition
	{
		// Total size: 34 bytes
		public UnitTypeEnum UnitType = UnitTypeEnum.None;
		public string Name = ""; // (12 bytes)
		public TechnologyEnum CancelTechnology = TechnologyEnum.None;
		public UnitCategoryEnum TerrainCategory = UnitCategoryEnum.Land;
		public short MoveCount = 0;
		public short TurnsOutside = 0;
		public short AttackStrength = 0;
		public short DefenseStrength = 0;
		public short Cost = 0;
		public short SightRange = 0;
		public short TransportCapacity = 0;
		public short UnitCategory = 0;
		public TechnologyEnum RequiredTechnology = TechnologyEnum.None;

		public UnitDefinition()
		{ }

		public UnitDefinition(UnitTypeEnum unitType, string name, TechnologyEnum cancelTechnology, UnitCategoryEnum terrainCategory,
			short moveCount, short turnsOutside, short attackStrength, short defenceStrength,
			short cost, short sightRange, short transportCapacity, short unitCategory,
			TechnologyEnum requiredTechnology)
		{
			this.UnitType= unitType;
			this.Name = name;
			this.CancelTechnology = cancelTechnology;
			this.TerrainCategory = terrainCategory;
			this.MoveCount = moveCount;
			this.TurnsOutside = turnsOutside;
			this.AttackStrength = attackStrength;
			this.DefenseStrength = defenceStrength;
			this.Cost = cost;
			this.SightRange = sightRange;
			this.TransportCapacity = transportCapacity;
			this.UnitCategory = unitCategory;
			this.RequiredTechnology = requiredTechnology;
		}

		public static UnitDefinition FromStream(Stream stream)
		{
			UnitDefinition ud = new UnitDefinition();

			ud.Name = GameLoadAndSave.ReadString(stream, 12);
			ud.CancelTechnology = (TechnologyEnum)GameLoadAndSave.ReadInt16(stream);
			ud.TerrainCategory = (UnitCategoryEnum)GameLoadAndSave.ReadInt16(stream);
			ud.MoveCount = GameLoadAndSave.ReadInt16(stream);
			ud.TurnsOutside = GameLoadAndSave.ReadInt16(stream);
			ud.AttackStrength = GameLoadAndSave.ReadInt16(stream);
			ud.DefenseStrength = GameLoadAndSave.ReadInt16(stream);
			ud.Cost = GameLoadAndSave.ReadInt16(stream);
			ud.SightRange = GameLoadAndSave.ReadInt16(stream);
			ud.TransportCapacity = GameLoadAndSave.ReadInt16(stream);
			ud.UnitCategory = GameLoadAndSave.ReadInt16(stream);
			ud.RequiredTechnology = (TechnologyEnum)GameLoadAndSave.ReadInt16(stream);

			return ud;
		}

		public void ToStream(Stream stream)
		{
			GameLoadAndSave.WriteString(stream, this.Name, 12);
			GameLoadAndSave.WriteInt16(stream, (short)this.CancelTechnology);
			GameLoadAndSave.WriteInt16(stream, (short)this.TerrainCategory);
			GameLoadAndSave.WriteInt16(stream, this.MoveCount);
			GameLoadAndSave.WriteInt16(stream, this.TurnsOutside);
			GameLoadAndSave.WriteInt16(stream, this.AttackStrength);
			GameLoadAndSave.WriteInt16(stream, this.DefenseStrength);
			GameLoadAndSave.WriteInt16(stream, this.Cost);
			GameLoadAndSave.WriteInt16(stream, this.SightRange);
			GameLoadAndSave.WriteInt16(stream, this.TransportCapacity);
			GameLoadAndSave.WriteInt16(stream, this.UnitCategory);
			GameLoadAndSave.WriteInt16(stream, (short)this.RequiredTechnology);
		}
	}
}
