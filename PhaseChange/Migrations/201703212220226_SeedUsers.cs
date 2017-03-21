namespace PhaseChange.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3ae0d695-61c1-49fc-b34c-6a80088dcbc5', N'guest@phasechange.com', 0, N'ACZi78pvKTsXzTD0f5bTtnrKYg4xT6W42HGRXaJP5bo15ITR6l6xrRPdFKpRADCpvQ==', N'7c5a1dd9-9d30-4715-a4ed-309623f6418a', NULL, 0, 0, NULL, 1, 0, N'guest@phasechange.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'475f2c34-c0f9-474b-8a9e-639abadbee87', N'admin@phasechange.com', 0, N'AH3BdC2R7Ihxt0d9wfHZXW7VzD2YThFwzqv09Mc08+7mZxUJBM77wkIBllb35dqp5g==', N'e24965a7-ea6f-45be-9a5f-fdd337d57383', NULL, 0, 0, NULL, 1, 0, N'admin@phasechange.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9741da31-1a8f-4796-9ab5-a7c46c8ef425', N'CanManageGame')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'475f2c34-c0f9-474b-8a9e-639abadbee87', N'9741da31-1a8f-4796-9ab5-a7c46c8ef425')


");
        }
        
        public override void Down()
        {
        }
    }
}
