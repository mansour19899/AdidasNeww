namespace AdidasNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HistoryOfPersons", "RegDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.HistoryOfPersons", "RegDate", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
