namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.Feedback",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            ScoreTitel = c.Int(nullable: false),
            //            ScoreContext = c.Int(nullable: false),
            //            ScoreSmart = c.Int(nullable: false),
            //            ScoreOnderzoeksvraag = c.Int(nullable: false),
            //            ScoreBijdrage = c.Int(nullable: false),
            //            ScoreOnderwerp = c.Int(nullable: false),
            //            ScoreReferentielijst = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.Id);

            AddColumn("dbo.Voorstel", "Feedback1_Id", c => c.Int());
            CreateIndex("dbo.Voorstel", "Feedback1_Id");
            AddForeignKey("dbo.Voorstel", "Feedback1_Id", "dbo.Feedback", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voorstel", "Feedback1_Id", "dbo.Feedback");
            DropIndex("dbo.Voorstel", new[] { "Feedback1_Id" });
            DropColumn("dbo.Voorstel", "Feedback1_Id");
            DropTable("dbo.Feedback");
        }
    }
}
