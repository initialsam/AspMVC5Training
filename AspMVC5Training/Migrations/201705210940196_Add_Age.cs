namespace AspMVC5Training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Age : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Age");
        }
    }
}
