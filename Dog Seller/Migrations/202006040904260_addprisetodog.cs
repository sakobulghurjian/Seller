namespace Dog_Seller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addprisetodog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dogs", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dogs", "Price");
        }
    }
}
