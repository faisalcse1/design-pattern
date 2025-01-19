using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class LoggerFactory
    {
        public ILogger CreateLogger(LoggerType type)
        {
            switch (type)
            {
                case LoggerType.Memory:
                    return new MemoryLogger();
                case LoggerType.Redis:
                    return new RedisLogger();
                default:
                    throw new ArgumentException("Invalid logger type.");
            }
        }
    }
}
