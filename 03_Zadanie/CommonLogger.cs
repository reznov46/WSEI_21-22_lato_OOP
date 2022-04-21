using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Zadanie
{
    internal class CommonLogger : ILogger
    {
        private ILogger[] Loggers;
        public CommonLogger(ILogger[] _loggers)
        {
            Loggers = _loggers;
        }
        public void Log(params string[] messages)
        {
            foreach (var loger in Loggers)
                loger.Log(messages);
        }
        public void Dispose()
        {
            foreach (var logger in Loggers)
                logger.Dispose();
        }
    }
}
