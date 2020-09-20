using Microsoft.EntityFrameworkCore;
using PerfumeSale.Core.Concrete.EntityFrameworkCore.Mapping;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.Core.Concrete.EntityFrameworkCore.Context
{
    public class PsDatabaseContext : DbContext
    {
        public PsDatabaseContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BrandMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderDetailMap());
            modelBuilder.ApplyConfiguration(new PerfumeMap());
            modelBuilder.ApplyConfiguration(new UserDetailMap());

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Perfume> Perfumes { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
    }
}
