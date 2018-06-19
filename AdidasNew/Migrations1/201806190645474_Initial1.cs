namespace AdidasNew.Migrations1
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FullName", c => c.String());
            DropColumn("dbo.AspNetUsers", "namee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "namee", c => c.String());
            DropColumn("dbo.AspNetUsers", "FullName");
        }
    }
}
