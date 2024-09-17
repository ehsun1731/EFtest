using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagment.Dtos.Sections;
using ZooManagment.Entities;

namespace ZooManagment.Persistence.Sections
{
    internal class EFSectionRepository(EFDataContext context)
    {
        public void Add(Section section)
        {
            context.Set<Section>().Add(section);
        }
        public List<GetAllSectionsWitchAnimalsDto> GetAll()
        {
           return context.Set<Section>().Include(_=>_.Animal).Select(_ => new GetAllSectionsWitchAnimalsDto 
            { 
               Id=_.Id,
               Erea=_.Erea,
               Description=_.Description,
               AnimalName=_.Animal.Name,
               AnimalCount=_.AnimalCount
               

            
            
            }).ToList();
        }
        public Section GetById(int id)
        {
            return context.Set<Section>().FirstOrDefault(_ => _.Id == id);
        }
        public void Delete(Section section)
        {
            context.Set<Section>().Remove(section);
        }

    }
}
