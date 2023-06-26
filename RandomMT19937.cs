using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

/* 
   MT19937, with initialization improved 2002/1/26.
   Coded by Takuji Nishimura and Makoto Matsumoto.

   Copyright (C) 1997 - 2002, Makoto Matsumoto and Takuji Nishimura,
   All rights reserved.                          

   Redistribution and use in source and binary forms, with or without
   modification, are permitted provided that the following conditions
   are met:

	 1. Redistributions of source code must retain the above copyright
		notice, this list of conditions and the following disclaimer.

	 2. Redistributions in binary form must reproduce the above copyright
		notice, this list of conditions and the following disclaimer in the
		documentation and/or other materials provided with the distribution.

	 3. The names of its contributors may not be used to endorse or promote 
		products derived from this software without specific prior written 
		permission.

   THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
   "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
   LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
   A PARTICULAR PURPOSE ARE DISCLAIMED.  IN NO EVENT SHALL THE COPYRIGHT OWNER OR
   CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
   EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
   PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
   PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
   LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
   NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
   SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.


   Any feedback is very welcome.
   http://www.math.sci.hiroshima-u.ac.jp/~m-mat/MT/emt.html
   email: m-mat @ math.sci.hiroshima-u.ac.jp (remove space)
 
 ***********************************************************************************
 
   C# version (revision 1.01) by:
   Rajko Horvat
   Laboratory for information systems, Division of Electronics
   Rudjer Boskovic Institute, Croatia
   e-mail: rhorvat @ irb.hr (remove space)
   
   Any suggestions or bug reports are welcome
   
 ***********************************************************************************
*/
[Serializable, ComVisible(true)]
public class RandomMT19937
{
	// Fields
	private const int N = 624;
	private const int M = 397;
	private const uint MATRIX_A = 0x9908b0dfU;   // constant vector a
	private const uint UPPER_MASK = 0x80000000U; // most significant w-r bits
	private const uint LOWER_MASK = 0x7fffffffU; // least significant r bits

	private uint[] mt = new uint[N]; // the array for the state vector
	private int mti = N + 1; // mti==N+1 means mt[N] is not initialized
	private uint[] mag01 = new uint[] { 0x0U, MATRIX_A }; // mag01[x] = x * MATRIX_A  for x=0,1

	// Methods
	public RandomMT19937()
		: this((uint)Environment.TickCount)
	{
	}

	// initializes mt[N] with a seed
	public RandomMT19937(uint Seed)
	{
		mt[0] = Seed & 0xffffffffU; // for >32 bit machines
		for (mti = 1; mti < N; mti++)
		{
			mt[mti] = (1812433253U * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + (uint)mti);
			// See Knuth TAOCP Vol2. 3rd Ed. P.106 for multiplier.
			// In the previous versions, MSBs of the seed affect
			// only MSBs of the array mt[].
			// 2002/01/09 modified by Makoto Matsumoto
			mt[mti] &= 0xffffffffU; // for >32 bit machines
		}
	}

	/* generates a random number on [0,0xffffffff]-interval */
	private uint InternalSample()
	{
		uint y;

		if (mti >= N)
		{
			/* generate N words at one time */
			int kk;

			for (kk = 0; kk < N - M; kk++)
			{
				y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
				mt[kk] = mt[kk + M] ^ (y >> 1) ^ mag01[y & 0x1U];
			}
			for (; kk < N - 1; kk++)
			{
				y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
				mt[kk] = mt[kk + (M - N)] ^ (y >> 1) ^ mag01[y & 0x1U];
			}
			y = (mt[N - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK);
			mt[N - 1] = mt[M - 1] ^ (y >> 1) ^ mag01[y & 0x1U];

			mti = 0;
		}

		y = mt[mti++];

		/* Tempering */
		y ^= (y >> 11);
		y ^= (y << 7) & 0x9d2c5680U;
		y ^= (y << 15) & 0xefc60000U;
		y ^= (y >> 18);

		return y;
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
		if (maxValue <= 0)
		{
			throw new ArgumentOutOfRangeException("maxValue", "'maxValue' must be greater than zero.");
		}
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
		return (this.InternalSample() * 2.3283064365386962890625e-10);
		// (1.0 / 4294967296.0) = 2.3283064365386962890625e-10
	}
}
