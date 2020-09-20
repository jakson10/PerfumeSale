using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.Core.Concrete.EntityFrameworkCore.Mapping
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("PS_Order");
            builder.HasKey(x => x.OrderId);
            builder.Property(x => x.OrderId).UseIdentityColumn();

            builder.Property(x => x.ShipAddress).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.OrderDate).IsRequired();

            builder.HasOne(x => x.UserDetail).WithMany(x => x.Orders).HasForeignKey(x => x.UserDetailId);

            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Order).HasForeignKey(x => x.OrderId);
        }
    }
}
