namespace OpenCiv1
{
	public struct PaletteCycleInfo
	{
		public readonly int Speed;
		public readonly int FromIndex;
		public readonly int ToIndex;

		public PaletteCycleInfo(int speed, int fromIndex, int toIndex)
		{
			this.Speed = speed;
			this.FromIndex = fromIndex;
			this.ToIndex = toIndex;
		}
	}
}
