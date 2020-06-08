namespace Dog_Seller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editthings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dogs", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dogs", "Image");
        }
    }
}
