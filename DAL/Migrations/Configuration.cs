namespace DAL.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.ApplicationDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.ApplicationDBContext context)
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

            ApplicationUserManager userManager = new ApplicationUserManager(context);

            ApplicationUserIDentity admin = new ApplicationUserIDentity()
            {
                Id = Guid.NewGuid().ToString(),
                Email = "test@gmail.com",
                UserName = "Admin",
                PasswordHash = "Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = true,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                Address = "Admin",
            };

            admin.PasswordHash = userManager.PasswordHasher.HashPassword(admin.PasswordHash);

            userManager.Create(admin);

            ApplicationRoleManager roleManager = new ApplicationRoleManager(context);
            IdentityRole roleAdmin = new IdentityRole()
            {
                Name = "Admin"
            };

            roleManager.Create(roleAdmin);

            userManager.AddToRole(admin.Id, "Admin");
        }
    }
}
