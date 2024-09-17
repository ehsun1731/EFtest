using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagment.Entities
{
    internal class Zoo(string title,string address)
    {
        public int Id { get; set; }
        public string Title { get; set; } = title;
        public string Address { get; set; } = address;
        public List <Section> Sections { get; set; }

    }
}
