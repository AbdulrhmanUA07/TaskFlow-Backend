using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.Property(t => t.Title)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(t => t.Description)
                   .HasMaxLength(1000);

            builder.Property(t => t.UserId)
                   .IsRequired();

            builder.HasOne(t => t.Category)
                   .WithMany(c => c.Tasks)
                   .HasForeignKey(t => t.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(t => t.UserId);

            builder.HasIndex(t => t.CategoryId);

            builder.HasIndex(t => t.DueDate);
        }

    }
}