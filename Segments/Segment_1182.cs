using Disassembler;

namespace OpenCiv1
{
	public class Segment_1182
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public Segment_1182(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F0_1182_002a_DrawString(ushort stringPtr, ushort xPos, ushort yPos, ushort frontColor)
		{
			this.oCPU.Log.EnterBlock("'F0_1182_002a'(Cdecl, Far) at 0x1182:0x002a");
			this.oCPU.CS.Word = 0x1182; // set this function segment

			// function body
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa) + 0xc), frontColor);

			if (this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b8c) != 0x0)
			{
				xPos <<= 1;
			}

			// Instruction address 0x1182:0x0053, size: 5
			this.oParent.VGADriver.F0_VGA_11d7_DrawString(
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				(short)xPos,
				(short)yPos,
				stringPtr);

			// Far return
			this.oCPU.Log.ExitBlock("'F0_1182_002a'");
		}

		public void F0_1182_005c()
		{
			this.oCPU.Log.EnterBlock("'F0_1182_005c'(Cdecl, Far) at 0x1182:0x005c");
			this.oCPU.CS.Word = 0x1182; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa) + 0xa), 0x0);

			// Instruction address 0x1182:0x0075, size: 3
			F0_1182_002a_DrawString(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)),
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)),
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)),
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));

			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa) + 0xa), 0x1);

			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1182_005c'");
		}

		public void F0_1182_0086()
		{
			this.oCPU.Log.EnterBlock("'F0_1182_0086'(Cdecl, Far) at 0x1182:0x0086");
			this.oCPU.CS.Word = 0x1182; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			this.oCPU.PushWord(0);
			this.oCPU.PushWord((ushort)(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)) + 1));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x009b); // stack management - push return offset
			// Instruction address 0x1182:0x0098, size: 3
			F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1182; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);

			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00ae); // stack management - push return offset
			// Instruction address 0x1182:0x00ab, size: 3
			F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1182; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);

			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1182_0086'");
		}

		public void F0_1182_00b3_DrawCenteredText(ushort stringPtr, ushort xPos, ushort value2, ushort value3)
		{
			this.oCPU.Log.EnterBlock($"'F0_1182_00b3_DrawText'('{this.oCPU.ReadString(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, stringPtr))}', "+
				$"{xPos}, {value2}, {value3})");
			this.oCPU.CS.Word = 0x1182; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			// Instruction address 0x1182:0x00ba, size: 3
			F0_1182_00ef_GetStringWidth(stringPtr);

			xPos -= (ushort)(this.oCPU.AX.Word >> 1);

			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa) + 0xa), 0x0);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00e1); // stack management - push return offset
			// Instruction address 0x1182:0x00de, size: 3
			F0_1182_002a_DrawString(stringPtr, xPos, value2, value3);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1182; // restore this function segment

			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa) + 0xa), 0x1);

			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("'F0_1182_00b3_DrawText'");
		}

		public void F0_1182_00ef_GetStringWidth(ushort stringPtr)
		{
			this.oCPU.Log.EnterBlock($"'F0_1182_00ef_GetStringWidth'('{this.oCPU.ReadString(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, stringPtr))}')");

			// function body
			ushort usFontID = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa) + 0x10));
			string text = this.oCPU.ReadString(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, stringPtr));

			this.oCPU.AX.Word = (ushort)this.oParent.VGADriver.GetDrawStringSize(usFontID, text).Width;

			// Far return
			this.oCPU.Log.ExitBlock("'F0_1182_00ef_GetStringWidth'");
		}

		public void F0_1182_0134()
		{
			this.oCPU.Log.EnterBlock("'F0_1182_0134'(Cdecl, Far) at 0x1182:0x0134");
			this.oCPU.CS.Word = 0x1182; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x013c); // stack management - push return offset
			// Instruction address 0x1182:0x0137, size: 5
			this.oParent.Segment_1000.F0_1000_033e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1182; // restore this function segment

		L013c:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5c);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			if (this.oCPU.Flags.L) goto L013c;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1182_0134'");
		}
	}
}
