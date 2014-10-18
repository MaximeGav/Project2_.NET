namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class feedback : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Feedback", "ScoreTitel", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Feedback", "ScoreContext", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Feedback", "ScoreSmart", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Feedback", "ScoreOnderzoeksvraag", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Feedback", "ScoreBijdrage", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Feedback", "ScoreOnderwerp", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Feedback", "ScoreReferentielijst", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feedback", "ScoreReferentielijst", c => c.Int(nullable: false));
            AlterColumn("dbo.Feedback", "ScoreOnderwerp", c => c.Int(nullable: false));
            AlterColumn("dbo.Feedback", "ScoreBijdrage", c => c.Int(nullable: false));
            AlterColumn("dbo.Feedback", "ScoreOnderzoeksvraag", c => c.Int(nullable: false));
            AlterColumn("dbo.Feedback", "ScoreSmart", c => c.Int(nullable: false));
            AlterColumn("dbo.Feedback", "ScoreContext", c => c.Int(nullable: false));
            AlterColumn("dbo.Feedback", "ScoreTitel", c => c.Int(nullable: false));
        }
    }
}
