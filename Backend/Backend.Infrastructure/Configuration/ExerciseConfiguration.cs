using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder
                .ToTable("Exercise")
                .HasKey(x => x.ExerciseId);
            builder
                .Property(x => x.ExerciseId)
                .IsRequired()
                .HasColumnName("ExerciseId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("varchar")
                .HasMaxLength(500);
            builder
                .Property(x => x.UrlImage)
                .IsRequired()
                .HasColumnName("UrlImage")
                .HasColumnType("varchar")
                .HasMaxLength(200);
            builder
                .Property(x => x.UrlVideo)
                .IsRequired()
                .HasColumnName("UrlVideo")
                .HasColumnType("varchar")
                .HasMaxLength(200);
        }
    }
}
