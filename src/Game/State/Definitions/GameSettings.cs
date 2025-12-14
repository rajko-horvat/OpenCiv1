namespace OpenCiv1
{
	public class GameSettings
	{
		private short value = 2;

		/// <summary>
		/// Represents bit value 0x1
		/// </summary>
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

		/// <summary>
		/// Represents bit value 0x2
		/// </summary>
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

		/// <summary>
		/// Represents bit value 0x4
		/// </summary>
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

		/// <summary>
		/// Represents bit value 0x8
		/// </summary>
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

		/// <summary>
		/// Represents bit value 0x10
		/// </summary>
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

		/// <summary>
		/// Represents bit value 0x20
		/// </summary>
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

		/// <summary>
		/// Represents bit value 0x40
		/// </summary>
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

		/// <summary>
		/// Represents bit value 0x80
		/// </summary>
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
