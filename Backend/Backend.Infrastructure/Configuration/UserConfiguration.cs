using Backend.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("User")
                .HasKey(x => x.UserId);
            builder
                .Property(x => x.UserId)
                .IsRequired()
                .HasColumnName("UserId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();
            builder
                .Property(x => x.Login)
                .IsRequired()
                .HasColumnName("Login")
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder
                .Property(x => x.Password)
                .IsRequired()
                .HasColumnName("Password")
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasColumnName("FirstName")
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder
                .Property(x => x.LastName)
                .IsRequired()
                .HasColumnName("LastName")
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder
                .Property(x => x.Avatar)
                .IsRequired()
                .HasColumnName("Avatar")
                .HasColumnType("varbinary(max)");
        }
    }
}
