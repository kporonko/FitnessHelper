using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{
    public class BasicalSetExerciseConfiguration : IEntityTypeConfiguration<BasicalSetExercise>
    {
        public void Configure(EntityTypeBuilder<BasicalSetExercise> builder)
        {
            builder
                .ToTable("BasicalSetExercise")
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .HasColumnType("int")
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder
                .Property(x => x.ExerciseId)
                .HasColumnType("int")
                .HasColumnName("ExerciseId")
                .IsRequired();
            builder
                .Property(x => x.SetId)
                .HasColumnType("int")
                .HasColumnName("SetId")
                .IsRequired();
        }

    }
}
