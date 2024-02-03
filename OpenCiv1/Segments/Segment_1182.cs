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

        /// <summary>
        /// Draws a string at specified coordinates on screen selected by rectangle at 0xaa
        /// </summary>
        /// <param name="stringPtr"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="mode"></param>
        public void F0_1182_002a_DrawString(ushort stringPtr, int xPos, int yPos, ushort mode)
        {
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xc), mode);

            if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b8c) != 0x0)
            {
                xPos <<= 1;
            }

            // Instruction address 0x1182:0x0053, size: 5
            this.oParent.VGADriver.F0_VGA_11d7_DrawString(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), xPos, yPos, stringPtr);
        }

        /// <summary>
        /// Draws a string at specified coordinates on screen 0
        /// </summary>
        /// <param name="stringPtr"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="mode"></param>
        public void F0_1182_005c_DrawStringToScreen0(ushort stringPtr, int xPos, int yPos, ushort mode)
        {
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x0);

            F0_1182_002a_DrawString(stringPtr, xPos, yPos, mode);

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x1);
        }

        /// <summary>
        /// Draws a string with shadow at specified coordinates on screen 0
        /// </summary>
        /// <param name="stringPtr"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="mode"></param>
        public void F0_1182_0086_DrawStringWithShadow(ushort stringPtr, int xPos, int yPos, ushort mode)
        {
            F0_1182_005c_DrawStringToScreen0(stringPtr, xPos, yPos + 1, 0);
            F0_1182_005c_DrawStringToScreen0(stringPtr, xPos, yPos, mode);
        }

        /// <summary>
        /// Draws a centered string by rectangle defined at 0xaa on screen 0
        /// </summary>
        /// <param name="stringPtr"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="mode"></param>
        public void F0_1182_00b3_DrawCenteredStringToScreen0(ushort stringPtr, int xPos, int yPos, ushort mode)
        {
            F0_1182_00ef_GetStringWidth(stringPtr);

            xPos -= this.oCPU.AX.Word / 2;

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x0);

            F0_1182_002a_DrawString(stringPtr, xPos, yPos, mode);

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x1);
        }

        /// <summary>
        /// Draws a centered string with shaddow by rectangle defined at 0xaa on screen 0
        /// </summary>
        /// <param name="stringPtr"></param>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="mode"></param>
        public void F0_1182_00b3_DrawCenteredStringWithShadowToScreen0(ushort stringPtr, ushort xPos, ushort yPos, ushort mode)
        {
            F0_1182_00ef_GetStringWidth(stringPtr);

            xPos -= (ushort)(this.oCPU.AX.Word >> 1);

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x0);

            F0_1182_002a_DrawString(stringPtr, xPos + 1, yPos + 1, 0);
            F0_1182_002a_DrawString(stringPtr, xPos, yPos, mode);

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0xa), 0x1);
        }

        /// <summary>
        /// Calculates the string width
        /// </summary>
        /// <param name="stringPtr"></param>
        /// <returns></returns>
        public int F0_1182_00ef_GetStringWidth(ushort stringPtr)
        {
            ushort usFontID = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0x10));
            string text = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr));

            this.oCPU.AX.Word = (ushort)this.oParent.VGADriver.GetDrawStringSize(usFontID, text).Width;

            return this.oParent.VGADriver.GetDrawStringSize(usFontID, text).Width;
        }

        /// <summary>
        /// Waits for specified number of main timer ticks
        /// </summary>
        /// <param name="waitTime"></param>
        public void F0_1182_0134_WaitTime(short waitTime)
        {
            this.oParent.Segment_1000.F0_1000_033e_ResetTimer();

            while (this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x5c) < waitTime)
            {
                Thread.Sleep(10);
            }
        }
    }
}
