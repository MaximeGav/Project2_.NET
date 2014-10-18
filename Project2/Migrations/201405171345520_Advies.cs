namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Advies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Advies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vraag = c.String(nullable: false, unicode: false),
                        Antwoord = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Feedback", "Suggesties", c => c.String(unicode: false));
            AddColumn("dbo.Feedback", "IsDefinitief", c => c.Boolean());
            AddColumn("dbo.Voorstel", "Advies_Id", c => c.Int());
            AlterColumn("dbo.Voorstel", "IsDefinitief", c => c.Boolean());
            CreateIndex("dbo.Voorstel", "Advies_Id");
            AddForeignKey("dbo.Voorstel", "Advies_Id", "dbo.Advies", "Id");
            //DropColumn("dbo.Voorstel", "Feedback");
            //DropColumn("dbo.Voorstel", "Antwoord");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Voorstel", "Antwoord", c => c.String(unicode: false));
            AddColumn("dbo.Voorstel", "Feedback", c => c.String(unicode: false));
            DropForeignKey("dbo.Voorstel", "Advies_Id", "dbo.Advies");
            DropIndex("dbo.Voorstel", new[] { "Advies_Id" });
            AlterColumn("dbo.Voorstel", "IsDefinitief", c => c.Boolean(nullable: false));
            DropColumn("dbo.Voorstel", "Advies_Id");
            DropColumn("dbo.Feedback", "IsDefinitief");
            DropColumn("dbo.Feedback", "Suggesties");
            DropTable("dbo.Advies");
        }
    }
}
