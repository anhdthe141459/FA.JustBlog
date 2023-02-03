using Autofac;
using Autofac.Integration.Mvc;
using FA.JustBlog.DataAccessLayer.Infrastructures;
using FA.JustBlog.DataAccessLayer.Repository;
using FA.JustBlog.Model;
using FA.JustBlog.Services.Categories;
using FA.JustBlog.Services.Posts;
using FA.JustBlog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FA.JustBlog.Core.App_Start
{
    public class AutofacConfig   
    {
        public static void RegisterComponents()
        {
            var builder = new ContainerBuilder();
            //register
            builder.RegisterControllers(typeof(MvcApplication).Assembly);


            builder.RegisterType<AppDbContext>().AsSelf().InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            // Scan an assembly for components
            builder.RegisterAssemblyTypes(typeof(PostRepository).Assembly)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(PostService).Assembly)
                 .Where(t => t.Name.EndsWith("Service"))
                 .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(typeof(CategoryRepository).Assembly)
       .Where(t => t.Name.EndsWith("Repository"))
       .AsImplementedInterfaces()
       .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CategoryService).Assembly)
                 .Where(t => t.Name.EndsWith("Service"))
                 .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
           // GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}