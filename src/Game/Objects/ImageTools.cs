using System;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	/// <summary>
	/// Image loading functions - RLE and LZW compression was used
	/// </summary>
	public class ImageTools
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;

		public ImageTools(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		#region New Image loading functions
		/// <summary>
		/// Loads and .pic or .map Image from given filename with optional palette data
		/// </summary>
		/// <param name="screenID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="filenamePtr"></param>
		/// <param name="palettePtr"></param>
		/// <exception cref="Exception"></exception>
		public void F0_2fa1_01a2_LoadBitmapOrPalette(short screenID, ushort xPos, ushort yPos, ushort filenamePtr, ushort palettePtr)
		{
			string filename = VCPU.DefaultCIVPath +
				CAPI.GetDOSFileName(this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.UInt16, filenamePtr)).ToUpper());
			this.oCPU.Log.EnterBlock($"F0_2fa1_01a2_LoadBitmapOrPalette(0x{screenID:x4}, 0x{xPos:x4}, 0x{yPos:x4}, " +
				$"'{filename}', 0x{palettePtr:x4})");

			if (screenID >= 0 && (Path.GetExtension(filename).Equals(".pic", StringComparison.InvariantCultureIgnoreCase) ||
				Path.GetExtension(filename).Equals(".map", StringComparison.InvariantCultureIgnoreCase)))
			{
				if (this.oParent.Graphics.Screens.ContainsKey(screenID))
				{
					byte[] palette;
					ushort startPtr;
					this.oParent.Graphics.Screens.GetValueByKey(screenID).LoadPIC(filename, xPos, yPos, out palette);

					if (palette != null)
					{
						switch (palettePtr)
						{
							case 0:
								startPtr = 0xba08;
								for (int i = 0; i < palette.Length; i++)
								{
									this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, startPtr++, palette[i]);
								}
								break;
							case 1:
								startPtr = 0xba06;
								for (int i = 0; i < palette.Length; i++)
								{
									this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, startPtr++, palette[i]);
								}
								break;

							default:
								startPtr = palettePtr;
								for (int i = 0; i < palette.Length; i++)
								{
									this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, startPtr++, palette[i]);
								}
								break;
						}
						if (palettePtr == 1 || palettePtr == 0xba06)
							this.oParent.Graphics.SetColorsFromColorStruct(palette);
					}
				}
				else
				{
					throw new Exception($"The page {screenID} is not allocated");
				}
			}
			else
			{
				// function body
				byte[] palette;
				ushort startPtr;

				GBitmap.ReadPaletteFromPICFile(filename, out palette);
				if (palette != null)
				{
					switch (palettePtr)
					{
						case 0:
							startPtr = 0xba08;
							for (int i = 0; i < palette.Length; i++)
							{
								this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, startPtr++, palette[i]);
							}
							break;
						case 1:
							startPtr = 0xba06;
							for (int i = 0; i < palette.Length; i++)
							{
								this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, startPtr++, palette[i]);
							}
							break;

						default:
							startPtr = palettePtr;
							for (int i = 0; i < palette.Length; i++)
							{
								this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, startPtr++, palette[i]);
							}
							break;
					}
					if (palettePtr == 1 || palettePtr == 0xba06)
						this.oParent.Graphics.SetColorsFromColorStruct(palette);
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2fa1_01a2_LoadBitmapOrPalette");
		}

		/// <summary>
		/// Loads an Bitmap (Icon) from given image Filename
		/// </summary>
		/// <param name="filenamePtr"></param>
		public int F0_2fa1_044c_LoadIcon(ushort filenamePtr)
		{
			return this.oParent.Graphics.LoadIcon(CAPI.GetDOSFileName(this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.UInt16, filenamePtr))));
		}
		#endregion
	}
}
