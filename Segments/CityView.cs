using IRB.VirtualCPU;
using System;

namespace OpenCiv1
{
	public class CityView
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public CityView(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F19_0000_0000(short cityID, ushort param2)
		{
			this.oCPU.Log.EnterBlock("'F19_0000_0000'(Cdecl, Far) at 0x0000:0x0000");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x186);

			City oCity = this.oParent.GameState.Cities[cityID];
			
			int iTechnologyCount = this.oParent.GameState.Players[oCity.PlayerID].DiscoveredTechnologyCount >> 1;
			int[,] aCityLayout = new int[19, 12];
			int i1, i2, i3, i4, i5, i6, i7, i8, i9, i10, i11;
			int iDirection, iValue;

			for (int i = 0; i < 19; i++)
			{
				for (int j = 0; j < 12; j++)
				{
					aCityLayout[i, j] = -1;
				}
			}

			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x80), 0x0);

			if (this.oParent.MSCAPI.strlen(0xba06) < 120)
			{
				// Instruction address 0x0000:0x004d, size: 5
				this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x80), 0xba06);
			}

			// RNG based on city name
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);
			string sCityName = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, 0xba06));
			RandomMT19937 oRNG = new RandomMT19937((uint)sCityName.GetHashCode());

			i1 = 9;
			i2 = 11;
			i3 = 0;
			i4 = 0;
			i5 = 0;

			while ((oCity.ActualSize << 3) > i5)
			{
				if (aCityLayout[i1, i2] != -1)
				{
					i4++;

					if (i4 < 999)
					{
						i5--;
					}
				}
				else
				{
					// Instruction address 0x0000:0x0195, size: 5
					i7 = this.oParent.Segment_2dc4.F0_2dc4_0208((short)(i1 - 9), (short)(i2 - 10));

					aCityLayout[i1, i2] = Math.Min(Math.Max(((iTechnologyCount - i7) / 3) - oRNG.Next(2), iTechnologyCount / 6), Math.Min((oCity.ActualSize / 4) + 6, 9));

					if ((i7 * i7) > ((int)oCity.ActualSize << 3))
					{
						i1 = 9;
						i2 = 11;
					}
				}

				i6 = oRNG.Next(8) + 1;

				i1 = Math.Min(Math.Max(this.oCPU.ReadInt16(this.oCPU.DS.Word, CPU.ToUInt16((i6 << 1) + 0x1882)) + i1, 0), 18);
				i2 = Math.Min(Math.Max(this.oCPU.ReadInt16(this.oCPU.DS.Word, CPU.ToUInt16((i6 << 1) + 0x18e4)) + (ushort)i2, 0), 11);

				i5++;
			}

			i6 = 4 + oRNG.Next(2);

			for (i5 = 2; i5 < 17; i5++)
			{
				aCityLayout[i5, i6] = -2;
			}

			aCityLayout[18, i6] = -1;
			aCityLayout[0, i6] = -1;

			i6 = 8 + oRNG.Next(2);

			for (i5 = 2; i5 < 17; i5++)
			{
				aCityLayout[i5, i6] = -2;
			}

			aCityLayout[18, i6] = -1;
			aCityLayout[0, i6] = -1;

			i8 = i6;

			i6 = 9 + oRNG.Next(4);

			for (i5 = 1; i5 < 12; i5++)
			{
				aCityLayout[i6 - ((i5 + 1) >> 1), i5] = -2;
			}

			i6 = 14 + oRNG.Next(4);

			for (i5 = 1; i5 < 12; i5++)
			{
				aCityLayout[i6 - ((i5 + 1) >> 1), i5] = -2;
			}

			if (cityID == this.oParent.GameState.WonderCityID[7])
			{
				aCityLayout[0, 0] = 15;
				aCityLayout[0, 1] = 15;
				aCityLayout[0, 2] = 15;
				aCityLayout[1, 0] = 15;
				aCityLayout[1, 1] = 15;
				aCityLayout[2, 0] = 15;
			}

			for (i5 = 1; i5 <= 21; i5++)
			{
				if (this.oParent.GameState.WonderCityID[i5] == cityID && ((1 << i5) & 0x808a) == 0)
				{
					for (i4 = 0; i4 < 500; i4++)
					{
						i1 = oRNG.Next(15) + 1;
						i2 = oRNG.Next(10) + 1;

						iDirection = 0;

						// ??? this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x17d)), 0x0);
						if (aCityLayout[i1 - 1, i2 + 1] >= 0)
						{
							iDirection |= 1;
						}

						// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x172)), 0x0);
						if (aCityLayout[i1, i2] >= 0)
						{
							iDirection |= 1;
						}

						// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x171)), 0x0);
						if (aCityLayout[i1, i2 + 1] >= 0)
						{
							iDirection |= 1;
						}

						// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x166)), 0x0);
						if (aCityLayout[i1 + 1, i2] >= 0)
						{
							iDirection |= 1;
						}

						// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x165)), 0x0);
						if (aCityLayout[i1 + 1, i2 + 1] >= 0)
						{
							iDirection |= 1;
						}

						// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x15a)), 0x0);
						if (aCityLayout[i1 + 2, i2] >= 0)
						{
							iDirection |= 1;
						}

						if (i4 > 400)
						{
							iDirection |= 1;
						}

						// ??? this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x17d)), 0xf);
						if (aCityLayout[i1 - 1, i2 + 1] >= 15)
						{
							iDirection |= 2;
						}

						// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x172)), 0xf);
						if (aCityLayout[i1, i2] >= 15)
						{
							iDirection |= 2;
						}

						// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x171)), 0xf);
						if (aCityLayout[i1, i2 + 1] >= 15)
						{
							iDirection |= 2;
						}

						// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x166)), 0xf);
						if (aCityLayout[i1 + 1, i2] >= 15)
						{
							iDirection |= 2;
						}

						//this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x165)), 0xf);
						if (aCityLayout[i1 + 1, i2 + 1] >= 15)
						{
							iDirection |= 2;
						}

						// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x15a)), 0xf);
						if (aCityLayout[i1 + 2, i2] >= 15)
						{
							iDirection |= 2;
						}

						// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x159)), 0xf);
						if (aCityLayout[i1 + 2, i2 + 1] >= 15)
						{
							iDirection |= 2;
						}

						// ??? this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x17d)), 0xfe);
						if (aCityLayout[i1 - 1, i2 + 1] == -2)
						{
							iDirection |= 2;
						}

						// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x172)), 0xfe);
						if (aCityLayout[i1, i2] == -2)
						{
							iDirection |= 2;
						}

						// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x171)), 0xfe);
						if (aCityLayout[i1, i2 + 1] == -2)
						{
							iDirection |= 2;
						}

						// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x166)), 0xfe);
						if (aCityLayout[i1 + 1, i2] == -2)
						{
							iDirection |= 2;
						}

						// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x165)), 0xfe);
						if (aCityLayout[i1 + 1, i2 + 1] == -2)
						{
							iDirection |= 2;
						}

						if (iDirection == 1)
							break;
					}

					if (i4 < 500)
					{
						aCityLayout[i1 - 1, i2 + 1] = 15;
						aCityLayout[i1, i2] = i5 + 64;
						aCityLayout[i1, i2 + 1] = 15;
						aCityLayout[i1 + 1, i2] = 15;
						aCityLayout[i1 + 1, i2 + 1] = 15;
						aCityLayout[i1 + 1, i2 - 1] = 15;
						aCityLayout[i1 + 2, i2] = 15;
						aCityLayout[i1 + 2, i2 - 1] = 15;
						aCityLayout[i1 + 2, i2 + 1] = 15;
						aCityLayout[i1 + 3, i2 - 1] = 15;

						if (i2 < 7 && (aCityLayout[i1 + 1, i2 + 2] & 7) == 0)
						{
							aCityLayout[i1 + 1, i2 + 2] = -1;
						}
					}
				}
			}

			for (i5 = 23; i5 > 0; i5--)
			{
				while (i5 > 0 && (((1 << i5) & this.oCPU.WordsToDWord(oCity.BuildingFlags0, oCity.BuildingFlags1)) == 0 ||
					i5 == 7 || i5 == 8 || i5 == 12 || i5 == 18 || i5 == 19))
				{
					i5--;
				}

				if (i5 < 1)
					break;

				for (i4 = 0; i4 < 500; i4++)
				{
					i1 = oRNG.Next(16) + 1;
					i2 = oRNG.Next(10) + 1;

					iDirection = 0;

					// ??? this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x17d)), 0x0);
					if (aCityLayout[i1 - 1, i2 + 1] >= 0)
					{
						iDirection |= 1;
					}

					// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x172)), 0x0);
					if (aCityLayout[i1, i2] >= 0)
					{
						iDirection |= 1;
					}

					// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x171)), 0x0);
					if (aCityLayout[i1, i2 + 1] >= 0)
					{
						iDirection |= 1;
					}

					// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x166)), 0x0);
					if (aCityLayout[i1 + 1, i2] >= 0)
					{
						iDirection |= 1;
					}

					// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x165)), 0x0);
					if (aCityLayout[i1 + 1, i2 + 1] >= 0)
					{
						iDirection |= 1;
					}

					if (i4 > 350)
					{
						iDirection |= 1;
					}

					// ??? this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x17d)), 0xf);
					if (aCityLayout[i1 - 1, i2 + 1] >= 15)
					{
						iDirection |= 2;
					}

					//this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x172)), 0xf);
					if (aCityLayout[i1, i2] >= 15)
					{
						iDirection |= 2;
					}

					// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x171)), 0xf);
					if (aCityLayout[i1, i2 + 1] >= 15)
					{
						iDirection |= 2;
					}

					// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x166)), 0xf);
					if (aCityLayout[i1 + 1, i2] >= 15)
					{
						iDirection |= 2;
					}

					// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x165)), 0xf);
					if (aCityLayout[i1 + 1, i2 + 1] >= 15)
					{
						iDirection |= 2;
					}

					// ??? this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x17d)), 0xfe);
					if (aCityLayout[i1 - 1, i2 + 1] == -2)
					{
						iDirection |= 2;
					}

					//this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x172)), 0xfe);
					if (aCityLayout[i1, i2] == -2)
					{
						iDirection |= 2;
					}

					//this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x171)), 0xfe);
					if (aCityLayout[i1, i2 + 1] == -2)
					{
						iDirection |= 2;
					}

					// this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x166)), 0xfe);
					if (aCityLayout[i1 + 1, i2] == -2)
					{
						iDirection |= 2;
					}

					//this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x165)), 0xfe);
					if (aCityLayout[i1 + 1, i2 + 1] == -2)
					{
						iDirection |= 2;
					}

					if (iDirection == 1)
						break;
				}

				if (i4 < 500)
				{
					aCityLayout[i1 - 1, i2 + 1] = 15;
					aCityLayout[i1, i2] = i5 + 15;
					aCityLayout[i1, i2 + 1] = 15;
					aCityLayout[i1 + 1, i2] = 15;
					aCityLayout[i1 + 1, i2 + 1] = 15;

					if (i2 < 7)
					{
						// this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BP.Word + (i1 * 12 + i2) - 0x164)), 0x7);
						if ((aCityLayout[i1 + 1, i2 + 2] & 7) == 0)
						{
							aCityLayout[i1 + 1, i2 + 2] = -1;
						}
					}
				}
			}

			if ((oCity.BuildingFlags1 & 8) != 0)
			{
				aCityLayout[17, 7] = 34; // this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x9f), 0x22);
				aCityLayout[17, 8] = 15; // this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x9e), 0xf);
				aCityLayout[18, 7] = 15; // this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x93), 0xf);
				aCityLayout[18, 8] = 15; // this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x92), 0xf);
			}
		
			if ((oCity.BuildingFlags0 & 0x100) != 0)
			{
				aCityLayout[0, i8 - 1] = 23; // this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + i8 - 0x173), 23);
				aCityLayout[0, i8] = 15; // this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + i8 - 0x172), 0xf);
				aCityLayout[1, i8] = 15; // this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + i8 - 0x166), 0xf);
				aCityLayout[1, i8 + 1] = 15; // this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + i8 - 0x167), 0xf);
				aCityLayout[2, i8] = 15; // this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + i8 - 0x15a), 0xf);
				aCityLayout[2, i8 + 1] = 15; // this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + i8 - 0x15b), 0xf);
			}
		
			// Instruction address 0x0000:0x08e4, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x08f0, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(1, 1);

			F19_0000_137f(param2, oCity.PlayerID, cityID);

		L0913:
			// Instruction address 0x0000:0x091b, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4e98, 0);

			i5 = 1;
			goto L093d;

		L092b:
			if (((1 << i9) & 0x808a) != 0)
				goto L0977;

		L0939:
			i5++;

		L093d:
			if (i5 > 7)
				goto L09df;

			i9 = i5;
			
			if (i5 == 2)
			{
				i9 = 15;
			}
		
			if (this.oParent.GameState.WonderCityID[i9] != cityID)
				goto L0939;

			if ((i9 + 24) != param2)
				goto L092b;

			goto L0939;

		L0977:
			if (i9 <= 7)
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(0x3767, (ushort)((i9 << 3) + 0x2));
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x6);
			}
			this.oCPU.PushWord(this.oCPU.AX.Word);
		
			this.oCPU.AX.Word = (ushort)((i9 == 3) ? 80 : 0);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)((this.oCPU.ReadInt16(0x3767, (ushort)((i9 << 3) + 0x0)) < 10) ? 0xffff : 2));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(0x3767, (ushort)((i9 << 3) + 0x0)));

			// Instruction address 0x0000:0x09d4, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				(short)this.oCPU.AX.Word,
				(short)this.oCPU.PopWord(),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((i9 << 1) + 0x68a0)));

			goto L0939;

		L09df:
			if ((oCity.BuildingFlags1 & 0x4) == 0 || param2 == 19)
				goto L0a2f;

			i5 = (cityID == this.oParent.GameState.WonderCityID[7]) ? 69 : 0;

			goto L0a27;

		L0a0a:
			// Instruction address 0x0000:0x0a1a, size: 5
			this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				(short)i5, 2, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x81c4));

			i5 += 45;

		L0a27:
			if (i5 < 310)
				goto L0a0a;

		L0a2f:
			i2 = 0;
			goto L0aeb;

		L0a38:
			int iPrefixTemp = ((this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)((i11 << 1) + 0x18e4)) <= 0) ? 0 : -1);

		L0a4c:
			int iXTemp = iPrefixTemp + this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)((i11 << 1) + 0x1882)) + i1;
			int iYTemp = this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)((i11 << 1) + 0x18e4)) + i2;

			if (iYTemp < 12 && aCityLayout[iXTemp, iYTemp] >= 0)
			{
				iDirection = 1;
			}
		
			i11++;

		L0a7a:
			if (i11 > 8)
				goto L0a9a;

			if ((i2 & 0x1) == 0)
				goto L0a38;

			if (this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)((i11 << 1) + 0x18e4)) >= 0)
			{
				iPrefixTemp = 0;
			}
			else
			{
				iPrefixTemp = 1;
			}
			goto L0a4c;

		L0a9a:
			if (iDirection != 0)
				goto L0ab3;

			aCityLayout[i1, i2] = -1;

		L0ab3:
			i1++;

		L0ab7:
			if (i1 >= 19)
				goto L0ae7;

			iValue = aCityLayout[i1, i2];

			if (iValue != -2)
				goto L0ab3;

			iDirection = 0;
			i11 = 1;

			goto L0a7a;

		L0ae7:
			i2++;

		L0aeb:
			if (i2 > 11)
				goto L0afa;

			i1 = 0;
			goto L0ab7;

		L0afa:
			i2 = 0;
			goto L0c9a;

		L0b03:
			if (iValue != -2)
				goto L0c05;

			i10 = 0;
			i11 = 1;
			goto L0b68;

		L0b1b:
			iPrefixTemp = (this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)((i11 << 1) + 0x18e4)) <= 0) ? 0 : -1;

		L0b2f:
			iXTemp = iPrefixTemp + this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)((i11 << 1) + 0x1882)) + i1;
			iYTemp = this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)((i11 << 1) + 0x18e4)) + i2;

			if ((i11 & 1) != 0)
			{
				i10 >>= 1;

				if (iYTemp < 12 && aCityLayout[iXTemp, iYTemp] == -2)
				{
					i10 |= 8;
				}
			}
		
			i11++;

		L0b68:
			if (i11 > 8)
				goto L0b88;

			if ((i2 & 1) == 0)
				goto L0b1b;

			iPrefixTemp = (this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)((i11 << 1) + 0x18e4)) >= 0) ? 0 : 1;

			goto L0b2f;

		L0b88:
			F19_0000_0ff4((ushort)i1, (ushort)i2, (ushort)i10);

		L0b9b:
			i1++;

		L0b9f:
			if (i1 >= 19)
				goto L0c96;

			iValue = aCityLayout[i1, i2];

			if (iValue != -1)
				goto L0bf2;

			if (i1 <= 2 || aCityLayout[i1 - 1, i2] == -1 || ((i1 + i2) & 1) == 0)
				goto L0bf2;

			F19_0000_0ff4((ushort)i1, (ushort)i2, 0);

		L0bf2:
			if (iValue == -1)
				goto L0b9b;

			if (iValue != 15)
				goto L0b03;

			goto L0b9b;

		L0c05:
			if (iValue >= 16)
				goto L0c61;

			if (iValue >= 2)
				goto L0c41;

			F19_0000_102e((ushort)i1, (ushort)i2, (ushort)(((iValue & 1) << 1) + (cityID & 1)), (ushort)(iValue >> 1));
			
			goto L0b9b;

		L0c41:
			F19_0000_102e((ushort)i1, (ushort)i2, (ushort)(((i1 + i2) & 1) + ((iValue & 1) << 1)), (ushort)(iValue >> 1));

			goto L0b9b;

		L0c61:
			if (param2 + 14 != iValue && param2 + 40 != iValue)
			{
				F19_0000_106c((ushort)i1, (ushort)i2, (ushort)(iValue - 16));
			}

			goto L0b9b;

		L0c96:
			i2++;

		L0c9a:
			if (i2 > 11)
				goto L0caa;

			i1 = 0;

			goto L0b9f;

		L0caa:
			if ((oCity.BuildingFlags0 & 0x80) == 0 || param2 == 8)
				goto L0d0f;

			i5 = 0;

		L0cc5:
			if (i5 == 172)
			{
				i5 += 19;
			}
		
			// Instruction address 0x0000:0x0ce2, size: 5
			this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				(short)i5, 108, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x81ce));

			i5 += 43;

			if (i5 < 320)
				goto L0cc5;

			// Instruction address 0x0000:0x0d07, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				142, 108, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x81ae));

		L0d0f:
			if ((oCity.BuildingFlags0 & 0x1000) == 0 || param2 == 13)
				goto L0d67;

			i5 = 0;

		L0d2b:
			// Instruction address 0x0000:0x0d3b, size: 5
			this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				(short)i5, 115, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x81cc));

			i5 += 46;
			
			if (i5 < 310)
				goto L0d2b;

			// Instruction address 0x0000:0x0d5f, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 115, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x81b8));

		L0d67:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x6);

			if (this.oParent.MSCAPI.strlen((ushort)(this.oCPU.BP.Word - 0x80)) == 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

				// Instruction address 0x0000:0x0d82, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x0000:0x0db1, size: 5
				this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringWithShadowToScreen0(0xba06, 160, 2, 15);

				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

				// Instruction address 0x0000:0x0dbe, size: 5
				this.oParent.Segment_1238.F0_1238_1720_GetCurrentYearAsString();

				// Instruction address 0x0000:0x0de7, size: 5
				this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringWithShadowToScreen0(0xba06, 160, 15, 15);
			}
			else
			{
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdb38, 0x1);

				// Instruction address 0x0000:0x0e03, size: 5
				this.oParent.Segment_2d05.F0_2d05_0031((ushort)(this.oCPU.BP.Word - 0x80), 80, 8, 1);

				this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x1);
			}
		
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);

			if (i3 == 0)
				goto L0e47;

			// Instruction address 0x0000:0x0e2c, size: 5
			this.oParent.Segment_1000.F0_1000_0a32(0x2c, 0);

			// Instruction address 0x0000:0x0e3c, size: 5
			this.oParent.VGADriver.F0_VGA_06b7_DrawScreenToMainScreen(1, 10);
			
			goto L0eec;

		L0e47:
			// Instruction address 0x0000:0x0e5a, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8, 0);

			this.oCPU.CMPWord(param2, 0xfffd);
			if (this.oCPU.Flags.E) goto L0e74;

			// Instruction address 0x0000:0x0e6c, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x4ea1, 1);

		L0e74:
			// Instruction address 0x0000:0x0e8c, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 320, 200,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			if (param2 != 0xfffd || this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762) == 0)
				goto L0ec1;

			// Instruction address 0x0000:0x0ea9, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x4eaa, 0xbdee);

			// Instruction address 0x0000:0x0eb9, size: 5
			this.oParent.Segment_1000.F0_1000_04aa(15, 0xbdee);

		L0ec1:
			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762) != 0)
			{
				// Instruction address 0x0000:0x0ed8, size: 5
				this.oParent.Segment_1000.F0_1000_0382(4, 15, 64, 79);

				// Instruction address 0x0000:0x0ee4, size: 5
				this.oParent.Segment_1000.F0_1000_03fa(4);
			}

		L0eec:
			if (param2 == 0xffff && i3 == 0)
			{
				// Instruction address 0x0000:0x0f01, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_0523_MemoryError(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x817a), 0x4eb3);

				F19_0000_111f(cityID, 0x18, 0x8c, 0x100);
			}
		
			this.oCPU.CMPWord(param2, 0xffff);
			if (this.oCPU.Flags.LE) goto L0f51;

			// Instruction address 0x0000:0x0f25, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0f51;
			param2 = 0xffff;
			i3 = 1;

			// Instruction address 0x0000:0x0f3d, size: 5
			this.oParent.Segment_1182.F0_1182_0134_WaitTime(60);

			// Instruction address 0x0000:0x0f45, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0f51;
			goto L0913;

		L0f51:
			if (param2 != 0xffff)
				goto L0f5e;

			if (i3 == 0)
				goto L0f6e;

		L0f5e:
			// Instruction address 0x0000:0x0f66, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_MemoryError(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x817a), 0x4eb8);

		L0f6e:
			this.oCPU.CMPWord(param2, 0xfffe);
			if (this.oCPU.Flags.E) goto L0fdb;

			// Instruction address 0x0000:0x0f74, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0f84;

			// Instruction address 0x0000:0x0f7d, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			goto L0f89;

		L0f84:
			// Instruction address 0x0000:0x0f84, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

		L0f89:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0f9c;

			// Instruction address 0x0000:0x0f94, size: 5
			this.oParent.Segment_1000.F0_1000_042b(4);

		L0f9c:
			// Instruction address 0x0000:0x0fa5, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0fd4;

			// Instruction address 0x0000:0x0fc7, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 0x140, 0xc8, 0);

			// Instruction address 0x0000:0x0fcf, size: 5
			this.oParent.Segment_1238.F0_1238_1beb();

		L0fd4:
			// Instruction address 0x0000:0x0fd4, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0626();

			goto L0fee;

		L0fdb:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0fee;

			// Instruction address 0x0000:0x0fe6, size: 5
			this.oParent.Segment_1000.F0_1000_042b(4);

		L0fee:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F19_0000_0000'");
		}

		public void F19_0000_0ff4(ushort param1, ushort param2, ushort bitmapID)
		{
			this.oCPU.Log.EnterBlock("'F19_0000_0ff4'(Cdecl, Far) at 0x0000:0x0ff4");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			// Instruction address 0x0000:0x1024, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				(short)((((param2 & 1) << 3) + (param1 << 4)) - 5),
				(short)((param2 << 3) + 0x32),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((bitmapID << 1) + 0x6880)));

			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F19_0000_0ff4'");
		}

		public void F19_0000_102e(ushort param1, ushort param2, ushort param3, ushort param4)
		{
			this.oCPU.Log.EnterBlock("'F19_0000_102e'(Cdecl, Far) at 0x0000:0x102e");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1061, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				(short)((ushort)(((param2 & 1) << 3) + (param1 << 4))),
				(short)((short)(param2 << 3) + 26),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((param3 << 1) + (param4 << 3) + 0x817a)));

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F19_0000_102e'");
		}

		public void F19_0000_106c(ushort param1, ushort param2, ushort param3)
		{
			this.oCPU.Log.EnterBlock("'F19_0000_106c'(Cdecl, Far) at 0x0000:0x106c");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			this.oCPU.CMPWord(param3, 0x30);
			if (this.oCPU.Flags.GE) goto L10b9;

			// Instruction address 0x0000:0x10a5, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(short)((ushort)(((param2 & 1) << 3) + (param1 << 4))) - 9, 
				0, 0x3e7);

			// Instruction address 0x0000:0x10b2, size: 5
			this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				(short)this.oCPU.AX.Word,
				(short)((short)(param2 << 3) + 16),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((param3 << 1) + 0x81a2)));

			goto L111a;

		L10b9:
			this.oCPU.ES.Word = 0x3767; // segment
			param3 -= 0x30;
			param2 = (ushort)((short)(param2 << 3) - this.oCPU.ReadInt16(this.oCPU.ES.Word, (ushort)((param3 << 3) + 6)) + 76);

			// Instruction address 0x0000:0x1108, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(short)((short)((param2 & 1) << 3) + (short)(param1 << 4) - 9),
				0, 0x3e7);

			// Instruction address 0x0000:0x1115, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				(short)this.oCPU.AX.Word,
				(short)((short)param2 - 10),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((param3 << 1) + 0x68a0)));

		L111a:
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F19_0000_106c'");
		}

		public void F19_0000_111f(short cityID, ushort param2, ushort param3, ushort param4)
		{
			this.oCPU.Log.EnterBlock("'F19_0000_111f'(Cdecl, Far) at 0x0000:0x111f");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x1c);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1133, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4ebc, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);
			goto L1165;

		L1145:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

		L1165:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0x9);
			if (this.oCPU.Flags.GE) goto L118c;

			// Instruction address 0x0000:0x117b, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.HumanPlayerID, 0x23);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
			{
				// Instruction address 0x0000:0x1152, size: 5
				this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
					(ushort)(((0x23 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)))) + 1),
					0x34, 0x22, 0x32);
			}
			else
			{
				// Instruction address 0x0000:0x1152, size: 5
				this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
					(ushort)(((0x23 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)))) + 1),
					1, 0x22, 0x32);
			}
			goto L1145;

		L118c:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].ActualSize;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Low);
			this.oCPU.AX.Low = 0xc;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)));
			this.oCPU.CMPWord(this.oCPU.AX.Word, param4);
			if (this.oCPU.Flags.LE) goto L11bb;

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = param4;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);

			goto L11c0;

		L11bb:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), 0xc);

		L11c0:
			// Instruction address 0x0000:0x11d7, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x70e2),
				0, this.oParent.GameState.Cities[cityID].ActualSize);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x1214, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x70e4), 
				0, this.oParent.GameState.Cities[cityID].ActualSize);
			goto L1214;

		L11ef:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			// Instruction address 0x0000:0x11fc, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				0, this.oParent.GameState.Cities[cityID].ActualSize);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			
			// Instruction address 0x0000:0x1214, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				0, this.oParent.GameState.Cities[cityID].ActualSize);

		L1214:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			
			// Instruction address 0x0000:0x123a, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oParent.GameState.Cities[cityID].ActualSize -
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xe8b8),
				0, 0x63);

			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L11ef;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);
			goto L1281;

		L1253:
			this.oCPU.SI.Word = 0;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x1270, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(short)param2,
				(short)param3,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x16)));

			param2 += this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

		L1281:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L1253;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1291;

			param2 += 8;

		L1291:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);
			goto L12c7;

		L1298:
			this.oCPU.SI.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x12b6, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(short)param2,
				(short)param3,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x16)));

			param2 += this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

		L12c7:
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe8b8));
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)));
			if (this.oCPU.Flags.G) goto L1298;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0x0);
			if (this.oCPU.Flags.E) goto L12ed;

			param2 += 8;

		L12ed:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);
			goto L1323;

		L12f4:
			this.oCPU.SI.Word = 0x4;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x1312, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(short)param2,
				(short)param3,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x16)));

			param2 += this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

		L1323:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L12f4;

			param2 += 12;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);

			goto L1363;

		L1336:
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x133e); // stack management - push return offset
			// Instruction address 0x0000:0x1339, size: 5
			this.oParent.Segment_1d12.F0_1d12_6da1();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x1352, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(short)param2,
				(short)param3,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0xc)));

			param2 += this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

		L1363:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe8b8);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L1336;

			// Instruction address 0x0000:0x1372, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_MemoryError(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x4ec4);

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F19_0000_111f'");
		}

		public void F19_0000_137f(ushort param1, short playerID, short cityID)
		{
			this.oCPU.Log.EnterBlock("'F19_0000_137f'(Cdecl, Far) at 0x0000:0x137f");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1394, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4ec8, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L13a1:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x6;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x3;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);

			// Instruction address 0x0000:0x13c0, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.DI.Word, 1, 0x1f, 0x1f);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x817a), this.oCPU.AX.Word);
			
			// Instruction address 0x0000:0x13da, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.DI.Word, 0x21, 0x1f, 0x1f);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x817e), this.oCPU.AX.Word);

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x21);

			// Instruction address 0x0000:0x13f7, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.DI.Word, 1, 0x1f, 0x1f);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x817c), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x1411, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.DI.Word, 0x21, 0x1f, 0x1f);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x8180), this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x4);
			if (this.oCPU.Flags.G) goto L1429;
			goto L13a1;

		L1429:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L1473;

		L1433:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6880), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L1473:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x10);
			if (this.oCPU.Flags.GE) goto L1499;

			// Instruction address 0x0000:0x1488, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x3a);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
			{
				// Instruction address 0x0000:0x145f, size: 5
				this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
					(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) & 0x7) * 0x18),
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) >> 3) << 3) + 0x41),
					0x18, 0x8);
			}
			else
			{
				// Instruction address 0x0000:0x145f, size: 5
				this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
					(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) & 0x7) * 0x18),
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) >> 3) << 3) + 0x51),
					0x18, 0x8);
			}
			goto L1433;

		L1499:
			// Instruction address 0x0000:0x14a0, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x25);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L14b1;

			// Instruction address 0x0000:0x14b9, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4ed5, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L14c6;

		L14b1:
			// Instruction address 0x0000:0x14b9, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4ee2, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L14c6:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = this.oCPU.INCByte(this.oCPU.CX.Low);
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, this.oParent.GameState.Cities[cityID].BuildingFlags0);
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oParent.GameState.Cities[cityID].BuildingFlags1);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.NE) goto L14fb;

			this.oCPU.AX.Word = param1;
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.E) goto L14fb;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x14);
			if (this.oCPU.Flags.LE) goto L153a;

		L14fb:
			// Instruction address 0x0000:0x1529, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) >> 2) * 0x32) + 1),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) & 0x3) * 0x32) + 1),
				0x31, 0x31);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81a2), this.oCPU.AX.Word);

		L153a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x17);
			if (this.oCPU.Flags.L) goto L14c6;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L154d:
			this.oCPU.AX.Word = (ushort)cityID;
			this.oCPU.CMPWord((ushort)this.oParent.GameState.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))], this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1596;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, 0x808a);
			if (this.oCPU.Flags.NE) goto L1596;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L157e;

			// Instruction address 0x0000:0x1576, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4eef, 0);

		L157e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

			F19_0000_1606(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x68a0), this.oCPU.AX.Word);

		L1596:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x15);
			if (this.oCPU.Flags.LE) goto L154d;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L15a9:
			this.oCPU.AX.Word = (ushort)cityID;
			this.oCPU.CMPWord((ushort)this.oParent.GameState.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))], this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L15f2;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, 0x808a);
			if (this.oCPU.Flags.E) goto L15f2;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L15da;

			// Instruction address 0x0000:0x15d2, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4efb, 0);

		L15da:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

			F19_0000_1606(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x68a0), this.oCPU.AX.Word);

		L15f2:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x15);
			if (this.oCPU.Flags.LE) goto L15a9;

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F19_0000_137f'");
		}

		public void F19_0000_1606(ushort param1)
		{
			this.oCPU.Log.EnterBlock("'F19_0000_1606'(Cdecl, Far) at 0x0000:0x1606");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			this.oCPU.ES.Word = 0x3767; // segment
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.ES.Word, 0xc), 0x12c);
			if (this.oCPU.Flags.LE) goto L164f;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

		L161f:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word <<= 3;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x4));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x0)));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x2)));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x6), this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x15);
			if (this.oCPU.Flags.LE) goto L161f;

		L164f:
			this.oCPU.SI.Word = param1;
			this.oCPU.SI.Word <<= 3;
			// Instruction address 0x0000:0x166e, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x0)),
				this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x2)),
				this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x4)),
				this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x6)));

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F19_0000_1606'");
		}

		public void F19_0000_167b(short playerID)
		{
			this.oCPU.Log.EnterBlock("'F19_0000_167b'(Cdecl, Far) at 0x0000:0x167b");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x28);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1682, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L16a0;

			// Instruction address 0x0000:0x1698, size: 5
			this.oParent.VGADriver.SetColor(0xfd, VGABitmap.Color18ToColor(3, 3, 3));

		L16a0:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x16aa); // stack management - push return offset
			// Instruction address 0x0000:0x16a5, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x16b1, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x22);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L16c0;

			goto L1743;

		L16c0:
			// Instruction address 0x0000:0x16c7, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x3a);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L16d8;

			// Instruction address 0x0000:0x16e0, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4f08, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);
			goto L16f2;

		L16d8:
			// Instruction address 0x0000:0x16e0, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4f15, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);
			goto L16f2;

		L16ef:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))));

		L16f2:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xa);
			if (this.oCPU.Flags.L) goto L16fb;
			goto L17a7;

		L16fb:
			// Instruction address 0x0000:0x1731, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) % 4) * 0x4f),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) >> 2) * 0x3d) + 2),
				0x4e, 0x3c);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20), this.oCPU.AX.Word);
			goto L16ef;

		L1743:
			// Instruction address 0x0000:0x174b, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4f22, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

		L1758:
			// Instruction address 0x0000:0x178e, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) % 4) * 0x4f) + 1),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) >> 2) * 0x42) + 1),
				0x4e, 0x41);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xa);
			if (this.oCPU.Flags.L) goto L1758;

		L17a7:
			// Instruction address 0x0000:0x17c7, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0x64, 0x140, 0x64,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 0x0);
			goto L17df;

		L17db:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x3));

		L17df:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x294);
			if (this.oCPU.Flags.L) goto L17e9;
			goto L18a2;

		L17e9:
			// Instruction address 0x0000:0x17e9, size: 5
			this.oParent.Segment_1000.F0_1000_033e_ResetTimer();
			
			// Instruction address 0x0000:0x1809, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0x64,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x64);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x7);

		L1816:
			this.oCPU.AX.Word = 0x30;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)));
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.CX.Word);
			this.oCPU.CMPWord(this.oCPU.CX.Word, 0x140);
			if (this.oCPU.Flags.GE) goto L1852;
			this.oCPU.CMPWord(this.oCPU.CX.Word, 0xffd0);
			if (this.oCPU.Flags.LE) goto L1852;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0xa;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.SI.Word = this.oCPU.DX.Word;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x184a, size: 5
			this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				(short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				0x84,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20)));

		L1852:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))));
			if (this.oCPU.Flags.NS) goto L1816;
			
			// Instruction address 0x0000:0x1875, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x64, 0x140, 0x64,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0x64);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28))));

		L1880:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5c);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.L) goto L1880;
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x188f); // stack management - push return offset
			// Instruction address 0x0000:0x188a, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x188f, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L18a2;
			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.NE) goto L18a2;
			goto L17db;

		L18a2:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x18a7); // stack management - push return offset
			// Instruction address 0x0000:0x18a2, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x18a7, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			// Instruction address 0x0000:0x18af, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_MemoryError(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0);

			// Instruction address 0x0000:0x18b7, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0626();

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F19_0000_167b'");
		}

		public void F19_0000_18c1()
		{
			this.oCPU.Log.EnterBlock("'F19_0000_18c1'(Cdecl, Far) at 0x0000:0x18c1");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x28);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x18c8, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x18d2); // stack management - push return offset
			// Instruction address 0x0000:0x18cd, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x18df, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.HumanPlayerID, 0xd);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L1955;

			// Instruction address 0x0000:0x18f3, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4f2f, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);
			goto L1905;

		L1902:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))));

		L1905:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xa);
			if (this.oCPU.Flags.L) goto L190e;
			goto L19b9;

		L190e:
			// Instruction address 0x0000:0x1943, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) % 4) * 0x4f) + 1),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) >> 2) << 6) + 1),
				0x4e, 0x3f);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20), this.oCPU.AX.Word);
			goto L1902;

		L1955:
			// Instruction address 0x0000:0x195d, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4f38, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

		L196a:
			// Instruction address 0x0000:0x19a0, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) % 4) * 0x4b) + 1),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) >> 2) * 0x42) + 1),
				0x4a, 0x41);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xa);
			if (this.oCPU.Flags.L) goto L196a;

		L19b9:
			// Instruction address 0x0000:0x19d9, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0x64, 0x140, 0x64,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 0xffd0);
			goto L19f1;

		L19ed:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x3));

		L19f1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x1a4);
			if (this.oCPU.Flags.L) goto L19fb;
			goto L1ac7;

		L19fb:
			// Instruction address 0x0000:0x19fb, size: 5
			this.oParent.Segment_1000.F0_1000_033e_ResetTimer();

			// Instruction address 0x0000:0x1a1b, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0x64,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x64);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

		L1a28:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4f42));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x140);
			if (this.oCPU.Flags.GE) goto L1a73;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffd0);
			if (this.oCPU.Flags.LE) goto L1a73;
			
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0xa;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.SI.Word = this.oCPU.DX.Word;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x1a6b, size: 5
			this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				(short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, 
					(ushort)(this.oCPU.BP.Word - 0x24)) << 1) + 0x4f4a)) + 0x84),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20)));

		L1a73:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x4);
			if (this.oCPU.Flags.L) goto L1a28;

			// Instruction address 0x0000:0x1a9a, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x64, 0x140, 0x64,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0x64);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28))));

		L1aa5:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5c);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.L) goto L1aa5;
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1ab4); // stack management - push return offset
			// Instruction address 0x0000:0x1aaf, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x1ab4, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1ac7;
			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.NE) goto L1ac7;
			goto L19ed;

		L1ac7:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1acc); // stack management - push return offset
			// Instruction address 0x0000:0x1ac7, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x1acc, size: 5
			this.oParent.Segment_1403.F0_1403_4545();
			
			// Instruction address 0x0000:0x1ad4, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_MemoryError(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0);

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F19_0000_18c1'");
		}

		public void F19_0000_1ae1()
		{
			this.oCPU.Log.EnterBlock("'F19_0000_1ae1'(Cdecl, Far) at 0x0000:0x1ae1");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x28);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1ae8, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x1afa, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.HumanPlayerID, 0x23);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L1b0b;

			// Instruction address 0x0000:0x1b13, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4f52, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);
			goto L1b20;

		L1b0b:
			// Instruction address 0x0000:0x1b13, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4f5c, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

		L1b20:
			// Instruction address 0x0000:0x1b56, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) % 4) * 0x4f) + 1),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) >> 2) * 0x42) + 1),
				0x4e, 0x41);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xa);
			if (this.oCPU.Flags.L) goto L1b20;

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1b79); // stack management - push return offset
			// Instruction address 0x0000:0x1b74, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x1b94, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0,0x64,0x140,0x64,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0,0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 0x1a4);
			goto L1bac;

		L1ba8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 
				this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x3));

		L1bac:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0xffd0);
			if (this.oCPU.Flags.G) goto L1bb5;
			goto L1c89;

		L1bb5:
			// Instruction address 0x0000:0x1bb5, size: 5
			this.oParent.Segment_1000.F0_1000_033e_ResetTimer();

			// Instruction address 0x0000:0x1bd5, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0,0,0x140,0x64,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0,0x64);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

		L1be2:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4f42)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x140);
			if (this.oCPU.Flags.GE) goto L1c35;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffd0);
			if (this.oCPU.Flags.LE) goto L1c35;

			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0xa;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.SI.Word = this.oCPU.DX.Word;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x1c2d, size: 5
			this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				(short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, 
					(ushort)(this.oCPU.BP.Word - 0x24)) << 1) + 0x4f4a)) + 0x84),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20)));

		L1c35:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x4);
			if (this.oCPU.Flags.L) goto L1be2;

			// Instruction address 0x0000:0x1c5c, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x64, 0x140, 0x64,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0x64);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28),
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28))));

		L1c67:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5c);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.L) goto L1c67;
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1c76); // stack management - push return offset
			// Instruction address 0x0000:0x1c71, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x1c76, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1c89;
			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.NE) goto L1c89;
			goto L1ba8;

		L1c89:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1c8e); // stack management - push return offset
			// Instruction address 0x0000:0x1c89, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x1c8e, size: 5
			this.oParent.Segment_1403.F0_1403_4545();
			
			// Instruction address 0x0000:0x1c96, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_MemoryError(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0);

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F19_0000_1ae1'");
		}
	}
}
