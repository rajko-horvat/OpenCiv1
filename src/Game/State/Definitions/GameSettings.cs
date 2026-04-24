using System.Xml.Serialization;

namespace OpenCiv1
{
	public class GameSettings
	{
		private int settingsValue = 2;

		/// <summary>
		/// Shows the Instant advices. Represents bit value 0x1
		/// </summary>
		public bool InstantAdvice
		{
			get => (settingsValue & (1 << 0)) != 0;
			set
			{
				this.settingsValue |= (1 << 0);
				if (!value)
					this.settingsValue ^= (1 << 0);
			}
		}

		/// <summary>
		/// Automatically saves the game every N turns. Represents bit value 0x2
		/// </summary>
		public bool AutoSave
		{
			get => (settingsValue & (1 << 1)) != 0;
			set
			{
				this.settingsValue |= (1 << 1);
				if (!value)
					this.settingsValue ^= (1 << 1);
			}
		}

		/// <summary>
		/// Waits for End of Turn confirmation. Represents bit value 0x4
		/// </summary>
		public bool EndOfTurn
		{
			get => (settingsValue & (1 << 2)) != 0;
			set
			{
				this.settingsValue |= (1 << 2);
				if (!value)
					this.settingsValue ^= (1 << 2);
			}
		}

		/// <summary>
		/// Shows animations. Represents bit value 0x8
		/// </summary>
		public bool Animations
		{
			get => (settingsValue & (1 << 3)) != 0;
			set
			{
				this.settingsValue |= (1 << 3);
				if (!value)
					this.settingsValue ^= (1 << 3);
			}
		}

		/// <summary>
		/// Enable sound. Represents bit value 0x10
		/// </summary>
		public bool Sound
		{
			get => (settingsValue & (1 << 4)) != 0;
			set
			{
				this.settingsValue |= (1 << 4);
				if (!value)
					this.settingsValue ^= (1 << 4);
			}
		}

		/// <summary>
		/// Shows enemy moves for visible units. Represents bit value 0x20
		/// </summary>
		public bool EnemyMoves
		{
			get => (settingsValue & (1 << 5)) != 0;
			set
			{
				this.settingsValue |= (1 << 5);
				if (!value)
					this.settingsValue ^= (1 << 5);
			}
		}

		/// <summary>
		/// Shows the text from Civilopedia. Represents bit value 0x40
		/// </summary>
		public bool CivilopediaText
		{
			get => (settingsValue & (1 << 6)) != 0;
			set
			{
				this.settingsValue |= (1 << 6);
				if (!value)
					this.settingsValue ^= (1 << 6);
			}
		}

		/// <summary>
		/// Are we building palace. Represents bit value 0x80
		/// </summary>
		public bool BuildPalace
		{
			get => (settingsValue & (1 << 7)) != 0;
			set
			{
				this.settingsValue |= (1 << 7);
				if (!value)
					this.settingsValue ^= (1 << 7);
			}
		}

		/// <summary>
		/// Enable debug saves for every turn. Represents bit value 0x80
		/// </summary>
		public bool DebugSaves
		{
			get => (settingsValue & (1 << 8)) != 0;
			set
			{
				this.settingsValue |= (1 << 8);
				if (!value)
					this.settingsValue ^= (1 << 8);
			}
		}

		[XmlIgnore]
		public int Value
		{
			get
			{
				return this.settingsValue;
			}
			set
			{
				this.settingsValue = value;
			}
		}
	}
}
