using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PerfumeSale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PerfumeSale.Core.Concrete.EntityFrameworkCore.Mapping
{
    public class UserDetailMap : IEntityTypeConfiguration<UserDetail>
    {
        public void Configure(EntityTypeBuilder<UserDetail> builder)
        {
            builder.ToTable("PS_UserDetail");
            builder.HasKey(x => x.UserDetailId);
            builder.Property(x => x.UserDetailId).UseIdentityColumn();

            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Address).IsRequired();

            builder.HasData(new UserDetail
                   {
                       UserDetailId = 7,
                       UserName = "jakson10",
                       FirstName = "fatih",
                       LastName = "sozuer",
                       Email = "fatihsozuer0@gmail.com",
                       Phone = "5364595158",
                       Address = "Cubuklu mahallesi engurubagı caddesı no=60 daire=1"
                   });
        }
    }
}
