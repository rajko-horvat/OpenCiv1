using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Segment_2f4d
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;

		public Segment_2f4d(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		public void F0_2f4d_0000(short param1)
		{
			this.oCPU.Log.EnterBlock($"F0_2f4d_0000({param1})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x4);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x0);
			goto L005d;

		L0012:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06)), 0x5e);
			if (this.oCPU.Flags.NE) goto L002b;
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06), 0x20);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba07), 0xa);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0xffff);

		L002b:
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06)), 0xa);
			if (this.oCPU.Flags.NE) goto L0037;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0xffff);

		L0037:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))));
			
			if (this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)) <= param1)
				goto L005a;

			if (this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06)) != 0x20)
				goto L005a;

			if (this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba07)) == 0x20)
				goto L005a;

			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06), 0xa);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x0);

		L005a:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))));

		L005d:
			// Instruction address 0x2f4d:0x0061, size: 5
			this.oParent.CAPI.strlen(0xba06);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));
			if (this.oCPU.Flags.G) goto L0012;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x0);
			if (this.oCPU.Flags.LE) goto L0084;

			// Instruction address 0x2f4d:0x007c, size: 5
			this.oParent.CAPI.strcat(0xba06, "\n");

		L0084:
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2f4d_0000");
		}

		/// <summary>
		/// Draws a text in a block of maximum width
		/// </summary>
		/// <param name="maxWidth"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="frontColor"></param>
		/// <returns></returns>
		public int F0_2f4d_0088_DrawTextBlock(int maxWidth, int xPos, int yPos, byte frontColor)
		{
			this.oCPU.Log.EnterBlock($"F0_2f4d_0088_DrawTextBlock({maxWidth}, {xPos}, {yPos}, {frontColor})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0xc);
			this.oCPU.AX.UInt16 = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);

			// Instruction address 0x2f4d:0x00a0, size: 5
			this.oParent.Graphics.F0_VGA_11ae_GetTextHeight(this.oParent.Var_aa_Rectangle.FontID);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 0x0);
			goto L00b5;

		L00b2:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))));

		L00b5:
			// Instruction address 0x2f4d:0x00b9, size: 5
			this.oParent.CAPI.strlen(0xba06);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			if (this.oCPU.Flags.G) goto L00c9;
			goto L017b;

		L00c9:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06));

			// Instruction address 0x2f4d:0x00d9, size: 5
			this.oParent.Graphics.F0_VGA_115d_GetCharWidth(this.oParent.Var_aa_Rectangle.FontID, this.oCPU.AX.LowUInt8);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), this.oCPU.AX.UInt16));
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06)), 0x20);
			if (this.oCPU.Flags.E) goto L00fc;
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06)), 0xa);
			if (this.oCPU.Flags.E) goto L00fc;
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06)), 0x5e);
			if (this.oCPU.Flags.NE) goto L0101;

		L00fc:
			this.oCPU.AX.UInt16 = this.oCPU.BX.UInt16;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.AX.UInt16);

		L0101:
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06)), 0xa);
			if (this.oCPU.Flags.E) goto L011b;
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06)), 0x5e);
			if (this.oCPU.Flags.E) goto L011b;

			if (maxWidth * 8 >= this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)))
				goto L00b2;

		L011b:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6));
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06), 0x0);

			// Instruction address 0x2f4d:0x013b, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0((ushort)(0xba06 + this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))),
				xPos, yPos, frontColor);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6));
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06), this.oCPU.AX.LowUInt8);

			yPos += this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x0);
			this.oCPU.AX.UInt16 = this.oCPU.BX.UInt16;
			this.oCPU.AX.UInt16 = this.oCPU.INC_UInt16(this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.AX.UInt16);
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xba06)), 0x5e);
			if (this.oCPU.Flags.NE) goto L016b;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))));

		L016b:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.AX.UInt16);

			if (yPos <= 192)
				goto L00b2;

		L017b:
			if (this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)) <= 0)
				goto L01a6;
			
			if (yPos > 192)
				goto L01a6;

			// Instruction address 0x2f4d:0x0198, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0((ushort)(0xba06 + this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))),
				xPos, yPos, frontColor);

			yPos += this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));

		L01a6:
			this.oCPU.AX.UInt16 = (ushort)((short)yPos);
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2f4d_0088_DrawTextBlock");

			return yPos;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="filenamePtr"></param>
		/// <param name="stringPtr"></param>
		/// <returns></returns>
		public ushort F0_2f4d_01ad(ushort filenamePtr, ushort stringPtr)
		{
			this.oCPU.Log.EnterBlock($"F0_2f4d_01ad(0x{filenamePtr:x4}, 0x{stringPtr:x4})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x110);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.AX.UInt16 = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x106), this.oCPU.AX.UInt16);
			goto L01d9;

		L01c5:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x106));
			this.oCPU.SI.UInt16 = stringPtr;
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + this.oCPU.SI.UInt16));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102)), this.oCPU.AX.UInt16));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x106), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x106))));

		L01d9:
			// Instruction address 0x2f4d:0x01dc, size: 5
			this.oParent.CAPI.strlen(stringPtr);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x106)));
			if (this.oCPU.Flags.G) goto L01c5;
			this.oCPU.WriteUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x101), 0x0);

		L01ef:
			// Instruction address 0x2f4d:0x01f6, size: 5
			this.oParent.CAPI.fopen(filenamePtr, "rb");

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110), this.oCPU.AX.UInt16);

			// Instruction address 0x2f4d:0x0226, size: 5
			this.oParent.CAPI.fseek((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)),
				(((int)((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102))) >> 5) +
					this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102))) << 1,
				0);

			// Instruction address 0x2f4d:0x023f, size: 5
			this.oParent.CAPI.fread((ushort)(this.oCPU.BP.UInt16 - 0x104), 2, 1, 
				(short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)));
			
			// Instruction address 0x2f4d:0x024b, size: 5
			this.oParent.CAPI.fclose((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)));
			
			// Instruction address 0x2f4d:0x025a, size: 5
			this.oParent.CAPI.fopen(filenamePtr, "rt");

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)), 0x1ff);
			if (this.oCPU.Flags.BE) goto L02bc;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)), 0x3030);
			if (this.oCPU.Flags.E) goto L02bc;

			// Instruction address 0x2f4d:0x0282, size: 5
			this.oParent.CAPI.fseek((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)), 0);

			// Instruction address 0x2f4d:0x0297, size: 5
			this.oParent.CAPI.fscanf((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)),
				"%[^\n]\n", (ushort)(this.oCPU.BP.UInt16 - 0x100));

			// Instruction address 0x2f4d:0x02a7, size: 5
			this.oParent.CAPI.stricmp((ushort)(this.oCPU.BP.UInt16 - 0x100), stringPtr);

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L02b6;
			goto L0392;

		L02b6:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e), 0x1);

		L02bc:
			this.oCPU.AX.UInt16 = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10a), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10c), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L0323;

			// Instruction address 0x2f4d:0x02d7, size: 5
			this.oParent.CAPI.fseek((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)),
				0x200, (short)this.oCPU.AX.UInt16);

		L02df:
			// Instruction address 0x2f4d:0x02e3, size: 5
			this.oParent.CAPI.ftell((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104), this.oCPU.AX.UInt16);

			// Instruction address 0x2f4d:0x02fc, size: 5
			this.oParent.CAPI.fscanf((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)),
				"%[^\n]\n", (ushort)(this.oCPU.BP.UInt16 - 0x100));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10a), this.oCPU.AX.UInt16);

			// Instruction address 0x2f4d:0x0310, size: 5
			this.oParent.CAPI.stricmp((ushort)(this.oCPU.BP.UInt16 - 0x100), stringPtr);

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0323;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10a)), 0xffff);
			if (this.oCPU.Flags.NE) goto L02df;

		L0323:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10a)), 0xffff);
			if (this.oCPU.Flags.NE) goto L032d;
			goto L03af;

		L032d:
			// Instruction address 0x2f4d:0x033a, size: 5
			this.oParent.CAPI.fscanf((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)),
				"%[^\n]\n", (ushort)(this.oCPU.BP.UInt16 - 0x100));

			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x100)), 0x2a);
			if (this.oCPU.Flags.E) goto L032d;

		L0349:
			// Instruction address 0x2f4d:0x0352, size: 5
			this.oParent.CAPI.strcat(0xba06, (ushort)(this.oCPU.BP.UInt16 - 0x100));

			// Instruction address 0x2f4d:0x0362, size: 5
			this.oParent.CAPI.strcat(0xba06, " ");

			// Instruction address 0x2f4d:0x0377, size: 5
			this.oParent.CAPI.fscanf((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)),
				"%[^\n]\n", (ushort)(this.oCPU.BP.UInt16 - 0x100));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10c), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10c))));
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x100)), 0x2a);
			if (this.oCPU.Flags.NE) goto L0349;

			// Let's try to trim the dialog text, and fix the bug with unecessary lines in dialogs
			string sInput = this.oCPU.ReadString(VCPU.ToLinearAddress(this.oParent.CPU.DS.UInt16, 0xba06));
			sInput = sInput.TrimEnd(new char[] {' ', '^'});
			this.oCPU.WriteString(VCPU.ToLinearAddress(this.oParent.CPU.DS.UInt16, 0xba06), sInput, sInput.Length);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108), 0x1);
			goto L03b5;

		L0392:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102))));
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102));
			this.oCPU.AX.HighUInt8 = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102), this.oCPU.AX.UInt16);
			
			// Instruction address 0x2f4d:0x03a4, size: 5
			this.oParent.CAPI.fclose((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)));
			goto L01ef;

		L03af:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108), 0x0);

		L03b5:
			// Instruction address 0x2f4d:0x03b9, size: 5
			this.oParent.CAPI.fclose((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x0);
			if (this.oCPU.Flags.NE) goto L043a;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)), 0x0);
			if (this.oCPU.Flags.E) goto L043a;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10a)), 0xffff);
			if (this.oCPU.Flags.E) goto L043a;

			// Instruction address 0x2f4d:0x03dd, size: 5
			this.oParent.CAPI.fopen(filenamePtr, "r+b");

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110), this.oCPU.AX.UInt16);

			// Instruction address 0x2f4d:0x040d, size: 5
			this.oParent.CAPI.fseek((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)),
				((int)((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102))) >> 5 +
					this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102))) << 1,
				0);

			// Instruction address 0x2f4d:0x0426, size: 5
			this.oParent.CAPI.fwrite((ushort)(this.oCPU.BP.UInt16 - 0x104), 2, 1,
				(short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)));
			
			// Instruction address 0x2f4d:0x0432, size: 5
			this.oParent.CAPI.fclose((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)));

		L043a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)), 0x0);
			if (this.oCPU.Flags.E) goto L0447;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10c));
			goto L044a;

		L0447:
			this.oCPU.AX.UInt16 = 0xffff;

		L044a:
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2f4d_01ad");

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="stringPtr"></param>
		public void F0_2f4d_044f(ushort stringPtr)
		{
			this.oCPU.Log.EnterBlock($"F0_2f4d_044f(0x{stringPtr:x4})");

			// function body
			// Instruction address 0x2f4d:0x045a, size: 3
			F0_2f4d_01ad(0x30a5, stringPtr);

			// Instruction address 0x2f4d:0x0461, size: 3
			F0_2f4d_0471();

			// Instruction address 0x2f4d:0x0469, size: 3
			F0_2f4d_0000(0x50);

			// Far return
			this.oCPU.Log.ExitBlock("F0_2f4d_044f");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_2f4d_0471()
		{
			this.oCPU.Log.EnterBlock("F0_2f4d_0471()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x204);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x204), 0x0);

		L0480:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x204));
			this.oCPU.SI.UInt16 <<= 1;
			// Instruction address 0x2f4d:0x048e, size: 5
			this.oParent.CAPI.strstr(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x30ae)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L04e0;

			// Instruction address 0x2f4d:0x04a3, size: 5
			this.oParent.CAPI.strcpy((ushort)(this.oCPU.BP.UInt16 - 0x202), this.oCPU.AX.UInt16);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, this.oCPU.BX.UInt16, 0x0);

			// Instruction address 0x2f4d:0x04b9, size: 5
			this.oParent.CAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x30b8)));

			// Instruction address 0x2f4d:0x04c5, size: 5
			this.oParent.CAPI.strlen(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x30ae)));

			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;
			// Instruction address 0x2f4d:0x04d8, size: 5
			this.oParent.CAPI.strcat(0xba06, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.DI.UInt16 - 0x202));

		L04e0:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L0480;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x204), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x204))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x204)), 0x5);
			if (this.oCPU.Flags.L) goto L0480;

			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2f4d_0471");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <param name="maxWidth"></param>
		public void F0_2f4d_04f7(ushort stringPtr, ushort maxWidth)
		{
			this.oCPU.Log.EnterBlock($"F0_2f4d_04f7(0x{stringPtr:x4}, {maxWidth})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);
			goto L0537;

		L04fd:
			// Instruction address 0x2f4d:0x0500, size: 5
			this.oParent.CAPI.strlen(stringPtr);

			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.BX.UInt16 = stringPtr;
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + this.oCPU.SI.UInt16 - 0x3)), 0x20);
			if (this.oCPU.Flags.E) goto L0525;

			// Instruction address 0x2f4d:0x0514, size: 5
			this.oParent.CAPI.strlen(this.oCPU.BX.UInt16);

			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.BX.UInt16 = stringPtr;
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + this.oCPU.SI.UInt16 - 0x2), 0x2e);

		L0525:
			// Instruction address 0x2f4d:0x0526, size: 5
			this.oParent.CAPI.strlen(this.oCPU.BX.UInt16);

			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.BX.UInt16 = stringPtr;
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + this.oCPU.SI.UInt16 - 0x1), 0x0);

		L0537:
			// Instruction address 0x2f4d:0x053a, size: 5
			this.oParent.Segment_1182.F0_1182_00ef_GetStringWidth(stringPtr);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, maxWidth);
			if (this.oCPU.Flags.G) goto L04fd;

			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2f4d_04f7");
		}
	}
}
