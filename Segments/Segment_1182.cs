using IRB.VirtualCPU;
using Microsoft.Win32;
using System.Threading;

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
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xc), frontColor);

			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b8c) != 0x0)
			{
				xPos <<= 1;
			}

			// Instruction address 0x1182:0x0053, size: 5
			this.oParent.VGADriver.F0_VGA_11d7_DrawString(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), xPos, yPos, stringPtr);
		}

		public void F0_1182_005c_DrawStringToScreen0(ushort stringPtr, int xPos, int yPos, ushort frontColor)
		{
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x0);

			F0_1182_002a_DrawString(stringPtr, xPos, yPos, frontColor);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x1);
		}

		public void F0_1182_0086_DrawStringWithShadow(ushort stringPtr, int xPos, int yPos, ushort mode)
		{
			F0_1182_005c_DrawStringToScreen0(stringPtr, xPos, yPos + 1, 0);
			F0_1182_005c_DrawStringToScreen0(stringPtr, xPos, yPos, mode);
		}

		public void F0_1182_00b3_DrawCenteredStringToScreen0(ushort stringPtr, ushort xPos, ushort yPos, ushort mode)
		{
			F0_1182_00ef_GetStringWidth(stringPtr);

			xPos -= (ushort)(this.oCPU.AX.Word >> 1);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x0);

			F0_1182_002a_DrawString(stringPtr, xPos, yPos, mode);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x1);
		}

		public void F0_1182_00b3_DrawCenteredStringWithShadowToScreen0(ushort stringPtr, ushort xPos, ushort yPos, ushort mode)
		{
			F0_1182_00ef_GetStringWidth(stringPtr);

			xPos -= (ushort)(this.oCPU.AX.Word >> 1);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x0);

			F0_1182_002a_DrawString(stringPtr, xPos + 1, yPos + 1, 0);
			F0_1182_002a_DrawString(stringPtr, xPos, yPos, mode);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x1);
		}

		public int F0_1182_00ef_GetStringWidth(ushort stringPtr)
		{
			ushort usFontID = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0x10));
			string text = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr));

			this.oCPU.AX.Word = (ushort)this.oParent.VGADriver.GetDrawStringSize(usFontID, text).Width;

			return this.oParent.VGADriver.GetDrawStringSize(usFontID, text).Width;
		}

		public void F0_1182_0134_WaitTime(short waitTime)
		{
			this.oParent.Segment_1000.F0_1000_033e_ResetTimer();

			while (this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x5c) < waitTime)
			{
				Thread.Sleep(1);
			}
		}
	}
}
