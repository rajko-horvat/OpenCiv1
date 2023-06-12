using Disassembler;
using System;

namespace Civilization1
{
	public class VGADriver
	{
		private Civilization oParent;
		private CPU oCPU;
		private ushort usSegment = 0;
		private static ushort usMaxWidth = 320;
		private static ushort usMaxHeight = 200;

		public VGADriver(Civilization parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public ushort Segment
		{
			get { return this.usSegment; }
			set { this.usSegment = value; }
		}

		public void F0_VGA_009a_ReplaceColor(ushort struct1, ushort xPos, ushort yPos, ushort width, ushort height, byte oldColor, byte newColor)
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_009a_ReplaceColor'(0x{struct1:x4}, {xPos}, {yPos}, {width}, {height}, {oldColor}, {newColor})");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock($"'F0_VGA_009a_ReplaceColor'(0x{struct1:x4}, {xPos}, {yPos}, {width}, {height}, {oldColor}, {newColor})");

			// function body
			ushort usXOffset = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(struct1 + 0x2));
			usXOffset += xPos;

			ushort usYOffset = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(struct1 + 0x4));
			usYOffset += yPos;

			if (usXOffset >= usMaxWidth)
				throw new Exception("X coordinate is too large");

			if (usYOffset >= usMaxHeight)
				throw new Exception("Y coordinate is too large");

			ushort usDestinationPtr = (ushort)(usYOffset * usMaxWidth);
			usDestinationPtr += usXOffset;
						
			ushort usNewRowOffset = (ushort)(usMaxWidth - width);

			ushort usDestinationSegment = this.oCPU.Memory.ReadWord(this.usSegment, (ushort)(0x1970 + (this.oCPU.ReadWord(this.oCPU.DS.Word, struct1) << 1)));

			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					if (oldColor == this.oCPU.Memory.ReadByte(usDestinationSegment, usDestinationPtr))
					{
						this.oCPU.Memory.WriteByte(usDestinationSegment, usDestinationPtr, newColor);
					}
					usDestinationPtr++;
				}

				usDestinationPtr += usNewRowOffset;
			}

			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_009a_ReplaceColor'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_010c()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_010c'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_010c'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = 0xffff;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x10));

		L011b:
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.CMPWord(this.oCPU.BX.Word, 0xf);
			if (this.oCPU.Flags.A) goto L012a;
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word)));
			if (this.oCPU.Flags.NE) goto L011b;
			this.oCPU.BX.High = this.oCPU.BX.Low;
			this.oCPU.PushWord(0x012a); // stack management - push return offset
			// Instruction address 0x0000:0x0127, size: 3
			F0_VGA_01ed();
			this.oCPU.PopWord(); // stack management - pop return offset

		L012a:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1988);
			this.oCPU.DS.Word = this.oCPU.AX.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			// LEA
			this.oCPU.DI.Word = 0x1d0;
			this.oCPU.AX.High = 0x0;
			this.oCPU.CX.Word = 0x10;

		L013d:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			// LEA
			this.oCPU.SI.Word = 0x50;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.MOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI);
			this.oCPU.MOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI);
			this.oCPU.MOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L013d;

			//this.oCPU.BX.Word = 0x0;
			//this.oCPU.CX.Word = 0x10;
			//this.oCPU.DX.Word = 0x1d0;

			// Instruction address 0x0000:0x015a, size: 3
			F0_VGA_01a1_SetColorBlock(this.oCPU.ES.Word, 0x1d0, 0, 16);

			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_010c'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0162_SetColorsFromStruct(ushort structPtr)
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0162_SetColorsFromStruct'(0x{structPtr:x4})");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock($"'F0_VGA_0162_SetColorsFromStruct'(0x{structPtr:x4})");

			// function body
			if (this.oCPU.ReadWord(this.oCPU.DS.Word, structPtr) == 0x304d)
			{
				ushort usFromIndex = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(structPtr + 0x4));
				ushort usToIndex = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(structPtr + 0x5));

				usToIndex -= usFromIndex;
				usToIndex++;

				F0_VGA_01a1_SetColorBlock(this.oCPU.DS.Word, (ushort)(structPtr + 6), usFromIndex, usToIndex);
			}

			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0162_SetColorsFromStruct'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_01a1_SetColorBlock(ushort segment, ushort offset, ushort index, ushort count)
		{
			// function body
			for (int i = 0; i < count; i++)
			{
				this.oCPU.VGA.SetPalette18(index + i,
					this.oCPU.Memory.ReadByte(segment, (ushort)(offset + (i * 3))),
					this.oCPU.Memory.ReadByte(segment, (ushort)(offset + (i * 3) + 1)),
					this.oCPU.Memory.ReadByte(segment, (ushort)(offset + (i * 3) + 2)));
				this.oCPU.Log.WriteLine($"Setting palette index {index + i}, #{this.oCPU.Memory.ReadByte(segment, (ushort)(offset + (i * 3))):x2}" +
					$"{this.oCPU.Memory.ReadByte(segment, (ushort)(offset + (i * 3) + 1)):x2}{this.oCPU.Memory.ReadByte(segment, (ushort)(offset + (i * 3) + 2)):x2}");
			}
		}

		public void F0_VGA_01ed()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_01ed'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// set overscan color

			// function body
			this.oCPU.DX.Word = 0x3da;

		L01f0:
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.E) goto L01f0;
			this.oCPU.CLI();
			this.oCPU.DX.Low = 0xc0;
			this.oCPU.AX.Low = 0x11;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.BX.High;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.AX.Word = 0x20;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.STI();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_VGA_01ed'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_020c()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_020c'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_020c'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x198a, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.AX.High;
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x3);
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x198b, this.oCPU.AX.Low);
			// LEA
			this.oCPU.BX.Word = 0x208;
			this.oCPU.XLAT(this.oCPU.AX, this.oCPU.CS, this.oCPU.BX);
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x198c, this.oCPU.AX.Low);
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_020c'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0224()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_0000_0224'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_0000_0224'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(0x0227); // stack management - push return offset
			// Instruction address 0x0000:0x0224, size: 3
			F0_VGA_022f();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15d2, 0x0);
			// Far return
			this.oCPU.Log.ExitBlock("'F0_0000_0224'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_022f()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_022f'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1988);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x212), 0x0);
			if (this.oCPU.Flags.E) goto L026b;
			// LEA
			this.oCPU.SI.Word = 0x216;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x20c);
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x416));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x20a));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1970);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x20e);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x210);
			this.oCPU.DX.Word = 0x140;
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L0262:
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.DX.Word);
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);
			if (this.oCPU.Flags.NE) goto L0262;

		L026b:
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_VGA_022f'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0270()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0270'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0270'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1988);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x200, this.oCPU.AX.Word);
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x202, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, 0x0);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x206, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L0306;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NS) goto L02a0;
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L0306;
			this.oCPU.AX.Word = 0x0;

		L02a0:
			this.oCPU.CX.Word = 0x140;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L0306;
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.BE) goto L02ad;
			this.oCPU.BX.Word = this.oCPU.CX.Word;

		L02ad:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x20e, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x20a, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x200;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.DX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x204, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, 0x2);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x208, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L0306;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NS) goto L02db;
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L0306;
			this.oCPU.AX.Word = 0x0;

		L02db:
			this.oCPU.CX.Word = 0xc8;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L0306;
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.BE) goto L02e8;
			this.oCPU.BX.Word = this.oCPU.CX.Word;

		L02e8:
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.BE) goto L02ee;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

		L02ee:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x210, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x20c, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x212, 0x1);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0303); // stack management - push return offset
			// Instruction address 0x0000:0x0300, size: 3
			F0_VGA_030e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

		L0303:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0270'");
			this.oCPU.Log = oTempLog;
			return;

		L0306:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x212, 0x0);
			goto L0303;
		}

		public void F0_VGA_030e()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_030e'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1988);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x214, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x212), 0x0);
			if (this.oCPU.Flags.E) goto L0386;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x20c);
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x416));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x20a));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word <<= 1;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x1970));
			// LEA
			this.oCPU.DI.Word = 0x216;
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1988);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x20e);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x210);
			this.oCPU.DX.Word = 0x140;
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DS.Word = this.oCPU.CX.Word;

		L034f:
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.DX.Word);
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);
			if (this.oCPU.Flags.NE) goto L034f;
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1988);
			this.oCPU.DX.Word = 0xc8;
			this.oCPU.DX.Word = this.oCPU.DECWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.DX.Word = 0x140;
			this.oCPU.DX.Word = this.oCPU.DECWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.DX.Word = 0x0;
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x214));
			this.oCPU.CX.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x200));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x204));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x202));
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0383); // stack management - push return offset
			// Instruction address 0x0000:0x0380, size: 3
			F0_VGA_0c3e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x12);

		L0386:
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_030e'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_038c()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_038c'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_038c'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word <<= 1;
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x1970));
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x17d6));
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.BX.Word);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_038c'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_03b1()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_03b1'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_03b1'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.SI.Word + 0x17d6));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.BX.Word <<= 1;
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x1970));
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_03b1'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_03df_CopyLine(ushort bufferPtr, ushort page, ushort xPos, ushort yPos, ushort width)
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_03df_CopyLine'(0x{bufferPtr:x4}, {page}, {xPos}, {yPos}, {width})");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock($"'F0_VGA_03df_CopyLine'(0x{bufferPtr:x4}, {page}, {xPos}, {yPos}, {width})");

			// function body
			ushort usDestinationAddress = (ushort)((yPos * usMaxWidth) + xPos);
			ushort usDestinationSegment = this.oCPU.Memory.ReadWord(this.usSegment, (ushort)(0x1970 + (page << 1)));

			for (int i = 0; i < width; i++)
			{
				this.oCPU.Memory.WriteByte(usDestinationSegment, (ushort)(usDestinationAddress + i), 
					this.oCPU.Memory.ReadByte(this.oCPU.DS.Word, (ushort)(bufferPtr + i)));
			}

			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_03df_CopyLine'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_040a()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_040a'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_040a'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.S) goto L045f;
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.G) goto L045f;
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1980);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.DX.Word = this.oCPU.CX.Word;
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x198a);
			this.oCPU.AX.High = this.oCPU.AX.Low;

		L0426:
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word));
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x190));
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.BP.Word);
			if (this.oCPU.Flags.B) goto L0457;
			if (this.oCPU.Flags.A) goto L043d;
			this.oCPU.BP.Word = this.oCPU.ORWord(this.oCPU.BP.Word, this.oCPU.BP.Word);
			if (this.oCPU.Flags.E) goto L0457;
			this.oCPU.CMPWord(this.oCPU.BP.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1986));
			if (this.oCPU.Flags.E) goto L0457;

		L043d:
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.SI.Word + 0x17d6));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BP.Word);
			this.oCPU.TESTWord(this.oCPU.DI.Word, 0x1);
			if (this.oCPU.Flags.E) goto L044f;
			this.oCPU.STOSByte();
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L0457;

		L044f:
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.REPESTOSWord();
			this.oCPU.CX.Word = this.oCPU.ADCWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			this.oCPU.REPESTOSByte();

		L0457:
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x2);
			this.oCPU.CMPWord(this.oCPU.SI.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.BE) goto L0426;
			this.oCPU.ES.Word = this.oCPU.PopWord();

		L045f:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_040a'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_046d()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_046d'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_046d'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1982, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1984, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1986, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.BX.Word <<= 1;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x1970));
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1980, this.oCPU.AX.Word);
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_046d'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0484()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0484'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0484'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.BX.Word <<= 1;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x1970));
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1980, this.oCPU.AX.Word);
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0484'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0492_GetFreeMemory()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0492_GetFreeMemory'()");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0492_GetFreeMemory'()");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.High = 0x48;
			this.oCPU.BX.Word = 0xffff;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0492_GetFreeMemory'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_049c_SetSlotAddress(ushort slot, ushort address)
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_049c_SetSlotAddress'({slot}, 0x{address:x4})");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock($"'F0_VGA_049c_SetSlotAddress'({slot}, 0x{address:x4})");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.WriteWord(this.oCPU.CS.Word, (ushort)(0x1970 + (slot << 1)), address);

			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_049c_SetSlotAddress'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_04ae_AllocateSlotMemory(ushort slot)
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_04ae_AllocateSlotMemory'({slot})");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock($"'F0_VGA_04ae_AllocateSlotMemory'({slot})");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.CMPWord(slot, 0x0);
			if (this.oCPU.Flags.NE) goto L04bd;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1970);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_04ae_AllocateSlotMemory'");
			this.oCPU.Log = oTempLog;
			return;

		L04bd:
			this.oCPU.AX.High = 0x48;
			this.oCPU.BX.Word = 0xfa0;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L04c8;
			this.oCPU.AX.Word = 0x0;

		L04c8:
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_04ae_AllocateSlotMemory'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_04e8_InitVGA()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_04e8_InitVGA'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_04e8_InitVGA'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x80);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, 0x13);
			this.oCPU.BX.Low = this.oCPU.AX.Low;
			this.oCPU.INT(0x10);
			this.oCPU.AX.High = 0xf;
			this.oCPU.INT(0x10);
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.BX.Low);
			if (this.oCPU.Flags.NE) goto L0505;

			// Set default palette
			F0_VGA_01a1_SetColorBlock(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1988), 0x50, 0, 0x80);
			
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_04e8_InitVGA'");
			this.oCPU.Log = oTempLog;
			return;

		L0505:
			// LEA
			this.oCPU.DX.Word = 0x5dc;
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1988);
			this.oCPU.AX.Word = 0x3;
			this.oCPU.INT(0x10);
			this.oCPU.AX.High = 0x9;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Word = 0x4c00;
			this.oCPU.INT(0x21);
		}

		public void F0_VGA_0550()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0550'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0550'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1988);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1980);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1982));
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1984));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x602, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x604, this.oCPU.BX.Word);
			this.oCPU.PushWord(0x0570); // stack management - push return offset
			// Instruction address 0x0000:0x056d, size: 3
			F0_VGA_057b();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x576, this.oCPU.AX.High);
			// 0x88 - MOV, 0x20 - AND, 0x8 - OR, 0x30 - XOR
			if (this.oCPU.AX.High != 0x88)
				throw new Exception("Undefined instruction");

			// Instruction address cs:0x575, referenced at cs:0x576
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.AX.Low);
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0550'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_057b()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_057b'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x198a);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x198c);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x604);
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x416));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x602));
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.PopWord();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_VGA_057b'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0599()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0599'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0599'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			goto L0599;

		L056d:
			this.oCPU.PushWord(0x0570); // stack management - push return offset
			// Instruction address 0x0000:0x056d, size: 3
			F0_VGA_057b();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x576, this.oCPU.AX.High);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.AX.Low);
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0599'");
			this.oCPU.Log = oTempLog;
			return;

		L0599:
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1988);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1980);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1982);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1984);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.DI.Word);
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.DI.Word);
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.BE) goto L05be;
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Word = this.oCPU.Temp.Word;
			this.oCPU.Temp.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;

		L05be:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x602, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x604, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x606, this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x608, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L05d3;
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L056d;

		L05d3:
			this.oCPU.SI.Word = 0x1;
			this.oCPU.BP.Word = 0x140;
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.BX.Word);
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NS) goto L05e3;
			this.oCPU.CX.Word = this.oCPU.NEGWord(this.oCPU.CX.Word);
			this.oCPU.SI.Word = this.oCPU.NEGWord(this.oCPU.SI.Word);

		L05e3:
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.BP.Word);
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.AE) goto L05ef;
			this.oCPU.Temp.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.SI.Word;
			this.oCPU.SI.Word = this.oCPU.Temp.Word;
			this.oCPU.Temp.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Word = this.oCPU.Temp.Word;

		L05ef:
			if (this.oCPU.Flags.E) goto L0626;
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.BP.Word;
			if (this.oCPU.Flags.E) goto L0626;
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			if (this.oCPU.Flags.E) goto L0626;
			this.oCPU.PushWord(0x0600); // stack management - push return offset
			// Instruction address 0x0000:0x05fd, size: 3
			F0_VGA_057b();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x613, this.oCPU.AX.High);
			// 0x88 - MOV, 0x20 - AND, 0x8 - OR, 0x30 - XOR
			if (this.oCPU.AX.High != 0x88)
				throw new Exception("Undefined instruction");

			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x60a, this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.CX.Word;
			this.oCPU.BP.Word = this.oCPU.INCWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.NEGWord(this.oCPU.BP.Word);
			this.oCPU.BX.Word = this.oCPU.CX.Word;

		L0612:
			// Instruction at cs:0x612 referenced by reference to cs:0x613
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.AX.Low);
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			if (this.oCPU.Flags.S) goto L0638;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);
			this.oCPU.BP.Word = this.oCPU.ADDWord(this.oCPU.BP.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.S) goto L0612;
			this.oCPU.BP.Word = this.oCPU.SUBWord(this.oCPU.BP.Word, this.oCPU.BX.Word);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x60a));
			goto L0612;

		L0626:
			this.oCPU.PushWord(0x0629); // stack management - push return offset
			// Instruction address 0x0000:0x0626, size: 3
			F0_VGA_057b();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x632, this.oCPU.AX.High);
			// 0x88 - MOV, 0x20 - AND, 0x8 - OR, 0x30 - XOR
			if (this.oCPU.AX.High != 0x88)
				throw new Exception("Undefined instruction");

			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);

		L0631:
			// Instruction at cs:0x631 referenced by reference to cs:0x632
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.AX.Low);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0631;

		L0638:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0599'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_063c()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_063c'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_063c'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.SI.Word = this.oCPU.ORWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.E) goto L0665;
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0650); // stack management - push return offset
			// Instruction address 0x0000:0x064d, size: 3
			F0_VGA_030e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SI.Word <<= 1;
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.SI.Word + 0x1970));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1970);
			this.oCPU.SI.Word = 0x0;
			this.oCPU.DI.Word = 0x0;
			this.oCPU.CX.Word = 0x7d00;
			this.oCPU.REPEMOVSWord(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);

		L0665:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_063c'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_06b7()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_06b7'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_06b7'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.WriteByte(this.oCPU.ES.Word, 0x440, this.oCPU.AX.Low);

		L06c7:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.ES.Word, 0x440), this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L06c7;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			if (this.oCPU.Flags.E) goto L0733;
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.SI.Word + 0x1970));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1970);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x6b3), 0x0);
			if (this.oCPU.Flags.NE) goto L06ea;
			this.oCPU.PushWord(0x06ea); // stack management - push return offset
			// Instruction address 0x0000:0x06e7, size: 3
			F0_VGA_0776();
			this.oCPU.PopWord(); // stack management - pop return offset

		L06ea:
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			if (this.oCPU.CX.Word == 0) goto L0738;
			this.oCPU.AX.Word = 0x2260;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.NE) goto L0700;
			this.oCPU.BX.Word = 0x1;

		L0700:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x6b3);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.BE) goto L0738;
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x6b5));
			this.oCPU.CX.Low = 0x4;

		L070f:
			this.oCPU.CMPWord(this.oCPU.DX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.B) goto L071b;
			this.oCPU.DX.Word = this.oCPU.SHRWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.RCRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Low = this.oCPU.DECByte(this.oCPU.CX.Low);
			goto L070f;

		L071b:
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Low = this.oCPU.ORByte(this.oCPU.CX.Low, this.oCPU.CX.Low);
			if (this.oCPU.Flags.S) goto L072b;
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ADCWord(this.oCPU.BX.Word, 0x1);
			goto L073a;

		L072b:
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x1);
			goto L073a;

		L0733:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_06b7'");
			this.oCPU.Log = oTempLog;
			return;

		L0738:
			this.oCPU.BX.Word = 0x0;

		L073a:
			this.oCPU.SI.Word = 0x1;
			this.oCPU.CX.Word = 0xfa00;
			this.oCPU.CMPWord(this.oCPU.BX.Word, 0x1);
			if (this.oCPU.Flags.A) goto L075b;

		L0745:
			this.oCPU.SI.Word = this.oCPU.SHRWord(this.oCPU.SI.Word, 0x1);
			if (this.oCPU.Flags.AE) goto L074d;
			this.oCPU.SI.Word = this.oCPU.XORWord(this.oCPU.SI.Word, 0xb400);

		L074d:
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0xfa00);
			if (this.oCPU.Flags.A) goto L0745;
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.SI.Word;
			this.oCPU.MOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0745;
			goto L0733;

		L075b:
			this.oCPU.SI.Word = this.oCPU.SHRWord(this.oCPU.SI.Word, 0x1);
			if (this.oCPU.Flags.AE) goto L0763;
			this.oCPU.SI.Word = this.oCPU.XORWord(this.oCPU.SI.Word, 0xb400);

		L0763:
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0xfa00);
			if (this.oCPU.Flags.A) goto L075b;
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.SI.Word;
			this.oCPU.MOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI);
			this.oCPU.AX.Word = this.oCPU.BX.Word;

		L076f:
			this.oCPU.AX.Word = 0; // this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			//if (this.oCPU.Flags.NE) goto L076f;
			if (this.oCPU.Loop(this.oCPU.CX)) goto L075b;
			goto L0733;
		}

		public void F0_VGA_0776()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0776'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.BX.Word = 0x1;
			this.oCPU.PushWord(0x077c); // stack management - push return offset
			// Instruction address 0x0000:0x0779, size: 3
			F0_VGA_07a4();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x6b3, this.oCPU.CX.Word);
			this.oCPU.BX.Word = 0x11;
			this.oCPU.PushWord(0x0787); // stack management - push return offset
			// Instruction address 0x0000:0x0784, size: 3
			F0_VGA_07a4();
			// here cx should be less than first value
			this.oCPU.CX.Word = 0x13eb / 0x11;
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Low = 0x0;
			this.oCPU.AX.High = this.oCPU.CX.Low;
			this.oCPU.DX.Low = this.oCPU.CX.High;
			this.oCPU.DX.High = 0x0;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x6b3);
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.ADCWord(this.oCPU.AX.Word, 0x0);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x6b5, this.oCPU.AX.Word);
			// Near return
			this.oCPU.Log.ExitBlock("'F0_VGA_0776'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_07a4()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_07a4'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.CLI();
			this.oCPU.CX.Word = 0x0;
			this.oCPU.SI.Word = 0x1;
			this.oCPU.DX.Word = 0x3da;

		L07ad:
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.E) goto L07ad;

		L07b2:
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.NE) goto L07b2;

		L07b7:
			this.oCPU.SI.Word = this.oCPU.SHRWord(this.oCPU.SI.Word, 0x1);
			if (this.oCPU.Flags.AE) goto L07bf;
			this.oCPU.SI.Word = this.oCPU.XORWord(this.oCPU.SI.Word, 0xb400);

		L07bf:
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0xfa00);
			if (this.oCPU.Flags.A) goto L07b7;
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);
			this.oCPU.DI.Word = 0xffff;
			this.oCPU.MOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI);
			this.oCPU.AX.Word = this.oCPU.BX.Word;

		L07cc:
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L07cc;
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.E) goto L07b7;

			// in real VGA CX.Word=0x13eb approximately
			this.oCPU.CX.Word = 0x13eb;

			this.oCPU.STI();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_VGA_07a4'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_07d8()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_07d8'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_07d8'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x10));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4));
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x12)));
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x14)));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.SI.Word <<= 1;
			this.oCPU.DI.Word <<= 1;
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.SI.Word + 0x1970));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.DI.Word + 0x1970));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x17d6));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x17d6));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0846;
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L0846;
			this.oCPU.DX.Word = 0x140;
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L0835:
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.REPEMOVSWord(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.CX.Word = this.oCPU.ADCWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.DX.Word);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.DX.Word);
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);
			if (this.oCPU.Flags.NE) goto L0835;

		L0846:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_07d8'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0a1e()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0a1e'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0a1e'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0a23); // stack management - push return offset
			// Instruction address 0x0000:0x0a20, size: 3
			F0_VGA_0492_GetFreeMemory();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L0a2f;
			this.oCPU.AX.High = 0x48;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L0a33;

		L0a2f:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.BX.Word = 0x0;

		L0a33:
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x89e, 0x0);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8a0, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8a2, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8a4, this.oCPU.BX.Word);
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0a1e'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0a4a()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0a4a'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0a4a'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8a2);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8a0);
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.B) goto L0a63;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.AX.High = 0x49;
			if (this.oCPU.Flags.E) goto L0a5f;
			this.oCPU.AX.High = 0x4a;

		L0a5f:
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L0a67;

		L0a63:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.ES.Word = this.oCPU.AX.Word;

		L0a67:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8a0, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8a4, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8a2, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ES.Word;
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0a4a'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0a78()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0a78'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0a78'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8a4);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8a0));
			if (this.oCPU.Flags.BE) goto L0aba;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1000);
			if (this.oCPU.Flags.B) goto L0a8e;
			this.oCPU.AX.Word = 0xfff;

		L0a8e:
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8a6, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			// LES
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x89e);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(0x89e + 2));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.STOSWord();
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8b0, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.STOSWord();
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8ae, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x89e, this.oCPU.DI.Word);
			this.oCPU.AX.Word = this.oCPU.ES.Word;
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0a78'");
			this.oCPU.Log = oTempLog;
			return;

		L0aba:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x89e, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8a0, this.oCPU.AX.Word);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0a78'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0ac6()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0ac6'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0ac6'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = 0x0;
			this.oCPU.Temp.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x89e);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x89e, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.Temp.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xf);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8a0));
			this.oCPU.Temp.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8a0);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8a0, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.Temp.Word;
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0ac6'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0ae3()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0ae3'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0ae3'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			// LES
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x89e);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(0x89e + 2));
			this.oCPU.AX.Word = this.oCPU.ES.Word;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0af9;
			goto L0b81;

		L0af9:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8b0);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8a6));
			if (this.oCPU.Flags.BE) goto L0b17;
			this.oCPU.WriteWord(this.oCPU.ES.Word, 0x2, this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.ES.Word, 0x2)));
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8a4, this.oCPU.AX.Word);
			goto L0b81;

		L0b17:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8a8, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8aa, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8ac, this.oCPU.AX.Word);
			this.oCPU.BP.Word = this.oCPU.DI.Word;
			this.oCPU.STOSWord();
			this.oCPU.STOSWord();
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8b0);

		L0b2e:
			this.oCPU.LODSByte();
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L0b3d;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8aa, 0x0);
			goto L0b54;

		L0b3d:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ac), 0x0);
			if (this.oCPU.Flags.NE) goto L0b4f;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8a8, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8a8)));
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0b2e;
			goto L0b5c;

		L0b4f:
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8aa, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8aa)));

		L0b54:
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8ac, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ac)));
			this.oCPU.STOSByte();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0b2e;

		L0b5c:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ac);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8a8);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8aa);
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L0b72;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.DI.Word = this.oCPU.SUBWord(this.oCPU.DI.Word, this.oCPU.CX.Word);

		L0b72:
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.BP.Word + 0x0), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.BP.Word + 0x2), this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x89e, this.oCPU.DI.Word);
			this.oCPU.AX.Word = this.oCPU.ES.Word;

		L0b81:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0ae3'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0b85()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0b85'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0b85'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0b95); // stack management - push return offset
			// Instruction address 0x0000:0x0b92, size: 3
			F0_VGA_0a78();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0be0;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ae), 0x0);
			if (this.oCPU.Flags.E) goto L0be0;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8b0), 0x0);
			if (this.oCPU.Flags.E) goto L0be0;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.SI.Word + 0x17d6));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.BP.Word = this.oCPU.DX.Word;
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word <<= 1;
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x1970));

		L0bcc:
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0bd2); // stack management - push return offset
			// Instruction address 0x0000:0x0bcf, size: 3
			F0_VGA_0ae3();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x140);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8ae, this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ae)));
			if (this.oCPU.Flags.NE) goto L0bcc;

		L0be0:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0be5); // stack management - push return offset
			// Instruction address 0x0000:0x0be2, size: 3
			F0_VGA_0ac6();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0b85'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0c3e()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0c3e'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0c3e'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.SI.Word = 0x0;
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8ba, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8bc, this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0c62); // stack management - push return offset
			// Instruction address 0x0000:0x0c5f, size: 3
			F0_VGA_0d12();
			this.oCPU.PopWord(); // stack management - pop return offset
			if (this.oCPU.Flags.E) goto L0c6c;
			this.oCPU.PushWord(0x0c67); // stack management - push return offset
			// Instruction address 0x0000:0x0c64, size: 3
			F0_VGA_0c77();
			this.oCPU.PopWord(); // stack management - pop return offset
			if (this.oCPU.Flags.B) goto L0c6c;
			this.oCPU.PushWord(0x0c6c); // stack management - push return offset
			// Instruction address 0x0000:0x0c69, size: 3
			F0_VGA_0d68();
			this.oCPU.PopWord(); // stack management - pop return offset

		L0c6c:
			// LEA
			this.oCPU.AX.Word = 0x8c2;
			this.oCPU.DX.Word = this.oCPU.CS.Word;
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0c3e'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0c77()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0c77'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.DI.Word = this.oCPU.ORWord(this.oCPU.DI.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.NS) goto L0c8a;
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8bc));
			if (this.oCPU.Flags.AE) goto L0cd6;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8ca, this.oCPU.AX.Word);

		L0c8a:
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8bc));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.S) goto L0cd6;
			this.oCPU.CMPWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.G) goto L0cd6;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.LE) goto L0ca5;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8ce, this.oCPU.AX.Word);

		L0ca5:
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NS) goto L0cb8;
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ba));
			if (this.oCPU.Flags.AE) goto L0cd6;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8cc, this.oCPU.AX.Word);

		L0cb8:
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ba));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.S) goto L0cd6;
			this.oCPU.CMPWord(this.oCPU.DX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.G) goto L0cd6;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.LE) goto L0cd8;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8d0, this.oCPU.AX.Word);
			goto L0cd8;

		L0cd6:
			this.oCPU.Flags.C = true;
			// Near return
			this.oCPU.Log.ExitBlock("'F0_VGA_0c77'");
			this.oCPU.Log = oTempLog;
			return;

		L0cd8:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8cc);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8c2, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ca);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8c4, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ba);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8cc));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8d0));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8c6, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8bc);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ca));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ce));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8c8, this.oCPU.AX.Word);
			this.oCPU.Flags.C = false;
			// Near return
			this.oCPU.Log.ExitBlock("'F0_VGA_0c77'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0d12()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0d12'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8ca, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8cc, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8ce, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8d0, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8c2, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8c4, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8c6, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8c8, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0d46;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x0);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0d46;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);

		L0d46:
			// Near return
			this.oCPU.Log.ExitBlock("'F0_VGA_0d12'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0d47()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0d47'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0d47'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.SI.Word = 0x0;
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.PushWord(0x0d5e); // stack management - push return offset
			// Instruction address 0x0000:0x0d5b, size: 3
			F0_VGA_0d12();
			this.oCPU.PopWord(); // stack management - pop return offset
			if (this.oCPU.Flags.E) goto L0d63;
			this.oCPU.PushWord(0x0d63); // stack management - push return offset
			// Instruction address 0x0000:0x0d60, size: 3
			F0_VGA_0d68();
			this.oCPU.PopWord(); // stack management - pop return offset

		L0d63:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0d47'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0d68()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0d68'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x0));
			this.oCPU.BX.Word <<= 1;
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x1970));
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x2)));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x4)));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ca));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.DI.Word + 0x17d6));
			this.oCPU.BP.Word = this.oCPU.ADDWord(this.oCPU.BP.Word, this.oCPU.DX.Word);
			this.oCPU.LODSWord();
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8d0));
			if (this.oCPU.Flags.LE) goto L0df5;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8b4, this.oCPU.AX.Word);
			this.oCPU.LODSWord();
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ca));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ce));
			if (this.oCPU.Flags.LE) goto L0df5;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8b2, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8ca);
			if (this.oCPU.CX.Word == 0) goto L0db3;

		L0dac:
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x4);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0dac;

		L0db3:
			this.oCPU.LODSWord();
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.DX.Word = this.oCPU.AX.Word;
			this.oCPU.LODSWord();
			if (this.oCPU.CX.Word == 0) goto L0de8;
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8cc));
			if (this.oCPU.Flags.A) goto L0dcc;
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L0dcc:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8b4);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.A) goto L0dd6;
			this.oCPU.CX.Word = this.oCPU.AX.Word;

		L0dd6:
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.BE) goto L0de8;
			this.oCPU.DI.Word = this.oCPU.BP.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.CX.Word);

		L0de0:
			this.oCPU.LODSByte();
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L0df8;
			this.oCPU.STOSByte();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0de0;

		L0de8:
			this.oCPU.BP.Word = this.oCPU.ADDWord(this.oCPU.BP.Word, 0x140);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.DX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x8b2, this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x8b2)));
			if (this.oCPU.Flags.NE) goto L0db3;

		L0df5:
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_VGA_0d68'");
			this.oCPU.Log = oTempLog;
			return;

		L0df8:
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0de0;
			goto L0de8;
		}

		public void F0_VGA_0fac()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0fac'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			goto L0fac;

		L0f9c:
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x7f);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x60c, this.oCPU.AX.Low);
			goto L0fe3;

		L0fa4:
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x60c);
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc), this.oCPU.AX.Low);
			// Near return
			this.oCPU.Log.ExitBlock("'F0_VGA_0fac'");
			this.oCPU.Log = oTempLog;
			return;

		L0fac:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x60c, this.oCPU.AX.Low);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0fb7); // stack management - push return offset
			// Instruction address 0x0000:0x0fb4, size: 3
			F0_VGA_020c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x105d, this.oCPU.AX.Low);
			// 0x88 - MOV, 0x20 - AND, 0x8 - OR, 0x30 - XOR
			if (this.oCPU.AX.Low != 0x88)
				throw new Exception("Undefined instruction");

			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x60d, this.oCPU.AX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x60e, this.oCPU.AX.Low);
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x614);
			this.oCPU.BX.Word = this.oCPU.ES.Word;
			this.oCPU.BX.Word <<= 1;
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x1970));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x618);
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x416));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x616));

		L0fe3:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L0fa4;
			if (this.oCPU.Flags.S) goto L0f9c;
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61e));
			if (this.oCPU.Flags.A) goto L0fe3;
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61d));
			if (this.oCPU.Flags.B) goto L0fe3;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ANDWord(this.oCPU.SI.Word, 0xff);
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61a);
			this.oCPU.CX.Low = this.oCPU.ORByte(this.oCPU.CX.Low, this.oCPU.CX.Low);
			if (this.oCPU.Flags.NE) goto L1013;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x612);
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word));
			this.oCPU.CX.Low = this.oCPU.ADDByte(this.oCPU.CX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61b));

		L1013:
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.AX.High);
			if (this.oCPU.Flags.NE) goto L101b;
			this.oCPU.CX.Low = this.oCPU.SUBByte(this.oCPU.CX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x620));

		L101b:
			this.oCPU.CX.Low = this.oCPU.SUBByte(this.oCPU.CX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61f));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x60f, this.oCPU.CX.Low);
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61c);
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x610));
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61f);
			this.oCPU.CX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x621);
			this.oCPU.DX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x60c);
			this.oCPU.DX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x60d);
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x60e), 0x1);
			if (this.oCPU.Flags.E) goto L1083;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x60f);
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.AX.High);
			if (this.oCPU.Flags.E) goto L104f;
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61b));

		L104f:
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.AX.High = this.oCPU.AX.Low;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.Temp.Low = this.oCPU.BX.Low;
			this.oCPU.BX.Low = this.oCPU.BX.High;
			this.oCPU.BX.High = this.oCPU.Temp.Low;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

		L1058:
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			if (this.oCPU.Flags.AE) goto L105f;
			// Instruction at cs:0x105c, referenced by cs:0x105d
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.DX.Low);

		L105f:
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.AX.High = this.oCPU.DECByte(this.oCPU.AX.High);
			if (this.oCPU.Flags.NE) goto L1058;
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x140);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.CX.High = this.oCPU.DECByte(this.oCPU.CX.High);
			if (this.oCPU.Flags.NE) goto L104f;

		L106f:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.AX.High = 0x0;
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x61f, this.oCPU.AX.High);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x60f);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x616, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x616), this.oCPU.AX.Word));
			goto L0fe3;

		L1083:
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x60f);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.Temp.Low = this.oCPU.BX.Low;
			this.oCPU.BX.Low = this.oCPU.BX.High;
			this.oCPU.BX.High = this.oCPU.Temp.Low;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

		L108e:
			this.oCPU.AX.Low = this.oCPU.DX.Low;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			if (this.oCPU.Flags.B) goto L1096;
			this.oCPU.AX.Low = this.oCPU.DX.High;

		L1096:
			this.oCPU.STOSByte();
			this.oCPU.AX.High = this.oCPU.DECByte(this.oCPU.AX.High);
			if (this.oCPU.Flags.NE) goto L108e;
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x140);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.CX.High = this.oCPU.DECByte(this.oCPU.CX.High);
			if (this.oCPU.Flags.NE) goto L1083;
			goto L106f;
		}

		public void F0_VGA_10bb_ScrollLeft()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_10bb_ScrollLeft'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_10bb_ScrollLeft'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x10ac);
			this.oCPU.AX.Word <<= 2;
			this.oCPU.AX.Word += this.oCPU.ReadWord(this.oCPU.CS.Word, 0x10ac);
			this.oCPU.AX.Word++;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x10ac, this.oCPU.AX.Word);

			if (this.oCPU.ReadByte(this.oCPU.CS.Word, 0x10ae) != 0x0)
			{
				this.oCPU.AX.High = this.oCPU.ANDByte(this.oCPU.AX.High, 0x3);
				this.oCPU.WriteByte(this.oCPU.CS.Word, 0x10ae, this.oCPU.DECByte(this.oCPU.ReadByte(this.oCPU.CS.Word, 0x10ae)));
				if (this.oCPU.Flags.NE) goto L10e1;
				this.oCPU.AX.High = 0x0;

			L10e1:
				this.oCPU.DX.Word = 0x3d4;
				this.oCPU.AX.Low = 0xd;
				this.oCPU.OUTWord(this.oCPU.DX.Word, 0xd); // Set GPU start address low
			}

			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_10bb_ScrollLeft'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_115d()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_115d'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_115d'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1988);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.CX.Low = this.oCPU.ORByte(this.oCPU.CX.Low, this.oCPU.CX.Low);
			if (this.oCPU.Flags.S) goto L11a8;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x630));
			if (this.oCPU.Flags.A) goto L11a8;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L11a8;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x630));
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x630);
			this.oCPU.CMPByte(this.oCPU.CX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x8)));
			if (this.oCPU.Flags.B) goto L11a8;
			this.oCPU.CMPByte(this.oCPU.CX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x7)));
			if (this.oCPU.Flags.A) goto L11a8;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x3));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x5));
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L11a8;
			this.oCPU.AX.Low = this.oCPU.CX.Low;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x7));
			this.oCPU.CX.Low = this.oCPU.SUBByte(this.oCPU.CX.Low, this.oCPU.AX.Low);
			this.oCPU.CX.High = 0x0;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0xfff7);
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word);

		L11a8:
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.AX.High);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_115d'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_11ae()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_11ae'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_11ae'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1988);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x630));
			if (this.oCPU.Flags.A) goto L11d4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L11d4;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x630));
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x630);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x4));
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x2)));

		L11d4:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_11ae'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_11d7()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_11d7'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_11d7'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x11ec); // stack management - push return offset
			// Instruction address 0x0000:0x11e9, size: 3
			F0_VGA_11f0();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_11d7'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_11f0()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_11f0'");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1988);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x0));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x616, this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x618, this.oCPU.DX.Word);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x624, this.oCPU.AX.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x61f, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x620, this.oCPU.AX.Low);
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.SS.Word, this.oCPU.BX.Word), this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L1311;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x10));
			this.oCPU.CMPWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x630));
			if (this.oCPU.Flags.A) goto L1311;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			if (this.oCPU.Flags.E) goto L1311;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x630));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x630);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x610, this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x4));
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), 0x1);
			if (this.oCPU.Flags.E) goto L1370;
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x2)));

		L1370:
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x621, this.oCPU.AX.Word);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x3));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x61b, this.oCPU.AX.High);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x5));
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L1384;
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.AX.High);

		L1384:
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x61a, this.oCPU.AX.Low);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x8));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x61d, this.oCPU.AX.High);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x7));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x61e, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, this.oCPU.AX.High);
			this.oCPU.AX.High = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x6));
			this.oCPU.CX.Low = this.oCPU.DECByte(this.oCPU.CX.Low);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x61c, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0xfff7);
			this.oCPU.DI.Word = this.oCPU.SUBWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x612, this.oCPU.DI.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x614, this.oCPU.AX.Word);

			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.S) goto L12b1;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x616));
			if (this.oCPU.Flags.L) goto L12b1;
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.AX.High = 0x0;
			this.oCPU.SI.Word = this.oCPU.BX.Word;
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);

		L126f:
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L12b0;
			if (this.oCPU.Flags.S) goto L126f;
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61e));
			if (this.oCPU.Flags.A) goto L126f;
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61d));
			if (this.oCPU.Flags.B) goto L126f;
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61a);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L1298;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x612));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61b));

		L1298:
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L126f;
			this.oCPU.CX.Word = this.oCPU.NEGWord(this.oCPU.CX.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x620, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, this.oCPU.SI.Word);
			this.oCPU.WriteByte(this.oCPU.SS.Word, this.oCPU.SI.Word, this.oCPU.AX.High);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x623, this.oCPU.AX.Low);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x624, this.oCPU.SI.Word);
			goto L12b0;

		L12b1:
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x624);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L131f;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x623);
			this.oCPU.WriteByte(this.oCPU.SS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);
			goto L131f;
			
		L12b0:
			this.oCPU.CX.Word = 0x0;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), this.oCPU.CX.Word);
			if (this.oCPU.Flags.S) goto L124f;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x616), this.oCPU.CX.Word);
			if (this.oCPU.Flags.NS) goto L124e;
			this.oCPU.Temp.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x616);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x616, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.Temp.Word;
			this.oCPU.AX.High = 0x0;
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);

		L121c:
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, this.oCPU.BX.Word);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L124f;
			if (this.oCPU.Flags.S) goto L121c;
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61e));
			if (this.oCPU.Flags.A) goto L121c;
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61d));
			if (this.oCPU.Flags.B) goto L121c;
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61a);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L1245;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x612));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x61b));

		L1245:
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L121c;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x61f, this.oCPU.AX.Low);
			goto L124e;

		L124f:
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x624);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L131f;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x623);
			this.oCPU.WriteByte(this.oCPU.SS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);
			goto L131f;

		L124e:
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.S) goto L12f7;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x618);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NS) goto L12e2;
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x621, this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x621), this.oCPU.AX.Word));
			if (this.oCPU.Flags.BE) goto L12f7;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x618, 0x0);
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x614));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x610, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x610), this.oCPU.AX.Word));

		L12e2:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x618);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.A) goto L12f7;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x621));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.BE) goto L12f6;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x621, this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x621), this.oCPU.AX.Word));
			goto L12f6;

		L12f7:
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x624);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L131f;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x623);
			this.oCPU.WriteByte(this.oCPU.SS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);
			goto L131f;

		L12f6:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x2));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x616, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x616), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x4));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x618, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x618), this.oCPU.AX.Word));
			this.oCPU.SI.Word = this.oCPU.BX.Word;

			this.oCPU.PushWord(0x1311); // stack management - push return offset
			// Instruction address 0x0000:0x130e, size: 3
			F0_VGA_0fac();
			this.oCPU.PopWord(); // stack management - pop return offset

			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x624);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L131f;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x623);
			this.oCPU.WriteByte(this.oCPU.SS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);

		L131f:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x616);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x2)));
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_11f0'");
			this.oCPU.Log = oTempLog;
			return;

		L1311:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x624);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L131f;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x623);
			this.oCPU.WriteByte(this.oCPU.SS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);
			goto L131f;
		}
	}
}
