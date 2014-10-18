namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1405 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "Promotor_id", c => c.Int());
            CreateIndex("dbo.Student", "Promotor_id");
            AddForeignKey("dbo.Student", "Promotor_id", "dbo.Promotor", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "Promotor_id", "dbo.Promotor");
            DropIndex("dbo.Student", new[] { "Promotor_id" });
            DropColumn("dbo.Student", "Promotor_id");
        }
    }
}
