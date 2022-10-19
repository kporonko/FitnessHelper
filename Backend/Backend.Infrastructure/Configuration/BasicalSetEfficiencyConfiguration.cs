using Backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{
    public class BasicalSetEfficiencyConfiguration : IEntityTypeConfiguration<BasicalSetEfficiency>
    {
        public void Configure(EntityTypeBuilder<BasicalSetEfficiency> builder)
        {
            builder
                .ToTable("BasicalSetEfficiency")
                .HasKey(x => x.EfficiencyId);
            builder
                .Property(x => x.EfficiencyId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("EfficiencyId")
                .HasColumnType("int");
            builder
                .Property(x => x.Cardio)
                .HasColumnName("Cardio")
                .HasColumnType("int")
                .IsRequired();
            builder
                .Property(x => x.Legs)
                .HasColumnName("Legs")
                .HasColumnType("int")
                .IsRequired();
            builder
                .Property(x => x.Arms)
                .HasColumnName("Arms")
                .HasColumnType("int")
                .IsRequired();
            builder
                .Property(x => x.Back)
                .HasColumnName("Back")
                .HasColumnType("int")
                .IsRequired();
            builder
                .Property(x => x.Chest)
                .HasColumnName("Chest")
                .HasColumnType("int")
                .IsRequired();
            builder
                .Property(x => x.Abs)
                .HasColumnName("Abs")
                .HasColumnType("int")
                .IsRequired();
            builder
                .Property(x => x.Cardio)
                .HasColumnName("Cardio")
                .HasColumnType("int")
                .IsRequired();

        }

    }
}
