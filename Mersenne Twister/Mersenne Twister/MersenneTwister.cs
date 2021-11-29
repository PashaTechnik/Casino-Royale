using System;

namespace Mersenne_Twister
{
    public class RandomMersenne
	{
		const int MERS_N = 624;
		const int MERS_M = 397;
		const int MERS_U = 11;
		const int MERS_S = 7;
		const int MERS_T = 15;
		const int MERS_L = 18;
		const uint MERS_A = 0x9908B0DF;
		const uint MERS_B = 0x9D2C5680;
		const uint MERS_C = 0xEFC60000;
 
		public uint[] mt = new uint[MERS_N + 1];
		uint mti = MERS_N + 1;
 
		public RandomMersenne() { }
		public RandomMersenne(uint seed)
		{
			RandomInit(seed);
		}
		public void RandomInit(uint seed)
		{
			mt[0] = seed;
			for (mti = 1; mti < MERS_N; mti++)
				mt[mti] = (1812433253U * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + mti);
		}
		public uint Random()
		{
			uint y;
 
			if (mti >= MERS_N)
			{
				const uint LOWER_MASK = 2147483647;
				const uint UPPER_MASK = 0x80000000;
				uint[] mag01 = { 0, MERS_A };
 
				int kk;
				for (kk = 0; kk < MERS_N - MERS_M; kk++)
				{
					y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
					mt[kk] = mt[kk + MERS_M] ^ (y >> 1) ^ mag01[y & 1];
				}
				for (; kk < MERS_N - 1; kk++)
				{
					y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
					mt[kk] = mt[kk + (MERS_M - MERS_N)] ^ (y >> 1) ^ mag01[y & 1];
				}
				y = (mt[MERS_N - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK);
				mt[MERS_N - 1] = mt[MERS_M - 1] ^ (y >> 1) ^ mag01[y & 1];
				mti = 0;
			}
 
			y = mt[mti++];
			
			y ^= y >> MERS_U;
			y ^= (y << MERS_S) & MERS_B;
			y ^= (y << MERS_T) & MERS_C;
			y ^= y >> MERS_L;
			return y;
		}
	}
	
	// class RandomMersenne
	// {
	// 	private const ulong N = 624;
	// 	private const ulong M = 397;
	// 	private const ulong MATRIX_A = 0x9908B0DFUL;
	// 	private const ulong UPPER_MASK = 0x80000000UL;
	// 	private const ulong LOWER_MASK = 0X7FFFFFFFUL;
	// 	private const uint DEFAULT_SEED = 4357;
	//
	// 	public ulong[] mt = new ulong[N + 1];
	// 	public ulong mti = N + 1;
	//
	// 	public RandomMersenne()
	// 	{
	// 		ulong[] init = new ulong[4];
	// 		init[0] = 0x123;
	// 		init[1] = 0x234;
	// 		init[2] = 0x345;
	// 		init[3] = 0x456;
	// 		ulong length = 4;
	// 		init_by_array(init, length);
	// 	}
	// 	
	// 	public void init_genrand(ulong s)
	// 	{
	// 		mt[0] = s & 0xffffffffUL;
	// 		for (mti = 1; mti < N; mti++)
	// 		{
	// 			mt[mti] = (1812433253UL * (mt[mti - 1] ^ (mt[mti - 1] >> 30)) + mti);
	// 			mt[mti] &= 0xffffffffUL;
	// 		}
	// 	}
	//
	// 	
	// 	public void init_by_array(ulong[] init_key, ulong key_length)
	// 	{
	// 		ulong i, j, k;
	// 		init_genrand(19650218UL);
	// 		i = 1; j = 0;
	// 		k = (N > key_length ? N : key_length);
	// 		for (; k > 0; k--)
	// 		{
	// 			mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1664525UL)) + init_key[j] + j;
	// 			mt[i] &= 0xffffffffUL;
	// 			i++; j++;
	// 			if (i >= N) { mt[0] = mt[N - 1]; i = 1; }
	// 			if (j >= key_length) j = 0;
	// 		}
	// 		for (k = N - 1; k > 0; k--)
	// 		{
	// 			mt[i] = (mt[i] ^ ((mt[i - 1] ^ (mt[i - 1] >> 30)) * 1566083941UL)) - i;
	// 			mt[i] &= 0xffffffffUL;
	// 			i++;
	// 			if (i >= N) { mt[0] = mt[N - 1]; i = 1; }
	// 		}
	// 		mt[0] = 0x80000000UL;
	// 	}
	// 	
	// 	public ulong genrand_int32()
	// 	{
	// 		ulong y = 0;
	// 		ulong[] mag01 = new ulong[2];
	// 		mag01[0] = 0x0UL;
	// 		mag01[1] = MATRIX_A;
	// 		if (mti >= N)
	// 		{
	// 			ulong kk;
	//
	// 			if (mti == N + 1)
	// 				init_genrand(5489UL);
	//
	// 			for (kk = 0; kk < N - M; kk++)
	// 			{
	// 				y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
	// 				mt[kk] = mt[kk + M] ^ (y >> 1) ^ mag01[y & 0x1UL];
	// 			}
	// 			for (; kk < N - 1; kk++)
	// 			{
	// 				y = (mt[kk] & UPPER_MASK) | (mt[kk + 1] & LOWER_MASK);
	// 				mt[kk] = mt[kk - 227] ^ (y >> 1) ^ mag01[y & 0x1UL];
	// 			}
	// 			y = (mt[N - 1] & UPPER_MASK) | (mt[0] & LOWER_MASK);
	// 			mt[N - 1] = mt[M - 1] ^ (y >> 1) ^ mag01[y & 0x1UL];
	//
	// 			mti = 0;
	// 		}
	//
	// 		y = mt[mti++];
	// 		
	// 		y ^= (y >> 11);
	// 		y ^= (y << 7) & 0x9d2c5680UL;
	// 		y ^= (y << 15) & 0xefc60000UL;
	// 		y ^= (y >> 18);
	//
	// 		return y;
	// 	}
	// }
}