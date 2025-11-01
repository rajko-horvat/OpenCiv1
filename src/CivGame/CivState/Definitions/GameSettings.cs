namespace OpenCiv1
{
	public class GameSettings
	{
		private short value = 2;

		// represents bit value 0x1
		public bool InstantAdvice
		{
			get => (value & (1 << 0)) != 0;
			set
			{
				this.value |= (1 << 0);
				if (!value)
					this.value ^= (1 << 0);
			}
		}

		// represents bit value 0x2
		public bool AutoSave
		{
			get => (value & (1 << 1)) != 0;
			set
			{
				this.value |= (1 << 1);
				if (!value)
					this.value ^= (1 << 1);
			}
		}

		// represents bit value 0x4
		public bool EndOfTurn
		{
			get => (value & (1 << 2)) != 0;
			set
			{
				this.value |= (1 << 2);
				if (!value)
					this.value ^= (1 << 2);
			}
		}

		// represents bit value 0x8
		public bool Animations
		{
			get => (value & (1 << 3)) != 0;
			set
			{
				this.value |= (1 << 3);
				if (!value)
					this.value ^= (1 << 3);
			}
		}

		// represents bit value 0x10
		public bool Sound
		{
			get => (value & (1 << 4)) != 0;
			set
			{
				this.value |= (1 << 4);
				if (!value)
					this.value ^= (1 << 4);
			}
		}

		// represents bit value 0x20
		public bool EnemyMoves
		{
			get => (value & (1 << 5)) != 0;
			set
			{
				this.value |= (1 << 5);
				if (!value)
					this.value ^= (1 << 5);
			}
		}

		// represents bit value 0x40
		public bool CivilopediaText
		{
			get => (value & (1 << 6)) != 0;
			set
			{
				this.value |= (1 << 6);
				if (!value)
					this.value ^= (1 << 6);
			}
		}

		// represents bit value 0x80
		public bool Palace
		{
			get => (value & (1 << 7)) != 0;
			set
			{
				this.value |= (1 << 7);
				if (!value)
					this.value ^= (1 << 7);
			}
		}

		public short Value
		{
			get
			{
				return this.value;
			}
			set
			{
				this.value = value;
			}
		}
	}
}
