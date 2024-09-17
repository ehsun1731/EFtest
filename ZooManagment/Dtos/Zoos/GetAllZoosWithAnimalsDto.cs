using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooManagment.Dtos.Zoos
{
    internal class GetAllZoosWithAnimalsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public List<string> AnimalName { get; set; }

    }
}
