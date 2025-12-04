using System;

namespace OpenCiv1
{
	public class TerrainMapGroup
	{
		private int iID;
		private TerrainMapGroupTypeEnum eGroupType;
		private int iSize = 0;
		private int iBuildSiteCount = 0;

		internal TerrainMapGroup(int id, TerrainMapGroupTypeEnum groupType)
		{
			this.iID = id;
			this.eGroupType = groupType;	
		}

		public int ID
		{
			get => this.iID;
		}

		public TerrainMapGroupTypeEnum GroupType
		{
			get => this.eGroupType;
			set => this.eGroupType = value;
		}

		public int Size
		{
			get => this.iSize;
			internal set => this.iSize = value;
		}

		public int BuildSiteCount
		{
			get => this.iBuildSiteCount;
			set => this.iBuildSiteCount = value;
		}
	}
}
