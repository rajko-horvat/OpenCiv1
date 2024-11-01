using System;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;
using OpenCiv1.UI;
using Tmds.DBus.Protocol;

namespace OpenCiv1
{
	public class Segment_2dc4
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public Segment_2dc4(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_2dc4_0042_Randomize()
		{
			// function body
			// Instruction address 0x2dc4:0x0045, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.time(0) & 0x7fff);

			this.oGameData.RandomSeed = this.oCPU.AX.Word;

			// Instruction address 0x2dc4:0x0054, size: 5
			this.oParent.MSCAPI.srand(this.oCPU.AX.Word);
		}

		/// <summary>
		/// Check and adjusts value to a given range
		/// </summary>
		/// <param name="value">Value to compare</param>
		/// <param name="minValue">Minumum allowed value</param>
		/// <param name="maxValue">Maximum allowed value</param>
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
			this.oCPU.AX.Word = (ushort)((short)iRetVal);

			return iRetVal;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2dc4_00ba(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2dc4_00ba({xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L00cb;

		L00c8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L00cb:
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) >= 128)
				goto L00fa;

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].StatusFlag == 0xff ||
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.X != xPos ||
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.Y != yPos)
				goto L00c8;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			goto L00fd;

		L00fa:
			this.oCPU.AX.Word = 0xffff;

		L00fd:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_00ba");

			return this.oCPU.AX.Word;
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
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x8);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);

		L0118:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8(this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L015f;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x2dc4:0x0142, size: 3
			this.oCPU.AX.Word = (ushort)((short)this.oGameData.Map.GetDistance(
				xPos,
				yPos,
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.X,
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.Y));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L015f;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

		L015f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x80);
			if (this.oCPU.Flags.L) goto L0118;
			
			this.oParent.Var_6c9a = this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_0102");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2dc4_0177(short playerID, short unitID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2dc4_0177({playerID}, {unitID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x8);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L01d2;

		L018f:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x2dc4:0x01b2, size: 3
			this.oCPU.AX.Word = (ushort)((short)this.oGameData.Map.GetDistance(
				xPos, yPos,
				this.oGameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.X, 
				this.oGameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.Y));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L01cf;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

		L01cf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L01d2:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x80);
			if (this.oCPU.Flags.GE) goto L01fa;
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oGameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].TypeID == -1)
				goto L01cf;

			this.oCPU.AX.Word = (ushort)unitID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L018f;
			goto L01cf;

		L01fa:
			this.oParent.Var_6c9a = this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_0177");

			return this.oCPU.AX.Word;
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
				this.oCPU.AX.Word = (ushort)((short)xPos * 2 + yPos);
			}
			else
			{
				this.oCPU.AX.Word = (ushort)((short)yPos * 2 + xPos);
			}

			this.oParent.Log.ExitBlock("F0_2dc4_0243");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <returns></returns>
		public ushort F0_2dc4_02cd(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F0_2dc4_02cd({playerID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x6);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L02fe;

		L02e0:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L02e9:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.GE) goto L02e0;

		L02fb:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L02fe:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.GE) goto L0325;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].PlayerID != playerID ||
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].StatusFlag == 0xff)
				goto L02fb;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);
			goto L02e9;

		L0325:
			// Instruction address 0x2dc4:0x0329, size: 3
			F0_2dc4_0337(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_02cd");

			return this.oCPU.AX.Word;
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
				this.oParent.MSCAPI.strcat(0xba06, this.oParent.MSCAPI.itoa(population / 100, 10));

				// Instruction address 0x2dc4:0x036f, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ",");

				if ((population % 100) < 10)
				{
					// Instruction address 0x2dc4:0x038d, size: 5
					this.oParent.MSCAPI.strcat(0xba06, "0");
				}
			}

			// Instruction address 0x2dc4:0x03b4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.MSCAPI.itoa(population % 100, 10));

			// Instruction address 0x2dc4:0x03c4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "0,000");
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

		/// <summary>
		/// Reads the palette from file and applies to screeen 0
		/// </summary>
		/// <param name="filenamePtr"></param>
		public void F0_2dc4_047d_ReadAndSetPalette(ushort filenamePtr)
		{
			this.oCPU.Log.EnterBlock($"F0_2dc4_047d_ReadAndSetPalette(0x{filenamePtr:x4})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x2dc4:0x0492, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, this.oCPU.ReadString(this.oCPU.DS.Word, filenamePtr), out this.oParent.Var_bdee);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L049f:
			this.oParent.Var_bdee[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 6] = 
				this.oParent.Var_6b34[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x30);
			if (this.oCPU.Flags.L) goto L049f;
			
			// Instruction address 0x2dc4:0x04b9, size: 5
			this.oParent.Graphics.F0_VGA_0162_SetColorsFromColorStruct(this.oParent.Var_bdee);
			
			// Instruction address 0x2dc4:0x04d2, size: 3
			this.oParent.Graphics.SetPaletteColor(0x2d, GBitmap.Color18ToColor(0x33, 0x27, 0x19));

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_047d_ReadAndSetPalette");
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

			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_0523_FreeResource");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_2dc4_05dd()
		{
			this.oCPU.Log.EnterBlock("F0_2dc4_05dd()");

			// function body
			// Instruction address 0x2dc4:0x05ed, size: 5
			this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(1, 15, 96, 103);

			// Instruction address 0x2dc4:0x0605, size: 5
			this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(2, 15, 104, 111);

			// Instruction address 0x2dc4:0x061d, size: 5
			this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(3, 15, 112, 127);

			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_05dd");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_2dc4_0626()
		{
			// function body
			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2fec) == 0)
			{
				// Instruction address 0x2dc4:0x0638, size: 5
				this.oParent.Segment_1000.F0_1000_03fa_StartPaletteCycleSlot(1);

				// Instruction address 0x2dc4:0x0644, size: 5
				this.oParent.Segment_1000.F0_1000_03fa_StartPaletteCycleSlot(2);

				// Instruction address 0x2dc4:0x0650, size: 5
				this.oParent.Segment_1000.F0_1000_03fa_StartPaletteCycleSlot(3);
			}
		
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2fec, 0x1);
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_2dc4_065f()
		{
			this.oCPU.Log.EnterBlock("F0_2dc4_065f()");

			// function body
			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2fec) != 0)
			{
				// Instruction address 0x2dc4:0x0671, size: 5
				this.oParent.Segment_1000.F0_1000_042b_StopPaletteCycleSlot(1);

				// Instruction address 0x2dc4:0x067d, size: 5
				this.oParent.Segment_1000.F0_1000_042b_StopPaletteCycleSlot(2);

				// Instruction address 0x2dc4:0x0689, size: 5
				this.oParent.Segment_1000.F0_1000_042b_StopPaletteCycleSlot(3);
			}

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2fec, 0x0);

			// Far return
			this.oCPU.Log.ExitBlock("F0_2dc4_065f");
		}
	}
}
