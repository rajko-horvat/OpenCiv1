using System;
using System.IO;
using IRB.VirtualCPU;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class GameLoadAndSave
	{
		private Game oParent;
		private CPU oCPU;

		public GameLoadAndSave(Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="flag"></param>
		/// <returns></returns>
		public ushort F11_0000_0000(ushort flag)
		{
			this.oCPU.Log.EnterBlock($"F11_0000_0000({flag})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x681a, 0x1);

			// Instruction address 0x0000:0x000c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			F11_0000_05f8();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L0020;
			goto L00f7;

		L0020:
			this.oCPU.CMPWord(flag, 0xffff);
			if (this.oCPU.Flags.E) goto L0029;
			goto L00ae;

		L0029:
			// Instruction address 0x0000:0x0031, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "\x008cSelect Load File...\n");

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd74e, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L0044:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x41cd, this.oCPU.AX.Low);

			F11_0000_0103_LoadGame(0x41c6, 1);
			
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L006d;

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd74e, this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd74e), this.oCPU.AX.Word));

		L006d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xa);
			if (this.oCPU.Flags.B) goto L0044;

			// Instruction address 0x0000:0x0076, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x0087, size: 5
			this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 48, 65, 1);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xe168, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0092, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xe168);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd74e));
			if (this.oCPU.Flags.NE) goto L00b4;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xe168, 0xffff);
			goto L00b4;

		L00ae:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xe168, flag);

		L00b4:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe168), 0xffff);
			if (this.oCPU.Flags.E) goto L00dc;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xe168);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x41cd, this.oCPU.AX.Low);

			F11_0000_0103_LoadGame(0x41c6, 0);
			
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L00dc;

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xe168, 0xffff);

		L00dc:
			// Instruction address 0x0000:0x00e5, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			// Instruction address 0x0000:0x00ed, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe168);
			goto L00ff;

		L00f7:
			// Instruction address 0x0000:0x00f7, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.AX.Word = 0xffff;

		L00ff:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F11_0000_0000");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="filenamePtr"></param>
		/// <param name="flag"></param>
		/// <returns></returns>
		public ushort F11_0000_0103_LoadGame(ushort filenamePtr, ushort flag)
		{
			this.oCPU.Log.EnterBlock($"F11_0000_0103_LoadGame(0x{filenamePtr:x4}, {flag})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x10);

			// Instruction address 0x0000:0x0114, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(filenamePtr + 9), "SVE");

			this.oCPU.CMPWord(flag, 0x0);
			if (this.oCPU.Flags.NE) goto L0125;
			goto L02fd;

		L0125:
			// Instruction address 0x0000:0x012c, size: 5
			this.oParent.MSCAPI.open(filenamePtr, 0x8000);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x681e, this.oCPU.AX.Word);
			
			if (this.oCPU.AX.Word == 0xffff)
			{
				// Instruction address 0x0000:0x02d9, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " (EMPTY)\n");
			}
			else
			{
				// Instruction address 0x0000:0x014c, size: 5
				this.oParent.MSCAPI.lseek((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), 2, 0);

				// Instruction address 0x0000:0x0160, size: 5
				this.oParent.MSCAPI.read((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), 0x6822, 2);

				// Instruction address 0x0000:0x0175, size: 5
				this.oParent.MSCAPI.lseek((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), 8, 0);

				// Instruction address 0x0000:0x0189, size: 5
				this.oParent.MSCAPI.read((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), 0x6826, 2);

				// Instruction address 0x0000:0x0199, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " ");

				// Instruction address 0x0000:0x01ae, size: 5
				this.oParent.MSCAPI.lseek((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), 10, 0);

				// Instruction address 0x0000:0x01c2, size: 5
				this.oParent.MSCAPI.read((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), 0x6824, 2);

				this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6824);
				this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
				// Instruction address 0x0000:0x01d8, size: 5
				this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x33a2)));

				// Instruction address 0x0000:0x01e8, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " ");

				// Instruction address 0x0000:0x0207, size: 5
				this.oParent.MSCAPI.lseek((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e),
					((14 * (int)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6822))) + 16), 0);

				// Instruction address 0x0000:0x021b, size: 5
				this.oParent.MSCAPI.read((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), (ushort)(this.oCPU.BP.Word - 0x10), 14);

				// Instruction address 0x0000:0x022b, size: 5
				this.oParent.MSCAPI.strcat(0xba06, (ushort)(this.oCPU.BP.Word - 0x10));

				// Instruction address 0x0000:0x024a, size: 5
				this.oParent.MSCAPI.lseek((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e),
					((12 * (int)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6822))) + 0x80), 0);

				// Instruction address 0x0000:0x025e, size: 5
				this.oParent.MSCAPI.read((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), (ushort)(this.oCPU.BP.Word - 0x10), 0xc);

				// Instruction address 0x0000:0x026e, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ", ");

				// Instruction address 0x0000:0x027e, size: 5
				this.oParent.MSCAPI.strcat(0xba06, (ushort)(this.oCPU.BP.Word - 0x10));

				// Instruction address 0x0000:0x028e, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "/");

				// Instruction address 0x0000:0x02b8, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oParent.MSCAPI.itoa(Math.Abs((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6826)), 10));

				if (this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6826) < 0)
				{
					// Instruction address 0x0000:0x02d9, size: 5
					this.oParent.MSCAPI.strcat(0xba06, " BC\n");
				}
				else
				{
					// Instruction address 0x0000:0x02d9, size: 5
					this.oParent.MSCAPI.strcat(0xba06, " AD\n");
				}
			}
		
			// Instruction address 0x0000:0x02e5, size: 5
			this.oParent.MSCAPI.close((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), 0xffff);
			if (this.oCPU.Flags.E) goto L02f9;

			L02f4:
			this.oCPU.AX.Word = 0x1;
			goto L0366;

		L02f9:
			this.oCPU.AX.Word = 0;
			goto L0366;

		L02fd:
			string path = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, filenamePtr));

			F11_0000_083b_LoadGameData(path);

			// Instruction address 0x0000:0x0310, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			this.oParent.Var_aa_Rectangle.ScreenID = 2;

			this.oParent.GameInitAndIntro.F7_0000_1440(0);

			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6820, 0x1);
			goto L0340;

		L033c:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6820, this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6820)));

		L0340:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6820), 0x8);
			if (this.oCPU.Flags.L) goto L033c;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe168), 0x4);
			if (this.oCPU.Flags.GE) goto L0353;

			this.oCPU.AX.Word = 0x1;
			goto L0356;

		L0353:
			this.oCPU.AX.Word = 0x2;

		L0356:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdf60, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3484, 0xfffd);
			this.oParent.GameState.SpaceshipFlags &= 0x7ffe;
			goto L02f4;

		L0366:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F11_0000_0103_LoadGame");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		public void F11_0000_036a(ushort param1)
		{
			this.oCPU.Log.EnterBlock($"F11_0000_036a({param1})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x681c, 0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x681a, 0);

			// Instruction address 0x0000:0x0378, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			F11_0000_05f8();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L0391;
			goto L04d0;

		L0391:
			// Instruction address 0x0000:0x0399, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "\x008cSelect Save File...\n");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L03a6:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x41cd, this.oCPU.AX.Low);

			F11_0000_0103_LoadGame(0x41c6, 1);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x4);
			if (this.oCPU.Flags.L) goto L03a6;

			// Instruction address 0x0000:0x03d3, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xe168), 0, 3);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9a, this.oCPU.AX.Word);
			this.oCPU.CMPWord(param1, 0xffff);
			if (this.oCPU.Flags.NE) goto L0405;

			// Instruction address 0x0000:0x03e4, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x03f5, size: 5
			this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 48, 33, 1);

			param1 = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x0400, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

		L0405:
			this.oCPU.CMPWord(param1, 0xffff);
			if (this.oCPU.Flags.NE) goto L040e;
			goto L04d0;

		L040e:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xe168, param1);
			this.oCPU.AX.Low = (byte)param1;
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x41cd, this.oCPU.AX.Low);

			F11_0000_04ef_SaveGame(0x41c6);
			
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L042e;
			goto L04d0;

		L042e:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681c);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0448;

			// Instruction address 0x0000:0x043e, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " Game has been saved.\n");

			goto L0478;

		L0448:
			// Instruction address 0x0000:0x0450, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " Game NOT saved.\n");

			// Instruction address 0x0000:0x0470, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 64, 127, 192, 34, 12);

		L0478:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681c), 0xd);
			if (this.oCPU.Flags.NE) goto L048f;

			// Instruction address 0x0000:0x0487, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Write access denied.\n");

		L048f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681c), 0x1c);
			if (this.oCPU.Flags.NE) goto L04a6;

			// Instruction address 0x0000:0x049e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Disk Full.\n");

		L04a6:
			// Instruction address 0x0000:0x04ae, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Press key to continue.\n");

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd206, 0x1);

			// Instruction address 0x0000:0x04c8, size: 5
			this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 64, 127, 1);

		L04d0:
			// Instruction address 0x0000:0x04d9, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x0000:0x04e6, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F11_0000_036a");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="filenamePtr"></param>
		/// <returns></returns>
		public ushort F11_0000_04ef_SaveGame(ushort filenamePtr)
		{
			this.oCPU.Log.EnterBlock($"F11_0000_04ef_SaveGame(0x{filenamePtr:x4})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdb38, 0x1);

			// Instruction address 0x0000:0x0503, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " ");

			// Instruction address 0x0000:0x0512, size: 5
			this.oParent.MSCAPI.strcat(0xba06, filenamePtr);

			// Instruction address 0x0000:0x0522, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n ");

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.DifficultyLevel;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0538, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x33a2)));

			// Instruction address 0x0000:0x0548, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " ");

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x055e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19a2)));

			// Instruction address 0x0000:0x056e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n ");

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0584, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			// Instruction address 0x0000:0x0594, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "/");

			// Instruction address 0x0000:0x059c, size: 5
			this.oParent.Segment_1238.F0_1238_1720_GetCurrentYearAsString();

			// Instruction address 0x0000:0x05a9, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n ... save in progress.\n");

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd206, 0x1);

			// Instruction address 0x0000:0x05c3, size: 5
			this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 64, 86, 1);

			string path = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, filenamePtr));
			F11_0000_08f6_SaveGameData(path);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F11_0000_04ef_SaveGame");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public ushort F11_0000_05f8()
		{
			this.oCPU.Log.EnterBlock("F11_0000_05f8()");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4384), 0xffff);
			if (this.oCPU.Flags.NE) goto L0615;

			// Instruction address 0x0000:0x0609, size: 5
			this.oParent.MSCAPI._dos_getdrive(0x4384);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384,
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4384)));

		L0615:
			// Instruction address 0x0000:0x0629, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 15);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681a), 0x0);
			if (this.oCPU.Flags.NE) goto L063d;

			// Instruction address 0x0000:0x0638, size: 5
			this.oParent.Segment_1866.F0_1866_260e();

		L063d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681a), 0x0);
			if (this.oCPU.Flags.E) goto L0649;
			// Instruction address 0x0000:0x0651, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "  Which drive contains your\n    saved game files?\n\n            ");
			goto L064c;

		L0649:
			// Instruction address 0x0000:0x0651, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "  Which drive contains your\n     Save Game disk?\n\n            ");

		L064c:
			// Instruction address 0x0000:0x065d, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x4384);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x41);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba05), this.oCPU.AX.Low);

			// Instruction address 0x0000:0x0678, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ":\n\n    Press drive letter and\nReturn when disk is inserted.\n");

			// Instruction address 0x0000:0x0688, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "    Press Escape to cancel.\n");

			// Instruction address 0x0000:0x069f, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_0088_DrawTextBlock(99, 80, 72, 0);

			// Instruction address 0x0000:0x06a7, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x41);
			if (this.oCPU.Flags.E) goto L06b9;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x61);
			if (this.oCPU.Flags.NE) goto L06bf;

		L06b9:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384, 0x0);

		L06bf:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x42);
			if (this.oCPU.Flags.E) goto L06cb;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x62);
			if (this.oCPU.Flags.NE) goto L06d1;

			L06cb:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384, 0x1);

		L06d1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x43);
			if (this.oCPU.Flags.E) goto L06dd;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x63);
			if (this.oCPU.Flags.NE) goto L06e3;

		L06dd:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384, 0x2);

		L06e3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x44);
			if (this.oCPU.Flags.E) goto L06ef;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x64);
			if (this.oCPU.Flags.NE) goto L06f5;

		L06ef:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384, 0x3);

		L06f5:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x45);
			if (this.oCPU.Flags.E) goto L0701;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x65);
			if (this.oCPU.Flags.NE) goto L0707;

		L0701:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384, 0x4);

		L0707:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x46);
			if (this.oCPU.Flags.E) goto L0713;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x66);
			if (this.oCPU.Flags.NE) goto L0719;

		L0713:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384, 0x5);

		L0719:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x1b);
			if (this.oCPU.Flags.NE) goto L0725;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384, 0xffff);

		L0725:
			// Instruction address 0x0000:0x073d, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 80, 88, 160, 24, 15);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xd);
			if (this.oCPU.Flags.E) goto L0754;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x1b);
			if (this.oCPU.Flags.E) goto L0754;
			goto L063d;

		L0754:
			// Instruction address 0x0000:0x0769, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 8, 8, 304, 184, 15);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4384), 0xffff);
			if (this.oCPU.Flags.E) goto L07c7;

			F11_0000_07d6(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4384));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L07c7;

			// Instruction address 0x0000:0x078f, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "No Disk in Drive A.\n");

			// Instruction address 0x0000:0x079b, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x4384);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x41);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba03), this.oCPU.AX.Low);

			// Instruction address 0x0000:0x07ba, size: 5
			this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 100, 80, 1);

			this.oCPU.AX.Word = 0xffff;
			goto L07d2;

		L07c7:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x4384);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x61);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x41c6, this.oCPU.AX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4384);

		L07d2:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F11_0000_05f8");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <returns></returns>
		public ushort F11_0000_07d6(ushort param1)
		{
			this.oCPU.Log.EnterBlock($"F11_0000_07d6({param1})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x12);
			this.oCPU.CMPWord(param1, 0x1);
			if (this.oCPU.Flags.LE) goto L07e7;

		L07e2:
			this.oCPU.AX.Word = 0x1;
			goto L0837;

		L07e7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), param1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L0806:
			// Instruction address 0x0000:0x080e, size: 5
			this.oParent.MSCAPI._bios_disk(4, (ushort)(this.oCPU.BP.Word - 0x12));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.TESTWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xff00);
			if (this.oCPU.Flags.E) goto L07e2;

			// Instruction address 0x0000:0x0824, size: 5
			this.oParent.MSCAPI._bios_disk(0, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3);
			if (this.oCPU.Flags.L) goto L0806;
			this.oCPU.AX.Word = 0;

		L0837:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F11_0000_07d6");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public bool F11_0000_083b_LoadGameData(string path)
		{
			path = path.ToUpper();

			this.oCPU.Log.EnterBlock($"F11_0000_083b_LoadGameData('{path}')");

			// function body
			bool bSuccess = false;
			string filename = Path.GetFileNameWithoutExtension(MSCAPI.GetDOSFileName(path));

			try
			{
				// read map file
				byte[] temp;

				if (!this.oParent.Graphics.Screens.GetValueByKey(2).LoadPIC($"{CPU.DefaultCIVPath}{filename}.MAP", 0, 0, out temp))
					throw new Exception($"Can't read Map file '{filename}.MAP'");

				// read sve file
				FileStream reader = new FileStream($"{CPU.DefaultCIVPath}{filename}.SVE", FileMode.Open);
				this.oParent.GameState.TurnCount = ReadInt16(reader);
				this.oParent.GameState.HumanPlayerID = ReadInt16(reader);
				this.oParent.GameState.PlayerFlags = ReadInt16(reader);
				this.oParent.GameState.RandomSeed = ReadUInt16(reader);
				this.oParent.GameState.Year = ReadInt16(reader);
				this.oParent.GameState.DifficultyLevel = ReadInt16(reader);
				this.oParent.GameState.ActiveCivilizations = ReadInt16(reader);
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID = ReadInt16(reader);
				ReadData(reader, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19a2), 0x70);
				ReadData(reader, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1992), 0x60);
				ReadData(reader, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1982), 0x58);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].Coins = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].ResearchProgress = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].ActiveUnits.Length; j++)
					{
						this.oParent.GameState.Players[i].ActiveUnits[j] = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].UnitsInProduction.Length; j++)
					{
						this.oParent.GameState.Players[i].UnitsInProduction[j] = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].DiscoveredTechnologyCount = ReadInt16(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 5; j++)
					{
						this.oParent.GameState.Players[i].DiscoveredTechnologyFlags[j] = ReadUInt16(reader);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].GovernmentType = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].Continents.Length; j++)
					{
						this.oParent.GameState.Players[i].Continents[j].Strategy = ReadInt16(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						this.oParent.GameState.Players[i].Diplomacy[j] = ReadUInt16(reader);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].CityCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].UnitCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].LandCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].SettlerCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].TotalCitySize = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].MilitaryPower = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].Ranking = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].TaxRate = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].Score = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].ContactPlayerCountdown = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].XStart = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].NationalityID = ReadInt16(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.oParent.GameState.Players[i].Continents[j].Attack = ReadInt16(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.oParent.GameState.Players[i].Continents[j].Defense = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].Continents.Length; j++)
					{
						this.oParent.GameState.Players[i].Continents[j].CityCount = ReadInt16(reader);
					}
				}

				for (int i = 0; i < 64; i++)
				{
					this.oParent.GameState.Continents[i].Size = ReadInt16(reader);
				}

				for (int i = 0; i < 64; i++)
				{
					this.oParent.GameState.Oceans[i].Size = ReadInt16(reader);
				}

				for (int i = 0; i < 16; i++)
				{
					this.oParent.GameState.Continents[i].BuildSiteCount = ReadInt16(reader);
				}

				for (int i = 0; i < 1200; i++)
				{
					this.oParent.GameState.ScoreGraphData[i] = ReadUInt8(reader);
				}

				for (int i = 0; i < this.oParent.GameState.PeaceGraphData.Length; i++)
				{
					this.oParent.GameState.PeaceGraphData[i] = ReadUInt8(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Cities.Length; i++)
				{
					this.oParent.GameState.Cities[i] = City.FromStream(reader);
				}

				for (int i = 0; i < 28; i++)
				{
					this.oParent.GameState.UnitDefinitions[i] = UnitDefinition.FromStream(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 128; j++)
					{
						this.oParent.GameState.Players[i].Units[j] = Unit.FromStream(reader);
					}
				}

				for (int i = 0; i < 80; i++)
				{
					for (int j = 0; j < 50; j++)
					{
						this.oParent.GameState.MapVisibility[i, j] = (ushort)((short)((sbyte)ReadUInt8(reader)));
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.oParent.GameState.Players[i].StrategicLocations[j].Active = (sbyte)ReadUInt8(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.oParent.GameState.Players[i].StrategicLocations[j].Policy = ReadUInt8(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.oParent.GameState.Players[i].StrategicLocations[j].Position.X = (sbyte)ReadUInt8(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.oParent.GameState.Players[i].StrategicLocations[j].Position.Y = (sbyte)ReadUInt8(reader);
					}
				}

				for (int i = 0; i < this.oParent.GameState.TechnologyFirstDiscoveredBy.Length; i++)
				{
					this.oParent.GameState.TechnologyFirstDiscoveredBy[i] = ReadInt16(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						this.oParent.GameState.Players[i].UnitsDestroyed[j] = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.oParent.GameState.CityNames.Length; i++)
				{
					char[] acCityName = new char[13];

					for (int j = 0; j < 13; j++)
					{
						acCityName[j] = (char)GameLoadAndSave.ReadUInt8(reader);
					}
					this.oParent.GameState.CityNames[i] = new string(acCityName);
				}

				this.oParent.GameState.ReplayDataLength = ReadInt16(reader);

				for (int i = 0; i < this.oParent.GameState.ReplayData.Length; i++)
				{
					this.oParent.GameState.ReplayData[i] = ReadUInt8(reader);
				}

				for (int i = 0; i < this.oParent.GameState.WonderCityID.Length; i++)
				{
					this.oParent.GameState.WonderCityID[i] = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].LostUnits.Length; j++)
					{
						this.oParent.GameState.Players[i].LostUnits[j] = ReadInt16(reader);

					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].TechnologyAcquiredFrom.Length; j++)
					{
						this.oParent.GameState.Players[i].TechnologyAcquiredFrom[j] = (sbyte)ReadUInt8(reader);
					}
				}

				this.oParent.GameState.PollutedSquareCount = ReadInt16(reader);
				this.oParent.GameState.PollutionEffectLevel = ReadInt16(reader);
				this.oParent.GameState.GlobalWarmingCount = ReadInt16(reader);
				this.oParent.GameState.GameSettingFlags = ReadInt16(reader);

				for (int i = 0; i < 260; i++)
				{
					this.oParent.GameState.LandPathfinding[i] = ReadUInt8(reader);
				}

				this.oParent.GameState.MaximumTechnologyCount = ReadInt16(reader);
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].FutureTechnologyCount = ReadInt16(reader);
				this.oParent.GameState.DebugFlags = ReadInt16(reader);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].ScienceTaxRate = ReadInt16(reader);
				}
				
				this.oParent.GameState.NextAnthologyTurn = ReadInt16(reader);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].CumulativeEpicRanking = ReadInt16(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					byte[] buffer = new byte[180];
					reader.Read(buffer, 0, 180);

					for (int j = 0; j < 180; j++)
					{
						this.oParent.GameState.Players[i].SpaceshipData[j] = (sbyte)buffer[j];
					}
				}

				this.oParent.GameState.SpaceshipFlags = ReadInt16(reader);
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].SpaceshipSuccessRate = ReadInt16(reader);
				this.oParent.GameState.AISpaceshipSuccessRate = ReadInt16(reader);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].SpaceshipETAYear = ReadInt16(reader);
				}

				for (int i = 0; i < 12; i++)
				{
					this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].PalaceData1[i + 2] = ReadInt16(reader);
				}

				for (int i = 0; i < 12; i++)
				{
					this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].PalaceData2[i] = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.CityPositions.Length; i++)
				{
					this.oParent.GameState.CityPositions[i].X = (sbyte)ReadUInt8(reader);
				}

				for (int i = 0; i < this.oParent.GameState.CityPositions.Length; i++)
				{
					this.oParent.GameState.CityPositions[i].Y = (sbyte)ReadUInt8(reader);
				}

				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].PalaceLevel = ReadInt16(reader);
				this.oParent.GameState.PeaceTurnCount = ReadInt16(reader);
				this.oParent.GameState.AIOpponentCount = ReadInt16(reader);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].SpaceshipPopulation = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].SpaceshipLaunchYear = ReadInt16(reader);
				}

				this.oParent.GameState.PlayerIdentityFlags = ReadInt16(reader);

				reader.Close();

				bSuccess = true;
			}
			catch (Exception ex)
			{
				this.oParent.MSCAPI.strcpy(0xba06, ex.Message);

				// Instruction address 0x0000:0x08a3, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

				bSuccess = false;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F11_0000_083b_LoadGameData");

			return bSuccess;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="bufferPtr"></param>
		/// <param name="length"></param>
		private void ReadData(Stream reader, ushort bufferPtr, ushort length)
		{
			reader.Read(this.oCPU.Memory.MemoryContent,
				(int)CPU.ToLinearAddress(this.oCPU.DS.Word, bufferPtr), length);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="bufferSeg"></param>
		/// <param name="bufferPtr"></param>
		/// <param name="length"></param>
		private void ReadData(Stream reader, ushort bufferSeg, ushort bufferPtr, ushort length)
		{
			reader.Read(this.oCPU.Memory.MemoryContent,
				(int)CPU.ToLinearAddress(bufferSeg, bufferPtr), length);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static byte ReadUInt8(Stream reader)
		{
			int byte0 = reader.ReadByte();

			if (byte0 >= 0)
			{
				return (byte)byte0;
			}

			return 0;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static ushort ReadUInt16(Stream reader)
		{
			int byte0 = reader.ReadByte();
			int byte1 = reader.ReadByte();

			if (byte0 >= 0 && byte1 >= 0)
			{
				return (ushort)(byte0 | (byte1 << 8));
			}

			return 0;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static short ReadInt16(Stream reader)
		{
			int byte0 = reader.ReadByte();
			int byte1 = reader.ReadByte();

			if (byte0 >= 0 && byte1 >= 0)
			{
				return (short)(byte0 | (byte1 << 8));
			}

			return 0;
		}

		/// <summary>
		/// Reads a null terminated string from the stream (null characher included)
		/// </summary>
		/// <param name="reader">Reading stream</param>
		/// <param name="length">Full string length, including null character</param>
		/// <returns></returns>
		public static string ReadString(Stream reader, int length)
		{
			int len = 0;
			char[] str = new char[length];
			bool end = false;

			for (int i = 0; i < length - 1; i++)
			{
				int ch = reader.ReadByte();

				if (!end && ch >= 0)
				{
					if (ch == 0)
					{
						end = true;
					}
					else
					{
						str[len] = (char)ch;
						len++;
					}
				}
			}

			reader.ReadByte();

			return new string(str, 0, len);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public bool F11_0000_08f6_SaveGameData(string path)
		{
			path = path.ToUpper();

			this.oCPU.Log.EnterBlock($"F11_0000_08f6_SaveGameData('{path}')");

			// function body
			bool bSuccess = false;
			string filename = Path.GetFileNameWithoutExtension(MSCAPI.GetDOSFileName(path));

			try
			{
				// write map file
				this.oParent.Graphics.Screens.GetValueByKey(2).SaveToPIC($"{CPU.DefaultCIVPath}{filename}.MAP", false);

				// write sve file
				FileStream writer = new FileStream($"{CPU.DefaultCIVPath}{filename}.SVE", FileMode.Create);
				WriteInt16(writer, this.oParent.GameState.TurnCount);
				WriteInt16(writer, this.oParent.GameState.HumanPlayerID);
				WriteInt16(writer, this.oParent.GameState.PlayerFlags);
				WriteUInt16(writer, this.oParent.GameState.RandomSeed);
				WriteInt16(writer, this.oParent.GameState.Year);
				WriteInt16(writer, this.oParent.GameState.DifficultyLevel);
				WriteInt16(writer, this.oParent.GameState.ActiveCivilizations);
				WriteInt16(writer, this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID);
				WriteData(writer, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19a2), 0x70);
				WriteData(writer, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1992), 0x60);
				WriteData(writer, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1982), 0x58);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].Coins);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].ResearchProgress);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].ActiveUnits.Length; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].ActiveUnits[j]);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].UnitsInProduction.Length; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].UnitsInProduction[j]);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].DiscoveredTechnologyCount);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 5; j++)
					{
						WriteUInt16(writer, this.oParent.GameState.Players[i].DiscoveredTechnologyFlags[j]);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].GovernmentType);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].Continents.Length; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].Continents[j].Strategy);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						WriteUInt16(writer, this.oParent.GameState.Players[i].Diplomacy[j]);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].CityCount);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].UnitCount);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].LandCount);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].SettlerCount);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].TotalCitySize);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].MilitaryPower);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].Ranking);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].TaxRate);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].Score);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].ContactPlayerCountdown);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].XStart);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].NationalityID);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].Continents[j].Attack);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].Continents[j].Defense);
					}
				}
				
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].Continents[j].CityCount);
					}
				}

				for (int i = 0; i < 64; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Continents[i].Size);
				}

				for (int i = 0; i < 64; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Oceans[i].Size);
				}

				for (int i = 0; i < 16; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Continents[i].BuildSiteCount);
				}

				for (int i = 0; i < 1200; i++)
				{
					writer.WriteByte(this.oParent.GameState.ScoreGraphData[i]);
				}

				for (int i = 0; i < this.oParent.GameState.PeaceGraphData.Length; i++)
				{
					writer.WriteByte(this.oParent.GameState.PeaceGraphData[i]);
				}

				for (int i = 0; i < this.oParent.GameState.Cities.Length; i++)
				{
					this.oParent.GameState.Cities[i].ToStream(writer);
				}

				for (int i = 0; i < 28; i++)
				{
					this.oParent.GameState.UnitDefinitions[i].ToStream(writer);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 128; j++)
					{
						this.oParent.GameState.Players[i].Units[j].ToStream(writer);
					}
				}

				for (int i = 0; i < 80; i++)
				{
					for (int j = 0; j < 50; j++)
					{
						writer.WriteByte((byte)((sbyte)((short)this.oParent.GameState.MapVisibility[i, j])));
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						writer.WriteByte((byte)this.oParent.GameState.Players[i].StrategicLocations[j].Active);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						writer.WriteByte(this.oParent.GameState.Players[i].StrategicLocations[j].Policy);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						writer.WriteByte((byte)this.oParent.GameState.Players[i].StrategicLocations[j].Position.X);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						writer.WriteByte((byte)this.oParent.GameState.Players[i].StrategicLocations[j].Position.Y);
					}
				}

				for (int i = 0; i < this.oParent.GameState.TechnologyFirstDiscoveredBy.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.TechnologyFirstDiscoveredBy[i]);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].UnitsDestroyed[j]);
					}
				}

				for (int i = 0; i < this.oParent.GameState.CityNames.Length; i++)
				{
					for (int j = 0; j < 13; j++)
					{
						writer.WriteByte((byte)this.oParent.GameState.CityNames[i][j]);
					}
				}

				WriteInt16(writer, this.oParent.GameState.ReplayDataLength);
				for (int i = 0; i < this.oParent.GameState.ReplayData.Length; i++)
				{
					writer.WriteByte(this.oParent.GameState.ReplayData[i]);
				}

				for (int i = 0; i < this.oParent.GameState.WonderCityID.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.WonderCityID[i]);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].LostUnits.Length; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].LostUnits[j]);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].TechnologyAcquiredFrom.Length; j++)
					{
						writer.WriteByte((byte)((sbyte)this.oParent.GameState.Players[i].TechnologyAcquiredFrom[j]));
					}
				}

				WriteInt16(writer, this.oParent.GameState.PollutedSquareCount);
				WriteInt16(writer, this.oParent.GameState.PollutionEffectLevel);
				WriteInt16(writer, this.oParent.GameState.GlobalWarmingCount);
				WriteInt16(writer, this.oParent.GameState.GameSettingFlags);

				for (int i = 0; i < 260; i++)
				{
					writer.WriteByte(this.oParent.GameState.LandPathfinding[i]);
				}

				WriteInt16(writer, this.oParent.GameState.MaximumTechnologyCount);
				WriteInt16(writer, this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].FutureTechnologyCount);
				WriteInt16(writer, this.oParent.GameState.DebugFlags);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].ScienceTaxRate);
				}
				
				WriteInt16(writer, this.oParent.GameState.NextAnthologyTurn);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].CumulativeEpicRanking);
				}

				for (int i = 0; i < 8; i++)
				{
					byte[] buffer = new byte[180];

					for (int j = 0; j < 180; j++)
					{
						buffer[j] = (byte)this.oParent.GameState.Players[i].SpaceshipData[j];
					}

					writer.Write(buffer, 0, 180);
				}

				WriteInt16(writer, this.oParent.GameState.SpaceshipFlags);
				WriteInt16(writer, this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].SpaceshipSuccessRate);
				WriteInt16(writer, this.oParent.GameState.AISpaceshipSuccessRate);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].SpaceshipETAYear);
				}

				for (int i = 0; i < 12; i++)
				{
					WriteInt16(writer, (short)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].PalaceData1[i + 2]);
				}

				for (int i = 0; i < 12; i++)
				{
					WriteInt16(writer, (short)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].PalaceData2[i]);
				}

				for (int i = 0; i < 256; i++)
				{
					writer.WriteByte((byte)((sbyte)this.oParent.GameState.CityPositions[i].X));
				}
				for (int i = 0; i < 256; i++)
				{
					writer.WriteByte((byte)((sbyte)this.oParent.GameState.CityPositions[i].Y));
				}

				WriteInt16(writer, this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].PalaceLevel);
				WriteInt16(writer, this.oParent.GameState.PeaceTurnCount);
				WriteInt16(writer, this.oParent.GameState.AIOpponentCount);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].SpaceshipPopulation);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].SpaceshipLaunchYear);
				}

				WriteInt16(writer, this.oParent.GameState.PlayerIdentityFlags);

				writer.Close();

				bSuccess = true;
			}
			catch (Exception ex)
			{
				this.oParent.MSCAPI.strcpy(0xba06, ex.Message);
				this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 4, 64, 1);

				bSuccess = false;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F11_0000_08f6_SaveGameData");

			return bSuccess;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="bufferPtr"></param>
		/// <param name="length"></param>
		private void WriteData(Stream writer, ushort bufferPtr, ushort length)
		{
			writer.Write(this.oCPU.Memory.MemoryContent,
				(int)CPU.ToLinearAddress(this.oCPU.DS.Word, bufferPtr), length);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="bufferSeg"></param>
		/// <param name="bufferPtr"></param>
		/// <param name="length"></param>
		private void WriteData(Stream writer, ushort bufferSeg, ushort bufferPtr, ushort length)
		{
			writer.Write(this.oCPU.Memory.MemoryContent,
				(int)CPU.ToLinearAddress(bufferSeg, bufferPtr), length);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		public static void WriteUInt16(Stream writer, ushort value)
		{
			writer.WriteByte((byte)(value & 0xff));
			writer.WriteByte((byte)((value & 0xff00) >> 8));
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		public static void WriteInt16(Stream writer, short value)
		{
			writer.WriteByte((byte)((ushort)value & 0xff));
			writer.WriteByte((byte)(((ushort)value & 0xff00) >> 8));
		}

		/// <summary>
		/// Writes a null terminated string to a stream. Null character is included in the string length
		/// </summary>
		/// <param name="writer">Writer</param>
		/// <param name="text">String to write</param>
		/// <param name="length">maximum string length including the null character</param>
		public static void WriteString(Stream writer, string text, int length)
		{
			bool end = false;

			for (int i = 0; i < length - 1; i++)
			{
				if (!end && i < text.Length)
				{
					if (text[i] == 0)
					{
						end = true;
						writer.WriteByte(0);
					}
					else
					{
						writer.WriteByte((byte)text[i]);
					}
				}
				else
				{
					writer.WriteByte(0);
				}
			}

			writer.WriteByte(0);
		}
	}
}
