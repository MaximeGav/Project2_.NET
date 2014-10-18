namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status : DbMigration
    {
        public override void Up()
        {
      //      AddColumn("dbo.Voorstel", "Status", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Voorstel", "Status");
        }
    }
}
