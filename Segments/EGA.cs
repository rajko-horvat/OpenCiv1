using System;
using Disassembler;

namespace Civilization1
{
	public class VGADriver
	{
		private Civilization oParent;
		private CPU oCPU;
		private ushort usSegment = 0;

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

		public void F0_0000_009a()
		{
			this.oParent.LogEnterBlock("'F0_0000_009a'(Cdecl, Far) at 0x0000:0x009a");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2)));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a52), 0x1);
			if (this.oCPU.Flags.NE) goto L00b8;
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

		L00b8:
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.DX.Word);
			this.oCPU.DI.Word = this.oCPU.DECWord(this.oCPU.DI.Word);
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = 0xff80;
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0x7);
			this.oCPU.BX.High = this.oCPU.SHRByte(this.oCPU.BX.High, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.DI.Word;
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0x7);
			this.oCPU.BX.Low = this.oCPU.SARByte(this.oCPU.BX.Low, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4)));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.DI.Word + 0x28ba));
			this.oCPU.DX.Word = this.oCPU.SHRWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.DX.Word = this.oCPU.SHRWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.DX.Word = this.oCPU.SHRWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.DX.Word);
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Low = 0x0;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x12));
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a73, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xf01;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a74, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x2;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x10));
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a75, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x805;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a78, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x8;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a72, this.oCPU.AX.Low);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.SI.Word + 0x2a54));
			this.oCPU.DS.Word = this.oCPU.SI.Word;
			this.oCPU.ES.Word = this.oCPU.SI.Word;
			this.oCPU.SI.Word = this.oCPU.DI.Word;

		L013b:
			this.oCPU.DI.Word = this.oCPU.SI.Word;
			this.oCPU.CX.High = this.oCPU.CX.Low;
			this.oCPU.AX.High = this.oCPU.BX.High;
			this.oCPU.AX.High = this.oCPU.ANDByte(this.oCPU.AX.High, this.oCPU.BX.Low);
			this.oCPU.CX.High = this.oCPU.DECByte(this.oCPU.CX.High);
			if (this.oCPU.Flags.E) goto L015c;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, this.oCPU.BX.High);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.STOSByte();
			this.oCPU.AX.High = this.oCPU.BX.Low;
			this.oCPU.CX.High = this.oCPU.DECByte(this.oCPU.CX.High);
			if (this.oCPU.Flags.E) goto L015c;

		L0154:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.STOSByte();
			this.oCPU.CX.High = this.oCPU.DECByte(this.oCPU.CX.High);
			if (this.oCPU.Flags.NE) goto L0154;

		L015c:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, this.oCPU.AX.High);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.STOSByte();
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e));
			this.oCPU.BP.Word = this.oCPU.DECWord(this.oCPU.BP.Word);
			if (this.oCPU.Flags.NE) goto L013b;
			this.oCPU.DX.Word = this.oCPU.DECWord(this.oCPU.DX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a74, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x5;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a78, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xff08;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_009a'");
		}

		public void F0_0000_04a3()
		{
			this.oParent.LogEnterBlock("'F0_0000_04a3'(Cdecl, Far) at 0x0000:0x04a3");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			// LEA
			this.oCPU.DI.Word = 0x50;
			this.oCPU.DX.Word = this.oCPU.DI.Word;
			this.oCPU.CX.Word = 0x11;

		L04b9:
			this.oCPU.LODSByte();
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xf);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x8);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x17);
			this.oCPU.STOSByte();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L04b9;
			this.oCPU.PushWord(0x04c6); // stack management - push return offset
			// Instruction address 0x0000:0x04c3, size: 3
			F0_0000_053f();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_04a3'");
		}

		public void F0_0000_04ca()
		{
			this.oParent.LogEnterBlock("'F0_0000_04ca'(Cdecl, Far) at 0x0000:0x04ca");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.NE) goto L04e0;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x189, 0x0);
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_04ca'");
			return;

		L04e0:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x45);
			if (this.oCPU.Flags.NE) goto L053b;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1)), 0x30);
			if (this.oCPU.Flags.E) goto L0500;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1)), 0x31);
			if (this.oCPU.Flags.NE) goto L053b;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x04fa); // stack management - push return offset
			// Instruction address 0x0000:0x04f7, size: 3
			F0_0000_04a3();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			goto L053b;

		L0500:
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x189, 0xff);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L053b;
			this.oCPU.CX.Word = this.oCPU.CS.Word;
			this.oCPU.ES.Word = this.oCPU.CX.Word;
			// LEA
			this.oCPU.DI.Word = 0x18a;
			this.oCPU.SI.Word = this.oCPU.BX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x6);
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x5));
			this.oCPU.CX.High = 0x0;
			this.oCPU.BX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4));
			this.oCPU.BX.High = 0x0;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.BX.Word);
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);

		L052a:
			this.oCPU.LODSByte();
			this.oCPU.AX.High = this.oCPU.AX.Low;
			this.oCPU.AX.Low = this.oCPU.RORByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.RORByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.RORByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.RORByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0xf0f);
			this.oCPU.STOSWord();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L052a;

		L053b:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_04ca'");
		}

		public void F0_0000_053f()
		{
			this.oParent.LogEnterBlock("'F0_0000_053f'(Cdecl, Near) at 0x0000:0x053f");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Word = 0x0;
			this.oCPU.DX.Word = 0x3da;

		L0547:
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.E) goto L0547;

		L054c:
			this.oCPU.DX.Low = 0xda;
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L0547;
			this.oCPU.DX.Low = 0xc0;
			this.oCPU.AX.Low = this.oCPU.CX.Low;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.AX.Word = 0x20;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.CX.Low = this.oCPU.INCByte(this.oCPU.CX.Low);
			this.oCPU.AAA();
			this.oCPU.CX.Low = this.oCPU.ADDByte(this.oCPU.CX.Low, this.oCPU.AX.High);
			this.oCPU.CMPByte(this.oCPU.CX.Low, 0x11);
			if (this.oCPU.Flags.BE) goto L054c;
			// Near return
			this.oParent.LogExitBlock("'F0_0000_053f'");
		}

		public void F0_0000_058c()
		{
			this.oParent.LogEnterBlock("'F0_0000_058c'(Cdecl, Far) at 0x0000:0x058c");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a73, this.oCPU.AX.Low);
			this.oCPU.AX.Low = 0x3;
			this.oCPU.AX.High = this.oCPU.ANDByte(this.oCPU.AX.High, this.oCPU.AX.Low);
			this.oCPU.AX.High = this.oCPU.SHLByte(this.oCPU.AX.High, 0x1);
			this.oCPU.AX.High = this.oCPU.SHLByte(this.oCPU.AX.High, 0x1);
			this.oCPU.AX.High = this.oCPU.SHLByte(this.oCPU.AX.High, 0x1);
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a76, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x0;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x2a73);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xf01;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a74, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Word = this.oCPU.BX.Word;
			// Far return
			this.oParent.LogExitBlock("'F0_0000_058c'");
		}

		public void F0_0000_05b9()
		{
			this.oParent.LogEnterBlock("'F0_0000_05b9'(Cdecl, Far) at 0x0000:0x05b9");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.DX.Word = 0x3c4;
			this.oCPU.AX.Word = 0xf02;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a79, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a74, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a76, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x4;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a77, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x5;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a78, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xff08;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a71, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_05b9'");
		}

		public void F0_0000_05fd()
		{
			this.oParent.LogEnterBlock("'F0_0000_05fd'(Cdecl, Near) at 0x0000:0x05fd");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.DX.Word = 0x3c4;
			this.oCPU.AX.Word = 0xf02;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x4;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x5;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xff08;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			// Near return
			this.oParent.LogExitBlock("'F0_0000_05fd'");
		}

		public void F0_0000_061c()
		{
			this.oParent.LogEnterBlock("'F0_0000_061c'(Cdecl, Near) at 0x0000:0x061c");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.DX.Word = 0x3c4;
			this.oCPU.AX.Low = 0x2;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x2a79);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x2a74);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x3;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x2a76);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x4;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x2a77);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x5;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x2a78);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x8;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x2a71);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Near return
			this.oParent.LogExitBlock("'F0_0000_061c'");
		}

		public void F0_0000_065a()
		{
			this.oParent.LogEnterBlock("'F0_0000_065a'(Cdecl, Far) at 0x0000:0x065a");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(0x065d); // stack management - push return offset
			// Instruction address 0x0000:0x065a, size: 3
			F0_0000_0665();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x26b4, 0x0);
			// Far return
			this.oParent.LogExitBlock("'F0_0000_065a'");
		}

		public void F0_0000_0665()
		{
			this.oParent.LogEnterBlock("'F0_0000_0665'(Cdecl, Near) at 0x0000:0x0665");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.PushWord(0x066c); // stack management - push return offset
			// Instruction address 0x0000:0x0669, size: 3
			F0_0000_05fd();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x74), 0x0);
			if (this.oCPU.Flags.E) goto L06b9;
			// LEA
			this.oCPU.SI.Word = 0x7a;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6e);
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x27a));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6c));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x76);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x2a54));
			this.oCPU.DX.Word = 0x3c4;
			this.oCPU.AX.Word = 0x802;

		L069b:
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x72);

		L06a2:
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x70);
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x78));
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);
			if (this.oCPU.Flags.NE) goto L06a2;
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.AX.High = this.oCPU.SHRByte(this.oCPU.AX.High, 0x1);
			if (this.oCPU.Flags.AE) goto L069b;
			this.oCPU.AX.Word = 0xf02;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L06b9:
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			// Near return
			this.oParent.LogExitBlock("'F0_0000_0665'");
		}

		public void F0_0000_06be()
		{
			this.oParent.LogEnterBlock("'F0_0000_06be'(Cdecl, Far) at 0x0000:0x06be");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x62, this.oCPU.AX.Word);
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x64, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, 0x0);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x68, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L0738;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NS) goto L06ee;
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L0738;
			this.oCPU.AX.Word = 0x0;

		L06ee:
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L0738;
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.BE) goto L0703;
			this.oCPU.BX.Word = this.oCPU.CX.Word;

		L0703:
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, 0x7);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x7);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x70, this.oCPU.BX.Word);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6c, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x78, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x200;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.DX.Word = this.oCPU.AX.Word;
			goto L0741;

		L0738:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x74, 0x0);
			goto L0788;

		L0741:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x66, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, 0x2);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6a, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L0738;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NS) goto L0760;
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L0738;
			this.oCPU.AX.Word = 0x0;

		L0760:
			this.oCPU.CX.Word = 0xc8;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L0738;
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.BE) goto L076d;
			this.oCPU.BX.Word = this.oCPU.CX.Word;

		L076d:
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.BE) goto L0773;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

		L0773:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x72, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6e, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x74, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x76);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0788); // stack management - push return offset
			// Instruction address 0x0000:0x0785, size: 3
			F0_0000_078e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

		L0788:
			this.oCPU.PushWord(0x078b); // stack management - push return offset
			// Instruction address 0x0000:0x0788, size: 3
			F0_0000_061c();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_06be'");
		}

		public void F0_0000_078e()
		{
			this.oParent.LogEnterBlock("'F0_0000_078e'(Cdecl, Far) at 0x0000:0x078e");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x76, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x74), 0x0);
			if (this.oCPU.Flags.E) goto L081a;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6e);
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x27a));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6c));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x2a54));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			// LEA
			this.oCPU.DI.Word = 0x7a;
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Word = 0x304;

		L07c7:
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, 0x72);

		L07cf:
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, 0x70);
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.ES.Word, 0x78));
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);
			if (this.oCPU.Flags.NE) goto L07cf;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.AX.High = this.oCPU.DECByte(this.oCPU.AX.High);
			if (this.oCPU.Flags.NS) goto L07c7;
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.DX.Word = 0xc8;
			this.oCPU.DX.Word = this.oCPU.DECWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.DX.Word = this.oCPU.DECWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.DX.Word = 0x0;
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x76));
			this.oCPU.CX.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x62));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x66));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x64));
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0817); // stack management - push return offset
			// Instruction address 0x0000:0x0814, size: 3
			F0_0000_1b2a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x12);

		L081a:
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_078e'");
		}

		public void F0_0000_0964()
		{
			this.oParent.LogEnterBlock("'F0_0000_0964'(Cdecl, Far) at 0x0000:0x0964");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x2a54));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.SI.Word + 0x28ba));
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0x7);
			this.oCPU.CX.High = 0x80;
			this.oCPU.CX.High = this.oCPU.SHRByte(this.oCPU.CX.High, this.oCPU.CX.Low);
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Word = 0x304;
			this.oCPU.BX.Low = 0x0;

		L0998:
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.High = this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.SI.Word);
			this.oCPU.BX.High = this.oCPU.ANDByte(this.oCPU.BX.High, this.oCPU.CX.High);
			this.oCPU.BX.High = this.oCPU.NEGByte(this.oCPU.BX.High);
			this.oCPU.BX.Word = this.oCPU.ROLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.High = this.oCPU.DECByte(this.oCPU.AX.High);
			if (this.oCPU.Flags.NS) goto L0998;
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.AX.High = 0x0;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0964'");
		}

		public void F0_0000_09af()
		{
			this.oParent.LogEnterBlock("'F0_0000_09af'(Cdecl, Far) at 0x0000:0x09af");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.SI.Word + 0x28ba));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe));
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, 0x7);
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x2a54));

		L09e7:
			this.oCPU.AX.Low = 0x4;
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.AX.Low = this.oCPU.DECByte(this.oCPU.AX.Low);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.BX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.DECByte(this.oCPU.AX.Low);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.BX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.DECByte(this.oCPU.AX.Low);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.DECByte(this.oCPU.AX.Low);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.LODSByte();
			this.oCPU.DX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.High = 0x1;

		L0a07:
			this.oCPU.AX.Low = 0x0;
			this.oCPU.BX.High = this.oCPU.SHLByte(this.oCPU.BX.High, 0x1);
			this.oCPU.AX.Low = this.oCPU.RCLByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.BX.Low = this.oCPU.SHLByte(this.oCPU.BX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.RCLByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DX.High = this.oCPU.SHLByte(this.oCPU.DX.High, 0x1);
			this.oCPU.AX.Low = this.oCPU.RCLByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DX.Low = this.oCPU.SHLByte(this.oCPU.DX.Low, 0x1);
			this.oCPU.AX.Word = this.oCPU.RCLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.STOSByte();
			if (this.oCPU.Flags.AE) goto L0a07;
			if (this.oCPU.Loop(this.oCPU.CX)) goto L09e7;
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_09af'");
		}

		public void F0_0000_0a23(ushort param1, ushort param2, ushort param3, ushort param4, ushort width)
		{
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);

			this.oCPU.SI.Word = param1;
			this.oCPU.DX.Word = param4;
			this.oCPU.DI.Word = (ushort)(this.oCPU.DX.Word * 2);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(0x28ba + this.oCPU.DI.Word));
			this.oCPU.AX.Word = (ushort)(param3 >> 3);
			this.oCPU.DI.Word += this.oCPU.AX.Word;
			this.oCPU.CX.Word = (ushort)((width + 0xf) >> 4);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(0x2a54 + param2 * 2));
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.ES.Word = this.oCPU.CS.Word;
			// LEA
			this.oCPU.DI.Word = 0x820;
			this.oCPU.DX.Word = this.oCPU.ANDWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x962, this.oCPU.DX.Word);
			if (this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a52) == 0x1) goto L0b05;

			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x960, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			if (this.oCPU.ReadByte(this.oCPU.CS.Word, 0x189) != 0x0) goto L0ab9;

		L0a86:
			this.oCPU.BX.Word = 0x0;
			this.oCPU.DX.Word = 0x10;

		L0a8c:
			this.oCPU.LODSByte();
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.BX.Low = this.oCPU.RCLByte(this.oCPU.BX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.BX.High = this.oCPU.RCLByte(this.oCPU.BX.High, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DX.Low = this.oCPU.RCLByte(this.oCPU.DX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DX.High = this.oCPU.RCLByte(this.oCPU.DX.High, 0x1);
			if (this.oCPU.Flags.AE) goto L0a8c;
			this.oCPU.WriteByte(this.oCPU.ES.Word, (ushort)(this.oCPU.DI.Word + 0x28), this.oCPU.BX.High);
			this.oCPU.WriteByte(this.oCPU.ES.Word, (ushort)(this.oCPU.DI.Word + 0x50), this.oCPU.DX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, (ushort)(this.oCPU.DI.Word + 0x78), this.oCPU.DX.High);
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.STOSByte();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0a86;

		L0ab0:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.ES.Word = this.oCPU.PopWord();

			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Word = this.oCPU.CS.Word;
			this.oCPU.DS.Word = this.oCPU.AX.Word;
			// LEA
			this.oCPU.SI.Word = 0x820;
			this.oCPU.BX.Word = this.oCPU.DI.Word;
			this.oCPU.DX.Word = 0x3c4;
			this.oCPU.AX.Low = 0x2;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.AX.Low = 0x1;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x960);
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SUBWord(this.oCPU.BP.Word, this.oCPU.CX.Word);
			this.oCPU.BP.Word = this.oCPU.SHLWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.BX.Word;
			this.oCPU.REPEMOVSWord(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.AX.Low = 0x2;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x960);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.DI.Word = this.oCPU.BX.Word;
			this.oCPU.REPEMOVSWord(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.AX.Low = 0x4;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x960);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.DI.Word = this.oCPU.BX.Word;
			this.oCPU.REPEMOVSWord(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.AX.Low = 0x8;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x960);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.DI.Word = this.oCPU.BX.Word;
			this.oCPU.REPEMOVSWord(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.AX.Low = 0xf;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();

			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			return;

		L0ab9:
			this.oCPU.PushWord(this.oCPU.BP.Word);
			// LEA
			this.oCPU.AX.Word = 0x18a;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x962, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x962), this.oCPU.AX.Word));

		L0ac3:
			this.oCPU.BX.Word = 0x0;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.DX.High = this.oCPU.INCByte(this.oCPU.DX.High);

		L0ac9:
			this.oCPU.LODSByte();
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x962));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x962, this.oCPU.XORWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x962), 0x1));
			this.oCPU.BP.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, (ushort)(this.oCPU.BP.Word + 0x0));
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.BX.Low = this.oCPU.RCLByte(this.oCPU.BX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.BX.High = this.oCPU.RCLByte(this.oCPU.BX.High, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DX.Low = this.oCPU.RCLByte(this.oCPU.DX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DX.High = this.oCPU.RCLByte(this.oCPU.DX.High, 0x1);
			if (this.oCPU.Flags.AE) goto L0ac9;
			this.oCPU.WriteByte(this.oCPU.ES.Word, (ushort)(this.oCPU.DI.Word + 0x28), this.oCPU.BX.High);
			this.oCPU.WriteByte(this.oCPU.ES.Word, (ushort)(this.oCPU.DI.Word + 0x50), this.oCPU.DX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, (ushort)(this.oCPU.DI.Word + 0x78), this.oCPU.DX.High);
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.STOSByte();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0ac3;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			goto L0ab0;

		L0b05:
			// LEA
			this.oCPU.AX.Word = 0x38a;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x962, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x962), this.oCPU.AX.Word));
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x960, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.BP.Word);

		L0b18:
			this.oCPU.BX.Word = 0x0;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.DX.High = this.oCPU.INCByte(this.oCPU.DX.High);

		L0b1e:
			this.oCPU.LODSByte();
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x962));
			this.oCPU.BP.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, (ushort)(this.oCPU.BP.Word + 0x0));
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.BX.Low = this.oCPU.RCLByte(this.oCPU.BX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.BX.High = this.oCPU.RCLByte(this.oCPU.BX.High, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DX.Low = this.oCPU.RCLByte(this.oCPU.DX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DX.High = this.oCPU.RCLByte(this.oCPU.DX.High, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.BX.Low = this.oCPU.RCLByte(this.oCPU.BX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.BX.High = this.oCPU.RCLByte(this.oCPU.BX.High, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DX.Low = this.oCPU.RCLByte(this.oCPU.DX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DX.High = this.oCPU.RCLByte(this.oCPU.DX.High, 0x1);
			if (this.oCPU.Flags.AE) goto L0b1e;
			this.oCPU.WriteByte(this.oCPU.ES.Word, (ushort)(this.oCPU.DI.Word + 0x50), this.oCPU.BX.High);
			this.oCPU.WriteByte(this.oCPU.ES.Word, (ushort)(this.oCPU.DI.Word + 0xa0), this.oCPU.DX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, (ushort)(this.oCPU.DI.Word + 0xf0), this.oCPU.DX.High);
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.STOSByte();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0b18;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			goto L0ab0;
		}

		public void F0_0000_0bca()
		{
			this.oParent.LogEnterBlock("'F0_0000_0bca'(Cdecl, Far) at 0x0000:0x0bca");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			goto L0bca;

		L0bc4:
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();

			if (this.oCPU.Memory.ReadDWord(this.oCPU.SS.Word, this.oCPU.SP.Word) == this.oCPU.WordsToDWord(0xcf1, this.usSegment))
			{
				this.F0_0000_0cf1();
				this.oCPU.PopDWord(); // stack management - pop return offset and segment

				goto L0bc4;
			}

		L0bc6:
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0bca'");
			return;

		L0bc7:
			goto L0cb2;

		L0bca:
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.S) goto L0bc6;
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.G) goto L0bc6;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a64);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x47e, this.oCPU.BX.Word);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x47c, this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x480, 0xffff);
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.CS.Word, 0x2a73), 0xf);
			if (this.oCPU.Flags.A) goto L0bc7;

		L0bfa:
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Low = 0x8;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a72, this.oCPU.AX.Low);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x2a52);
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, 0x2);

		L0c0d:
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x2);
			this.oCPU.CMPWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x47c));
			if (this.oCPU.Flags.A) goto L0bc4;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x190));
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word));
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.BP.Word);
			if (this.oCPU.Flags.B) goto L0c0d;
			if (this.oCPU.Flags.A) goto L0c2f;
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L0c0d;
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6a));
			if (this.oCPU.Flags.E) goto L0c0d;

		L0c2f:
			this.oCPU.CMPByte(this.oCPU.AX.High, 0x1);
			if (this.oCPU.Flags.NE) goto L0c39;
			this.oCPU.BP.Word = this.oCPU.SHLWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);

		L0c39:
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, 0xf);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x45a));
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x480));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x47a, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.BP.Word;
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, 0xf);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x43a));
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x480));
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.BP.Word;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x27a)));
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.BP.Word);
			if (this.oCPU.Flags.E) goto L0c95;
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.BX.High;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.BX.Word = 0xffff;
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x480));
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L0c95;
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.REPESTOSWord();

		L0c95:
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x47a));
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.BX.High;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x480, this.oCPU.RORWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x480), 0x1));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x47e);
			goto L0c0d;

		L0cb2:
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x2a73);
			// LEA
			this.oCPU.DI.Word = 0x482;

		L0cbb:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0d0e;
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			if (this.oCPU.Flags.NE) goto L0cbb;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a73, this.oCPU.AX.High);
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Low = 0x0;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x5555;
			this.oCPU.CX.Word = this.oCPU.SI.Word;
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.RORWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x480, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.RORWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0xcf1);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			goto L0bfa;

		L0d0e:
			goto L0bfa;
		}

		public void F0_0000_0cf1()
		{
			this.oParent.LogEnterBlock("'F0_0000_0cf1'(Cdecl, Far) at 0x0000:0x0cf1");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			goto L0cf1;

		L0bc4:
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0cf1'");
			return;

		L0bfa:
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Low = 0x8;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a72, this.oCPU.AX.Low);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x2a52);
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, 0x2);

		L0c0d:
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x2);
			this.oCPU.CMPWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x47c));
			if (this.oCPU.Flags.A) goto L0bc4;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x190));
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word));
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.BP.Word);
			if (this.oCPU.Flags.B) goto L0c0d;
			if (this.oCPU.Flags.A) goto L0c2f;
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L0c0d;
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6a));
			if (this.oCPU.Flags.E) goto L0c0d;

		L0c2f:
			this.oCPU.CMPByte(this.oCPU.AX.High, 0x1);
			if (this.oCPU.Flags.NE) goto L0c39;
			this.oCPU.BP.Word = this.oCPU.SHLWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);

		L0c39:
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, 0xf);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x45a));
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x480));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x47a, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.BP.Word;
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, 0xf);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x43a));
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x480));
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.BP.Word;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x27a)));
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.BP.Word);
			if (this.oCPU.Flags.E) goto L0c95;
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.BX.High;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.BX.Word = 0xffff;
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x480));
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L0c95;
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.REPESTOSWord();

		L0c95:
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x47a));
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.BX.High;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x480, this.oCPU.RORWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x480), 0x1));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x47e);
			goto L0c0d;

		L0cf1:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x2a73);
			this.oCPU.AX.High = this.oCPU.RORByte(this.oCPU.AX.High, 0x1);
			this.oCPU.AX.High = this.oCPU.RORByte(this.oCPU.AX.High, 0x1);
			this.oCPU.AX.High = this.oCPU.RORByte(this.oCPU.AX.High, 0x1);
			this.oCPU.AX.High = this.oCPU.RORByte(this.oCPU.AX.High, 0x1);
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a73, this.oCPU.AX.High);
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Low = 0x0;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x480, this.oCPU.PopWord());
			goto L0bfa;
		}

		public void F0_0000_0d1f()
		{
			this.oParent.LogEnterBlock("'F0_0000_0d1f'(Cdecl, Far) at 0x0000:0x0d1f");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x2a66, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x2a68, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x2a6a, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x2a54));
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x2a64, this.oCPU.AX.Word);
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0d1f'");
		}

		public void F0_0000_0d36()
		{
			this.oParent.LogEnterBlock("'F0_0000_0d36'(Cdecl, Far) at 0x0000:0x0d36");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x2a54));
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x2a64, this.oCPU.AX.Word);
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0d36'");
		}

		public void F0_0000_0d44()
		{
			this.oParent.LogEnterBlock("'F0_0000_0d44'(Cdecl, Far) at 0x0000:0x0d44");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.High = 0x48;
			this.oCPU.BX.Word = 0xffff;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0d44'");
		}

		public void F0_0000_0d4e()
		{
			this.oParent.LogEnterBlock("'F0_0000_0d4e'(Cdecl, Far) at 0x0000:0x0d4e");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x2a54), this.oCPU.AX.Word);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0d4e'");
		}

		public void F0_0000_0d60()
		{
			this.oParent.LogEnterBlock("'F0_0000_0d60'(Cdecl, Far) at 0x0000:0x0d60");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x2a54));
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0d60'");
		}

		public void F0_0000_0d74()
		{
			this.oParent.LogEnterBlock("'F0_0000_0d74'(Cdecl, Far) at 0x0000:0x0d74");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DX.Word = this.oCPU.AX.Word;
			this.oCPU.DX.Word = this.oCPU.ANDWord(this.oCPU.DX.Word, 0x80);
			this.oCPU.TESTWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.E) goto L0da3;
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, 0xe);
			this.oCPU.BX.Word = 0x400;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x2a52, 0x1);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x2a6e, 0x50);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x2a50, 0x1);
			goto L0dbe;

		L0da3:
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, 0xd);
			this.oCPU.BX.Word = 0x200;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x2a52, 0x0);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x2a6e, 0x28);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x2a50, 0x0);

		L0dbe:
			this.oCPU.PushWord(0x0dc1); // stack management - push return offset
			// Instruction address 0x0000:0x0dbe, size: 3
			F0_0000_0de5();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.INT(0x10);
			this.oCPU.AX.High = 0xf;
			this.oCPU.INT(0x10);
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.DX.Low);
			if (this.oCPU.Flags.NE) goto L0dcf;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0d74'");
			return;

		L0dcf:
			this.oCPU.DX.Word = 0x496;
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.AX.Word = 0x3;
			this.oCPU.INT(0x10);
			this.oCPU.AX.High = 0x9;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Word = 0x4c00;
			this.oCPU.INT(0x21);
		}

		public void F0_0000_0de5()
		{
			this.oParent.LogEnterBlock("'F0_0000_0de5'(Cdecl, Near) at 0x0000:0x0de5");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = 0xa000;
			this.oCPU.DI.Word = 0x2a54;
			this.oCPU.CX.Word = 0x8;

		L0df2:
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0df2;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.DI.Word = 0x28ba;
			this.oCPU.CX.Word = 0xc8;

		L0dff:
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e));
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0dff;
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			// Near return
			this.oParent.LogExitBlock("'F0_0000_0de5'");
		}

		public void F0_0000_0e3c()
		{
			this.oParent.LogEnterBlock("'F0_0000_0e3c'(Cdecl, Far) at 0x0000:0x0e3c");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a64);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a52), 0x1);
			if (this.oCPU.Flags.NE) goto L0e52;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);

		L0e52:
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a66));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4c4, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a68));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4c6, this.oCPU.BX.Word);
			this.oCPU.PushWord(0x0e66); // stack management - push return offset
			// Instruction address 0x0000:0x0e63, size: 3
			F0_0000_0e6e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0e3c'");
		}

		public void F0_0000_0e6e()
		{
			this.oParent.LogEnterBlock("'F0_0000_0e6e'(Cdecl, Near) at 0x0000:0x0e6e");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4c4);
			this.oCPU.DI.Word = this.oCPU.BX.Word;
			this.oCPU.DI.Word = this.oCPU.SHRWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.SHRWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.SHRWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4c6);
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x27a)));
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Low = 0x8;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, 0x7);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4bc));
			// Near return
			this.oParent.LogExitBlock("'F0_0000_0e6e'");
		}

		public void F0_0000_0e94()
		{
			this.oParent.LogEnterBlock("'F0_0000_0e94'(Cdecl, Far) at 0x0000:0x0e94");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			goto L0e94;

		L0e63:
			this.oCPU.PushWord(0x0e66); // stack management - push return offset
			// Instruction address 0x0000:0x0e63, size: 3
			F0_0000_0e6e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0e94'");
			return;

		L0e94:
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a64);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a66);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a68);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.DI.Word);
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.DI.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.BE) goto L0eb9;
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Word = this.oCPU.Temp.Word;
			this.oCPU.Temp.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;

		L0eb9:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a52), 0x1);
			if (this.oCPU.Flags.NE) goto L0ec6;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);

		L0ec6:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4c4, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4c6, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4c8, this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4ca, this.oCPU.DX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.NE) goto L0edd;
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L0e63;

		L0edd:
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e);
			this.oCPU.BP.Word = this.oCPU.DECWord(this.oCPU.BP.Word);
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4cc, this.oCPU.CX.Word);
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.NS) goto L0ef4;
			this.oCPU.BP.Word = this.oCPU.NEGWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SUBWord(this.oCPU.BP.Word, 0x2);
			this.oCPU.DX.Word = this.oCPU.NEGWord(this.oCPU.DX.Word);

		L0ef4:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4ce, this.oCPU.DX.Word);
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L0f4a;
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L0f47;
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L0f77;
			if (this.oCPU.Flags.B) goto L0f4d;
			this.oCPU.PushWord(0x0f09); // stack management - push return offset
			// Instruction address 0x0000:0x0f06, size: 3
			F0_0000_0e6e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4cc);
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.NEGWord(this.oCPU.BX.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4ce);
			this.oCPU.AX.High = this.oCPU.AX.Low;
			goto L0f2b;

		L0f1c:
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4cc));
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.AX.High = this.oCPU.RORByte(this.oCPU.AX.High, 0x1);
			this.oCPU.DI.Word = this.oCPU.ADCWord(this.oCPU.DI.Word, this.oCPU.BP.Word);

		L0f29:
			this.oCPU.AX.Low = this.oCPU.AX.High;

		L0f2b:
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.High);
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			if (this.oCPU.Flags.S) goto L0f3f;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.NS) goto L0f1c;
			this.oCPU.AX.High = this.oCPU.RORByte(this.oCPU.AX.High, 0x1);
			if (this.oCPU.Flags.AE) goto L0f2b;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			goto L0f29;

		L0f3f:
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));

		L0f43:
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0e94'");
			return;

		L0f47:
			goto L0f9c;

		L0f4a:
			goto L0f8b;

		L0f4d:
			this.oCPU.PushWord(0x0f50); // stack management - push return offset
			// Instruction address 0x0000:0x0f4d, size: 3
			F0_0000_0e6e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4ce);
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.NEGWord(this.oCPU.BX.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4cc);
			goto L0f63;

		L0f61:
			this.oCPU.DI.Word = this.oCPU.ADCWord(this.oCPU.DI.Word, this.oCPU.BP.Word);

		L0f63:
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			if (this.oCPU.Flags.S) goto L0f43;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.S) goto L0f61;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4ce));
			this.oCPU.AX.Low = this.oCPU.RORByte(this.oCPU.AX.Low, 0x1);
			goto L0f61;

		L0f77:
			this.oCPU.PushWord(0x0f7a); // stack management - push return offset
			// Instruction address 0x0000:0x0f77, size: 3
			F0_0000_0e6e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.BP.Word = this.oCPU.INCWord(this.oCPU.BP.Word);

		L0f7c:
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BP.Word);
			this.oCPU.AX.Low = this.oCPU.RORByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DI.Word = this.oCPU.ADCWord(this.oCPU.DI.Word, 0x0);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0f7c;
			goto L0f43;

		L0f8b:
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.BP.Word = this.oCPU.INCWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(0x0f92); // stack management - push return offset
			// Instruction address 0x0000:0x0f8f, size: 3
			F0_0000_0e6e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);

		L0f93:
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BP.Word);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0f93;
			goto L0f43;

		L0f9c:
			this.oCPU.PushWord(0x0f9f); // stack management - push return offset
			// Instruction address 0x0000:0x0f9c, size: 3
			F0_0000_0e6e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4c4);
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4c8);
			this.oCPU.CX.Word = this.oCPU.BX.Word;
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0x7);
			this.oCPU.AX.Low = 0xff;
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.BP.Word;
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0x7);
			this.oCPU.AX.High = 0x80;
			this.oCPU.AX.High = this.oCPU.SARByte(this.oCPU.AX.High, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SUBWord(this.oCPU.BP.Word, this.oCPU.BX.Word);
			this.oCPU.CX.Word = this.oCPU.BP.Word;
			if (this.oCPU.CX.Word == 0) goto L0fde;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.AX.Low = 0xff;
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L0fde;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);

		L0fd8:
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0fd8;

		L0fde:
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, this.oCPU.AX.High);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			goto L0f43;
		}

		public void F0_0000_0fe8()
		{
			this.oParent.LogEnterBlock("'F0_0000_0fe8'(Cdecl, Far) at 0x0000:0x0fe8");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.PushWord(0x0ff1); // stack management - push return offset
			// Instruction address 0x0000:0x0fee, size: 3
			F0_0000_0665();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = this.oCPU.BP.Word;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0ff8); // stack management - push return offset
			// Instruction address 0x0000:0x0ff5, size: 3
			F0_0000_078e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.BP.Word = this.oCPU.SHLWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BP.Word + 0x2a54));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Low = 0xc;
			this.oCPU.DX.Word = 0x3d4;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0fe8'");
		}

		public void F0_0000_105e()
		{
			this.oParent.LogEnterBlock("'F0_0000_105e'(Cdecl, Far) at 0x0000:0x105e");
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

		L106e:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.ES.Word, 0x440), this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L106e;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.SI.Word + 0x2a54));
			if (this.oCPU.Flags.E) goto L10f0;
			this.oCPU.DX.Word = 0x3d4;
			this.oCPU.AX.Low = 0xc;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.AX.High = 0x0;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a54));
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.E) goto L10f0;
			this.oCPU.DS.Word = this.oCPU.SI.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x105a), 0x0);
			if (this.oCPU.Flags.NE) goto L10a7;
			this.oCPU.PushWord(0x10a7); // stack management - push return offset
			// Instruction address 0x0000:0x10a4, size: 3
			F0_0000_1243();
			this.oCPU.PopWord(); // stack management - pop return offset

		L10a7:
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			if (this.oCPU.CX.Word == 0) goto L10f7;
			this.oCPU.AX.Word = 0x2260;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.NE) goto L10bd;
			this.oCPU.BX.Word = 0x1;

		L10bd:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x105a);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.BE) goto L10f7;
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x105c));
			this.oCPU.CX.Low = 0x4;

		L10cc:
			this.oCPU.CMPWord(this.oCPU.DX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.B) goto L10d8;
			this.oCPU.DX.Word = this.oCPU.SHRWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.RCRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Low = this.oCPU.DECByte(this.oCPU.CX.Low);
			goto L10cc;

		L10d8:
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Low = this.oCPU.ORByte(this.oCPU.CX.Low, this.oCPU.CX.Low);
			if (this.oCPU.Flags.S) goto L10e8;
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ADCWord(this.oCPU.BX.Word, 0x1);
			goto L10f9;

		L10e8:
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x1);
			goto L10f9;

		L10f0:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_105e'");
			return;

		L10f7:
			this.oCPU.BX.Word = 0x0;

		L10f9:
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x10f5, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.NE) goto L1105;
			goto L11b3;

		L1105:
			this.oCPU.BP.Word = 0x1;
			this.oCPU.CX.Word = 0xfa00;
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Word = 0x205;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a78, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L1117:
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			if (this.oCPU.Flags.AE) goto L111f;
			this.oCPU.BP.Word = this.oCPU.XORWord(this.oCPU.BP.Word, 0xb400);

		L111f:
			this.oCPU.CMPWord(this.oCPU.BP.Word, 0xfa00);
			if (this.oCPU.Flags.A) goto L1117;
			this.oCPU.SI.Word = this.oCPU.BP.Word;
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.SI.Word;
			this.oCPU.DI.Word = this.oCPU.ANDWord(this.oCPU.DI.Word, 0x7);
			this.oCPU.SI.Word = this.oCPU.SHRWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.SHRWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.SHRWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, (ushort)(this.oCPU.DI.Word + 0x104c));
			this.oCPU.AX.Low = 0x8;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0xff;
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Low = 0x0;
			this.oCPU.AX.Word = 0x304;

		L1146:
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.DI.Word);
			this.oCPU.BX.High = this.oCPU.NEGByte(this.oCPU.BX.High);
			this.oCPU.BX.Word = this.oCPU.ROLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.High = this.oCPU.DECByte(this.oCPU.AX.High);
			if (this.oCPU.Flags.NS) goto L1146;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.SI.Word);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.SI.Word, this.oCPU.BX.Low);
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a52), 0x1);
			if (this.oCPU.Flags.NE) goto L118f;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, (ushort)(this.oCPU.DI.Word + 0x104c));
			this.oCPU.AX.Low = 0x8;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0xff;
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Low = 0x0;
			this.oCPU.AX.Word = 0x304;

		L1175:
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1f40));
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.DI.Word);
			this.oCPU.BX.High = this.oCPU.NEGByte(this.oCPU.BX.High);
			this.oCPU.BX.Word = this.oCPU.ROLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.High = this.oCPU.DECByte(this.oCPU.AX.High);
			if (this.oCPU.Flags.NS) goto L1175;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x1f40));
			this.oCPU.WriteByte(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x1f40), this.oCPU.BX.Low);

		L118f:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x10f5);

		L1193:
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1193;
			if (this.oCPU.Loop(this.oCPU.CX)) goto L119b;
			goto L119e;

		L119b:
			goto L1117;

		L119e:
			this.oCPU.AX.Word = 0x5;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a78, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xff08;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a71, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			goto L10f0;

		L11b3:
			this.oCPU.DI.Word = 0x1;
			this.oCPU.CX.Word = 0x3e80;
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Word = 0x5;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a78, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L11c5:
			this.oCPU.DI.Word = this.oCPU.SHRWord(this.oCPU.DI.Word, 0x1);
			if (this.oCPU.Flags.AE) goto L11cd;
			this.oCPU.DI.Word = this.oCPU.XORWord(this.oCPU.DI.Word, 0x3500);

		L11cd:
			this.oCPU.CMPWord(this.oCPU.DI.Word, 0x3e80);
			if (this.oCPU.Flags.A) goto L11c5;
			this.oCPU.SI.Word = this.oCPU.DI.Word;
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.SHRWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x1058));
			this.oCPU.BX.Low = 0x3;
			this.oCPU.BX.High = 0x8;
			this.oCPU.DX.Low = 0xce;
			this.oCPU.AX.Low = 0x8;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L11ec:
			this.oCPU.DX.Low = 0xce;
			this.oCPU.AX.Low = 0x4;
			this.oCPU.AX.High = this.oCPU.BX.Low;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Low = 0xc4;
			this.oCPU.AX.Low = 0x2;
			this.oCPU.AX.High = this.oCPU.BX.High;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.SI.Word);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.SI.Word, this.oCPU.AX.Low);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a52), 0x1);
			if (this.oCPU.Flags.NE) goto L1218;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1f40));
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x1f40));
			this.oCPU.WriteByte(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x1f40), this.oCPU.AX.Low);

		L1218:
			this.oCPU.BX.Low = this.oCPU.DECByte(this.oCPU.BX.Low);
			this.oCPU.BX.High = this.oCPU.SHRByte(this.oCPU.BX.High, 0x1);
			if (this.oCPU.Flags.NE) goto L11ec;
			if (this.oCPU.Loop(this.oCPU.CX)) goto L11c5;
			this.oCPU.DX.Low = 0xce;
			this.oCPU.AX.Word = 0x5;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a78, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xff08;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a71, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Low = 0xc4;
			this.oCPU.AX.Word = 0xf02;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a79, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			goto L10f0;
		}

		public void F0_0000_1243()
		{
			this.oParent.LogEnterBlock("'F0_0000_1243'(Cdecl, Near) at 0x0000:0x1243");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.BX.Word = 0x1;
			this.oCPU.PushWord(0x1249); // stack management - push return offset
			// Instruction address 0x0000:0x1246, size: 3
			F0_0000_1271();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x105a, this.oCPU.CX.Word);
			this.oCPU.BX.Word = 0x11;
			this.oCPU.PushWord(0x1254); // stack management - push return offset
			// Instruction address 0x0000:0x1251, size: 3
			F0_0000_1271();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Low = 0x0;
			this.oCPU.AX.High = this.oCPU.CX.Low;
			this.oCPU.DX.Low = this.oCPU.CX.High;
			this.oCPU.DX.High = 0x0;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x105a);
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.ADCWord(this.oCPU.AX.Word, 0x0);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x105c, this.oCPU.AX.Word);
			// Near return
			this.oParent.LogExitBlock("'F0_0000_1243'");
		}

		public void F0_0000_1271()
		{
			this.oParent.LogEnterBlock("'F0_0000_1271'(Cdecl, Near) at 0x0000:0x1271");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x10f5, this.oCPU.BX.Word);
			this.oCPU.CX.Word = 0x0;
			this.oCPU.BP.Word = 0x1;
			this.oCPU.DX.Word = 0x3da;

		L1280:
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.E) goto L1280;

		L1285:
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.NE) goto L1285;
			this.oCPU.DX.Low = 0xce;
			this.oCPU.AX.Word = 0x205;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a78, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L1295:
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, 0x1);
			if (this.oCPU.Flags.AE) goto L129d;
			this.oCPU.BP.Word = this.oCPU.XORWord(this.oCPU.BP.Word, 0xb400);

		L129d:
			this.oCPU.CMPWord(this.oCPU.BP.Word, 0xfa00);
			if (this.oCPU.Flags.A) goto L1295;
			this.oCPU.SI.Word = this.oCPU.BP.Word;
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.SI.Word;
			this.oCPU.DI.Word = this.oCPU.ANDWord(this.oCPU.DI.Word, 0x7);
			this.oCPU.SI.Word = this.oCPU.SHRWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.SHRWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.SHRWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, (ushort)(this.oCPU.DI.Word + 0x104c));
			this.oCPU.AX.Low = 0x8;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0xff;
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Low = 0x0;
			this.oCPU.AX.Word = 0x304;

		L12c2:
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.DI.Word);
			this.oCPU.BX.High = this.oCPU.NEGByte(this.oCPU.BX.High);
			this.oCPU.BX.Word = this.oCPU.ROLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.High = this.oCPU.DECByte(this.oCPU.AX.High);
			if (this.oCPU.Flags.NS) goto L12c2;
			this.oCPU.SI.Word = 0xffff;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.SI.Word);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.SI.Word, this.oCPU.BX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x10f5);

		L12dc:
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L12dc;
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.DX.Low = 0xda;
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.DX.Low = 0xce;
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.E) goto L1295;
			this.oCPU.AX.Word = 0x5;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a78, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xff08;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a71, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Near return
			this.oParent.LogExitBlock("'F0_0000_1271'");
		}

		public void F0_0000_130a()
		{
			this.oParent.LogEnterBlock("'F0_0000_130a'(Cdecl, Far) at 0x0000:0x130a");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			goto L130a;

		L1307:
			goto L1491;

		L130a:
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x10));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1302, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1304, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4));
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x12)));
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x14)));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe));
			this.oCPU.SI.Word = this.oCPU.ORWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.E) goto L1307;
			this.oCPU.DI.Word = this.oCPU.ORWord(this.oCPU.DI.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.E) goto L1307;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a52), 0x1);
			if (this.oCPU.Flags.NE) goto L1356;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

		L1356:
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4d0, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4d2, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4d4, this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4d6, this.oCPU.DX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4d8, this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4da, this.oCPU.DI.Word);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4d6);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x27a));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4d4);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4d2);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x27a));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4d0);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4d4);
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0x7);
			this.oCPU.BX.Low = 0xff;
			this.oCPU.BX.Low = this.oCPU.SHRByte(this.oCPU.BX.Low, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4d4);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4d8));
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0x7);
			this.oCPU.AX.Word = 0xff80;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.High = this.oCPU.AX.Low;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4d4);
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x7);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4d8));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.High = this.oCPU.AX.Low;
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4da);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4d4);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x7);
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4d0);
			this.oCPU.DX.Low = this.oCPU.ANDByte(this.oCPU.DX.Low, 0x7);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1302);
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.DI.Word + 0x2a54));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1304);
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.DI.Word + 0x2a54));
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x1306, 0x4);
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, this.oCPU.DX.Low);
			this.oCPU.CX.Low = this.oCPU.AX.Low;
			if (this.oCPU.Flags.S) goto L1405;
			if (this.oCPU.Flags.E) goto L1402;
			goto L1496;

		L1402:
			goto L1520;

		L1405:
			this.oCPU.CX.Low = this.oCPU.NEGByte(this.oCPU.CX.Low);

		L1407:
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1306);
			this.oCPU.AX.High = this.oCPU.DECByte(this.oCPU.AX.High);
			if (this.oCPU.Flags.S) goto L1485;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x1306, this.oCPU.AX.High);
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Low = 0x4;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a77, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.Temp.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.Temp.Word;
			this.oCPU.BX.Low = this.oCPU.AX.High;
			this.oCPU.BX.High = this.oCPU.SUBByte(this.oCPU.BX.High, this.oCPU.BX.High);
			this.oCPU.AX.Low = 0x2;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x12fe));
			this.oCPU.Temp.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.Temp.Word;
			this.oCPU.DX.Word = 0x3c4;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a79, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L143b:
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.CX.High = this.oCPU.ORByte(this.oCPU.CX.High, this.oCPU.CX.High);
			if (this.oCPU.Flags.E) goto L1462;
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.DX.Word = this.oCPU.ROLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.DX.Low = this.oCPU.ANDByte(this.oCPU.DX.Low, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.NOTByte(this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word));
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.DX.Low);
			this.oCPU.STOSByte();
			this.oCPU.CX.High = this.oCPU.DECByte(this.oCPU.CX.High);
			if (this.oCPU.Flags.E) goto L1460;

		L1457:
			this.oCPU.LODSWord();
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.ROLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.STOSByte();
			this.oCPU.CX.High = this.oCPU.DECByte(this.oCPU.CX.High);
			if (this.oCPU.Flags.NE) goto L1457;

		L1460:
			this.oCPU.AX.Low = 0xff;

		L1462:
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, this.oCPU.BX.High);
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.DX.Word = this.oCPU.ROLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.DX.Low = this.oCPU.ANDByte(this.oCPU.DX.Low, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.NOTByte(this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word));
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.DX.Low);
			this.oCPU.STOSByte();
			this.oCPU.CX.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.BP.Word = this.oCPU.DECWord(this.oCPU.BP.Word);
			if (this.oCPU.Flags.NE) goto L143b;
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			goto L1407;

		L1485:
			this.oCPU.DX.Word = 0x3c4;
			this.oCPU.AX.Word = 0xf02;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a79, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L1491:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_130a'");
			return;

		L1496:
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);

		L1497:
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1306);
			this.oCPU.AX.High = this.oCPU.DECByte(this.oCPU.AX.High);
			if (this.oCPU.Flags.S) goto L1485;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x1306, this.oCPU.AX.High);
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Low = 0x4;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a77, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.Temp.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.Temp.Word;
			this.oCPU.BX.Low = this.oCPU.AX.High;
			this.oCPU.BX.High = this.oCPU.SUBByte(this.oCPU.BX.High, this.oCPU.BX.High);
			this.oCPU.AX.Low = 0x2;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x12fe));
			this.oCPU.Temp.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.Temp.Word;
			this.oCPU.DX.Word = 0x3c4;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a79, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L14cb:
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.CX.High = this.oCPU.ORByte(this.oCPU.CX.High, this.oCPU.CX.High);
			if (this.oCPU.Flags.E) goto L14f7;
			this.oCPU.DX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.DX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1));
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.DX.Word = this.oCPU.RORWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.DX.High = this.oCPU.ANDByte(this.oCPU.DX.High, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.NOTByte(this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word));
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.DX.High);
			this.oCPU.STOSByte();
			this.oCPU.CX.High = this.oCPU.DECByte(this.oCPU.CX.High);
			if (this.oCPU.Flags.E) goto L14f5;

		L14ea:
			this.oCPU.LODSWord();
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.RORWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Low = this.oCPU.AX.High;
			this.oCPU.STOSByte();
			this.oCPU.CX.High = this.oCPU.DECByte(this.oCPU.CX.High);
			if (this.oCPU.Flags.NE) goto L14ea;

		L14f5:
			this.oCPU.AX.Low = 0xff;

		L14f7:
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, this.oCPU.BX.High);
			this.oCPU.DX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.DX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1));
			this.oCPU.DX.Word = this.oCPU.RORWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.DX.High = this.oCPU.ANDByte(this.oCPU.DX.High, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.NOTByte(this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word));
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.DX.High);
			this.oCPU.STOSByte();
			this.oCPU.CX.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e));
			this.oCPU.BP.Word = this.oCPU.DECWord(this.oCPU.BP.Word);
			if (this.oCPU.Flags.NE) goto L14cb;
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			goto L1497;

		L1520:
			this.oCPU.CX.Low = this.oCPU.CX.High;
			this.oCPU.CX.High = 0x0;
			this.oCPU.CMPWord(this.oCPU.CX.Word, 0x1);
			if (this.oCPU.Flags.LE) goto L155d;
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Word = 0x8;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a71, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L153b:
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.CX.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e));
			this.oCPU.BP.Word = this.oCPU.DECWord(this.oCPU.BP.Word);
			if (this.oCPU.Flags.NE) goto L153b;
			this.oCPU.AX.Word = 0xff08;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a71, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);

		L155d:
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1306);
			this.oCPU.AX.High = this.oCPU.DECByte(this.oCPU.AX.High);
			if (this.oCPU.Flags.NS) goto L1569;
			goto L1485;

		L1569:
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x1306, this.oCPU.AX.High);
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Low = 0x4;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a77, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.Temp.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.Temp.Word;
			this.oCPU.BX.Low = this.oCPU.AX.High;
			this.oCPU.BX.High = this.oCPU.SUBByte(this.oCPU.BX.High, this.oCPU.BX.High);
			this.oCPU.AX.Low = 0x2;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x12fe));
			this.oCPU.Temp.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.Temp.Word;
			this.oCPU.DX.Word = 0x3c4;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x2a79, this.oCPU.AX.High);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L1594:
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.AX.High = this.oCPU.BX.Low;
			this.oCPU.CX.Low = this.oCPU.ORByte(this.oCPU.CX.Low, this.oCPU.CX.Low);
			if (this.oCPU.Flags.E) goto L15b4;
			this.oCPU.CX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.CX.High = this.oCPU.ANDByte(this.oCPU.CX.High, this.oCPU.AX.High);
			this.oCPU.AX.High = this.oCPU.NOTByte(this.oCPU.AX.High);
			this.oCPU.AX.High = this.oCPU.ANDByte(this.oCPU.AX.High, this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word));
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.CX.High);
			this.oCPU.AX.Low = this.oCPU.AX.High;
			this.oCPU.STOSByte();
			this.oCPU.CX.High = this.oCPU.SUBByte(this.oCPU.CX.High, this.oCPU.CX.High);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.CX.Word);
			this.oCPU.AX.High = 0xff;

		L15b4:
			this.oCPU.AX.High = this.oCPU.ANDByte(this.oCPU.AX.High, this.oCPU.BX.High);
			this.oCPU.CX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.CX.High = this.oCPU.ANDByte(this.oCPU.CX.High, this.oCPU.AX.High);
			this.oCPU.AX.High = this.oCPU.NOTByte(this.oCPU.AX.High);
			this.oCPU.AX.High = this.oCPU.ANDByte(this.oCPU.AX.High, this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word));
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.CX.High);
			this.oCPU.AX.Low = this.oCPU.AX.High;
			this.oCPU.STOSByte();
			this.oCPU.CX.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e));
			this.oCPU.BP.Word = this.oCPU.DECWord(this.oCPU.BP.Word);
			if (this.oCPU.Flags.NE) goto L1594;
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			goto L155d;
		}

		public void F0_0000_176a()
		{
			this.oParent.LogEnterBlock("'F0_0000_176a'(Cdecl, Far) at 0x0000:0x176a");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x176f); // stack management - push return offset
			// Instruction address 0x0000:0x176c, size: 3
			F0_0000_0d44();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L177b;
			this.oCPU.AX.High = 0x48;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L177f;

		L177b:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.BX.Word = 0x0;

		L177f:
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15da, 0x0);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15dc, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15de, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15e0, this.oCPU.BX.Word);
			// Far return
			this.oParent.LogExitBlock("'F0_0000_176a'");
		}

		public void F0_0000_1796()
		{
			this.oParent.LogEnterBlock("'F0_0000_1796'(Cdecl, Far) at 0x0000:0x1796");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15de);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15dc);
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.B) goto L17af;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.AX.High = 0x49;
			if (this.oCPU.Flags.E) goto L17ab;
			this.oCPU.AX.High = 0x4a;

		L17ab:
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L17b3;

		L17af:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.ES.Word = this.oCPU.AX.Word;

		L17b3:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15dc, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15e0, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15de, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ES.Word;
			// Far return
			this.oParent.LogExitBlock("'F0_0000_1796'");
		}

		public void F0_0000_17c4()
		{
			this.oParent.LogEnterBlock("'F0_0000_17c4'(Cdecl, Far) at 0x0000:0x17c4");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15e0);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15dc));
			if (this.oCPU.Flags.BE) goto L184d;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1000);
			if (this.oCPU.Flags.B) goto L17da;
			this.oCPU.AX.Word = 0xfff;

		L17da:
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15e2, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			// LES
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15da);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(0x15da + 2));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.STOSWord();
			// LEA
			this.oCPU.CX.Word = 0x1a08;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a52), 0x1);
			if (this.oCPU.Flags.NE) goto L1806;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			// LEA
			this.oCPU.DX.Word = 0x38a;
			// LEA
			this.oCPU.CX.Word = 0x1a87;

		L1806:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.CS.Word, 0x189), 0x0);
			if (this.oCPU.Flags.E) goto L1816;
			// LEA
			this.oCPU.DX.Word = 0x18a;
			// LEA
			this.oCPU.CX.Word = 0x1a3c;

		L1816:
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15ec, this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15ee, this.oCPU.DX.Word);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x7);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15f4, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0x7);
			this.oCPU.AX.Low = 0x80;
			this.oCPU.AX.Low = this.oCPU.SARByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x15f0, this.oCPU.AX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.STOSWord();
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15f2, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15da, this.oCPU.DI.Word);
			this.oCPU.AX.Word = this.oCPU.ES.Word;
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_17c4'");
			return;

		L184d:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15da, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15dc, this.oCPU.AX.Word);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_17c4'");
		}

		public void F0_0000_1859()
		{
			this.oParent.LogEnterBlock("'F0_0000_1859'(Cdecl, Far) at 0x0000:0x1859");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = 0x0;
			this.oCPU.Temp.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15da);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15da, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.Temp.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xf);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15dc));
			this.oCPU.Temp.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15dc);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15dc, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.Temp.Word;
			// Far return
			this.oParent.LogExitBlock("'F0_0000_1859'");
		}

		public void F0_0000_1876()
		{
			this.oParent.LogEnterBlock("'F0_0000_1876'(Cdecl, Far) at 0x0000:0x1876");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			// LES
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15da);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(0x15da + 2));
			this.oCPU.AX.Word = this.oCPU.ES.Word;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L188c;
			goto L1936;

		L188c:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15f4);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15e2));
			if (this.oCPU.Flags.BE) goto L18ae;
			this.oCPU.WriteWord(this.oCPU.ES.Word, 0x2, this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.ES.Word, 0x2)));
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15e0, this.oCPU.AX.Word);
			goto L1936;

		L18ae:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15e4, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15e6, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15e8, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15ee, this.oCPU.XORWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15ee), 0x1));
			this.oCPU.BP.Word = this.oCPU.DI.Word;
			this.oCPU.STOSWord();
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15f4);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15ea, this.oCPU.AX.Word);

		L18ce:
			this.oCPU.PushWord(0x18d3); // stack management - push return offset
			// Instruction address 0x0000:0x18ce, size: 5
			//this.oCPU.Call(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15ec));
			switch (this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15ec))
			{
				case 0x19b8:
					this.F0_0000_19b8();
					break;
				case 0x1a3c:
					this.F0_0000_1a3c();
					break;
				default:
					throw new Exception($"Unknown jump address 0x{this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15ec):x4} in graphics overlay");
			}
			this.oCPU.PopWord(); // stack management - pop return offset
			if (this.oCPU.Flags.E) goto L18df;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15e6, 0x0);
			goto L18fb;

		L18df:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15e8), 0x0);
			if (this.oCPU.Flags.NE) goto L18f6;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15e4, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15e4)));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15ea, this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15ea)));
			if (this.oCPU.Flags.NE) goto L18ce;
			goto L190d;

		L18f6:
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15e6, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15e6)));

		L18fb:
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15e8, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15e8)));
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.STOSWord();
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15ea, this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15ea)));
			if (this.oCPU.Flags.NE) goto L18ce;

		L190d:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15e8);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15e4);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15e6);
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L1927;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.SUBWord(this.oCPU.DI.Word, this.oCPU.CX.Word);

		L1927:
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.BP.Word + 0x0), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.BP.Word + 0x2), this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15da, this.oCPU.DI.Word);
			this.oCPU.AX.Word = this.oCPU.ES.Word;

		L1936:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_1876'");
		}

		public void F0_0000_193a()
		{
			this.oParent.LogEnterBlock("'F0_0000_193a'(Cdecl, Far) at 0x0000:0x193a");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x194a); // stack management - push return offset
			// Instruction address 0x0000:0x1947, size: 3
			F0_0000_17c4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L19af;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15f2), 0x0);
			if (this.oCPU.Flags.E) goto L19af;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15f4), 0x0);
			if (this.oCPU.Flags.E) goto L19af;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.SI.Word + 0x28ba));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x2a54));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a52), 0x1);
			if (this.oCPU.Flags.NE) goto L1982;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

		L1982:
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x7);
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x15f1, this.oCPU.AX.Low);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15ec, 0x19b8);

		L199a:
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x19a0); // stack management - push return offset
			// Instruction address 0x0000:0x199d, size: 3
			F0_0000_1876();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15f2, this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15f2)));
			if (this.oCPU.Flags.NE) goto L199a;

		L19af:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x19b4); // stack management - push return offset
			// Instruction address 0x0000:0x19b1, size: 3
			F0_0000_1859();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_193a'");
		}

		public void F0_0000_19b8()
		{
			this.oParent.LogEnterBlock("'F0_0000_19b8'(Cdecl, Near) at 0x0000:0x19b8");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x15f1);
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Word = 0x304;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.ROLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.High = this.oCPU.AX.Low;
			this.oCPU.AX.Low = 0x2;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.ROLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Low = this.oCPU.AX.Low;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.ROLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CX.High = this.oCPU.AX.Low;
			this.oCPU.AX.Low = 0x0;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.ROLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.DX.Low = this.oCPU.AX.Low;
			this.oCPU.DX.High = this.oCPU.CX.High;
			this.oCPU.Temp.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.Temp.Word;
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15ea), 0x1);
			if (this.oCPU.Flags.NE) goto L19ff;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x15f0);
			this.oCPU.AX.High = this.oCPU.AX.Low;
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Word = this.oCPU.ANDWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L19ff:
			this.oCPU.AX.Low = this.oCPU.DX.High;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.DX.Low);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.BX.High);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.BX.Low);
			// Near return
			this.oParent.LogExitBlock("'F0_0000_19b8'");
		}

		public void F0_0000_1a3c()
		{
			this.oParent.LogEnterBlock("'F0_0000_1a3c'(Cdecl, Near) at 0x0000:0x1a3c");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BX.Word = 0x0;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.DX.High = this.oCPU.INCByte(this.oCPU.DX.High);

		L1a43:
			this.oCPU.LODSByte();
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15ee));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15ee, this.oCPU.XORWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15ee), 0x1));
			this.oCPU.BP.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, (ushort)(this.oCPU.BP.Word + 0x0));
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.BX.Low = this.oCPU.RCLByte(this.oCPU.BX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.BX.High = this.oCPU.RCLByte(this.oCPU.BX.High, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DX.Low = this.oCPU.RCLByte(this.oCPU.DX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DX.High = this.oCPU.RCLByte(this.oCPU.DX.High, 0x1);
			if (this.oCPU.Flags.AE) goto L1a43;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15ea), 0x1);
			if (this.oCPU.Flags.NE) goto L1a7d;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x15f0);
			this.oCPU.AX.High = this.oCPU.AX.Low;
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Word = this.oCPU.ANDWord(this.oCPU.DX.Word, this.oCPU.AX.Word);

		L1a7d:
			this.oCPU.AX.Low = this.oCPU.DX.High;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.DX.Low);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.BX.High);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.BX.Low);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Near return
			this.oParent.LogExitBlock("'F0_0000_1a3c'");
		}

		public void F0_0000_1b2a()
		{
			this.oParent.LogEnterBlock("'F0_0000_1b2a'(Cdecl, Far) at 0x0000:0x1b2a");
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
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15fe, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1600, this.oCPU.AX.Word);
			this.oCPU.PushWord(0x1b4e); // stack management - push return offset
			// Instruction address 0x0000:0x1b4b, size: 3
			F0_0000_1bfe();
			this.oCPU.PopWord(); // stack management - pop return offset
			if (this.oCPU.Flags.E) goto L1b58;
			this.oCPU.PushWord(0x1b53); // stack management - push return offset
			// Instruction address 0x0000:0x1b50, size: 3
			F0_0000_1b63();
			this.oCPU.PopWord(); // stack management - pop return offset
			if (this.oCPU.Flags.B) goto L1b58;
			this.oCPU.PushWord(0x1b58); // stack management - push return offset
			// Instruction address 0x0000:0x1b55, size: 3
			F0_0000_1c54();
			this.oCPU.PopWord(); // stack management - pop return offset

		L1b58:
			// LEA
			this.oCPU.AX.Word = 0x1606;
			this.oCPU.DX.Word = this.oCPU.CS.Word;
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_1b2a'");
		}

		public void F0_0000_1b63()
		{
			this.oParent.LogEnterBlock("'F0_0000_1b63'(Cdecl, Near) at 0x0000:0x1b63");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.DI.Word = this.oCPU.ORWord(this.oCPU.DI.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.NS) goto L1b76;
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1600));
			if (this.oCPU.Flags.AE) goto L1bc2;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x160e, this.oCPU.AX.Word);

		L1b76:
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1600));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.S) goto L1bc2;
			this.oCPU.CMPWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.G) goto L1bc2;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.LE) goto L1b91;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1612, this.oCPU.AX.Word);

		L1b91:
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NS) goto L1ba4;
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15fe));
			if (this.oCPU.Flags.AE) goto L1bc2;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1610, this.oCPU.AX.Word);

		L1ba4:
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15fe));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.S) goto L1bc2;
			this.oCPU.CMPWord(this.oCPU.DX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.G) goto L1bc2;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.LE) goto L1bc4;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1614, this.oCPU.AX.Word);
			goto L1bc4;

		L1bc2:
			this.oCPU.Flags.C = true;
			// Near return
			this.oParent.LogExitBlock("'F0_0000_1b63'");
			return;

		L1bc4:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1610);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1606, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x160e);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1608, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15fe);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1610));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1614));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x160a, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1600);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x160e));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1612));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x160c, this.oCPU.AX.Word);
			this.oCPU.Flags.C = false;
			// Near return
			this.oParent.LogExitBlock("'F0_0000_1b63'");
		}

		public void F0_0000_1bfe()
		{
			this.oParent.LogEnterBlock("'F0_0000_1bfe'(Cdecl, Near) at 0x0000:0x1bfe");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x160e, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1610, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1612, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1614, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1606, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1608, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x160a, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x160c, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1c32;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x0);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1c32;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);

		L1c32:
			// Near return
			this.oParent.LogExitBlock("'F0_0000_1bfe'");
		}

		public void F0_0000_1c33()
		{
			this.oParent.LogEnterBlock("'F0_0000_1c33'(Cdecl, Far) at 0x0000:0x1c33");
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
			this.oCPU.PushWord(0x1c4a); // stack management - push return offset
			// Instruction address 0x0000:0x1c47, size: 3
			F0_0000_1bfe();
			this.oCPU.PopWord(); // stack management - pop return offset
			if (this.oCPU.Flags.E) goto L1c4f;
			this.oCPU.PushWord(0x1c4f); // stack management - push return offset
			// Instruction address 0x0000:0x1c4c, size: 3
			F0_0000_1c54();
			this.oCPU.PopWord(); // stack management - pop return offset

		L1c4f:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_1c33'");
		}

		public void F0_0000_1c54()
		{
			this.oParent.LogEnterBlock("'F0_0000_1c54'(Cdecl, Near) at 0x0000:0x1c54");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x0));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x2a54));
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x2)));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x4)));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x160e));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.DI.Word + 0x28ba));
			this.oCPU.LODSWord();
			this.oCPU.BP.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a52), 0x1);
			if (this.oCPU.Flags.NE) goto L1c8b;
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SHLWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1610, this.oCPU.SHLWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1610), 0x1));
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1614, this.oCPU.SHLWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1614), 0x1));

		L1c8b:
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, 0x7);
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x1627, this.oCPU.CX.Low);
			this.oCPU.AX.Low = 0xff;
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x1622, this.oCPU.AX.Low);
			this.oCPU.BX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ORByte(this.oCPU.CX.Low, this.oCPU.CX.Low);
			if (this.oCPU.Flags.E) goto L1ca6;
			this.oCPU.AX.Low = this.oCPU.NOTByte(this.oCPU.AX.Low);
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);

		L1ca6:
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x1623, this.oCPU.AX.Low);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1620, this.oCPU.BX.Word);
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1610));
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, 0x7);
			this.oCPU.AX.Low = 0xff;
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x1625, this.oCPU.AX.Low);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.BP.Word);
			this.oCPU.DX.Word = this.oCPU.DECWord(this.oCPU.DX.Word);
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1614));
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0x7);
			this.oCPU.AX.Low = 0x80;
			this.oCPU.AX.Low = this.oCPU.SARByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x1626, this.oCPU.AX.Low);
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15f8, this.oCPU.AX.Word);
			this.oCPU.LODSWord();
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x160e));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1612));
			if (this.oCPU.Flags.G) goto L1cff;
			goto L1dcd;

		L1cff:
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x15f6, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x160e);
			if (this.oCPU.CX.Word == 0) goto L1d16;

		L1d0a:
			this.oCPU.LODSWord();
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L1d0a;

		L1d16:
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1627);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1610));
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x1610, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1627);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x4);
			if (this.oCPU.Flags.BE) goto L1d35;
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, 0x8);

		L1d35:
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x1627, this.oCPU.AX.Low);

		L1d39:
			this.oCPU.LODSWord();
			this.oCPU.DX.Word = this.oCPU.AX.Word;
			this.oCPU.LODSWord();
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L1dbe;
			this.oCPU.BP.Word = this.oCPU.DX.Word;
			this.oCPU.BP.Word = this.oCPU.SHLWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.SHLWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BP.Word = this.oCPU.ADDWord(this.oCPU.BP.Word, this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.BX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1625);
			this.oCPU.BX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1626);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x15f8);
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1620));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1610));
			if (this.oCPU.Flags.E) goto L1d85;
			if (this.oCPU.Flags.B) goto L1d76;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L1dbc;
			this.oCPU.BX.High = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1622);
			goto L1d8a;

		L1d76:
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L1dbc;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			goto L1d8a;

		L1d85:
			this.oCPU.BX.High = this.oCPU.ANDByte(this.oCPU.BX.High, this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1622));

		L1d8a:
			this.oCPU.CMPWord(this.oCPU.DX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L1d9a;
			if (this.oCPU.Flags.A) goto L1d9f;
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.BX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1623);
			goto L1d9f;

		L1d9a:
			this.oCPU.BX.Low = this.oCPU.ANDByte(this.oCPU.BX.Low, this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1623));

		L1d9f:
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x1624, this.oCPU.BX.Low);
			this.oCPU.BX.Low = this.oCPU.CX.Low;
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, 0x4);
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1627), 0x0);
			if (this.oCPU.Flags.E) goto L1db6;
			if (this.oCPU.Flags.S) goto L1dde;
			goto L1e4c;

		L1db6:
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x4);
			goto L1eba;

		L1dbc:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();

		L1dbe:
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e));
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x15f6, this.oCPU.DECByte(this.oCPU.ReadByte(this.oCPU.CS.Word, 0x15f6)));
			if (this.oCPU.Flags.E) goto L1dcd;
			goto L1d39;

		L1dcd:
			this.oCPU.DX.Word = 0x3c4;
			this.oCPU.AX.Word = 0xf02;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.AX.Word = 0xff08;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Near return
			this.oParent.LogExitBlock("'F0_0000_1c54'");
			return;

		L1dde:
			this.oCPU.Temp.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1627);
			this.oCPU.CX.Low = this.oCPU.NEGByte(this.oCPU.CX.Low);
			this.oCPU.LODSWord();
			this.oCPU.DX.Word = this.oCPU.AX.Word;
			this.oCPU.LODSWord();
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.LODSWord();
			this.oCPU.Temp.Low = this.oCPU.AX.High;
			this.oCPU.AX.High = this.oCPU.DX.Low;
			this.oCPU.DX.Low = this.oCPU.Temp.Low;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.DX.Low = this.oCPU.AX.High;
			this.oCPU.LODSWord();
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, 0x4);
			this.oCPU.Temp.Low = this.oCPU.AX.High;
			this.oCPU.AX.High = this.oCPU.BX.Low;
			this.oCPU.BX.Low = this.oCPU.Temp.Low;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Low = this.oCPU.AX.High;
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.BX.High);
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.DX.Low);
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.DX.High);
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.Temp.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.Temp.Word;
			this.oCPU.CMPByte(this.oCPU.BX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L1e42;

		L1e11:
			this.oCPU.AX.High = this.oCPU.ANDByte(this.oCPU.AX.High, this.oCPU.BX.High);
			if (this.oCPU.Flags.E) goto L1e49;
			this.oCPU.AX.Low = 0x8;
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Low = 0xc4;
			this.oCPU.AX.Word = 0x102;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.Temp.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Low = this.oCPU.Temp.Low;
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.CX.High);
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.CX.Word = this.oCPU.BP.Word;
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.CX.High;
			this.oCPU.STOSByte();

		L1e39:
			this.oCPU.BX.High = 0xff;
			this.oCPU.BX.Low = this.oCPU.DECByte(this.oCPU.BX.Low);
			if (this.oCPU.Flags.NE) goto L1dde;
			goto L1dbc;

		L1e42:
			this.oCPU.BX.High = this.oCPU.ANDByte(this.oCPU.BX.High, this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1624));
			goto L1e11;

		L1e49:
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			goto L1e39;

		L1e4c:
			this.oCPU.Temp.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1627);
			this.oCPU.LODSWord();
			this.oCPU.DX.Word = this.oCPU.AX.Word;
			this.oCPU.LODSWord();
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.LODSWord();
			this.oCPU.Temp.Low = this.oCPU.AX.High;
			this.oCPU.AX.High = this.oCPU.DX.Low;
			this.oCPU.DX.Low = this.oCPU.Temp.Low;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.DX.Word = this.oCPU.SHRWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.DX.High = this.oCPU.AX.Low;
			this.oCPU.LODSWord();
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, 0x4);
			this.oCPU.Temp.Low = this.oCPU.AX.High;
			this.oCPU.AX.High = this.oCPU.BX.Low;
			this.oCPU.BX.Low = this.oCPU.Temp.Low;
			this.oCPU.AX.Word = this.oCPU.RORWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.RORWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.High = this.oCPU.AX.Low;
			this.oCPU.AX.High = this.oCPU.BX.Low;
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.BX.High);
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.DX.Low);
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.DX.High);
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.Temp.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.Temp.Word;
			this.oCPU.CMPByte(this.oCPU.BX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L1eb0;

		L1e7f:
			this.oCPU.AX.High = this.oCPU.ANDByte(this.oCPU.AX.High, this.oCPU.BX.High);
			if (this.oCPU.Flags.E) goto L1eb7;
			this.oCPU.AX.Low = 0x8;
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Low = 0xc4;
			this.oCPU.AX.Word = 0x102;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.Temp.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.CX.High);
			this.oCPU.CX.High = this.oCPU.Temp.Low;
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.CX.Word = this.oCPU.BP.Word;
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.CX.High);
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.CX.Low;
			this.oCPU.STOSByte();

		L1ea7:
			this.oCPU.BX.High = 0xff;
			this.oCPU.BX.Low = this.oCPU.DECByte(this.oCPU.BX.Low);
			if (this.oCPU.Flags.NE) goto L1e4c;
			goto L1dbc;

		L1eb0:
			this.oCPU.BX.High = this.oCPU.ANDByte(this.oCPU.BX.High, this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1624));
			goto L1e7f;

		L1eb7:
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			goto L1ea7;

		L1eba:
			this.oCPU.LODSWord();
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.LODSWord();
			this.oCPU.BP.Word = this.oCPU.AX.Word;
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.AX.Low);
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.CX.Low);
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.CX.High);
			this.oCPU.CMPByte(this.oCPU.BX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L1efc;

		L1ecb:
			this.oCPU.AX.High = this.oCPU.ANDByte(this.oCPU.AX.High, this.oCPU.BX.High);
			if (this.oCPU.Flags.E) goto L1f03;
			this.oCPU.AX.Low = 0x8;
			this.oCPU.DX.Word = 0x3ce;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Low = 0xc4;
			this.oCPU.AX.Word = 0x102;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.Temp.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Low = this.oCPU.Temp.Low;
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.CX.High);
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.CX.Word = this.oCPU.BP.Word;
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.CX.High;
			this.oCPU.STOSByte();

		L1ef3:
			this.oCPU.BX.High = 0xff;
			this.oCPU.BX.Low = this.oCPU.DECByte(this.oCPU.BX.Low);
			if (this.oCPU.Flags.NE) goto L1eba;
			goto L1dbc;

		L1efc:
			this.oCPU.BX.High = this.oCPU.ANDByte(this.oCPU.BX.High, this.oCPU.ReadByte(this.oCPU.CS.Word, 0x1624));
			goto L1ecb;

		L1f03:
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			goto L1ef3;
		}

		public void F0_0000_21bb()
		{
			this.oParent.LogEnterBlock("'F0_0000_21bb'(Cdecl, Far) at 0x0000:0x21bb");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.DX.Word = 0x3da;
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x21ac);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x21ac));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x21ac, this.oCPU.AX.Word);
			this.oCPU.DX.Word = 0x3c0;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.CS.Word, 0x21ae), 0x0);
			if (this.oCPU.Flags.E) goto L21f0;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0x21ae, this.oCPU.DECByte(this.oCPU.ReadByte(this.oCPU.CS.Word, 0x21ae)));
			if (this.oCPU.Flags.NE) goto L21e8;
			this.oCPU.BX.Low = 0x0;

		L21e8:
			this.oCPU.AX.Low = 0x13;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x7);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);

		L21f0:
			this.oCPU.AX.Low = 0x20;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Word = 0x3da;
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			// Far return
			this.oParent.LogExitBlock("'F0_0000_21bb'");
		}

		public void F0_0000_221c()
		{
			this.oParent.LogEnterBlock("'F0_0000_221c'(Cdecl, Near) at 0x0000:0x221c");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			goto L221c;

		L21fa:
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x7f);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4e8);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4e4, this.oCPU.AX.Low);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x2208); // stack management - push return offset
			// Instruction address 0x0000:0x2205, size: 3
			F0_0000_058c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			goto L226a;

		L220b:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x2210); // stack management - push return offset
			// Instruction address 0x0000:0x220d, size: 3
			F0_0000_05b9();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4e4);
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc), this.oCPU.AX.Low);
			// Near return
			this.oParent.LogExitBlock("'F0_0000_221c'");
			return;

		L2218:
			goto L220b;

		L221a:
			goto L21fa;

		L221c:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4e4, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4e8, this.oCPU.AX.High);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x222b); // stack management - push return offset
			// Instruction address 0x0000:0x2228, size: 3
			F0_0000_058c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4e5, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4e6, this.oCPU.AX.Low);
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4ee);
			this.oCPU.BX.Word = this.oCPU.ES.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(this.oCPU.BX.Word + 0x2a54));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f2);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x27a));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4e2, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e);
			this.oCPU.MULByte(this.oCPU.AX, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4fb));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4de, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4ee);
			this.oCPU.MULByte(this.oCPU.AX, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4fb));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4e0, this.oCPU.AX.Word);
			this.oCPU.DX.Word = 0x3ce;

		L226a:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L2218;
			if (this.oCPU.Flags.S) goto L221a;
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f8));
			if (this.oCPU.Flags.A) goto L226a;
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f7));
			if (this.oCPU.Flags.B) goto L226a;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ANDWord(this.oCPU.SI.Word, 0xff);
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f4);
			this.oCPU.CX.Low = this.oCPU.ORByte(this.oCPU.CX.Low, this.oCPU.CX.Low);
			if (this.oCPU.Flags.NE) goto L2299;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4ec);
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word));
			this.oCPU.CX.Low = this.oCPU.ADDByte(this.oCPU.CX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f5));

		L2299:
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.AX.High);
			if (this.oCPU.Flags.NE) goto L22a1;
			this.oCPU.CX.Low = this.oCPU.SUBByte(this.oCPU.CX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4fa));

		L22a1:
			this.oCPU.CX.Low = this.oCPU.SUBByte(this.oCPU.CX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f9));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4e9, this.oCPU.CX.Low);
			this.oCPU.CX.Low = this.oCPU.DECByte(this.oCPU.CX.Low);
			this.oCPU.BX.Word = 0x8000;
			this.oCPU.BX.Word = this.oCPU.SARWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4dc, this.oCPU.BX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f0);
			this.oCPU.CX.Low = this.oCPU.AX.Low;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4e2);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0x7);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Low = this.oCPU.SUBByte(this.oCPU.CX.Low, 0x8);
			this.oCPU.CX.Low = this.oCPU.NEGByte(this.oCPU.CX.Low);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4e7, this.oCPU.CX.Low);
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f6);
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4ea));

		L22dd:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4e6), 0x0);
			if (this.oCPU.Flags.E) goto L2305;
			this.oCPU.AX.Low = 0x0;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4e5);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x8;
			this.oCPU.AX.High = this.oCPU.BX.High;
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4fb);
			this.oCPU.CX.High = 0x0;

		L22f7:
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e));
			if (this.oCPU.Loop(this.oCPU.CX)) goto L22f7;
			this.oCPU.DI.Word = this.oCPU.SUBWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4de));

		L2305:
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4e4);
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			this.oCPU.OUTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x8;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4e7);
			this.oCPU.CX.Low = this.oCPU.ADDByte(this.oCPU.CX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f9));
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0xf);
			this.oCPU.CX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4fb);

		L231f:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.Temp.Low = this.oCPU.AX.Low;
			this.oCPU.AX.Low = this.oCPU.AX.High;
			this.oCPU.AX.High = this.oCPU.Temp.Low;
			this.oCPU.AX.Word = this.oCPU.ROLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, this.oCPU.BX.High);
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.ES.Word, this.oCPU.DI.Word, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word)));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6e));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.CX.High = this.oCPU.DECByte(this.oCPU.CX.High);
			if (this.oCPU.Flags.NE) goto L231f;
			this.oCPU.DX.Word = this.oCPU.DECWord(this.oCPU.DX.Word);
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.SUBWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4de));
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4e0));
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4e7);
			this.oCPU.CMPByte(this.oCPU.CX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4e9));
			if (this.oCPU.Flags.AE) goto L2358;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4dc);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4e7, this.oCPU.ADDByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4e7), 0x8));
			goto L22dd;

		L2358:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.AX.High = 0x0;
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4f9, this.oCPU.AX.High);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4e9);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4f0, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f0), this.oCPU.AX.Word));
			goto L226a;
		}

		public void F0_0000_23df()
		{
			this.oParent.LogEnterBlock("'F0_0000_23df'(Cdecl, Far) at 0x0000:0x23df");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.CX.Low = this.oCPU.ORByte(this.oCPU.CX.Low, this.oCPU.CX.Low);
			if (this.oCPU.Flags.S) goto L242a;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x500));
			if (this.oCPU.Flags.A) goto L242a;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L242a;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x500));
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x500);
			this.oCPU.CMPByte(this.oCPU.CX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x8)));
			if (this.oCPU.Flags.B) goto L242a;
			this.oCPU.CMPByte(this.oCPU.CX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x7)));
			if (this.oCPU.Flags.A) goto L242a;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x3));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x5));
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L242a;
			this.oCPU.AX.Low = this.oCPU.CX.Low;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x7));
			this.oCPU.CX.Low = this.oCPU.SUBByte(this.oCPU.CX.Low, this.oCPU.AX.Low);
			this.oCPU.CX.High = 0x0;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0xfff7);
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word);

		L242a:
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.AX.High);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_23df'");
		}

		public void F0_0000_2430()
		{
			this.oParent.LogEnterBlock("'F0_0000_2430'(Cdecl, Far) at 0x0000:0x2430");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x500));
			if (this.oCPU.Flags.A) goto L2456;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L2456;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x500));
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x500);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x4));
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x2)));

		L2456:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_2430'");
		}

		public void F0_0000_2459()
		{
			this.oParent.LogEnterBlock("'F0_0000_2459'(Cdecl, Far) at 0x0000:0x2459");
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
			this.oCPU.PushWord(0x246e); // stack management - push return offset
			// Instruction address 0x0000:0x246b, size: 3
			F0_0000_2472();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_2459'");
		}

		public void F0_0000_2472()
		{
			this.oParent.LogEnterBlock("'F0_0000_2472'(Cdecl, Far) at 0x0000:0x2472");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(0x2475); // stack management - push return offset
			// Instruction address 0x0000:0x2472, size: 3
			F0_0000_25aa();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.PushWord(0x2478); // stack management - push return offset
			// Instruction address 0x0000:0x2475, size: 3
			F0_0000_24de();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.PushWord(0x247b); // stack management - push return offset
			// Instruction address 0x0000:0x2478, size: 3
			F0_0000_248a();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.PushWord(0x247e); // stack management - push return offset
			// Instruction address 0x0000:0x247b, size: 3
			F0_0000_2540();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x2));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4f0, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f0), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x4));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4f2, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f2), this.oCPU.AX.Word));
			this.oCPU.SI.Word = this.oCPU.BX.Word;
			this.oCPU.PushWord(0x2593); // stack management - push return offset
			// Instruction address 0x0000:0x2590, size: 3
			F0_0000_221c();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4fe);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L25a1;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4fd);
			this.oCPU.WriteByte(this.oCPU.SS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);

		L25a1:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f0);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x2)));
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_2472'");
		}

		public void F0_0000_248a()
		{
			this.oParent.LogEnterBlock("'F0_0000_248a'(Cdecl, Near, Far) at 0x0000:0x248a");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.CX.Word = 0x0;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), this.oCPU.CX.Word);
			if (this.oCPU.Flags.S) goto L24d1;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f0), this.oCPU.CX.Word);
			if (this.oCPU.Flags.NS) goto L24d0;
			this.oCPU.Temp.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f0);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4f0, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.Temp.Word;
			this.oCPU.AX.High = 0x0;
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);

		L249e:
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, this.oCPU.BX.Word);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L24d1;
			if (this.oCPU.Flags.S) goto L249e;
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f8));
			if (this.oCPU.Flags.A) goto L249e;
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f7));
			if (this.oCPU.Flags.B) goto L249e;
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f4);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L24c7;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4ec));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f5));

		L24c7:
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L249e;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4f9, this.oCPU.AX.Low);

		L24d0:
			// Near return
			this.oParent.LogExitBlock("'F0_0000_248a'");
			return;

		L24d1:
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4fe);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L25a1;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4fd);
			this.oCPU.WriteByte(this.oCPU.SS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);

		L25a1:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f0);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x2)));
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_248a'");
		}

		public void F0_0000_24de()
		{
			this.oParent.LogEnterBlock("'F0_0000_24de'(Cdecl, Near, Far) at 0x0000:0x24de");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.S) goto L2533;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f0));
			if (this.oCPU.Flags.L) goto L2533;
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.AX.High = 0x0;
			this.oCPU.SI.Word = this.oCPU.BX.Word;
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);

		L24f1:
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L2532;
			if (this.oCPU.Flags.S) goto L24f1;
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f8));
			if (this.oCPU.Flags.A) goto L24f1;
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f7));
			if (this.oCPU.Flags.B) goto L24f1;
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f4);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L251a;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4ec));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4f5));

		L251a:
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L24f1;
			this.oCPU.CX.Word = this.oCPU.NEGWord(this.oCPU.CX.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4fa, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, this.oCPU.SI.Word);
			this.oCPU.WriteByte(this.oCPU.SS.Word, this.oCPU.SI.Word, this.oCPU.AX.High);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4fd, this.oCPU.AX.Low);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4fe, this.oCPU.SI.Word);

		L2532:
			// Near return
			this.oParent.LogExitBlock("'F0_0000_24de'");
			return;

		L2533:
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4fe);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L25a1;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4fd);
			this.oCPU.WriteByte(this.oCPU.SS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);

		L25a1:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f0);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x2)));
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_24de'");
		}

		public void F0_0000_2540()
		{
			this.oParent.LogEnterBlock("'F0_0000_2540'(Cdecl, Near, Far) at 0x0000:0x2540");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.S) goto L2579;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f2);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NS) goto L2564;
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4fb, this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4fb), this.oCPU.AX.Word));
			if (this.oCPU.Flags.BE) goto L2579;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4f2, 0x0);
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4ee));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4ea, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4ea), this.oCPU.AX.Word));

		L2564:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f2);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.A) goto L2579;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4fb));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.BE) goto L2578;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4fb, this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4fb), this.oCPU.AX.Word));

		L2578:
			// Near return
			this.oParent.LogExitBlock("'F0_0000_2540'");
			return;

		L2579:
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4fe);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L25a1;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4fd);
			this.oCPU.WriteByte(this.oCPU.SS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);

		L25a1:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f0);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x2)));
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_2540'");
		}

		public void F0_0000_25aa()
		{
			this.oParent.LogEnterBlock("'F0_0000_25aa'(Cdecl, Far) at 0x0000:0x25aa");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			goto L25aa;

		L2593:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4fe);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L25a1;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x4fd);
			this.oCPU.WriteByte(this.oCPU.SS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);

		L25a1:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4f0);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x2)));
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oParent.LogExitBlock("'F0_0000_25aa'");
			return;

		L25aa:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x2a6c);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x0));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4f0, this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4f2, this.oCPU.DX.Word);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4fe, this.oCPU.AX.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4f9, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4fa, this.oCPU.AX.Low);
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.SS.Word, this.oCPU.BX.Word), this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L2593;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x10));
			this.oCPU.CMPWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x500));
			if (this.oCPU.Flags.A) goto L2593;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			if (this.oCPU.Flags.E) goto L2593;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x500));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x500);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4ea, this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x4));
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), 0x1);
			if (this.oCPU.Flags.E) goto L25f2;
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x2)));

		L25f2:
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4fb, this.oCPU.AX.Word);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x3));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4f5, this.oCPU.AX.High);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x5));
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L2606;
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.AX.High);

		L2606:
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4f4, this.oCPU.AX.Low);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x8));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4f7, this.oCPU.AX.High);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x7));
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4f8, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, this.oCPU.AX.High);
			this.oCPU.AX.High = 0x0;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x6));
			this.oCPU.CX.Low = this.oCPU.DECByte(this.oCPU.CX.Low);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x4f6, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0xfff7);
			this.oCPU.DI.Word = this.oCPU.SUBWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4ec, this.oCPU.DI.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4ee, this.oCPU.AX.Word);
			// Probably a switch statement - near jump to register value
			this.oCPU.Jmp(this.oCPU.SI.Word);
		}
	}
}
