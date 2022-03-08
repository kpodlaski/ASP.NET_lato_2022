using System;
using System.Threading;

namespace Poczta
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Otwieram Pocztę");
            Post post = new Post();
            int numberOfClients = 10;
            int numberOfClerks = 3;
            
            for (int i=0; i<Math.Max(numberOfClerks, numberOfClients); i++)
            {
                if (i < numberOfClerks)
                {
                    Clerk c = new Clerk(post);
                    Thread t = new Thread(c.clerkThread);
                    t.Start();
                }
                if (i < numberOfClients)
                {
                    Client c = new SmarterClient(post);
                    Thread t = new Thread(c.clientThread);
                    t.Start();
                }
            }
            post.AllClientsGenerated = true;
            
        }
    }
}
