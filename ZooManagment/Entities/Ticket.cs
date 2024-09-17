using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagment.Entities
{
    internal class Ticket(int cost,int count)
    {
        public int Id { get; set; }
        public int Cost { get; set; } = cost;
        public int Count { get; set; } = count;
        public Section? Section { get; set; }
        public int? SectionId { get; set; }
        
    }
}
