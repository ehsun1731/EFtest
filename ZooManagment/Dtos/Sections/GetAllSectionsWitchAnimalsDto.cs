using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagment.Dtos.Sections
{
    internal class GetAllSectionsWitchAnimalsDto
    {
        public int Id { get; set; }
        public decimal  Erea { get; set; }
        public string  Description { get; set; }
        public string  AnimalName { get; set; }
        public int AnimalCount { get; set; }
    }
}
