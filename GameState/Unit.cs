using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

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
		public UnitStatusEnum Status = UnitStatusEnum.None;
		public Point Position = new Point(-1, -1);
		public short TypeID = 0;
		public short RemainingMoves = 0;
		public short SpecialMoves = 0;
		public Point GoToPosition = new Point(-1, -1);
		public short GotoNextDirection = 0;
		public short VisibleByFlag = 0;
		public short NextUnitID = 0;
		public short HomeCityID = 0;


		public void ClearStatus(UnitStatusEnum flag)
		{
			this.Status |= flag;
			this.Status ^= flag;
		}

		public bool TestStatus(UnitStatusEnum flag)
		{
			return (this.Status & flag) == flag;
		}

		public bool TestAnyStatus(UnitStatusEnum flag)
		{
			return (int)(this.Status & flag) != 0;
		}

		public bool TestSettlerStatus(UnitStatusEnum flag)
		{
			return (this.Status & UnitStatusEnum.SettlerBuildMask) == flag;
		}

		public static Unit FromStream(Stream stream)
		{
			Unit unit = new Unit();

			unit.Status = (UnitStatusEnum)Overlay_11.ReadUInt8(stream);
			unit.Position.X = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.Position.Y = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.TypeID = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.RemainingMoves = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.SpecialMoves = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.GoToPosition.X = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.GoToPosition.Y = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.GotoNextDirection = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.VisibleByFlag = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.NextUnitID = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.HomeCityID = (sbyte)Overlay_11.ReadUInt8(stream);

			return unit;
		}

		public void ToStream(Stream stream)
		{
			stream.WriteByte((byte)((int)this.Status & 0xff));
			stream.WriteByte((byte)this.Position.X);
			stream.WriteByte((byte)this.Position.Y);
			stream.WriteByte((byte)this.TypeID);
			stream.WriteByte((byte)this.RemainingMoves);
			stream.WriteByte((byte)this.SpecialMoves);
			stream.WriteByte((byte)this.GoToPosition.X);
			stream.WriteByte((byte)this.GoToPosition.Y);
			stream.WriteByte((byte)this.GotoNextDirection);
			stream.WriteByte((byte)this.VisibleByFlag);
			stream.WriteByte((byte)this.NextUnitID);
			stream.WriteByte((byte)this.HomeCityID);
		}
	}
}
