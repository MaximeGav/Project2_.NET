namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test3 : DbMigration
    {
        public override void Up()
        {
            //RenameTable(name: "dbo.Voorstel", newName: "Student");
            //DropForeignKey("dbo.Voorstel", "sVoorstel_id", "dbo.Student");
            //DropIndex("dbo.Voorstel", new[] { "sVoorstel_id" });
            //AddColumn("dbo.Student", "Voorstel_id", c => c.Int());
            //CreateIndex("dbo.Student", "Voorstel_id");
            //AddForeignKey("dbo.Student", "Voorstel_id", "dbo.Voorstel", "id");
            //DropColumn("dbo.Voorstel", "sVoorstel_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Voorstel", "sVoorstel_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Student", "Voorstel_id", "dbo.Voorstel");
            DropIndex("dbo.Student", new[] { "Voorstel_id" });
            DropColumn("dbo.Student", "Voorstel_id");
            CreateIndex("dbo.Voorstel", "sVoorstel_id");
            AddForeignKey("dbo.Voorstel", "sVoorstel_id", "dbo.Student", "id");
            RenameTable(name: "dbo.Student", newName: "Voorstel");
        }
    }
}
