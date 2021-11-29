using System;
using System.Collections.Generic;

namespace Mersenne_Twister
{
    // public class BetterMt
    // {
    //     public static void solveBetterMt()
    //     {
    //         RandomMersenne mersenne = new RandomMersenne();
    //         List<long> state = new List<long>();
    //         for (int i = 0; i < 624; i++)
    //         {
    //             var result = (uint) Networking.GetResult("BetterMt", 1239, 1).Result.realNumber;
    //             state.Add(result);
    //             Console.WriteLine($"{i} - {result}");
    //         }
    //         
    //         var initState = backtrace(state.ToArray());
    //
    //         mersenne.mt = initState;
    //         
    //         for (int i = 0; i < 624; i++)
    //         {
    //             Console.WriteLine($"Mine: {state[i]}; Correct: {mersenne.mt[i]}");
    //         }
    //         
    //         Console.WriteLine($"Next Number: {mersenne.genrand_int32()}");
    //         //mersenne.Random();
    //
    //     }
    //
    //     public static long unBitShiftRightXor(long receivedValue, int numOfShifts)
    //     {
    //         long i = 0;
    //         long result = 0;
    //         while (i * numOfShifts < 32)
    //         {
    //             long minusOneShifted = -1 << (32 - numOfShifts);
    //             long partMask = UnsignedRightShift(minusOneShifted, (int)(numOfShifts * i));
    //             long part = receivedValue & partMask;
    //             receivedValue ^= UnsignedRightShift(part, numOfShifts);
    //             result |= part;
    //             i++;
    //         }
    //         return result;
    //     }
    //
    //     public static long unBitShiftLeftXor(long receivedValue, int numOfShifts, long AndMask)
    //     {
    //         long i = 0;
    //         long result = 0;
    //         while (i * numOfShifts < 32)
    //         {
    //             long minusOneShifted = (int)(unchecked((uint)-1) >> (32 - numOfShifts));
    //             long partMask =  minusOneShifted << (int)(numOfShifts * i);
    //             long part = receivedValue & partMask;
    //             receivedValue ^= (part << numOfShifts) & AndMask;
    //             result |= part;
    //             i++;
    //         }
    //         return result;
    //     }
    //
    //     private static ulong getState(long number)
    //     {
    //         number = unBitShiftRightXor(number, 18);
    //         number = unBitShiftLeftXor(number, 15, 0xefc60000);
    //         number = unBitShiftLeftXor(number, 7, 0x9d2c5680);
    //         number = unBitShiftRightXor(number, 11);
    //         return (ulong)number;
    //     }
    //
    //     private static ulong[] backtrace(long[] numbers)
    //     {
    //         List<ulong> state = new List<ulong>();
    //
    //         foreach (var number in numbers)
    //         {
    //             state.Add((ulong)getState(number));
    //         }
    //         return state.ToArray();
    //     }
    //     public static long UnsignedRightShift(long signed, int places)
    //     {
    //         unchecked 
    //         {
    //             var unsigned = (ulong)signed;
    //             unsigned >>= places;
    //             return (long)unsigned;
    //         }
    //     }
    //
    //
    //     // int unBitshiftLeftXor(int value, int shift, int mask) {
    //     //     
    //     //     int i = 0;
    //     //     
    //     //     int result = 0;
    //     //     
    //     //     while (i * shift < 32) {
    //     //         
    //     //         int partMask = (-1 >>> (32 - shift)) << (shift * i);
    //     //         
    //     //         int part = value & partMask;
    //     //         
    //     //         value ^= (part << shift) & mask;
    //     //         
    //     //         result |= part;
    //     //         i++;
    //     //     }
    //     //     return result;
    //     // } 
    //     
    //     
    // }
    
    class BetterMt
	{
		public static long unBitshiftRightXor(long receivedValue, int numOfShifts)
		{
			long i = 0;
			long result = 0;
			while (i * numOfShifts < 32)
			{
				long minusOneShifted = -1 << (32 - numOfShifts);
				long partMask = UnginedRightShiftInt(minusOneShifted, (int)(numOfShifts * i));
				long part = receivedValue & partMask;
				receivedValue ^= UnginedRightShift(part, numOfShifts);
				result |= part;
				i++;
			}
			return result;
		}

		public static long unBitshiftLeftXor(long receivedValue, int numOfShifts, long AndMask)
		{
			long i = 0;
			long result = 0;
			while (i * numOfShifts < 32)
			{
				long minusOneShifted = (int)(unchecked((uint)-1) >> (32 - numOfShifts));
				long partMask =  minusOneShifted << (int)(numOfShifts * i);
				long part = receivedValue & partMask;
				receivedValue ^= (part << numOfShifts) & AndMask;
				result |= part;
				i++;
			}
			return result;
		}

		public static void Hacc()
		{
			RandomMersenne mersenneTwister = new RandomMersenne();
			uint[] state = new uint[624];
			for (int i = 0; i < 624; i++)
			{
				var value = Networking.GetResult("BetterMt", 1243, 1).Result.realNumber;
				value = unBitshiftRightXor(value, 18);
				value = unBitshiftLeftXor(value, 15, 0xefc60000);
				value = unBitshiftLeftXor(value, 7, 0x9d2c5680);
				value = unBitshiftRightXor(value, 11);
				state[i] = (uint)value;
			}

			
			
			for (int i = 0; i < 624; i++)
			{
				Console.WriteLine($"Mine: {state[i]}; Correct: {mersenneTwister.mt[i]}");
			}
			
			mersenneTwister.mt = state;
			long num = (long)mersenneTwister.Random();
			Console.WriteLine(num);
		}

		private static long UnginedRightShift(long valueToShift, int numOfShifts)
		{
			return (long)((ulong)valueToShift >> numOfShifts);
		}

		private static int UnginedRightShiftInt(long valueToShift, int numOfShifts)
		{
			return (int)((uint)valueToShift >> numOfShifts);
		}
	}
}