using System;
using System.Reflection.Metadata.Ecma335;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class City
	{
		public int ID = -1;

		public uint BuildingFlags = 0;
		public GPoint Position = new GPoint(0, 0);
		public byte StatusFlag = 0;
		public sbyte ActualSize = 0;
		public sbyte VisibleSize = 0;
		public sbyte CurrentProductionID = 0;
		public sbyte BaseTrade = 0;
		public short PlayerID = 0;
		public short FoodCount = 0;
		public short ShieldsCount = 0;
		public uint WorkerFlags = 0;
		public ushort SpecialWorkerFlags = 0;
		public byte NameID = 0;
		public sbyte[] TradeCityIDs = new sbyte[3];
		public sbyte[] Unknown = new sbyte[2];

		public City(int id)
		{
			this.ID = id;

			for (int i = 0; i < this.TradeCityIDs.Length; i++)
				this.TradeCityIDs[i] = 0;

			for (int i = 0; i < this.Unknown.Length; i++)
				this.Unknown[i] = 0;
		}

		// Emulate BuildingFlags 0 and 1 for now
		public ushort BuildingFlags0
		{
			get => (ushort)(this.BuildingFlags & 0xffff);
			set
			{
				this.BuildingFlags &= 0xffff0000;
				this.BuildingFlags |= value;
			}
		}

		public ushort BuildingFlags1
		{
			get => (ushort)((this.BuildingFlags & 0xffff0000) >> 16);
			set
			{
				this.BuildingFlags &= 0xffff;
				this.BuildingFlags |= ((uint)value << 16);
			}
		}

		public static City FromStream(int id, Stream stream)
		{
			City city = new City(id);

			city.BuildingFlags = GameLoadAndSave.ReadUInt32(stream);
			city.Position.X = GameLoadAndSave.ReadUInt8(stream);
			city.Position.Y = GameLoadAndSave.ReadUInt8(stream);
			city.StatusFlag = GameLoadAndSave.ReadUInt8(stream);
			city.ActualSize = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			city.VisibleSize = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			city.CurrentProductionID = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			city.BaseTrade = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			city.PlayerID = (sbyte)GameLoadAndSave.ReadUInt8(stream);
			city.FoodCount = GameLoadAndSave.ReadInt16(stream);
			city.ShieldsCount = GameLoadAndSave.ReadInt16(stream);
			city.WorkerFlags = GameLoadAndSave.ReadUInt32(stream);
			city.SpecialWorkerFlags = GameLoadAndSave.ReadUInt16(stream);
			city.NameID = GameLoadAndSave.ReadUInt8(stream);

			for (int i = 0; i < city.TradeCityIDs.Length; i++)
				city.TradeCityIDs[i] = (sbyte)GameLoadAndSave.ReadUInt8(stream);

			for (int i = 0; i < city.Unknown.Length; i++)
				city.Unknown[i] = (sbyte)GameLoadAndSave.ReadUInt8(stream);

			return city;
		}

		public void ToStream(Stream stream)
		{
			GameLoadAndSave.WriteUInt32(stream, this.BuildingFlags);
			stream.WriteByte((byte)this.Position.X);
			stream.WriteByte((byte)this.Position.Y);
			stream.WriteByte(this.StatusFlag);
			stream.WriteByte((byte)this.ActualSize);
			stream.WriteByte((byte)this.VisibleSize);
			stream.WriteByte((byte)this.CurrentProductionID);
			stream.WriteByte((byte)this.BaseTrade);
			stream.WriteByte((byte)((short)this.PlayerID));
			GameLoadAndSave.WriteInt16(stream, this.FoodCount);
			GameLoadAndSave.WriteInt16(stream, this.ShieldsCount);
			GameLoadAndSave.WriteUInt32(stream, this.WorkerFlags);
			GameLoadAndSave.WriteUInt16(stream, this.SpecialWorkerFlags);
			stream.WriteByte(this.NameID);

			for (int i = 0; i < this.TradeCityIDs.Length; i++)
				stream.WriteByte((byte)this.TradeCityIDs[i]);

			for (int i = 0; i < this.Unknown.Length; i++)
				stream.WriteByte((byte)this.Unknown[i]);
		}
	}
}
