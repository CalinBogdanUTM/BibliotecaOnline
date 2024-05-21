namespace MyLibrary.BusinessLogic.Migrations.BookContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class BookConfiguration : DbMigrationsConfiguration<MyLibrary.BusinessLogic.DBModel.BookContext>
    {
        public BookConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\BookContext";
        }

        protected override void Seed(MyLibrary.BusinessLogic.DBModel.BookContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
