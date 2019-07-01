namespace UNSData.Migrations
{
    using System.Data.Entity.Migrations;
    using UNSData.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UNSModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

        }

        protected override void Seed(UNSModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
