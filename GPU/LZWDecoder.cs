using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civilization1.GPU
{
	public class LZWDecoder
	{
		// non functional LZW decoder I used for Win CIV, but had to try on DOS CIV
		public static void Decode(Stream reader)
		{
			int iUndefined = reader.ReadByte() | (reader.ReadByte() << 8);
			int iWidth = reader.ReadByte() | (reader.ReadByte() << 8);
			int iHeight = reader.ReadByte() | (reader.ReadByte() << 8);
			int iBitCount = Math.Min(reader.ReadByte(), 0xb);

			// uncompressed buffer
			int iBufferPosition = 0;
			byte[] aBuffer = new byte[iWidth * iHeight];

			int iPreviousPosition = -1;
			int iMask = 1;
			int iResetBitCount = iBitCount; // To handle clear codes
			int iClearCode = 1 << iBitCount; // This varies depending on code_length
			int iStopCode = iClearCode + 1;  // one more than clear code

			// Create a dictionary large enough to hold "code_length" entries. 
			// Once the dictionary overflows, code_length increases. 
			// Initialize the first 2^code_len entries of the dictionary with their 
			// indices. The rest of the entries will be built up dynamically. 
			// Technically, it shouldn't be necessary to initialize the 
			// dictionary. The spec says that the encoder "should output a 
			// clear code as the first code in the image data stream". It doesn't 
			// say must, though...
			List<LZWDictionaryEntry> aDictionary = new List<LZWDictionaryEntry>();

			for (int i = 0; i < iClearCode; i++)
			{
				aDictionary.Add(new LZWDictionaryEntry(i, -1, 1));
			}
			aDictionary.Add(null); // clearcode, this is a dummy entry
			aDictionary.Add(null); // clearcode + 1, this is a dummy entry
			int iDictionaryLength = iClearCode + 2; // 2^code_len + 1 is the special "end" code; don't give it an entry here

			int inputLength = (int)(reader.Length - reader.Position - 2);
			int iChunkLength = reader.ReadByte();
			int input = reader.ReadByte();
			int iCode = 0x0;

			// TODO verify that the very last byte is iClearCode + 1
			while (inputLength > 0)
			{
				iCode = 0x0;

				// Always read one more bit than the code length
				for (int i = 0; i <= iBitCount; i++)
				{
					iCode |= (((input & iMask) != 0 ? 1 : 0) << i);
					iMask <<= 1;

					if (iMask == 0x100)
					{
						iMask = 1;
						iChunkLength--;
						if (iChunkLength <= 0)
						{
							iChunkLength = reader.ReadByte();
							inputLength--;
						}
						input = reader.ReadByte();
						inputLength--;
					}
				}

				if (iCode == iClearCode)
				{
					iBitCount = iResetBitCount;
					if (aDictionary.Count > iClearCode + 2)
						aDictionary.RemoveRange(iClearCode + 2, aDictionary.Count - iClearCode - 2);
					iDictionaryLength = iClearCode + 2; // 2^code_len + 1 is the special "end" code; don't give it an entry here
					iPreviousPosition = -1;
					continue;
				}
				else if (iCode == iStopCode)
				{
					if (inputLength > 1 && iBufferPosition < aBuffer.Length)
					{
						// only if we don't have all of the data (iBufferPosition < aBuffer.Length)
						Console.Write($"Malformed LZW (early stop code), mask 0x{iMask:x}, chunk length: 0x{iChunkLength:x}, "+
							$"buffer position: 0x{iBufferPosition:x}, buffer length: 0x{aBuffer.Length:x}, stream length: 0x{inputLength:x}, stream data: [");
						for (int i = 0; i < inputLength; i++)
						{
							if (i > 0)
								Console.Write(", ");
							Console.Write("0x{0:x}", reader.ReadByte());
						}
						Console.WriteLine("]");
					}
					break;
				}

				// Update the dictionary with this character plus the _entry_
				// (character or string) that came before it
				if ((iPreviousPosition > -1))
				{
					if (iCode > iDictionaryLength)
					{
						throw new Exception(string.Format("iCode = 0x{0:x}, but iDictionaryIndex = 0x{1:x}", iCode, iDictionaryLength));
					}

					// Special handling for KwKwK
					if (iCode < iDictionaryLength)
					{
						int iPosition = iCode;

						while (aDictionary[iPosition].PreviousPosition != -1)
						{
							iPosition = aDictionary[iPosition].PreviousPosition;
						}
						aDictionary.Add(new LZWDictionaryEntry(aDictionary[iPosition].Code));
					}
					else
					{
						int iPosition = iPreviousPosition;

						while (aDictionary[iPosition].PreviousPosition != -1)
						{
							iPosition = aDictionary[iPosition].PreviousPosition;
						}
						aDictionary.Add(new LZWDictionaryEntry(aDictionary[iPosition].Code));
					}

					aDictionary[iDictionaryLength].PreviousPosition = iPreviousPosition;
					aDictionary[iDictionaryLength].Length = aDictionary[iPreviousPosition].Length + 1;

					iDictionaryLength++;

					// GIF89a mandates that this stops at 12 bits
					if ((iDictionaryLength >= (1 << (iBitCount + 1))) &&
						 (iBitCount < 11))
					{
						iBitCount++;
					}
				}

				iPreviousPosition = iCode;

				// Now copy the dictionary entry backwards into buffer
				int iMatchLength = aDictionary[iCode].Length;

				while (iCode != -1)
				{
					aBuffer[iBufferPosition + aDictionary[iCode].Length - 1] = (byte)(aDictionary[iCode].Code & 0xff);
					if (aDictionary[iCode].PreviousPosition == iCode)
					{
						throw new Exception("Internal error; self-reference.");
					}
					iCode = aDictionary[iCode].PreviousPosition;
				}

				iBufferPosition += iMatchLength;
			}
			if (iCode != iStopCode)
				throw new Exception("LZW stream doesn't end with stop code");
		}

		private class LZWDictionaryEntry
		{
			public int Code = 0;
			public int PreviousPosition = -1;
			public int Length = 1;

			public LZWDictionaryEntry()
			{ }

			public LZWDictionaryEntry(int code)
			{
				this.Code = code;
			}

			public LZWDictionaryEntry(int code, int previousPosition, int length)
			{
				this.Code = code;
				this.PreviousPosition = previousPosition;
				this.Length = length;
			}
		}
	}
}
