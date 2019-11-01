namespace UNS.Models.Migrations
{
    using System.Data.Entity.Migrations;
    using UNS.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<UNSModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            CommandTimeout = 100000000;
        }

        protected override void Seed(UNSModel context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
