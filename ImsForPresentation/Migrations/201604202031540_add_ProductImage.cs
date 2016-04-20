namespace ImsForPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_ProductImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ProductImage");
        }
    }
}
