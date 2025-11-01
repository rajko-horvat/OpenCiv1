using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Segment_2d05
	{
		private CivGame oParent;
		private VCPU oCPU;

		public Segment_2d05(CivGame parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="flag"></param>
		/// <returns></returns>
		public ushort F0_2d05_0031(ushort stringPtr, int xPos, int yPos, ushort flag)
		{
			this.oCPU.Log.EnterBlock($"F0_2d05_0031(0x{stringPtr:x4}, {xPos}, {yPos}, {flag})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x12);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.CMP_UInt16(flag, 0x0);
			if (this.oCPU.Flags.E) goto L0043;

			// Instruction address 0x2d05:0x003e, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

		L0043:
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2fa2, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9c, this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3c), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L006f;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xffff);
			if (this.oCPU.Flags.NE) goto L006f;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x8066), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L006f;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd206), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L006f;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

		L006f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2f9a), 0xffff);
			if (this.oCPU.Flags.E) goto L0081;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2f9a);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

		L0081:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb1ec, 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd2e2, 0x1);

			// Instruction address 0x2d05:0x0094, size: 5
			this.oParent.Graphics.F0_VGA_11ae_GetTextHeight(this.oParent.Var_aa_Rectangle.FontID);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2fa4, this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x9);
			if (this.oCPU.Flags.NE) goto L00a8;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2fa4, this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2fa4)));

		L00a8:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3936), 0xffff);
			if (this.oCPU.Flags.E) goto L00b5;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2fa4, 0x8);

		L00b5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x16);

			if (yPos == 139)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x8);
			}

			if ((yPos & 1) != 0 && yPos != 139)
			{
				// Instruction address 0x2d05:0x00e1, size: 5
				this.oParent.Graphics.F0_VGA_038c_GetPixel(0, xPos, yPos);

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);
			}

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xf);
			if (this.oCPU.Flags.NE) goto L00fc;
			this.oCPU.AX.Word = 0x3;
			goto L00ff;

		L00fc:
			this.oCPU.AX.Word = 0xf;

		L00ff:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x654c, this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.NE) goto L010e;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);

		L010e:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2fa4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

			// Instruction address 0x2d05:0x011c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x2d05:0x012f, size: 3
			F0_2d05_0475(stringPtr, xPos, yPos, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2f9a));

			// Instruction address 0x2d05:0x0135, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdb38), 0x0);
			if (this.oCPU.Flags.E) goto L014d;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdb38, 0x0);
			this.oCPU.AX.Word = 0xffff;
			goto L0470;

		L014d:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3936), 0xffff);
			if (this.oCPU.Flags.E) goto L0159;

			this.oParent.MeetWithKing.F6_0000_1b33();

		L0159:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd2e2, 0x0);
			this.oParent.Var_db3a_MouseButton = 0x0;

			// Instruction address 0x2d05:0x0165, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223_UpdateMouse();

			this.oCPU.CMP_UInt16(this.oParent.Var_db3a_MouseButton, 0x0);
			if (this.oCPU.Flags.NE) goto L0177;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x0);
			if (this.oCPU.Flags.E) goto L01db;

		L0177:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2fa2, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oParent.Var_db3a_MouseButton, 0x2);
			if (this.oCPU.Flags.NE) goto L018a;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9c, this.oCPU.AX.Word);

		L018a:
			this.oCPU.AX.Word = this.oParent.Var_db3e_MouseYPos;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)((short)yPos));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x4);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2fa4);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb1ec));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			if (xPos > (short)this.oParent.Var_db3c_MouseXPos)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0xffff);
			}
			else
			{
				if ((short)this.oParent.Var_db3c_MouseXPos > this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xde0e))
				{
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0xffff);
				}
			}
		
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb276));
			if (this.oCPU.Flags.E) goto L01cd;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));

		L01c8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			goto L0217;

		L01cd:
			this.oCPU.CMP_UInt16(this.oParent.Var_db3a_MouseButton, 0x0);

		L01d2:
			if (this.oCPU.Flags.NE) goto L0217;

		L01d4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);
			goto L0217;

		L01db:
			// Instruction address 0x2d05:0x01db, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0217;

			// Instruction address 0x2d05:0x01e5, size: 3
			F0_2d05_0ac9_GetNavigationKey();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x20);
			if (this.oCPU.Flags.NE) goto L01f3;
			goto L0377;

		L01f3:
			if (this.oCPU.Flags.LE) goto L01f8;
			goto L03e3;

		L01f8:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xd);
			if (this.oCPU.Flags.NE) goto L0200;
			goto L0377;

		L0200:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1b);
			if (this.oCPU.Flags.NE) goto L0208;
			goto L0392;

		L0208:
			goto L03fd;

		L020b:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd208);
			this.oCPU.AX.Word = this.oCPU.DEC_UInt16(this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0217;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L0217:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.L) goto L0233;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd208);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0233;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x8066), 0x0);
			if (this.oCPU.Flags.NE) goto L0233;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd206), 0x0);
			if (this.oCPU.Flags.E) goto L0238;

		L0233:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0xffff);

		L0238:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0243;
			goto L0337;

		L0243:
			// Instruction address 0x2d05:0x0243, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xffff);
			if (this.oCPU.Flags.E) goto L02ba;

			// Instruction address 0x2d05:0x027c, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				xPos + 3,
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xb1ec)) *
					this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x2fa4)) + yPos + 4,
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd4c8) + 5,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				11, (byte)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xffff);
			if (this.oCPU.Flags.E) goto L02ba;

			// Instruction address 0x2d05:0x02b2, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				xPos + 3,
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xb1ec)) *
					this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x2fa4)) + yPos + 4,
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd4c8) + 5,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				3, (byte)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));

		L02ba:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xffff);
			if (this.oCPU.Flags.E) goto L032c;

			// Instruction address 0x2d05:0x02ee, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				xPos + 3,
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xb1ec)) *
					this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x2fa4)) + yPos + 4,
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd4c8) + 5,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				(byte)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				11);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xffff);
			if (this.oCPU.Flags.E) goto L032c;

			// Instruction address 0x2d05:0x0324, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				xPos + 3,
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xb1ec)) *
					this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x2fa4)) + yPos + 4,
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd4c8) + 5,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				(byte)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				3);

		L032c:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			// Instruction address 0x2d05:0x0332, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

		L0337:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x0);
			if (this.oCPU.Flags.NE) goto L0340;
			goto L014d;

		L0340:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0349;
			goto L0450;

		L0349:
			// Instruction address 0x2d05:0x0349, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L0358;
			goto L043d;

		L0358:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2f9c), 0x0);
			if (this.oCPU.Flags.NE) goto L0362;
			goto L0406;

		L0362:
			this.oCPU.AX.Word = 0xb;
			goto L0409;

		L0368:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.G) goto L0371;
			goto L0217;

		L0371:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			goto L0217;

		L0377:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb276));
			goto L01d2;

		L0386:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9c, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			goto L0217;

		L0392:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0xffff);
			goto L01d4;

		L039a:
			this.oParent.CivState.GameSettingFlags.Sound ^= true;

			if (!this.oParent.CivState.GameSettingFlags.Sound) goto L03a9;
			goto L0217;

		L03a9:
			// Instruction address 0x2d05:0x03ad, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			goto L0217;

		L03b8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L03bb:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x20);
			if (this.oCPU.Flags.L) goto L03c4;
			goto L0217;

		L03c4:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xdc4a)), 0xff);
			if (this.oCPU.Flags.E) goto L03b8;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xdc4a));
			this.oCPU.AX.Low = this.oCPU.AND_UInt8(this.oCPU.AX.Low, 0x1f);
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CX.Low = this.oCPU.AND_UInt8(this.oCPU.CX.Low, 0x1f);
			this.oCPU.CMP_UInt8(this.oCPU.AX.Low, this.oCPU.CX.Low);
			if (this.oCPU.Flags.NE) goto L03b8;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			goto L01c8;

		L03e3:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2300);
			if (this.oCPU.Flags.E) goto L0386;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2f00);
			if (this.oCPU.Flags.E) goto L039a;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4800);
			if (this.oCPU.Flags.NE) goto L03f5;
			goto L0368;

		L03f5:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x5000);
			if (this.oCPU.Flags.NE) goto L03fd;
			goto L020b;

		L03fd:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			goto L03bb;

		L0406:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x654c);

		L0409:
			// Instruction address 0x2d05:0x0435, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
				xPos + 3,
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xb1ec)) *
					this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x2fa4)) + yPos + 4,
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd4c8) + 5,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				11,
				this.oCPU.AX.Low);

		L043d:
			// Instruction address 0x2d05:0x0441, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(20);

			// Instruction address 0x2d05:0x0449, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			goto L0456;

		L0450:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9c, 0x0);

		L0456:
			this.oParent.Var_2f9e_MessageBoxStyle = CivMessageBoxStyleEnum.Default;

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9a, 0xffff);

			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2fa0, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd206, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb276, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd7f2, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));

		L0470:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2d05_0031");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="param4"></param>
		public void F0_2d05_0475(ushort stringPtr, int xPos, int yPos, ushort param4)
		{
			this.oCPU.Log.EnterBlock($"F0_2d05_0475(0x{stringPtr:x4}, {xPos}, {yPos}, {param4})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x5c);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x654e, 0x0);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd2e2), 0x1);
			if (this.oCPU.Flags.E) goto L048d;
			goto L07df;

		L048d:
			// Instruction address 0x2d05:0x0494, size: 5
			this.oParent.Graphics.F0_VGA_11ae_GetTextHeight(this.oParent.Var_aa_Rectangle.FontID);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2fa4, this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x9);
			if (this.oCPU.Flags.NE) goto L04a8;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2fa4, this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2fa4)));

		L04a8:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3936), 0xffff);
			if (this.oCPU.Flags.E) goto L04b5;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2fa4, 0x8);

		L04b5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), 0x0);

		L04ba:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xdc4a), 0xff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x20);
			if (this.oCPU.Flags.L) goto L04ba;
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x658e, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4c8, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), this.oCPU.AX.Word);
			goto L053b;

		L04de:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0x0);
			if (this.oCPU.Flags.NE) goto L051c;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.SI.Word = stringPtr;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c), this.oCPU.AX.Low);
			this.oCPU.CMP_UInt8(this.oCPU.AX.Low, 0x20);
			if (this.oCPU.Flags.E) goto L04f7;
			this.oCPU.CMP_UInt8(this.oCPU.AX.Low, 0x5f);
			if (this.oCPU.Flags.NE) goto L051c;

		L04f7:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)), 0x20);
			if (this.oCPU.Flags.GE) goto L050c;
			this.oCPU.SI.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = stringPtr;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x1));
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xdc4a), this.oCPU.AX.Low);

		L050c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb1ec), 0xffff);
			if (this.oCPU.Flags.NE) goto L0519;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x658e);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb1ec, this.oCPU.AX.Word);

		L0519:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a))));

		L051c:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.SI.Word = stringPtr;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word));

			// Instruction address 0x2d05:0x052d, size: 5
			this.oParent.Graphics.F0_VGA_115d_GetCharWidth(this.oParent.Var_aa_Rectangle.FontID, this.oCPU.AX.Low);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), this.oCPU.AX.Word));

		L0538:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56))));

		L053b:
			// Instruction address 0x2d05:0x053e, size: 5
			this.oParent.MSCAPI.strlen(stringPtr);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)));
			if (this.oCPU.Flags.LE) goto L057d;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.SI.Word = stringPtr;
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word)), 0xa);
			if (this.oCPU.Flags.NE) goto L04de;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4c8);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L0564;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4c8, this.oCPU.AX.Word);

		L0564:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x658e, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x658e)));
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x658e);
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x654e), this.oCPU.AX.Word);
			goto L0538;

		L057d:
			// Instruction address 0x2d05:0x0592, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x658e),
				0, (192 - yPos) / this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x2fa4));

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x658e, this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)xPos;
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4c8));
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xde0e, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x658e);
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2fa4));
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, (ushort)yPos);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2fa0), 0x0);
			if (this.oCPU.Flags.E) goto L05c5;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)), 0x2));

		L05c5:
			// Instruction address 0x2d05:0x05c8, size: 5
			this.oParent.MSCAPI.strlen(stringPtr);

			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = stringPtr;
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word - 0x1)), 0xa);
			if (this.oCPU.Flags.E) goto L05de;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), 
				this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a))));

		L05de:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd208, this.oCPU.AX.Word);

			if ((yPos & 1) == 0)
				goto L05ed;

			goto L075b;

		L05ed:
			if (this.oParent.Var_2f9e_MessageBoxStyle != CivMessageBoxStyleEnum.Default) goto L0613;

			// Instruction address 0x2d05:0x060d, size: 3
			F0_2d05_096c_FillRectangleWithDoubleShadow(xPos, yPos,
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xde0e) - xPos, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)) - yPos, 7);

			goto L075b;

		L0613:
			this.oCPU.BX.Word = (ushort)((short)this.oParent.Var_2f9e_MessageBoxStyle);
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x2d05:0x0621, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x50), this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2fa6)));

			if (this.oParent.Var_2f9e_MessageBoxStyle == CivMessageBoxStyleEnum.DefenseMinister || this.oParent.Var_2f9e_MessageBoxStyle == CivMessageBoxStyleEnum.DomesticAdvisor ||
				this.oParent.Var_2f9e_MessageBoxStyle == CivMessageBoxStyleEnum.ForeignMinister || this.oParent.Var_2f9e_MessageBoxStyle == CivMessageBoxStyleEnum.ScienceAdvisor) goto L0640;

			// Instruction address 0x2d05:0x0638, size: 5
			this.oParent.MSCAPI.strcat((ushort)(this.oCPU.BP.Word - 0x50), " report:");

		L0640:
			// Instruction address 0x2d05:0x0644, size: 5
			this.oParent.Segment_1182.F0_1182_00ef_GetStringWidth((ushort)(this.oCPU.BP.Word - 0x50));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), this.oCPU.AX.Word);
			this.oCPU.SI.Word = (ushort)xPos;
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, 0x8);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xde0e), this.oCPU.SI.Word);
			if (this.oCPU.Flags.GE) goto L0661;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xde0e, this.oCPU.SI.Word);

		L0661:
			this.oCPU.SI.Word = (ushort)((short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)) - yPos));

			// Instruction address 0x2d05:0x0677, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((short)this.oCPU.SI.Word + 8, 61, 999);

			// Instruction address 0x2d05:0x0699, size: 3
			F0_2d05_096c_FillRectangleWithDoubleShadow(xPos - 42, yPos - 8,
				(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xde0e) - xPos) + 42, (short)this.oCPU.AX.Word, 7);

			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.SI.Word - 0x34);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), this.oCPU.AX.Word);

			if (this.oParent.Var_2f9e_MessageBoxStyle == CivMessageBoxStyleEnum.DefenseMinister || this.oParent.Var_2f9e_MessageBoxStyle == CivMessageBoxStyleEnum.DomesticAdvisor ||
				this.oParent.Var_2f9e_MessageBoxStyle == CivMessageBoxStyleEnum.ForeignMinister || this.oParent.Var_2f9e_MessageBoxStyle == CivMessageBoxStyleEnum.ScienceAdvisor) goto L06d2;
			
			// Instruction address 0x2d05:0x06c8, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, xPos - 40, yPos - 5,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xdf62 + ((int)this.oParent.Var_2f9e_MessageBoxStyle * 2))));
			goto L0715;

		L06d2:
			// ??? This is dialog image being drawn for future reference
			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)) > 0)
			{
				// Instruction address 0x2d05:0x070d, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
					(40 * (int)this.oParent.Var_2f9e_MessageBoxStyle) + 40, 140, 40, 60,
					this.oParent.Var_aa_Rectangle,
					xPos - 40, ((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)) - 1) + yPos) - 6);
			}
			else
			{
				// Instruction address 0x2d05:0x070d, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
					(40 * (int)this.oParent.Var_2f9e_MessageBoxStyle) + 40, 140, 40, 60,
					this.oParent.Var_aa_Rectangle, xPos - 40, yPos - 6);
			}

		L0715:
			// Instruction address 0x2d05:0x072b, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0((ushort)(this.oCPU.BP.Word - 0x50),
				xPos + 5, yPos - 4, 15);

			// Instruction address 0x2d05:0x0742, size: 5
			this.oParent.Segment_1182.F0_1182_00ef_GetStringWidth((ushort)(this.oCPU.BP.Word - 0x50));

			// Instruction address 0x2d05:0x0753, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos + 5, yPos + 3, xPos + 5, yPos + 3, 11);

		L075b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2fa0), 0x0);
			if (this.oCPU.Flags.E) goto L0799;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), this.oParent.Var_aa_Rectangle.FontID);
			this.oParent.Var_aa_Rectangle.FontID = 2;
			
			// Instruction address 0x2d05:0x0787, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("(HELP AVAILABLE)",
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xde0e) - 74,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)) - 4,
				10);

			this.oParent.Var_aa_Rectangle.FontID = this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));

		L0799:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x8066), 0x0);
			if (this.oCPU.Flags.E) goto L07df;

			// Instruction address 0x2d05:0x07b6, size: 5
			this.oParent.Segment_1182.F0_1182_002a_DrawString("OK", 
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xde0e) - 0x11),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)) - 8),
				11);
			
			// Instruction address 0x2d05:0x07d9, size: 3
			F0_2d05_0a05_DrawRectangle(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xde0e) - 20,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)) - 10,
				20, 10, 11);

		L07df:
			this.oCPU.BX.Word = stringPtr;
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x20);
			if (this.oCPU.Flags.E) goto L07ec;
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x5f);
			if (this.oCPU.Flags.NE) goto L07f0;

		L07ec:
			this.oCPU.AX.Word = 0;
			goto L07f3;

		L07f0:
			this.oCPU.AX.Word = 0xffff;

		L07f3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);
			
			this.oParent.Var_aa_Rectangle.FrontColor = (byte)this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x654c);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), 0x0);
			goto L08fd;

		L0808:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb276));
			if (this.oCPU.Flags.E) goto L081b;
			this.oCPU.AX.Word = 0x3;
			goto L081d;

		L081b:
			this.oCPU.AX.Word = 0;

		L081d:
			// Instruction address 0x2d05:0x0834, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(this.oCPU.DI.Word,
				xPos + 5,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)) * this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x2fa4)) + yPos + 5,
				(byte)this.oCPU.AX.Word);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x654e));
			this.oCPU.BX.Word = this.oCPU.ADD_UInt16(this.oCPU.BX.Word, stringPtr);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x20);
			goto L08ce;

		L0849:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)), 0x0);
			if (this.oCPU.Flags.GE) goto L0883;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2fa4), 0x9);
			if (this.oCPU.Flags.LE) goto L0883;
			
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			// Instruction address 0x2d05:0x087b, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0((ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x654e)) + stringPtr),
				xPos + 5,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)) * this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x2fa4)) + yPos + 6,
				0);

		L0883:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)), 0x0);
			if (this.oCPU.Flags.GE) goto L088e;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x654c);
			goto L08a3;

		L088e:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb276));
			if (this.oCPU.Flags.E) goto L08a1;
			this.oCPU.AX.Word = 0x3;
			goto L08a3;

		L08a1:
			this.oCPU.AX.Word = 0;

		L08a3:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			// Instruction address 0x2d05:0x08c6, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0((ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x654e)) + stringPtr),
				xPos + 5,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)) * this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x2fa4)) + yPos + 5,
				this.oCPU.AX.Low);

		L08ce:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6550));
			this.oCPU.BX.Word = stringPtr;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word - 0x1), 0xa);

		L08de:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6550));
			this.oCPU.SI.Word = stringPtr;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c), this.oCPU.AX.Low);
			this.oCPU.CMP_UInt8(this.oCPU.AX.Low, 0x20);
			if (this.oCPU.Flags.E) goto L08f7;
			this.oCPU.CMP_UInt8(this.oCPU.AX.Low, 0x5f);
			if (this.oCPU.Flags.NE) goto L08fa;

		L08f7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a))));

		L08fa:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56))));

		L08fd:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x658e);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0963;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd2e2), 0x0);
			if (this.oCPU.Flags.NE) goto L0920;
			this.oCPU.AX.Word = param4;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)));
			
			// Instruction address 0x2d05:0x0913, size: 5
			this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.GE) goto L08de;

		L0920:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6550));
			this.oCPU.BX.Word = this.oCPU.ADD_UInt16(this.oCPU.BX.Word, stringPtr);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x1), 0x0);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)), 0x0);
			if (this.oCPU.Flags.GE) goto L0939;
			goto L0849;

		L0939:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f2));
			if (this.oCPU.Flags.NE) goto L094a;
			goto L0849;

		L094a:
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x654e));
			this.oCPU.DI.Word = this.oCPU.ADD_UInt16(this.oCPU.DI.Word, stringPtr);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.DI.Word, 0x5e);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)), 0x0);
			if (this.oCPU.Flags.L) goto L095d;
			goto L0808;

		L095d:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x654c);
			goto L081d;

		L0963:
			this.oCPU.AX.Word = param4;

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2d05_0475");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="mode"></param>
		public void F0_2d05_096c_FillRectangleWithDoubleShadow(int xPos, int yPos, int width, int height, ushort mode)
		{
			// function body
			if (mode == 7 && this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2f98) != 0)
			{
				// Instruction address 0x2d05:0x098c, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_03ce_FillRectangleWithPattern(xPos + 1, yPos + 1, width, height);
			}
			else
			{
				// Instruction address 0x2d05:0x09b1, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos + 1, yPos + 1, width, height, mode);
			}
		
			this.oParent.Var_aa_Rectangle.BackColor = (byte)mode;

			// Instruction address 0x2d05:0x09e1, size: 3
			F0_2d05_0a66_DrawShadowRectangle(xPos + 1, yPos + 1, width, height, 15, 8);

			// Instruction address 0x2d05:0x09fd, size: 3
			F0_2d05_0a05_DrawRectangle(xPos, yPos, width + 2, height + 2, 0);
		}

		/// <summary>
		/// Draws a rectangle
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="mode"></param>
		public void F0_2d05_0a05_DrawRectangle(int xPos, int yPos, int width, int height, ushort mode)
		{
			// function body
			// Instruction address 0x2d05:0x0a1d, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos, yPos, xPos + width, yPos, mode);

			// Instruction address 0x2d05:0x0a34, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos, yPos + height, xPos + width, yPos + height, mode);

			// Instruction address 0x2d05:0x0a45, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos + width, yPos, xPos + width, yPos + height, mode);

			// Instruction address 0x2d05:0x0a5a, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos, yPos, xPos, yPos + height, mode);
		}

		/// <summary>
		/// Draws a shaddow rectangle
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="mode"></param>
		/// <param name="mode1"></param>
		public void F0_2d05_0a66_DrawShadowRectangle(int xPos, int yPos, int width, int height, ushort mode, ushort mode1)
		{
			// function body
			// Instruction address 0x2d05:0x0a7e, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos, yPos, xPos + width, yPos, mode1);

			// Instruction address 0x2d05:0x0a95, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos, yPos + height, xPos + width, yPos + height, mode);

			// Instruction address 0x2d05:0x0aa6, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos + width, yPos, xPos + width, yPos + height, mode1);

			// Instruction address 0x2d05:0x0abd, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos, yPos + 1, xPos, yPos + height, mode);
		}

		/// <summary>
		/// Get navigation key
		/// </summary>
		/// <returns></returns>
		public int F0_2d05_0ac9_GetNavigationKey()
		{
			this.oCPU.Log.EnterBlock("F0_2d05_0ac9_GetNavigationKey()");

			// function body

			// Instruction address 0x2d05:0x0acf, size: 5
			int iKey = this.oParent.MSCAPI.getch();

			switch (iKey)
			{
				case 0:
					break;

				case 0x4800: // Up
				case 0x487e: // Another code for Up
					iKey = 0x4800; // Up
					break;

				case 0x4d00: // Right
				case 0xf400: // Another code for Right
					iKey = 0x4d00; // Right
					break;

				case 0x5000: // Down
				case 0x5060: // Another code for Down
					iKey = 0x5000; // Down
					break;

				case 0x4b00: // Left
				case 0x4b7c: // Another code for Left
					iKey = 0x4b00; // Left
					break;

				case 0x4838: // Shift + Up
					iKey = 0x4838; // Shift + Up
					break;

				case 0x4d36: // Shift + Right
				case 0x4d46: // Another code for Shift + Right
					iKey = 0x4d36; // Shift + Right
					break;

				case 0x5032: // Shift + Down
					iKey = 0x5032; // Shift + Down
					break;

				case 0x4b34: // Shift + Left
				case 0x4b43: // Another code for Shift + Left
					iKey = 0x4b34; // Shift + Left
					break;

				case 0x4700: // Home
				case 0x475c: // Another code for Home
					iKey = 0x4700; // Home
					break;

				case 0x4f00: // End
					iKey = 0x4f00; // End
					break;

				case 0x4737: // shift + Home
					iKey = 0x4737; // Shift + Home
					break;

				case 0x4f31: // Shift + End
					iKey = 0x4f31; // Shift + End
					break;

				case 0x4900: // Page Up
					iKey = 0x4900; // Page Up
					break;

				case 0x5100: // Page Down
					iKey = 0x5100; // Page Down
					break;

				case 0x4939: // Shift + Page Up
					iKey = 0x4939; // Shift + Page Up
					break;

				case 0x5133: // Shift + Page Down
					iKey = 0x5133; // Shift + Page Down
					break;

				default:
					//iKey &= 0xff;
					break;
			}

			this.oCPU.AX.Word = (ushort)((short)iKey);

			// Far return
			this.oCPU.Log.ExitBlock("F0_2d05_0ac9_GetNavigationKey");

			return iKey;
		}
	}
}
