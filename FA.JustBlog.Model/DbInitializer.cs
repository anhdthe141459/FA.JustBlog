
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FA.JustBlog.Model
{
     class DbInitializer : CreateDatabaseIfNotExists<AppDbContext>
    {
        public void SeedData(AppDbContext context)
        {
            base.Seed(context);
            var storeRole = new RoleStore<IdentityRole>(context);
            var managerRole = new RoleManager<IdentityRole>(storeRole);
            var roleAdmin = new IdentityRole { Name = "Admin" };
            var roleUser = new IdentityRole { Name = "User" };

            managerRole.Create(roleAdmin);
            managerRole.Create(roleUser);
            context.SaveChanges();
            var user = new User
            {
                UserName = "admin2@gmail.com",
                Email = "admin2@gmail.com",
                PasswordHash = "AAIKir9RO0n4AbQ6yYOiXlbpeXuTg7i2Kf14P1YnRAXopgWQyyt/0hG5/Yiu3vw7CQ==",
                //password:123456asdA@

            };


            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            manager.Create(user);
            manager.AddToRole(user.Id, "Admin");


            Category category1 = new Category();
            category1.Name = "Entity FrameWork";

            Category category2 = new Category();
            category2.Name = "MVC";

            context.Categories.Add(category1);
            context.Categories.Add(category2);


            Post post1 = new Post();
            post1.Title = "The first Post";
            post1.SeoUrl = "The-first-Post";
            post1.Rate = 4.5;
            post1.CreatedOn = DateTime.Now;
            post1.Views = 1000;
            post1.CateId = 1;
            post1.Content = "ASP.NET is a free web framework for building websites and web applications on .NET Framework using HTML, CSS, and JavaScript.ASP.NET MVC 5 is a web framework based on Model-View - Controller(MVC) architecture.Developers can build dynamic web applications using ASP.NET MVC framework that enables a clean separation of concerns, fast development, and TDD friendly.";
            Post post2 = new Post();
            post2.Title = "The second Post";
            post2.SeoUrl = "The-second-Post";
            post2.CreatedOn = DateTime.Now;
            post2.Rate = 3.5;
            post2.Views = 2000;
            post2.Content = "ASP.NET is a free web framework for building websites and web applications on .NET Framework using HTML, CSS, and JavaScript.ASP.NET MVC 5 is a web framework based on Model-View - Controller(MVC) architecture.Developers can build dynamic web applications using ASP.NET MVC framework that enables a clean separation of concerns, fast development, and TDD friendly.";
            post2.CateId = 2;
            context.Posts.Add(post1);
            context.Posts.Add(post2);

            context.SaveChanges();
        }
    }
}
