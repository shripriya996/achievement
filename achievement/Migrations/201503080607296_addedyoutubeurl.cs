namespace achievement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedyoutubeurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Achievement", "URL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Achievement", "URL");
        }
    }
}
