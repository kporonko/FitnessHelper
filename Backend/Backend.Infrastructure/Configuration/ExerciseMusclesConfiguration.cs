using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{

    public class ExerciseMusclesConfiguration : IEntityTypeConfiguration<ExerciseMuscles>
    {
        public void Configure(EntityTypeBuilder<ExerciseMuscles> builder)
        {
            builder
                .ToTable("ExerciseMuscles")
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id")
                .HasColumnType("int");
            builder
                .Property(x => x.ExerciseId)
                .IsRequired()
                .HasColumnName("ExerciseId")
                .HasColumnType("int");
            builder
                .Property(x => x.MuscleId)
                .IsRequired()
                .HasColumnName("MuscleId")
                .HasColumnType("int");
            builder
                .Property(x => x.IsTarget)
                .IsRequired()
                .HasColumnName("IsTarget")
                .HasColumnType("bit");
        }
    }
}
