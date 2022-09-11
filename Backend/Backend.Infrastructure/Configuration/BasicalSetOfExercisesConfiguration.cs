using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{
    public class BasicalSetOfExercisesConfiguration : IEntityTypeConfiguration<BasicalSetOfExercises>
    {
        public void Configure(EntityTypeBuilder<BasicalSetOfExercises> builder)
        {
            builder
                .ToTable("BasicalSetOfExercises")
                .HasKey(x => x.BasicalSetId);
            builder
                .Property(x => x.BasicalSetId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnType("int")
                .HasColumnName("BasicalSetId");
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnName("Name");
            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(500)
                .HasColumnName("Description");
        }
    }
}
