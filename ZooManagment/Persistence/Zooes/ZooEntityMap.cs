using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooManagment.Entities;

namespace ZooManagment.Persistence.Zooes
{
    internal class ZooEntityMap : IEntityTypeConfiguration<Zoo>
    {
        public void Configure(EntityTypeBuilder<Zoo> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).UseIdentityColumn();
            builder.Property(_ => _.Address).HasMaxLength(500).IsRequired();
            builder.Property(_ => _.Title).HasMaxLength(100).IsRequired();



        }
    }
}
