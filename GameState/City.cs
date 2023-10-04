using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace OpenCiv1
{
	public class City
	{
		public ushort BuildingFlags0 = 0;
		public ushort BuildingFlags1 = 0;
		public Point Position = new Point(0, 0);
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

			city.BuildingFlags0 = Overlay_11.ReadUInt16(stream);
			city.BuildingFlags1 = Overlay_11.ReadUInt16(stream);
			city.Position.X = Overlay_11.ReadUInt8(stream);
			city.Position.Y = Overlay_11.ReadUInt8(stream);
			city.StatusFlag = Overlay_11.ReadUInt8(stream);
			city.ActualSize = (sbyte)Overlay_11.ReadUInt8(stream);
			city.VisibleSize = (sbyte)Overlay_11.ReadUInt8(stream);
			city.CurrentProductionID = (sbyte)Overlay_11.ReadUInt8(stream);
			city.BaseTrade = (sbyte)Overlay_11.ReadUInt8(stream);
			city.PlayerID = (sbyte)Overlay_11.ReadUInt8(stream);
			city.FoodCount = Overlay_11.ReadInt16(stream);
			city.ShieldsCount = Overlay_11.ReadInt16(stream);
			city.WorkerFlags0 = Overlay_11.ReadUInt16(stream);
			city.WorkerFlags1 = Overlay_11.ReadUInt16(stream);
			city.WorkerFlags2 = Overlay_11.ReadUInt16(stream);
			city.NameID = Overlay_11.ReadUInt8(stream);

			for (int i = 0; i < city.TradeCityIDs.Length; i++)
				city.TradeCityIDs[i] = (sbyte)Overlay_11.ReadUInt8(stream);

			for (int i = 0; i < city.Unknown.Length; i++)
				city.Unknown[i] = (sbyte)Overlay_11.ReadUInt8(stream);

			return city;
		}

		public void ToStream(Stream stream)
		{
			Overlay_11.WriteUInt16(stream, this.BuildingFlags0);
			Overlay_11.WriteUInt16(stream, this.BuildingFlags1);
			stream.WriteByte((byte)this.Position.X);
			stream.WriteByte((byte)this.Position.Y);
			stream.WriteByte(this.StatusFlag);
			stream.WriteByte((byte)this.ActualSize);
			stream.WriteByte((byte)this.VisibleSize);
			stream.WriteByte((byte)this.CurrentProductionID);
			stream.WriteByte((byte)this.BaseTrade);
			stream.WriteByte((byte)((short)this.PlayerID));
			Overlay_11.WriteInt16(stream, this.FoodCount);
			Overlay_11.WriteInt16(stream, this.ShieldsCount);
			Overlay_11.WriteUInt16(stream, this.WorkerFlags0);
			Overlay_11.WriteUInt16(stream, this.WorkerFlags1);
			Overlay_11.WriteUInt16(stream, this.WorkerFlags2);
			stream.WriteByte(this.NameID);

			for (int i = 0; i < this.TradeCityIDs.Length; i++)
				stream.WriteByte((byte)this.TradeCityIDs[i]);

			for (int i = 0; i < this.Unknown.Length; i++)
				stream.WriteByte((byte)this.Unknown[i]);
		}
	}
}
