using System;

namespace SingletonPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Singleton objectOne=Singleton.Instance;
            Singleton objectTwo=Singleton.Instance;


            
            Console.ReadKey();
        }
    }
}
