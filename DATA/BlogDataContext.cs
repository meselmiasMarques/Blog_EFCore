using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog_EFCore.DATA.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Blog.DATA
{
    public class BlogDataContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }


        //Conexão 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;Database=BlogFluentMapMigration;User ID=sa;Password=Mm@rques0701!;TrustServerCertificate=True");
            //options.LogTo(Console.WriteLine);
        }

        //define o mapeamento
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new PostMap());
        }
    }
}