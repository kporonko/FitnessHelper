using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{
    public class UserMusclesConfiguration : IEntityTypeConfiguration<UserMuscles>
    {
        public void Configure(EntityTypeBuilder<UserMuscles> builder)
        {
            builder
                .ToTable("UserMuscles")
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("Id")
                .HasColumnType("int");
            builder
                .Property(x => x.MusclePoints)
                .IsRequired()
                .HasColumnName("MusclePoints")
                .HasColumnType("float");
            builder
                .Property(x => x.MuscleId)
                .IsRequired()
                .HasColumnName("MuscleId")
                .HasColumnType("int");
            builder
                .Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("int");
        }
    }
}
