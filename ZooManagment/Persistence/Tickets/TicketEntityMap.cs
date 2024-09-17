using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagment.Entities;

namespace ZooManagment.Persistence.Tickets
{
    internal class TicketEntityMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).UseIdentityColumn();
            builder.Property(_ => _.SectionId).IsRequired(false);

            builder.HasOne(_ => _.Section)
                .WithOne(_ => _.Ticket)
                .HasForeignKey<Ticket>(_ => _.SectionId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
