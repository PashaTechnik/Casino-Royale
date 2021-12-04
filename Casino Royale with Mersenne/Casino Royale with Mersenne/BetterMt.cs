using System;
using System.Collections.Generic;

namespace Mersenne_Twister
{
    public class BetterMt
    {
        public static void solveBetterMt()
        {
	        Random rand = new Random();
	        var id = rand.Next(1_000, 10_000);
	        Networking.CreateAccount(id);
            RandomMersenne mersenne = new RandomMersenne();
            uint[] state = new uint[624];
            for (int i = 0; i < 624; i++)
            {
                var result = (uint) Networking.GetResult("BetterMt", id, 1).Result.realNumber;
                state[i] = result;
                Console.WriteLine($"{i} - {result}");
            }
            
            var initState = backtrace(state);
    
            mersenne.mt = initState;

            var num = mersenne.Random();
            
            var response = Networking.GetResult("BetterMt", id, num).Result.message;
            Console.WriteLine(num);
            Console.WriteLine(response);

        }
        public static long unBitShiftRightXor(long receivedValue, int numOfShifts)
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
        
        	public static long unBitShiftLeftXor(long receivedValue, int numOfShifts, long AndMask)
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
    
        private static ulong getState(long number)
        {
            number = unBitShiftRightXor(number, 18);
            number = unBitShiftLeftXor(number, 15, 0xefc60000);
            number = unBitShiftLeftXor(number, 7, 0x9d2c5680);
            number = unBitShiftRightXor(number, 11);
            return (ulong)number;
        }
    
        private static uint[] backtrace(uint[] numbers)
        {
            List<uint> state = new List<uint>();
    
            foreach (var number in numbers)
            {
                state.Add((uint)getState(number));
            }
            return state.ToArray();
        }
        public static long UnsignedRightShift(long signed, int places)
        {
            unchecked 
            {
                var unsigned = (ulong)signed;
                unsigned >>= places;
                return (long)unsigned;
            }
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
    