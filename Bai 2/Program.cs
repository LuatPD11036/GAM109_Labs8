using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bai2
{
    internal class Program
    {
        static void Thread1FuntionLab8()
        {
            lock (lock1)
            {
                Console.WriteLine("Thead 1 locked lock 1");
                Thread.Sleep(100);
                Console.WriteLine("Thead 1 is waiting for lock 2");
                lock (lock2)
                {
                    Console.WriteLine("Thead 1 locked lock 2");
                }
            }
        }
        static void Thread2FuntionLab8()
        {
            lock (lock2)
            {
                Console.WriteLine("Thead 2 locked lock 2");
                Thread.Sleep(100);
                Console.WriteLine("Thead 2 is waiting for lock 1");
                lock (lock1)
                {
                    Console.WriteLine("Thead 2 locked lock 1");
                }
            }
        }
        public void bai2()
        {
            Thread thread1 = new Thread(Thread1FuntionLab8);
            Thread thread2 = new Thread(Thread2FuntionLab8);
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine("end start");
        }
        static object lock1 = new object();
        static object lock2 = new object();
        static void Main(string[] args)
        {
            Program program = new Program();
            program.bai2();
            Console.ReadLine();
        }
    }
}