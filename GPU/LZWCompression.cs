using IRB.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1.GPU
{
	public class LZWCompression
	{
		private class LZWState
		{
			public bool NibbleMode = false;
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

			public LZWState()
			{
				for (int i = 0; i < 2048; i++)
				{
					this.abDictionary[i * 3] = 0xff;
					this.abDictionary[i * 3 + 1] = 0xff;
					this.abDictionary[i * 3 + 2] = (byte)((i < 256) ? i : 0);
				}
			}

			public LZWState(bool nibbleMode) : this()
			{
				this.NibbleMode = nibbleMode;
			}
		}

		public static Bitmap ReadBitmapFromFile(string path)
		{
			Bitmap bitmap;
			FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
			List<BKeyValuePair<int, Color>> aPalette = new List<BKeyValuePair<int, Color>>();
			LZWState state = new LZWState();
			bool bNibbleMode = LoadPaletteFromStream(stream, state, aPalette);

			state.UnknownValue1 = ReadUInt16FromStream(stream);
			state.Width = ReadUInt16FromStream(stream);
			state.Height = ReadUInt16FromStream(stream);

			Console.WriteLine($"Bitmap: '{Path.GetFileName(path)}', unknown value: 0x{state.UnknownValue1:x4}");

			// init state
			if (state.Width > 0 && state.Height > 0)
			{
				ushort usTemp = ReadUInt16FromStream(stream);
				state.ClearCode = (byte)Math.Min((usTemp & 0xff), 0xb);
				state.InputData = (ushort)((usTemp & 0xff00) | state.ClearCode);

				state.Stride = (int)(Math.Ceiling((double)state.Width / 4.0) * 4.0);

				byte[] abBitmapData = new byte[state.Stride * state.Height];

				DecodeBitmapRow(stream, state, abBitmapData);

				bitmap = new Bitmap(state.Width, state.Height, PixelFormat.Format8bppIndexed);

				BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
					ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
				Marshal.Copy(abBitmapData, 0, bitmapData.Scan0, abBitmapData.Length);
				bitmap.UnlockBits(bitmapData);
			}
			else
			{
				state.Stride = (int)(Math.Ceiling((double)state.Width / 4.0) * 4.0);
				bitmap = new Bitmap(state.Width, state.Height, PixelFormat.Format8bppIndexed);
			}

			// set bitmap palette
			ColorPalette palette = bitmap.Palette;
			for (int i = 0; i < aPalette.Count; i++)
			{
				palette.Entries[aPalette[i].Key] = aPalette[i].Value;
			}
			bitmap.Palette = palette;

			stream.Close();

			return bitmap;
		}

		private static bool LoadPaletteFromStream(FileStream stream, LZWState state, List<BKeyValuePair<int, Color>> palette)
		{
			ushort usSignature;

			while (((usSignature = ReadUInt16FromStream(stream)) & 0xff) != 0x58)
			{
				int iLength = ReadUInt16FromStream(stream);

				// VGA 256 color palette signature
				if (usSignature == 0x304d)
				{
					int iIndex = stream.ReadByte();
					int iColorCount = stream.ReadByte();

					if (iIndex >= 0 && iColorCount >= 0)
					{
						iColorCount -= iIndex;
						iColorCount++;

						for (int i = 0; i < iColorCount; i++)
						{
							int iRed = stream.ReadByte();
							int iGreen = stream.ReadByte();
							int iBlue = stream.ReadByte();

							if (iRed < 0 || iGreen < 0 || iBlue < 0)
							{
								return false;
							}
							palette.Add(new BKeyValuePair<int, Color>(iIndex + i, VGABitmap.Color18ToColor(iRed, iGreen, iBlue)));
						}
					}
					else
					{
						return false;
					}
				}
				else
				{
					stream.Seek(iLength, SeekOrigin.Current);
				}
			}

			state.NibbleMode = (usSignature & 0x100) != 0;

			return true;
		}

		private static void DecodeBitmapRow(FileStream stream, LZWState state, byte[] dataBuffer)
		{
			int iBufferPos = 0;
			int iWidth = state.Width;

			if (state.NibbleMode)
			{
				iWidth++;
				iWidth >>= 1;
			}

			for (int i = 0; i < state.Height; i++)
			{
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
						if (state.NibbleMode)
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
				if (state.NibbleMode)
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
		}

		private static byte GetNextByte(FileStream stream, LZWState state)
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

				int iPosition;

				while (true)
				{
					iPosition = usCode * 3;
					usCode = (ushort)((ushort)state.abDictionary[iPosition] | ((ushort)state.abDictionary[iPosition + 1] << 8));
					if (usCode == 0xffff)
						break;

					state.DataStack.Push(state.abDictionary[iPosition + 2]);
				}

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

		private static ushort ReadUInt16FromStream(FileStream stream)
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
	}
}
