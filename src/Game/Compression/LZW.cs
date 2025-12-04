using System;
using IRB.Collections.Generic;

namespace OpenCiv1.Compression
{
	/// <summary>
	/// Lempel–Ziv–Welch compression algorithm as implemented in original Civilization game
	/// </summary>
	public class LZW
	{
		public static void Compress(Stream output, Stream input, int startBitCount, int maxBitCount)
		{
			int iBitCount = startBitCount; // we start with current dictionary size
			int iBitMask = (1 << iBitCount) - 1;
			int iOutputLength = 0;
			int iOutputData = 0;
			BDictionary<LZWWord, int> aDictionary = new BDictionary<LZWWord, int>();
			List<byte> w = new List<byte>();
			List<byte> wc = new List<byte>();

			// initialize dictionary
			for (int i = 0; i < 256; i++)
			{
				aDictionary.Add(new LZWWord((byte)i), aDictionary.Count);
			}
			aDictionary.Add(LZWWord.Empty, aDictionary.Count); // ignore position 256

			// write our maximum dictionary bit count
			output.WriteByte((byte)maxBitCount);

			int c;

			while ((c = input.ReadByte()) >= 0)
			{
				wc.Clear();
				wc.AddRange(w);
				wc.Add((byte)c);

				if (aDictionary.ContainsKey(new LZWWord(wc)))
				{
					w.Clear();
					w.AddRange(wc);
				}
				else
				{
					// write w to output
					int iNewValue = aDictionary.GetValueByKey(new LZWWord(w));

					iOutputData |= iNewValue << iOutputLength;
					iOutputLength += iBitCount;

					while (iOutputLength >= 8)
					{
						output.WriteByte((byte)(iOutputData & 0xff));

						iOutputData >>= 8;
						iOutputLength -= 8;
					}

					if (aDictionary.Count > iBitMask)
					{
						// it's a time to increase number of bits for a dictionary
						iBitCount++;
						iBitMask = (1 << iBitCount) - 1;

						w.Clear();
						w.Add((byte)c);
					}

					if (iBitCount > maxBitCount)
					{
						// we start from beginning
						iBitCount = startBitCount;
						iBitMask = (1 << iBitCount) - 1;
						aDictionary.Clear();

						for (int j = 0; j < 256; j++)
						{
							aDictionary.Add(new LZWWord((byte)j), aDictionary.Count);
						}
						aDictionary.Add(LZWWord.Empty, aDictionary.Count); // ignore position 256

						input.Position--;
						w.Clear();
					}
					else
					{
						// wc is a new sequence; add it to the dictionary
						aDictionary.Add(new LZWWord(wc), aDictionary.Count);
						w.Clear();
						w.Add((byte)c);
					}
				}
			}

			// write remaining output, if necessary
			if (w.Count > 0)
			{
				int iNewValue = aDictionary.GetValueByKey(new LZWWord(w));

				iOutputData |= iNewValue << iOutputLength;
				iOutputLength += iBitCount;

				while (iOutputLength >= 8)
				{
					output.WriteByte((byte)(iOutputData & 0xff));

					iOutputData >>= 8;
					iOutputLength -= 8;
				}

				if (iOutputLength > 0)
				{
					output.WriteByte((byte)(iOutputData & 0xff));
				}
			}
		}

		public static void Decompress(Stream output, Stream input, int startBitCount, int maxBitCount)
		{
			int iInputData = 0;
			int iInputLength = 0;
			int iBitCount = startBitCount;
			int iBitMask = (1 << iBitCount) - 1;

			BDictionary<int, byte[]> aDictionary = new BDictionary<int, byte[]>();

			// initial dictionary
			for (int i = 0; i < 256; i++)
			{
				aDictionary.Add(i, new byte[] { (byte)i });
			}

			List<byte> w = new List<byte>();
			w.Add(0); // ignore position 256

			while (true)
			{
				// read encoded value
				while (iInputLength < iBitCount)
				{
					int c = input.ReadByte();
					if (c < 0)
						break;

					iInputData |= c << iInputLength;
					iInputLength += 8; // byte is 8 bits
				}

				if (iInputLength < iBitCount)
					break;

				int iNewValue = iInputData & iBitMask;

				// test if old compressor skipped code 256 altogether
				if (iNewValue == 256)
					throw new Exception("Code 256");

				iInputLength -= iBitCount;
				iInputData >>= iBitCount;

				// compare encoded value against dictionary
				List<byte> entry = new List<byte>();

				if (aDictionary.ContainsKey(iNewValue))
				{
					entry.AddRange(aDictionary.GetValueByKey(iNewValue));
				}
				else if (iNewValue == aDictionary.Count)
				{
					entry.AddRange(w);
					if (w.Count > 0)
						entry.Add(w[0]);
				}

				// write sequence to output
				for (int i = 0; i < entry.Count; i++)
					output.WriteByte(entry[i]);

				if (entry.Count > 0)
					w.Add(entry[0]);

				if (aDictionary.Count >= iBitMask)
				{
					// increase bit count
					iBitCount++;
					iBitMask = (1 << iBitCount) - 1;
				}

				if (iBitCount > maxBitCount)
				{
					// reinitialize dictionary
					iBitCount = startBitCount;
					iBitMask = (1 << iBitCount) - 1;

					aDictionary = new BDictionary<int, byte[]>();

					for (int i = 0; i < 256; i++)
					{
						aDictionary.Add(i, new byte[] { (byte)i });
					}

					w.Clear();
					w.Add(0); // ignore position 256
				}
				else
				{
					if (w.Count > 0)
					{
						// add new sequence to dictionary
						aDictionary.Add(aDictionary.Count, w.ToArray());
					}

					w.Clear();
					w.AddRange(entry);
				}
			}
		}
	}
}
