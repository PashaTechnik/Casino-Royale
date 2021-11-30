using System;

namespace Mersenne_Twister
{
    public class Lcg
    {
        const long m = 4294967296;
        
        public static void SolveLcg()
        {
            var x1 = Networking.GetResult("Lcg", 1228, 1).Result.realNumber;
            var x2 = Networking.GetResult("Lcg", 1228, 1).Result.realNumber;
            var x3 = Networking.GetResult("Lcg", 1228, 1).Result.realNumber;

            Console.WriteLine($"x1 = {x1}");
            Console.WriteLine($"x2 = {x2}");
            Console.WriteLine($"x3 = {x3}");

            var M = 0;
            var m = 4294967296;
            long a = 0;

            for (int i = -1_000_000; i < int.MaxValue; i++)
            {
                double temp = x2 - x3 - i * m;
                double _a = temp / (x1 - x2);

                if (Math.Floor(_a) == _a)
                {
                    a = Convert.ToInt64(_a);
                    Console.WriteLine($"a = {a}");
                    M = i;
                    break;
                }
            }
            
            long c = 0;
            
            var coef = a * (x1 + x2);
            c = (x3 + x2 - (m * M) - coef) / 2;

            if (c < 0)
            { 
                while (c < int.MinValue)
                {
                    c -= m;
                }
            }
            if (c > 0)
            {
                while (c > int.MaxValue)
                {
                    c -= m;
                }
            }

            Console.WriteLine($"c = {c}");

            Console.WriteLine($"Next Number: {Next(a,c,x3)}");
            
        }
        
        private static long Next(long a, long c, long last)
        {
    
            last = ((a * last) + c) % m;
            return last;
        }
    }
}

//197373647 = (a * 3576682619 + c) % pow(2,32)
//1511091214 = (a * 197373647 + c) % pow(2,32)
//197373647 = (3576682619 * a)%pow(2,32) + c%pow(2,32)
//197373647 = (3576682619 * a)%pow(2,32) + c%pow(2,32)
// c%pow(2,32) = 197373647 - (3576682619 * a) % pow(2,32)
// m = (k*a) % pow(2,32) + l - (a*m)%pow(2,32)

//7870493 = (4294967296 + (96284334.0 * 76616377)/937293398.0

    
//var coef1 = double(x1) - double(x2)
//var coef2 = double(x2) - double(x3)
//var i = 0.0
//var mult = 0
//coef2 = (coef1*a)%2^32