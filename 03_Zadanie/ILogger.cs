using System;

namespace _03_Zadanie
{
    internal interface ILogger : IDisposable
    {
        void Log(params string[] messages);
    }
}
