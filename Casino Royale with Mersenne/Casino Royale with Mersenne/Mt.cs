using System;
using System.Collections.Generic;
using System.Linq;

namespace Mersenne_Twister
{
    public class Mt
    {
        public static void SolveMt()
        {
            var mt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            long newSeed = 0;

            List<long> resultList = new List<long>();

            for (int i = -500; i < 500; i++)
            {
                newSeed = mt + i;
                // RandomMersenne m = new RandomMersenne((uint) newSeed);
                // for (int j = 0; j < 626; j++)
                // {
                //     resultList.Add(m.Random());
                // }
            }
            
            var number = Networking.GetResult("Mt", 1229, 1).Result.realNumber;
            
            int index = resultList.IndexOf(number);

            Console.WriteLine(index);

            Console.WriteLine($"Next Number: {resultList[index + 1]}");
            
        }
        

    }
}