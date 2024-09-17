using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagment.Entities;
using ZooManagment.Persistence.Zooes;

namespace ZooManagment
{
    internal class EFDataContext : DbContext
    {

        public DbSet<Zoo> Zoos { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=.; Initial Catalog= ZooManagment;Integrated Security=true;" +
                "Trust Server Certificate=true;");
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(
                    typeof(ZooEntityMap).Assembly);
        }
    }
}
