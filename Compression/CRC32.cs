using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace OpenCiv1
{
	public static class CRC32
	{
		private static uint[] table = new uint[256];

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
				table[i] = rem;
			}
		}

		public static uint GetCRC32(byte[] buf)
		{
			uint crc = 0xffffffff;

			for (int i = 0; i < buf.Length; i++)
			{
				crc = (crc >> 8) ^ table[(crc & 0xff) ^ buf[i]];
			}

			return ~crc;
		}

		public static uint GetCRC32(List<byte> buf)
		{
			uint crc = 0xffffffff;

			for (int i = 0; i < buf.Count; i++)
			{
				crc = (crc >> 8) ^ table[(crc & 0xff) ^ buf[i]];
			}

			return ~crc;
		}
	}
}
