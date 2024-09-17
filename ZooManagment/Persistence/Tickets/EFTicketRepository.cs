using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagment.Entities;

namespace ZooManagment.Persistence.Tickets
{
    internal class EFTicketRepository(EFDataContext context)
    {
        public void Add(Ticket ticket)
        {
            context.Set<Ticket>().Add(ticket);
        }
    }
}
