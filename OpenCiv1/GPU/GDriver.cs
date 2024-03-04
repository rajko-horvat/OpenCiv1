using System.IO.Compression;

using IRB.Collections.Generic;
using IRB.VirtualCPU;

using OpenCiv1.Contracts;
using OpenCiv1.Drawing;
using OpenCiv1.Input;

namespace OpenCiv1.GPU
{
	public class GDriver
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		private IMainForm? oMainForm = null;
		public object GLock = new object();
		private BDictionary<int, GBitmap> aScreens = new BDictionary<int, GBitmap>();
		private int iNextBitmapID = 0xb000;
		private BDictionary<int, GBitmap> aBitmaps = new BDictionary<int, GBitmap>();
		private Queue<int> aKeys = new Queue<int>();
		private GFonts aFonts;

		public GDriver(OpenCiv1 parent, IMainForm mainForm)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oMainForm = mainForm;

			this.aScreens.Add(0, new GBitmap()); // Main screen

			byte[]? fonts = (byte[]?)mainForm.GetObject("Fonts_xml_gz");

			if (fonts == null)
			{
				throw new ResourceMissingException($"OpenCiv1 Font resources are missing.");
			}

			Stream fonts1 = new GZipStream(new MemoryStream(fonts), CompressionMode.Decompress);
			//Stream fonts1 = new MemoryStream(fonts);
			this.aFonts = GFonts.Deserialize(fonts1);

			fonts1.Close();
			
			//Stream writer = new GZipStream(new FileStream("Fonts.xml.gz", FileMode.Create), CompressionMode.Compress);
			//writer.Write(fonts, 0, fonts.Length);
			//writer.Flush();
			//writer.Close();
		}

		#region Properties
		public CPU CPU
		{
			get { return this.oCPU; }
		}

		public BDictionary<int, GBitmap> Screens
		{
			get { return this.aScreens; }
		}

		public BDictionary<int, GBitmap> Bitmaps
		{
			get { return this.aBitmaps; }
		}

		public Queue<int> Keys
		{
			get { return this.aKeys; }
		}

		public GPoint ScreenMouseLocation
		{
			get
			{
				if (this.oMainForm != null)
					return this.oMainForm.ScreenMouseLocation;
				else
					return new GPoint(0, 0);
			}
		}

		public ushort ScreenMouseButtons
		{
			get
			{
				if (this.oMainForm != null)
				{
					ushort usTemp = 0;
					usTemp |= (ushort)(((this.oMainForm.ScreenMouseButtons & MouseButtons.Left) == MouseButtons.Left) ? 1 : 0);
					usTemp |= (ushort)(((this.oMainForm.ScreenMouseButtons & MouseButtons.Right) == MouseButtons.Right) ? 2 : 0);
					return usTemp;
				}
				else
					return 0;
			}
		}
		#endregion

		#region Memory and Initialization functions
		public ushort F0_VGA_0492_GetFreeMemory()
		{
			// function body
			this.oCPU.AX.Word = (ushort)((this.oCPU.Memory.FreeMemory.Size >> 4) & 0xffff);
			this.oCPU.Flags.C = true;

			return this.oCPU.AX.Word;
		}

		public ushort F0_VGA_04ae_AllocateScreen(ushort screenID)
		{
			// function body
			if (!this.aScreens.ContainsKey(screenID))
			{
				lock (this.GLock)
				{
					GBitmap bitmap = new GBitmap();
					bitmap.Visible = false; // additional screens are not shown by default
					this.aScreens.Add(screenID, bitmap);
				}
				if (this.oMainForm != null)
					this.oMainForm.OnScreenCountChange();
			}

			this.oCPU.AX.Word = 0xa000; // return something to make underlying code happy

			return this.oCPU.AX.Word;
		}
		#endregion

		#region Palette functions
		public void F0_VGA_010c_SetColorsByIndexArray(ushort indexArrayPtr)
		{
			// function body
			lock (this.GLock)
			{
				Color[] aColors = new Color[16];

				for (int i = 0; i < 16; i++)
				{
					aColors[i] = GBitmap.Palette1[this.oCPU.ReadUInt8(this.oCPU.DS.Word, indexArrayPtr)];

					indexArrayPtr++;
				}

				// set colors to all planes, as this is what original code does
				for (int i = 0; i < this.aScreens.Count; i++)
				{
					this.aScreens[i].Value.SetPaletteFromColorArray(aColors, 0, 0, 16);
				}
			}
		}

		public void SetColor(byte index, Color color)
		{
			lock (this.GLock)
			{
				// set colors to all planes, as this is what original code does
				for (int i = 0; i < this.aScreens.Count; i++)
				{
					this.aScreens[i].Value.SetPaletteColor(index, color);
				}
			}
		}

		public void F0_VGA_0162_SetColorsFromColorStruct(ushort colorStructPtr)
		{
			// function body
			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, colorStructPtr) == 0x304d)
			{
				int iFrom = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(colorStructPtr + 0x4));
				int iTo = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(colorStructPtr + 0x5));
				int iCount = (iTo - iFrom) + 1;
				colorStructPtr += 6;

				lock (this.GLock)
				{
					Color[] aColors = new Color[iCount];

					for (int i = 0; i < iCount; i++)
					{
						aColors[i] = GBitmap.Color18ToColor(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(colorStructPtr + (i * 3))),
							this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(colorStructPtr + (i * 3) + 1)),
						this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(colorStructPtr + (i * 3) + 2)));

						this.oCPU.Log.WriteLine($"Setting palette index {iFrom + i}, #{aColors[i].A:x2}{aColors[i].R:x2}{aColors[i].G:x2}{aColors[i].B:x2}");
					}

					// set colors to all planes, as this is what original code does
					for (int i = 0; i < this.aScreens.Count; i++)
					{
						this.aScreens[i].Value.SetPaletteFromColorArray(aColors, iFrom, iFrom, iCount);
					}
				}
			}
		}

		public void SetColorsFromColorStruct(byte[] colorStruct)
		{
			int iStructPos = 0;

			if (colorStruct[iStructPos] == 0x4d && colorStruct[iStructPos + 1] == 0x30)
			{
				int iFrom = colorStruct[iStructPos + 4];
				int iTo = colorStruct[iStructPos + 5];
				int iCount = (iTo - iFrom) + 1;
				iStructPos += 6;

				lock (this.GLock)
				{
					Color[] aColors = new Color[iCount];

					for (int i = 0; i < iCount; i++)
					{
						aColors[i] = GBitmap.Color18ToColor(colorStruct[iStructPos + (i * 3)],
							colorStruct[iStructPos + (i * 3) + 1],
							colorStruct[iStructPos + (i * 3) + 2]);
					}

					// set colors to all screens, as this is what original code does
					for (int i = 0; i < this.aScreens.Count; i++)
					{
						this.aScreens[i].Value.SetPaletteFromColorArray(aColors, iFrom, iFrom, iCount);
					}
				}
			}
		}
		#endregion

		#region Drawing functions
		public void F0_VGA_06b7_DrawScreenToMainScreen(ushort screenID)
		{
			// function body
			// this is either random fade in image, or a scrolling from right to left
			if (screenID != 0)
			{
				if (this.aScreens.ContainsKey(screenID))
				{
					lock (this.GLock)
					{
						GBitmap screen0 = this.aScreens.GetValueByKey(0);

						screen0.DrawImage(this.aScreens.GetValueByKey(screenID));
					}
				}
				else
				{
					throw new Exception($"The screen {screenID} is not allocated");
				}
			}
		}

		public void F0_VGA_07d8_DrawImage(ushort srcRectPtr, int xFrom, int yFrom, int width, int height, ushort destRectPtr, int xTo, int yTo)
		{
			CivRectangle rectFrom = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, srcRectPtr));
			int iXOffsetFrom = rectFrom.X + xFrom;
			int iYOffsetFrom = rectFrom.Y + yFrom;

			CivRectangle rectTo = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, destRectPtr));
			int iXOffsetTo = rectTo.X + xTo;
			int iYOffsetTo = rectTo.Y + yTo;

			// function body
			if (this.aScreens.ContainsKey(rectFrom.ScreenID))
			{
				GBitmap srcBitmap = this.aScreens.GetValueByKey(rectFrom.ScreenID);

				if (this.aScreens.ContainsKey(rectTo.ScreenID))
				{
					lock (this.GLock)
					{
						GBitmap destBitmap = this.aScreens.GetValueByKey(rectTo.ScreenID);

						destBitmap.DrawImage(iXOffsetTo, iYOffsetTo, srcBitmap, new GRectangle(iXOffsetFrom, iYOffsetFrom, width, height), false);
					}
				}
				else
				{
					throw new Exception($"The screen {rectTo.ScreenID} is not allocated");
				}
			}
			else
			{
				throw new Exception($"The screen {rectFrom.ScreenID} is not allocated");
			}
		}

		public ushort F0_VGA_0b85_ScreenToBitmap(ushort screenID, ushort xPos, ushort yPos, ushort width, ushort height)
		{
			// function body
			if (this.aScreens.ContainsKey(screenID))
			{
				lock (this.GLock)
				{
					GBitmap screen = this.aScreens.GetValueByKey(screenID);
					GBitmap bitmap = new GBitmap(width, height);
					GRectangle rect = new GRectangle(xPos, yPos, width, height);
					screen.CopyPalette(bitmap);

					bitmap.DrawImage(0, 0, screen, rect, false);

					this.aBitmaps.Add(this.iNextBitmapID, bitmap);

					//bitmap.Bitmap.SaveToPIC($"Bitmaps{Path.DirectorySeparatorChar}Image_{this.iNextBitmapID:x4}.png", ImageFormat.Png);

					this.oCPU.AX.Word = (ushort)this.iNextBitmapID;
					this.iNextBitmapID++;
				}
			}
			else
			{
				throw new Exception($"The screen {screenID} is not allocated");
			}

			return this.oCPU.AX.Word;
		}

		public void F0_VGA_0c3e_DrawBitmapToScreen(ushort rectPtr, int xPos, int yPos, ushort bitmapPtr)
		{
			// function body
			CivRectangle rect = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, rectPtr));

			if (this.aScreens.ContainsKey(rect.ScreenID))
			{
				if (this.aBitmaps.ContainsKey(bitmapPtr))
				{
					lock (this.GLock)
					{
						GBitmap screen = this.aScreens.GetValueByKey(rect.ScreenID);
						GBitmap bitmap = this.aBitmaps.GetValueByKey(bitmapPtr);

						screen.DrawImage(rect.X + xPos, rect.Y + yPos, bitmap, true);
					}
				}
				else
				{
					this.oCPU.Log.WriteLine($"The bitmap 0x{bitmapPtr:x4} is not allocated");
				}
			}
			else
			{
				throw new Exception($"The screen {rect.ScreenID} is not allocated");
			}
		}

		public void F0_VGA_0d47_DrawBitmapToScreen(ushort rectPtr, int xPos, int yPos, int bitmapPtr)
		{
			// function body
			CivRectangle rect = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, rectPtr));

			if (this.aScreens.ContainsKey(rect.ScreenID))
			{
				if (this.aBitmaps.ContainsKey(bitmapPtr))
				{
					lock (this.GLock)
					{
						GBitmap screen = this.aScreens.GetValueByKey(rect.ScreenID);
						GBitmap bitmap = this.aBitmaps.GetValueByKey(bitmapPtr);

						screen.DrawImage(rect.X + xPos, rect.Y + yPos, bitmap, true);
					}
				}
				else
				{
					this.oCPU.Log.WriteLine($"The bitmap 0x{bitmapPtr:x4} is not allocated");
				}
			}
			else
			{
				throw new Exception($"The screen {rect.ScreenID} is not allocated");
			}
		}

		public ushort LoadIcon(string filename)
		{
			byte[] aTemp;
			GBitmap? bitmap = GBitmap.FromPICFile(this.oCPU.DefaultDirectory + filename.ToUpper(), out aTemp);

			if (bitmap != null)
			{
				this.aBitmaps.Add(this.iNextBitmapID, bitmap);

				this.oCPU.AX.Word = (ushort)this.iNextBitmapID;
				this.iNextBitmapID++;
			}
			else
			{
				this.oCPU.AX.Word = 0xffff;
			}
			
			return this.oCPU.AX.Word;
		}

		public ushort F0_VGA_038c_GetPixel(ushort screenID, int xPos, int yPos)
		{
			// function body
			if (this.aScreens.ContainsKey(screenID))
			{
				lock (this.GLock)
				{
					this.oCPU.AX.Word = this.aScreens.GetValueByKey(screenID).GetPixel(xPos, yPos);
				}
			}
			else
			{
				throw new Exception($"The screen {screenID} is not allocated");
			}

			return this.oCPU.AX.Word;
		}

		public void F0_VGA_0550_SetPixel(ushort screenID, int xPos, int yPos, byte frontColor, byte pixelMode)
		{
			// function body
			if (this.aScreens.ContainsKey(screenID))
			{
				lock (this.GLock)
				{
					GBitmap screen = this.aScreens.GetValueByKey(screenID);

					screen.SetPixel(xPos, yPos, frontColor, (PixelWriteModeEnum)pixelMode);
				}
			}
			else
			{
				throw new Exception($"The screen {screenID} is not allocated");
			}
		}

		public void F0_VGA_0599_DrawLine(ushort rectPtr, int x1, int y1, int x2, int y2, ushort mode)
		{
			// function body
			CivRectangle rect = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, rectPtr));

			if (this.aScreens.ContainsKey(rect.ScreenID))
			{
				lock (this.GLock)
				{
					GBitmap screen = this.aScreens.GetValueByKey(rect.ScreenID);

					x1 += rect.X;
					y1 += rect.Y;
					x2 += rect.X;
					y2 += rect.Y;

					screen.DrawLine(x1, y1, x2, y2, (byte)(mode & 0xff), (PixelWriteModeEnum)((mode & 0xff00) >> 8));
				}
			}
			else
			{
				throw new Exception($"The screen {rect.ScreenID} is not allocated");
			}
		}

		public void F0_VGA_040a_FillRectangle(int screenID, GRectangle rect, byte frontColor, byte pixelMode)
		{
			// function body
			if (this.aScreens.ContainsKey(screenID))
			{
				lock (this.GLock)
				{
					this.aScreens.GetValueByKey(screenID).FillRectangle(rect, frontColor, (PixelWriteModeEnum)pixelMode);
				}
			}
			else
			{
				throw new Exception($"The screen {screenID} is not allocated");
			}
		}

		public void F0_VGA_009a_ReplaceColor(ushort rectPtr, int xPos, int yPos, int width, int height, byte oldColor, byte newColor)
		{
			// function body
			lock (this.GLock)
			{
				CivRectangle rect = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, rectPtr));
				int iTop = rect.X + xPos;
				int iLeft = rect.Y + yPos;

				if (this.aScreens.ContainsKey(rect.ScreenID))
				{
					this.aScreens.GetValueByKey(rect.ScreenID).ReplaceColor(new GRectangle(iTop, iLeft, width, height), oldColor, newColor);
				}
				else
				{
					throw new Exception($"The screen {rect.ScreenID} is not allocated");
				}
			}
		}
		#endregion

		#region Fonts
		public ushort F0_VGA_115d_GetCharWidth(ushort fontID, byte ch)
		{
			// function body
			this.oCPU.AX.Word = (ushort)GetDrawStringSize(fontID, new string((char)ch, 1)).Width;

			return this.oCPU.AX.Word;
		}

		public Size GetDrawStringSize(int fontID, string text)
		{
			int iWidth = 0;
			int iHeight = 0;

			if (!this.aFonts.ContainsKey(fontID))
			{
				fontID = 1; // default font
			}

			GFont font = this.aFonts.GetValueByKey(fontID);

			for (int i = 0; i < text.Length; i++)
			{
				char ch = text[i];
				GFontChar fontCh;

				//if (i > 0)
				iWidth += font.CharacterWidthSpacing;

				if (font.Characters.ContainsKey(ch))
				{
					fontCh = font.Characters.GetValueByKey(ch);
				}
				else
				{
					// unknown char, use '?'
					fontCh = font.Characters.GetValueByKey('?');
				}
				iWidth += fontCh.Width;
				iHeight = Math.Max(iHeight, fontCh.Height);
				iHeight += font.LineSpacing;
			}

			return new Size(iWidth, iHeight);
		}

		public ushort F0_VGA_11ae_GetTextHeight(ushort fontID)
		{
			// function body
			this.oCPU.AX.Word = (ushort)GetDrawStringSize(fontID, "?").Height;

			return this.oCPU.AX.Word;
		}

		public void F0_VGA_11d7_DrawString(ushort rectPtr, int xPos, int yPos, string text)
		{
			CivRectangle rect = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, rectPtr));

			if (!this.aFonts.ContainsKey(rect.FontID))
			{
				rect.FontID = 1; // default font
			}

			// function body
			GFont font = this.aFonts.GetValueByKey(rect.FontID);

			if (this.aScreens.ContainsKey(rect.ScreenID))
			{
				lock (this.GLock)
				{
					GBitmap screen = this.aScreens.GetValueByKey(rect.ScreenID);
					GRectangle rect1 = new GRectangle(rect.X + xPos, rect.Y + yPos, rect.Width, rect.Height);

					screen.DrawString(text, font, rect1, rect.FrontColor, rect.BackColor, (PixelWriteModeEnum)rect.PixelMode);
				}
			}
			else
			{
				throw new Exception($"The screen {rect.ScreenID} is not allocated");
			}
		}
		#endregion
	}
}
