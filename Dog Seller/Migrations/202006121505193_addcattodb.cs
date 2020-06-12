namespace Dog_Seller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcattodb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Age = c.Int(nullable: false),
                        Image = c.String(),
                        Type = c.String(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cats");
        }
    }
}
