namespace achievement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class misc : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Achievement", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Achievement", "Acheivement", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Achievement", "Acheivement", c => c.String());
            AlterColumn("dbo.Achievement", "Name", c => c.String());
        }
    }
}
