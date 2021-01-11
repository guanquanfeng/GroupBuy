namespace GroupBuy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryNproduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CateId = c.Int(nullable: false, identity: true),
                        CateName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CateId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Totle = c.Int(nullable: false),
                        Remaining = c.Int(nullable: false),
                        InStock = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                        CateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CateId, cascadeDelete: true)
                .Index(t => t.CateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CateId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CateId" });
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
