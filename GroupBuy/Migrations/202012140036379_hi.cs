namespace GroupBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "UserName");
        }
    }
}
