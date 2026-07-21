using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
       public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property( n => n.Name)
                .HasMaxLength(100)
                .IsRequired();

            // builder.HasMany(t => t.Tasks)
            //    .WithOne(t => t.Category)
            //    .HasForeignKey(t => t.CategoryId);
        }
    }
}
