using System;
using Avalonia.Media;
using IRB.Collections.Generic;
using IRB.VirtualCPU;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class Segment_1000
	{
		private CivGame oParent;
		private VCPU oCPU;
		private GDriver oGraphics;

		private bool bInTimer = false;
		private Timer? oTimer = null;

		private BDictionary<int, PaletteCycleSlot> aPletteCycleSlots = new BDictionary<int, PaletteCycleSlot>();

		private bool bTransformFlag = false;
		private int iTransformValue = 0;
		private int iTransformCount = 0;
		private TransformColor[] aTransformColors = new TransformColor[0];

		public Segment_1000(CivGame parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGraphics = parent.Graphics;
		}

		/// <summary>
		/// Initializes and calibrates timer
		/// </summary>
		public void F0_1000_0000_InitializeTimer()
		{
			this.oCPU.Log.EnterBlock("F0_1000_0000_InitializeTimer()");

			// function body
			if (this.oTimer == null)
			{
				this.oCPU.EnableTimer = true;
				this.oTimer = new Timer(F0_1000_01a7_Timer, null, 10, 10);
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_0000_InitializeTimer");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_0051_StopTimer()
		{
			this.oCPU.Log.EnterBlock("F0_1000_0051_InitTimer()");

			// function body
			if (this.oTimer != null)
			{
				this.oTimer.Dispose();
				this.oTimer = null;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_0051_InitTimer");
		}

		/// <summary>
		/// Timer function, it should fire approximately every 20 ms
		/// </summary>
		private void F0_1000_01a7_Timer(object? state)
		{
			lock (this.oGraphics.GLock)
			{
				this.bInTimer = true;

				if (this.bTransformFlag)
				{
					// Instruction address 0x1000:0x0349, size: 5
					F0_1000_0631_TransformPaletteTimer();
				}
				else
				{
					// Instruction address 0x1000:0x034e, size: 5
					F0_1000_044a_CyclePaletteTimer();
				}

				this.oParent.Var_5c_TickCount++;

				// sound driver call
				// Instruction address 0x1000:0x01e7, size: 5
				F0_1000_0a40_SoundWorker();

				this.bInTimer = false;
			}
		}

		/// <summary>
		/// Processes palette cycles and updates current palette
		/// </summary>
		/// <exception cref="Exception"></exception>
		public void F0_1000_044a_CyclePaletteTimer()
		{
			for (int i = 0; i < this.aPletteCycleSlots.Count; i++)
			{
				PaletteCycleSlot slot = this.aPletteCycleSlots[i].Value;

				if (slot.Active)
				{
					slot.SpeedCount++;

					if (slot.SpeedCount > slot.Speed)
					{
						slot.SpeedCount = 0;
						slot.CurrentPosition = (slot.CurrentPosition + 1) % slot.Palette.Length;

						for (int j = 0; j < slot.Palette.Length; j++)
						{
							int index = (slot.CurrentPosition + j) % slot.Palette.Length;

							this.oGraphics.SetPaletteColor((byte)(slot.StartPosition + index), slot.Palette[j]);
						}
					}
				}
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <exception cref="Exception"></exception>
		public void F0_1000_0631_TransformPaletteTimer()
		{
			if (this.bTransformFlag)
			{
				this.iTransformCount++;

				for (int i = 0; i < this.aTransformColors.Length; i++)
				{
					this.oGraphics.SetPaletteColor((byte)i, this.aTransformColors[i].GetNextColor(this.iTransformCount).ToColor());
				}

				if (this.iTransformCount >= this.iTransformValue)
				{
					for (int i = 0; i < this.aTransformColors.Length; i++)
					{
						this.oGraphics.SetPaletteColor((byte)i, this.aTransformColors[i].ToHSV.ToColor());
					}

					this.bTransformFlag = false;
				}
			}
		}

		/// <summary>
		/// Reset timer count
		/// </summary>
		/// <returns></returns>
		public void F0_1000_033e_ResetWaitTimer()
		{
			// function body
			this.oParent.Var_5c_TickCount = 0;
		}

		/// <summary>
		/// Waits for specified number of main timer ticks
		/// </summary>
		/// <param name="waitTime"></param>
		public void F0_1182_0134_WaitTimer(int waitTime)
		{
			this.oCPU.Log.EnterBlock($"F0_1182_0134_WaitTime({waitTime})");

			F0_1000_033e_ResetWaitTimer();

			int iTime = Math.Max(waitTime * 12, 1);

			Thread.Sleep(iTime);
			this.oCPU.DoEvents();//*/

			/*waitTime = (short)(Math.Ceiling(0.6 * waitTime));

			while (this.oParent.Var_5c_TickCount < waitTime)
			{
				Thread.Sleep(1);
			}//*/

			this.oCPU.Log.ExitBlock("F0_1182_0134_WaitTime");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="index"></param>
		/// <param name="speed"></param>
		/// <param name="fromColorIndex"></param>
		/// <param name="toColorIndex"></param>
		/// <exception cref="Exception"></exception>
		public void F0_1000_0382_AddPaletteCycleSlot(int index, int speed, byte fromColorIndex, byte toColorIndex)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_0382_AddPaletteCycleSlot({index}, {speed}, {fromColorIndex}, {toColorIndex})");

			if (index < 0 || index > 8)
				throw new ArgumentOutOfRangeException("Argument index is out of range");

			if (fromColorIndex > toColorIndex)
				throw new ArgumentOutOfRangeException("Argument fromColorIndex is greater than toColorIndex");

			while (this.bInTimer)
			{
				Thread.Sleep(1);
			}

			// function body
			lock (this.oGraphics.GLock)
			{
				if (this.aPletteCycleSlots.ContainsKey(index))
				{
					// restore old slot palette
					PaletteCycleSlot oldSlot = this.aPletteCycleSlots.GetValueByKey(index);
					
					if (oldSlot.Active)
					{
						for (int i = 0; i < oldSlot.Palette.Length; i++)
						{
							this.oGraphics.SetPaletteColor((byte)(oldSlot.StartPosition + i), oldSlot.Palette[i]);
						}
					}

					// prepare new slot
					Color[] palette = new Color[(toColorIndex - fromColorIndex) + 1];
					for (int i = 0; i < palette.Length; i++)
					{
						palette[i] = this.oGraphics.GetPaletteColor((byte)(fromColorIndex + i));
					}

					PaletteCycleSlot newSlot = new PaletteCycleSlot(speed, fromColorIndex, palette);
					//newSlot.Active = oldSlot.Active;

					this.aPletteCycleSlots.SetValueByKey(index, newSlot);
				}
				else
				{
					Color[] palette = new Color[(toColorIndex - fromColorIndex) + 1];
					for (int i = 0; i < palette.Length; i++)
					{
						palette[i] = this.oGraphics.GetPaletteColor((byte)(fromColorIndex + i));
					}

					PaletteCycleSlot slot = new PaletteCycleSlot(speed, fromColorIndex, palette);

					this.aPletteCycleSlots.Add(index, slot);
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_0382_AddPaletteCycleSlot");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="index"></param>
		public void F0_1000_03fa_StartPaletteCycleSlot(int index)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_03fa_StartPaletteCycleSlot({index})");

			// function body
			if (this.aPletteCycleSlots.ContainsKey(index))
			{
				while (this.bInTimer)
				{
					Thread.Sleep(1);
				}

				lock (this.oGraphics.GLock)
				{
					this.aPletteCycleSlots.GetValueByKey(index).Active = true;
				}
			}
			else
			{
				this.oCPU.Log.WriteLine($"Attempt to start undefined PaletteCycleSlot({index})");
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_03fa_StartPaletteCycleSlot");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="index"></param>
		public void F0_1000_042b_StopPaletteCycleSlot(int index)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_042b_StopPaletteCycleSlot({index})");

			// function body
			if (this.aPletteCycleSlots.ContainsKey(index))
			{
				while (this.bInTimer)
				{
					Thread.Sleep(1);
				}

				lock (this.oGraphics.GLock)
				{
					PaletteCycleSlot slot = this.aPletteCycleSlots.GetValueByKey(index);

					if (slot.Active)
					{
						for (int i = 0; i < slot.Palette.Length; i++)
						{
							this.oGraphics.SetPaletteColor((byte)(slot.StartPosition + i), slot.Palette[i]);
						}
					}

					slot.Active = false;
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_042b_StopPaletteCycleSlot");
		}

		/// <summary>
		/// Transform current palette to another palette
		/// </summary>
		/// <param name="speed"></param>
		/// <param name="palettePtr"></param>
		public void F0_1000_04aa_TransformPalette(int speed, ushort palettePtr)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_04aa_TransformPalette({speed}, 0x{palettePtr:x4})");

			// function body
			if (speed < 1 || speed > 50)
				throw new ArgumentOutOfRangeException("The argument speed is out of range");

			this.aTransformColors = new TransformColor[256];
			palettePtr += 6;

			lock (this.oParent.Graphics.GLock)
			{
				while (this.bInTimer)
				{
					Thread.Sleep(1);
				}

				this.iTransformValue = speed * 10;
				this.iTransformCount = 0;

				for (int i = 0; i < 256; i++)
				{
					HSVColor from = HSVColor.FromColor(this.oGraphics.GetPaletteColor((byte)i));
					HSVColor to = HSVColor.FromColor(GBitmap.Color18ToColor(this.oCPU.ReadUInt8(this.oCPU.DS.Word, palettePtr),
						this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(palettePtr + 1)),
						this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(palettePtr + 2))));

					this.aTransformColors[i] = new TransformColor(from, to, this.iTransformValue);

					palettePtr += 3;
				}

				this.bTransformFlag = true;
			}

			while (this.bTransformFlag)
			{
				this.oCPU.DoEvents();
				Thread.Sleep(1);
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_04aa_TransformPalette");
		}

		/// <summary>
		/// Transform entire palette to one color
		/// </summary>
		/// <param name="speed"></param>
		/// <param name="color"></param>
		public void F0_1000_04d4_TransformPaletteToColor(int speed, Color color)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_04d4_TransformPaletteToColor({speed}, {color})");

			// function body
			HSVColor to = HSVColor.FromColor(color);
			this.aTransformColors = new TransformColor[256];

			lock (this.oParent.Graphics.GLock)
			{
				while (this.bInTimer)
				{
					Thread.Sleep(1);
				}

				this.iTransformValue = speed * 10;
				this.iTransformCount = 0;

				for (int i = 0; i < 256; i++)
				{
					HSVColor from = HSVColor.FromColor(this.oGraphics.GetPaletteColor((byte)i));

					this.aTransformColors[i] = new TransformColor(from, to, this.iTransformValue);
				}

				this.bTransformFlag = true;
			}

			while (this.bTransformFlag)
			{
				this.oCPU.DoEvents();
				Thread.Sleep(1);
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_04d4_TransformPaletteToColor");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="fileNamePtr"></param>
		/// <returns></returns>
		public ushort F0_1000_066a_FileExists(ushort fileNamePtr)
		{
			string fileName = MSCAPI.GetDOSFileName(this.oParent.CPU.ReadString(VCPU.ToLinearAddress(this.oParent.CPU.DS.Word, fileNamePtr)).ToUpper());

			this.oCPU.Log.EnterBlock($"F0_1000_066a_FileExists('{fileName}')");

			// function body
			if (File.Exists($"{VCPU.DefaultCIVPath}{fileName}"))
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.AX.Word = 0xffff;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_066a_FileExists");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_07d6()
		{
			this.oCPU.Log.EnterBlock("F0_1000_07d6()");

			// function body
			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0);
			}

			this.oCPU.Log.ExitBlock("F0_1000_07d6");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		public void F0_1000_083f(short param1, short param2, ushort param3)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_083f({param1}, {param2}, {param3})");

			// function body
			//this.oParent.Graphics.F0_VGA_0270(param1, param2, param3);

			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0);
			}

			this.oCPU.Log.ExitBlock("F0_1000_083f");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="screenID"></param>
		public void F0_1000_0846(int screenID)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_0846({screenID})");

			// function body
			//this.oParent.Graphics.F0_VGA_063c(screenID);
			this.oParent.Graphics.F0_VGA_06b7_DrawScreenToMainScreenWithEffect(screenID);

			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0);
			}

			this.oCPU.Log.ExitBlock("F0_1000_0846");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="rectPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="bitmapPtr"></param>
		public void F0_1000_0797_DrawBitmapToScreen(CRectangle rect, int xPos, int yPos, ushort bitmapPtr)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_0797_DrawBitmapToScreen({rect}, {xPos}, {yPos}, 0x{bitmapPtr:x4})");

			// function body
			this.oParent.Graphics.F0_VGA_0c3e_DrawBitmapToScreen(rect, xPos, yPos, bitmapPtr);

			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0);
			}

			this.oCPU.Log.ExitBlock("F0_1000_0797_DrawBitmapToScreen");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="rectPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="bitmapPtr"></param>
		public void F0_1000_084d_DrawBitmapToScreen(CRectangle rect, int xPos, int yPos, ushort bitmapPtr)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_084d_DrawBitmapToScreen({rect}, {xPos}, {yPos}, 0x{bitmapPtr:x4})");

			// function body
			this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(rect, xPos, yPos, bitmapPtr);

			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0);

			/*L075e:
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, this.oCPU.DECByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5402)));
				if (this.oCPU.Flags.E) goto L0769;

				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.PushWord(this.oCPU.DX.Word);
				this.oCPU.PushWord(this.oCPU.ES.Word);
				
				this.oCPU.ES.Word = 0x1000;
				// Instruction address 0x1000:0x17a2, size: 5
				this.oParent.Graphics.F0_VGA_0224_DrawBufferToScreen();

				this.oCPU.ES.Word = 0x1000;
				// Instruction address 0x1000:0x17c0, size: 5
				this.oParent.Graphics.F0_VGA_0270(
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x586e) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5878)),
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5870) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x587a)),
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876));

				this.oCPU.ES.Word = this.oCPU.PopWord();
				this.oCPU.DX.Word = this.oCPU.PopWord();
				this.oCPU.AX.Word = this.oCPU.PopWord();
				goto L075e;

			L0769:
				this.oCPU.AX.Word |= 0;*/
			}

			this.oCPU.Log.ExitBlock("F0_1000_084d_DrawBitmapToScreen");
		}

		/// <summary>
		/// Sound function
		/// </summary>
		public void F0_1000_0a2b_InitSound()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a2b_InitSound'");

			// Instruction address 0x1000:0x0a2b, size: 5
			this.oParent.Sound.F0_0000_0048_InitSound();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a2b_InitSound'");
		}

		/// <summary>
		/// Sound function, possibly: Play Music
		/// </summary>
		/// <param name="tune"></param>
		/// <param name="param2"></param>
		public void F0_1000_0a32_PlayTune(short tune, ushort param2)
		{
			if ((this.oParent.CivState.GameSettingFlags & 0x10) != 0)
			{
				// Instruction address 0x1000:0x0a32, size: 5
				this.oParent.Sound.F0_0000_0062_PlayTune(tune, param2);
			}
		}

		/// <summary>
		/// Sound function
		/// </summary>
		/// <returns></returns>
		public void F0_1000_0a39_CloseSound()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a39_CloseSound'");

			// Instruction address 0x1000:0x0a39, size: 5
			this.oParent.Sound.F0_0000_006a_CloseSound();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a39_CloseSound'");
		}

		/// <summary>
		/// Sound function
		/// </summary>
		/// <returns></returns>
		public ushort F0_1000_0a40_SoundWorker()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a40_SoundWorker'");

			// Instruction address 0x1000:0x0a40, size: 5
			ushort usTemp =  this.oParent.Sound.F0_0000_0055_SoundWorker();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a40_SoundWorker'");

			return usTemp;
		}

		/// <summary>
		/// Sound function, possibly advance sound buffer
		/// </summary>
		public void F0_1000_0a47_FastSoundWorker()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a47_FastSoundWorker'");

			// function body
			// Instruction address 0x1000:0x0a47, size: 5
			this.oParent.Sound.F0_0000_005c_FastSoundWorker();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a47_FastSoundWorker'");
		}

		/// <summary>
		/// Sound function
		/// </summary>
		/// <returns></returns>
		public ushort F0_1000_0a4e_Soundtimer()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a4e_Soundtimer'");

			// Instruction address 0x1000:0x0a4e, size: 5
			this.oCPU.AX.Word = this.oParent.Sound.F0_0000_005d_SoundTimer();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a4e_Soundtimer'");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// Fills the rectangle with color
		/// </summary>
		/// <param name="rectPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="mode"></param>
		public void F0_1000_0bfa_FillRectangle(CRectangle rect, int xPos, int yPos, int width, int height, ushort mode)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_0bfa_FillRectangle({rect}, {xPos}, {yPos}, {width}, {height}, 0x{mode:x4})");

			// function body
			if (width > 0 && height > 0)
			{
				GRectangle rect1 = new GRectangle(rect.Left + xPos, rect.Top + yPos, width, height);
				this.oParent.Graphics.F0_VGA_040a_FillRectangle(rect.ScreenID, rect1, (byte)(mode & 0xff), (byte)((mode & 0xff00) >> 8));
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_0bfa_FillRectangle");
		}

		/// <summary>
		/// Sets a pixel on screen set by structure at 0xaa
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="mode"></param>
		public void F0_1000_104f_SetPixel(int xPos, int yPos, ushort mode)
		{
			CRectangle rect = this.oParent.Var_aa_Rectangle;

			this.oCPU.Log.EnterBlock($"F0_1000_104f_SetPixel({rect.ScreenID}, {xPos}, {yPos}, 0x{mode:x4})");

			// function body
			if (xPos >= 0 && xPos <= rect.Width && yPos >= 0 && yPos <= rect.Height)
			{
				// Instruction address 0x1000:0x1080, size: 5
				this.oParent.Graphics.F0_VGA_0550_SetPixel(rect.ScreenID, rect.Left + xPos, rect.Top + yPos, (byte)(mode & 0xff), (byte)((mode & 0xff00) >> 8));
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_104f_SetPixel");
		}

		/// <summary>
		/// Sets a pixel on selected screen
		/// </summary>
		/// <param name="screenID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="mode"></param>
		public void F0_1000_104f_SetPixel(ushort screenID, int xPos, int yPos, ushort mode)
		{
			CRectangle rect = this.oParent.Var_aa_Rectangle;

			this.oCPU.Log.EnterBlock($"F0_1000_104f_SetPixel({screenID}, {xPos}, {yPos}, 0x{mode:x4})");

			// function body
			if (xPos >= 0 && xPos <= rect.Width && yPos >= 0 && yPos <= rect.Height)
			{
				// Instruction address 0x1000:0x1080, size: 5
				this.oParent.Graphics.F0_VGA_0550_SetPixel(screenID, rect.Left + xPos, rect.Top + yPos, (byte)(mode & 0xff), (byte)((mode & 0xff00) >> 8));
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_104f_SetPixel");
		}

		/// <summary>
		/// Resets and inits the mouse subsystem
		/// </summary>
		/// <returns>true if mouse is detected</returns>
		public ushort F0_1000_163e_InitMouse()
		{
			this.oCPU.Log.EnterBlock("F0_1000_163e_InitMouse()");

			// function body
			// assume our mouse is initialized

			//this.oCPU.ES.Word = 0;
			//this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, 0xcc);
			//this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.ES.Word, 0xce));
			//if (this.oCPU.Flags.E) goto L1683;
			//this.oCPU.AX.Word = 0x0;
			//this.oCPU.INT(0x33);
			//this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			//if (this.oCPU.Flags.E) goto L1683;
			//this.oCPU.AX.Word = 0xc;
			//this.oCPU.CX.Word = 0x1f;
			//this.oCPU.ES.Word = this.oCPU.CS.Word;
			//this.oCPU.DX.Word = 0x17db;
			//this.oCPU.INT(0x33);
			//this.oCPU.AX.Word = 0x3;
			//this.oCPU.INT(0x33);
			this.oCPU.CX.Low = 0;
			this.oCPU.AX.Word = (ushort)(this.oCPU.MouseLocation.X >> this.oCPU.CX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x587c, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x586e, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5870, (ushort)this.oCPU.MouseLocation.Y);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5872, (ushort)this.oCPU.MouseButtons);
			this.oCPU.AX.Word = 0xffff;

		//L1683:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x587d, this.oCPU.AX.Low);

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_163e_InitMouse");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_1687()
		{
			this.oCPU.Log.EnterBlock("F0_1000_1687()");

			// function body
			this.oCPU.AX.Low = 0x0;
			this.oCPU.Temp.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x587d);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x587d, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.Temp.Low;
			this.oCPU.AX.Low = this.oCPU.OR_UInt8(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L1696;

			//this.oCPU.AX.Word = 0x0;
			//this.oCPU.INT(0x33);
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.BX.Word = 2;

		L1696:
			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_1687");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		public void F0_1000_1697(ushort param1, ushort param2, ushort param3)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_1697({param1}, {param2}, {param3})");

			// function body
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5878, param1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x587a, param2);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5876, param3);

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_1697");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		public void F0_1000_16ae(ushort param1, ushort param2)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_16ae({param1}, {param2})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			this.oCPU.AX.Word = param1;
			this.oCPU.DX.Word = param2;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x586e, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5870, this.oCPU.DX.Word);

			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x587d), 0x0);
			if (this.oCPU.Flags.E) goto L16d2;
			
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x587c);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			
			//this.oCPU.AX.Word = 0x4;
			//this.oCPU.INT(0x33);

		L16d2:
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_16ae");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public ushort F0_1000_16d4()
		{
			// function body
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5874);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5874, 0);

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_16db()
		{
			this.oCPU.Log.EnterBlock("F0_1000_16db()");

			// function body
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876), 0x0);
			if (this.oCPU.Flags.E) goto L170a;
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403), 0x0);
			if (this.oCPU.Flags.NE) goto L170a;

			// Instruction address 0x1000:0x16fd, size: 5
			F0_1000_083f((short)(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x586e) - this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x5878)),
				(short)(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x5870) - this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x587a)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876));

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5403, 0x1);

		L170a:
			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_16db");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_170b()
		{
			this.oCPU.Log.EnterBlock("F0_1000_170b()");

			// function body
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876), 0x0);
			if (this.oCPU.Flags.E) goto L1723;

			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403), 0x0);
			if (this.oCPU.Flags.E) goto L1723;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5403, 0x0);

			// Instruction address 0x1000:0x171e, size: 5
			F0_1000_07d6();

		L1723:
			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_170b");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_179a()
		{
			this.oCPU.Log.EnterBlock("F0_1000_179a()");

			// function body
			// Near return
			this.oCPU.Log.ExitBlock("F0_1000_179a");
		}

		/// <summary>
		/// Handles mouse events
		/// </summary>
		public void F0_1000_17db_MouseEvent()
		{
			//this.oCPU.Log.EnterBlock("F0_1000_17db_MouseEvent()");

			// function body
			this.oCPU.DS.Word = 0x3b01;

			this.oCPU.BP.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x587c);
			this.oCPU.BP.Word = this.oCPU.SHR_UInt16(this.oCPU.BP.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.BP.Word;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5874, 
				this.oCPU.OR_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5874), this.oCPU.BX.Word));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5872, this.oCPU.BX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x586e, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5870, this.oCPU.DX.Word);

			this.oCPU.BP.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oCPU.BP.Word, 0x1);
			if (this.oCPU.Flags.E) goto L1829;
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403), 0x0);
			if (this.oCPU.Flags.E) goto L1829;
			this.oCPU.AX.Low = 0x2;
			this.oCPU.Temp.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5402);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.Temp.Low;
			this.oCPU.AX.Low = this.oCPU.OR_UInt8(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L1829;

			// Instruction address 0x1000:0x1821, size: 3
			F0_1000_179a();

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0x0);

		L1829:
			// Far return
			//this.oCPU.Log.ExitBlock("F0_1000_17db_MouseEvent");
			this.oCPU.AX.Low = this.oCPU.AX.Low;
		}
	}
}
