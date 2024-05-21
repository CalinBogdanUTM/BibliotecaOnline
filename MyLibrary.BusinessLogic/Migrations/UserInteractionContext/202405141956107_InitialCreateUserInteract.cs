namespace MyLibrary.BusinessLogic.Migrations.UserInteractionContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreateUserInteract : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInteractions",
                c => new
                    {
                        InteractionId = c.Int(nullable: false, identity: true),
                        UserUsername = c.String(),
                        BookId = c.Int(nullable: false),
                        Action = c.Int(nullable: false),
                        InteractionTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InteractionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserInteractions");
        }
    }
}
