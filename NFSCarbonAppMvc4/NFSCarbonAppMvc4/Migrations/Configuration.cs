using System;
using System.Web.Security;
using NFSCarbonAppMvc4.Models;
using WebMatrix.WebData;

namespace NFSCarbonAppMvc4.Migrations
{

    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<NFSCarbonAppMvc4.Models.NFSCarbondb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NFSCarbonAppMvc4.Models.NFSCarbondb context)
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

            context.Cars.AddOrUpdate(c => c.Name,
                new Car { Type = "Exotic", CarInfo = "Great!", Vendor = "Porshe", Name = "Cayman 911", Price = 750000, Country = "Germany" },
                new Car { Type = "Tuning", CarInfo = "Great!", Vendor = "Mitsubishi", Name = "Lancer", Price = 330000, Country = "Japan" },
                new Car { Type = "Muscule", CarInfo = "Great!", Vendor = "Dodge", Name = "Chalenger", Price = 750000, Country = "USA" });

            context.Images.AddOrUpdate(i => i.ImagePath,
                new Image { CarId = 1, ImagePath = "porshe1.jpg" },
                new Image { CarId = 2, ImagePath = "Lancer1.jpg" },
                new Image { CarId = 2, ImagePath = "Lancer2.jpg" },
                new Image { CarId = 3, ImagePath = "Dodge1.jpg" }
                );
            context.Reviews.AddOrUpdate( r => r.Id,
                new CarReview{Body = "Like it!", CarId = 2, Rating = 10, ReveiwerName = "Sergii"});

            SeedMembership();


        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection",
                "UserProfile", "UserId", "UserName", autoCreateTables: true);

            var roles = (SimpleRoleProvider) Roles.Provider;
            var membership = (SimpleMembershipProvider) Membership.Provider;

            if (!roles.RoleExists("admin"))
            {
                roles.CreateRole("admin");
            }

            if (membership.GetUser("cero",false)==null)
            {
                membership.CreateUserAndAccount("cero", "qwerty");
            }



            if (!roles.IsUserInRole("cero", "admin"))
            {
                roles.AddUsersToRoles(new[] { "cero" }, new[] { "admin" });
            }

        }

    }
}
