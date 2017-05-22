namespace AspMVC5Training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUserAddresses", newName: "AccountAddress");
            RenameTable(name: "dbo.AspNetRoles", newName: "Roles");
            RenameTable(name: "dbo.AspNetUserRoles", newName: "AccountRoles");
            RenameTable(name: "dbo.AspNetUsers", newName: "Account");
            RenameTable(name: "dbo.AspNetUserClaims", newName: "AccountClaims");
            RenameTable(name: "dbo.AspNetUserLogins", newName: "AccountLogins");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AccountLogins", newName: "AspNetUserLogins");
            RenameTable(name: "dbo.AccountClaims", newName: "AspNetUserClaims");
            RenameTable(name: "dbo.Account", newName: "AspNetUsers");
            RenameTable(name: "dbo.AccountRoles", newName: "AspNetUserRoles");
            RenameTable(name: "dbo.Roles", newName: "AspNetRoles");
            RenameTable(name: "dbo.AccountAddress", newName: "AspNetUserAddresses");
        }
    }
}
