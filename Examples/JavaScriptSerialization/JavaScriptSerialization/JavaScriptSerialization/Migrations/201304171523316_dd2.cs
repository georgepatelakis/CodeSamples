namespace JavaScriptSerialization.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Dogs", "AnimalID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dogs", "AnimalID", c => c.Int(nullable: false));
        }
    }
}
