using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{
    public class UserSetOfExercisesConfiguration : IEntityTypeConfiguration<UserSetOfExercises>
    {
        public void Configure(EntityTypeBuilder<UserSetOfExercises> builder)
        {
            builder
                .ToTable("UserSetOfExercises")
                .HasKey(x => x.UserSetId);
            builder
                .Property(x => x.UserSetId)
                .IsRequired()
                .HasColumnName("UserSetId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnName("ExerciseId")
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }
    }
}
