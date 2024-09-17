using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZooManagment.Dtos.Zoos;
using ZooManagment.Entities;

namespace ZooManagment.Persistence.Zooes
{
    internal class EFZooRepository(EFDataContext context)
    {
        public void Add(Zoo zoo)
        {
            context.Set<Zoo>().Add(zoo);
        }
        public List<GetAllZoosDto> GetAll()
        {
            return context.Set<Zoo>().Select(_ => new GetAllZoosDto
            {
                Id=_.Id,
                Title = _.Title,
                Address=_.Address
                

            }).ToList();
        }
        public Zoo GetById(int id)
        {
          return  context.Set<Zoo>().FirstOrDefault(_ => _.Id == id);
        }
        
        public void Delete(Zoo zoo)
        {
            context.Set<Zoo>().Remove(zoo);
        }
        public List<GetAllZoosWithAnimalsDto> GetAllZoosWithAnimals()
        {
            return context.Set<Zoo>().Include(_ => _.Sections).ThenInclude(_ => _.Animal)
                .Select(_ => new GetAllZoosWithAnimalsDto
                {
                    Id = _.Id,
                    Title = _.Title,
                    Address = _.Address,
                    AnimalName = _.Sections.Select(s => s.Animal.Name).ToList()
                }).ToList();
        }
        public List<ZoosAndSectionsAndTicketsDto> GetZoosAndSectionsAndTickets()
        {
            return context.Set<Zoo>().Include(_ => _.Sections).ThenInclude(_ => _.Ticket)
                 .Select(_ => new ZoosAndSectionsAndTicketsDto
                 {
                     Id = _.Id,
                     SectionCount = _.Sections.Count(),
                     TicketCosts = _.Sections.Select(s => s.Ticket.Cost).ToList(),
                     Ereas =_.Sections.Select(s=>s.Erea).ToList()
                 }).ToList();
        }

    }

}
