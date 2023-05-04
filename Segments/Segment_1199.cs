using Disassembler;

namespace Civilization1
{
	public class Segment_1199
	{
		private Civilization oParent;
		private CPU oCPU;

		public Segment_1199(Civilization parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F0_1199_00a1()
		{
			this.oParent.LogWriteLine("Entering function 'F0_1199_00a1'(Cdecl) at 0x1199:0x00a1, stack: 0x0");
			this.oCPU.CS.Word = 0x1199; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.High = 0x2;
			this.oCPU.BX.High = 0x0;
			this.oCPU.DX.High = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L00b6;
			this.oCPU.INT(0x10);

		L00b6:
			this.oCPU.BX.Low = this.oCPU.ReadByte(this.oCPU.CS.Word, 0xa0);
			this.oCPU.BX.High = 0x0;
			this.oCPU.CX.Word = 0x1;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));

		L00c3:
			this.oCPU.LODSByte();
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L00e9;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0xff);
			if (this.oCPU.Flags.E) goto L00dc;
			this.oCPU.DX.Low = this.oCPU.AX.Low;
			this.oCPU.AX.High = 0x9;
			this.oCPU.AX.Low = 0x20;
			this.oCPU.INT(0x10);
			this.oCPU.AX.High = 0xe;
			this.oCPU.AX.Low = this.oCPU.DX.Low;
			this.oCPU.INT(0x10);
			goto L00c3;

		L00dc:
			this.oCPU.LODSByte();
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L00e9;
			this.oCPU.WriteByte(this.oCPU.CS.Word, 0xa0, this.oCPU.AX.Low);
			this.oCPU.BX.Low = this.oCPU.AX.Low;
			goto L00c3;

		L00e9:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_1199_00a1'");
		}

		public void F0_1199_00ec()
		{
			this.oParent.LogWriteLine("Entering function 'F0_1199_00ec'(Cdecl) at 0x1199:0x00ec, stack: 0x0");
			this.oCPU.CS.Word = 0x1199; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.High = 0x9;
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.INT(0x21);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_1199_00ec'");
		}
	}
}
