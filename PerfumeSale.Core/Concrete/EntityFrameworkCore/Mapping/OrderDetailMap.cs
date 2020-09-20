using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.Core.Concrete.EntityFrameworkCore.Mapping
{
    public class OrderDetailMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("PS_OrderDetail");
            builder.HasKey(x => x.OrderDetailId);
            builder.Property(x => x.OrderDetailId).UseIdentityColumn();

            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Count).IsRequired();

            builder.HasOne(x => x.Perfume).WithMany(x => x.OrderDetails).HasForeignKey(x => x.PerfumeId);

        }
    }
}
