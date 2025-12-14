using Avalonia.Media;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class GameInitAndIntro
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;

		public GameInitAndIntro(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_0012_GameIntro()
		{
			this.oCPU.Log.EnterBlock("F7_0000_0012_GameIntro()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0xe);

			this.oParent.Var_aa_Rectangle.ScreenID = 1;

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x67fc, 0x0);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xd76a), 0x0);
			if (this.oCPU.Flags.E) goto L0054;
			
			// Instruction address 0x0000:0x0049, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x3b20, 1);

			goto L0578;

		L0054:
			F7_0000_17cf();

			// Instruction address 0x0000:0x006b, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

		L0073:
			F7_0000_08be();

			F7_0000_17cf();

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x7ef6);
			this.oCPU.CX.LowUInt8 = 0x3;
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.CX.UInt16 = 0x28;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, 0x280);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x67fe));
			if (this.oCPU.Flags.G) goto L0073;

			// Instruction address 0x0000:0x009f, size: 5
			this.oParent.ManuBoxDialog.F0_2d05_0a05_DrawRectangle(0, 0, 79, 49, 0);

			// Instruction address 0x0000:0x00b7, size: 5
			this.oParent.ManuBoxDialog.F0_2d05_0a05_DrawRectangle(1, 1, 77, 47, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 0x1);

		L00c4:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), 0x1);

		L00c9:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x0);

			// Instruction address 0x0000:0x00d8, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L00e8;
			
			this.oCPU.WriteUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 
				this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x1));

		L00e8:
			// Instruction address 0x0000:0x00f4, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)) + 1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0104;
			this.oCPU.WriteUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 
				this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x2));

		L0104:
			// Instruction address 0x0000:0x0110, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)) + 1);

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0120;
			this.oCPU.WriteUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 
				this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x4));

		L0120:
			// Instruction address 0x0000:0x012e, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)) + 1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)) + 1);

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L013e;
			this.oCPU.WriteUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 
				this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x8));

		L013e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x6);
			if (this.oCPU.Flags.E) goto L014a;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x9);
			if (this.oCPU.Flags.NE) goto L0195;

		L014a:
			// Instruction address 0x0000:0x0157, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)) + 1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				1);

			// Instruction address 0x0000:0x016c, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)) + 1,
				1);

			// Instruction address 0x0000:0x017b, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)) + 1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)) + 1,
				1);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)), 0x0);
			if (this.oCPU.Flags.E) goto L018c;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 
				this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))));

		L018c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)), 0x0);
			if (this.oCPU.Flags.E) goto L0195;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), 
				this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))));

		L0195:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)), 0x31);
			if (this.oCPU.Flags.GE) goto L01a1;
			goto L00c9;

		L01a1:
			F7_0000_17cf();

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)), 0x4f);
			if (this.oCPU.Flags.GE) goto L01b1;
			goto L00c4;

		L01b1:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 0x0);
			goto L0296;

		L01b9:
			// Instruction address 0x0000:0x01c4, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				1);

		L01cc:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))));

		L01cf:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)), 0x32);
			if (this.oCPU.Flags.L) goto L01d8;
			goto L028f;

		L01d8:
			// Instruction address 0x0000:0x01e2, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L01b9;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.E) goto L0207;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x2);
			if (this.oCPU.Flags.NE) goto L01fe;
			goto L0285;

		L01fe:
			// Instruction address 0x0000:0x01c4, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				13);

			goto L01cc;

		L0207:
			// Instruction address 0x0000:0x020b, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.RNG.Next(8));

			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, 0x1d);
			this.oCPU.AX.UInt16 = this.oCPU.NEG_UInt16(this.oCPU.AX.UInt16);
			// Instruction address 0x0000:0x021c, size: 5
			this.oParent.CAPI.abs((short)this.oCPU.AX.UInt16);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = 0x1;
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x7ef8));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), this.oCPU.AX.UInt16));
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.UInt16 = 0x6;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, 0xffff);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x7);
			if (this.oCPU.Flags.A) goto L01cc;
			switch(this.oCPU.AX.UInt16)
			{
				case 0:
					goto L024a;
				case 1:
					goto L024a;
				case 2:
					goto L0254;
				case 3:
					goto L0254;
				case 4:
					goto L025e;
				case 5:
					goto L025e;
				case 6:
					goto L0268;
				case 7:
					goto L0268;
			}

		L024a:
			// Instruction address 0x0000:0x01c4, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				14);

			goto L01cc;

		L0254:
			// Instruction address 0x0000:0x01c4, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				6);

			goto L01cc;

		L025e:
			// Instruction address 0x0000:0x01c4, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				7);

			goto L01cc;

		L0268:
			// Instruction address 0x0000:0x01c4, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				15);

			goto L01cc;

		L0285:
			// Instruction address 0x0000:0x01c4, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				12);

			goto L01cc;

		L028f:
			F7_0000_17cf();

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))));

		L0296:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)), 0x50);
			if (this.oCPU.Flags.GE) goto L02a4;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), 0x0);
			goto L01cf;

		L02a4:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), 0x0);
			goto L0448;

		L02ac:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x0);
			if (this.oCPU.Flags.LE) goto L02fa;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x7efa);
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, 0x7);
			this.oCPU.AX.UInt16 = this.oCPU.NEG_UInt16(this.oCPU.AX.UInt16);
			
			// Instruction address 0x0000:0x02bd, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.RNG.Next(this.oCPU.AX.UInt16));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), this.oCPU.AX.UInt16));
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x6);
			if (this.oCPU.Flags.E) goto L0340;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x7);
			if (this.oCPU.Flags.E) goto L0352;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xc);
			if (this.oCPU.Flags.E) goto L0349;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xd);
			if (this.oCPU.Flags.E) goto L035b;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xe);
			if (this.oCPU.Flags.NE) goto L02fa;

			// Instruction address 0x0000:0x02f2, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				6);

		L02fa:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))));

		L02fd:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)), 0x50);
			if (this.oCPU.Flags.GE) goto L0361;

			// Instruction address 0x0000:0x030d, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.NE) goto L02ac;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));
			
			// Instruction address 0x0000:0x0324, size: 5
			this.oParent.CAPI.abs((short)this.oCPU.AX.UInt16);

			this.oCPU.CX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x7efa);
			this.oCPU.CX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.CX.UInt16, 0x1);
			this.oCPU.CX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.CX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			if (this.oCPU.Flags.LE) goto L02fa;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))));
			goto L02fa;

		L0340:
			// Instruction address 0x0000:0x02f2, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				10);

			goto L02fa;

		L0349:
			// Instruction address 0x0000:0x02f2, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				2);

			goto L02fa;

		L0352:
			// Instruction address 0x0000:0x02f2, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				15);

			goto L02fa;

		L035b:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x3));
			goto L02fa;

		L0361:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 0x4f);
			goto L03cc;

		L036d:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x0);
			if (this.oCPU.Flags.LE) goto L03c9;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x7efa);
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, 0x7);
			this.oCPU.AX.UInt16 = this.oCPU.NEG_UInt16(this.oCPU.AX.UInt16);
			
			// Instruction address 0x0000:0x037e, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.RNG.Next(this.oCPU.AX.UInt16));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), this.oCPU.AX.UInt16));
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x3);
			if (this.oCPU.Flags.NE) goto L0394;
			goto L0437;

		L0394:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x6);
			if (this.oCPU.Flags.E) goto L0402;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.E) goto L040b;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xc);
			if (this.oCPU.Flags.NE) goto L03a6;
			goto L0437;

		L03a6:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xd);
			if (this.oCPU.Flags.NE) goto L03ae;
			goto L0433;

		L03ae:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xe);
			if (this.oCPU.Flags.NE) goto L03c9;

			// Instruction address 0x0000:0x03c1, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				6);

		L03c9:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))));

		L03cc:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)), 0x0);
			if (this.oCPU.Flags.L) goto L0441;

			// Instruction address 0x0000:0x03dc, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.NE) goto L036d;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, this.oCPU.DX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.SAR_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x7efa));
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			if (this.oCPU.Flags.LE) goto L03c9;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))));
			goto L03c9;

		L0402:
			// Instruction address 0x0000:0x03c1, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				10);

			goto L03c9;

		L040b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), 0xa);
			if (this.oCPU.Flags.L)
			{
				// Instruction address 0x0000:0x0424, size: 5
				this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
					this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
					11);
			}
			else
			{
				// Instruction address 0x0000:0x0424, size: 5
				this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
					this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
					3);
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 0xfffe);
			goto L03c9;

		L0433:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x3));

		L0437:
			// Instruction address 0x0000:0x03c1, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				2);

			goto L03c9;

		L0441:
			F7_0000_17cf();

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))));

		L0448:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)), 0x32);
			if (this.oCPU.Flags.GE) goto L046d;
			this.oCPU.AX.UInt16 = 0x19;
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));
			
			// Instruction address 0x0000:0x0455, size: 5
			this.oParent.CAPI.abs((short)this.oCPU.AX.UInt16);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 0x0);
			goto L02fd;

		L046d:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe), 0x0);
			goto L0537;

		L0475:
			// Instruction address 0x0000:0x0479, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.RNG.Next(80));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x0488, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.RNG.Next(50));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.AX.UInt16);

		L0493:
			// Instruction address 0x0000:0x049d, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, 0x2);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xd);
			if (this.oCPU.Flags.BE) goto L04b3;
			goto L0534;

		L04b3:
			switch (this.oCPU.AX.UInt16)
			{
				case 0:
					goto L04dc;
				case 1:
					goto L04f7;
				case 2:
					goto L0534;
				case 3:
					goto L0534;
				case 4:
					goto L04e5;
				case 5:
					goto L04e5;
				case 6:
					goto L0534;
				case 7:
					goto L0534;
				case 8:
					goto L04d3;
				case 9:
					goto L0500;
				case 10:
					goto L04ee;
				case 11:
					goto L04c4;
				case 12:
					goto L04bb;
				case 13:
					goto L04ee;
			}

		L04bb:
			// Instruction address 0x0000:0x050e, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				6);

			goto L0534;

		L04c4:
			F7_0000_05d4(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));
			
			goto L0534;

		L04d3:
			// Instruction address 0x0000:0x050e, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				2);

			goto L0534;

		L04dc:
			// Instruction address 0x0000:0x050e, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				11);

			goto L0534;

		L04e5:
			// Instruction address 0x0000:0x050e, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				12);

			goto L0534;

		L04ee:
			// Instruction address 0x0000:0x050e, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				13);

			goto L0534;

		L04f7:
			// Instruction address 0x0000:0x050e, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				10);

			goto L0534;

		L0500:
			// Instruction address 0x0000:0x050e, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)),
				3);

		L0534:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe))));

		L0537:
			this.oCPU.AX.UInt16 = 0x320;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x7efc));
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, 0x320);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe)));
			if (this.oCPU.Flags.LE) goto L0574;
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe)), 0x1);
			if (this.oCPU.Flags.NE) goto L054f;
			goto L0475;

		L054f:
			// Instruction address 0x0000:0x0553, size: 5
			this.oCPU.WriteInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2),
				(short)(this.oParent.CAPI.RNG.Next(8) + 1));

			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))];

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)), (ushort)((short)direction.X)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)), (ushort)((short)direction.Y)));
			goto L0493;

		L0574:
			F7_0000_065c();

		L0578:
			// Instruction address 0x0000:0x058e, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 160, 0, 160, 200, 0);

			F7_0000_0a33();

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x67fc, 0x1);

		L05a0:
			F7_0000_17cf();

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L05a0;

			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x0000:0x05c6, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19e8_Rectangle, 0, 0);

			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_0012_GameIntro");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F7_0000_05d4(short xPos, short yPos)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_05d4({xPos}, {yPos})");

			// function body
			// Instruction address 0x0000:0x05e5, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos - 1, yPos - 1);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.NE) goto L05f6;

		L05f2:
			this.oCPU.AX.UInt16 = 0;
			goto L065a;

		L05f6:
			// Instruction address 0x0000:0x0604, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos - 1, yPos + 1);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.E) goto L05f2;

			// Instruction address 0x0000:0x061f, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos + 1, yPos - 1);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.E) goto L05f2;

			// Instruction address 0x0000:0x063a, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos + 1, yPos + 1);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.E) goto L05f2;

			// Instruction address 0x0000:0x0652, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, xPos, yPos, 1);

		L065a:
			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_05d4");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_065c()
		{
			this.oCPU.Log.EnterBlock($"F7_0000_065c()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x18);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0);

		L066b:
			// Instruction address 0x0000:0x0686, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle,
				0, 0, 160, 100, this.oParent.Var_aa_Rectangle, 160, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 0x0);

		L0693:
			// Instruction address 0x0000:0x0697, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.RNG.Next(80));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x06a6, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.RNG.Next(50));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x06b9, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xc);
			if (this.oCPU.Flags.NE) goto L0693;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x06d6, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.RNG.Next(4));

			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), this.oCPU.AX.UInt16);

		L06e6:
			// Instruction address 0x0000:0x06f4, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				9);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), 0x1);

		L0706:
			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))];

			// Instruction address 0x0000:0x071f, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)) + direction.X,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)) + direction.Y);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.NE) goto L0731;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x1);

		L0731:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)), 0x2));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)), 0x8);
			if (this.oCPU.Flags.LE) goto L0706;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x0745, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.RNG.Next(2));

			this.oCPU.CX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16));
			this.oCPU.CX.UInt16 = this.oCPU.AND_UInt16(this.oCPU.CX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)));
			this.oCPU.AX.UInt16 = this.oCPU.AND_UInt16(this.oCPU.AX.UInt16, 0x7);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10));
			this.oCPU.AX.LowUInt8 = this.oCPU.XOR_UInt8(this.oCPU.AX.LowUInt8, 0x4);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)));
			if (this.oCPU.Flags.LE) goto L0784;

			// Instruction address 0x0000:0x077c, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)) + 0x32,
				8);

		L0784:
			direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)) + 1];

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), (ushort)((short)direction.X)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)), (ushort)((short)direction.Y)));

			// Instruction address 0x0000:0x07a1, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L07c7;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xd);
			if (this.oCPU.Flags.E) goto L07c7;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.E) goto L07c7;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x9);
			if (this.oCPU.Flags.E) goto L07c7;
			goto L06e6;

		L07c7:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L07d3;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x9);
			if (this.oCPU.Flags.NE) goto L07d9;

		L07d3:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)), 0x5);
			if (this.oCPU.Flags.GE) goto L07fe;

		L07d9:
			// Instruction address 0x0000:0x07f4, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle,
				160, 0, 160, 100, this.oParent.Var_aa_Rectangle, 0, 0);

			goto L0853;

		L07fe:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), 0x1);

		L0806:
			direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))];

			this.oCPU.AX.UInt16 = (ushort)((short)direction.X);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = (ushort)((short)direction.Y);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe)));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x0827, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x2);
			if (this.oCPU.Flags.NE) goto L084a;

			// Instruction address 0x0000:0x0842, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				11);

		L084a:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)), 0x15);
			if (this.oCPU.Flags.LE) goto L0806;

		L0853:
			F7_0000_17cf();

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x100);
			if (this.oCPU.Flags.GE) goto L0875;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x7ef6);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x7efa));
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, 0x6);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)));
			if (this.oCPU.Flags.LE) goto L0875;
			goto L066b;

		L0875:
			// Instruction address 0x0000:0x0893, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(
				this.oParent.Var_aa_Rectangle, 0, 50, 80, 50, this.oParent.Var_aa_Rectangle, 0, 150);

			// Instruction address 0x0000:0x08b1, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 50, 80, 50, 0);

			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_065c");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_08be()
		{
			this.oCPU.Log.EnterBlock("F7_0000_08be()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x6);

			// Instruction address 0x0000:0x08da, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 160, 0, 80, 50, 0);

			// Instruction address 0x0000:0x08e6, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.RNG.Next(72));

			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x08f8, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.RNG.Next(34));

			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0x0);

		L090b:
			F7_0000_0988_GenerateCloud(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0x1);
			if (this.oCPU.Flags.L) goto L090b;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x0);
			goto L0977;

		L0928:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))));

		L092b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), 0x32);
			if (this.oCPU.Flags.GE) goto L0974;
			
			// Instruction address 0x0000:0x093f, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)) + 0xa0,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0928;

			// Instruction address 0x0000:0x0956, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(1,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));

			// Instruction address 0x0000:0x0966, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)),
				(ushort)(this.oCPU.AX.UInt16 + 1));

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x67fe, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x67fe)));
			goto L0928;

		L0974:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))));

		L0977:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x50);
			if (this.oCPU.Flags.GE) goto L0984;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x0);
			goto L092b;

		L0984:
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_08be");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F7_0000_0988_GenerateCloud(short xPos, short yPos)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_0988_GenerateCloud({xPos}, {yPos})");

			// function body
			int iCloudSize = this.oParent.CAPI.RNG.Next(64) + 1;

			do
			{
				this.oParent.CommonTools.F0_1000_104f_SetPixel(1, xPos + 160, yPos, 15);
				this.oParent.CommonTools.F0_1000_104f_SetPixel(1, xPos + 161, yPos, 15);
				this.oParent.CommonTools.F0_1000_104f_SetPixel(1, xPos + 160, yPos + 1, 15);

				/*this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, xPos + 159, yPos, 15);
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, xPos + 160, yPos, 15);
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, xPos + 161, yPos, 15);
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, xPos + 160, yPos + 1, 15);
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, xPos + 160, yPos - 1, 15);*/

				switch (this.oParent.CAPI.RNG.Next(4))
				{
					case 0:
						xPos += 0;
						yPos += -1;
						break;

					case 1:
						xPos += 1;
						yPos += 0;
						break;

					case 2:
						xPos += 0;
						yPos += 1;
						break;

					case 3:
						xPos += -1;
						yPos += 0;
						break;
				}

				iCloudSize--;

			} while (iCloudSize > 0 && xPos > 2 && xPos < 77 && yPos > 2 && yPos < 46);

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_0988_GenerateCloud");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_0a33()
		{
			this.oCPU.Log.EnterBlock("F7_0000_0a33()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0xd4);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 0x0);

		L0a41:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0x20), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)), 0xc);
			if (this.oCPU.Flags.L) goto L0a41;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 0x0);
			goto L0de2;

		L0a5c:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8))));

		L0a60:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8)), 0x32);
			if (this.oCPU.Flags.GE) goto L0a7f;

			this.oParent.GameData.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8))] = 0;
			goto L0a5c;

		L0a7f:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24))));

		L0a82:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)), 0x50);
			if (this.oCPU.Flags.GE) goto L0a90;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8), 0x0);
			goto L0a60;

		L0a90:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xae), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8), 0x0);
			goto L0c46;

		L0a9f:
			this.oCPU.AX.UInt16 = 0;

		L0aa1:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x1);
			this.oCPU.CX.UInt16 = this.oCPU.SBB_UInt16(this.oCPU.CX.UInt16, this.oCPU.CX.UInt16);
			this.oCPU.CX.UInt16 = this.oCPU.NEG_UInt16(this.oCPU.CX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.UInt16);
			if (this.oCPU.Flags.E) goto L0ab0;
			goto L0bfc;

		L0ab0:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8)), 0x0);
			if (this.oCPU.Flags.G) goto L0aba;
			goto L0b9a;

		L0aba:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L0ac5;
			this.oCPU.AX.UInt16 = 0xffff;
			goto L0ac7;

		L0ac5:
			this.oCPU.AX.UInt16 = 0;

		L0ac7:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xac), this.oCPU.AX.UInt16);
			goto L0b8b;

		L0ace:
			this.oCPU.AX.UInt16 = 0;

		L0ad0:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xac)));
			if (this.oCPU.Flags.GE) goto L0ad9;
			goto L0b9a;

		L0ad9:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24));
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xac)));
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8));
			if (this.oCPU.BX.UInt16 > 0)
			{
				this.oCPU.BX.UInt16--;
			}
			else
			{
				this.oCPU.AX.UInt16--;
				this.oCPU.BX.UInt16 = 49;
			}
			this.oCPU.AX.UInt16 = this.oParent.GameData.MapVisibility[this.oCPU.AX.UInt16, this.oCPU.BX.UInt16];
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xd0), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L0b00;
			goto L0b87;

		L0b00:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 0xffff);
			if (this.oCPU.Flags.E) goto L0b7c;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0b7c;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x0);
			goto L0b6c;

		L0b12:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))));

		L0b15:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x50);
			if (this.oCPU.Flags.GE) goto L0b69;
			
			this.oCPU.AX.UInt16 = this.oParent.GameData.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))];

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)));
			if (this.oCPU.Flags.NE) goto L0b45;

			this.oParent.GameData.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))] = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xd0));

		L0b45:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.CX.LowUInt8 = 0x7;
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, 0x1);
			this.oCPU.DI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.DI.UInt16, this.oCPU.SI.UInt16);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xd0));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			switch (this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)))
			{
				case 0:
					this.oParent.GameData.Continents[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xd0))].Size +=
						this.oParent.GameData.Continents[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))].Size;

					this.oParent.GameData.Continents[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))].Size = 0;
					break;

				case 1:
					this.oParent.GameData.Oceans[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xd0))].Size +=
						this.oParent.GameData.Oceans[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))].Size;

					this.oParent.GameData.Oceans[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))].Size = 0;
					break;

				default:
					throw new IndexOutOfRangeException("Continent selector out of range");
			}

			goto L0b12;

		L0b69:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))));

		L0b6c:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.G) goto L0b7c;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x0);
			goto L0b15;

		L0b7c:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xd0));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), this.oCPU.AX.UInt16);

			F7_0000_17cf();

		L0b87:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xac), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xac))));

		L0b8b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)), 0x4f);
			if (this.oCPU.Flags.L) goto L0b94;
			goto L0ace;

		L0b94:
			this.oCPU.AX.UInt16 = 0x1;
			goto L0ad0;

		L0b9a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0bcb;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0x0);
			if (this.oCPU.Flags.NE) goto L0bc4;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xae), 0x0);

		L0bac:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xae),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xae))));

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.CX.LowUInt8 = 0x7;
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xae));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			switch (this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)))
			{
				case 0:
					if (this.oParent.GameData.Continents[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xae))].Size != 0)
						goto L0bac;

					break;

				case 1:
					if (this.oParent.GameData.Oceans[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xae))].Size != 0)
						goto L0bac;

					break;

				default:
					throw new IndexOutOfRangeException("Continent selector out of range");
			}

		L0bc4:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xae));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), this.oCPU.AX.UInt16);

		L0bcb:
			this.oParent.GameData.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8))] = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.CX.LowUInt8 = 0x7;
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			switch (this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)))
			{
				case 0:
					this.oParent.GameData.Continents[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))].Size++;
					break;

				case 1:
					this.oParent.GameData.Oceans[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))].Size++;
					break;

				default:
					throw new IndexOutOfRangeException("Continent selector out of range");
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0x1);

			goto L0c06;

		L0bfc:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), 0xffff);

		L0c06:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24))));

		L0c09:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)), 0x50);
			if (this.oCPU.Flags.GE) goto L0c3e;

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8)));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xaa), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x0);
			if (this.oCPU.Flags.NE) goto L0c2e;

			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0x20), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0x20))));

		L0c2e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xaa)), 0xa);
			if (this.oCPU.Flags.NE) goto L0c38;
			goto L0a9f;

		L0c38:
			this.oCPU.AX.UInt16 = 0x1;
			goto L0aa1;

		L0c3e:
			F7_0000_17cf();

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8))));

		L0c46:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8)), 0x32);
			if (this.oCPU.Flags.GE) goto L0c5e;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 0x0);
			goto L0c09;

		L0c5e:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 0x0);

		L0c63:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0xce), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)), 0x10);
			if (this.oCPU.Flags.L) goto L0c63;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa4), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 0x1);
			goto L0cc9;

		L0c84:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xac));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.BP.UInt16);

			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 - 0xd0));
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, 0x1);

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xac));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.DI.UInt16 - 0xa4), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 - 0xd0));
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 - 0xce), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xac), this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xac))));

		L0ca6:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xac)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.G) goto L0c84;

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0xa4), this.oCPU.AX.UInt16);

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0xce), this.oCPU.AX.UInt16);

		L0cc6:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24))));

		L0cc9:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)), 0x40);
			if (this.oCPU.Flags.GE) goto L0d17;

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0xa4), 0xf);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8), 0x1);
			goto L0ce6;

		L0ce2:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8))));

		L0ce6:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8)), 0xf);
			if (this.oCPU.Flags.GE) goto L0cc6;
			
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.CX.LowUInt8 = 0x7;
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8));
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, 0x1);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.DI.UInt16 - 0xce));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			switch (this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)))
			{
				case 0:
					if (this.oParent.GameData.Continents[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.DI.UInt16 - 0xce))].Size >=
						this.oParent.GameData.Continents[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24))].Size)
						goto L0ce2;

					break;

				case 1:
					if (this.oParent.GameData.Oceans[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.DI.UInt16 - 0xce))].Size >=
						this.oParent.GameData.Oceans[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24))].Size)
						goto L0ce2;
					break;

				default:
					throw new IndexOutOfRangeException("Continent selector out of range");
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xac), 0xf);
			goto L0ca6;

		L0d17:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa4), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 0x0);
			goto L0d74;

		L0d24:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8))));

		L0d28:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8)), 0x32);
			if (this.oCPU.Flags.GE) goto L0d71;

			this.oCPU.AX.UInt16 = this.oParent.GameData.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8))];

			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0xa4));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa6), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0d24;

			// Instruction address 0x0000:0x0d67, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8)) + 0x32,
				this.oCPU.AX.UInt16);

			goto L0d24;

		L0d71:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24))));

		L0d74:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)), 0x50);
			if (this.oCPU.Flags.GE) goto L0d82;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa8), 0x0);
			goto L0d28;

		L0d82:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 0x1);

		L0d87:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.BP.UInt16);
			this.oCPU.SI.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SI.UInt16, 0xce);

			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.CX.LowUInt8 = 0x7;
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, this.oCPU.SI.UInt16);
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			switch (this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)))
			{
				case 0:
					this.oCPU.WriteInt16(this.oCPU.DS.UInt16, this.oCPU.SI.UInt16, this.oParent.GameData.Continents[this.oCPU.ReadInt16(this.oCPU.DS.UInt16, this.oCPU.SI.UInt16)].Size);
					break;

				case 1:
					this.oCPU.WriteInt16(this.oCPU.DS.UInt16, this.oCPU.SI.UInt16, this.oParent.GameData.Oceans[this.oCPU.ReadInt16(this.oCPU.DS.UInt16, this.oCPU.SI.UInt16)].Size);
					break;

				default:
					throw new IndexOutOfRangeException("Continent selector out of range");
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)), 0xf);
			if (this.oCPU.Flags.L)
				goto L0d87;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 0x1);

		L0db1:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.CX.LowUInt8 = 0x7;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			switch (this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)))
			{
				case 0:
					this.oParent.GameData.Continents[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24))].Size =
						this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0xce));
					break;

				case 1:
					this.oParent.GameData.Oceans[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24))].Size =
						this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0xce));
					break;

				default:
					throw new IndexOutOfRangeException("Continent selector out of range");
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)), 0xf);
			if (this.oCPU.Flags.L) goto L0db1;

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.CX.LowUInt8 = 0x7;
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			switch (this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)))
			{
				case 0:
					this.oParent.GameData.Continents[0].Size = 0;
					this.oParent.GameData.Continents[15].Size = 1;
					break;

				case 1:
					this.oParent.GameData.Oceans[0].Size = 0;
					this.oParent.GameData.Oceans[15].Size = 1;
					break;

				default:
					throw new IndexOutOfRangeException("Continent selector out of range");
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))));

		L0de2:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x2);
			if (this.oCPU.Flags.GE) goto L0df0;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 0x0);
			goto L0a82;

		L0df0:
			F7_0000_17cf();

			// Instruction address 0x0000:0x0e0c, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19e8_Rectangle, 0, 0);

			F7_0000_1188();

			F7_0000_1440(1);

			F7_0000_17cf();

			F7_0000_0f0a();

			// Instruction address 0x0000:0x0e49, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 0, 0, 79, 0, 15);

			// Instruction address 0x0000:0x0e68, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 0, 49, 79, 49, 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 0x0);

		L0e75:
			// Instruction address 0x0000:0x0e8d, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(this.oParent.CAPI.RNG.Next(80), 0, 7);

			// Instruction address 0x0000:0x0eae, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(this.oParent.CAPI.RNG.Next(80), 1, 7);

			// Instruction address 0x0000:0x0ecf, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(this.oParent.CAPI.RNG.Next(80), 48, 7);

			// Instruction address 0x0000:0x0ef0, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(this.oParent.CAPI.RNG.Next(80), 49, 7);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)), 0x14);
			if (this.oCPU.Flags.GE) goto L0f04;
			goto L0e75;

		L0f04:
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_0a33");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_0f0a()
		{
			this.oCPU.Log.EnterBlock("F7_0000_0f0a()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x42);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40), 0x0);

		L0f17:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			
			this.oParent.GameData.Continents[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40))].BuildSiteCount = 0;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40)), 0x10);
			if (this.oCPU.Flags.L) goto L0f17;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40), 0x0);
			goto L0f54;

		L0f32:
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.SI.UInt16 = (ushort)this.oParent.GameData.TerrainModifications[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].IrrigationEffect;
			this.oCPU.SI.UInt16 = this.oCPU.OR_UInt16(this.oCPU.SI.UInt16, this.oCPU.SI.UInt16);
			if (this.oCPU.Flags.GE) goto L0f51;
			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40));
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, 0x1);
			this.oCPU.AX.UInt16 = 0xffff;
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, this.oCPU.SI.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);

		L0f4e:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.DI.UInt16 - 0x38), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.DI.UInt16 - 0x38)), this.oCPU.AX.UInt16));

		L0f51:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40))));

		L0f54:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40)), 0x18);
			if (this.oCPU.Flags.GE) goto L0fb8;

			this.oCPU.AX.UInt16 = 0x13;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40));
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, 0x1);
			this.oCPU.DI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.DI.UInt16, this.oCPU.BP.UInt16);
			this.oCPU.DI.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.DI.UInt16, 0x38);

			this.oCPU.AX.LowUInt8 = (byte)this.oParent.GameData.TerrainTypes[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40))].Trade;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.LowUInt8 = 0x3;
			this.oCPU.IMUL_UInt8(this.oCPU.AX, 
				(byte)this.oParent.GameData.TerrainTypes[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40))].Food);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, this.oCPU.DI.UInt16, this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.UInt16 = 0xc;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.DX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.DX.UInt16, 0x2);
			if (this.oCPU.Flags.E) goto L0f9c;
			this.oCPU.CMP_UInt16(this.oCPU.DX.UInt16, 0xb);
			if (this.oCPU.Flags.E) goto L0f9c;

			this.oCPU.AX.LowUInt8 = (byte)this.oParent.GameData.TerrainTypes[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40))].Production;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, this.oCPU.DI.UInt16, this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, this.oCPU.DI.UInt16), this.oCPU.AX.UInt16));

		L0f9c:
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.SI.UInt16 = (ushort)this.oParent.GameData.TerrainModifications[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].MiningEffect;
			this.oCPU.SI.UInt16 = this.oCPU.OR_UInt16(this.oCPU.SI.UInt16, this.oCPU.SI.UInt16);
			if (this.oCPU.Flags.GE) goto L0f32;
			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40));
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, 0x1);
			this.oCPU.AX.UInt16 = 0xffff;
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, this.oCPU.SI.UInt16);
			goto L0f4e;

		L0fb8:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c), 0x2);
			goto L1174;

		L0fc0:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c));
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, 0x50);

			// Instruction address 0x0000:0x0fd3, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c)) + 80,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3e)), 0);

			// Instruction address 0x0000:0x0fec, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c)) + 80,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3e)) + 0x32, 0);

		L0ff4:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3e), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3e))));

		L0ff7:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3e)), 0x30);
			if (this.oCPU.Flags.L) goto L1000;
			goto L1171;

		L1000:
			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3e)));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x42), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xb);
			if (this.oCPU.Flags.E) goto L101f;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x2);
			if (this.oCPU.Flags.E) goto L101f;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.NE) goto L0fc0;

		L101f:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40), 0x0);

		L1029:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x0);

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.AX.UInt16 = (ushort)((short)(this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40))].X +
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c))));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = (ushort)((short)(this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40))].Y +
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3e))));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a), this.oCPU.AX.UInt16);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)),
				(short)this.oCPU.AX.UInt16);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x42), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x2);
			if (this.oCPU.Flags.E) goto L105f;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xb);
			if (this.oCPU.Flags.NE) goto L1078;

		L105f:
			this.oCPU.AX.UInt16 = 0x7;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.CX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xb;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a)));
			this.oCPU.CX.LowUInt8 = this.oCPU.ADD_UInt8(this.oCPU.CX.LowUInt8, this.oCPU.AX.LowUInt8);
			this.oCPU.TEST_UInt8(this.oCPU.CX.LowUInt8, 0x2);
			if (this.oCPU.Flags.NE) goto L1078;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), 0x2));

		L1078:
			// Instruction address 0x0000:0x1081, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.MapManagement.F0_2aea_1836_CellHasSpecialResource(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a))) ? 1 : 0);

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L1091;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x42), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x42)), 0xc));

		L1091:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x42));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0x38));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), this.oCPU.AX.UInt16));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40)), 0x9);
			if (this.oCPU.Flags.GE) goto L10a8;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), this.oCPU.AX.UInt16));

		L10a8:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40)), 0x0);
			if (this.oCPU.Flags.NE) goto L10b4;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), this.oCPU.AX.UInt16));

		L10b4:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), this.oCPU.AX.UInt16));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x40)), 0x14);
			if (this.oCPU.Flags.G) goto L10c6;
			goto L1029;

		L10c6:
			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3e)));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x42), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.E) goto L10f4;
			this.oCPU.AX.UInt16 = 0x7;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c)));
			this.oCPU.CX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xb;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3e)));
			this.oCPU.CX.LowUInt8 = this.oCPU.ADD_UInt8(this.oCPU.CX.LowUInt8, this.oCPU.AX.LowUInt8);
			this.oCPU.TEST_UInt8(this.oCPU.CX.LowUInt8, 0x2);
			if (this.oCPU.Flags.E) goto L10f4;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0x10));

		L10f4:
			// Instruction address 0x0000:0x1111, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)) - 120) / 8,
				1, 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, this.oCPU.DX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.SAR_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c));
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, 0x50);

			// Instruction address 0x0000:0x1138, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c)) + 80,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3e)), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x1151, size: 5
			this.oParent.CommonTools.F0_1000_104f_SetPixel(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c)) + 80,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3e)) + 0x32,
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));

			F7_0000_178e(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3e)));

			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oParent.GameData.Continents[this.oCPU.AX.UInt16].BuildSiteCount++;

			goto L0ff4;

		L1171:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c))));

		L1174:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3c)), 0x4e);
			if (this.oCPU.Flags.GE) goto L1182;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3e), 0x2);
			goto L0ff7;

		L1182:
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_0f0a");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_1188()
		{
			this.oCPU.Log.EnterBlock("F7_0000_1188()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x26);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);

			// Instruction address 0x0000:0x119b, size: 5
			for (int i = 0; i < 260; i++)
			{
				this.oParent.GameData.LandPathfinding[i] = 0;
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x0);
			goto L142c;

		L11ab:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);

			F7_0000_176d(
				(short)this.oCPU.SI.UInt16,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.E) goto L11d4;

			// Instruction address 0x0000:0x11c3, size: 5
			this.oCPU.AX.Int16 = (short)this.oParent.MapManagement.F0_2aea_1942_GetCellGroupID(
				this.oCPU.SI.Int16, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20), this.oCPU.SI.UInt16);
			goto L125a;

		L11d4:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)),
				(short)this.oCPU.SI.UInt16);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.E) goto L1262;

			// Instruction address 0x0000:0x11ec, size: 5
			this.oCPU.AX.Int16 = (short)this.oParent.MapManagement.F0_2aea_1942_GetCellGroupID(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)),
				(short)this.oCPU.SI.UInt16);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), this.oCPU.SI.UInt16);

		L1200:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)), 0xffff);
			if (this.oCPU.Flags.E) goto L1209;
			goto L128e;

		L1209:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a))));

		L120c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a)), 0xd);
			if (this.oCPU.Flags.L) goto L1215;
			goto L1429;

		L1215:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.INC_UInt16(this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a));
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.INC_UInt16(this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), 0xffff);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)),
				(short)this.oCPU.AX.UInt16);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L1243;
			goto L11ab;

		L1243:
			// Instruction address 0x0000:0x1249, size: 5
			this.oCPU.AX.Int16 = (short)this.oParent.MapManagement.F0_2aea_1942_GetCellGroupID(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20), this.oCPU.AX.UInt16);

		L125a:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), this.oCPU.AX.UInt16);
			goto L1200;

		L1262:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc));
			this.oCPU.DI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.DI.UInt16);

			F7_0000_176d((short)this.oCPU.SI.UInt16, (short)this.oCPU.DI.UInt16);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.E) goto L1200;

			// Instruction address 0x0000:0x127a, size: 5
			this.oCPU.AX.Int16 = (short)this.oParent.MapManagement.F0_2aea_1942_GetCellGroupID(
				this.oCPU.SI.Int16, this.oCPU.DI.Int16);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20), this.oCPU.SI.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), this.oCPU.DI.UInt16);
			goto L1200;

		L128e:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 0x1);
			goto L12fb;

		L1295:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);

			F7_0000_176d(
				(short)this.oCPU.SI.UInt16,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.E) goto L12be;

			// Instruction address 0x0000:0x12ad, size: 5
			this.oCPU.AX.Int16 = (short)this.oParent.MapManagement.F0_2aea_1942_GetCellGroupID(
				this.oCPU.SI.Int16,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), this.oCPU.SI.UInt16);
			goto L1354;

		L12be:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				(short)this.oCPU.SI.UInt16);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L12d5;
			goto L135c;

		L12d5:
			// Instruction address 0x0000:0x12d9, size: 5
			this.oCPU.AX.Int16 = (short)this.oParent.MapManagement.F0_2aea_1942_GetCellGroupID(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				(short)this.oCPU.SI.UInt16);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c), this.oCPU.SI.UInt16);

		L12ed:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L12f8;
			goto L138b;

		L12f8:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))));

		L12fb:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)), 0x4);
			if (this.oCPU.Flags.LE) goto L1304;
			goto L1209;

		L1304:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))];

			this.oCPU.AX.UInt16 = (ushort)((short)direction.X * 4);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = (ushort)((short)direction.Y * 4);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe), 0xffff);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				(short)this.oCPU.AX.UInt16);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L133d;
			goto L1295;

		L133d:
			// Instruction address 0x0000:0x1343, size: 5
			this.oCPU.AX.Int16 = (short)this.oParent.MapManagement.F0_2aea_1942_GetCellGroupID(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), this.oCPU.AX.UInt16);

		L1354:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c), this.oCPU.AX.UInt16);
			goto L12ed;

		L135c:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.DI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.DI.UInt16);

			F7_0000_176d((short)this.oCPU.SI.UInt16, (short)this.oCPU.DI.UInt16);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L1375;
			goto L12ed;

		L1375:
			// Instruction address 0x0000:0x1377, size: 5
			this.oCPU.AX.Int16 = (short)this.oParent.MapManagement.F0_2aea_1942_GetCellGroupID(
				(short)this.oCPU.SI.UInt16,
				(short)this.oCPU.DI.UInt16);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), this.oCPU.SI.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c), this.oCPU.DI.UInt16);
			goto L12ed;

		L138b:
			// Instruction address 0x0000:0x139e, size: 5
			this.oParent.UnitGoTo.F0_2e31_111c(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)),
				0, 20);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xffff);
			if (this.oCPU.Flags.NE) goto L13b1;
			goto L12f8;

		L13b1:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 20);
			if (this.oCPU.Flags.L) goto L13b9;
			goto L12f8;

		L13b9:
			this.oCPU.AX.UInt16 = 13;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a));

			this.oCPU.AX.LowUInt8 = 0x1;
			this.oCPU.CX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));
			this.oCPU.CX.LowUInt8 = this.oCPU.DEC_UInt8(this.oCPU.CX.LowUInt8);
			this.oCPU.AX.LowUInt8 = this.oCPU.SHL_UInt8(this.oCPU.AX.LowUInt8, this.oCPU.CX.LowUInt8);

			this.oParent.GameData.LandPathfinding[(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)) * 13) + this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a))] |= 
				this.oCPU.AX.LowUInt8;

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))];

			this.oCPU.AX.UInt16 = (ushort)((short)direction.X);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = (ushort)((short)direction.Y);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.BX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x0);
			if (this.oCPU.Flags.GE) goto L13f2;
			goto L12f8;

		L13f2:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x14);
			if (this.oCPU.Flags.L) goto L13fb;
			goto L12f8;

		L13fb:
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.GE) goto L1402;
			goto L12f8;

		L1402:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xd);
			if (this.oCPU.Flags.L) goto L140a;
			goto L12f8;

		L140a:
			this.oCPU.AX.UInt16 = 13;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));

			this.oCPU.AX.LowUInt8 = 0x1;
			this.oCPU.CX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));
			this.oCPU.CX.LowUInt8 = this.oCPU.ADD_UInt8(this.oCPU.CX.LowUInt8, 0x3);
			this.oCPU.CX.LowUInt8 = this.oCPU.AND_UInt8(this.oCPU.CX.LowUInt8, 0x7);
			this.oCPU.AX.LowUInt8 = this.oCPU.SHL_UInt8(this.oCPU.AX.LowUInt8, this.oCPU.CX.LowUInt8);

			this.oParent.GameData.LandPathfinding[(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)) * 13) + this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))] |=
				this.oCPU.AX.LowUInt8;

			goto L12f8;

		L1429:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));

		L142c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x14);
			if (this.oCPU.Flags.GE) goto L143a;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a), 0x0);
			goto L120c;

		L143a:
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_1188");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="flag"></param>
		public void F7_0000_1440(ushort flag)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_1440({flag})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x18);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);

			// Instruction address 0x0000:0x1453, size: 5
			this.oParent.CAPI.memset(0x7f38, 0, 0x104);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x0);
			goto L172a;

		L1463:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);

			F7_0000_176d(
				(short)this.oCPU.SI.UInt16,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L147d;

			F7_0000_178e(
				(short)this.oCPU.SI.UInt16,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));

			goto L14f3;

		L147d:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)),
				(short)this.oCPU.SI.UInt16);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L1494;

			F7_0000_178e(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)),
				(short)this.oCPU.SI.UInt16);

			goto L14f3;

		L1494:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc));
			this.oCPU.DI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.DI.UInt16);

			F7_0000_176d((short)this.oCPU.SI.UInt16, (short)this.oCPU.DI.UInt16);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L14ad;

			F7_0000_178e((short)this.oCPU.SI.UInt16, (short)this.oCPU.DI.UInt16);

			goto L14f3;

		L14ad:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)), 0xffff);
			if (this.oCPU.Flags.NE) goto L14ff;

		L14b3:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18))));

		L14b6:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)), 0xc);
			if (this.oCPU.Flags.L) goto L14bf;
			goto L171d;

		L14bf:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.INC_UInt16(this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18));
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.INC_UInt16(this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 0xffff);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)),
				(short)this.oCPU.AX.UInt16);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.E) goto L14ed;
			goto L1463;

		L14ed:
			F7_0000_178e(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));

		L14f3:			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), this.oCPU.AX.UInt16);
			goto L14ad;

		L14ff:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 0x1);
			goto L155b;

		L1506:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);

			F7_0000_176d(
				(short)this.oCPU.SI.UInt16,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L1520;

			F7_0000_178e(
				(short)this.oCPU.SI.UInt16,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));

			goto L159e;

		L1520:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				(short)this.oCPU.SI.UInt16);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L1537;

			F7_0000_178e(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				(short)this.oCPU.SI.UInt16);

			goto L159e;

		L1537:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.DI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.DI.UInt16);

			F7_0000_176d((short)this.oCPU.SI.UInt16, (short)this.oCPU.DI.UInt16);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L1550;

			F7_0000_178e((short)this.oCPU.SI.UInt16, (short)this.oCPU.DI.UInt16);

			goto L159e;

		L1550:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L15aa;

		L1558:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))));

		L155b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)), 0x8);
			if (this.oCPU.Flags.LE) goto L1564;
			goto L14b3;

		L1564:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))];

			this.oCPU.AX.UInt16 = (ushort)((short)direction.X * 4);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = (ushort)((short)direction.Y * 4);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				(short)this.oCPU.AX.UInt16);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.E) goto L1598;
			goto L1506;

		L1598:
			F7_0000_178e(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));

		L159e:			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe), this.oCPU.AX.UInt16);
			goto L1550;

		L15aa:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12), 0x0);
			goto L15c5;

		L15c2:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))));

		L15c5:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)), 0x4);
			if (this.oCPU.Flags.LE) goto L15ce;
			goto L1690;

		L15ce:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))];

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), (ushort)((short)direction.X)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), (ushort)((short)direction.Y)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0x4);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L160a;

			// Instruction address 0x0000:0x15fe, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.MapManagement.F0_2aea_1326_CheckMapCoordinates(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))) ? 1 : 0);

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L160d;

		L160a:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))));

		L160d:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);

			F7_0000_176d(
				(short)this.oCPU.SI.UInt16,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L1631;

			// Instruction address 0x0000:0x1625, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.MapManagement.F0_2aea_1326_CheckMapCoordinates((short)this.oCPU.SI.UInt16,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))) ? 1 : 0);

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L1634;

		L1631:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))));

		L1634:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				(short)this.oCPU.SI.UInt16);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L1658;

			// Instruction address 0x0000:0x164c, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.MapManagement.F0_2aea_1326_CheckMapCoordinates(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), (short)this.oCPU.SI.UInt16) ? 1 : 0);

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L165b;

		L1658:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))));

		L165b:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.SI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.DI.UInt16 = this.oCPU.INC_UInt16(this.oCPU.DI.UInt16);

			F7_0000_176d((short)this.oCPU.SI.UInt16, (short)this.oCPU.DI.UInt16);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L167f;

			// Instruction address 0x0000:0x1673, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.MapManagement.F0_2aea_1326_CheckMapCoordinates((short)this.oCPU.SI.UInt16, (short)this.oCPU.DI.UInt16) ? 1 : 0);

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L1682;

		L167f:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))));

		L1682:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0x2);
			if (this.oCPU.Flags.L) goto L168b;
			goto L15c2;

		L168b:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), 0x0);

		L1690:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)), 0x0);
			if (this.oCPU.Flags.NE) goto L16a8;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)), 0xb);
			if (this.oCPU.Flags.E) goto L169f;
			goto L1558;

		L169f:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)), 0x3);
			if (this.oCPU.Flags.E) goto L16a8;
			goto L1558;

		L16a8:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))];

			this.oCPU.DI.UInt16 = (ushort)((short)direction.Y);
			this.oCPU.DI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.DI.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)));

			if ((short)this.oCPU.DI.UInt16 >= 12)
				goto L1558;

			this.oCPU.AX.UInt16 = 0xd;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.BX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.BX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)));

			this.oCPU.AX.LowUInt8 = 0x1;
			this.oCPU.CX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));
			this.oCPU.CX.LowUInt8 = this.oCPU.DEC_UInt8(this.oCPU.CX.LowUInt8);
			this.oCPU.AX.LowUInt8 = this.oCPU.SHL_UInt8(this.oCPU.AX.LowUInt8, this.oCPU.CX.LowUInt8);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x7f38), 
				this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x7f38)), this.oCPU.AX.LowUInt8));

			this.oCPU.AX.UInt16 = (ushort)((short)direction.X);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.DI.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.GE) goto L16e8;
			goto L1558;

		L16e8:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x14);
			if (this.oCPU.Flags.L) goto L16f0;
			goto L1558;

		L16f0:
			this.oCPU.DI.UInt16 = this.oCPU.OR_UInt16(this.oCPU.DI.UInt16, this.oCPU.DI.UInt16);
			if (this.oCPU.Flags.GE) goto L16f7;
			goto L1558;

		L16f7:
			this.oCPU.CMP_UInt16(this.oCPU.DI.UInt16, 0xc);
			if (this.oCPU.Flags.LE) goto L16ff;
			goto L1558;

		L16ff:
			this.oCPU.AX.UInt16 = 0xd;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.BX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.BX.UInt16, this.oCPU.DI.UInt16);
			this.oCPU.AX.LowUInt8 = 0x1;
			this.oCPU.CX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));
			this.oCPU.CX.LowUInt8 = this.oCPU.ADD_UInt8(this.oCPU.CX.LowUInt8, 0x3);
			this.oCPU.CX.LowUInt8 = this.oCPU.AND_UInt8(this.oCPU.CX.LowUInt8, 0x7);
			this.oCPU.AX.LowUInt8 = this.oCPU.SHL_UInt8(this.oCPU.AX.LowUInt8, this.oCPU.CX.LowUInt8);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x7f38), 
				this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x7f38)), this.oCPU.AX.LowUInt8));
			goto L1558;

		L171d:
			if (flag != 0)
			{
				F7_0000_17cf();
			}
		
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));

		L172a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x14);
			if (this.oCPU.Flags.GE) goto L1738;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), 0x0);
			goto L14b6;

		L1738:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), 0x0);

		L173d:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18));
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x7f38), 
				this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x7f38)), 0xe0));
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x802f), 
				this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x802f)), 0xe));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)), 0xc);
			if (this.oCPU.Flags.L) goto L173d;
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0x7f38, this.oCPU.AND_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, 0x7f38), 0x7f));
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0x7f43, this.oCPU.AND_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, 0x7f43), 0xdf));
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0x802f, this.oCPU.AND_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, 0x802f), 0xfd));
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0x803a, this.oCPU.AND_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, 0x803a), 0xf7));
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_1440");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F7_0000_176d(short xPos, short yPos)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_176d({xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;

			// Instruction address 0x0000:0x177c, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(this.oParent.Var_aa_Rectangle.ScreenID, xPos, yPos);

			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x2ba6));
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_176d");

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F7_0000_178e(short xPos, short yPos)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_178e({xPos}, {yPos})");

			// function body
			// Instruction address 0x0000:0x17a1, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(this.oParent.Var_aa_Rectangle.ScreenID, xPos, yPos + 50);

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_178e");

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_17cf()
		{
			this.oCPU.Log.EnterBlock("F7_0000_17cf()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x1a);

			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b62), 0x2);
			if (this.oCPU.Flags.L) goto L185a;

			// Instruction address 0x0000:0x17e4, size: 5
			this.oParent.CAPI.kbhit();

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L185a;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b62), 0x5);
			if (this.oCPU.Flags.GE) goto L1820;
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x3b62, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b62)));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b62), 0x5);
			if (this.oCPU.Flags.NE) goto L184f;

			// Instruction address 0x0000:0x1816, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 40, 160, 240, 8, 0);

			goto L184f;

		L1820:
			this.oCPU.AX.UInt16 = this.oParent.Var_5c_TickCount;
			this.oCPU.DoEvents();
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.UInt16 = 0x3c;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x6800, this.oCPU.AX.UInt16);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, 0x6800), 0x1);
			if (this.oCPU.Flags.E) goto L183a;
			this.oCPU.AX.UInt16 = 0xf;
			goto L183d;

		L183a:
			this.oCPU.AX.UInt16 = 0x3;

		L183d:
			// Instruction address 0x0000:0x1847, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToScreen0("BUILDING NEW WORLD...", 160, 160, this.oCPU.AX.LowUInt8);

		L184f:
			this.oParent.Var_aa_Rectangle.ScreenID = 1;

			goto L1bdd;

		L185a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b62), 0x0);
			if (this.oCPU.Flags.NE) goto L18a1;

			// Instruction address 0x0000:0x1869, size: 5
			this.oParent.CAPI.fopen("story.txt", "rt");

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x6804, this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x3b62, 0x1);
			this.oCPU.AX.UInt16 = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x6806, this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x6800, this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x188a, size: 5
			this.oParent.CAPI.strcpy(0xba06, "");

			this.oParent.Var_aa_Rectangle.FontID = 7;

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x6802, 0x0);

		L18a1:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6802), 0x0);
			if (this.oCPU.Flags.E) goto L18b0;

			// Instruction address 0x0000:0x18a8, size: 5
			this.oParent.CommonTools.F0_1000_0a4e_Soundtimer();

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x6800, this.oCPU.AX.UInt16);

		L18b0:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6806);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6800), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.GE) goto L18c4;

			this.oParent.Var_aa_Rectangle.ScreenID = 1;

			goto L1bd8;

		L18c4:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b62), 0x2);
			if (this.oCPU.Flags.E) goto L18f3;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6802), 0x28);
			if (this.oCPU.Flags.GE) goto L18f3;

			// Instruction address 0x0000:0x18df, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 160, 160, 3);

			// Instruction address 0x0000:0x18eb, size: 5
			this.oParent.CommonTools.F0_1182_0134_WaitTimer(5);

		L18f3:
			// Instruction address 0x0000:0x18ff, size: 5
			this.oParent.CAPI.fscanf((short)this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6804), "%[^\n]\n", 0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xffff);
			if (this.oCPU.Flags.NE) goto L1912;
			goto L1b6a;

		L1912:
			// Instruction address 0x0000:0x1912, size: 5
			this.oParent.CAPI.kbhit();

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L1925;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x67fc), 0x0);
			if (this.oCPU.Flags.E) goto L1925;
			goto L1b6a;

		L1925:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b64), 0x1);
			if (this.oCPU.Flags.LE) goto L1952;

			// Instruction address 0x0000:0x194a, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 0, 160, 320, 8, this.oParent.Var_aa_Rectangle, 0, 160);

		L1952:
			// Instruction address 0x0000:0x1956, size: 5
			this.oParent.CommonTools.F0_1182_0134_WaitTimer(10);

			// Instruction address 0x0000:0x196b, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 160, 160, 3);

			// Instruction address 0x0000:0x1977, size: 5
			this.oParent.CommonTools.F0_1182_0134_WaitTimer(5);

			// Instruction address 0x0000:0x198c, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 160, 160, 11);

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x6806, 0x0);

			// Instruction address 0x0000:0x199e, size: 5
			this.oParent.CAPI.strlen(0xba06);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x3);
			if (this.oCPU.Flags.LE) goto L19db;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6802), 0x0);
			if (this.oCPU.Flags.NE) goto L19cf;

			// Instruction address 0x0000:0x19b2, size: 5
			this.oParent.CommonTools.F0_1000_033e_ResetWaitTimer();

			// Instruction address 0x0000:0x19bb, size: 5
			this.oParent.CommonTools.F0_1000_0a32_PlayTune(1, 0);

			// Instruction address 0x0000:0x19c7, size: 5
			this.oParent.CommonTools.F0_1000_0a32_PlayTune(4, 0);

		L19cf:
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x6806, this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6806), 0x2));
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x6802, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6802)));
			goto L1b29;

		L19db:
			// Instruction address 0x0000:0x19e3, size: 5
			this.oParent.CAPI.strcpy((ushort)(this.oCPU.BP.UInt16 - 0x10), "birth0.pic");

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b64);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x3b64, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b64)));
			this.oCPU.WriteUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xb), this.oCPU.ADD_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xb)), this.oCPU.AX.LowUInt8));
			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L1a19;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 0x1);
			goto L1a11;

		L1a03:
			// Instruction address 0x0000:0x1a06, size: 5
			this.oParent.CommonTools.F0_1000_042b_StopPaletteCycleSlot(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))));

		L1a11:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b68);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.LE) goto L1a03;

		L1a19:
			// Instruction address 0x0000:0x1a21, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(2, 0, 0, (ushort)(this.oCPU.BP.UInt16 - 0x10), 0);

			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L1a41;

			// Instruction address 0x0000:0x1a39, size: 5
			this.oParent.CommonTools.F0_1000_04d4_TransformPaletteToColor(8, Color.FromRgb(0, 0, 0));

		L1a41:
			// Instruction address 0x0000:0x1a59, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.NE) goto L1a6b;
			goto L1b29;

		L1a6b:
			// Instruction address 0x0000:0x1a73, size: 5
			this.oParent.CAPI.strcpy((ushort)(this.oCPU.BP.UInt16 - 0x9), "pal");

			// Instruction address 0x0000:0x1a83, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, (ushort)(this.oCPU.BP.UInt16 - 0x10), 0xc5be);

			// Instruction address 0x0000:0x1a93, size: 5
			this.oParent.CommonTools.F0_1000_04aa_TransformPalette(8, 0xc5be);

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x3b68, 0x0);
			goto L1af8;

		L1aa3:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b66);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x3b66, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b66)));
			this.oCPU.ES.UInt16 = 0x3710; // segment
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.ES.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x0));
			this.oCPU.AX.HighUInt8 = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12), this.oCPU.AX.UInt16);
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b66);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x3b66, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b66)));
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.ES.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x0));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), this.oCPU.AX.UInt16);
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b66);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x3b66, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b66)));
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.ES.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x0));
			this.oCPU.CX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0x12c;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.DIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a), this.oCPU.AX.UInt16);

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x3b68, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b68)));

			// Instruction address 0x0000:0x1af0, size: 5
			this.oParent.CommonTools.F0_1000_0382_AddPaletteCycleSlot(
				this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b68),
				this.oCPU.AX.UInt16,
				this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)),
				this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));

		L1af8:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b66);
			this.oCPU.ES.UInt16 = 0x3710; // segment
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.ES.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0x0)), 0x0);
			if (this.oCPU.Flags.NE) goto L1aa3;
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x3b66, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b66)));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 0x1);
			goto L1b21;

		L1b13:
			// Instruction address 0x0000:0x1b16, size: 5
			this.oParent.CommonTools.F0_1000_03fa_StartPaletteCycleSlot(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))));

		L1b21:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b68);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.LE) goto L1b13;

		L1b29:
			// Instruction address 0x0000:0x1b2d, size: 5
			this.oParent.CAPI.strlen(0xba06);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x13);
			if (this.oCPU.Flags.LE) goto L1b3e;
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x6806, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6806)));

		L1b3e:
			// Instruction address 0x0000:0x1b5d, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(0x3710, (ushort)((this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6802) << 1) + 0x83)),
				(45 * this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0x6806)) + this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0x6800),
				32767);

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x6806, this.oCPU.AX.UInt16);
			goto L1bbe;

		L1b6a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1b7c;

			// Instruction address 0x0000:0x1b74, size: 5
			this.oParent.CommonTools.F0_1182_0134_WaitTimer(180);

		L1b7c:
			// Instruction address 0x0000:0x1b80, size: 5
			this.oParent.CAPI.fclose((short)this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6804));

			// Instruction address 0x0000:0x1b8c, size: 5
			this.oParent.CommonTools.F0_1000_0a32_PlayTune(1, 0);

			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L1bb8;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 0x1);
			goto L1bb0;

		L1ba2:
			// Instruction address 0x0000:0x1ba5, size: 5
			this.oParent.CommonTools.F0_1000_042b_StopPaletteCycleSlot(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))));

		L1bb0:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b68);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.LE) goto L1ba2;

		L1bb8:
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x3b62, 0x2);

		L1bbe:
			// Instruction address 0x0000:0x1bc1, size: 5
			this.oParent.CommonTools.F0_1000_0846(0);

			this.oParent.Var_aa_Rectangle.ScreenID = 1;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x3b62), 0x2);
			if (this.oCPU.Flags.E) goto L1bdd;

		L1bd8:
			this.oCPU.AX.UInt16 = 0x1;
			goto L1bdf;

		L1bdd:
			this.oCPU.AX.UInt16 = 0;

		L1bdf:
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_17cf");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="globalWarmingCount"></param>
		public void F7_0000_1be3(short globalWarmingCount)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_1be3({globalWarmingCount})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0xe);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);

			// Instruction address 0x0000:0x1bf2, size: 5
			this.oParent.CAPI.strcpy(0xba06, "Global temperature\nrises! Icecaps melt.\nSevere Drought.\n");

			this.oParent.Overlay_21.F21_0000_0000(-1);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x0);
			goto L1d45;

		L1c11:
			// Instruction address 0x0000:0x1c2a, size: 5
			this.oParent.MapManagement.F0_2aea_16ee(6,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));

			goto L1c8a;

		L1c34:
			this.oCPU.AX.UInt16 = 0xb;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
			this.oCPU.CX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xd;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));
			this.oCPU.CX.LowUInt8 = this.oCPU.ADD_UInt8(this.oCPU.CX.LowUInt8, this.oCPU.AX.LowUInt8);
			this.oCPU.CX.HighUInt8 = 0;
			this.oCPU.CX.UInt16 = this.oCPU.AND_UInt16(this.oCPU.CX.UInt16, 0x7);
			this.oCPU.CMP_UInt16(this.oCPU.CX.UInt16, (ushort)globalWarmingCount);
			if (this.oCPU.Flags.NE) goto L1cac;

			this.oParent.GameData.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))] |= 1;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x1);
			if (this.oCPU.Flags.LE)
			{
				// Instruction address 0x0000:0x1c82, size: 5
				this.oParent.CommonTools.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
					this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)),
					14);
			}
			else
			{
				// Instruction address 0x0000:0x1c82, size: 5
				this.oParent.CommonTools.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
					this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)),
					6);
			}

		L1c8a:
			this.oCPU.AX.UInt16 = this.oParent.GameData.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))];
			this.oCPU.DX.UInt16 = 0x1;
			this.oCPU.CX.LowUInt8 = (byte)(this.oParent.GameData.HumanPlayerID & 0xff);
			this.oCPU.DX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DX.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.TEST_UInt16(this.oCPU.AX.UInt16, this.oCPU.DX.UInt16);
			if (this.oCPU.Flags.E) goto L1cac;

			// Instruction address 0x0000:0x1ca4, size: 5
			this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));

		L1cac:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))));

		L1caf:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0x32);
			if (this.oCPU.Flags.L) goto L1cb8;
			goto L1d42;

		L1cb8:
			// Instruction address 0x0000:0x1cbe, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x3);
			if (this.oCPU.Flags.G) goto L1cac;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x1);

		L1cd8:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))];

			// Instruction address 0x0000:0x1ced, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)) + direction.X,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)) + direction.Y);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.NE) goto L1cfd;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))));

		L1cfd:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), 0x8);
			if (this.oCPU.Flags.LE) goto L1cd8;
			this.oCPU.AX.UInt16 = 0x7;
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, (ushort)globalWarmingCount);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)));
			if (this.oCPU.Flags.LE) goto L1d14;
			goto L1c34;

		L1d14:
			this.oParent.GameData.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))] |= 1;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x3);
			if (this.oCPU.Flags.NE)
			{
				// Instruction address 0x0000:0x1c18, size: 5
				this.oParent.CommonTools.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
					this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)),
					3);
			}
			else
			{
				// Instruction address 0x0000:0x1c18, size: 5
				this.oParent.CommonTools.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
					this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)),
					11);
			}
			goto L1c11;

		L1d42:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))));

		L1d45:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x50);
			if (this.oCPU.Flags.GE) goto L1d53;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0x0);
			goto L1caf;

		L1d53:
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_1be3");
		}
	}
}
