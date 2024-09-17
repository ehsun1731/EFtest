using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagment.Dtos.Zoos
{
    internal class ZoosAndSectionsAndTicketsDto
    {
        public int Id { get; set; }
        public int SectionCount { get; set; }
        public List<int> TicketCosts { get; set; }
        public List<decimal> Ereas { get; set; }
    }
}
