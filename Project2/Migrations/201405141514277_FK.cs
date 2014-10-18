namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Voorstel", "Feedback1_Id", c => c.Int());
            CreateIndex("dbo.Voorstel", "Feedback1_Id");
            AddForeignKey("dbo.Voorstel", "Feedback1_Id", "dbo.Feedback", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voorstel", "Feedback1_Id", "dbo.Feedback");
            DropIndex("dbo.Voorstel", new[] { "Feedback1_Id" });
            DropColumn("dbo.Voorstel", "Feedback1_Id");
        }
    }
}
