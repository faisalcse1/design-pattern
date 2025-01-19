using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class RedisLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Redis Log: {message}");
        }
    }
}
