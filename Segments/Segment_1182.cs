using IRB.VirtualCPU;

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

		public void F0_1182_002a_DrawString(ushort stringPtr, int xPos, int yPos, ushort frontColor)
		{
			this.oCPU.Log.EnterBlock($"F0_1182_002a_DrawString('{this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr))}', " +
				$"{xPos}, {yPos}, {frontColor})");

			// function body
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xc), frontColor);

			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b8c) != 0x0)
			{
				xPos <<= 1;
			}

			// Instruction address 0x1182:0x0053, size: 5
			this.oParent.VGADriver.F0_VGA_11d7_DrawString(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), xPos, yPos, stringPtr);

			// Far return
			this.oCPU.Log.ExitBlock("'F0_1182_002a'");
		}

		public void F0_1182_005c_DrawStringToScreen0(ushort stringPtr, int xPos, int yPos, ushort frontColor)
		{
			this.oCPU.Log.EnterBlock($"F0_1182_005c_DrawStringToScreen0('{this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr))}', " +
				$"{xPos}, {yPos}, {frontColor})");

			// function body			
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x0);

			// Instruction address 0x1182:0x0075, size: 3
			F0_1182_002a_DrawString(stringPtr, xPos, yPos, frontColor);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x1);

			// Far return
			this.oCPU.Log.ExitBlock("F0_1182_005c_DrawStringToScreen0");
		}

		public void F0_1182_0086_DrawTextWithShadow()
		{
			this.oCPU.Log.EnterBlock("'F0_1182_0086'(Cdecl, Far) at 0x1182:0x0086");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			// Instruction address 0x1182:0x0098, size: 3
			F0_1182_005c_DrawStringToScreen0(
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)) + 1,
				0);

			// Instruction address 0x1182:0x00ab, size: 3
			F0_1182_005c_DrawStringToScreen0(
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));

			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("'F0_1182_0086'");
		}

		public void F0_1182_00b3_DrawCenteredText(ushort stringPtr, ushort xPos, ushort yPos, ushort mode)
		{
			this.oCPU.Log.EnterBlock($"'F0_1182_00b3_DrawText'('{this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr))}', "+
				$"{xPos}, {yPos}, {mode})");
			this.oCPU.CS.Word = 0x1182; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			// Instruction address 0x1182:0x00ba, size: 3
			F0_1182_00ef_GetStringWidth(stringPtr);

			xPos -= (ushort)(this.oCPU.AX.Word >> 1);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x0);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00e1); // stack management - push return offset
			// Instruction address 0x1182:0x00de, size: 3
			F0_1182_002a_DrawString(stringPtr, xPos, yPos, mode);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1182; // restore this function segment

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x1);

			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("'F0_1182_00b3_DrawText'");
		}

		public int F0_1182_00ef_GetStringWidth(ushort stringPtr)
		{
			this.oCPU.Log.EnterBlock($"F0_1182_00ef_GetStringWidth('{this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr))}')");

			// function body
			ushort usFontID = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0x10));
			string text = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr));

			this.oCPU.AX.Word = (ushort)this.oParent.VGADriver.GetDrawStringSize(usFontID, text).Width;

			// Far return
			this.oCPU.Log.ExitBlock("F0_1182_00ef_GetStringWidth");

			return this.oParent.VGADriver.GetDrawStringSize(usFontID, text).Width;
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
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5c);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			if (this.oCPU.Flags.L) goto L013c;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1182_0134'");
		}
	}
}
