namespace GroupBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delordercount : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "OrderCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "OrderCount", c => c.Int(nullable: false));
        }
    }
}
