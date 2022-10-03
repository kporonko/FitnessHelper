using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{
    public class AchievmentConfiguration : IEntityTypeConfiguration<Achievment>
    {
        public void Configure(EntityTypeBuilder<Achievment> builder)
        {
            builder
                .ToTable("Achievment")
                .HasKey(x => x.AchievmentId);
            builder
                .Property(x => x.AchievmentId)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("AchievmentId")
                .HasColumnType("int");
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("varchar(max)");
            builder
                .Property(x => x.Description)
                .IsRequired()
                .HasColumnName("Description")
                .HasColumnType("varchar(max)");
            builder
                .Property(x => x.UrlImage)
                .IsRequired()
                .HasColumnName("UrlImage")
                .HasColumnType("varchar(max)");
        }
    }
}
