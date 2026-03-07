using System;
using Avalonia.Media;
using IRB.Collections.Generic;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class CommonTools
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GDriver oGraphics;

		private bool bInTimer = false;
		private Timer? oTimer = null;

		private BDictionary<int, PaletteCycleSlot> aPletteCycleSlots = new BDictionary<int, PaletteCycleSlot>();

		private bool bTransformFlag = false;
		private int iTransformValue = 0;
		private int iTransformCount = 0;
		private TransformColor[] aTransformColors = new TransformColor[0];

		public CommonTools(OpenCiv1Game parent)
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
			//this.oCPU.Log.EnterBlock("F0_1000_0000_InitializeTimer()");

			// function body
			if (this.oTimer == null)
			{
				this.oCPU.EnableTimer = true;
				this.oTimer = new Timer(F0_1000_01a7_Timer, null, 10, 10);
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_0051_StopTimer()
		{
			//this.oCPU.Log.EnterBlock("F0_1000_0051_InitTimer()");

			// function body
			if (this.oTimer != null)
			{
				this.oTimer.Dispose();
				this.oTimer = null;
			}
		}

		/// <summary>
		/// Timer function, it should fire approximately every 20 ms
		/// </summary>
		private void F0_1000_01a7_Timer(object? state)
		{
			lock (VCPU.GraphicsLock)
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
			//this.oCPU.Log.EnterBlock($"F0_1182_0134_WaitTime({waitTime})");

			F0_1000_033e_ResetWaitTimer();

			int iTime = Math.Max(waitTime * 12, 1);

			Thread.Sleep(iTime);
			this.oCPU.DoEvents();

			/*waitTime = (short)(Math.Ceiling(0.6 * waitTime));

			while (this.oParent.Var_5c_TickCount < waitTime)
			{
				Thread.Sleep(1);
			}//*/
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
			//this.oCPU.Log.EnterBlock($"F0_1000_0382_AddPaletteCycleSlot({index}, {speed}, {fromColorIndex}, {toColorIndex})");

			if (index < 0 || index > 8)
				throw new ArgumentOutOfRangeException("Argument index is out of range");

			if (fromColorIndex > toColorIndex)
				throw new ArgumentOutOfRangeException("Argument fromColorIndex is greater than toColorIndex");

			while (this.bInTimer)
			{
				Thread.Sleep(1);
			}

			// function body
			lock (VCPU.GraphicsLock)
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
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="index"></param>
		public void F0_1000_03fa_StartPaletteCycleSlot(int index)
		{
			//this.oCPU.Log.EnterBlock($"F0_1000_03fa_StartPaletteCycleSlot({index})");

			// function body
			if (this.aPletteCycleSlots.ContainsKey(index))
			{
				while (this.bInTimer)
				{
					Thread.Sleep(1);
				}

				lock (VCPU.GraphicsLock)
				{
					this.aPletteCycleSlots.GetValueByKey(index).Active = true;
				}
			}
			else
			{
				//throw new Exception($"Attempt to start undefined PaletteCycleSlot({index})");
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="index"></param>
		public void F0_1000_042b_StopPaletteCycleSlot(int index)
		{
			//this.oCPU.Log.EnterBlock($"F0_1000_042b_StopPaletteCycleSlot({index})");

			// function body
			if (this.aPletteCycleSlots.ContainsKey(index))
			{
				while (this.bInTimer)
				{
					Thread.Sleep(1);
				}

				lock (VCPU.GraphicsLock)
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
		}

		/// <summary>
		/// Transform current palette to another palette
		/// </summary>
		/// <param name="speed"></param>
		/// <param name="palettePtr"></param>
		public void F0_1000_04aa_TransformPalette(int speed, ushort palettePtr)
		{
			//this.oCPU.Log.EnterBlock($"F0_1000_04aa_TransformPalette({speed}, 0x{palettePtr:x4})");

			// function body
			if (speed < 1 || speed > 50)
				throw new ArgumentOutOfRangeException("The argument speed is out of range");

			this.aTransformColors = new TransformColor[256];
			palettePtr += 6;

			lock (VCPU.GraphicsLock)
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
					HSVColor to = HSVColor.FromColor(GBitmap.Color18ToColor(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, palettePtr),
						this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(palettePtr + 1)),
						this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(palettePtr + 2))));

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
		}

		/// <summary>
		/// Transform entire palette to one color
		/// </summary>
		/// <param name="speed"></param>
		/// <param name="color"></param>
		public void F0_1000_04d4_TransformPaletteToColor(int speed, Color color)
		{
			//this.oCPU.Log.EnterBlock($"F0_1000_04d4_TransformPaletteToColor({speed}, {color})");

			// function body
			HSVColor to = HSVColor.FromColor(color);
			this.aTransformColors = new TransformColor[256];

			lock (VCPU.GraphicsLock)
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
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="BitmapPtr"></param>
		public void F0_1000_083f(int x, int y, int BitmapPtr)
		{
			//this.oCPU.Log.EnterBlock($"F0_1000_083f({x}, {y}, {BitmapPtr})");

			// function body
			//this.oParent.Graphics.F0_VGA_0270(x, y, BitmapPtr);

			if (this.oParent.Var_5403 != 0)
			{
				this.oParent.Var_5402 = 0;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="screenID"></param>
		public void F0_1000_0846(int screenID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1000_0846({screenID})");

			// function body
			//this.oParent.Graphics.F0_VGA_063c(screenID);
			this.oParent.Graphics.F0_VGA_06b7_DrawScreenToMainScreenWithEffect(screenID);

			if (this.oParent.Var_5403 != 0)
			{
				this.oParent.Var_5402 = 0;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="rectPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="bitmapPtr"></param>
		public void F0_1000_0797_DrawBitmapToScreen(CRectangle rect, int xPos, int yPos, int bitmapPtr)
		{
			//this.oCPU.Log.EnterBlock($"F0_1000_0797_DrawBitmapToScreen({rect}, {xPos}, {yPos}, 0x{bitmapPtr:x4})");

			// function body
			this.oParent.Graphics.F0_VGA_0c3e_DrawBitmapToScreen(rect, xPos, yPos, bitmapPtr);

			if (this.oParent.Var_5403 != 0)
			{
				this.oParent.Var_5402 = 0;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="rectPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="bitmapPtr"></param>
		public void F0_1000_084d_DrawBitmapToScreen(CRectangle rect, int xPos, int yPos, int bitmapPtr)
		{
			//this.oCPU.Log.EnterBlock($"F0_1000_084d_DrawBitmapToScreen({rect}, {xPos}, {yPos}, 0x{bitmapPtr:x4})");

			// function body
			this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(rect, xPos, yPos, bitmapPtr);

			if (this.oParent.Var_5403 != 0)
			{
				this.oParent.Var_5402 = 0;
			}
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
			if (this.oParent.GameData.GameSettingFlags.Sound)
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
			return this.oParent.Sound.F0_0000_0055_SoundWorker();
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
			return this.oParent.Sound.F0_0000_005d_SoundTimer();
		}

		/// <summary>
		/// Fills the rectangle with color
		/// </summary>
		/// <param name="rectPtr"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="mode"></param>
		public void F0_1000_0bfa_FillRectangle(CRectangle rect, int x, int y, int width, int height, ushort mode)
		{
			//this.oCPU.Log.EnterBlock($"F0_1000_0bfa_FillRectangle({rect}, {x}, {y}, {width}, {height}, 0x{mode:x4})");

			// function body
			if (width > 0 && height > 0)
			{
				GRectangle rect1 = new GRectangle(rect.Left + x, rect.Top + y, width, height);
				this.oParent.Graphics.F0_VGA_040a_FillRectangle(rect.ScreenID, rect1, (byte)(mode & 0xff), (byte)((mode & 0xff00) >> 8));
			}
		}

		/// <summary>
		/// Resets and inits the mouse subsystem
		/// </summary>
		/// <returns>true if mouse is detected</returns>
		public void F0_1000_163e_InitMouse()
		{
			//this.oCPU.Log.EnterBlock("F0_1000_163e_InitMouse()");

			// function body
			//this.oCPU.AX.Word = 0x3;
			//this.oCPU.INT(0x33);
			this.oParent.Var_586e_MouseNewX = this.oCPU.MouseLocation.X;
			this.oParent.Var_5870_MouseNewY = this.oCPU.MouseLocation.Y;
			this.oParent.Var_5872_MouseNewButtons = (int)this.oCPU.MouseButtons;
			this.oParent.Var_587d = -1;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="bitmapPtr"></param>
		public void F0_1000_1697(int x, int y, int bitmapPtr)
		{
			//this.oCPU.Log.EnterBlock($"F0_1000_1697({param1}, {param2}, {bitmapPtr})");

			// function body
			this.oParent.Var_5878_MouseIconXOffset = x;
			this.oParent.Var_587a_MouseIconYOffset = y;
			this.oParent.Var_5876_MouseIcon = bitmapPtr;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void F0_1000_16ae(int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_1000_16ae({param1}, {param2})");

			// function body
			this.oParent.Var_586e_MouseNewX = x;
			this.oParent.Var_5870_MouseNewY = y;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_16db()
		{
			//this.oCPU.Log.EnterBlock("F0_1000_16db()");

			// function body
			if (this.oParent.Var_5876_MouseIcon != 0)
			{
				if (this.oParent.Var_5403 == 0)
				{
					// Instruction address 0x1000:0x16fd, size: 5
					F0_1000_083f(this.oParent.Var_586e_MouseNewX - this.oParent.Var_5878_MouseIconXOffset,
						this.oParent.Var_5870_MouseNewY - this.oParent.Var_587a_MouseIconYOffset,
						this.oParent.Var_5876_MouseIcon);

					this.oParent.Var_5403 = 1;
				}
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_170b()
		{
			//this.oCPU.Log.EnterBlock("F0_1000_170b()");

			// function body
			if (this.oParent.Var_5876_MouseIcon != 0)
			{
				if (this.oParent.Var_5403 != 0)
				{
					this.oParent.Var_5403 = 0;
				}
			}
		}

		/// <summary>
		/// Handles mouse events
		/// </summary>
		public void F0_1000_17db_MouseEvent()
		{
			//this.oCPU.Log.EnterBlock("F0_1000_17db_MouseEvent()");

			// function body
			this.oCPU.DoEvents();

			this.oParent.Var_5874 |= this.oCPU.BX.UInt16;
			this.oParent.Var_5872_MouseNewButtons = this.oCPU.BX.Int16;
			this.oParent.Var_586e_MouseNewX = this.oCPU.CX.Int16;
			this.oParent.Var_5870_MouseNewY = this.oCPU.DX.Int16;

			// Mouse location changed
			if ((this.oCPU.AX.UInt16 & 0x1) != 0 && this.oParent.Var_5403 != 0)
			{
				if (this.oParent.Var_5402 == 0)
				{
					this.oParent.Var_5402 = 0;
				}
				else
				{
					this.oParent.Var_5402 = 2;
				}
			}
		}
	}
}
