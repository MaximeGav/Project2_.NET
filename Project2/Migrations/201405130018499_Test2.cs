namespace Project2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test2 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.BPCoordinator", "username", c => c.String(unicode: false));
            //AddColumn("dbo.Promotor", "username", c => c.String(unicode: false));
            //AddColumn("dbo.Student", "username", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "username");
            DropColumn("dbo.Promotor", "username");
            DropColumn("dbo.BPCoordinator", "username");
        }
    }
}
