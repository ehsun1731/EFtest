using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagment.Entities
{
    internal class Animal(string name)

    {
        public int Id { get; set; }
        public string Name { get; set; } = name;
        public  List<Section> Sections { get; set; }
        
    }
}
