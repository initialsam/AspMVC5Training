namespace AspMVC5Training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_GoogleAuthenticatorSecretKey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "IsGoogleAuthenticatorEnabled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Account", "GoogleAuthenticatorSecretKey", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Account", "GoogleAuthenticatorSecretKey");
            DropColumn("dbo.Account", "IsGoogleAuthenticatorEnabled");
        }
    }
}
