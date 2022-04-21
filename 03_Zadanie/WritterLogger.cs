using System;
using System.IO;

namespace _03_Zadanie
{
    internal abstract class WritterLogger : ILogger
    {
        protected TextWriter writer;
        private const string DateFormat = "yyyy-MM-ddTHH:mm:sszzz";
        public abstract void Dispose();
        public virtual void Log(params string[] messages)
        {
            DateTime time = DateTime.Now;
            writer.Write($"{time.ToString(DateFormat)} ");
            foreach (string m in messages)
                writer.Write($"{m} ");
            writer.Write('\n');
            writer.Flush();
        }
    }
}
