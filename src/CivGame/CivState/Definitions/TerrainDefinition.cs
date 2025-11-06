using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class TerrainDefinition
	{
		readonly TerrainTypeEnum TerrainType;

		// Total size: 19 bytes
		public string Name; // (12 bytes)
		public sbyte MovementCost;
		public sbyte DefenseBonus;
		public sbyte Food;
		public sbyte Production;
		public sbyte Trade;
		public sbyte Unknown1;
		public sbyte TerrainChangeID;

		public TerrainDefinition(TerrainTypeEnum terrainType, string name, sbyte movementCost, sbyte defenseBonus, 
			sbyte food, sbyte production, sbyte trade, sbyte unknown1, sbyte terrainChangeID)
		{
			this.TerrainType = terrainType;
			this.Name = name;
			this.MovementCost = movementCost;
			this.DefenseBonus = defenseBonus;
			this.Food = food;
			this.Production = production;
			this.Trade = trade;
			this.Unknown1 = unknown1;
			this.TerrainChangeID = terrainChangeID;
		}
	}
}
