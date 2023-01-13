using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
           
            while (a < 10)
            {
                
                a = a + 1;
                a = a + 2;
                a = a + 3;
                a = a + 4;
                a = a + 5;
                a = a + 6;
                a = a + 7;
                a = a + 8;
                a = a + 9;

            }
            int b = (a + a + a + a + a + a + a + a + a) / (2) / 9;
            Console.WriteLine(b);
            
        }
    }
}
