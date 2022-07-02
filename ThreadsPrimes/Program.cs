using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ThreadsPrimes
{
    class Program
    {

        static void make(bool isEnd, object locker, int firstNumber, int amountOfFound)
        {

        }
        static void Main(string[] args)
        {
            bool isEnd = false;
            object locker = new object();
            int firstNumber = 2;
            int amountOfFound = 0;
            Action<int, int, object > action = (firstNumber, amountOfFound, locker) =>
            {
                while (!isEnd)
                {
                    int number;
                    lock (locker)
                    {
                        number = firstNumber;
                        firstNumber++;
                    }
                    if (isPrimeNumber(number))
                    {
                        lock (locker)
                        {
                            amountOfFound++;
                        }
                    }
                }
            };

            var thread0 = new Thread(() => action(firstNumber, amountOfFound, locker));
            //var thread1 = new Thread(() => {
            //    while (!isEnd)
            //    {
            //        int number;
            //        lock (locker)
            //        {
            //            number = firstNumber;
            //            firstNumber++;
            //        }
            //        if (isPrimeNumber(number))
            //        {
            //            lock (locker)
            //            {
            //                amountOfFound++;
            //            }
            //        }
            //    }
            //});
            //var thread2 = new Thread(() => {
            //    while (!isEnd)
            //    {
            //        int number;
            //        lock (locker)
            //        {
            //            number = firstNumber;
            //            firstNumber++;
            //        }
            //        if (isPrimeNumber(number))
            //        {
            //            lock (locker)
            //            {
            //                amountOfFound++;
            //            }
            //        }
            //    }
            //});
            //var thread3 = new Thread(() => {
            //    while (!isEnd)
            //    {
            //        int number;
            //        lock (locker)
            //        {
            //            number = firstNumber;
            //            firstNumber++;
            //        }
            //        if (isPrimeNumber(number))
            //        {
            //            lock (locker)
            //            {
            //                amountOfFound++;
            //            }
            //        }
            //    }
            //});
            //var thread4 = new Thread(() => {
            //    while (!isEnd)
            //    {
            //        int number;
            //        lock (locker)
            //        {
            //            number = firstNumber;
            //            firstNumber++;
            //        }
            //        if (isPrimeNumber(number))
            //        { 
            //            lock (locker)
            //            {
            //                amountOfFound++;
            //            }
            //        }
            //    }
            //});
            //thread1.Start();
            //thread2.Start();
            //thread3.Start();
            //thread4.Start();
            thread0.Start();
            Thread.Sleep(1000);
            isEnd = true;
            //thread1.Join();
            //thread2.Join();
            //thread3.Join();
            //thread4.Join();

            Console.WriteLine(amountOfFound);

        }

     public static bool isPrimeNumber(int number)
        {
            double limit = Math.Floor(Math.Sqrt(number));
            for (int i = 2; i <= limit; ++i)
            {
                if (number % i == 0)
                    {
                return false;
                    }
            }
            return number >= 2;
        }
    }
}
