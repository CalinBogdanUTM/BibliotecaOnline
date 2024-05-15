namespace MyLibrary.BusinessLogic.Migrations.BookContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookInfoes",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        PublishingDate = c.DateTime(nullable: false),
                        Language = c.String(),
                        Category = c.String(),
                        SourceUrl = c.String(),
                    })
                .PrimaryKey(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookInfoes");
        }
    }
}
