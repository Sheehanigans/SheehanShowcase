namespace DvdService.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DvdService.Data.Entities.DvdLibraryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DvdService.Data.Entities.DvdLibraryEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Dvds.AddOrUpdate(
                d => d.DvdId,
                new Models.Dvd { DvdId = 1, Title = "Herbie Fully Loaded", Director = "Lindsay Lohan", ReleaseYear = 2006, Rating = "PG", Notes = "Confused teenager rides in living car"},
                new Models.Dvd { DvdId = 2, Title = "The Room", Director = "Tommy Wiseau", ReleaseYear = 2000, Rating = "R", Notes = "Prequil to the Disaster Artist"}
                );

            context.SaveChanges();
        }
    }
}
