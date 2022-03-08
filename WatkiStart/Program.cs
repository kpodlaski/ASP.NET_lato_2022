using System;
using System.Collections.Generic;
using System.Threading;

namespace WatkiStart
{
    class Program
    {
        String monitor = "Monitor";

        void countA()
        {
            int i = 0;
            while (true)
            {
                Console.WriteLine("A");
                Console.WriteLine(i++);
                Console.WriteLine("A");
            }
        }

        void countB()
        {
            int i = 10000;
            while (true)
            {
                Console.WriteLine("B");
                Console.WriteLine(i--);
                Console.WriteLine("B");
            }
        }

        volatile int x = 0;

        void evenNumbers()
        {
            while (true)
            {
                lock(this.monitor) { 
                    x++;
                    x++;
                }
            }
        }

        void checkParity()
        {
            int _x;
            while (true)
            {
                lock (this.monitor)
                {
                    _x = x;
                }
                if (_x%2 != 0)
                {
                    Console.WriteLine("X:");
                    Console.WriteLine(_x);
                    Console.WriteLine(x);
                    //Thread.Sleep(12);
                    throw new Exception("Not even number");
                    
                }
            }
        }

        void getFromList()
        {
            while (true)
            {
                int x = queue.Count;
                Console.WriteLine(x);
                Thread.Sleep(30);
            }
        }

        void addToList()
        {
            int x = 0;
            while (true)
            {
                queue.Add("Alojzy"+x);
                x++;
                Thread.Sleep(5);
            }
        }

        List<String> queue = new List<String>();

        static void Main(string[] a)
        {
            Program p = new Program();
            Thread threadA = new Thread(p.getFromList);
            Thread threadB = new Thread(p.addToList);
            threadA.Start();
            threadB.Start();

        }


        static void Main2(string[] args)
        {
            Program p = new Program();
            Thread threadA = new Thread(p.evenNumbers);
            Thread threadB = new Thread(p.checkParity);
            threadA.Start();
            threadB.Start();
            Console.WriteLine("Start");
        }

        static void Main3(string[] a)
        {
            List<String> myList = new List<String>();
            myList.Add("Ala");
            myList.Add("ma");
            myList.Add("kota");

            while (myList.Count > 0)
            {
                String s = myList[0];
                myList.Remove(s);
                Console.WriteLine(s);
            }
        }
    }
}
