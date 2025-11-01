﻿namespace OpenCiv1
{
	public class GameSettings
	{
		private short value = 2;

		public bool InstantAdvice
		{
			get
			{
				return (value & (1 << 0)) != 0;
			}
			set
			{
				this.value |= (1 << 0);
				if (!value)
					this.value ^= (1 << 0);
			}
		}

		public bool Autosave
		{
			get
			{
				return (value & (1 << 1)) != 0;
			}
			set
			{
				this.value |= (1 << 1);
				if (!value)
					this.value ^= (1 << 1);
			}
		}

		public bool EndOfTurn
		{
			get
			{
				return (value & (1 << 2)) != 0;
			}
			set
			{
				this.value |= (1 << 2);
				if (!value)
					this.value ^= (1 << 2);
			}
		}

		public bool Animations
		{
			get
			{
				return (value & (1 << 3)) != 0;
			}
			set
			{
				this.value |= (1 << 3);
				if (!value)
					this.value ^= (1 << 3);
			}
		}

		public bool Sound
		{
			get
			{
				return (value & (1 << 4)) != 0;
			}
			set
			{
				this.value |= (1 << 4);
				if (!value)
					this.value ^= (1 << 4);
			}
		}

		public bool EnemyMoves
		{
			get
			{
				return (value & (1 << 5)) != 0;
			}
			set
			{
				this.value |= (1 << 5);
				if (!value)
					this.value ^= (1 << 5);
			}
		}

		public bool CivilopediaText
		{
			get
			{
				return (value & (1 << 6)) != 0;
			}
			set
			{
				this.value |= (1 << 6);
				if (!value)
					this.value ^= (1 << 6);
			}
		}

		public bool Palace
		{
			get
			{
				return (value & (1 << 7)) != 0;
			}
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
