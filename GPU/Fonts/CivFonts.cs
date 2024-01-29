using System;
using System.IO;
using System.IO.Compression;
using System.Xml.Serialization;
using IRB.Collections.Generic;

namespace OpenCiv1.GPU
{
	public class CivFonts: BDictionary<int, CivFont>
	{
		public CivFonts() : base()
		{ }

		public static CivFonts ImportFromOldStructure(byte[] fontStruct)
		{
			CivFonts fonts = new CivFonts();

			int iCount = FontStructReadWord(fontStruct, 0);

			for (int i = 0; i < iCount; i++)
			{
				CivFont font = new CivFont();
				int iFontPtr = FontStructReadWord(fontStruct, (i + 1) * 2);

				char cFirstCharCode = (char)fontStruct[iFontPtr - 8];
				char cLastCharCode = (char)fontStruct[iFontPtr - 7];
				int iBytesPerChar = fontStruct[iFontPtr - 6];
				int iCharWidth = fontStruct[iFontPtr - 5];
				int iCharHeight = fontStruct[iFontPtr - 4];
				int iCharWidthSpacing = fontStruct[iFontPtr - 3];
				int iLineSpacing = fontStruct[iFontPtr - 2];

				int iCharCodeRange = (int)(cLastCharCode - cFirstCharCode);
				int iFontWidthTablePtr = 0;
				if (iCharWidth == 0)
				{
					iFontWidthTablePtr = (ushort)(iFontPtr - 9 - iCharCodeRange);
				}
				int iCharTableRowWitdh = (ushort)((iCharCodeRange + 1) << (iBytesPerChar - 1));

				font.CharacterWidthSpacing = iCharWidthSpacing;
				font.LineSpacing = iLineSpacing;

				for (int j = 0; j < iCharCodeRange; j++)
				{
					CivFontCharacter fontChar = new CivFontCharacter();
					char ch = (char)(cFirstCharCode + j);

					if (iFontWidthTablePtr != 0)
					{
						fontChar.Width = fontStruct[iFontWidthTablePtr + j];
					}
					else
					{
						fontChar.Width = iCharWidth;
					}
					fontChar.Height = iCharHeight;

					// parse bitmap
					int iCharPtr = iFontPtr + (iBytesPerChar * j);
					int[][] aBitmap = new int[fontChar.Height][];

					for (int k = 0; k < fontChar.Height; k++)
					{
						int iBitCount = 0;
						int iValue = fontStruct[iCharPtr];
						int iByteCount = 0;
						aBitmap[k] = new int[fontChar.Width];

						for (int l = 0; l < fontChar.Width; l++)
						{
							if (iBitCount >= 8)
							{
								iBitCount = 0;
								iByteCount++;
								iValue = fontStruct[iCharPtr + iByteCount];
							}
							aBitmap[k][l] = 0;
							if ((iValue & 0x80) != 0)
							{
								aBitmap[k][l] = 1;
							}
							iBitCount++;
							iValue <<= 1;
						}
						iCharPtr += iCharTableRowWitdh;
					}
					fontChar.Bitmap = aBitmap;

					font.Characters.Add(ch, fontChar);
				}

				fonts.Add(i + 1, font);
			}

			return fonts;
		}

		private static ushort FontStructReadWord(byte[] fontBuffer, int position)
		{
			return (ushort)((ushort)fontBuffer[position] | ((ushort)fontBuffer[position + 1] << 8));
		}

		/// <summary>
		/// Deserializes a CivFonts object.
		/// </summary>
		/// <param name="path">A path to the CivFonts xml</param>
		/// <returns>A deserialized CivFonts object</returns>
		public static CivFonts Deserialize(string path, bool gzipped)
		{
			return Deserialize(path + (gzipped ? ".gz" : ""));
		}

		/// <summary>
		/// Deserializes a GeneOntology object.
		/// Assumes file iz gzipped, if the filename ends with .gz
		/// </summary>
		/// <param name="path">A path to CivFonts xml</param>
		/// <returns>A deserialized CivFonts object</returns>
		public static CivFonts Deserialize(string path)
		{
			Stream reader;
			if (path.EndsWith(".gz"))
			{
				reader = new GZipStream(new BufferedStream(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read), 65536), CompressionMode.Decompress);
			}
			else
			{
				reader = new BufferedStream(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read), 65536);
			}

			CivFonts oObject = Deserialize(reader);

			reader.Close();

			return oObject;
		}

		/// <summary>
		/// Deserializes a CivFonts object.
		/// </summary>
		/// <param name="reader">A stream to read the object from.</param>
		/// <returns>A deserialized CivFonts object.</returns>
		public static CivFonts Deserialize(Stream reader)
		{
			XmlSerializer ser = new XmlSerializer(typeof(CivFonts));
			object? obj = ser.Deserialize(reader);
			if (obj == null)
				throw new Exception("Can't deserialize object");

			CivFonts newObj = (CivFonts)obj;

			return newObj;
		}

		/// <summary>
		/// Serializes a CivFonts object.
		/// </summary>
		/// <param name="path">A path to serialize CivFonts to</param>
		public void Serialize(string path, bool gzipped)
		{
			Serialize(path + (gzipped ? ".gz" : ""));
		}

		/// <summary>
		/// Serializes a CivFonts object.
		/// Assumes file iz gzipped, if the filename ends with .gz
		/// </summary>
		/// <param name="filePath">A path to a object xml file</param>
		public void Serialize(string filePath)
		{
			StreamWriter writer;
			if (filePath.EndsWith(".gz"))
			{
				writer = new StreamWriter(new GZipStream(new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read), CompressionMode.Compress));
			}
			else
			{
				writer = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read));
			}

			Serialize(writer);

			writer.Flush();
			writer.Close();
		}

		/// <summary>
		/// Serializes a CivFonts object.
		/// </summary>
		/// <param name="writer">A stream to serialize the object to.</param>
		public void Serialize(StreamWriter writer)
		{
			XmlSerializer ser = new XmlSerializer(typeof(CivFonts));
			ser.Serialize(writer, this);
		}
	}
}
