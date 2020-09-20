using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.Core.Concrete.EntityFrameworkCore.Mapping
{
    public class PerfumeMap : IEntityTypeConfiguration<Perfume>
    {
        public void Configure(EntityTypeBuilder<Perfume> builder)
        {
            builder.ToTable("PS_Perfume");
            builder.HasKey(x => x.PerfumeId);
            builder.Property(x => x.PerfumeId).UseIdentityColumn();

            builder.Property(x => x.PerfumeName).IsRequired();
            builder.Property(x => x.BrandId).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.PhotoPath).IsRequired();
        }
    }
}
