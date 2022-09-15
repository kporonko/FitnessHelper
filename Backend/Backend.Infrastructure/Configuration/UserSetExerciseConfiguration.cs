using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{
    public class UserSetExerciseConfiguration : IEntityTypeConfiguration<UserSetExercise>
    {
        public void Configure(EntityTypeBuilder<UserSetExercise> builder)
        {
            builder
                .ToTable("UserSetExercise")
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(x => x.ExerciseId)
                .IsRequired()
                .HasColumnName("ExerciseId")
                .HasColumnType("int");
            builder
                .Property(x => x.UserSetId)
                .IsRequired()
                .HasColumnName("UserSetId")
                .HasColumnType("int");
        }
    }
}
