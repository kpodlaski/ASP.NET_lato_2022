using System;
using System.Collections.Generic;
using System.Text;

namespace Poczta
{
    class Client
    {
        static int lastId = 0; 
        public int ID { get; private set; }
        public volatile bool serviceEnded = false;
        protected Post post;

        public Client(Post post)
        {
            this.post = post;
            ID = lastId++;
        }

        virtual public void clientThread()
        {
            Console.WriteLine("Klient " + this + " wszedł na pocztę");
            post.newClient(this);
            do
            {

            }
            while (!serviceEnded);
            Console.WriteLine("Klient "+this+" wychodzi z poczty");
        }


        public override string ToString()
        {
            return "K"+ID;
        }
    }
}
