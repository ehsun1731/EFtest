using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagment.Dtos.Animals;
using ZooManagment.Dtos.Zoos;
using ZooManagment.Entities;

namespace ZooManagment.Persistence.Animals
{
    internal class EFAnimalRepository(EFDataContext context)
    {
        public void Add(Animal animal)
        {
            context.Set<Animal>().Add(animal);
        }
        public List<GetAllAnimalsDto> GetAll()
        {
            return context.Set<Animal>().Select(_ => new GetAllAnimalsDto
            {
                Id = _.Id,
                Name = _.Name


            }).ToList();
        }
        //public Animal GetById(int id)
        //{
        //    return context.Set<Animal>().FirstOrDefault(_ => _.Id == id);
        //}



    }
}
