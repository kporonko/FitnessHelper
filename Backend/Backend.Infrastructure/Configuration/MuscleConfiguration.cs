using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{
    public class MuscleConfiguration : IEntityTypeConfiguration<Muscle>
    {
        public void Configure(EntityTypeBuilder<Muscle> builder)
        {
            builder
                .ToTable("Muscle")
                .HasKey(x => x.MuscleId);
            builder
                .Property(x => x.MuscleId)
                .IsRequired()
                .HasColumnName("MuscleId")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar")
                .HasMaxLength(100);
            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("varchar")
                .HasMaxLength(2000);
            builder
                .Property(x => x.UrlImage)
                .IsRequired()
                .HasColumnName("UrlImage")
                .HasColumnType("varchar")
                .HasMaxLength(500);
            builder
                .Property(x => x.PartOfBody)
                .IsRequired()
                .HasColumnName("PartOfBody")
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }
    }
}