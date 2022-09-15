using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{

    public class UserSetTrainingConfiguration : IEntityTypeConfiguration<UserSetTraining>
    {
        public void Configure(EntityTypeBuilder<UserSetTraining> builder)
        {
            builder
                .ToTable("UserSetTraining")
                .HasKey(x => x.UserTrainingId);
            builder
                .Property(x => x.UserTrainingId)
                .IsRequired()
                .HasColumnName("UserTrainingId")
                .HasColumnType("int");
            builder
                .Property(x => x.Date)
                .IsRequired()
                .HasColumnName("Date")
                .HasColumnType("date");
            builder
                .Property(x => x.Time)
                .IsRequired()
                .HasColumnName("Time")
                .HasColumnType("int");
        }
    }
}
