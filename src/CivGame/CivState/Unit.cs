using System;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class Unit
	{
		public short Status = 0;
		public GPoint Position = new GPoint(-1);
		public short TypeID = 0;
		public short RemainingMoves = 0;
		public short SpecialMoves = 0;
		public GPoint GoToPosition = new GPoint(-1);
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

			unit.Status = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.Position.X = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.Position.Y = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.TypeID = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.RemainingMoves = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.SpecialMoves = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.GoToPosition.X = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			unit.GoToPosition.Y = (sbyte)GameLoadAndSave.ReadUInt8(stream);
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
			stream.WriteByte((byte)((sbyte)this.GoToPosition.X));
			stream.WriteByte((byte)((sbyte)this.GoToPosition.Y));
			stream.WriteByte((byte)((sbyte)this.GoToNextDirection));
			stream.WriteByte((byte)(this.VisibleByPlayer & 0xff));
			stream.WriteByte((byte)((sbyte)this.NextUnitID));
			stream.WriteByte((byte)((sbyte)this.HomeCityID));
		}
	}
}
