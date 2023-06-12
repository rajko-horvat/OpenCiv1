using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Disassembler
{
	public class VGACard : IDisposable
	{
		public enum ModeEnum : byte
		{
			Undefined = 0,
			Text80x25Color = 3,
			Graphics320x200x16 = 0xd,
			Graphics320x200x256 = 0x13
		}

		#region Font data
		byte[] abFont08 = new byte[256 * 8]{
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x7e, 0x81, 0xa5, 0x81, 0xbd, 0x99, 0x81, 0x7e,
			0x7e, 0xff, 0xdb, 0xff, 0xc3, 0xe7, 0xff, 0x7e,
			0x6c, 0xfe, 0xfe, 0xfe, 0x7c, 0x38, 0x10, 0x00,
			0x10, 0x38, 0x7c, 0xfe, 0x7c, 0x38, 0x10, 0x00,
			0x38, 0x7c, 0x38, 0xfe, 0xfe, 0x7c, 0x38, 0x7c,
			0x10, 0x10, 0x38, 0x7c, 0xfe, 0x7c, 0x38, 0x7c,
			0x00, 0x00, 0x18, 0x3c, 0x3c, 0x18, 0x00, 0x00,
			0xff, 0xff, 0xe7, 0xc3, 0xc3, 0xe7, 0xff, 0xff,
			0x00, 0x3c, 0x66, 0x42, 0x42, 0x66, 0x3c, 0x00,
			0xff, 0xc3, 0x99, 0xbd, 0xbd, 0x99, 0xc3, 0xff,
			0x0f, 0x07, 0x0f, 0x7d, 0xcc, 0xcc, 0xcc, 0x78,
			0x3c, 0x66, 0x66, 0x66, 0x3c, 0x18, 0x7e, 0x18,
			0x3f, 0x33, 0x3f, 0x30, 0x30, 0x70, 0xf0, 0xe0,
			0x7f, 0x63, 0x7f, 0x63, 0x63, 0x67, 0xe6, 0xc0,
			0x99, 0x5a, 0x3c, 0xe7, 0xe7, 0x3c, 0x5a, 0x99,
			0x80, 0xe0, 0xf8, 0xfe, 0xf8, 0xe0, 0x80, 0x00,
			0x02, 0x0e, 0x3e, 0xfe, 0x3e, 0x0e, 0x02, 0x00,
			0x18, 0x3c, 0x7e, 0x18, 0x18, 0x7e, 0x3c, 0x18,
			0x66, 0x66, 0x66, 0x66, 0x66, 0x00, 0x66, 0x00,
			0x7f, 0xdb, 0xdb, 0x7b, 0x1b, 0x1b, 0x1b, 0x00,
			0x3e, 0x63, 0x38, 0x6c, 0x6c, 0x38, 0xcc, 0x78,
			0x00, 0x00, 0x00, 0x00, 0x7e, 0x7e, 0x7e, 0x00,
			0x18, 0x3c, 0x7e, 0x18, 0x7e, 0x3c, 0x18, 0xff,
			0x18, 0x3c, 0x7e, 0x18, 0x18, 0x18, 0x18, 0x00,
			0x18, 0x18, 0x18, 0x18, 0x7e, 0x3c, 0x18, 0x00,
			0x00, 0x18, 0x0c, 0xfe, 0x0c, 0x18, 0x00, 0x00,
			0x00, 0x30, 0x60, 0xfe, 0x60, 0x30, 0x00, 0x00,
			0x00, 0x00, 0xc0, 0xc0, 0xc0, 0xfe, 0x00, 0x00,
			0x00, 0x24, 0x66, 0xff, 0x66, 0x24, 0x00, 0x00,
			0x00, 0x18, 0x3c, 0x7e, 0xff, 0xff, 0x00, 0x00,
			0x00, 0xff, 0xff, 0x7e, 0x3c, 0x18, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x30, 0x78, 0x78, 0x30, 0x30, 0x00, 0x30, 0x00,
			0x6c, 0x6c, 0x6c, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x6c, 0x6c, 0xfe, 0x6c, 0xfe, 0x6c, 0x6c, 0x00,
			0x30, 0x7c, 0xc0, 0x78, 0x0c, 0xf8, 0x30, 0x00,
			0x00, 0xc6, 0xcc, 0x18, 0x30, 0x66, 0xc6, 0x00,
			0x38, 0x6c, 0x38, 0x76, 0xdc, 0xcc, 0x76, 0x00,
			0x60, 0x60, 0xc0, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x18, 0x30, 0x60, 0x60, 0x60, 0x30, 0x18, 0x00,
			0x60, 0x30, 0x18, 0x18, 0x18, 0x30, 0x60, 0x00,
			0x00, 0x66, 0x3c, 0xff, 0x3c, 0x66, 0x00, 0x00,
			0x00, 0x30, 0x30, 0xfc, 0x30, 0x30, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x30, 0x30, 0x60,
			0x00, 0x00, 0x00, 0xfc, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x30, 0x30, 0x00,
			0x06, 0x0c, 0x18, 0x30, 0x60, 0xc0, 0x80, 0x00,
			0x7c, 0xc6, 0xce, 0xde, 0xf6, 0xe6, 0x7c, 0x00,
			0x30, 0x70, 0x30, 0x30, 0x30, 0x30, 0xfc, 0x00,
			0x78, 0xcc, 0x0c, 0x38, 0x60, 0xcc, 0xfc, 0x00,
			0x78, 0xcc, 0x0c, 0x38, 0x0c, 0xcc, 0x78, 0x00,
			0x1c, 0x3c, 0x6c, 0xcc, 0xfe, 0x0c, 0x1e, 0x00,
			0xfc, 0xc0, 0xf8, 0x0c, 0x0c, 0xcc, 0x78, 0x00,
			0x38, 0x60, 0xc0, 0xf8, 0xcc, 0xcc, 0x78, 0x00,
			0xfc, 0xcc, 0x0c, 0x18, 0x30, 0x30, 0x30, 0x00,
			0x78, 0xcc, 0xcc, 0x78, 0xcc, 0xcc, 0x78, 0x00,
			0x78, 0xcc, 0xcc, 0x7c, 0x0c, 0x18, 0x70, 0x00,
			0x00, 0x30, 0x30, 0x00, 0x00, 0x30, 0x30, 0x00,
			0x00, 0x30, 0x30, 0x00, 0x00, 0x30, 0x30, 0x60,
			0x18, 0x30, 0x60, 0xc0, 0x60, 0x30, 0x18, 0x00,
			0x00, 0x00, 0xfc, 0x00, 0x00, 0xfc, 0x00, 0x00,
			0x60, 0x30, 0x18, 0x0c, 0x18, 0x30, 0x60, 0x00,
			0x78, 0xcc, 0x0c, 0x18, 0x30, 0x00, 0x30, 0x00,
			0x7c, 0xc6, 0xde, 0xde, 0xde, 0xc0, 0x78, 0x00,
			0x30, 0x78, 0xcc, 0xcc, 0xfc, 0xcc, 0xcc, 0x00,
			0xfc, 0x66, 0x66, 0x7c, 0x66, 0x66, 0xfc, 0x00,
			0x3c, 0x66, 0xc0, 0xc0, 0xc0, 0x66, 0x3c, 0x00,
			0xf8, 0x6c, 0x66, 0x66, 0x66, 0x6c, 0xf8, 0x00,
			0xfe, 0x62, 0x68, 0x78, 0x68, 0x62, 0xfe, 0x00,
			0xfe, 0x62, 0x68, 0x78, 0x68, 0x60, 0xf0, 0x00,
			0x3c, 0x66, 0xc0, 0xc0, 0xce, 0x66, 0x3e, 0x00,
			0xcc, 0xcc, 0xcc, 0xfc, 0xcc, 0xcc, 0xcc, 0x00,
			0x78, 0x30, 0x30, 0x30, 0x30, 0x30, 0x78, 0x00,
			0x1e, 0x0c, 0x0c, 0x0c, 0xcc, 0xcc, 0x78, 0x00,
			0xe6, 0x66, 0x6c, 0x78, 0x6c, 0x66, 0xe6, 0x00,
			0xf0, 0x60, 0x60, 0x60, 0x62, 0x66, 0xfe, 0x00,
			0xc6, 0xee, 0xfe, 0xfe, 0xd6, 0xc6, 0xc6, 0x00,
			0xc6, 0xe6, 0xf6, 0xde, 0xce, 0xc6, 0xc6, 0x00,
			0x38, 0x6c, 0xc6, 0xc6, 0xc6, 0x6c, 0x38, 0x00,
			0xfc, 0x66, 0x66, 0x7c, 0x60, 0x60, 0xf0, 0x00,
			0x78, 0xcc, 0xcc, 0xcc, 0xdc, 0x78, 0x1c, 0x00,
			0xfc, 0x66, 0x66, 0x7c, 0x6c, 0x66, 0xe6, 0x00,
			0x78, 0xcc, 0xe0, 0x70, 0x1c, 0xcc, 0x78, 0x00,
			0xfc, 0xb4, 0x30, 0x30, 0x30, 0x30, 0x78, 0x00,
			0xcc, 0xcc, 0xcc, 0xcc, 0xcc, 0xcc, 0xfc, 0x00,
			0xcc, 0xcc, 0xcc, 0xcc, 0xcc, 0x78, 0x30, 0x00,
			0xc6, 0xc6, 0xc6, 0xd6, 0xfe, 0xee, 0xc6, 0x00,
			0xc6, 0xc6, 0x6c, 0x38, 0x38, 0x6c, 0xc6, 0x00,
			0xcc, 0xcc, 0xcc, 0x78, 0x30, 0x30, 0x78, 0x00,
			0xfe, 0xc6, 0x8c, 0x18, 0x32, 0x66, 0xfe, 0x00,
			0x78, 0x60, 0x60, 0x60, 0x60, 0x60, 0x78, 0x00,
			0xc0, 0x60, 0x30, 0x18, 0x0c, 0x06, 0x02, 0x00,
			0x78, 0x18, 0x18, 0x18, 0x18, 0x18, 0x78, 0x00,
			0x10, 0x38, 0x6c, 0xc6, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xff,
			0x30, 0x30, 0x18, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x78, 0x0c, 0x7c, 0xcc, 0x76, 0x00,
			0xe0, 0x60, 0x60, 0x7c, 0x66, 0x66, 0xdc, 0x00,
			0x00, 0x00, 0x78, 0xcc, 0xc0, 0xcc, 0x78, 0x00,
			0x1c, 0x0c, 0x0c, 0x7c, 0xcc, 0xcc, 0x76, 0x00,
			0x00, 0x00, 0x78, 0xcc, 0xfc, 0xc0, 0x78, 0x00,
			0x38, 0x6c, 0x60, 0xf0, 0x60, 0x60, 0xf0, 0x00,
			0x00, 0x00, 0x76, 0xcc, 0xcc, 0x7c, 0x0c, 0xf8,
			0xe0, 0x60, 0x6c, 0x76, 0x66, 0x66, 0xe6, 0x00,
			0x30, 0x00, 0x70, 0x30, 0x30, 0x30, 0x78, 0x00,
			0x0c, 0x00, 0x0c, 0x0c, 0x0c, 0xcc, 0xcc, 0x78,
			0xe0, 0x60, 0x66, 0x6c, 0x78, 0x6c, 0xe6, 0x00,
			0x70, 0x30, 0x30, 0x30, 0x30, 0x30, 0x78, 0x00,
			0x00, 0x00, 0xcc, 0xfe, 0xfe, 0xd6, 0xc6, 0x00,
			0x00, 0x00, 0xf8, 0xcc, 0xcc, 0xcc, 0xcc, 0x00,
			0x00, 0x00, 0x78, 0xcc, 0xcc, 0xcc, 0x78, 0x00,
			0x00, 0x00, 0xdc, 0x66, 0x66, 0x7c, 0x60, 0xf0,
			0x00, 0x00, 0x76, 0xcc, 0xcc, 0x7c, 0x0c, 0x1e,
			0x00, 0x00, 0xdc, 0x76, 0x66, 0x60, 0xf0, 0x00,
			0x00, 0x00, 0x7c, 0xc0, 0x78, 0x0c, 0xf8, 0x00,
			0x10, 0x30, 0x7c, 0x30, 0x30, 0x34, 0x18, 0x00,
			0x00, 0x00, 0xcc, 0xcc, 0xcc, 0xcc, 0x76, 0x00,
			0x00, 0x00, 0xcc, 0xcc, 0xcc, 0x78, 0x30, 0x00,
			0x00, 0x00, 0xc6, 0xd6, 0xfe, 0xfe, 0x6c, 0x00,
			0x00, 0x00, 0xc6, 0x6c, 0x38, 0x6c, 0xc6, 0x00,
			0x00, 0x00, 0xcc, 0xcc, 0xcc, 0x7c, 0x0c, 0xf8,
			0x00, 0x00, 0xfc, 0x98, 0x30, 0x64, 0xfc, 0x00,
			0x1c, 0x30, 0x30, 0xe0, 0x30, 0x30, 0x1c, 0x00,
			0x18, 0x18, 0x18, 0x00, 0x18, 0x18, 0x18, 0x00,
			0xe0, 0x30, 0x30, 0x1c, 0x30, 0x30, 0xe0, 0x00,
			0x76, 0xdc, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x10, 0x38, 0x6c, 0xc6, 0xc6, 0xfe, 0x00,
			0x78, 0xcc, 0xc0, 0xcc, 0x78, 0x18, 0x0c, 0x78,
			0x00, 0xcc, 0x00, 0xcc, 0xcc, 0xcc, 0x7e, 0x00,
			0x1c, 0x00, 0x78, 0xcc, 0xfc, 0xc0, 0x78, 0x00,
			0x7e, 0xc3, 0x3c, 0x06, 0x3e, 0x66, 0x3f, 0x00,
			0xcc, 0x00, 0x78, 0x0c, 0x7c, 0xcc, 0x7e, 0x00,
			0xe0, 0x00, 0x78, 0x0c, 0x7c, 0xcc, 0x7e, 0x00,
			0x30, 0x30, 0x78, 0x0c, 0x7c, 0xcc, 0x7e, 0x00,
			0x00, 0x00, 0x78, 0xc0, 0xc0, 0x78, 0x0c, 0x38,
			0x7e, 0xc3, 0x3c, 0x66, 0x7e, 0x60, 0x3c, 0x00,
			0xcc, 0x00, 0x78, 0xcc, 0xfc, 0xc0, 0x78, 0x00,
			0xe0, 0x00, 0x78, 0xcc, 0xfc, 0xc0, 0x78, 0x00,
			0xcc, 0x00, 0x70, 0x30, 0x30, 0x30, 0x78, 0x00,
			0x7c, 0xc6, 0x38, 0x18, 0x18, 0x18, 0x3c, 0x00,
			0xe0, 0x00, 0x70, 0x30, 0x30, 0x30, 0x78, 0x00,
			0xc6, 0x38, 0x6c, 0xc6, 0xfe, 0xc6, 0xc6, 0x00,
			0x30, 0x30, 0x00, 0x78, 0xcc, 0xfc, 0xcc, 0x00,
			0x1c, 0x00, 0xfc, 0x60, 0x78, 0x60, 0xfc, 0x00,
			0x00, 0x00, 0x7f, 0x0c, 0x7f, 0xcc, 0x7f, 0x00,
			0x3e, 0x6c, 0xcc, 0xfe, 0xcc, 0xcc, 0xce, 0x00,
			0x78, 0xcc, 0x00, 0x78, 0xcc, 0xcc, 0x78, 0x00,
			0x00, 0xcc, 0x00, 0x78, 0xcc, 0xcc, 0x78, 0x00,
			0x00, 0xe0, 0x00, 0x78, 0xcc, 0xcc, 0x78, 0x00,
			0x78, 0xcc, 0x00, 0xcc, 0xcc, 0xcc, 0x7e, 0x00,
			0x00, 0xe0, 0x00, 0xcc, 0xcc, 0xcc, 0x7e, 0x00,
			0x00, 0xcc, 0x00, 0xcc, 0xcc, 0x7c, 0x0c, 0xf8,
			0xc3, 0x18, 0x3c, 0x66, 0x66, 0x3c, 0x18, 0x00,
			0xcc, 0x00, 0xcc, 0xcc, 0xcc, 0xcc, 0x78, 0x00,
			0x18, 0x18, 0x7e, 0xc0, 0xc0, 0x7e, 0x18, 0x18,
			0x38, 0x6c, 0x64, 0xf0, 0x60, 0xe6, 0xfc, 0x00,
			0xcc, 0xcc, 0x78, 0xfc, 0x30, 0xfc, 0x30, 0x30,
			0xf8, 0xcc, 0xcc, 0xfa, 0xc6, 0xcf, 0xc6, 0xc7,
			0x0e, 0x1b, 0x18, 0x3c, 0x18, 0x18, 0xd8, 0x70,
			0x1c, 0x00, 0x78, 0x0c, 0x7c, 0xcc, 0x7e, 0x00,
			0x38, 0x00, 0x70, 0x30, 0x30, 0x30, 0x78, 0x00,
			0x00, 0x1c, 0x00, 0x78, 0xcc, 0xcc, 0x78, 0x00,
			0x00, 0x1c, 0x00, 0xcc, 0xcc, 0xcc, 0x7e, 0x00,
			0x00, 0xf8, 0x00, 0xf8, 0xcc, 0xcc, 0xcc, 0x00,
			0xfc, 0x00, 0xcc, 0xec, 0xfc, 0xdc, 0xcc, 0x00,
			0x3c, 0x6c, 0x6c, 0x3e, 0x00, 0x7e, 0x00, 0x00,
			0x38, 0x6c, 0x6c, 0x38, 0x00, 0x7c, 0x00, 0x00,
			0x30, 0x00, 0x30, 0x60, 0xc0, 0xcc, 0x78, 0x00,
			0x00, 0x00, 0x00, 0xfc, 0xc0, 0xc0, 0x00, 0x00,
			0x00, 0x00, 0x00, 0xfc, 0x0c, 0x0c, 0x00, 0x00,
			0xc3, 0xc6, 0xcc, 0xde, 0x33, 0x66, 0xcc, 0x0f,
			0xc3, 0xc6, 0xcc, 0xdb, 0x37, 0x6f, 0xcf, 0x03,
			0x18, 0x18, 0x00, 0x18, 0x18, 0x18, 0x18, 0x00,
			0x00, 0x33, 0x66, 0xcc, 0x66, 0x33, 0x00, 0x00,
			0x00, 0xcc, 0x66, 0x33, 0x66, 0xcc, 0x00, 0x00,
			0x22, 0x88, 0x22, 0x88, 0x22, 0x88, 0x22, 0x88,
			0x55, 0xaa, 0x55, 0xaa, 0x55, 0xaa, 0x55, 0xaa,
			0xdb, 0x77, 0xdb, 0xee, 0xdb, 0x77, 0xdb, 0xee,
			0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18, 0x18,
			0x18, 0x18, 0x18, 0x18, 0xf8, 0x18, 0x18, 0x18,
			0x18, 0x18, 0xf8, 0x18, 0xf8, 0x18, 0x18, 0x18,
			0x36, 0x36, 0x36, 0x36, 0xf6, 0x36, 0x36, 0x36,
			0x00, 0x00, 0x00, 0x00, 0xfe, 0x36, 0x36, 0x36,
			0x00, 0x00, 0xf8, 0x18, 0xf8, 0x18, 0x18, 0x18,
			0x36, 0x36, 0xf6, 0x06, 0xf6, 0x36, 0x36, 0x36,
			0x36, 0x36, 0x36, 0x36, 0x36, 0x36, 0x36, 0x36,
			0x00, 0x00, 0xfe, 0x06, 0xf6, 0x36, 0x36, 0x36,
			0x36, 0x36, 0xf6, 0x06, 0xfe, 0x00, 0x00, 0x00,
			0x36, 0x36, 0x36, 0x36, 0xfe, 0x00, 0x00, 0x00,
			0x18, 0x18, 0xf8, 0x18, 0xf8, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0xf8, 0x18, 0x18, 0x18,
			0x18, 0x18, 0x18, 0x18, 0x1f, 0x00, 0x00, 0x00,
			0x18, 0x18, 0x18, 0x18, 0xff, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0xff, 0x18, 0x18, 0x18,
			0x18, 0x18, 0x18, 0x18, 0x1f, 0x18, 0x18, 0x18,
			0x00, 0x00, 0x00, 0x00, 0xff, 0x00, 0x00, 0x00,
			0x18, 0x18, 0x18, 0x18, 0xff, 0x18, 0x18, 0x18,
			0x18, 0x18, 0x1f, 0x18, 0x1f, 0x18, 0x18, 0x18,
			0x36, 0x36, 0x36, 0x36, 0x37, 0x36, 0x36, 0x36,
			0x36, 0x36, 0x37, 0x30, 0x3f, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x3f, 0x30, 0x37, 0x36, 0x36, 0x36,
			0x36, 0x36, 0xf7, 0x00, 0xff, 0x00, 0x00, 0x00,
			0x00, 0x00, 0xff, 0x00, 0xf7, 0x36, 0x36, 0x36,
			0x36, 0x36, 0x37, 0x30, 0x37, 0x36, 0x36, 0x36,
			0x00, 0x00, 0xff, 0x00, 0xff, 0x00, 0x00, 0x00,
			0x36, 0x36, 0xf7, 0x00, 0xf7, 0x36, 0x36, 0x36,
			0x18, 0x18, 0xff, 0x00, 0xff, 0x00, 0x00, 0x00,
			0x36, 0x36, 0x36, 0x36, 0xff, 0x00, 0x00, 0x00,
			0x00, 0x00, 0xff, 0x00, 0xff, 0x18, 0x18, 0x18,
			0x00, 0x00, 0x00, 0x00, 0xff, 0x36, 0x36, 0x36,
			0x36, 0x36, 0x36, 0x36, 0x3f, 0x00, 0x00, 0x00,
			0x18, 0x18, 0x1f, 0x18, 0x1f, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x1f, 0x18, 0x1f, 0x18, 0x18, 0x18,
			0x00, 0x00, 0x00, 0x00, 0x3f, 0x36, 0x36, 0x36,
			0x36, 0x36, 0x36, 0x36, 0xff, 0x36, 0x36, 0x36,
			0x18, 0x18, 0xff, 0x18, 0xff, 0x18, 0x18, 0x18,
			0x18, 0x18, 0x18, 0x18, 0xf8, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x1f, 0x18, 0x18, 0x18,
			0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
			0x00, 0x00, 0x00, 0x00, 0xff, 0xff, 0xff, 0xff,
			0xf0, 0xf0, 0xf0, 0xf0, 0xf0, 0xf0, 0xf0, 0xf0,
			0x0f, 0x0f, 0x0f, 0x0f, 0x0f, 0x0f, 0x0f, 0x0f,
			0xff, 0xff, 0xff, 0xff, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x76, 0xdc, 0xc8, 0xdc, 0x76, 0x00,
			0x00, 0x78, 0xcc, 0xf8, 0xcc, 0xf8, 0xc0, 0xc0,
			0x00, 0xfc, 0xcc, 0xc0, 0xc0, 0xc0, 0xc0, 0x00,
			0x00, 0xfe, 0x6c, 0x6c, 0x6c, 0x6c, 0x6c, 0x00,
			0xfc, 0xcc, 0x60, 0x30, 0x60, 0xcc, 0xfc, 0x00,
			0x00, 0x00, 0x7e, 0xd8, 0xd8, 0xd8, 0x70, 0x00,
			0x00, 0x66, 0x66, 0x66, 0x66, 0x7c, 0x60, 0xc0,
			0x00, 0x76, 0xdc, 0x18, 0x18, 0x18, 0x18, 0x00,
			0xfc, 0x30, 0x78, 0xcc, 0xcc, 0x78, 0x30, 0xfc,
			0x38, 0x6c, 0xc6, 0xfe, 0xc6, 0x6c, 0x38, 0x00,
			0x38, 0x6c, 0xc6, 0xc6, 0x6c, 0x6c, 0xee, 0x00,
			0x1c, 0x30, 0x18, 0x7c, 0xcc, 0xcc, 0x78, 0x00,
			0x00, 0x00, 0x7e, 0xdb, 0xdb, 0x7e, 0x00, 0x00,
			0x06, 0x0c, 0x7e, 0xdb, 0xdb, 0x7e, 0x60, 0xc0,
			0x38, 0x60, 0xc0, 0xf8, 0xc0, 0x60, 0x38, 0x00,
			0x78, 0xcc, 0xcc, 0xcc, 0xcc, 0xcc, 0xcc, 0x00,
			0x00, 0xfc, 0x00, 0xfc, 0x00, 0xfc, 0x00, 0x00,
			0x30, 0x30, 0xfc, 0x30, 0x30, 0x00, 0xfc, 0x00,
			0x60, 0x30, 0x18, 0x30, 0x60, 0x00, 0xfc, 0x00,
			0x18, 0x30, 0x60, 0x30, 0x18, 0x00, 0xfc, 0x00,
			0x0e, 0x1b, 0x1b, 0x18, 0x18, 0x18, 0x18, 0x18,
			0x18, 0x18, 0x18, 0x18, 0x18, 0xd8, 0xd8, 0x70,
			0x30, 0x30, 0x00, 0xfc, 0x00, 0x30, 0x30, 0x00,
			0x00, 0x76, 0xdc, 0x00, 0x76, 0xdc, 0x00, 0x00,
			0x38, 0x6c, 0x6c, 0x38, 0x00, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x18, 0x18, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00,
			0x0f, 0x0c, 0x0c, 0x0c, 0xec, 0x6c, 0x3c, 0x1c,
			0x78, 0x6c, 0x6c, 0x6c, 0x6c, 0x00, 0x00, 0x00,
			0x70, 0x18, 0x30, 0x60, 0x78, 0x00, 0x00, 0x00,
			0x00, 0x00, 0x3c, 0x3c, 0x3c, 0x3c, 0x00, 0x00,
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00
			};
		#endregion

		#region Palette
		private Color[] aColorPalette = new Color[16] {
			Color.FromArgb(0x00, 0x00, 0x00),	// 0
			Color.FromArgb(0x00, 0x00, 0xaa),	// 1
			Color.FromArgb(0x00, 0xaa, 0x00),	// 2
			Color.FromArgb(0x00, 0xaa, 0xaa),	// 3
			Color.FromArgb(0xaa, 0x00, 0x00),	// 4
			Color.FromArgb(0xaa, 0x00, 0xaa),	// 5
			Color.FromArgb(0xaa, 0x55, 0x00),	// 6
			Color.FromArgb(0xaa, 0xaa, 0xaa),	// 7
			Color.FromArgb(0x55, 0x55, 0x55),	// 8
			Color.FromArgb(0x55, 0x55, 0xff),	// 9
			Color.FromArgb(0x55, 0xff, 0x55),	// 10
			Color.FromArgb(0x55, 0xff, 0xff),	// 11
			Color.FromArgb(0xff, 0x55, 0x55),	// 12
			Color.FromArgb(0xff, 0x55, 0xff),	// 13
			Color.FromArgb(0xff, 0xff, 0x55),	// 14
			Color.FromArgb(0xff, 0xff, 0xff)	// 15
		};

		private Color[] aColorPalette256 = new Color[] {
			Color.FromArgb(0x00, 0x00, 0x00),
			Color.FromArgb(0x00, 0x00, 0xaa),
			Color.FromArgb(0x00, 0xaa, 0x00),
			Color.FromArgb(0x00, 0xaa, 0xaa),
			Color.FromArgb(0xaa, 0x00, 0x00),
			Color.FromArgb(0xaa, 0x00, 0xaa),
			Color.FromArgb(0xaa, 0x55, 0x00),
			Color.FromArgb(0xaa, 0xaa, 0xaa),
			Color.FromArgb(0x55, 0x55, 0x55),
			Color.FromArgb(0x55, 0x55, 0xff),
			Color.FromArgb(0x55, 0xff, 0x55),
			Color.FromArgb(0x55, 0xff, 0xff),
			Color.FromArgb(0xff, 0x55, 0x55),
			Color.FromArgb(0xff, 0x55, 0xff),
			Color.FromArgb(0xff, 0xff, 0x55),
			Color.FromArgb(0xff, 0xff, 0xff),
			Color.FromArgb(0x00, 0x00, 0x00),
			Color.FromArgb(0x14, 0x14, 0x14),
			Color.FromArgb(0x20, 0x20, 0x20),
			Color.FromArgb(0x2c, 0x2c, 0x2c),
			Color.FromArgb(0x38, 0x38, 0x38),
			Color.FromArgb(0x45, 0x45, 0x45),
			Color.FromArgb(0x51, 0x51, 0x51),
			Color.FromArgb(0x61, 0x61, 0x61),
			Color.FromArgb(0x71, 0x71, 0x71),
			Color.FromArgb(0x82, 0x82, 0x82),
			Color.FromArgb(0x92, 0x92, 0x92),
			Color.FromArgb(0xa2, 0xa2, 0xa2),
			Color.FromArgb(0xb6, 0xb6, 0xb6),
			Color.FromArgb(0xcb, 0xcb, 0xcb),
			Color.FromArgb(0xe3, 0xe3, 0xe3),
			Color.FromArgb(0xff, 0xff, 0xff),
			Color.FromArgb(0x00, 0x00, 0xff),
			Color.FromArgb(0x41, 0x00, 0xff),
			Color.FromArgb(0x7d, 0x00, 0xff),
			Color.FromArgb(0xbe, 0x00, 0xff),
			Color.FromArgb(0xff, 0x00, 0xff),
			Color.FromArgb(0xff, 0x00, 0xbe),
			Color.FromArgb(0xff, 0x00, 0x7d),
			Color.FromArgb(0xff, 0x00, 0x41),
			Color.FromArgb(0xff, 0x00, 0x00),
			Color.FromArgb(0xff, 0x41, 0x00),
			Color.FromArgb(0xff, 0x7d, 0x00),
			Color.FromArgb(0xff, 0xbe, 0x00),
			Color.FromArgb(0xff, 0xff, 0x00),
			Color.FromArgb(0xbe, 0xff, 0x00),
			Color.FromArgb(0x7d, 0xff, 0x00),
			Color.FromArgb(0x41, 0xff, 0x00),
			Color.FromArgb(0x00, 0xff, 0x00),
			Color.FromArgb(0x00, 0xff, 0x41),
			Color.FromArgb(0x00, 0xff, 0x7d),
			Color.FromArgb(0x00, 0xff, 0xbe),
			Color.FromArgb(0x00, 0xff, 0xff),
			Color.FromArgb(0x00, 0xbe, 0xff),
			Color.FromArgb(0x00, 0x7d, 0xff),
			Color.FromArgb(0x00, 0x41, 0xff),
			Color.FromArgb(0x7d, 0x7d, 0xff),
			Color.FromArgb(0x9e, 0x7d, 0xff),
			Color.FromArgb(0xbe, 0x7d, 0xff),
			Color.FromArgb(0xdf, 0x7d, 0xff),
			Color.FromArgb(0xff, 0x7d, 0xff),
			Color.FromArgb(0xff, 0x7d, 0xdf),
			Color.FromArgb(0xff, 0x7d, 0xbe),
			Color.FromArgb(0xff, 0x7d, 0x9e),
			Color.FromArgb(0xff, 0x7d, 0x7d),
			Color.FromArgb(0xff, 0x9e, 0x7d),
			Color.FromArgb(0xff, 0xbe, 0x7d),
			Color.FromArgb(0xff, 0xdf, 0x7d),
			Color.FromArgb(0xff, 0xff, 0x7d),
			Color.FromArgb(0xdf, 0xff, 0x7d),
			Color.FromArgb(0xbe, 0xff, 0x7d),
			Color.FromArgb(0x9e, 0xff, 0x7d),
			Color.FromArgb(0x7d, 0xff, 0x7d),
			Color.FromArgb(0x7d, 0xff, 0x9e),
			Color.FromArgb(0x7d, 0xff, 0xbe),
			Color.FromArgb(0x7d, 0xff, 0xdf),
			Color.FromArgb(0x7d, 0xff, 0xff),
			Color.FromArgb(0x7d, 0xdf, 0xff),
			Color.FromArgb(0x7d, 0xbe, 0xff),
			Color.FromArgb(0x7d, 0x9e, 0xff),
			Color.FromArgb(0xb6, 0xb6, 0xff),
			Color.FromArgb(0xc7, 0xb6, 0xff),
			Color.FromArgb(0xdb, 0xb6, 0xff),
			Color.FromArgb(0xeb, 0xb6, 0xff),
			Color.FromArgb(0xff, 0xb6, 0xff),
			Color.FromArgb(0xff, 0xb6, 0xeb),
			Color.FromArgb(0xff, 0xb6, 0xdb),
			Color.FromArgb(0xff, 0xb6, 0xc7),
			Color.FromArgb(0xff, 0xb6, 0xb6),
			Color.FromArgb(0xff, 0xc7, 0xb6),
			Color.FromArgb(0xff, 0xdb, 0xb6),
			Color.FromArgb(0xff, 0xeb, 0xb6),
			Color.FromArgb(0xff, 0xff, 0xb6),
			Color.FromArgb(0xeb, 0xff, 0xb6),
			Color.FromArgb(0xdb, 0xff, 0xb6),
			Color.FromArgb(0xc7, 0xff, 0xb6),
			Color.FromArgb(0xb6, 0xff, 0xb6),
			Color.FromArgb(0xb6, 0xff, 0xc7),
			Color.FromArgb(0xb6, 0xff, 0xdb),
			Color.FromArgb(0xb6, 0xff, 0xeb),
			Color.FromArgb(0xb6, 0xff, 0xff),
			Color.FromArgb(0xb6, 0xeb, 0xff),
			Color.FromArgb(0xb6, 0xdb, 0xff),
			Color.FromArgb(0xb6, 0xc7, 0xff),
			Color.FromArgb(0x00, 0x00, 0x71),
			Color.FromArgb(0x1c, 0x00, 0x71),
			Color.FromArgb(0x38, 0x00, 0x71),
			Color.FromArgb(0x55, 0x00, 0x71),
			Color.FromArgb(0x71, 0x00, 0x71),
			Color.FromArgb(0x71, 0x00, 0x55),
			Color.FromArgb(0x71, 0x00, 0x38),
			Color.FromArgb(0x71, 0x00, 0x1c),
			Color.FromArgb(0x71, 0x00, 0x00),
			Color.FromArgb(0x71, 0x1c, 0x00),
			Color.FromArgb(0x71, 0x38, 0x00),
			Color.FromArgb(0x71, 0x55, 0x00),
			Color.FromArgb(0x71, 0x71, 0x00),
			Color.FromArgb(0x55, 0x71, 0x00),
			Color.FromArgb(0x38, 0x71, 0x00),
			Color.FromArgb(0x1c, 0x71, 0x00),
			Color.FromArgb(0x00, 0x71, 0x00),
			Color.FromArgb(0x00, 0x71, 0x1c),
			Color.FromArgb(0x00, 0x71, 0x38),
			Color.FromArgb(0x00, 0x71, 0x55),
			Color.FromArgb(0x00, 0x71, 0x71),
			Color.FromArgb(0x00, 0x55, 0x71),
			Color.FromArgb(0x00, 0x38, 0x71),
			Color.FromArgb(0x00, 0x1c, 0x71),
			Color.FromArgb(0x38, 0x38, 0x71),
			Color.FromArgb(0x45, 0x38, 0x71),
			Color.FromArgb(0x55, 0x38, 0x71),
			Color.FromArgb(0x61, 0x38, 0x71),
			Color.FromArgb(0x71, 0x38, 0x71),
			Color.FromArgb(0x71, 0x38, 0x61),
			Color.FromArgb(0x71, 0x38, 0x55),
			Color.FromArgb(0x71, 0x38, 0x45),
			Color.FromArgb(0x71, 0x38, 0x38),
			Color.FromArgb(0x71, 0x45, 0x38),
			Color.FromArgb(0x71, 0x55, 0x38),
			Color.FromArgb(0x71, 0x61, 0x38),
			Color.FromArgb(0x71, 0x71, 0x38),
			Color.FromArgb(0x61, 0x71, 0x38),
			Color.FromArgb(0x55, 0x71, 0x38),
			Color.FromArgb(0x45, 0x71, 0x38),
			Color.FromArgb(0x38, 0x71, 0x38),
			Color.FromArgb(0x38, 0x71, 0x45),
			Color.FromArgb(0x38, 0x71, 0x55),
			Color.FromArgb(0x38, 0x71, 0x61),
			Color.FromArgb(0x38, 0x71, 0x71),
			Color.FromArgb(0x38, 0x61, 0x71),
			Color.FromArgb(0x38, 0x55, 0x71),
			Color.FromArgb(0x38, 0x45, 0x71),
			Color.FromArgb(0x51, 0x51, 0x71),
			Color.FromArgb(0x59, 0x51, 0x71),
			Color.FromArgb(0x61, 0x51, 0x71),
			Color.FromArgb(0x69, 0x51, 0x71),
			Color.FromArgb(0x71, 0x51, 0x71),
			Color.FromArgb(0x71, 0x51, 0x69),
			Color.FromArgb(0x71, 0x51, 0x61),
			Color.FromArgb(0x71, 0x51, 0x59),
			Color.FromArgb(0x71, 0x51, 0x51),
			Color.FromArgb(0x71, 0x59, 0x51),
			Color.FromArgb(0x71, 0x61, 0x51),
			Color.FromArgb(0x71, 0x69, 0x51),
			Color.FromArgb(0x71, 0x71, 0x51),
			Color.FromArgb(0x69, 0x71, 0x51),
			Color.FromArgb(0x61, 0x71, 0x51),
			Color.FromArgb(0x59, 0x71, 0x51),
			Color.FromArgb(0x51, 0x71, 0x51),
			Color.FromArgb(0x51, 0x71, 0x59),
			Color.FromArgb(0x51, 0x71, 0x61),
			Color.FromArgb(0x51, 0x71, 0x69),
			Color.FromArgb(0x51, 0x71, 0x71),
			Color.FromArgb(0x51, 0x69, 0x71),
			Color.FromArgb(0x51, 0x61, 0x71),
			Color.FromArgb(0x51, 0x59, 0x71),
			Color.FromArgb(0x00, 0x00, 0x41),
			Color.FromArgb(0x10, 0x00, 0x41),
			Color.FromArgb(0x20, 0x00, 0x41),
			Color.FromArgb(0x30, 0x00, 0x41),
			Color.FromArgb(0x41, 0x00, 0x41),
			Color.FromArgb(0x41, 0x00, 0x30),
			Color.FromArgb(0x41, 0x00, 0x20),
			Color.FromArgb(0x41, 0x00, 0x10),
			Color.FromArgb(0x41, 0x00, 0x00),
			Color.FromArgb(0x41, 0x10, 0x00),
			Color.FromArgb(0x41, 0x20, 0x00),
			Color.FromArgb(0x41, 0x30, 0x00),
			Color.FromArgb(0x41, 0x41, 0x00),
			Color.FromArgb(0x30, 0x41, 0x00),
			Color.FromArgb(0x20, 0x41, 0x00),
			Color.FromArgb(0x10, 0x41, 0x00),
			Color.FromArgb(0x00, 0x41, 0x00),
			Color.FromArgb(0x00, 0x41, 0x10),
			Color.FromArgb(0x00, 0x41, 0x20),
			Color.FromArgb(0x00, 0x41, 0x30),
			Color.FromArgb(0x00, 0x41, 0x41),
			Color.FromArgb(0x00, 0x30, 0x41),
			Color.FromArgb(0x00, 0x20, 0x41),
			Color.FromArgb(0x00, 0x10, 0x41),
			Color.FromArgb(0x20, 0x20, 0x41),
			Color.FromArgb(0x28, 0x20, 0x41),
			Color.FromArgb(0x30, 0x20, 0x41),
			Color.FromArgb(0x38, 0x20, 0x41),
			Color.FromArgb(0x41, 0x20, 0x41),
			Color.FromArgb(0x41, 0x20, 0x38),
			Color.FromArgb(0x41, 0x20, 0x30),
			Color.FromArgb(0x41, 0x20, 0x28),
			Color.FromArgb(0x41, 0x20, 0x20),
			Color.FromArgb(0x41, 0x28, 0x20),
			Color.FromArgb(0x41, 0x30, 0x20),
			Color.FromArgb(0x41, 0x38, 0x20),
			Color.FromArgb(0x41, 0x41, 0x20),
			Color.FromArgb(0x38, 0x41, 0x20),
			Color.FromArgb(0x30, 0x41, 0x20),
			Color.FromArgb(0x28, 0x41, 0x20),
			Color.FromArgb(0x20, 0x41, 0x20),
			Color.FromArgb(0x20, 0x41, 0x28),
			Color.FromArgb(0x20, 0x41, 0x30),
			Color.FromArgb(0x20, 0x41, 0x38),
			Color.FromArgb(0x20, 0x41, 0x41),
			Color.FromArgb(0x20, 0x38, 0x41),
			Color.FromArgb(0x20, 0x30, 0x41),
			Color.FromArgb(0x20, 0x28, 0x41),
			Color.FromArgb(0x2c, 0x2c, 0x41),
			Color.FromArgb(0x30, 0x2c, 0x41),
			Color.FromArgb(0x34, 0x2c, 0x41),
			Color.FromArgb(0x3c, 0x2c, 0x41),
			Color.FromArgb(0x41, 0x2c, 0x41),
			Color.FromArgb(0x41, 0x2c, 0x3c),
			Color.FromArgb(0x41, 0x2c, 0x34),
			Color.FromArgb(0x41, 0x2c, 0x30),
			Color.FromArgb(0x41, 0x2c, 0x2c),
			Color.FromArgb(0x41, 0x30, 0x2c),
			Color.FromArgb(0x41, 0x34, 0x2c),
			Color.FromArgb(0x41, 0x3c, 0x2c),
			Color.FromArgb(0x41, 0x41, 0x2c),
			Color.FromArgb(0x3c, 0x41, 0x2c),
			Color.FromArgb(0x34, 0x41, 0x2c),
			Color.FromArgb(0x30, 0x41, 0x2c),
			Color.FromArgb(0x2c, 0x41, 0x2c),
			Color.FromArgb(0x2c, 0x41, 0x30),
			Color.FromArgb(0x2c, 0x41, 0x34),
			Color.FromArgb(0x2c, 0x41, 0x3c),
			Color.FromArgb(0x2c, 0x41, 0x41),
			Color.FromArgb(0x2c, 0x3c, 0x41),
			Color.FromArgb(0x2c, 0x34, 0x41),
			Color.FromArgb(0x2c, 0x30, 0x41),
			Color.FromArgb(0x00, 0x00, 0x00),
			Color.FromArgb(0x00, 0x00, 0x00),
			Color.FromArgb(0x00, 0x00, 0x00),
			Color.FromArgb(0x00, 0x00, 0x00),
			Color.FromArgb(0x00, 0x00, 0x00),
			Color.FromArgb(0x00, 0x00, 0x00),
			Color.FromArgb(0x00, 0x00, 0x00),
			Color.FromArgb(0x00, 0x00, 0x00)
		};
		#endregion

		private CPU oParent;
		private bool disposedValue = false;

		internal object oBitmapLock = new object();
		private byte[] aBitmapMemory = new byte[0x20000];
		private GCHandle oBitmapMemoryHandle;
		private IntPtr oBitmapMemoryAddress;
		private uint uiBitmapPage = 0;

		private VGACardForm oForm;
		private Bitmap oBitmap;

		// state
		private ModeEnum eMode = ModeEnum.Undefined;
		private int iWidth = 640;
		private int iHeight = 200;
		private bool bBitmapChanged = true;

		// printing
		private int iXPosition = 0;
		private int iYPosition = 0;
		private int iTextWidth = 80;
		private int iTextHeight = 25;
		private int iFontWidth = 8;
		private int iFontHeight = 8;
		private byte biTextForeColor = 15;
		private byte biTextBackColor = 0;
		private int iBytesPerLine = 160;
		private int iPixelsPerByte = 0;

		// specific VGA HW stuff
		private static int iNumberOfPlanes = 4;
		private static int iPlaneMemorySize = 0x10000;

		private byte biSequencerAddress = 0xff;
		private byte biMapWriteMask = 0xf;

		private byte biGraphicsAddress = 0xff;
		private byte biWriteSetReset = 0xf;
		private byte biEnableSetReset = 0;
		private byte biColorCompare = 0;
		private byte biMapReadSelect = 0;
		private byte biWriteBitMask = 0xff;
		private byte biGraphicsMode = 0x0;

		private bool bAttributeAddressFlag = true;
		private byte biAttributeAddress = 0xff;

		private byte biDACState = 0x0;
		private byte biDACReadAddress = 0x0;
		private int iDACReadIndex = -1;
		private byte biDACReadRed = 0x0;
		private byte biDACReadGreen = 0x0;
		private byte biDACReadBlue = 0x0;
		private byte biDACWriteAddress = 0x0;
		private int iDACWriteIndex = -1;
		private byte biDACWriteRed = 0x0;
		private byte biDACWriteGreen = 0x0;
		private byte biDACWriteBlue = 0x0;

		private byte[,] abMemoryPlanes = new byte[iNumberOfPlanes, iPlaneMemorySize];

		private byte ubHWStatus = 0xd;

		public VGACard(CPU parent)
		{
			this.oParent = parent;

			this.oBitmapMemoryHandle = GCHandle.Alloc(this.aBitmapMemory, GCHandleType.Pinned);
			this.oBitmapMemoryAddress = Marshal.UnsafeAddrOfPinnedArrayElement(this.aBitmapMemory, 0);
			this.oForm = new VGACardForm(this);

			// assume default 80x25 text mode
			this.Mode = (byte)ModeEnum.Text80x25Color;

			this.oForm.Show();

			Application.DoEvents();
		}

		#region Disposable members
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects)

					if (this.oBitmapMemoryHandle.IsAllocated)
					{
						oBitmapMemoryHandle.Free();
					}

					this.oBitmap.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override finalizer
				// TODO: set large fields to null
				this.oBitmapMemoryAddress = IntPtr.Zero;
				this.aBitmapMemory = null;
				this.oBitmap = null;
				this.disposedValue = true;
			}
		}

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion

		public CPU Parent
		{
			get { return this.oParent; }
		}

		public byte Mode
		{
			get
			{
				return (byte)this.eMode;
			}
			set
			{
				lock (this.oBitmapLock)
				{
					switch (value)
					{
						case 3:
							this.eMode = ModeEnum.Text80x25Color;
							this.iWidth = 640;
							this.iHeight = 200;
							this.iXPosition = 0;
							this.iYPosition = 0;
							this.iTextWidth = 80;
							this.iTextHeight = 25;
							this.biTextForeColor = 15;
							this.biTextBackColor = 0;
							this.iPixelsPerByte = 0;
							this.iBytesPerLine = 160;

							this.oBitmap = new Bitmap(this.iWidth, this.iHeight, this.iWidth, PixelFormat.Format8bppIndexed, this.oBitmapMemoryAddress);
							InitPalette(this.aColorPalette);
							this.oForm.ClientSize = new Size(this.iWidth, this.iHeight);
							break;

						case 0xd:
							this.eMode = ModeEnum.Graphics320x200x16;
							this.iWidth = 320;
							this.iHeight = 200;
							this.iXPosition = 0;
							this.iYPosition = 0;
							this.iTextWidth = 40;
							this.iTextHeight = 25;
							this.biTextForeColor = 15;
							this.biTextBackColor = 0;
							this.iPixelsPerByte = 8;
							this.iBytesPerLine = 320 / this.iPixelsPerByte;

							// GPU HW stuff
							this.biSequencerAddress = 0xff;
							this.biMapWriteMask = 0xf;

							this.biGraphicsAddress = 0xff;
							this.biWriteSetReset = 0xf;
							this.biEnableSetReset = 0xf;
							this.biMapReadSelect = 0;
							this.biWriteBitMask = 0xff;

							this.oBitmap = new Bitmap(this.iWidth, this.iHeight, this.iWidth, PixelFormat.Format8bppIndexed, this.oBitmapMemoryAddress);
							InitPalette(this.aColorPalette);
							this.oForm.ClientSize = new Size(this.iWidth * 2, this.iHeight * 2);
							break;

						case 0x13:
							this.eMode = ModeEnum.Graphics320x200x256;
							this.iWidth = 320;
							this.iHeight = 200;
							this.iXPosition = 0;
							this.iYPosition = 0;
							this.iTextWidth = 40;
							this.iTextHeight = 25;
							this.biTextForeColor = 15;
							this.biTextBackColor = 0;
							this.iPixelsPerByte = 1;
							this.iBytesPerLine = 320;

							this.oBitmap = new Bitmap(this.iWidth, this.iHeight, this.iWidth, PixelFormat.Format8bppIndexed, this.oBitmapMemoryAddress);
							InitPalette(this.aColorPalette256);
							this.oForm.ClientSize = new Size(this.iWidth * 2, this.iHeight * 2);
							break;

						default:
							throw new Exception("Unknown graphic mode");
					}

					ClearInternal();
				}
			}
		}

		private void InitPalette(Color[] palette)
		{
			// what a stupid way to change palette, we have to assign new ColorPalette to bitmap object to modify any palette entry!
			ColorPalette bmpPalette = this.oBitmap.Palette;

			for (int i = 0; i < palette.Length; i++)
			{
				bmpPalette.Entries[i] = palette[i];
			}

			this.oBitmap.Palette = bmpPalette;
		}

		public void SetPalette18(int index, int red, int green, int blue)
		{
			SetPaletteColor(index & 0xff, Color.FromArgb((255 * (red & 0x3f)) / 64, (255 * (green & 0x3f)) / 64, (255 * (blue & 0x3f)) / 64));
		}

		private void SetPaletteColor(int index, Color value)
		{
			// what a stupid way to change palette, we have to assign new ColorPalette to bitmap object to modify any palette entry!
			ColorPalette bmpPalette = this.oBitmap.Palette;

			bmpPalette.Entries[index] = value;

			this.oBitmap.Palette = bmpPalette;
		}

		public int Width
		{
			get
			{
				return this.iWidth;
			}
		}

		public int Height
		{
			get
			{
				return this.iHeight;
			}
		}

		public int TextWidth
		{
			get
			{
				return this.iTextWidth;
			}
		}

		public int TextHeight
		{
			get
			{
				return this.iTextHeight;
			}
		}

		#region VGA HW specific stuff
		public void SetSequencerValue(byte value)
		{
			switch (this.biSequencerAddress)
			{
				case 2:
					// Map Write Mask
					this.biMapWriteMask = value;
					this.oParent.Parent.VGALog.WriteLine($"Sequencer Map Write Mask changed to 0x{value:x2}");
					break;

				case 0xff:
					// ignore this value
					break;

				default:
					this.oParent.Parent.VGALog.WriteLine($"Unknown Sequencer address 0x{this.biSequencerAddress:x2}, value 0x{value:x2}");
					break;
			}
		}

		public void SetGraphicsValue(byte value)
		{
			switch (this.biGraphicsAddress)
			{
				case 0:
					// Write plane mask bits
					this.biWriteSetReset = value;
					this.oParent.Parent.VGALog.WriteLine($"Graphics Write plane mask bits changed to 0x{value:x2}");
					break;

				case 1:
					// Enable write plane mask bits
					this.biEnableSetReset = value;
					this.oParent.Parent.VGALog.WriteLine($"Graphics Enable write plane mask bits changed to 0x{value:x2}");
					break;

				case 2:
					// Color Compare
					this.biColorCompare = value;
					this.oParent.Parent.VGALog.WriteLine($"Graphics Color Compare changed to 0x{value:x2}");
					break;

				case 3:
					// Data rotate, ignore for now
					if (value != 0)
					{
						this.oParent.Parent.VGALog.WriteLine($"Graphics data rotate 0x{this.biGraphicsAddress:x2}, value 0x{value:x2}");
					}
					break;

				case 0x5:
					// Graphics Mode Register
					this.biGraphicsMode = value;
					if (this.biGraphicsMode != 0)
					{
						this.oParent.Parent.VGALog.WriteLine($"Graphics mode 0x{this.biGraphicsAddress:x2}, value 0x{value:x2}");
					}
					break;

				case 4:
					// Read plane select
					this.biMapReadSelect = (byte)(value & 0x3);
					this.oParent.Parent.VGALog.WriteLine($"Graphics Read plane select changed to 0x{value:x2}");
					break;

				case 8:
					// Write bit mask
					this.biWriteBitMask = value;
					this.oParent.Parent.VGALog.WriteLine($"Graphics Write bit mask changed to 0x{value:x2}");
					break;

				case 0xff:
					// ignore this value
					break;

				default:
					this.oParent.Parent.VGALog.WriteLine($"Unknown Graphics address 0x{this.biGraphicsAddress:x2}, value 0x{value:x2}");
					break;
			}
		}

		public void AttributeControllerWrite(byte value)
		{
			if (this.bAttributeAddressFlag)
			{
				this.biAttributeAddress = value;
				if (this.biAttributeAddress > 0x20)
					this.oParent.Parent.VGALog.WriteLine($"Attribute address is greater than 0x20, 0x{this.biAttributeAddress:x2}");
				this.bAttributeAddressFlag = false;
			}
			else if((this.biAttributeAddress & 0x20) == 0)
			{
				switch (this.biAttributeAddress)
				{
					case 0:
					case 1:
					case 2:
					case 3:
					case 4:
					case 5:
					case 6:
					case 7:
					case 8:
					case 9:
					case 0xa:
					case 0xb:
					case 0xc:
					case 0xd:
					case 0xe:
					case 0xf:
						int iRed = (value & 4) >> 2 | (value & 0x20) >> 4;
						iRed = (255 * iRed) / 3;
						int iGreen = (value & 2) >> 1 | (value & 0x10) >> 3;
						iGreen = (255 * iGreen) / 3;
						int iBlue = (value & 1) | (value & 0x8) >> 2;
						iBlue = (255 * iBlue) / 3;
						SetPaletteColor(this.biAttributeAddress, Color.FromArgb(iRed, iGreen, iBlue));
						break;

					case 0x10:
						// Attribute Mode Control Register, ignore if zero
						if (value != 0)
						{
							this.oParent.Parent.VGALog.WriteLine($"Undefined Attribute mode address 0x{this.biAttributeAddress:x2}, value 0x{value:x2}");
						}
						break;

					case 0x11:
						// Overscan Color Register, not supported, ignore
						break;

					case 0x13:
						// Horizontal PEL Panning Register, ignore for now
						break;

					case 0xff:
						// ignore this value
						break;

					default:
						this.oParent.Parent.VGALog.WriteLine($"Unknown Attribute address 0x{this.biAttributeAddress:x2}, value 0x{value:x2}");
						break;
				}
				this.bAttributeAddressFlag = true;
			}

			if ((this.biAttributeAddress & 0x20) != 0)
			{
				this.bAttributeAddressFlag = true;
			}
		}

		public byte HWStatus
		{
			// alternate horizontal retrace status
			get { this.ubHWStatus ^= 0x8; this.bAttributeAddressFlag = true; return this.ubHWStatus; }
		}

		public byte HWSequencerAddress
		{
			get { return this.biSequencerAddress; }
			set { this.biSequencerAddress = value; }
		}

		public byte HWMapWriteMask
		{
			get { return this.biMapWriteMask; }
			set { this.biMapWriteMask = value; }
		}

		public byte HWGraphicsAddress
		{
			get { return this.biGraphicsAddress; }
			set { this.biGraphicsAddress = value; }
		}

		public byte HWWriteSetReset
		{
			get { return this.biWriteSetReset; }
			set { this.biWriteSetReset = value; }
		}

		public byte HWEnableSetReset
		{
			get { return this.biEnableSetReset; }
			set { this.biEnableSetReset = value; }
		}

		public byte HWMapReadSelect
		{
			get { return this.biMapReadSelect; }
		}

		public byte HWWriteBitMask
		{
			get { return this.biWriteBitMask; }
			set { this.biWriteBitMask = value; }
		}

		public byte DACWriteAddress
		{
			get { return this.biDACWriteAddress; }
			set { this.biDACWriteAddress = value; this.iDACWriteIndex = -1; }
		}

		public byte DACReadAddress
		{
			get { return this.biDACState; }
			set { this.biDACReadAddress = value; this.iDACReadIndex = -1; }
		}

		public byte DACPalette
		{
			get
			{
				switch (this.iDACReadIndex)
				{
					case -1:
						Color color = this.oBitmap.Palette.Entries[this.biDACReadAddress];
						this.biDACReadRed = (byte)((64 * color.R) / 255);
						this.biDACReadGreen = (byte)((64 * color.G) / 255);
						this.biDACReadBlue = (byte)((64 * color.B) / 255);
						this.iDACReadIndex++;
						return this.biDACReadRed;

					case 0:
						this.iDACReadIndex++;
						return this.biDACReadGreen;

					case 1:
						this.biDACReadAddress++;
						this.iDACReadIndex = -1;
						this.biDACState = 0x3;
						return this.biDACReadBlue;

					default:
						return 0;   // Happy compiler
				}
			}
			set
			{
				value &= 0x3f;
				switch (this.iDACWriteIndex)
				{
					case -1:
						this.biDACWriteRed = (byte)((255 * value) / 64);
						this.iDACWriteIndex++;
						break;

					case 0:
						this.biDACWriteGreen = (byte)((255 * value) / 64);
						this.iDACWriteIndex++;
						break;

					case 1:
						this.biDACWriteBlue = (byte)((255 * value) / 64);
						SetPaletteColor(this.biDACWriteAddress, Color.FromArgb(this.biDACWriteRed, this.biDACWriteGreen, this.biDACWriteBlue));
						this.biDACWriteAddress++;
						this.iDACWriteIndex = -1;
						this.biDACState = 0x0;
						break;
				}
			}
		}
		#endregion

		public VGACardForm Form
		{
			get { return this.oForm; }
		}

		public Bitmap ScreenBitmap
		{
			get
			{
				return this.oBitmap;
			}
		}

		public bool BitmapChanged
		{
			get { return this.bBitmapChanged; }
			set { this.bBitmapChanged = value; }
		}

		public void Clear()
		{
			ClearInternal();
		}

		private void ClearInternal()
		{
			lock (this.oBitmapLock)
			{
				for (int i = 0; i < this.aBitmapMemory.Length; i++)
				{
					this.aBitmapMemory[i] = 0;
				}

				switch (this.eMode)
				{
					case ModeEnum.Text80x25Color:
						for (int i = 0; i < iNumberOfPlanes; i++)
						{
							for (int j = 0; j < iPlaneMemorySize; j++)
							{
								if (i == 0 && (j & 1) == 0)
								{
									this.abMemoryPlanes[i, j] = 0x7;
								}
								else
								{
									this.abMemoryPlanes[i, j] = 0;
								}
							}
						}
						break;
					case ModeEnum.Graphics320x200x16:
					case ModeEnum.Graphics320x200x256:
						for (int i = 0; i < iNumberOfPlanes; i++)
						{
							for (int j = 0; j < iPlaneMemorySize; j++)
							{
								this.abMemoryPlanes[i, j] = 0;
							}
						}
						break;
				}
			}

			this.bBitmapChanged = true;

			Application.DoEvents();
		}

		public byte ReadByte(uint address)
		{
			address &= 0xffff;
			if (address < 0 || address >= iPlaneMemorySize)
			{
				throw new Exception("Video address outside bounds");
			}

			return this.abMemoryPlanes[this.biMapReadSelect, address];
		}

		public ushort ReadWord(uint address)
		{
			address &= 0xffff;
			if (address < 0 || address + 1 >= iPlaneMemorySize)
			{
				throw new Exception("Video address outside bounds");
			}

			return (ushort)((ushort)this.abMemoryPlanes[this.biMapReadSelect, address] |
				(ushort)((ushort)this.abMemoryPlanes[this.biMapReadSelect, address + 1] << 8));
		}

		public uint ReadDWord(uint address)
		{
			address &= 0xffff;
			if (address < 0 || address + 3 >= iPlaneMemorySize)
			{
				throw new Exception("Video address outside bounds");
			}

			return (uint)((uint)this.abMemoryPlanes[this.biMapReadSelect, address] |
				(uint)((uint)this.abMemoryPlanes[this.biMapReadSelect, address + 1] << 8) |
				(uint)((uint)this.abMemoryPlanes[this.biMapReadSelect, address + 2] << 16) |
				(uint)((uint)this.abMemoryPlanes[this.biMapReadSelect, address + 3] << 24));
		}

		public void WriteByte(uint address, byte value)
		{
			address &= 0xffff;
			if (address < 0 || address >= iPlaneMemorySize)
			{
				throw new Exception("Video address outside bounds");
			}
			lock (this.oBitmapLock)
			{
				switch (this.eMode)
				{
					case ModeEnum.Graphics320x200x16:
						byte biValue = (byte)(value & this.biWriteBitMask);

						for (int i = 0; i < iNumberOfPlanes; i++)
						{
							int iBitMask = 1 << i;

							if ((this.biMapWriteMask & iBitMask) != 0)
							{
								if ((this.biEnableSetReset & iBitMask) != 0)
								{
									if ((this.biWriteSetReset & iBitMask) != 0)
									{
										// write all 1's
										byte biNewValue = this.abMemoryPlanes[i, address];
										biNewValue |= this.biWriteBitMask;
										biNewValue ^= this.biWriteBitMask;
										biNewValue |= this.biWriteBitMask;
										this.abMemoryPlanes[i, address] = biNewValue;
									}
									else
									{
										// write all 0's
										byte biNewValue = this.abMemoryPlanes[i, address];
										biNewValue |= this.biWriteBitMask;
										biNewValue ^= this.biWriteBitMask;
										this.abMemoryPlanes[i, address] = biNewValue;
									}
								}
								else
								{
									byte biNewValue = this.abMemoryPlanes[i, address];
									biNewValue |= this.biWriteBitMask;
									biNewValue ^= this.biWriteBitMask;
									biNewValue |= biValue;
									this.abMemoryPlanes[i, address] = biNewValue;
								}
							}
						}
						RenderAddress(address);
						break;

					case ModeEnum.Graphics320x200x256:
						this.abMemoryPlanes[0, address] = value;
						RenderAddress(address);
						break;
				}
			}
		}

		public void WriteWord(uint address, ushort value)
		{
			address &= 0xffff;
			if (address < 0 || address + 1 >= iPlaneMemorySize)
			{
				throw new Exception("Video address outside bounds");
			}
			lock (this.oBitmapLock)
			{
				switch (this.eMode)
				{
					case ModeEnum.Graphics320x200x16:
						for (int j = 0; j < 2; j++)
						{
							byte biValue = (byte)((value & 0xff) & this.biWriteBitMask);

							for (int i = 0; i < iNumberOfPlanes; i++)
							{
								int iBitMask = 1 << i;

								if ((this.biMapWriteMask & iBitMask) != 0)
								{
									if ((this.biEnableSetReset & iBitMask) != 0)
									{
										if ((this.biWriteSetReset & iBitMask) != 0)
										{
											// write all 1's
											byte biNewValue = this.abMemoryPlanes[i, address + j];
											biNewValue |= this.biWriteBitMask;
											biNewValue ^= this.biWriteBitMask;
											biNewValue |= (byte)(0xff & this.biWriteBitMask);
											this.abMemoryPlanes[i, address + j] = biNewValue;
										}
										else
										{
											// write all 0's
											byte biNewValue = this.abMemoryPlanes[i, address + j];
											biNewValue |= this.biWriteBitMask;
											biNewValue ^= this.biWriteBitMask;
											this.abMemoryPlanes[i, address + j] = biNewValue;
										}
									}
									else
									{
										byte biNewValue = this.abMemoryPlanes[i, address + j];
										biNewValue |= this.biWriteBitMask;
										biNewValue ^= this.biWriteBitMask;
										biNewValue |= biValue;
										this.abMemoryPlanes[i, address + j] = biNewValue;
									}
								}
							}
							value >>= 8;
							RenderAddress((uint)(address + j));
						}
						break;

					case ModeEnum.Graphics320x200x256:
						this.abMemoryPlanes[0, address] = (byte)(value & 0xff);
						this.abMemoryPlanes[0, address + 1] = (byte)((value & 0xff00) >> 8);
						RenderAddress(address);
						RenderAddress(address + 1);
						break;
				}
			}
		}

		public void WriteDWord(uint address, uint value)
		{
			address &= 0xffff;
			if (address < 0 || address + 3 >= iPlaneMemorySize)
			{
				throw new Exception("Video address outside bounds");
			}
			lock (this.oBitmapLock)
			{
				switch (this.eMode)
				{
					case ModeEnum.Graphics320x200x16:
						for (int j = 0; j < 4; j++)
						{
							byte biValue = (byte)((value & 0xff) & this.biWriteBitMask);

							for (int i = 0; i < iNumberOfPlanes; i++)
							{
								int iBitMask = 1 << i;

								if ((this.biMapWriteMask & iBitMask) != 0)
								{
									if ((this.biEnableSetReset & iBitMask) != 0)
									{
										if ((this.biWriteSetReset & iBitMask) != 0)
										{
											// write all 1's
											byte biNewValue = this.abMemoryPlanes[i, address + j];
											biNewValue |= this.biWriteBitMask;
											biNewValue ^= this.biWriteBitMask;
											biNewValue |= (byte)(0xff & this.biWriteBitMask);
											this.abMemoryPlanes[i, address + j] = biNewValue;
										}
										else
										{
											// write all 0's
											byte biNewValue = this.abMemoryPlanes[i, address + j];
											biNewValue |= this.biWriteBitMask;
											biNewValue ^= this.biWriteBitMask;
											this.abMemoryPlanes[i, address + j] = biNewValue;
										}
									}
									else
									{
										byte biNewValue = this.abMemoryPlanes[i, address + j];
										biNewValue |= this.biWriteBitMask;
										biNewValue ^= this.biWriteBitMask;
										biNewValue |= biValue;
										this.abMemoryPlanes[i, address + j] = biNewValue;
									}
								}
							}
							value >>= 8;
							RenderAddress((uint)(address + j));
						}
						break;

					case ModeEnum.Graphics320x200x256:
						this.abMemoryPlanes[0, address] = (byte)(value & 0xff);
						this.abMemoryPlanes[0, address + 1] = (byte)((value & 0xff00) >> 8);
						this.abMemoryPlanes[0, address + 2] = (byte)((value & 0xff0000) >> 16);
						this.abMemoryPlanes[0, address + 3] = (byte)((value & 0xff000000) >> 24);

						RenderAddress(address);
						RenderAddress(address + 1);
						RenderAddress(address + 2);
						RenderAddress(address + 3);
						break;
				}
			}
		}

		public int XPosition
		{
			get
			{
				return this.iXPosition;
			}
			set
			{
				this.iXPosition = Math.Abs(value);
				this.iXPosition %= this.iTextWidth;
			}
		}

		public int YPosition
		{
			get
			{
				return this.iYPosition;
			}
			set
			{
				this.iYPosition = Math.Abs(value);
				this.iYPosition %= this.iTextHeight;
			}
		}

		public byte TextForeColor
		{
			get
			{
				return this.biTextForeColor;
			}
			set
			{
				this.biTextForeColor = value;
				switch (this.eMode)
				{
					case ModeEnum.Text80x25Color:
					case ModeEnum.Graphics320x200x16:
						this.biTextForeColor &= 0xf;
						break;

					case ModeEnum.Graphics320x200x256:
						//this.biTextForeColor &= 0xff;
						break;
				}
			}
		}

		public byte TextBackColor
		{
			get
			{
				return this.biTextBackColor;
			}
			set
			{
				this.biTextBackColor = value;
				switch (this.eMode)
				{
					case ModeEnum.Text80x25Color:
					case ModeEnum.Graphics320x200x16:
						this.biTextBackColor &= 0xf;
						break;

					case ModeEnum.Graphics320x200x256:
						//this.biTextBackColor &= 0xff;
						break;
				}
			}
		}

		private byte ToForeColor(byte attribute)
		{
			return (byte)(attribute & 0xf);
		}

		private byte ToBackColor(byte attribute)
		{
			return (byte)((attribute & 0xf0) >> 4);
		}

		private byte ToAttribute(byte foreColor, byte backColor)
		{
			return (byte)((foreColor & 0xf) | ((backColor & 0xf) << 4));
		}

		private Color ToColor(int color)
		{
			switch (this.eMode)
			{
				case ModeEnum.Text80x25Color:
				case ModeEnum.Graphics320x200x16:
					return this.oBitmap.Palette.Entries[color & 0xf];

				case ModeEnum.Graphics320x200x256:
					return this.oBitmap.Palette.Entries[color & 0xff];
			}

			return Color.Black;
		}

		public void PrintStdOut(string text)
		{
			lock (this.oBitmapLock)
			{
				for (int i = 0; i < text.Length; i++)
				{
					PrintStdOutInternal(text[i]);
				}
			}
		}

		public void PrintStdOut(string text, byte attribute)
		{
			lock (this.oBitmapLock)
			{
				for (int i = 0; i < text.Length; i++)
				{
					PrintStdOutInternal(text[i], attribute);
				}
			}
		}

		public void PrintStdOut(char ch)
		{
			lock (this.oBitmapLock)
			{
				PrintStdOutInternal(ch);
			}
		}

		public void PrintStdOut(char ch, byte attribute)
		{
			lock (this.oBitmapLock)
			{
				PrintStdOutInternal(ch, attribute);
			}
		}

		private void PrintStdOutInternal(char ch)
		{
			switch (ch)
			{
				case '\0':
					// ignore zero character
					break;
				case '\a':  // 0x7 - bell
					System.Media.SystemSounds.Beep.Play();
					break;
				case '\b':  // 0x8 - backspace
					this.iXPosition--;
					if (this.iXPosition < 0)
					{
						this.iXPosition = this.iTextWidth - 1;
						this.iYPosition--;
						if (this.iYPosition < 0)
						{
							this.iYPosition = 0;
							ScrollWindowInternal(0, 0, this.iTextWidth, this.iTextHeight, 1);
						}
					}
					break;
				case '\t':  // 0x9 - tab
					PrintStdOutInternal(' ');
					break;
				case '\r':  // 0xd - carriage return
					this.iXPosition = 0;
					break;
				case '\n':  // 0xa - new line
					this.iYPosition++;
					if (this.iYPosition >= this.iTextHeight)
					{
						this.iYPosition--;
						ScrollWindowInternal(0, 0, this.iTextWidth, this.iTextHeight, -1);
					}
					break;
				default:
					PrintChar(ch);
					// next cursor position
					this.iXPosition++;
					if (this.iXPosition >= this.iTextWidth)
					{
						this.iXPosition = 0;
						this.iYPosition++;
						if (this.iYPosition >= this.iTextHeight)
						{
							this.iYPosition--;
							ScrollWindowInternal(0, 0, this.iTextWidth, this.iTextHeight, -1);
						}
					}
					break;
			}
		}

		private void PrintStdOutInternal(char ch, byte attribute)
		{
			switch (ch)
			{
				case '\0':
					// ignore zero character
					break;
				case '\a':  // 0x7 - bell
					System.Media.SystemSounds.Beep.Play();
					break;
				case '\b':  // 0x8 - backspace
					this.iXPosition--;
					if (this.iXPosition < 0)
					{
						this.iXPosition = this.iTextWidth - 1;
						this.iYPosition--;
						if (this.iYPosition < 0)
						{
							this.iYPosition = 0;
							ScrollWindowInternal(0, 0, this.iTextWidth, this.iTextHeight, 1);
						}
					}
					break;
				case '\t':  // 0x9 - tab
					PrintStdOut("   ", attribute);
					break;
				case '\r':  // 0xd - carriage return
					this.iXPosition = 0;
					break;
				case '\n':  // 0xa - new line
					this.iYPosition++;
					if (this.iYPosition >= this.iTextHeight)
					{
						this.iYPosition--;
						ScrollWindowInternal(0, 0, this.iTextWidth, this.iTextHeight, -1);
					}
					break;
				default:
					PrintChar(ch, attribute);
					// next cursor position
					this.iXPosition++;
					if (this.iXPosition >= this.iTextWidth)
					{
						this.iXPosition = 0;
						this.iYPosition++;
						if (this.iYPosition >= this.iTextHeight)
						{
							this.iYPosition--;
							ScrollWindowInternal(0, 0, this.iTextWidth, this.iTextHeight, -1);
						}
					}
					break;
			}
		}

		private void RenderAddress(uint address)
		{
			uint address1 = address;
			int iXPos;
			int iYPos;

			switch (this.eMode)
			{
				case ModeEnum.Text80x25Color:
					if (address <= (this.iTextWidth * this.iTextHeight * 2))
					{
						int iY = (int)(address / (this.iTextWidth * 2));
						int iX = (int)((address - (iY * (this.iTextWidth * 2))) / 2);
						int ch = this.abMemoryPlanes[0, address];
						byte attr = this.abMemoryPlanes[0, address + 1];
						if (iX < this.iTextWidth && iY < this.iTextHeight)
						{
							RenderCharacter(iX, iY, ch, (byte)(attr & 0xf), (byte)((attr & 0xf0) >> 4));
						}
					}
					break;

				case ModeEnum.Graphics320x200x16:
					address &= 0x7fff;
					address1 &= 0x7fff;
					address1 -= 0x2000 * this.uiBitmapPage;
					if (address1 < 0x1f40)
					{
						iYPos = (int)(address1 / this.iBytesPerLine);
						iXPos = (int)(address1 - (iYPos * this.iBytesPerLine)) * iPixelsPerByte;

						for (int j = 0; j < iPixelsPerByte; j++)
						{
							int iBitMask = 1 << j;
							byte biColor = 0;

							for (int k = 0; k < iNumberOfPlanes; k++)
							{
								byte biBit = (byte)((this.abMemoryPlanes[k, address] & iBitMask) != 0 ? 1 : 0);
								biBit <<= k;
								biColor |= biBit;
							}

							SetPixelInternal((int)iXPos + (iPixelsPerByte - (j + 1)), iYPos, biColor);
						}
					}
					break;

				case ModeEnum.Graphics320x200x256:
					iYPos = (int)((address & 0xffff) / this.iWidth);
					iXPos = (int)((address & 0xffff) - (iYPos * this.iWidth));

					SetPixelInternal(iXPos, iYPos, this.abMemoryPlanes[0, address]);
					break;
			}
		}

		public void ScrollWindow(int x, int y, int width, int height, int dir)
		{
			lock (this.oBitmapLock)
			{
				ScrollWindowInternal(x, y, width, height, dir);
			}
		}

		private void ScrollWindowInternal(int x, int y, int width, int height, int dir)
		{
			if (x >= 0 && x < this.iTextWidth && y >= 0 && y < this.iTextHeight)
			{
				if (x + width > this.iTextWidth) width = this.iTextWidth - x;
				if (y + height > this.iTextHeight) height = this.iTextHeight - y;

				if (width > 0 && height > 1)
				{
					// scroll memory data
					int iBlockSrc;
					int iBlockDst;
					int iBlockWidth;
					int iLineWidth;
					int iLineSize;
					byte attr;
					byte bTemp;

					switch (this.eMode)
					{
						case ModeEnum.Text80x25Color:
							attr = this.ToAttribute(this.biTextForeColor, this.biTextBackColor);
							iBlockWidth = width * 2;
							iLineSize = this.iTextWidth * 2;
							if (dir > 0)
							{
								iBlockSrc = (y + height - 2) * (this.iTextWidth * 2) + x * 2;
								iBlockDst = (y + height - 1) * (this.iTextWidth * 2) + x * 2;
							}
							else
							{
								iBlockSrc = (y + 1) * (this.iTextWidth * 2) + x * 2;
								iBlockDst = y * (this.iTextWidth * 2) + x * 2;
							}

							for (int i = 0; i < height - 1; i++)
							{
								for (int j = 0; j < iBlockWidth; j++)
								{
									this.abMemoryPlanes[0, iBlockDst + j] = this.abMemoryPlanes[0, iBlockSrc + j];
								}
								iBlockSrc += (dir > 0) ? -iLineSize : iLineSize;
								iBlockDst += (dir > 0) ? -iLineSize : iLineSize;
							}

							// clear empty line
							if (dir > 0)
							{
								iBlockDst = y * (this.iTextWidth * 2) + x * 2;
							}
							else
							{
								iBlockDst = (y + height - 1) * (this.iTextWidth * 2) + x * 2;
							}

							for (int j = 0; j < iBlockWidth; j += 2)
							{
								this.abMemoryPlanes[0, iBlockDst + j] = attr;
								this.abMemoryPlanes[0, iBlockDst + j + 1] = 0x0;
							}
							break;

						case ModeEnum.Graphics320x200x16:
							iBlockWidth = (this.iFontWidth * width) >> 1;
							iLineWidth = (this.iFontWidth * this.iTextWidth) >> 1;
							iLineSize = iLineWidth * this.iFontHeight;

							if (dir > 0)
							{
								iBlockSrc = ((y + height - 2) * iLineSize) + (x * this.iFontWidth);
								iBlockDst = ((y + height - 1) * iLineSize) + (x * this.iFontWidth);
							}
							else
							{
								iBlockSrc = ((y + 1) * iLineSize) + (x * this.iFontWidth);
								iBlockDst = (y * iLineSize) + (x * this.iFontWidth);
							}

							for (int i = 0; i < (height - 1) * this.iFontHeight; i++)
							{
								for (int j = 0; j < iBlockWidth; j++)
								{
									this.abMemoryPlanes[0, iBlockDst + j] = this.abMemoryPlanes[0, iBlockSrc + j];
								}
								iBlockSrc += (dir > 0) ? -iLineWidth : iLineWidth;
								iBlockDst += (dir > 0) ? -iLineWidth : iLineWidth;
							}

							// clear empty line
							if (dir > 0)
							{
								iBlockDst = (y * iLineSize) + (x * this.iFontWidth);
							}
							else
							{
								iBlockDst = ((y + height - 1) * iLineSize) + (x * this.iFontWidth);
							}

							bTemp = (byte)this.biTextBackColor;
							for (int i = 0; i < this.iFontHeight; i++)
							{
								for (int j = 0; j < iBlockWidth; j++)
								{
									this.abMemoryPlanes[0, iBlockDst + j] = bTemp;
								}
								iBlockDst += (dir > 0) ? -iLineWidth : iLineWidth;
							}
							break;

						case ModeEnum.Graphics320x200x256:
							iBlockWidth = this.iFontWidth * width;
							iLineWidth = this.iFontWidth * this.iTextWidth;
							iLineSize = iLineWidth * this.iFontHeight;

							if (dir > 0)
							{
								iBlockSrc = ((y + height - 2) * iLineSize) + (x * this.iFontWidth);
								iBlockDst = ((y + height - 1) * iLineSize) + (x * this.iFontWidth);
							}
							else
							{
								iBlockSrc = ((y + 1) * iLineSize) + (x * this.iFontWidth);
								iBlockDst = (y * iLineSize) + (x * this.iFontWidth);
							}

							for (int i = 0; i < (height - 1) * this.iFontHeight; i++)
							{
								for (int j = 0; j < iBlockWidth; j++)
								{
									this.abMemoryPlanes[0, iBlockDst + j] = this.abMemoryPlanes[0, iBlockSrc + j];
								}
								iBlockSrc += (dir > 0) ? -iLineWidth : iLineWidth;
								iBlockDst += (dir > 0) ? -iLineWidth : iLineWidth;
							}

							// clear empty line
							if (dir > 0)
							{
								iBlockDst = (y * iLineSize) + (x * this.iFontWidth);
							}
							else
							{
								iBlockDst = ((y + height - 1) * iLineSize) + (x * this.iFontWidth);
							}

							bTemp = (byte)this.biTextBackColor;
							for (int i = 0; i < this.iFontHeight; i++)
							{
								for (int j = 0; j < iBlockWidth; j++)
								{
									this.abMemoryPlanes[0, iBlockDst + j] = bTemp;
								}
								iBlockDst += (dir > 0) ? -iLineWidth : iLineWidth;
							}
							break;
					}

					// scroll bitmap
					Rectangle rSrc;
					Rectangle rDst;
					Graphics g = Graphics.FromImage(this.oBitmap);
					if (dir > 0)
					{
						rSrc = new Rectangle(x * this.iFontWidth, y * this.iFontHeight,
							width * this.iFontWidth, (height - 1) * this.iFontHeight);
						rDst = new Rectangle(x * this.iFontWidth, (y + 1) * this.iFontHeight,
							width * this.iFontWidth, (height - 1) * this.iFontHeight);
						g.DrawImage(this.oBitmap, rDst, rSrc, GraphicsUnit.Pixel);
						rDst = new Rectangle(x * this.iFontWidth, y * this.iFontHeight,
							width * this.iFontWidth, this.iFontHeight);
						g.FillRectangle(new SolidBrush(ToColor(this.biTextBackColor)), rDst);
					}
					else
					{
						rSrc = new Rectangle(x * this.iFontWidth, (y + 1) * this.iFontHeight,
							width * this.iFontWidth, (height - 1) * this.iFontHeight);
						rDst = new Rectangle(x * this.iFontWidth, y * this.iFontHeight,
							width * this.iFontWidth, (height - 1) * this.iFontHeight);
						g.DrawImage(this.oBitmap, rDst, rSrc, GraphicsUnit.Pixel);
						rDst = new Rectangle(x * this.iFontWidth, (y + height - 1) * this.iFontHeight,
							width * this.iFontWidth, this.iFontHeight);
						g.FillRectangle(new SolidBrush(ToColor(this.biTextBackColor)), rDst);
					}
					g.Flush();
					g.Dispose();
				}
			}
		}

		public void SetPixel(int x, int y, byte color)
		{
			if (x >= 0 && x < this.iWidth && y >= 0 && y < this.iHeight)
			{
				lock (this.oBitmapLock)
				{
					int iAddress;

					switch (this.eMode)
					{
						case ModeEnum.Graphics320x200x16:
							// four memory planes used, each pixel spans all four planes
							color &= 0xf;
							iAddress = (y * this.iWidth) + x;
							byte biBitMask = (byte)(1 << (iAddress & 0x7));
							iAddress >>= 3; // divide by 8
							for (int i = 0; i < 4; i++)
							{
								this.abMemoryPlanes[i, iAddress] |= biBitMask;
								this.abMemoryPlanes[i, iAddress] ^= biBitMask;
								this.abMemoryPlanes[i, iAddress] |= (byte)(color & 1);
								color >>= 1;
							}

							SetPixelInternal(x, y, color);
							break;

						case ModeEnum.Graphics320x200x256:
							// single memory plane used, each byte is one pixel
							iAddress = (y * this.iWidth) + x;
							this.abMemoryPlanes[0, iAddress] = color;

							SetPixelInternal(x, y, color);
							break;
					}
				}
			}
		}

		private void SetPixelInternal(int x, int y, byte color)
		{
			switch (this.eMode)
			{
				case ModeEnum.Text80x25Color:
				case ModeEnum.Graphics320x200x16:
					if (x >= 0 && x < this.iWidth && y >= 0 && y < this.iHeight)
					{
						color &= 0xf;
						int iAddress = (y * this.iWidth) + x;

						this.aBitmapMemory[iAddress] = color;
						this.bBitmapChanged = true;
					}
					break;

				case ModeEnum.Graphics320x200x256:
					if (x >= 0 && x < this.iWidth && y >= 0 && y < this.iHeight)
					{
						color &= 0xff;
						int iAddress = (y * this.iWidth) + x;

						this.aBitmapMemory[iAddress] = color;
						this.bBitmapChanged = true;
					}
					break;
			}
		}

		private void PrintChar(char ch)
		{
			int iAddress;
			switch (this.eMode)
			{
				case ModeEnum.Text80x25Color:
					// render into video memory
					iAddress = (this.iYPosition * this.iTextWidth * 2) + this.iXPosition * 2;
					this.abMemoryPlanes[0, iAddress + 1] = (byte)ch;

					// render to bitmap
					RenderCharacter(this.iXPosition, this.iYPosition, ch, ToForeColor(this.abMemoryPlanes[0, iAddress]), ToBackColor(this.abMemoryPlanes[0, iAddress]));
					break;

				case ModeEnum.Graphics320x200x256:
					// render to bitmap
					RenderCharacter(this.iXPosition, this.iYPosition, ch, this.biTextForeColor, this.biTextBackColor);
					break;
			}
		}

		private void PrintChar(char ch, byte colorAttribute)
		{
			int iAddress;
			switch (this.eMode)
			{
				case ModeEnum.Text80x25Color:
					// render into video memory
					iAddress = (this.iYPosition * this.iTextWidth * 2) + this.iXPosition * 2;
					this.abMemoryPlanes[0, iAddress] = colorAttribute;
					this.abMemoryPlanes[0, iAddress + 1] = (byte)ch;

					// render to bitmap
					RenderCharacter(this.iXPosition, this.iYPosition, ch, ToForeColor(this.abMemoryPlanes[0, iAddress]), ToBackColor(this.abMemoryPlanes[0, iAddress]));
					break;

				case ModeEnum.Graphics320x200x16:
					// render to bitmap
					RenderCharacter(this.iXPosition, this.iYPosition, ch, this.biTextForeColor, this.biTextBackColor);
					break;

				case ModeEnum.Graphics320x200x256:
					// render to bitmap
					RenderCharacter(this.iXPosition, this.iYPosition, ch, this.biTextForeColor, this.biTextBackColor);
					break;
			}
		}

		private void RenderCharacter(int x, int y, int ch, byte fore, byte back)
		{
			int iXPos = x * 8; // pixel x position
			int iYPos = y * 8; // pixel y position
			int iChPos = ch * 8; // character table position
			int iBitCount = 0;
			int iChMask = this.abFont08[iChPos];

			Color cFore = this.ToColor(fore);
			Color cBack = this.ToColor(back);

			for (int i = 0; i < this.iFontHeight; i++)
			{
				for (int j = 0; j < this.iFontWidth; j++)
				{
					SetPixelInternal(iXPos + j, iYPos + i, ((iChMask & 0x80) != 0) ? fore : back);
					iChMask <<= 1;
					iBitCount++;
					if (iBitCount > 7)
					{
						iBitCount = 0;
						iChPos++;
						iChMask = this.abFont08[iChPos];
					}
				}
			}
		}
	}
}
