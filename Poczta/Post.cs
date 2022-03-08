using System;
using System.Collections.Generic;

namespace Poczta
{
    internal class Post
    {
        private List<Client> clients = new List<Client>();

        public volatile bool AllClientsGenerated = false;

        public Client getNextClient()
        {
            Client c = null;
            lock(this){ 
                if (clients.Count > 0)
                {
                    c = clients[0];
                    clients.RemoveAt(0);
                }
            }
            return c;
        }

        public void newClient(Client client) {
            lock (this)
            {
                clients.Add(client);
            }
        }
    }
}