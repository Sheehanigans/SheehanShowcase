namespace CarDealership.UI.Migrations
{
    using CarDealership.UI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership.UI.Models.CarDealershipDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealership.UI.Models.CarDealershipDbContext context)
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

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Create Admin Role
            string adminRole = "Admin";
            IdentityResult roleResult;
            // Check to see if Role Exists, if not create it
            if (!roleManager.RoleExists(adminRole))
            {
                roleResult = roleManager.Create(new IdentityRole(adminRole));
            }
            string salesRole = "Sales";
            IdentityResult identityResult;
            if (!roleManager.RoleExists(salesRole))
            {
                identityResult = roleManager.Create(new IdentityRole(salesRole));
            }
            string disabledRole = "Disabled";
            IdentityResult identity;
            if (!roleManager.RoleExists(disabledRole))
            {
                identity = roleManager.Create(new IdentityRole(disabledRole));
            }


            if(!context.Users.Any(a => a.UserName == "test@test.com"))
            {
                var adminUser = new ApplicationUser()
                {
                    UserName = "test@test.com",
                    Email = "test@test.com",
                    FirstName = "Ryan",
                    LastName = "Sheehan",
                };
                userManager.Create(adminUser, "test123");

                userManager.AddToRole(adminUser.Id, "Admin");
            }
        }
    }
}
