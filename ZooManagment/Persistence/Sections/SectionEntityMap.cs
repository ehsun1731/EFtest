using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagment.Entities;

namespace ZooManagment.Persistence.Sections
{
    internal class SectionEntityMap : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).UseIdentityColumn();
            builder.Property(_ => _.Description).HasMaxLength(500).IsRequired();
            builder.Property(_ => _.AnimalCount).IsRequired();
            builder.Property(_ => _.Erea).HasPrecision(5, 3).IsRequired();

            builder.Property(_ => _.AnimalId).IsRequired(false);
            builder.Property(_ => _.ZooId).IsRequired(false);


            builder.HasOne(_ => _.Animal)
                .WithMany(_ => _.Sections)
                .HasForeignKey(_ => _.AnimalId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(_ => _.Zoo)
                .WithMany(_ => _.Sections)
                .HasForeignKey(_ => _.ZooId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
