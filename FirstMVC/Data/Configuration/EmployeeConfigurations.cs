using FirstMVC.DAL.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVC.DAL.Data.Configuration
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {


        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(d => d.Id).UseIdentityColumn(10, 10).IsRequired();
            builder.Property(d => d.Name).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Address).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Salary).IsRequired().HasMaxLength(50);
        }
    }
}
