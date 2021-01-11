namespace GroupBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ordercount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "OrderCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "OrderCount");
        }
    }
}
