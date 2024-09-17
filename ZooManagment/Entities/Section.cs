using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagment.Entities
{
    internal class Section(decimal erea,int animalCount,string description)
    {
        public int Id { get; set; }
        public decimal Erea { get; set; } = erea;
        public int AnimalCount { get; set; } = animalCount;
        public string Description { get; set; } = description;

        public Zoo? Zoo { get; set; }
        public int? ZooId { get; set; }

        public Ticket Ticket { get; set; }
       

        public Animal? Animal { get; set; }
        public int? AnimalId { get; set; }
    }
}
