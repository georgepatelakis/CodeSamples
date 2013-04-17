namespace JavaScriptSerialization.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dogs",
                c => new
                    {
                        DogID = c.Int(nullable: false, identity: true),
                        breed = c.Int(nullable: false),
                        AnimalID = c.Int(nullable: false),
                        age = c.Int(nullable: false),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.DogID);
            
            DropTable("dbo.Animals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        AnimalID = c.Int(nullable: false, identity: true),
                        age = c.Int(nullable: false),
                        name = c.String(),
                        DogID = c.Int(),
                        breed = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.AnimalID);
            
            DropTable("dbo.Dogs");
        }
    }
}
