namespace Dog_Seller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Animals", newName: "Dogs");
            DropColumn("dbo.Dogs", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dogs", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            RenameTable(name: "dbo.Dogs", newName: "Animals");
        }
    }
}
