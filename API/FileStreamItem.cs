using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civilization1
{
	public enum FileStreamTypeEnum
	{
		Binary,
		Text
	}

	public class FileStreamItem
	{
		private FileStreamTypeEnum eType = FileStreamTypeEnum.Binary;
		private FileStream oStream;
		private bool bLineEnd = false;
		private char cLastEndChar = '\r';
		private short sUnGetC = -1;

		public FileStreamItem(FileStream stream)
		{
			this.oStream = stream;
		}

		public FileStreamItem(FileStream stream, FileStreamTypeEnum type)
		{
			this.oStream = stream;
			this.eType = type;
		}

		public short ReadChar()
		{
			if (this.eType == FileStreamTypeEnum.Binary)
			{
				if (this.sUnGetC != -1)
				{
					return this.UnGetC;
				}

				return (short)this.oStream.ReadByte();
			}

			while (true)
			{
				int ich;

				if (this.sUnGetC != -1)
				{
					ich = this.UnGetC;
				}
				else
				{
					ich = this.oStream.ReadByte();
				}
				if (ich == -1)
					return -1;

				char ch = (char)ich;
				if (ch == '\r' || ch == '\n')
				{
					if (bLineEnd)
					{
						if (cLastEndChar == ch)
						{
							return (short)ch;
						}
						else
						{
							bLineEnd = false;
							continue;
						}
					}
					else
					{
						bLineEnd = true;
						cLastEndChar = ch;
						return (short)'\n';
					}
				}

				return (short)ch;
			}
		}

		public FileStreamTypeEnum Type
		{
			get { return this.eType; }
		}

		public FileStream Stream
		{
			get { return this.oStream; }
		}

		public short UnGetC
		{
			set { this.sUnGetC = value; }
			get
			{
				short sTemp = this.sUnGetC;
				this.sUnGetC = -1;
				return sTemp;
			}
		}
	}
}
