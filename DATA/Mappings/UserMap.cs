using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog_EFCore.DATA.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Tabela
            builder.ToTable("User");
            //Identity
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); //PK IDENTITY(1,1);

            //PROPRIEDADES
            builder.Property(x => x.Name)
                .IsRequired() //not null
                .HasColumnName("Name")//noma da coluna
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Email);
            builder.Property(x => x.PasswordHash);
            builder.Property(x => x.Bio);
            builder.Property(x => x.Image);

            builder.Property(x => x.Slug)
                           .IsRequired() //not null
                           .HasColumnName("Slug")//noma da coluna
                           .HasColumnType("NVARCHAR")
                           .HasMaxLength(80);

            //Indices
            builder.HasIndex(x => x.Slug, "IX_User_Slug")
                .IsUnique();

            //Relacionamento
            builder.HasMany(x => x.Roles)
           .WithMany(x => x.Users)
           //objeto virtual (string e um objeto)
           .UsingEntity<Dictionary<string, object>>(
               "UserRole",
               user => user.HasOne<Role>()
                   .WithMany()
                   .HasForeignKey("UserId")
                   .HasConstraintName("FK_UserRole_UserId")
                   .OnDelete(DeleteBehavior.Cascade),
               role => role.HasOne<User>()
                   .WithMany()
                   .HasForeignKey("RoleId")
                   .HasConstraintName("FK_UserRole_RoleId")
                   .OnDelete(DeleteBehavior.Cascade));

        }
    }
}