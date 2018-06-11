namespace AdidasNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        Title = c.String(),
                        Duration = c.String(),
                        Disconnection = c.String(),
                        Address = c.String(),
                        Tell = c.String(),
                        Person_FK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblPerson", t => t.Person_FK, cascadeDelete: true)
                .Index(t => t.Person_FK);
            
            CreateTable(
                "dbo.tblPerson",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Firstname = c.String(nullable: false, maxLength: 20),
                        Father = c.String(nullable: false, maxLength: 20),
                        BirthDay = c.DateTime(nullable: false),
                        MilitaryService = c.Byte(),
                        Marriage = c.Boolean(nullable: false),
                        Children = c.Byte(),
                        NationalCode = c.String(nullable: false, maxLength: 10),
                        Address = c.String(nullable: false, maxLength: 200),
                        Tell = c.String(nullable: false, maxLength: 15),
                        Mobile = c.String(nullable: false, maxLength: 12),
                        Email = c.String(),
                        Degree = c.Byte(),
                        Institute = c.String(nullable: false),
                        Field = c.String(nullable: false),
                        EnglishKnowledge = c.Byte(),
                        Excel = c.Boolean(nullable: false),
                        Word = c.Boolean(nullable: false),
                        Outlook = c.Boolean(nullable: false),
                        PowerPoint = c.Boolean(nullable: false),
                        Accounting = c.Boolean(nullable: false),
                        OtherSoftwer = c.String(),
                        Skills = c.String(),
                        SalaryExpection = c.String(nullable: false, maxLength: 10),
                        JobStatus = c.Boolean(nullable: false),
                        DaysNumber = c.Byte(),
                        WorkingGuranty = c.Boolean(nullable: false),
                        Duration = c.Byte(),
                        GurantyPayment = c.Boolean(nullable: false),
                        Gender = c.Boolean(nullable: false),
                        image = c.Binary(),
                        RegPerson = c.DateTime(),
                        Checked = c.Boolean(nullable: false),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RelationShips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Relational = c.String(),
                        Tell = c.String(),
                        Address = c.String(),
                        Moaref = c.Boolean(nullable: false),
                        Person_FK = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblPerson", t => t.Person_FK, cascadeDelete: true)
                .Index(t => t.Person_FK);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Role = c.String(),
                        Enabled = c.Boolean(nullable: false),
                        Expired = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RelationShips", "Person_FK", "dbo.tblPerson");
            DropForeignKey("dbo.JobRecords", "Person_FK", "dbo.tblPerson");
            DropIndex("dbo.RelationShips", new[] { "Person_FK" });
            DropIndex("dbo.JobRecords", new[] { "Person_FK" });
            DropTable("dbo.Users");
            DropTable("dbo.RelationShips");
            DropTable("dbo.tblPerson");
            DropTable("dbo.JobRecords");
        }
    }
}
