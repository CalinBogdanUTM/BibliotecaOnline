namespace MyLibrary.BusinessLogic.Migrations.SessionContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class SessionConfiguration : DbMigrationsConfiguration<MyLibrary.BusinessLogic.DBModel.SessionContext>
    {
        public SessionConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\SessionContext";
        }

        protected override void Seed(MyLibrary.BusinessLogic.DBModel.SessionContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
