using IRB.VirtualCPU;
using OpenCiv1.Graphics;
using OpenCiv1.UI;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace OpenCiv1
{
	public class Segment_2dc4
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;

		public Segment_2dc4(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_2dc4_0042_Randomize()
		{
			// function body
			// Instruction address 0x2dc4:0x0045, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.time(0) & 0x7fff);

			this.oParent.GameData.RandomSeed = this.oCPU.AX.UInt16;

			// Instruction address 0x2dc4:0x0054, size: 5
			this.oParent.CAPI.srand(this.oCPU.AX.UInt16);
		}

		/// <summary>
		/// Check and adjusts value to given range
		/// </summary>
		/// <param name="value"></param>
		/// <param name="minValue"></param>
		/// <param name="maxValue"></param>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public int F0_2dc4_007c_CheckValueRange(int value, int minValue, int maxValue)
		{
			// function body
			if (minValue > maxValue)
			{
				// do nothing, just return minimum value
				this.oParent.Log.WriteLine($"CheckValueRange({value}, {minValue}, {maxValue}), Minimum value is greater than maximum value.");
				return minValue;
				//throw new Exception("Minimum value is greater than maximum value");
			}

			int iRetVal = Math.Min(Math.Max(value, minValue), maxValue);
			this.oCPU.AX.UInt16 = (ushort)((short)iRetVal);

			return iRetVal;
		}

		/// <summary>
		/// Tests if city is present at given coordinates
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>City ID, otherwise -1</returns>
		public int F0_2dc4_00ba_GetCityID(int x, int y)
		{
			this.oCPU.Log.EnterBlock($"F0_2dc4_00ba({x}, {y})");

			// function body
			int retval = -1;

			for (int i = 0; i < 128; i++)
			{
				City city = this.oParent.GameData.Cities[i];

				if (city.StatusFlag != 0xff && city.Position.X == x && city.Position.Y == y)
				{
					retval = i;
					break;
				}
			}

			this.oCPU.AX.UInt16 = (ushort)((short)retval);

			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_00ba");

			return retval;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2dc4_0102(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2dc4_0102({xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x8);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 0x0);

		L0118:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.CMP_UInt8(this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L015f;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			// Instruction address 0x2dc4:0x0142, size: 3
			F0_2dc4_0289_GetShortestDistance(
				xPos,
				yPos,
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].Position.X,
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.GE) goto L015f;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.AX.UInt16);

		L015f:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x80);
			if (this.oCPU.Flags.L) goto L0118;
			
			this.oParent.Var_6c9a = this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6));
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_0102");

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public ushort F0_2dc4_0177(int playerID, int unitID, int x, int y)
		{
			this.oCPU.Log.EnterBlock($"F0_2dc4_0177({playerID}, {unitID}, {x}, {y})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x8);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 0x0);
			goto L01d2;

		L018f:
			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)((short)playerID));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			// Instruction address 0x2dc4:0x01b2, size: 3
			F0_2dc4_0289_GetShortestDistance(
				x, y,
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].Position.X, this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.GE) goto L01cf;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.AX.UInt16);

		L01cf:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))));

		L01d2:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x80);
			if (this.oCPU.Flags.GE) goto L01fa;
			
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)((short)playerID));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			if (this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].TypeID == -1)
				goto L01cf;

			this.oCPU.AX.UInt16 = (ushort)((short)unitID);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L018f;
			goto L01cf;

		L01fa:
			this.oParent.Var_6c9a = this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6));
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_0177");

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="xPos1"></param>
		/// <param name="yPos1"></param>
		/// <returns></returns>
		public int F0_2dc4_0289_GetShortestDistance(int xPos, int yPos, int xPos1, int yPos1)
		{
			// function body
			return F0_2dc4_0208_GetShortestDistance(xPos - xPos1, yPos - yPos1);
		}

		/// <summary>
		/// Combines the X and Y positions
		/// </summary>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <returns></returns>
		public int F0_2dc4_0208_GetShortestDistance(int width, int height)
		{
			// function body			
			width = Math.Abs(width);
			height = Math.Abs(height);

			// take into account either map direction from median
			if (width > 40)
			{
				width = 80 - width;
			}

			if (width > height)
			{
				height = (height / 2) + width;
				this.oCPU.AX.UInt16 = (ushort)((short)height);

				return height;
			}
			else
			{
				width = (width / 2) + height;
				this.oCPU.AX.UInt16 = (ushort)((short)width);

				return width;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2dc4_0243(int xPos, int yPos)
		{
			this.oParent.Log.EnterBlock($"F0_2dc4_0243({xPos}, {yPos})");

			// function body
			xPos = Math.Abs(xPos);

			if (xPos > 40)
			{
				xPos = 80 - xPos;
			}

			yPos = Math.Abs(yPos);

			if (xPos > yPos)
			{
				this.oCPU.AX.UInt16 = (ushort)((short)xPos * 2 + yPos);
			}
			else
			{
				this.oCPU.AX.UInt16 = (ushort)((short)yPos * 2 + xPos);
			}

			this.oParent.Log.ExitBlock("F0_2dc4_0243");

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <returns></returns>
		public ushort F0_2dc4_02cd(int playerID)
		{
			this.oCPU.Log.EnterBlock($"F0_2dc4_02cd({playerID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x6);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x0);
			goto L02fe;

		L02e0:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), this.oCPU.AX.UInt16));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))));

		L02e9:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.LowUInt8 = (byte)this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));
			if (this.oCPU.Flags.GE) goto L02e0;

		L02fb:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))));

		L02fe:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x80);
			if (this.oCPU.Flags.GE) goto L0325;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			if (this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].PlayerID != playerID ||
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].StatusFlag == 0xff)
				goto L02fb;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x1);
			goto L02e9;

		L0325:
			// Instruction address 0x2dc4:0x0329, size: 3
			F0_2dc4_0337(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6));
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_02cd");

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// Converts population to string
		/// </summary>
		/// <param name="population"></param>
		public void F0_2dc4_0337(int population)
		{
			// function body
			if (population >= 100)
			{
				// Instruction address 0x2dc4:0x035f, size: 5
				this.oParent.CAPI.strcat(0xba06, this.oParent.CAPI.itoa(population / 100, 10));

				// Instruction address 0x2dc4:0x036f, size: 5
				this.oParent.CAPI.strcat(0xba06, ",");

				if ((population % 100) < 10)
				{
					// Instruction address 0x2dc4:0x038d, size: 5
					this.oParent.CAPI.strcat(0xba06, "0");
				}
			}

			// Instruction address 0x2dc4:0x03b4, size: 5
			this.oParent.CAPI.strcat(0xba06, this.oParent.CAPI.itoa(population % 100, 10));

			// Instruction address 0x2dc4:0x03c4, size: 5
			this.oParent.CAPI.strcat(0xba06, "0,000");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		public void F0_2dc4_03ce_FillRectangleWithPattern(int xPos, int yPos, int width, int height)
		{
			// function body
			if (this.oParent.Var_d762 != 0)
			{
				int iYPosTemp = yPos;
				int iHeightTemp = height;

				while (iHeightTemp > 0)
				{
					int iCellHeight = Math.Min(iHeightTemp, 16);
					int iXPosTemp = xPos;
					int iWidthTemp = width;

					while (iWidthTemp > 0)
					{
						int iCellWidth = Math.Min(iWidthTemp, 32);

						// Instruction address 0x2dc4:0x0435, size: 5
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 
							288, 120, iCellWidth, iCellHeight, this.oParent.Var_aa_Rectangle, iXPosTemp, iYPosTemp);

						iXPosTemp += iCellWidth;
						iWidthTemp -= iCellWidth;
					}

					iYPosTemp += iCellHeight;
					iHeightTemp -= iCellHeight;
				}
			}
			else
			{
				// Instruction address 0x2dc4:0x0471, size: 5
				this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos, yPos, width, height, 7);
			}		
		}

		/// <summary>
		/// Reads the palette from file and applies to screeen 0
		/// </summary>
		/// <param name="filenamePtr"></param>
		public void F0_2dc4_047d_ReadAndSetPalette(ushort filenamePtr)
		{
			this.oCPU.Log.EnterBlock($"F0_2dc4_047d_ReadAndSetPalette(0x{filenamePtr:x4})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x2);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L04d8;

			// Instruction address 0x2dc4:0x0492, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, filenamePtr, 0xbdee);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x0);

		L049f:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.SI.UInt16 = this.oCPU.BX.UInt16;
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x6b34));
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xbdf4), this.oCPU.AX.LowUInt8);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x30);
			if (this.oCPU.Flags.L) goto L049f;
			
			// Instruction address 0x2dc4:0x04b9, size: 5
			this.oParent.Graphics.F0_VGA_0162_SetColorsFromColorStruct(0xbdee);
			
			// Instruction address 0x2dc4:0x04d2, size: 3
			this.oParent.Graphics.SetPaletteColor(0x2d, GBitmap.Color18ToColor(0x33, 0x27, 0x19));

		L04d8:
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_047d_ReadAndSetPalette");
		}

		public void F0_2dc4_0523_FreeResource(int bitmapID, ushort textPtr)
		{
			string text = this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.UInt16, textPtr));

			F0_2dc4_0523_FreeResource(bitmapID, text);
		}

		/// <summary>
		/// Free resource, show Memory error dialog if error happens
		/// </summary>
		/// <param name="bitmapID"></param>
		/// <param name="stringPtr"></param>
		public void F0_2dc4_0523_FreeResource(int bitmapID, string text)
		{
			this.oCPU.Log.EnterBlock($"F0_2dc4_0523_FreeResource({bitmapID}, \"{text}\")");

			// function body
			// ignore unallocated bitmaps
			if (bitmapID != 0)
			{
				// Instruction address 0x2dc4:0x0529, size: 5
				if (this.oParent.Graphics.Bitmaps.ContainsKey(bitmapID))
				{
					this.oParent.Graphics.Bitmaps.RemoveByKey(bitmapID);
				}
				else
				{
					// Instruction address 0x2dc4:0x0570, size: 5
					if (string.IsNullOrEmpty(text))
					{
						MessageBox.Show("Unspecified memory error", "Memory error", MessageBoxIcon.Error, MessageBoxButtons.OK);
					}
					else
					{
						MessageBox.Show(text, "Memory error", MessageBoxIcon.Error, MessageBoxButtons.OK);
					}
				}
			}
		}


		/// <summary>
		/// ?
		/// </summary>
		public void F0_2dc4_05dd()
		{
			this.oCPU.Log.EnterBlock("F0_2dc4_05dd()");

			// function body
			// Instruction address 0x2dc4:0x05ed, size: 5
			this.oParent.CommonTools.F0_1000_0382_AddPaletteCycleSlot(1, 15, 96, 103);

			// Instruction address 0x2dc4:0x0605, size: 5
			this.oParent.CommonTools.F0_1000_0382_AddPaletteCycleSlot(2, 15, 104, 111);

			// Instruction address 0x2dc4:0x061d, size: 5
			this.oParent.CommonTools.F0_1000_0382_AddPaletteCycleSlot(3, 15, 112, 127);

			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_05dd");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_2dc4_0626()
		{
			// function body
			if (this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x2fec) == 0 && this.oParent.Var_d762 != 0)
			{
				// Instruction address 0x2dc4:0x0638, size: 5
				this.oParent.CommonTools.F0_1000_03fa_StartPaletteCycleSlot(1);

				// Instruction address 0x2dc4:0x0644, size: 5
				this.oParent.CommonTools.F0_1000_03fa_StartPaletteCycleSlot(2);

				// Instruction address 0x2dc4:0x0650, size: 5
				this.oParent.CommonTools.F0_1000_03fa_StartPaletteCycleSlot(3);
			}
		
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x2fec, 0x1);
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_2dc4_065f()
		{
			this.oCPU.Log.EnterBlock("F0_2dc4_065f()");

			// function body
			if (this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x2fec) != 0 && this.oParent.Var_d762 != 0)
			{
				// Instruction address 0x2dc4:0x0671, size: 5
				this.oParent.CommonTools.F0_1000_042b_StopPaletteCycleSlot(1);

				// Instruction address 0x2dc4:0x067d, size: 5
				this.oParent.CommonTools.F0_1000_042b_StopPaletteCycleSlot(2);

				// Instruction address 0x2dc4:0x0689, size: 5
				this.oParent.CommonTools.F0_1000_042b_StopPaletteCycleSlot(3);
			}

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x2fec, 0x0);

			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_065f");
		}
	}
}
