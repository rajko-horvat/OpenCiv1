using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class TerrainModification
	{
		readonly TerrainTypeEnum TerrainType;

		// Total size: 12 bytes
		/// <summary>
		///	Effect of irrigation or changing cell to.
		///	If positive: TerrainChangeID of terrain after change.
		/// If negative: -1 impossible to irrigate, -2 +1 food, -3 +2 food etc.
		/// </summary>
		public short IrrigationEffect;
		/// <summary>
		/// Number of turns it takes the settlers to create irrigation or change cell.
		/// </summary>
		public short IrrigationCost;
		/// <summary>
		/// Effect of mines or changing cell to.
		/// If positive: TerrainChangeID of terrain after change.
		/// If negative: -1 impossible to mine, -2 +1 production, -3 +2 production etc.
		/// </summary>
		public short MiningEffect;
		/// <summary>
		/// Number of turns it takes the settlers to create mines or change cell.
		/// </summary>
		public short MiningCost;
		/// <summary>
		/// Whether AI can irrigate or mine this terrain type under Despotism/Anarchy.
		/// </summary>
		public short AICanImproveBeforeMonarchy;
		/// <summary>
		/// Whether AI can irrigate or mine this terrain type under Monarchy or above.
		/// </summary>
		public short AICanImproveAfterMonarchy;

		public TerrainModification(TerrainTypeEnum terrainType, short irrigationEffect, short irrigationCost, short miningEffect, short miningCost, short aiCanImproveBeforeMonarchy, short aiCanImproveAfterMonarchy)
		{
			this.TerrainType = terrainType;
			this.IrrigationEffect = irrigationEffect;
			this.IrrigationCost = irrigationCost;
			this.MiningEffect = miningEffect;
			this.MiningCost = miningCost;
			this.AICanImproveBeforeMonarchy = aiCanImproveBeforeMonarchy;
			this.AICanImproveAfterMonarchy = aiCanImproveAfterMonarchy;
		}
	}
}
