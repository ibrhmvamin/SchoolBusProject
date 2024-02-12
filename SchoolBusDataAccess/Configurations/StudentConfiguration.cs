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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(x => x.Firstname).HasColumnType("nvarchar(50)");
            builder.Property(x => x.Lastname).HasColumnType("nvarchar(50)");
            builder.Property(x => x.HomeAddress).HasColumnType("nvarchar(50)");
            builder.Property(x => x.OtherAddress).HasColumnType("nvarchar(50)");
        }
    }
}
