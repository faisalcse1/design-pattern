using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class MemoryLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Memory Log: {message}");
        }
    }
}
