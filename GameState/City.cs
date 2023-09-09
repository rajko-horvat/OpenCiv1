using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCiv1.GameState
{
	public class City
	{
		public string Name = "";
		public byte BuildingsFlag0 = 0;
		public byte BuildingsFlag1 = 0;
		public byte BuildingsFlag2 = 0;
		public sbyte BuildingsFlag3 = 0;
		public sbyte XPosition = 0;
		public sbyte YPosition = 0;
		public byte StatusFlag = 0;
		public sbyte ActualSize = 0;
		public sbyte VisibleSize = 0;
		public byte CurrentProductionID = 0;
		public sbyte BaseTrade = 0;
		public sbyte OwningCivilization = 0;
		public short FoodCount = 0;
		public short ShieldsCount = 0;
		public byte WorkersFlag0 = 0;
		public byte WorkersFlag1 = 0;
		public byte WorkersFlag2 = 0;
		public byte WorkersFlag3 = 0;
		public byte WorkersFlag4 = 0;
		public byte WorkersFlag5 = 0;
		public byte TradeCity1 = 0;
		public byte TradeCity2 = 0;
		public byte TradeCity3 = 0;
		public byte Unknown_cb27 = 0;
		public byte Unknown_cb28 = 0;
	}
}
