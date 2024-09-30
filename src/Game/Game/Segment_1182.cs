using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Segment_1182
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public Segment_1182(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// Draws a string at specified coordinates on screen selected by rectangle at 0xaa
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="frontColor"></param>
		public void F0_1182_002a_DrawStringToRectAA(ushort stringPtr, int xPos, int yPos, byte frontColor)
		{
			string text = this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr));

			F0_1182_002a_DrawStringToRectAA(text, xPos, yPos, frontColor);
		}

		/// <summary>
		/// Draws a string at specified coordinates on screen selected by rectangle at 0xaa
		/// </summary>
		/// <param name="text"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="frontColor"></param>
		public void F0_1182_002a_DrawStringToRectAA(string text, int xPos, int yPos, byte frontColor)
		{
			this.oParent.Var_aa_Rectangle.FrontColor = frontColor;

			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b8c) != 0x0)
			{
				xPos *= 2;
			}

			// Instruction address 0x1182:0x0053, size: 5
			this.oParent.Graphics.F0_VGA_11d7_DrawString(this.oParent.Var_aa_Rectangle, xPos, yPos, text);
		}

		/// <summary>
		/// Draws a string at specified coordinates on screen 0
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="frontColor"></param>
		public void F0_1182_005c_DrawStringToRectAA(ushort stringPtr, int xPos, int yPos, byte frontColor)
		{
			string text = this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr));

			F0_1182_005c_DrawStringToRectAA(text, xPos, yPos, frontColor);
		}

		/// <summary>
		/// Draws a string at specified coordinates on screen 0
		/// </summary>
		/// <param name="text"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="frontColor"></param>
		public void F0_1182_005c_DrawStringToRectAA(string text, int xPos, int yPos, byte frontColor)
		{
			this.oParent.Var_aa_Rectangle.Flags = 0;

			F0_1182_002a_DrawStringToRectAA(text, xPos, yPos, frontColor);

			this.oParent.Var_aa_Rectangle.Flags = 1;
		}

		/// <summary>
		/// Draws a string with shadow at specified coordinates on screen 0
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="frontColor"></param>
		public void F0_1182_0086_DrawStringWithShadowToRectAA(ushort stringPtr, int xPos, int yPos, byte frontColor)
		{
			F0_1182_005c_DrawStringToRectAA(stringPtr, xPos, yPos + 1, 0);
			F0_1182_005c_DrawStringToRectAA(stringPtr, xPos, yPos, frontColor);
		}

		/// <summary>
		/// Draws a string with shadow at specified coordinates on screen 0
		/// </summary>
		/// <param name="text"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="frontColor"></param>
		public void F0_1182_0086_DrawStringWithShadowToRectAA(string text, int xPos, int yPos, byte frontColor)
		{
			F0_1182_005c_DrawStringToRectAA(text, xPos, yPos + 1, 0);
			F0_1182_005c_DrawStringToRectAA(text, xPos, yPos, frontColor);
		}

		/// <summary>
		/// Draws a centered string by rectangle defined at 0xaa on screen 0
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="frontColor"></param>
		public void F0_1182_00b3_DrawCenteredStringToRectAA(ushort stringPtr, int xPos, int yPos, byte frontColor)
		{
			string text = this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr));

			F0_1182_00b3_DrawCenteredStringToRectAA(text, xPos, yPos, frontColor);
		}

		/// <summary>
		/// Draws a centered string by rectangle defined at 0xaa on screen 0
		/// </summary>
		/// <param name="text"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="frontColor"></param>
		public void F0_1182_00b3_DrawCenteredStringToRectAA(string text, int xPos, int yPos, byte frontColor)
		{
			xPos -= F0_1182_00ef_GetStringWidth(text) / 2;

			this.oParent.Var_aa_Rectangle.Flags = 0;

			F0_1182_002a_DrawStringToRectAA(text, xPos, yPos, frontColor);

			this.oParent.Var_aa_Rectangle.Flags = 1;
		}

		/// <summary>
		/// Draws a centered string with shaddow by rectangle defined at 0xaa on screen 0
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="frontColor"></param>
		public void F0_1182_00b3_DrawCenteredStringWithShadowToRectAA(ushort stringPtr, int xPos, int yPos, byte frontColor)
		{
			string text = this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr));

			F0_1182_00b3_DrawCenteredStringWithShadowToRectAA(text, xPos, yPos, frontColor);
		}

		/// <summary>
		/// Draws a centered string with shaddow by rectangle defined at 0xaa on screen 0
		/// </summary>
		/// <param name="text"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="frontColor"></param>
		public void F0_1182_00b3_DrawCenteredStringWithShadowToRectAA(string text, int xPos, int yPos, byte frontColor)
		{
			xPos -= F0_1182_00ef_GetStringWidth(text) / 2;

			this.oParent.Var_aa_Rectangle.Flags = 0;

			F0_1182_002a_DrawStringToRectAA(text, xPos + 1, yPos + 1, 0);
			F0_1182_002a_DrawStringToRectAA(text, xPos, yPos, frontColor);

			this.oParent.Var_aa_Rectangle.Flags = 1;
		}

		/// <summary>
		/// Calculates the string width
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <returns></returns>
		public int F0_1182_00ef_GetStringWidth(ushort stringPtr)
		{
			string text = this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr));

			return F0_1182_00ef_GetStringWidth(text);
		}

		/// <summary>
		/// Calculates the string width
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		public int F0_1182_00ef_GetStringWidth(string text)
		{
			int width = this.oParent.Graphics.GetDrawStringSize(this.oParent.Var_aa_Rectangle.FontID, text).Width;

			this.oCPU.AX.Word = (ushort)((short)width);

			return width;
		}
	}
}
