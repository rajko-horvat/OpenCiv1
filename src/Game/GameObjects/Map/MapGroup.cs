using System;

namespace OpenCiv1
{
	public class MapGroup
	{
		private int iID;
		private MapGroupTypeEnum eGroupType;
		private int iSize = 0;
		private int iBuildSiteCount = 0;

		internal MapGroup(int id, MapGroupTypeEnum groupType)
		{
			this.iID = id;
			this.eGroupType = groupType;	
		}

		public int ID
		{
			get => this.iID;
		}

		public MapGroupTypeEnum GroupType
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
