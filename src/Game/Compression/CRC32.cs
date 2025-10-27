using Avalonia.Controls.Shapes;
using System;

namespace OpenCiv1
{
	public static class CRC32
	{
		private static uint[] crc32Table = new uint[256];

		static CRC32()
		{
			// Calculate CRC table
			for (int i = 0; i < 256; i++)
			{
				uint rem = (uint)i;  // remainder from polynomial division

				for (int j = 0; j < 8; j++)
				{
					if ((rem & 1) != 0)
					{
						rem >>= 1;
						rem ^= 0xedb88320;
					}
					else
					{
						rem >>= 1;
					}
				}
				crc32Table[i] = rem;
			}
		}

		public static uint GetCRC32(byte[] buffer)
		{
			uint crc = 0xffffffff;

			for (int i = 0; i < buffer.Length; i++)
			{
				crc = (crc >> 8) ^ crc32Table[(crc & 0xff) ^ buffer[i]];
			}

			return ~crc;
		}

		public static uint GetCRC32(List<byte> buffer)
		{
			uint crc = 0xffffffff;

			for (int i = 0; i < buffer.Count; i++)
			{
				crc = (crc >> 8) ^ crc32Table[(crc & 0xff) ^ buffer[i]];
			}

			return ~crc;
		}

		public static uint GetCRC32(List<uint> buffer)
		{
			uint crc = 0xffffffff;

			for (int i = 0; i < buffer.Count; i++)
			{
				uint uintValue = buffer[i];

				crc = (crc >> 8) ^ crc32Table[(crc & 0xff) ^ (uintValue & 0xff)];
				crc = (crc >> 8) ^ crc32Table[(crc & 0xff) ^ ((uintValue & 0xff00) >> 8)];
				crc = (crc >> 8) ^ crc32Table[(crc & 0xff) ^ ((uintValue & 0xff0000) >> 16)];
				crc = (crc >> 8) ^ crc32Table[(crc & 0xff) ^ ((uintValue & 0xff000000) >> 24)];
			}

			return ~crc;
		}
	}
}
