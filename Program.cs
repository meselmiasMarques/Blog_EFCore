using Blog.DATA;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var db = new BlogDataContext();

            // var user = new User
            // {
            //     Name = "Meselmias",
            //     Email = "meselmias@testes.com",
            //     Slug = "meselmias",
            //     Bio = "xpo",
            //     Image = "https://balta.io",
            //     PasswordHash = "123456"
            // };

            // var category = new Category
            // {
            //     Name = "Backend",
            //     Slug = "backend"
            // };
            // var post = new Post
            // {
            //     Author = user,
            //     Category = category,
            //     Body = "<p>Hello World</p>",
            //     Slug = "comecando-com-ef-core",
            //     Summary = "Neste Artigo vamos aprender EF core",
            //     Title = "Nova Carreira",
            //     CreateDate = DateTime.Now,
            //     LastUpdateDate = DateTime.Now
            // };

            // db.Posts.Add(post);
            // db.SaveChanges();

            // var posts = db
            //     .Posts
            //     .AsNoTracking()
            //     .Include(x => x.Author)
            //     .Include(x => x.Category)
            //     .OrderBy(x => x.LastUpdateDate)
            //     .ToList();

            // foreach (var post in posts)
            //     System.Console.WriteLine($"{post.Title} escrito por {post.Author?.Name} em {post.Category?.Name}");

            // var post = db
            //    .Posts
            //    .Include(x => x.Author)
            //    .Include(x => x.Category)
            //    .OrderByDescending(x => x.LastUpdateDate)
            //    .FirstOrDefault();//pega o primeiro da lista;

            // post.Author.Name = "teste";
            // db.Posts.Update(post);
            // db.SaveChanges();


        }
    }
}

