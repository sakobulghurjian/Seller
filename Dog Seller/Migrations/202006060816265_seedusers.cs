namespace Dog_Seller.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c7b99de5-917c-40e0-a93b-cd94010c1e7d', N'guest@gmail.com', 0, N'APveTVu7XXx3cM6hfYNwGv5QwJlnEmvpEGaBS/tyyKi1TN4LB7DYvXUemSiPEzElJQ==', N'339bb133-ad62-4fdd-9049-463145f4bfac', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dc0fe720-f9e4-464b-b1b2-3e2650610948', N'admin@gmail.com', 0, N'AKPyqryaDonqhzMakEwnhC/o+5CPz52UVAMotVUSBbzWmW+P390GHeBYv3+687zPeg==', N'bb8dd5ed-92c0-4451-b55a-8df061b611b0', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'62fbf58c-2c76-4945-9f97-a0c18a93127e', N'CanManage')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dc0fe720-f9e4-464b-b1b2-3e2650610948', N'62fbf58c-2c76-4945-9f97-a0c18a93127e')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
