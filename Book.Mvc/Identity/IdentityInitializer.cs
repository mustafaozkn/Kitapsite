using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Book.Mvc.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //roles

            if (!context.Roles.Any(i=>i.Name=="admin"))
            {
                var store = new RoleStore<BooksRole>(context);

                var manager =new RoleManager<BooksRole>(store);

                var role = new BooksRole() {Name="admin",Description="yönetici rolü" };

                manager.Create(role);
            }


            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<BooksRole>(context);

                var manager = new RoleManager<BooksRole>(store);

                var role = new BooksRole() { Name = "user", Description = "kullanıcı rolü" }; ;

                manager.Create(role);
            }


            if (!context.Roles.Any(i => i.Name == "yazar"))
            {
                var store = new RoleStore<BooksRole>(context);

                var manager = new RoleManager<BooksRole>(store);

                var role = new BooksRole() { Name = "yazar", Description = "Özel yorum yazar rolü" }; ;

                manager.Create(role);
            }

            if (!context.Users.Any(i => i.UserName == "mustafaozkan"))
            {
                var store = new UserStore<BooksUser>(context);

                var manager = new UserManager<BooksUser>(store);

                var user = new BooksUser() {Name="Mustafa",SurName="Özkan",UserName="mustafaozkan",Email="mustafa.ozkn@outlook.com" };

               
                manager.Create(user,"qwerty123");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(i => i.UserName == "kullanicimustafa"))
            {
                var store = new UserStore<BooksUser>(context);

                var manager = new UserManager<BooksUser>(store);

                var user = new BooksUser() { Name = "KullanıcıMustafa", SurName = "Özkan", UserName = "kullanicimustafa", Email = "usermustafa.ozkn@outlook.com" };


                manager.Create(user, "qwerty123");
               
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(i => i.UserName == "yazarmustafa"))
            {
                var store = new UserStore<BooksUser>(context);

                var manager = new UserManager<BooksUser>(store);

                var user = new BooksUser() { Name = "YazarMustafa", SurName = "Özkan", UserName = "yazarmustafa", Email = "yazarmustafa.ozkn@outlook.com" };


                manager.Create(user, "qwerty123");

                manager.AddToRole(user.Id, "yazar");
            }


 
            base.Seed(context);
        }

        
    }
}