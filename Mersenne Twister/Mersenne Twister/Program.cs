using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Mersenne_Twister
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var mt = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            
            //BruteForce();


            //Lcg.SolveLcg();
            //Mt.SolveMt();
            
            //BetterMt.solveBetterMt();
            
            BetterMt.Hacc();
            
            
            //Console.WriteLine(BetterMt.unBitShiftRightXor(-3, 23));




            // using (StreamWriter writetext = new StreamWriter("/Users/pasha/Desktop/file.txt"))
            // {
            //     for (int i = -500; i < 500; i++)
            //     {
            //         newSeed = mt + i;
            //         RandomMersenne m = new RandomMersenne((uint) newSeed);
            //         for (int j = 0; j < 626; j++)
            //         {
            //             writetext.WriteLine(j + " " + m.Random());
            //         }
            //     }
            // }

        }

        // public static void BruteForce()
        // {
        //     using (StreamWriter writetext = new StreamWriter("/Users/pasha/Desktop/file.txt"))
        //     {
        //         string filePath = "/Users/pasha/Desktop/file.txt";
        //         for (int i = 0; i < 4_000_000_000; i++)
        //         {
        //             RandomMersenne m = new RandomMersenne((uint) i);
        //             writetext.WriteLine(i + " " + m.Random());
        //             writetext.WriteLine(i + " " + m.Random());
        //             if (i % 1_000_000 == 0)
        //             {
        //                 Console.WriteLine(i);
        //             }
        //         }
        //     }
        // }
    }
}