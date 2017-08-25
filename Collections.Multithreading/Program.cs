using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace Collections.Multithreading
{

    class Program
    {
        private static ConcurrentQueue<char> queue;
        private static Queue<char> normalQueue;

        private static void PushA()
        {
            Thread.Sleep(500);
            for (int i=0;i<50;i++)
            {
                queue.Enqueue('A');
            }
        }

        private static void PushB()
        {
            Thread.Sleep(500);
            for (int i = 0; i < 50; i++)
            {
                queue.Enqueue('B');
            }
        }

        private static void PushNormalA()
        {
            Thread.Sleep(500);
            for (int i = 0; i < 400; i++)
            {
                //lock (normalQueue)
                {
                    normalQueue.Enqueue('A');
                }
            }
        }

        private static void PushNormalB()
        {
            Thread.Sleep(500);
            for (int i = 0; i < 400; i++)
            {
                //lock(normalQueue)
                {
                    normalQueue.Enqueue('B');
                }
            }
        }

        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello World!");
            queue = new ConcurrentQueue<char>();
            normalQueue = new Queue<char>();
            ICollection ic = normalQueue;
            

            Thread t1 = new Thread(new ThreadStart(PushA));
            Thread t2 = new Thread(new ThreadStart(PushB));

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();
            
            char c;
            Console.Write("CONCURRENT: ");
            while (queue.TryDequeue(out c))
            {
                Console.Write(c);
            }
            Console.WriteLine();
            Console.WriteLine();

            Thread t3 = new Thread(new ThreadStart(PushNormalA));
            Thread t4 = new Thread(new ThreadStart(PushNormalB));

            t3.Start();
            t4.Start();

            t3.Join();
            t4.Join();
            Console.Write("NORMAL:     ");
            while (normalQueue.Count > 0)
            {
                Console.Write(normalQueue.Dequeue());
            }
            Console.WriteLine();
            
            Console.Read();
        }
    }
}