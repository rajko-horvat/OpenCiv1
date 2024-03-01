using System;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class City
	{
		public ushort BuildingFlags0 = 0;
		public ushort BuildingFlags1 = 0;
		public GPoint Position = new GPoint(0, 0);
		public byte StatusFlag = 0;
		public sbyte ActualSize = 0;
		public sbyte VisibleSize = 0;
		public sbyte CurrentProductionID = 0;
		public sbyte BaseTrade = 0;
		public short PlayerID = 0;
		public short FoodCount = 0;
		public short ShieldsCount = 0;
		public ushort WorkerFlags0 = 0;
		public ushort WorkerFlags1 = 0;
		public ushort WorkerFlags2 = 0;
		public byte NameID = 0;
		public sbyte[] TradeCityIDs = new sbyte[3];
		public sbyte[] Unknown = new sbyte[2];

		public City()
		{
			for (int i = 0; i < this.TradeCityIDs.Length; i++)
				this.TradeCityIDs[i] = 0;

			for (int i = 0; i < this.Unknown.Length; i++)
				this.Unknown[i] = 0;
		}

		public static City FromStream(Stream stream)
		{
			City city = new City();

			city.BuildingFlags0 = GameLoadAndSave.ReadUInt16(stream);
			city.BuildingFlags1 = GameLoadAndSave.ReadUInt16(stream);
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
			city.WorkerFlags0 = GameLoadAndSave.ReadUInt16(stream);
			city.WorkerFlags1 = GameLoadAndSave.ReadUInt16(stream);
			city.WorkerFlags2 = GameLoadAndSave.ReadUInt16(stream);
			city.NameID = GameLoadAndSave.ReadUInt8(stream);

			for (int i = 0; i < city.TradeCityIDs.Length; i++)
				city.TradeCityIDs[i] = (sbyte)GameLoadAndSave.ReadUInt8(stream);

			for (int i = 0; i < city.Unknown.Length; i++)
				city.Unknown[i] = (sbyte)GameLoadAndSave.ReadUInt8(stream);

			return city;
		}

		public void ToStream(Stream stream)
		{
			GameLoadAndSave.WriteUInt16(stream, this.BuildingFlags0);
			GameLoadAndSave.WriteUInt16(stream, this.BuildingFlags1);
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
			GameLoadAndSave.WriteUInt16(stream, this.WorkerFlags0);
			GameLoadAndSave.WriteUInt16(stream, this.WorkerFlags1);
			GameLoadAndSave.WriteUInt16(stream, this.WorkerFlags2);
			stream.WriteByte(this.NameID);

			for (int i = 0; i < this.TradeCityIDs.Length; i++)
				stream.WriteByte((byte)this.TradeCityIDs[i]);

			for (int i = 0; i < this.Unknown.Length; i++)
				stream.WriteByte((byte)this.Unknown[i]);
		}
	}
}
