using Disassembler;
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
		public short Status = 0;
		public Point Position = new Point(-1, -1);
		public short TypeID = 0;
		public short RemainingMoves = 0;
		public short SpecialMoves = 0;
		public Point GoToPosition = new Point(-1, -1);
		public short GoToNextDirection = 0;
		public ushort VisibleByPlayer = 0;
		public short NextUnitID = 0;
		public short HomeCityID = 0;


		public void ClearStatus(short status)
		{
			this.Status &= status;
		}

		public bool TestStatus(short status)
		{
			return (this.Status & status) != 0;
		}

		public static Unit FromStream(Stream stream)
		{
			Unit unit = new Unit();

			unit.Status = Overlay_11.ReadUInt8(stream);
			unit.Position.X = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.Position.Y = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.TypeID = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.RemainingMoves = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.SpecialMoves = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.GoToPosition.X = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.GoToPosition.Y = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.GoToNextDirection = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.VisibleByPlayer = Overlay_11.ReadUInt8(stream);
			unit.NextUnitID = (sbyte)Overlay_11.ReadUInt8(stream);
			unit.HomeCityID = (sbyte)Overlay_11.ReadUInt8(stream);

			return unit;
		}

		public void ToStream(Stream stream)
		{
			stream.WriteByte(CPU.ForceUInt8(this.Status));
			stream.WriteByte(CPU.ForceUInt8(this.Position.X));
			stream.WriteByte(CPU.ForceUInt8(this.Position.Y));
			stream.WriteByte(CPU.ForceUInt8(this.TypeID));
			stream.WriteByte(CPU.ForceUInt8(this.RemainingMoves));
			stream.WriteByte(CPU.ForceUInt8(this.SpecialMoves));
			stream.WriteByte(CPU.ForceUInt8(this.GoToPosition.X));
			stream.WriteByte(CPU.ForceUInt8(this.GoToPosition.Y));
			stream.WriteByte(CPU.ForceUInt8(this.GoToNextDirection));
			stream.WriteByte(CPU.ForceUInt8(this.VisibleByPlayer));
			stream.WriteByte(CPU.ForceUInt8(this.NextUnitID));
			stream.WriteByte(CPU.ForceUInt8(this.HomeCityID));
		}
	}
}
