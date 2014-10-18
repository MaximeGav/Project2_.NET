namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1805 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Voorstel", "ReferentieLijst", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Voorstel", "Onderzoeksvraag", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voorstel", "Onderzoeksvraag", c => c.String(unicode: false));
            DropColumn("dbo.Voorstel", "ReferentieLijst");
        }
    }
}
