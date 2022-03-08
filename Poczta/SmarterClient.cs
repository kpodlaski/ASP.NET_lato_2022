using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Poczta
{
    class SmarterClient : Client
    {
        public SmarterClient(Post post) : base(post)
        {
        }

        override public void clientThread()
        {
            Console.WriteLine("Klient " + this + " wszedł na pocztę");
            post.newClient(this);
            lock (this)
            {
                Monitor.Wait(this);
            }
            Console.WriteLine("Klient " + this + " wychodzi z poczty");
        }

        public void ServiceHaveEnded()
        {
            lock (this)
            {
                Monitor.Pulse(this);
            }
        }
    }
}
