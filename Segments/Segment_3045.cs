using Disassembler;

namespace Civilization1
{
	public class Segment_3045
	{
		private Civilization oParent;
		private CPU oCPU;

		public Segment_3045(Civilization parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void Start()
		{
			this.oCPU.Log.EnterBlock("Start()");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			ushort usDataSegment = 0x3b01;

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DS.Word = 0x3b01;

			string sPath = this.oCPU.DefaultDirectory + "CIV.EXE";
			this.oCPU.Memory.WriteByte(this.oCPU.DS.Word, 0x61ee, (byte)'C');
			this.oCPU.WriteString(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, 0x6156), sPath, sPath.Length);

			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.ES.Word = this.oCPU.DS.Word;

			this.oCPU.Memory.WriteWord(this.oCPU.DS.Word, 0x5901, this.oCPU.ES.Word); // PSP segment
			this.oCPU.SI.Word = (ushort)(this.oCPU.Memory.FreeMemory.End >> 4); // top of memory
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, usDataSegment);

			// init SS:SP
			this.oCPU.CLI();
			this.oCPU.SS.Word = usDataSegment;
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xe8c0);
			this.oCPU.STI();

			// align SP
			this.oCPU.SP.Word = this.oCPU.ANDWord(this.oCPU.SP.Word, 0xfffe);

			this.oCPU.WriteWord(this.oCPU.SS.Word, 0x5890, this.oCPU.SP.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, 0x588c, this.oCPU.SP.Word);

			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 4);
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, 0x588a, this.oCPU.AX.Word);

			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, usDataSegment);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2, this.oCPU.SI.Word);
			this.oCPU.BX.Word = this.oCPU.ES.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.SI.Word);
			this.oCPU.BX.Word = this.oCPU.NEGWord(this.oCPU.BX.Word);
			this.oCPU.AX.High = 0x4a;
			this.oCPU.INT(0x21);

			this.oCPU.WriteWord(this.oCPU.SS.Word, 0x5901, this.oCPU.DS.Word);

			this.oCPU.ES.Word = this.oCPU.SS.Word;
			this.oCPU.DS.Word = this.oCPU.SS.Word;

			// clear the rest of data and stack segment 0x652e - 0xe8c0
			for (int i = 0x652e; i < this.oCPU.SP.Word; i++)
			{
				this.oCPU.Memory.WriteByte(usDataSegment, (ushort)i, 0);
			}

			// DOS version
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5903, 0x616);

			// Environment block is not used
			// Argument block in not used
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5922, 0);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5920, 0);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x591e, 0);

			// Get special devices information
			// Defaults are OK, no need to modify bytes at 0x590a - 0x590e

			// call our 'short Main()' function
			this.oCPU.BP.Word = 0x0;
			this.oParent.Segment_11a8.F0_11a8_0008_Main();

			this.oCPU.Log.ExitBlock("Start");

			this.oParent.MSCAPI.exit((short)this.oCPU.AX.Word);
		}
	}
}
