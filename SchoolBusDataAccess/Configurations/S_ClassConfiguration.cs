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
    public class S_ClassConfiguration : IEntityTypeConfiguration<S_Class>
    {
        public void Configure(EntityTypeBuilder<S_Class> builder)
        {
            builder.Property(x => x.Name).HasColumnType("nvarchar(50)");
        }
    }
}
