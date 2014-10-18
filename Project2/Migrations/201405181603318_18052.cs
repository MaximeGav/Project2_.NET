namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18052 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Voorstel", "Trefwoorden", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Voorstel", "Trefwoorden", c => c.String(nullable: false, unicode: false));
        }
    }
}
