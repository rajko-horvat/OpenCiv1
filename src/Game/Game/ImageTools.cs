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
		private GameData oGameData;

		public ImageTools(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		#region New Image loading functions
		/// <summary>
		/// Loads and .pic or .map Image from given filenamePtr with optional palette data
		/// </summary>
		/// <param name="screenID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="filenamePtr"></param>
		/// <param name="palettePtr"></param>
		public void F0_2fa1_01a2_LoadBitmapOrPalette(short screenID, int xPos, int yPos, ushort filenamePtr, ushort palettePtr)
		{
			string filename = MSCAPI.GetDOSFileName(this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.Word, filenamePtr)).ToUpper());

			F0_2fa1_01a2_LoadBitmapOrPalette(screenID, xPos, yPos, filename, palettePtr);
		}
		
		/// <summary>
		/// Loads and .pic or .map Image from given filename with optional palette data
		/// </summary>
		/// <param name="screenID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="filenamePtr"></param>
		/// <param name="palettePtr"></param>
		/// <exception cref="Exception"></exception>
		public void F0_2fa1_01a2_LoadBitmapOrPalette(short screenID, int xPos, int yPos, string filename, ushort palettePtr)
		{
			filename = VCPU.DefaultCIVPath + filename;

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
									this.oCPU.WriteUInt8(this.oCPU.DS.Word, startPtr++, palette[i]);
								}
								break;
							case 1:
								startPtr = 0xba06;
								for (int i = 0; i < palette.Length; i++)
								{
									this.oCPU.WriteUInt8(this.oCPU.DS.Word, startPtr++, palette[i]);
								}
								break;

							default:
								startPtr = palettePtr;
								for (int i = 0; i < palette.Length; i++)
								{
									this.oCPU.WriteUInt8(this.oCPU.DS.Word, startPtr++, palette[i]);
								}
								break;
						}
						if (palettePtr == 1 || palettePtr == 0xba06)
							this.oParent.Graphics.SetColorsFromColorStruct(palette);
					}
				}
				else
				{
					throw new Exception($"The screen {screenID} is not allocated");
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
								this.oCPU.WriteUInt8(this.oCPU.DS.Word, startPtr++, palette[i]);
							}
							break;
						case 1:
							startPtr = 0xba06;
							for (int i = 0; i < palette.Length; i++)
							{
								this.oCPU.WriteUInt8(this.oCPU.DS.Word, startPtr++, palette[i]);
							}
							break;

						default:
							startPtr = palettePtr;
							for (int i = 0; i < palette.Length; i++)
							{
								this.oCPU.WriteUInt8(this.oCPU.DS.Word, startPtr++, palette[i]);
							}
							break;
					}
					if (palettePtr == 1 || palettePtr == 0xba06)
						this.oParent.Graphics.SetColorsFromColorStruct(palette);
				}
			}
		}

		/// <summary>
		/// Loads and .pic or .map Image from given filename with optional palette data
		/// </summary>
		/// <param name="screenID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="filenamePtr"></param>
		/// <param name="palettePtr"></param>
		/// <exception cref="Exception"></exception>
		public void F0_2fa1_01a2_LoadBitmapOrPalette(short screenID, int xPos, int yPos, string filename, out byte[] palette)
		{
			filename = VCPU.DefaultCIVPath + filename;

			if (screenID >= 0 && (Path.GetExtension(filename).Equals(".pic", StringComparison.InvariantCultureIgnoreCase) ||
				Path.GetExtension(filename).Equals(".map", StringComparison.InvariantCultureIgnoreCase)))
			{
				if (this.oParent.Graphics.Screens.ContainsKey(screenID))
				{
					this.oParent.Graphics.Screens.GetValueByKey(screenID).LoadPIC(filename, xPos, yPos, out palette);
				}
				else
				{
					throw new Exception($"The screen {screenID} is not allocated");
				}
			}
			else
			{
				// function body
				GBitmap.ReadPaletteFromPICFile(filename, out palette);
			}
		}

		/// <summary>
		/// Loads an Bitmap (Icon) from given image Filename
		/// </summary>
		/// <param name="filenamePtr"></param>
		public int F0_2fa1_044c_LoadIcon(ushort filenamePtr)
		{
			return this.oParent.Graphics.LoadIcon(MSCAPI.GetDOSFileName(this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.Word, filenamePtr)).ToUpper()));
		}
		#endregion
	}
}
