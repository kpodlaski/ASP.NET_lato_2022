using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Poczta
{
    class Clerk
    {
        static int lastId = 0;
        private Random rand = new Random();
        public int ID { get; private set; }
        private Post post;

        public Clerk(Post post)
        {
            this.post = post;
            this.ID = lastId++;
        }

        void processClient(Client c)
        {
            Console.WriteLine("Okienko " + this + " obsługuje klienta " + c);
            int tsleep = rand.Next(20, 60);
            Thread.Sleep(tsleep);
            Console.WriteLine("Okienko " + this + " obsłużyło klienta " + c);
            if (c is SmarterClient)
            {
                ((SmarterClient)c).ServiceHaveEnded();
            }
            else
            {
                c.serviceEnded = true;
            }
        }
        
        public void clerkThread()
        {
            while (!post.AllClientsGenerated)
            {
                Client c = post.getNextClient();
                while (c != null)
                {
                    processClient(c);
                    c = post.getNextClient();
                }
            }
            Console.WriteLine("Okienko " + this + " skończyło pracę");
        }

        public override string ToString()
        {
            return "O"+ID;
        }

    }
}
