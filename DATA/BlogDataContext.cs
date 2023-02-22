using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.DATA
{
    public class BlogDataContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        //public DbSet<PostTag> PostTags { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<User> UserRoles { get; set; }

        //Conexão 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;Database=dbOrder;User ID=sa;Password=Mm@rques0701!;TrustServerCertificate=True");
            //options.LogTo(Console.WriteLine);
        }

    }
}