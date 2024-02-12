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
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.Property(x => x.UserName).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Password).HasColumnType("nvarchar(50)");
            builder.Property(x => x.FirstName).HasColumnType("nvarchar(50)");
            builder.Property(x => x.LastName).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Phone).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Address).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Licence).HasColumnType("nvarchar(50)");
            
        }
    }
}
