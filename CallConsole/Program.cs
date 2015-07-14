using System;
using CallSharp;
using CallSharp.Tests;

namespace CallConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var sample = new SampleClass();

            var id = sample.Call(s => s.GetName(42)).On<string, NotImplementedException>("test")();

            Console.WriteLine(id);
            Console.ReadLine();
        }
    }
}
