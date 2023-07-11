using Disassembler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Civilization1
{
	public enum PixelWriteModeEnum
	{
		Normal = 0,
		And = 1,
		Or = 2,
		Xor = 3
	}

	public class VGABitmap : IDisposable
	{
		private byte[] aBitmapMemory;
		private GCHandle oBitmapMemoryHandle;
		private IntPtr oBitmapMemoryAddress;
		private Bitmap oBitmap;
		private Rectangle oBitmapRectangle;
		private bool bModified = true;
		private bool bVisible = true;

		#region Default palette
		public static Color[] DefaultPalette = new Color[] {
			Color.FromArgb(0x000000),
			Color.FromArgb(0x00002a),
			Color.FromArgb(0x002a00),
			Color.FromArgb(0x002a2a),
			Color.FromArgb(0x2a0000),
			Color.FromArgb(0x2a002a),
			Color.FromArgb(0x2a1500),
			Color.FromArgb(0x2a2a2a),
			Color.FromArgb(0x151515),
			Color.FromArgb(0x15153f),
			Color.FromArgb(0x153f15),
			Color.FromArgb(0x153f3f),
			Color.FromArgb(0x3f1515),
			Color.FromArgb(0x3f153f),
			Color.FromArgb(0x3f3f15),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x000000),
			Color.FromArgb(0x0a0a0a),
			Color.FromArgb(0x151515),
			Color.FromArgb(0x1f1f1f),
			Color.FromArgb(0x2a2a2a),
			Color.FromArgb(0x353535),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x150000),
			Color.FromArgb(0x1f0a0a),
			Color.FromArgb(0x2a1515),
			Color.FromArgb(0x2a0000),
			Color.FromArgb(0x2a0a00),
			Color.FromArgb(0x350a0a),
			Color.FromArgb(0x35150a),
			Color.FromArgb(0x351f1f),
			Color.FromArgb(0x3f1515),
			Color.FromArgb(0x3f2a2a),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x150a00),
			Color.FromArgb(0x1f150a),
			Color.FromArgb(0x2a1f15),
			Color.FromArgb(0x2a1500),
			Color.FromArgb(0x351f0a),
			Color.FromArgb(0x352a1f),
			Color.FromArgb(0x3f2a15),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x151500),
			Color.FromArgb(0x1f1f0a),
			Color.FromArgb(0x151f00),
			Color.FromArgb(0x2a2a15),
			Color.FromArgb(0x35351f),
			Color.FromArgb(0x352a0a),
			Color.FromArgb(0x3f3f2a),
			Color.FromArgb(0x3f3f15),
			Color.FromArgb(0x001500),
			Color.FromArgb(0x151f15),
			Color.FromArgb(0x0a1f0a),
			Color.FromArgb(0x1f2a1f),
			Color.FromArgb(0x152a15),
			Color.FromArgb(0x1f2a0a),
			Color.FromArgb(0x002a00),
			Color.FromArgb(0x002a15),
			Color.FromArgb(0x1f351f),
			Color.FromArgb(0x1f350a),
			Color.FromArgb(0x0a350a),
			Color.FromArgb(0x0a351f),
			Color.FromArgb(0x2a3f2a),
			Color.FromArgb(0x2a3f15),
			Color.FromArgb(0x153f15),
			Color.FromArgb(0x153f2a),
			Color.FromArgb(0x001515),
			Color.FromArgb(0x0a1f1f),
			Color.FromArgb(0x152a2a),
			Color.FromArgb(0x002a2a),
			Color.FromArgb(0x1f3535),
			Color.FromArgb(0x0a3535),
			Color.FromArgb(0x2a3f3f),
			Color.FromArgb(0x153f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x000015),
			Color.FromArgb(0x0a0a1f),
			Color.FromArgb(0x15152a),
			Color.FromArgb(0x00152a),
			Color.FromArgb(0x00002a),
			Color.FromArgb(0x15002a),
			Color.FromArgb(0x0a0a35),
			Color.FromArgb(0x0a1f35),
			Color.FromArgb(0x1f0a35),
			Color.FromArgb(0x1f1f35),
			Color.FromArgb(0x15153f),
			Color.FromArgb(0x152a3f),
			Color.FromArgb(0x2a153f),
			Color.FromArgb(0x2a2a3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x150a15),
			Color.FromArgb(0x150015),
			Color.FromArgb(0x1f151f),
			Color.FromArgb(0x1f0a1f),
			Color.FromArgb(0x2a152a),
			Color.FromArgb(0x2a002a),
			Color.FromArgb(0x351f35),
			Color.FromArgb(0x350a35),
			Color.FromArgb(0x3f153f),
			Color.FromArgb(0x3f2a3f),
			Color.FromArgb(0x3f3f3f),
			Color.FromArgb(0x2a0a15),
			Color.FromArgb(0x2a0015),
			Color.FromArgb(0x35151f),
			Color.FromArgb(0x350a1f),
			Color.FromArgb(0x3f152a)
		};
		#endregion

		#region Palette 1
		public static Color[] Palette1 = new Color[] {
			Color.FromArgb(0x000000),
			Color.FromArgb(0x0000a7),
			Color.FromArgb(0x00a700),
			Color.FromArgb(0x00a7a7),
			Color.FromArgb(0xa70000),
			Color.FromArgb(0xa700a7),
			Color.FromArgb(0xa75300),
			Color.FromArgb(0xa7a7a7),
			Color.FromArgb(0x535353),
			Color.FromArgb(0x5353fb),
			Color.FromArgb(0x53fb53),
			Color.FromArgb(0x53fbfb),
			Color.FromArgb(0xfb5353),
			Color.FromArgb(0xfb53fb),
			Color.FromArgb(0xfbfb53),
			Color.FromArgb(0xfbfbfb)
		};
		#endregion

		public VGABitmap()
		{
			this.aBitmapMemory = new byte[VGADriver.ScreenStride * VGADriver.ScreenHeight];
			this.oBitmapMemoryHandle = GCHandle.Alloc(this.aBitmapMemory, GCHandleType.Pinned);
			this.oBitmapMemoryAddress = Marshal.UnsafeAddrOfPinnedArrayElement(this.aBitmapMemory, 0);
			this.oBitmap = new Bitmap(VGADriver.ScreenWidth, VGADriver.ScreenHeight, VGADriver.ScreenStride,
				PixelFormat.Format8bppIndexed, this.oBitmapMemoryAddress);
			this.oBitmapRectangle = new Rectangle(0, 0, VGADriver.ScreenWidth, VGADriver.ScreenHeight);

			// set default palette
			ColorPalette palette = this.oBitmap.Palette;
			for (int i = 0; i < DefaultPalette.Length; i++)
			{
				palette.Entries[i] = DefaultPalette[i];
			}
			this.oBitmap.Palette = palette;
		}

		#region IDisposable members
		~VGABitmap()
		{
			this.Dispose();
		}

		public void Dispose()
		{
			if (this.oBitmapMemoryAddress != IntPtr.Zero || (this.oBitmapMemoryHandle != null && this.oBitmapMemoryHandle.IsAllocated))
			{
				this.oBitmap.Dispose();
				this.oBitmapMemoryAddress = IntPtr.Zero;
				this.oBitmapMemoryHandle.Free();
				this.aBitmapMemory = null;
			}
		}
		#endregion

		public Bitmap Bitmap
		{
			get { return this.oBitmap; }
		}

		public byte[] BitmapMemory
		{
			get { return this.aBitmapMemory; }
		}

		public bool Modified
		{
			get { return this.bModified; }
			set { this.bModified = value; }
		}

		public bool Visible
		{
			get { return this.bVisible; }
			set { this.bVisible = value; }
		}

		public static Color GetColor18(int red, int green, int blue)
		{
			return Color.FromArgb((255 * (red & 0x3f)) / 64, (255 * (green & 0x3f)) / 64, (255 * (blue & 0x3f)) / 64);
		}

		public void SetColorsFromArray(Color[] colors, ushort sourceIndex, ushort destinationIndex, ushort length)
		{
			ColorPalette palette = this.oBitmap.Palette;
			for (int i = 0; i < length; i++)
			{
				palette.Entries[destinationIndex + i] = colors[sourceIndex + i];
			}

			this.oBitmap.Palette = palette;
			this.bModified = true;
		}

		public void ReplaceColor(Rectangle rect, byte oldColor, byte newColor)
		{
			if (rect.IntersectsWith(this.oBitmapRectangle))
			{
				Rectangle newRect = new Rectangle(rect.Location, rect.Size);
				newRect.Intersect(this.oBitmapRectangle);

				int iBitmapMemoryPtr = (newRect.Top * VGADriver.ScreenStride) + newRect.Left;

				for (int i = 0; i < newRect.Height; i++)
				{
					for (int j = 0; j < newRect.Width; j++)
					{
						if (aBitmapMemory[iBitmapMemoryPtr + j] != oldColor)
						{
							this.bModified = true;
							aBitmapMemory[iBitmapMemoryPtr + j] = newColor;
						}
					}

					iBitmapMemoryPtr += VGADriver.ScreenStride;
				}
				this.bModified = true;
			}
		}

		public byte GetPixel(int x, int y)
		{
			if (this.oBitmapRectangle.Contains(x, y))
			{
				return aBitmapMemory[(y * VGADriver.ScreenStride) + x];
			}

			return 0;
		}

		public void SetPixel(int x, int y, byte color)
		{
			if (this.oBitmapRectangle.Contains(x, y))
			{
				aBitmapMemory[(y * VGADriver.ScreenStride) + x] = color;
				this.bModified = true;
			}
		}

		public void SetPixel(int x, int y, byte color, PixelWriteModeEnum mode)
		{
			if (this.oBitmapRectangle.Contains(x, y))
			{
				switch (mode)
				{
					case PixelWriteModeEnum.Normal:
						aBitmapMemory[(y * VGADriver.ScreenStride) + x] = color;
						break;

					case PixelWriteModeEnum.And:
						aBitmapMemory[(y * VGADriver.ScreenStride) + x] &= color;
						break;

					case PixelWriteModeEnum.Or:
						aBitmapMemory[(y * VGADriver.ScreenStride) + x] |= color;
						break;

					case PixelWriteModeEnum.Xor:
						aBitmapMemory[(y * VGADriver.ScreenStride) + x] ^= color;
						break;
				}

				this.bModified = true;
			}
		}

		public void FillRectangle(Rectangle rect, byte color, PixelWriteModeEnum mode)
		{
			if (rect.IntersectsWith(this.oBitmapRectangle))
			{
				Rectangle newRect = new Rectangle(rect.Location, rect.Size);
				newRect.Intersect(this.oBitmapRectangle);

				int iBitmapMemoryPtr = (newRect.Top * VGADriver.ScreenStride) + newRect.Left;

				for (int i = 0; i < newRect.Height; i++)
				{
					for (int j = 0; j < newRect.Width; j++)
					{
						switch (mode)
						{
							case PixelWriteModeEnum.Normal:
								aBitmapMemory[iBitmapMemoryPtr + j] = color;
								break;

							case PixelWriteModeEnum.And:
								aBitmapMemory[iBitmapMemoryPtr + j] &= color;
								break;

							case PixelWriteModeEnum.Or:
								aBitmapMemory[iBitmapMemoryPtr + j] |= color;
								break;

							case PixelWriteModeEnum.Xor:
								aBitmapMemory[iBitmapMemoryPtr + j] ^= color;
								break;
						}
					}

					iBitmapMemoryPtr += VGADriver.ScreenStride;
				}
				this.bModified = true;
			}
		}

		public void DrawImage(VGABitmap screen)
		{
			if (this.aBitmapMemory.Length == screen.BitmapMemory.Length)
			{
				for (int i = 0; i < this.aBitmapMemory.Length; i++)
				{
					this.aBitmapMemory[i] = screen.BitmapMemory[i];
				}
			}
		}

		public void LoadBitmap(ushort xPos, ushort yPos, string filename, out byte[] paletteBuffer)
		{
			// function body
			FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);

			bool bWordMode = LoadPalette(stream, out paletteBuffer);

			LZWDecoder state = new LZWDecoder(bWordMode);

			state.UnknownValue1 = ReadUInt16FromStream(stream);
			state.Width = ReadUInt16FromStream(stream);
			state.Height = ReadUInt16FromStream(stream);

			// init state
			if (state.Width > 0 && state.Height > 0)
			{
				ushort usTemp = Math.Min(ReadUInt16FromStream(stream), (ushort)0xb);
				state.iMaxBits = (byte)usTemp;
				state.Var_68f4 = usTemp;

				byte[] abPixelBuffer = new byte[state.Width];

				for (int i = 0; i < state.Height; i++)
				{
					DecodeBitmapRow(stream, state, abPixelBuffer);

					for (int j = 0; j < state.Width; j++)
					{
						this.SetPixel(xPos + j, yPos + i, abPixelBuffer[j]);
					}
				}
			}

			stream.Close();
		}

		private void DecodeBitmapRow(FileStream stream, LZWDecoder state, byte[] buffer)
		{
			int iBufferPos = 0;
			int iWidth = state.Width;

			if (state.WordMode)
			{
				iWidth++;
				iWidth >>= 1;
			}

			for (int i = 0; i < iWidth; i++)
			{
				byte ubPixelData;

				if (state.bCurrentData != 0)
				{
					ubPixelData = state.Var_68ed;
					state.bCurrentData--;
				}
				else
				{
					// Instruction address 0x1000:0x12c3, size: 3
					ubPixelData = GetNextByte(stream, state);

					if (ubPixelData != 0x90)
					{
						state.Var_68ed = ubPixelData;
					}
					else
					{
						ubPixelData = GetNextByte(stream, state);

						if (ubPixelData == 0)
						{
							ubPixelData = 0x90;
							state.Var_68ed = ubPixelData;
						}
						else
						{
							state.bCurrentData = ubPixelData;
							state.bCurrentData -= 2;
							ubPixelData = state.Var_68ed;
						}
					}
				}

				if (state.WordMode)
				{
					buffer[iBufferPos] = (byte)(ubPixelData & 0xf);
					buffer[iBufferPos + 1] = (byte)((ushort)(ubPixelData & 0xf0) >> 4);
					iBufferPos += 2;
				}
				else
				{
					buffer[iBufferPos] = ubPixelData;
					iBufferPos++;
				}
			}
		}

		private byte GetNextByte(FileStream stream, LZWDecoder state)
		{
			// function body
			if (state.DataStack.Count == 0)
			{
				// buffer is empty, fill it
				int iPosition;
				int iOffset;
				int iTemp;
				int iCurrentBitPosition;

				iOffset = state.Var_68f4;
				iOffset >>= (16 - state.iBitPosition);
				iCurrentBitPosition = state.iBitPosition;

				while (iCurrentBitPosition < state.iBitCount)
				{
					ushort usValue = ReadUInt16FromStream(stream);
					state.Var_68f4 = usValue;
					usValue <<= iCurrentBitPosition;
					iOffset |= usValue;
					iCurrentBitPosition += 16;
				}

				iCurrentBitPosition -= state.iBitCount;
				state.iBitPosition = iCurrentBitPosition;
				iOffset &= state.Var_68f0;
				iTemp = iOffset;
				if (iOffset >= state.Var_68f2)
				{
					iTemp = state.Var_68f2;
					iOffset = state.Var_68f8;
					state.DataStack.Push(state.Var_68fa);
				}

				while (true)
				{
					iPosition = iOffset * 3;
					iOffset = (short)((ushort)state.abDictionary[iPosition] | ((ushort)state.abDictionary[iPosition + 1] << 8));
					if (iOffset < 0)
						break;
					state.DataStack.Push(state.abDictionary[iPosition + 2]);
				}

				state.Var_68fa = state.abDictionary[iPosition + 2];
				state.DataStack.Push(state.Var_68fa);

				iPosition = state.Var_68f2 * 3;
				state.abDictionary[iPosition] = (byte)(state.Var_68f8 & 0xff);
				state.abDictionary[iPosition + 1] = (byte)((state.Var_68f8 & 0xff00) >> 8);
				state.abDictionary[iPosition + 2] = state.Var_68fa;
				state.Var_68f2++;

				if (state.Var_68f2 > state.Var_68f0)
				{
					state.iBitCount++;
					state.Var_68f0 <<= 1;
					state.Var_68f0 |= 1;
				}

				if (state.iBitCount > state.iMaxBits)
				{
					state.iBitCount = 9;
					state.Var_68f0 = 0x1ff;
					state.Var_68f2 = 0x100;

					for (int i = 0; i < 2048; i++)
					{
						state.abDictionary[i * 3] = 0xff;
						state.abDictionary[i * 3 + 1] = 0xff;
						state.abDictionary[i * 3 + 2] = (byte)((i < 256) ? i : 0);
					}

					state.Var_68f8 = 0;
				}
				else
				{
					state.Var_68f8 = (ushort)iTemp;
				}
			}

			return state.DataStack.Pop();
		}

		private bool LoadPalette(FileStream stream, out byte[] paletteBuffer)
		{
			ushort usTemp;
			int iPalettePos = 0;
			paletteBuffer = new byte[0];

			while (((usTemp = ReadUInt16FromStream(stream)) & 0xff) != 0x58)
			{
				if (usTemp == 0x304d)
				{
					int iByteCount = ReadUInt16FromStream(stream);
					paletteBuffer = new byte[iByteCount + 4];

					paletteBuffer[iPalettePos++] = 0x4d;
					paletteBuffer[iPalettePos++] = 0x30;
					paletteBuffer[iPalettePos++] = (byte)(iByteCount & 0xff);
					paletteBuffer[iPalettePos++] = (byte)((iByteCount & 0xff00) >> 8);

					for (int i = 0; i < iByteCount; i++)
					{
						int iTemp = stream.ReadByte();
						if (iTemp >= 0)
						{
							paletteBuffer[iPalettePos++] = (byte)(iTemp);
						}
						else
						{
							paletteBuffer[iPalettePos++] = 0;
						}
					}

					// set our palette
					int iFromIndex = paletteBuffer[4];
					int iToIndex = paletteBuffer[5];
					int iCount = (iToIndex - iFromIndex) + 1;

					Color[] aColors = new Color[iCount];
					iPalettePos = 6;

					for (int i = 0; i < iCount; i++)
					{
						aColors[i] = VGABitmap.GetColor18(paletteBuffer[iPalettePos],
							paletteBuffer[iPalettePos + 1], paletteBuffer[iPalettePos + 2]);
						iPalettePos += 3;
					}
				}
				else
				{
					usTemp = ReadUInt16FromStream(stream);

					for (int i = 0; i < usTemp; i++)
					{
						stream.ReadByte();
					}
				}
			}

			return (usTemp & 0x100) != 0;
		}

		private ushort ReadUInt16FromStream(FileStream stream)
		{
			int iByte0 = stream.ReadByte();
			int iByte1 = stream.ReadByte();

			if (iByte0 < 0 || iByte1 < 0)
			{
				// end of stream, return 0
				return 0;
			}

			return (ushort)(iByte0 | (iByte1 << 8));
		}

		private class LZWDecoder
		{
			public bool WordMode = false;
			public int Width = 0;
			public int Stride = 0;
			public int Height = 0;
			public ushort UnknownValue1 = 0;
			public byte bCurrentData = 0;
			public byte Var_68ed = 0;
			public Stack<byte> DataStack = new Stack<byte>();
			public int iMaxBits = 11;
			public ushort Var_68f4 = 11;
			public int iBitPosition = 8;
			public int iBitCount = 9;
			public ushort Var_68f0 = 0x1ff;
			public ushort Var_68f2 = 0x100;
			public ushort Var_68f8 = 0;
			public byte Var_68fa = 0;

			public byte[] abDictionary = new byte[0x1800];

			public LZWDecoder(bool wordMode)
			{
				this.WordMode = wordMode;

				for (int i = 0; i < 2048; i++)
				{
					this.abDictionary[i * 3] = 0xff;
					this.abDictionary[i * 3 + 1] = 0xff;
					this.abDictionary[i * 3 + 2] = (byte)((i < 256) ? i : 0);
				}
			}
		}
	}
}
