using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog_EFCore.DATA.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //Tabela
            builder.ToTable("Post");
            //Identity
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); //PK IDENTITY(1,1);

            //PROPRIEDADES
            builder.Property(x => x.Title)
                    .IsRequired() //not null
                    .HasColumnName("Tile")//noma da coluna
                    .HasColumnType("NVARCHAR")
                    .HasMaxLength(100);

            builder.Property(x => x.Summary);
            builder.Property(x => x.Body)
                .HasColumnType("TEXT");

            builder.Property(x => x.Slug)
                .IsRequired() //not null
                .HasColumnName("Slug")//noma da coluna
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.LastUpdateDate)
                .IsRequired()
                .HasColumnName("LastUpdateDate")
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValueSql("GETDATE()"); //data default do SQL

            //.HasDefaultValue(DateTime.Now.ToUniversalTime());//forma data do c#

            //Indices
            builder.HasIndex(x => x.Slug, "IX_Post_Slug")
                    .IsUnique();

            //Relacionamentos
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Posts)
                .HasConstraintName("FK_Post_Author");

            builder.HasOne(x => x.Category)
               .WithMany(x => x.Posts)
               .HasConstraintName("FK_Post_Category");

            //Muitos para Muitos  um post possui muitas tags, e uma tag pode ter muitos posts
            builder.HasMany(x => x.Tags)
                .WithMany(x => x.Posts)
                //objeto virtual (string e um objeto)
                .UsingEntity<Dictionary<string, object>>(
                    "PostTag",
                    post => post.HasOne<Tag>()
                        .WithMany()
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_PostTag_PostId")
                        .OnDelete(DeleteBehavior.Cascade),
                    tag => tag.HasOne<Post>()
                        .WithMany()
                        .HasForeignKey("TagId")
                        .HasConstraintName("FK_PostTag_TagId")
                        .OnDelete(DeleteBehavior.Cascade));
        }
    }
}