using System;
using IRB.Collections.Generic;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	[Flags]
	public enum UnitStatusEnum
	{
		None = 0,
		Sentry = 1,
		Fortifying = 4,
		Fortified = 8,
		Unknown1 = 0x10,
		Veteran = 0x20,
		SettlerBuildRoadOrRail = 2,
		SettlerBuildIrrigation = 0x40,
		SettlerBuildMineOrForest = 0x80,
		SettlerBuildFortress = 0xc0,
		SettlerCleanPollution = 0x82,
		SettlerBuildMask = 0xc2
	}

	public class Unit
	{
		private Player? oParent = null;

		public short TypeID = 0;
		public short Status = 0;
		public GPoint Position = new GPoint(-1);
		public short RemainingMoves = 0;
		public short SpecialMoves = 0;
		public short NextUnitID = 0;
		public short HomeCityID = 0;
		public ushort VisibleByPlayer = 0;
		public BHashSet<int> VisibilityList = new BHashSet<int>(); // List of the Player IDs that this cell is visible to

		public GPoint GoToDestination = new GPoint(-1);
		public int GoToNextDirection = 0;
		public Stack<GPoint> GoToPath = new Stack<GPoint>();

		public Unit()
		{ }

		public Unit(Player parent)
		{
			this.oParent = parent;
		}

		public Player? Parent
		{
			get => this.oParent;
		}

		public int PlayerID
		{
			get
			{
				if (this.oParent != null)
				{
					return this.oParent.ID;
				}

				return -1;
			}
		}

		public void ClearStatus(short status)
		{
			this.Status &= status;
		}

		public bool TestStatus(short status)
		{
			return (this.Status & status) != 0;
		}

		/// <summary>
		/// Makes this cell invisible to everyone
		/// </summary>
		public void ClearVisibility()
		{
			this.VisibilityList.Clear();
		}

		/// <summary>
		/// Tests if this cell is visible
		/// </summary>
		/// <param name="playerID">The Player ID to test visibility for</param>
		/// <returns></returns>
		public bool IsVisibleTo(int playerID)
		{
			return this.VisibilityList.Contains(playerID);
		}

		/// <summary>
		/// Sets visibility of this cell
		/// </summary>
		/// <param name="playerID">Player ID to set visibility for</param>
		/// <param name="visible">If the cell is visible to the provided Player</param>
		public void SetVisiblity(int playerID, bool visible)
		{
			if (visible)
			{
				if (!this.VisibilityList.Contains(playerID))
				{
					this.VisibilityList.Add(playerID);
				}
			}
			else
			{
				if (this.VisibilityList.Contains(playerID))
				{
					this.VisibilityList.Remove(playerID);
				}
			}
		}

		/// <summary>
		/// Appends another Visibility list to this cell
		/// </summary>
		/// <param name="visibilityList"></param>
		public void AppendVisibility(BHashSet<int> visibilityList)
		{
			for (int i = 0; i < visibilityList.Count; i++)
			{
				if (!this.VisibilityList.Contains(visibilityList[i]))
				{
					this.VisibilityList.Add(visibilityList[i]);
				}
			}
		}

		public int GetNextGoToMove()
		{
			return GetNextGoToMove(true);
		}

		public int GetNextGoToMove(bool testVisibility)
		{
			int direction = -1;

			this.GoToNextDirection = -1;

			if (this.oParent!=null && this.oParent.Parent.Map.IsValidPosition(this.GoToDestination) && this.Position != this.GoToDestination)
			{
				if (this.GoToPath.Count == 0)
				{
					this.oParent.Parent.Map.FindUnitPath(this, testVisibility);
				}

				if (this.GoToPath.Count == 0)
				{
					// We couldn't find a path for a destination
					this.GoToDestination = OpenCiv1Game.InvalidPosition;
					this.GoToPath.Clear();
					this.GoToNextDirection = -1;
				}
				else
				{
					GPoint newPos = this.GoToPath.Pop();

					direction = this.oParent.Parent.Map.GetMoveOffset(newPos - this.Position);
					this.GoToNextDirection = direction;
				}
			}

			return direction;
		}

		public static Unit FromStream(Player parent, Stream stream)
		{
			Unit unit = new Unit(parent);

			unit.Status = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.Position.X = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.Position.Y = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.TypeID = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.RemainingMoves = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.SpecialMoves = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.GoToDestination.X = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.GoToDestination.Y = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.GoToNextDirection = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.VisibleByPlayer = GameLoadAndSave.ReadUInt8(stream);
			unit.NextUnitID = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.HomeCityID = (sbyte)GameLoadAndSave.ReadUInt8(stream);

			return unit;
		}

		public void ToStream(Stream stream)
		{
			stream.WriteByte((byte)((sbyte)this.Status));
			stream.WriteByte((byte)((sbyte)this.Position.X));
			stream.WriteByte((byte)((sbyte)this.Position.Y));
			stream.WriteByte((byte)((sbyte)this.TypeID));
			stream.WriteByte((byte)((sbyte)this.RemainingMoves));
			stream.WriteByte((byte)((sbyte)this.SpecialMoves));
			stream.WriteByte((byte)((sbyte)this.GoToDestination.X));
			stream.WriteByte((byte)((sbyte)this.GoToDestination.Y));
			stream.WriteByte((byte)((sbyte)this.GoToNextDirection));
			stream.WriteByte((byte)(this.VisibleByPlayer & 0xff));
			stream.WriteByte((byte)((sbyte)this.NextUnitID));
			stream.WriteByte((byte)((sbyte)this.HomeCityID));
		}
	}
}
