using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{

    public class BasicalSetTrainingConfiguration : IEntityTypeConfiguration<BasicalSetTraining>
    {
        public void Configure(EntityTypeBuilder<BasicalSetTraining> builder)
        {
            builder
                .ToTable("BasicalSetTraining")
                .HasKey(x => x.BasicalTrainingId);
            builder
                .Property(x => x.BasicalTrainingId)
                .IsRequired()
                .HasColumnName("BasicalTrainingId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(x => x.Date)
                .IsRequired()
                .HasColumnName("Date")
                .HasColumnType("datetime");
            builder
                .Property(x => x.Time)
                .IsRequired()
                .HasColumnName("Time")
                .HasColumnType("int");
        }
    }
}
