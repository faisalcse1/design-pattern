using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new LoggerFactory();

            var memoryLogger = factory.CreateLogger(LoggerType.Memory);
            memoryLogger.Log("This is a simulated memory logger.");

            var redisLogger = factory.CreateLogger(LoggerType.Redis);
            redisLogger.Log("This is a simulated Redis logger.");
        }
    }
}
