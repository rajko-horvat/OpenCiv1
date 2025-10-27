using OpenCiv1.API;
using System;

/// <summary>
/// Marsenne Twister (MT19937), with initialization improved 2002/1/26. Version 1.02
/// </summary>
/// <license>
///		Mixed License
/// 
/// Authors:
///		Takuji Nishimura and Makoto Matsumoto, Copyright(C) 1997 - 2002, All rights reserved.
/// 	Rajko Horvat (https://github.com/rajko-horvat), C# version, 2023
/// 
/// Redistribution and use in source and binary forms, with or without
/// modification, are permitted provided that the following conditions
/// are met:
/// 
/// 1.Redistributions of source code must retain the above copyright
/// notice, this list of conditions and the following disclaimer.
/// 
/// 2. Redistributions in binary form must reproduce the above copyright
/// notice, this list of conditions and the following disclaimer in the
/// documentation and/or other materials provided with the distribution.
/// 
/// 3. The names of its contributors may not be used to endorse or promote 
/// products derived from this software without specific prior written 
/// permission.
/// 
/// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
/// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
/// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
/// A PARTICULAR PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL THE COPYRIGHT OWNER OR
/// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
/// EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
/// PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
/// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
/// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
/// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
/// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
/// </license>
[Serializable]
public class RandomMT19937
{
	// Fields
	private const int matrixLength = 624;
	private const int matrixMedian = 397;
	private const uint upperMask = 0x80000000U; // Most significant w-r bits
	private const uint lowerMask = 0x7fffffffU; // Least significant r bits

	private RandomMT19937State state;
	private uint[] matrixA = new uint[] { 0x0U, 0x9908b0dfU }; // Constant Vector A = 0x9908b0dfU

	// Methods
	public RandomMT19937() : this(Environment.TickCount)
	{ }

	// initializes matrix[N] with a seed
	public RandomMT19937(int seed)
	{
		this.state = new RandomMT19937State(matrixLength);

		this.state.Matrix[0] = (uint)seed & 0xffffffffU; // for >32 bit machines

		// generate matrixLength words at one time
		for (int i = 1; i < matrixLength; i++)
		{
			this.state.Matrix[i] = (1812433253U * (this.state.Matrix[i - 1] ^ (this.state.Matrix[i - 1] >> 30)) + (uint)i);
			// See Knuth TAOCP Vol 2. 3rd Ed. P.106 for multiplier.
			// In the previous versions, MSBs of the seed affect only MSBs of the array aMatrix[].
			// 2002/01/09 modified by Makoto Matsumoto
			this.state.Matrix[i] &= 0xffffffffU; // for >32 bit machines
		}
	}

	/// <summary>
	/// Generates a random number on [0,0xffffffff] interval
	/// </summary>
	/// <returns></returns>
	private uint InternalSample()
	{
		uint value;

		if (this.state.MatrixIndex >= matrixLength)
		{
			// generate matrixLength words at one time
			int i;

			for (i = 0; i < matrixLength - matrixMedian; i++)
			{
				value = (this.state.Matrix[i] & upperMask) | (this.state.Matrix[i + 1] & lowerMask);
				this.state.Matrix[i] = this.state.Matrix[i + matrixMedian] ^ (value >> 1) ^ matrixA[value & 1];
			}

			for (; i < matrixLength - 1; i++)
			{
				value = (this.state.Matrix[i] & upperMask) | (this.state.Matrix[i + 1] & lowerMask);
				this.state.Matrix[i] = this.state.Matrix[i + (matrixMedian - matrixLength)] ^ (value >> 1) ^ matrixA[value & 1];
			}

			value = (this.state.Matrix[matrixLength - 1] & upperMask) | (this.state.Matrix[0] & lowerMask);
			this.state.Matrix[matrixLength - 1] = this.state.Matrix[matrixMedian - 1] ^ (value >> 1) ^ matrixA[value & 1];

			this.state.MatrixIndex = 0;
		}

		value = this.state.Matrix[this.state.MatrixIndex++];

		// Tempering
		value ^= (value >> 11);
		value ^= (value << 7) & 0x9d2c5680U;
		value ^= (value << 15) & 0xefc60000U;
		value ^= (value >> 18);

		return value;
	}

	public virtual uint UNext()
	{
		return this.InternalSample();
	}

	public virtual int Next()
	{
		return (int)(this.InternalSample() >> 1);
	}

	/// <summary>
	/// Generates a random number on [0, maxValue) Int32 interval
	/// </summary>
	/// <param name="maxValue"></param>
	/// <returns></returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	public virtual int Next(int maxValue)
	{
		return (int)(this.Sample() * maxValue);
	}

	public virtual int Next(int minValue, int maxValue)
	{
		if (minValue > maxValue)
		{
			throw new ArgumentOutOfRangeException("minValue", "'minValue' cannot be greater than maxValue.");
		}
		long num = maxValue - minValue;
		
		return (((int)(this.Sample() * num)) + minValue);
	}

	public virtual void NextBytes(byte[] buffer)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		for (int i = 0; i < buffer.Length; i++)
		{
			// (this.InternalSample() & 0xff) is the same, but faster than (this.InternalSample() % 0x100)
			buffer[i] = (byte)(this.InternalSample() & 0xff);
		}
	}

	/// <summary>
	/// Generates a random number on [0,1) real interval
	/// </summary>
	/// <returns></returns>
	public virtual double NextDouble()
	{
		return this.Sample();
	}

	/// <summary>
	/// Generates a random number on [0,1) real interval
	/// </summary>
	/// <returns></returns>
	protected virtual double Sample()
	{
		// (1.0 / 4294967296.0) = 2.3283064365386962890625e-10
		return (this.InternalSample() * 2.3283064365386962890625e-10);
	}

	public RandomMT19937State State { get => this.State; set => this.state = value; }
}
