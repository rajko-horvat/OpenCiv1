using System;
using System.Reflection.Metadata.Ecma335;
using IRB.Collections.Generic;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class City
	{
		public int ID = -1;

		private uint uiImprovementFlags = 0;
		public BHashSet<ImprovementEnum> Improvements = new BHashSet<ImprovementEnum>();
		public GPoint Position = new GPoint(0, 0);
		public byte StatusFlag = 0xff;
		public sbyte ActualSize = 0;
		public sbyte VisibleSize = 0;
		public sbyte CurrentProductionID = 0;
		public sbyte BaseTrade = 0;
		public short PlayerID = 0;
		public short FoodCount = 0;
		public short ShieldsCount = 0;
		public uint WorkerFlags = 0;
		public ushort SpecialWorkerFlags = 0;
		public byte NameID = 0xff;
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

		/// <summary>
		/// Conversion for old type bitwise improvements
		/// </summary>
		/// <param name="bit"></param>
		/// <returns></returns>
		public static ImprovementEnum BitToImprovementEnum(int bit)
		{
			switch (bit)
			{
				case 0:
					return ImprovementEnum.Palace;

				case 1:
					return ImprovementEnum.Barracks;

				case 2:
					return ImprovementEnum.Granary;

				case 3:
					return ImprovementEnum.Temple;

				case 4:
					return ImprovementEnum.MarketPlace;

				case 5:
					return ImprovementEnum.Library;

				case 6:
					return ImprovementEnum.Courthouse;

				case 7:
					return ImprovementEnum.CityWalls;

				case 8:
					return ImprovementEnum.Aqueduct;

				case 9:
					return ImprovementEnum.Bank;

				case 10:
					return ImprovementEnum.Cathedral;

				case 11:
					return ImprovementEnum.University;

				case 12:
					return ImprovementEnum.MassTransit;

				case 13:
					return ImprovementEnum.Colosseum;

				case 14:
					return ImprovementEnum.Factory;

				case 15:
					return ImprovementEnum.ManufacturingPlant;

				case 16:
					return ImprovementEnum.SDIDefense;

				case 17:
					return ImprovementEnum.RecyclingCenter;

				case 18:
					return ImprovementEnum.PowerPlant;

				case 19:
					return ImprovementEnum.HydroPlant;

				case 20:
					return ImprovementEnum.NuclearPlant;

				case 21:
					return ImprovementEnum.SSStructural;

				case 22:
					return ImprovementEnum.SSComponent;

				case 23:
					return ImprovementEnum.SSModule;

				default:
					return ImprovementEnum.None;
			}
		}

		/// <summary>
		/// Conversion for old type bitwise improvements
		/// </summary>
		/// <param name="improvement"></param>
		/// <returns></returns>
		public static uint ImprovementEnumToBit(ImprovementEnum improvement)
		{
			switch (improvement)
			{
				case ImprovementEnum.Palace:
					return 0x1;

				case ImprovementEnum.Barracks:
					return 0x2;

				case ImprovementEnum.Granary:
					return 0x4;

				case ImprovementEnum.Temple:
					return 0x8;

				case ImprovementEnum.MarketPlace:
					return 0x10;

				case ImprovementEnum.Library:
					return 0x20;

				case ImprovementEnum.Courthouse:
					return 0x40;

				case ImprovementEnum.CityWalls:
					return 0x80;

				case ImprovementEnum.Aqueduct:
					return 0x100;

				case ImprovementEnum.Bank:
					return 0x200;

				case ImprovementEnum.Cathedral:
					return 0x400;

				case ImprovementEnum.University:
					return 0x800;

				case ImprovementEnum.MassTransit:
					return 0x1000;

				case ImprovementEnum.Colosseum:
					return 0x2000;

				case ImprovementEnum.Factory:
					return 0x4000;

				case ImprovementEnum.ManufacturingPlant:
					return 0x8000;

				case ImprovementEnum.SDIDefense:
					return 0x10000;

				case ImprovementEnum.RecyclingCenter:
					return 0x20000;

				case ImprovementEnum.PowerPlant:
					return 0x40000;

				case ImprovementEnum.HydroPlant:
					return 0x80000;

				case ImprovementEnum.NuclearPlant:
					return 0x100000;

				case ImprovementEnum.SSStructural:
					return 0x200000;

				case ImprovementEnum.SSComponent:
					return 0x400000;

				case ImprovementEnum.SSModule:
					return 0x800000;

				default:
					return 0;
			}
		}

		// Emulate ImprovementFlags for now
		public ushort ImprovementFlags0
		{
			get => (ushort)(this.uiImprovementFlags & 0xffff);
			set
			{
				this.ImprovementFlags = (uint)((uint)(this.uiImprovementFlags & 0xffff0000) | value);
			}
		}

		public ushort ImprovementFlags1
		{
			get => (ushort)((this.uiImprovementFlags & 0xffff0000) >> 16);
			set
			{
				this.ImprovementFlags = (uint)((uint)(this.uiImprovementFlags & 0xffff) | (uint)((uint)value << 16));
			}
		}

		public uint ImprovementFlags
		{
			get
			{
				return this.uiImprovementFlags;
			}
			set
			{
				for (int i = 0; i < 24; i++)
				{
					uint bit = (uint)(1 << i);

					if ((value & bit) != (this.uiImprovementFlags & bit))
					{
						ImprovementEnum improvement = BitToImprovementEnum(i);

						if ((value & bit) != 0)
						{
							this.AddImprovement(improvement);
						}
						else
						{
							this.RemoveImprovement(improvement);
						}
					}
				}

				this.uiImprovementFlags = value;
			}
		}

		public void AddImprovement(ImprovementEnum improvement)
		{
			if (!this.Improvements.Contains(improvement))
			{
				this.Improvements.Add(improvement);

				this.uiImprovementFlags |= ImprovementEnumToBit(improvement);
			}
		}

		public void RemoveImprovement(ImprovementEnum improvement)
		{
			if (this.Improvements.Contains(improvement))
			{
				this.Improvements.Remove(improvement);

				this.uiImprovementFlags |= ImprovementEnumToBit(improvement);
				this.uiImprovementFlags ^= ImprovementEnumToBit(improvement);
			}
		}

		public bool HasImprovement(ImprovementEnum improvement)
		{
			return this.Improvements.Contains(improvement);
		}

		/// <summary>
		/// Sets the new owner of the city
		/// </summary>
		/// <param name="cityID">The city that is about to change ownership</param>
		/// <param name="playerID">The new owner of the city</param>
		public void SetCityOwner(GameData gameData, int cityID, int playerID)
		{
			// function body
			City city = gameData.Cities[cityID];

			// The city size should be removed from previous owner
			gameData.Players[city.PlayerID].TotalCitySize -= city.ActualSize;

			// !!! The units that belong to this city should also change ownership

			city.PlayerID = (short)playerID;
			gameData.Map[city.Position].Layer9_ActiveUnits &= 0x8;
			gameData.Map[city.Position].Layer9_ActiveUnits += playerID;
			gameData.Players[playerID].TotalCitySize += city.ActualSize;
		}

		public static City FromStream(int id, Stream stream)
		{
			City city = new City(id);

			city.ImprovementFlags = GameLoadAndSave.ReadUInt32(stream);
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
			GameLoadAndSave.WriteUInt32(stream, this.ImprovementFlags);
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
