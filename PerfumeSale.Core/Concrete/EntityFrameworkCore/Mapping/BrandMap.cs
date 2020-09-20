using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.Core.Concrete.EntityFrameworkCore.Mapping
{
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("PS_Brand");
            builder.HasKey(x => x.BrandId);
            builder.Property(x => x.BrandId).UseIdentityColumn();

            builder.Property(x => x.BrandName).IsRequired();
            builder.Property(x => x.Description).IsRequired();

            builder.HasMany(x => x.Perfumes).WithOne(x => x.Brand).HasForeignKey(x => x.BrandId);

        }
    }
}
