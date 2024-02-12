using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolBusDomainLayer.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusDataAccess.Configurations
{
    public class ParentConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.Property(x => x.UserName).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.Password).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(x => x.Firstname).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Lastname).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Phone).HasColumnType("nvarchar(50)");
        }
    }
}
