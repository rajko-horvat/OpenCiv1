using Disassembler;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCiv1
{
	public class CivStringMatch:IComparable<CivStringMatch>
	{
		public ushort Start;
		public ushort End;
		public string String;

		public CivStringMatch(CPU cpu, ushort stringPtr)
		{
			uint uiAddress = CPU.ToLinearAddress(0x3b01, stringPtr);

			this.Start = stringPtr;
			this.String = cpu.ReadString(uiAddress);
			this.End = (ushort)(stringPtr + this.String.Length);
		}

		public string FormatttedString
		{
			get
			{
				StringBuilder builder = new StringBuilder();
				for (int i = 0; i < this.String.Length; i++)
				{
					char ch=this.String[i];
					if (ch == '\n')
					{
						builder.Append("\\n");
					}
					else if (ch == '\\')
					{
						builder.Append(@"\\");
					}
					else if (ch < ' ')
					{
						//throw new Exception($"Unknown character 0x{(int)ch:x2}");
						builder.Append($"\\x{(int)ch:x4}");
					}
					else if (ch >= ' ' && ch < (char)127)
					{
						builder.Append(ch);
					}
					else
					{
						builder.Append($"\\x{(int)ch:x4}");
					}
				}

				return builder.ToString();
			}
		}

		public int CompareTo(CivStringMatch other)
		{
			return this.Start.CompareTo(other.Start);
		}
	}
}
