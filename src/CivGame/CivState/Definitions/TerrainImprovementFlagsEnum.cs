namespace OpenCiv1
{
	[Flags]
	public enum TerrainImprovementFlagsEnum
	{
		None = 0x0,
		City = 0x1,
		Irrigation = 0x2,
		Mines = 0x4,
		Road = 0x8,
		RailRoad = 0x10,
		Fortress = 0x20,
		Pollution = 0x40,
		PillageMask = 0x1e,
	}
}
