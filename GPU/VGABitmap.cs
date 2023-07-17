using Civilization1.GPU;
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
		private int iStride;
		private byte[] aBitmapMemory;
		private GCHandle oBitmapMemoryHandle;
		private IntPtr oBitmapMemoryAddress;
		private Bitmap oBitmap;
		private Rectangle oRectangle;
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

		public VGABitmap() : this(new Size(320, 200))
		{ }

		public VGABitmap(Size size) : this(size.Width, size.Height)
		{ }

		public VGABitmap(int width, int height)
		{
			// stride has to be a multiple of 4
			this.iStride = (int)(Math.Ceiling((double)width / 4.0) * 4.0);
			this.aBitmapMemory = new byte[this.iStride * height];
			this.oBitmapMemoryHandle = GCHandle.Alloc(this.aBitmapMemory, GCHandleType.Pinned);
			this.oBitmapMemoryAddress = Marshal.UnsafeAddrOfPinnedArrayElement(this.aBitmapMemory, 0);
			this.oBitmap = new Bitmap(width, height, this.iStride, PixelFormat.Format8bppIndexed, this.oBitmapMemoryAddress);
			this.oRectangle = new Rectangle(0, 0, width, height);

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

		public int Stride
		{
			get { return this.iStride; }
		}

		public Rectangle Rectangle
		{
			get { return this.oRectangle; }
		}

		public Size Size
		{
			get { return this.oRectangle.Size; }
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

		public void SetColorsFromColorStruct(byte[] colorStruct)
		{
			int iStructPos = 0;

			if (colorStruct.Length > 0 && colorStruct[iStructPos] == 0x4d && colorStruct[iStructPos + 1] == 0x30)
			{
				int iFrom = colorStruct[iStructPos + 4];
				int iTo = colorStruct[iStructPos + 5];
				int iCount = (iTo - iFrom) + 1;
				iStructPos += 6;

				Color[] aColors = new Color[iCount];

				for (int i = 0; i < iCount; i++)
				{
					aColors[i] = VGABitmap.GetColor18(colorStruct[iStructPos + (i * 3)],
						colorStruct[iStructPos + (i * 3) + 1],
						colorStruct[iStructPos + (i * 3) + 2]);
				}

				this.SetColorsFromArray(aColors, iFrom, iFrom, iCount);
			}
		}

		public void SetColorsFromArray(Color[] colors, int sourceIndex, int destinationIndex, int length)
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
			if (rect.IntersectsWith(this.oRectangle))
			{
				Rectangle newRect = new Rectangle(rect.Location, rect.Size);
				newRect.Intersect(this.oRectangle);

				int iBitmapMemoryPtr = (newRect.Top * this.iStride) + newRect.Left;

				for (int i = 0; i < newRect.Height; i++)
				{
					for (int j = 0; j < newRect.Width; j++)
					{
						if (aBitmapMemory[iBitmapMemoryPtr + j] == oldColor)
						{
							this.bModified = true;
							aBitmapMemory[iBitmapMemoryPtr + j] = newColor;
						}
					}

					iBitmapMemoryPtr += this.iStride;
				}
				this.bModified = true;
			}
		}

		public void CopyPalette(VGABitmap bitmap)
		{
			ColorPalette newPalette = this.oBitmap.Palette;
			ColorPalette oldPalette = bitmap.Bitmap.Palette;

			for (int i = 0; i < oldPalette.Entries.Length; i++)
			{
				newPalette.Entries[i] = oldPalette.Entries[i];
			}

			this.oBitmap.Palette = newPalette;
		}

		public byte GetPixel(int x, int y)
		{
			if (this.oRectangle.Contains(x, y))
			{
				return aBitmapMemory[(y * this.iStride) + x];
			}

			return 0;
		}

		public void SetPixel(int x, int y, byte color)
		{
			if (this.oRectangle.Contains(x, y))
			{
				aBitmapMemory[(y * this.iStride) + x] = color;
				this.bModified = true;
			}
		}

		public void SetPixel(int x, int y, byte color, PixelWriteModeEnum mode)
		{
			if (this.oRectangle.Contains(x, y))
			{
				switch (mode)
				{
					case PixelWriteModeEnum.Normal:
						aBitmapMemory[(y * this.iStride) + x] = color;
						break;

					case PixelWriteModeEnum.And:
						aBitmapMemory[(y * this.iStride) + x] &= color;
						break;

					case PixelWriteModeEnum.Or:
						aBitmapMemory[(y * this.iStride) + x] |= color;
						break;

					case PixelWriteModeEnum.Xor:
						aBitmapMemory[(y * this.iStride) + x] ^= color;
						break;
				}

				this.bModified = true;
			}
		}

		public void DrawLine(int x1, int y1, int x2, int y2, byte color, PixelWriteModeEnum mode)
		{
			int iWidth;
			int iHeight;

			if (x1 > x2)
			{
				int iTemp = x1;
				x1 = x2;
				x2 = iTemp;
			}
			iWidth = (x2 - x1) + 1;

			if (y1 > y2)
			{
				int iTemp = y1;
				y1 = y2;
				y2 = iTemp;
			}
			iHeight = (y2 - y1) + 1;

			if (iWidth == 1 && iHeight == 1)
			{
				// a single point
				this.SetPixel(x1, y1, color, mode);
			}
			else if (iWidth > 1 && iHeight == 1)
			{
				// a horizontal line
				for (int i = 0; i < iWidth; i++)
				{
					this.SetPixel(x1 + i, y1, color, mode);
				}
			}
			else if (iWidth == 1 && iHeight > 1)
			{
				// a vertical line
				for (int i = 0; i < iHeight; i++)
				{
					this.SetPixel(x1, y1 + i, color, mode);
				}
			}
			else if(iWidth>iHeight)
			{
				double dYStep = (double)iHeight/ (double)iWidth;

				for (int i = 0; i < iWidth; i++)
				{
					this.SetPixel(x1 + i, y1 + (int)(dYStep * i), color, mode);
				}
			}
			else
			{
				double dXStep = (double)iWidth / (double)iHeight;

				for (int i = 0; i < iHeight; i++)
				{
					this.SetPixel(x1 + (int)(dXStep * i), y1 + i, color, mode);
				}
			}
		}

		public void FillRectangle(Rectangle rect, byte color, PixelWriteModeEnum mode)
		{
			if (rect.IntersectsWith(this.oRectangle))
			{
				Rectangle newRect = new Rectangle(rect.Location, rect.Size);
				newRect.Intersect(this.oRectangle);

				int iBitmapMemoryPtr = (newRect.Top * this.iStride) + newRect.Left;

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

					iBitmapMemoryPtr += this.iStride;
				}
				this.bModified = true;
			}
		}

		public void DrawImage(VGABitmap srcScreen)
		{
			this.DrawImage(Point.Empty, srcScreen, srcScreen.Rectangle);
		}

		public void DrawImage(int x, int y, VGABitmap srcBitmap)
		{
			DrawImage(new Point(x, y), srcBitmap, srcBitmap.Rectangle);
		}

		public void DrawImage(int x, int y, VGABitmap srcBitmap, Rectangle srcRect)
		{
			DrawImage(new Point(x, y), srcBitmap, srcRect);
		}

		public void DrawImage(Point destPoint, VGABitmap srcBitmap, Rectangle srcRect)
		{
			Rectangle srcRect1 = new Rectangle(srcRect.Location, srcRect.Size);
			srcRect1.Intersect(srcBitmap.Rectangle);

			Rectangle destRect = new Rectangle(destPoint, srcRect1.Size);
			destRect.Intersect(this.oRectangle);

			if (destRect.Width > 0 && destRect.Height > 0)
			{
				srcRect1.Size = destRect.Size;

				int iSrcPosition = (srcBitmap.Stride * srcRect1.Y) + srcRect1.X;
				int iDestPosition = (this.iStride * destRect.Y) + destRect.X;

				for (int i = 0; i < destRect.Height; i++)
				{
					Array.Copy(srcBitmap.BitmapMemory, iSrcPosition, this.aBitmapMemory, iDestPosition, destRect.Width);

					iSrcPosition += srcBitmap.Stride;
					iDestPosition += this.iStride;
				}
				this.bModified = true;
			}
		}

		public void DrawString(string text, CivFont font, Rectangle rect, byte color, PixelWriteModeEnum writeMode)
		{
			Rectangle rect1 = new Rectangle(rect.Location, rect.Size);
			rect1.Intersect(this.oRectangle);

			if (rect1.Width > 0 && rect1.Height > 0)
			{
				int iXPosition = rect1.X;
				int iYPosition = rect1.Y;
				int iBitmapPosition = (this.iStride * rect1.Y) + rect1.X;

				for (int i = 0; i < text.Length; i++)
				{
					char ch = text[i];
					CivFontCharacter fontCh;

					if (i > 0)
						iBitmapPosition += font.CharacterWidthSpacing;

					if (font.Characters.ContainsKey(ch))
					{
						fontCh = font.Characters.GetValueByKey(ch);
					}
					else
					{
						// unknown char, use '?'
						fontCh = font.Characters.GetValueByKey('?');
					}

					int iBitmapPosition1 = iBitmapPosition;

					for (int j = 0; j < fontCh.Height; j++)
					{
						for (int k = 0; k < fontCh.Width; k++)
						{
							if (fontCh.Bitmap[j][k] != 0)
							{
								switch (writeMode)
								{
									case PixelWriteModeEnum.Normal:
										this.aBitmapMemory[iBitmapPosition1 + k] = color;
										break;

									case PixelWriteModeEnum.And:
										this.aBitmapMemory[iBitmapPosition1 + k] &= color;
										break;

									case PixelWriteModeEnum.Or:
										this.aBitmapMemory[iBitmapPosition1 + k] |= color;
										break;

									case PixelWriteModeEnum.Xor:
										this.aBitmapMemory[iBitmapPosition1 + k] ^= color;
										break;
								}
							}
						}
						iBitmapPosition1 += this.iStride;
					}
					iBitmapPosition += fontCh.Width;
				}
				this.bModified = true;
			}
		}

		public void LoadBitmap(ushort xPos, ushort yPos, string filename, out byte[] paletteBuffer)
		{
			// function body
			FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);

			bool bWordMode = LoadPalette(stream, out paletteBuffer);

			//SetColorsFromColorStruct(paletteBuffer);

			LZWDecoderState state = new LZWDecoderState(bWordMode);

			state.UnknownValue1 = ReadUInt16FromStream(stream);
			state.Width = ReadUInt16FromStream(stream);
			state.Height = ReadUInt16FromStream(stream);

			// init state
			if (state.Width > 0 && state.Height > 0)
			{
				ushort usTemp = ReadUInt16FromStream(stream);
				state.ClearCode = (byte)Math.Min((usTemp & 0xff), 0xb);
				state.InputData = (ushort)((usTemp & 0xff00) | state.ClearCode);

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

		private void DecodeBitmapRow(FileStream stream, LZWDecoderState state, byte[] dataBuffer)
		{
			int iBufferPos = 0;
			int iWidth = state.Width;

			if (state.WordMode)
			{
				iWidth++;
				iWidth >>= 1;
			}

				for (int j = 0; j < iWidth; j++)
				{
					byte ubPixelData;

					if (state.ChunkLength != 0)
					{
						ubPixelData = state.ChunkData;
						state.ChunkLength--;
					}
					else
					{
						// Instruction address 0x1000:0x12c3, size: 3
						ubPixelData = GetNextByte(stream, state);

						if (ubPixelData != 0x90)
						{
							state.ChunkData = ubPixelData;
						}
						else
						{
							ubPixelData = GetNextByte(stream, state);

							if (ubPixelData == 0)
							{
								ubPixelData = 0x90;
								state.ChunkData = ubPixelData;
							}
							else
							{
								state.ChunkLength = ubPixelData;
								state.ChunkLength -= 2;
								ubPixelData = state.ChunkData;
							}
						}
					}

					if (iBufferPos < dataBuffer.Length)
					{
						if (state.WordMode)
						{
							dataBuffer[iBufferPos] = (byte)(ubPixelData & 0xf);
							dataBuffer[iBufferPos + 1] = (byte)((ushort)(ubPixelData & 0xf0) >> 4);
							iBufferPos += 2;
						}
						else
						{
							dataBuffer[iBufferPos] = ubPixelData;
							iBufferPos++;
						}
					}
				}
				if (state.WordMode)
				{
					for (int j = iWidth * 2; j < state.Stride; j++)
					{
						// overscan, just set to 0
						dataBuffer[iBufferPos] = 0;
						iBufferPos++;
					}
				}
				else
				{
					for (int j = iWidth; j < state.Stride; j++)
					{
						// overscan, just set to 0
						dataBuffer[iBufferPos] = 0;
						iBufferPos++;
					}
				}
		}

		private byte GetNextByte(FileStream stream, LZWDecoderState state)
		{
			// function body
			if (state.DataStack.Count == 0)
			{
				// buffer is empty, fill it
				ushort usCode = state.InputData;
				usCode >>= (16 - state.InputLength);

				while (state.InputLength < state.BitCount)
				{
					state.InputData = ReadUInt16FromStream(stream);
					usCode |= (ushort)(state.InputData << state.InputLength);
					state.InputLength += 0x10;
				}

				state.InputLength -= state.BitCount;
				usCode &= state.Mask;
				ushort usNextPosition = usCode;
				if (usCode >= state.DictionaryLength)
				{
					usNextPosition = state.DictionaryLength;
					usCode = state.PreviousPosition;
					state.DataStack.Push(state.NextPosition);
				}

			L1377:
				int iPosition = usCode * 3;
				usCode = (ushort)((ushort)state.abDictionary[iPosition] | ((ushort)state.abDictionary[iPosition + 1] << 8));
				usCode++;
				if (usCode == 0) goto L138c;
				usCode--;
				state.DataStack.Push(state.abDictionary[iPosition + 2]);
				goto L1377;

			L138c:
				state.NextPosition = state.abDictionary[iPosition + 2];
				state.DataStack.Push(state.NextPosition);
				iPosition = (ushort)(state.DictionaryLength * 3);
				state.abDictionary[iPosition + 2] = state.NextPosition;
				state.abDictionary[iPosition] = (byte)(state.PreviousPosition & 0xff);
				state.abDictionary[iPosition + 1] = (byte)((state.PreviousPosition & 0xff00) >> 8);
				state.DictionaryLength++;

				if (state.DictionaryLength > state.Mask)
				{
					state.BitCount++;
					state.Mask <<= 1;
					state.Mask |= 1;
				}

				if (state.BitCount > state.ClearCode)
				{
					state.BitCount = 9;
					state.Mask = 511;
					state.DictionaryLength = 256;

					for (int i = 0; i < 2048; i++)
					{
						state.abDictionary[i * 3] = 0xff;
						state.abDictionary[i * 3 + 1] = 0xff;
						state.abDictionary[i * 3 + 2] = (byte)((i < 256) ? i : 0);
					}

					state.PreviousPosition = 0;
				}
				else
				{
					state.PreviousPosition = usNextPosition;
				}
			}

			return state.DataStack.Pop();
		}

		private bool LoadPalette(FileStream stream, out byte[] paletteBuffer)
		{
			ushort usTemp;
			paletteBuffer = new byte[0];

			while (((usTemp = ReadUInt16FromStream(stream)) & 0xff) != 0x58)
			{
				if (usTemp == 0x304d)
				{
					int iPalettePos = 0;
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

		private class LZWDecoderState
		{
			public bool WordMode = false;
			public int Width = 0;
			public int Stride = 0;
			public int Height = 0;
			public ushort UnknownValue1 = 0;
			public byte ChunkLength = 0;
			public byte ChunkData = 0;
			public Stack<byte> DataStack = new Stack<byte>();
			public byte ClearCode = 11;
			public ushort InputData = 0;
			public byte InputLength = 8;
			public byte BitCount = 9;
			public ushort Mask = 0x1ff;
			public ushort DictionaryLength = 256;
			public ushort PreviousPosition = 0;
			public byte NextPosition = 0;

			public byte[] abDictionary = new byte[2048 * 3];

			public LZWDecoderState(bool wordMode)
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
