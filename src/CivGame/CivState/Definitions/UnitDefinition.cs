using System;

namespace OpenCiv1
{
	public class UnitDefinition
	{
		// Total size: 34 bytes
		public UnitTypeEnum TypeID = UnitTypeEnum.None;
		public string Name = ""; // (12 bytes)
		public short Price = 0;
		public UnitMovementTypeEnum MovementType = UnitMovementTypeEnum.Land;
		public short MoveCount = 0;
		public short AttackStrength = 0;
		public short DefenseStrength = 0;
		public short OutsideTurns = 0;
		public short SightRange = 0;
		public short TransportCapacity = 0;
		public short UnitCategory = 0;
		public TechnologyEnum RequiresTechnology = TechnologyEnum.None;
		public TechnologyEnum ObsoletesAfterTechnology = TechnologyEnum.None;

		public UnitDefinition()
		{ }

		public UnitDefinition(UnitTypeEnum typeID, string name, short price, UnitMovementTypeEnum movementType,
			short moveCount, short attackStrength, short defenseStrength, 
			short outsideTurns, short sightRange, short transportCapacity, short unitCategory, 
			TechnologyEnum requiresTechnology, TechnologyEnum obsoletesAfterTechnology)
		{
			this.TypeID = typeID;
			this.Name = name;
			this.Price = price;
			this.MovementType = movementType;
			this.MoveCount = moveCount;
			this.AttackStrength = attackStrength;
			this.DefenseStrength = defenseStrength;
			this.OutsideTurns = outsideTurns;
			this.SightRange = sightRange;
			this.TransportCapacity = transportCapacity;
			this.UnitCategory = unitCategory;
			this.RequiresTechnology = requiresTechnology;
			this.ObsoletesAfterTechnology = obsoletesAfterTechnology;
		}

		public static UnitDefinition FromStream(Stream stream)
		{
			UnitDefinition ud = new UnitDefinition();

			ud.Name = GameLoadAndSave.ReadString(stream, 12);
			ud.ObsoletesAfterTechnology = (TechnologyEnum)GameLoadAndSave.ReadInt16(stream);
			ud.MovementType = (UnitMovementTypeEnum)GameLoadAndSave.ReadInt16(stream);
			ud.MoveCount = GameLoadAndSave.ReadInt16(stream);
			ud.OutsideTurns = GameLoadAndSave.ReadInt16(stream);
			ud.AttackStrength = GameLoadAndSave.ReadInt16(stream);
			ud.DefenseStrength = GameLoadAndSave.ReadInt16(stream);
			ud.Price = GameLoadAndSave.ReadInt16(stream);
			ud.SightRange = GameLoadAndSave.ReadInt16(stream);
			ud.TransportCapacity = GameLoadAndSave.ReadInt16(stream);
			ud.UnitCategory = GameLoadAndSave.ReadInt16(stream);
			ud.RequiresTechnology = (TechnologyEnum)GameLoadAndSave.ReadInt16(stream);

			return ud;
		}

		public void ToStream(Stream stream)
		{
			GameLoadAndSave.WriteString(stream, this.Name, 12);
			GameLoadAndSave.WriteInt16(stream, (short)this.ObsoletesAfterTechnology);
			GameLoadAndSave.WriteInt16(stream, (short)this.MovementType);
			GameLoadAndSave.WriteInt16(stream, this.MoveCount);
			GameLoadAndSave.WriteInt16(stream, this.OutsideTurns);
			GameLoadAndSave.WriteInt16(stream, this.AttackStrength);
			GameLoadAndSave.WriteInt16(stream, this.DefenseStrength);
			GameLoadAndSave.WriteInt16(stream, this.Price);
			GameLoadAndSave.WriteInt16(stream, this.SightRange);
			GameLoadAndSave.WriteInt16(stream, this.TransportCapacity);
			GameLoadAndSave.WriteInt16(stream, this.UnitCategory);
			GameLoadAndSave.WriteInt16(stream, (short)this.RequiresTechnology);
		}
	}
}
