using System;
using System.Text;

namespace _03_Zadanie
{
    internal class SocketLogger : ILogger
    {
        private readonly ClientSocket ClientSocket;

        public SocketLogger(string host, int port)
        {
            ClientSocket = new ClientSocket(host, port);
        }
        public void Log(params string[] messages)
        {
            foreach (var m in messages)
            {

                    byte[] bytes = Encoding.UTF8.GetBytes(m);
                    ClientSocket.Send(bytes);

            }
        }
        public void Dispose()
        {
            ClientSocket.Close();
            GC.SuppressFinalize(this);
        }

    }
}
