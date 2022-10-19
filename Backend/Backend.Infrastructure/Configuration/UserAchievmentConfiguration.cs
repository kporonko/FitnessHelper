using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{
    public class UserAchievmentConfiguration : IEntityTypeConfiguration<UserAchievment>
    {
        public void Configure(EntityTypeBuilder<UserAchievment> builder)
        {
            builder
                .ToTable("UserAchievment")
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("int");
            builder
                .Property(x => x.AchievmentId)
                .IsRequired()
                .HasColumnName("AchievmentId")
                .HasColumnType("int");
            builder
                .Property(x => x.IsDone)
                .IsRequired()
                .HasColumnName("IsDone")
                .HasColumnType("bit");
        }
    }
}
