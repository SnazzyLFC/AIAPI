namespace Repository.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Repo;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.Repo.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            SeedRoles(context);
            SeedUsers(context);
            SeedOrder(context);
            SeedProduct(context);
        }
        
        private void SeedOrder(Context context)
        {
            var order1 = new Order()
            {
                OrderId = 1,
                TotalPrice = 9
            };

            var order2 = new Order()
            {
                OrderId = 2,
                TotalPrice = 9
            };
            
            context.Set<Order>().AddOrUpdate(order1);
            context.Set<Order>().AddOrUpdate(order2);
            context.SaveChanges();
        }



        private void SeedProduct(Context context)
        {
            for (int i = 1; i <= 18; i++)
            {
                var product = new Product()
                {
                    ProductId = i,
                    Name = $"Product {i}",
                    Description = $"Brand new product! Number {i}",
                    Price = 1,
                    OrderId = (i.ToString().Length == 1 ? 1 : 2)
                };

                context.Set<Product>().AddOrUpdate(product);
            }
            
            context.SaveChanges();
        }

        private void SeedRoles(Context context)
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>());
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
        }

        private void SeedUsers(Context context)
        {
            var store = new UserStore<User>(context);
            var manager = new UserManager<User>(store);
            if (!context.Users.Any(u => u.UserName == "Admin"))
            {
                var user = new User { UserName = "Admin" };
                var adminresult = manager.Create(user, "zaq12wsx");
                if (adminresult.Succeeded)
                    manager.AddToRole(user.Id, "Admin");
            }
        }


    }
}
