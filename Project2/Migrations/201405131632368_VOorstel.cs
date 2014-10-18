namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VOorstel : DbMigration
    {
        public override void Up()
        {
         //   RenameTable(name: "dbo.Student", newName: "Voorstel");
          //  DropForeignKey("dbo.Student", "Voorstel_id", "dbo.Voorstel");
            //DropIndex("dbo.Student", new[] { "Voorstel_id" });
            //AddColumn("dbo.Voorstel", "Voorstel_id", c => c.Int(nullable: false));
            //CreateIndex("dbo.Voorstel", "Voorstel_id");
            //AddForeignKey("dbo.Voorstel", "Voorstel_id", "dbo.Student", "id");
            //DropColumn("dbo.Student", "Voorstel_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "Voorstel_id", c => c.Int());
            DropForeignKey("dbo.Voorstel", "sVoorstel_id", "dbo.Student");
            DropIndex("dbo.Voorstel", new[] { "sVoorstel_id" });
            DropColumn("dbo.Voorstel", "sVoorstel_id");
            CreateIndex("dbo.Student", "Voorstel_id");
            AddForeignKey("dbo.Student", "Voorstel_id", "dbo.Voorstel", "id");
            RenameTable(name: "dbo.Voorstel", newName: "Student");
        }
    }
}
