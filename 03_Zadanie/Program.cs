namespace _03_Zadanie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger[] loggers = new ILogger[]
                { 
                    new SocketLogger("google.com", 80),
                    new ConsoleLogger(),
                    new FileLogger("log.txt"),
                    // works cuz of interface Ilogger
                     new CommonLogger(new ILogger[]
                    {
                        new SocketLogger("google2.com", 80),
                        new ConsoleLogger(),
                        new FileLogger("log2.txt")
                    })

                };
            using var logger = new CommonLogger(loggers);
            logger.Log("E msg 1");
            logger.Log("E msg 2");
            logger.Log("E msg 3", "val1", "val4", "val3");
        }
    }
}
