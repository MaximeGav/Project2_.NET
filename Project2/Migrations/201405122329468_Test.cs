namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.OnderzoeksDomein", "Voorstel_id", "dbo.Voorstel");
            //DropIndex("dbo.OnderzoeksDomein", new[] { "Voorstel_id" });
            //AddColumn("dbo.Voorstel", "OnderzoeksDomein1_Id", c => c.Int(nullable: false));
            //AddColumn("dbo.Voorstel", "OnderzoeksDomein2_Id", c => c.Int());
            //AlterColumn("dbo.Student", "Voorstel_id", c => c.Int());
            //AlterColumn("dbo.Voorstel", "Onderzoeksvraag", c => c.String(unicode: false));
            //AlterColumn("dbo.OnderzoeksDomein", "Naam", c => c.String(nullable: false, unicode: false));
            //CreateIndex("dbo.Voorstel", "OnderzoeksDomein1_Id");
            //CreateIndex("dbo.Voorstel", "OnderzoeksDomein2_Id");
            //AddForeignKey("dbo.Voorstel", "OnderzoeksDomein1_Id", "dbo.OnderzoeksDomein", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.Voorstel", "OnderzoeksDomein2_Id", "dbo.OnderzoeksDomein", "Id");
           // DropColumn("dbo.OnderzoeksDomein", "Voorstel_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OnderzoeksDomein", "Voorstel_id", c => c.Int());
            DropForeignKey("dbo.Voorstel", "OnderzoeksDomein2_Id", "dbo.OnderzoeksDomein");
            DropForeignKey("dbo.Voorstel", "OnderzoeksDomein1_Id", "dbo.OnderzoeksDomein");
            DropIndex("dbo.Voorstel", new[] { "OnderzoeksDomein2_Id" });
            DropIndex("dbo.Voorstel", new[] { "OnderzoeksDomein1_Id" });
            AlterColumn("dbo.OnderzoeksDomein", "Naam", c => c.String(unicode: false));
            AlterColumn("dbo.Voorstel", "Onderzoeksvraag", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Student", "Voorstel_id", c => c.Int());
            DropColumn("dbo.Voorstel", "OnderzoeksDomein2_Id");
            DropColumn("dbo.Voorstel", "OnderzoeksDomein1_Id");
            CreateIndex("dbo.OnderzoeksDomein", "Voorstel_id");
            AddForeignKey("dbo.OnderzoeksDomein", "Voorstel_id", "dbo.Voorstel", "Id");
        }
    }
}
