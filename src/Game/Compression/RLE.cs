using System;

namespace OpenCiv1.Compression
{
	/// <summary>
	/// Run-length compression algorithm as implemented in original Civilization game
	/// </summary>
	public static class RLE
	{
		public static void Compress(Stream output, Stream input, int minCount)
		{
			int iOldValue = -1;
			int iCount = 0;
			int c;
			minCount = Math.Max(minCount, 2);

			while ((c = input.ReadByte()) >= 0)
			{
				if (c < 0)
					break;

				if (c == iOldValue && iCount < 255)
				{
					iCount++;
				}
				else
				{
					if (iCount > minCount)
					{
						output.WriteByte((byte)iOldValue);
						if (iOldValue == 0x90)
							output.WriteByte(0);
						output.WriteByte(0x90);
						output.WriteByte((byte)iCount);

						iOldValue = c;
						iCount = 1;
					}
					else
					{
						for (int i = 0; i < iCount; i++)
						{
							output.WriteByte((byte)iOldValue);
							if (iOldValue == 0x90)
								output.WriteByte(0);
						}
						iOldValue = c;
						iCount = 1;
					}
				}
			}
			if (iCount > minCount)
			{
				output.WriteByte((byte)iOldValue);
				if (iOldValue == 0x90)
					output.WriteByte(0);
				output.WriteByte(0x90);
				output.WriteByte((byte)iCount);
			}
			else
			{
				for (int i = 0; i < iCount; i++)
				{
					output.WriteByte((byte)iOldValue);
					if (iOldValue == 0x90)
						output.WriteByte(0);
				}
			}
		}

		public static void Decompress(Stream output, Stream input)
		{
			byte ubOldValue = 0;
			int c;

			while ((c = input.ReadByte()) >= 0)
			{
				if (c == 0x90)
				{
					int iLength = input.ReadByte();
					if (iLength < 0)
						break;

					if (iLength == 0)
					{
						ubOldValue = (byte)c;
						output.WriteByte(ubOldValue);
					}
					else
					{
						for (int i = 1; i < iLength; i++)
						{
							output.WriteByte(ubOldValue);
						}
					}
				}
				else
				{
					ubOldValue = (byte)c;
					output.WriteByte(ubOldValue);
				}
			}
		}
	}
}
