using OpenCiv1.GPU;
using Disassembler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using IRB.Collections.Generic;
using OpenCiv1.Compression;

namespace OpenCiv1
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
		protected int iStride;
		protected byte[] aBitmapMemory;
		private GCHandle oBitmapMemoryHandle;
		private IntPtr oBitmapMemoryAddress;
		protected Bitmap oBitmap;
		protected Rectangle oRectangle;
		protected bool bModified = true;
		protected bool bVisible = true;

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

		public static Color Color18ToColor(int red, int green, int blue)
		{
			return Color.FromArgb((255 * (red & 0x3f)) / 63, (255 * (green & 0x3f)) / 63, (255 * (blue & 0x3f)) / 63);
		}

		public static Color ColorToColor18(Color color)
		{
			return Color.FromArgb((63 * color.R) / 255, (63 * color.G) / 255, (63 * color.B) / 255);
		}

		public Color GetColor(int index)
		{
			return this.oBitmap.Palette.Entries[index];
		}

		public void SetColor(int index, Color color)
		{
			ColorPalette palette = this.oBitmap.Palette;

			palette.Entries[index] = color;

			this.oBitmap.Palette = palette;
			this.bModified = true;
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
					aColors[i] = VGABitmap.Color18ToColor(colorStruct[iStructPos + (i * 3)],
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
			int iWidthDir = 1;
			int iHeight;
			int iHeightDir = 1;

			if (x1 > x2)
			{
				iWidth = (x1 - x2) + 1;
				iWidthDir = -1;
			}
			else
			{
				iWidth = (x2 - x1) + 1;
			}

			if (y1 > y2)
			{
				iHeight = (y1 - y2) + 1;
				iHeightDir = -1;
			}
			else
			{
				iHeight = (y2 - y1) + 1;
			}

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
					this.SetPixel(x1 + i * iWidthDir, y1, color, mode);
				}
			}
			else if (iWidth == 1 && iHeight > 1)
			{
				// a vertical line
				for (int i = 0; i < iHeight; i++)
				{
					this.SetPixel(x1, y1 + i * iHeightDir, color, mode);
				}
			}
			else if (iWidth > iHeight)
			{
				double dYStep = (double)iHeight / (double)iWidth;

				for (int i = 0; i < iWidth; i++)
				{
					this.SetPixel(x1 + i * iWidthDir, y1 + (int)(dYStep * i) * iHeightDir, color, mode);
				}
			}
			else
			{
				double dXStep = (double)iWidth / (double)iHeight;

				for (int i = 0; i < iHeight; i++)
				{
					this.SetPixel(x1 + (int)(dXStep * i) * iWidthDir, y1 + i * iHeightDir, color, mode);
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
			this.DrawImage(Point.Empty, srcScreen, srcScreen.Rectangle, false);
		}

		public void DrawImage(int x, int y, VGABitmap srcBitmap, bool transparent)
		{
			DrawImage(new Point(x, y), srcBitmap, srcBitmap.Rectangle, transparent);
		}

		public void DrawImage(int x, int y, VGABitmap srcBitmap, Rectangle srcRect, bool transparent)
		{
			DrawImage(new Point(x, y), srcBitmap, srcRect, transparent);
		}

		public void DrawImage(Point destPoint, VGABitmap srcBitmap, Rectangle srcRect, bool transparent)
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
					for (int j = 0; j < destRect.Width; j++)
					{
						if (srcBitmap.BitmapMemory[iSrcPosition + j] != 0 || !transparent)
						{
							this.aBitmapMemory[iDestPosition + j] = srcBitmap.BitmapMemory[iSrcPosition + j];
						}
					}

					iSrcPosition += srcBitmap.Stride;
					iDestPosition += this.iStride;
				}
				this.bModified = true;
			}
		}

		public void DrawString(string text, CivFont font, Rectangle rect, byte frontColor, byte backColor, PixelWriteModeEnum writeMode)
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
							byte color = (byte)((fontCh.Bitmap[j][k] != 0) ? frontColor : backColor);

							if (fontCh.Bitmap[j][k] != 0 ) //|| backColor != 0)
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

		public void LoadBitmap(string filename, ushort xPos, ushort yPos, out byte[] palette)
		{
			// function body
			VGABitmap bitmap = VGABitmap.FromPIC(filename, out palette);

			if (bitmap != null)
			{
				for (int i = 0; i < bitmap.Bitmap.Height; i++)
				{
					for (int j = 0; j < bitmap.Bitmap.Width; j++)
					{
						this.SetPixel(xPos + j, yPos + i, bitmap.GetPixel(j, i));
					}
				}
			}
		}

		public static VGABitmap FromPIC(string path, out byte[] palette)
		{
			VGABitmap bitmap = null;
			FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
			List<BKeyValuePair<int, Color>> aPalette = new List<BKeyValuePair<int, Color>>();
			palette = null;

			// PIC file is written in blocks
			while (true)
			{
				int iSignature = ReadUInt16(stream);
				int iBlockLength = ReadUInt16(stream);

				if (iSignature < 0 || iBlockLength < 0)
					break;

				byte[] aBlock = new byte[iBlockLength];
				int iBlockSize = stream.Read(aBlock, 0, iBlockLength);

				if (iBlockLength != iBlockSize)
				{
					throw new Exception(
						$"Block type 0x{iSignature:x4} data missing, expected {iBlockLength} bytes, " +
						$"but read only {iBlockSize} bytes");
				}

				MemoryStream blockReader;
				int iWidth;
				int iHeight;
				int iMaxBits;

				switch (iSignature)
				{
					case 0x3045:
						// 8bit color palette
						break;

					case 0x304d:
						// 18bit color palette
						List<byte> aTemp = new List<byte>();
						aTemp.Add(0x4d);
						aTemp.Add(0x30);
						aTemp.Add((byte)(iBlockLength & 0xff));
						aTemp.Add((byte)((iBlockLength & 0xff00) >> 8));
						aTemp.AddRange(aBlock);
						palette = aTemp.ToArray();

						blockReader = new MemoryStream(aBlock);
						int iIndex = blockReader.ReadByte();
						int iColorCount = blockReader.ReadByte();

						if (iIndex >= 0 && iColorCount >= 0)
						{
							iColorCount -= iIndex;
							iColorCount++;

							for (int i = 0; i < iColorCount; i++)
							{
								int iRed = blockReader.ReadByte();
								int iGreen = blockReader.ReadByte();
								int iBlue = blockReader.ReadByte();

								if (iRed < 0 || iGreen < 0 || iBlue < 0)
								{
									throw new Exception($"Palette block type 0x{iSignature:x4} malformed");
								}
								aPalette.Add(new BKeyValuePair<int, Color>(iIndex + i,
									VGABitmap.Color18ToColor(iRed, iGreen, iBlue)));
							}
						}
						else
						{
							throw new Exception($"Palette block type 0x{iSignature:x4} malformed");
						}
						break;

					case 0x3058:
						// Image data encoded by RLE and LZW
						blockReader = new MemoryStream(aBlock);
						iWidth = ReadUInt16(blockReader);
						iHeight = ReadUInt16(blockReader);
						iMaxBits = blockReader.ReadByte();

						if (iWidth >= 0 && iHeight >= 0 && iMaxBits > 7)
						{
							// decode LZW
							MemoryStream lzwOutput = new MemoryStream();
							LZW.Decompress(lzwOutput, blockReader, 9, iMaxBits);
							lzwOutput.Position = 0;

							// decode RLE
							MemoryStream rleOutput = new MemoryStream();
							RLE.Decompress(rleOutput, lzwOutput);
							rleOutput.Position = 0;

							// construct bitmap with our raw data
							int iStrideLength = (int)(Math.Ceiling((double)iWidth / 4.0) * 4.0);
							int iScanPosition = 0;

							bitmap = new VGABitmap(iWidth, iHeight);

							for (int i = 0; i < iHeight; i++)
							{
								for (int j = 0; j < iWidth; j++)
								{
									int c = rleOutput.ReadByte();
									if (c < 0)
										break;

									bitmap.aBitmapMemory[iScanPosition] = (byte)c;
									iScanPosition++;
								}
								iScanPosition += iStrideLength - iWidth;
							}

							// set bitmap palette
							ColorPalette bitmapPalette = bitmap.oBitmap.Palette;
							for (int i = 0; i < aPalette.Count; i++)
							{
								bitmapPalette.Entries[aPalette[i].Key] = aPalette[i].Value;
							}
							bitmap.oBitmap.Palette = bitmapPalette;
						}
						else
						{
							throw new Exception($"Image block type 0x{iSignature:x4} malformed");
						}
						break;

					case 0x3158:
						// Image data encoded by two pixels packed into one, RLE and LZW
						blockReader = new MemoryStream(aBlock);
						iWidth = ReadUInt16(blockReader);
						iHeight = ReadUInt16(blockReader);
						iMaxBits = blockReader.ReadByte();

						if (iWidth >= 0 && iHeight >= 0 && iMaxBits > 7)
						{
							// decode LZW
							MemoryStream lzwOutput = new MemoryStream();
							LZW.Decompress(lzwOutput, blockReader, 9, iMaxBits);
							lzwOutput.Position = 0;

							// decode RLE
							MemoryStream rleOutput = new MemoryStream();
							RLE.Decompress(rleOutput, lzwOutput);
							rleOutput.Position = 0;

							// construct bitmap with our raw data
							int iStrideLength = (int)(Math.Ceiling((double)iWidth / 2.0) * 4.0);
							int iScanPosition = 0;

							bitmap = new VGABitmap(iWidth * 2, iHeight);

							for (int i = 0; i < iHeight; i++)
							{
								for (int j = 0; j < iWidth; j += 2)
								{
									int c = rleOutput.ReadByte();
									if (c < 0)
										break;

									bitmap.aBitmapMemory[iScanPosition] = (byte)(c & 0xf);
									iScanPosition++;
									bitmap.aBitmapMemory[iScanPosition] = (byte)((c & 0xf0) >> 4);
									iScanPosition++;
								}
								iScanPosition += iStrideLength - iWidth;
							}

							// set bitmap palette
							ColorPalette bitmapPalette = bitmap.oBitmap.Palette;
							for (int i = 0; i < aPalette.Count; i++)
							{
								bitmapPalette.Entries[aPalette[i].Key] = aPalette[i].Value;
							}
							bitmap.oBitmap.Palette = bitmapPalette;
						}
						else
						{
							throw new Exception($"Image block type 0x{iSignature:x4} malformed");
						}
						break;

					default:
						throw new Exception($"Undefined block type 0x{iSignature:x4}");
				}
			}

			stream.Close();

			return bitmap;
		}

		public static List<BKeyValuePair<int, Color>> PaletteFromPICOrPAL(string path, out byte[] palette)
		{
			FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
			List<BKeyValuePair<int, Color>> aPalette = new List<BKeyValuePair<int, Color>>();
			palette = null;

			// PIC file is written in blocks
			while (true)
			{
				int iSignature = ReadUInt16(stream);
				int iBlockLength = ReadUInt16(stream);

				if (iSignature < 0 || iBlockLength < 0)
					break;

				byte[] aBlock = new byte[iBlockLength];
				int iBlockSize = stream.Read(aBlock, 0, iBlockLength);

				if (iBlockLength != iBlockSize)
				{
					throw new Exception(
						$"Block type 0x{iSignature:x4} data missing, expected {iBlockLength} bytes, " +
						$"but read only {iBlockSize} bytes");
				}

				MemoryStream blockReader;

				switch (iSignature)
				{
					case 0x3045:
						// 8bit color palette
						break;

					case 0x304d:
						// 18bit color palette
						List<byte> aTemp = new List<byte>();
						aTemp.Add(0x4d);
						aTemp.Add(0x30);
						aTemp.Add((byte)(iBlockLength & 0xff));
						aTemp.Add((byte)((iBlockLength & 0xff00) >> 8));
						aTemp.AddRange(aBlock);
						palette = aTemp.ToArray();

						blockReader = new MemoryStream(aBlock);
						int iIndex = blockReader.ReadByte();
						int iColorCount = blockReader.ReadByte();

						if (iIndex >= 0 && iColorCount >= 0)
						{
							iColorCount -= iIndex;
							iColorCount++;

							for (int i = 0; i < iColorCount; i++)
							{
								int iRed = blockReader.ReadByte();
								int iGreen = blockReader.ReadByte();
								int iBlue = blockReader.ReadByte();

								if (iRed < 0 || iGreen < 0 || iBlue < 0)
								{
									throw new Exception($"Palette block type 0x{iSignature:x4} malformed");
								}
								aPalette.Add(new BKeyValuePair<int, Color>(iIndex + i,
									VGABitmap.Color18ToColor(iRed, iGreen, iBlue)));
							}
						}
						else
						{
							throw new Exception($"Palette block type 0x{iSignature:x4} malformed");
						}
						break;

					case 0x3058:
						// Image data encoded by RLE and LZW
						break;

					case 0x3158:
						// Image data encoded by two pixels packed into one, RLE and LZW
						break;

					default:
						throw new Exception($"Undefined block type 0x{iSignature:x4}");
				}
			}

			stream.Close();

			return aPalette;
		}

		private static int ReadUInt16(Stream stream)
		{
			int iByte0 = stream.ReadByte();
			int iByte1 = stream.ReadByte();

			if (iByte0 < 0 || iByte1 < 0)
			{
				// end of stream, return -1
				return -1;
			}

			return iByte0 | (iByte1 << 8);
		}
	}
}
