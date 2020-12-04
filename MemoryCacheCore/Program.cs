using MemoryCacheLib;
using System;
using System.Threading;

namespace MemoryCacheCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MemoryCacheExtension.AddValue("1", "test 1", 60);
            var val = MemoryCacheExtension.GetValue("1");
            Console.WriteLine($"Value of cache: {val}");
            int count = 1;
            while (count < 70)
            {
                count++;
                Thread.Sleep(1000);
                Console.WriteLine($"Thread sleep: {count} s");
            }
            var val1 = MemoryCacheExtension.GetValue("1");
            Console.WriteLine($"Value of cache: {val1}");
            Console.ReadLine();
        }
    }
}
