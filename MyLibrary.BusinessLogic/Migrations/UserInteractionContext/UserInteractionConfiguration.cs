namespace MyLibrary.BusinessLogic.Migrations.UserInteractionContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class UserInteractionConfiguration : DbMigrationsConfiguration<MyLibrary.BusinessLogic.DBModel.UserInteractionContext>
    {
        public UserInteractionConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations/UserInteractionContext";
        }

        protected override void Seed(MyLibrary.BusinessLogic.DBModel.UserInteractionContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
