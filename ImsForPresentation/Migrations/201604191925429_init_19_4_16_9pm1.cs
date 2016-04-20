namespace ImsForPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_19_4_16_9pm1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AcceptedRouteForRoles", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.AcceptedRouteForRoles", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.PrivilegedRoutes", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.PrivilegedRoutes", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.AdminOrders", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.AdminOrders", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.AdminOrderStatus", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.AdminOrderStatus", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Houses", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Houses", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.HouseTypes", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.HouseTypes", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Products", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Products", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Brands", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Brands", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Categories", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Categories", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.FeaturePalettes", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.FeaturePalettes", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.SiUnits", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.SiUnits", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.DifferentProducers", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.DifferentProducers", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Features", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Features", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.HouseProducts", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.HouseProducts", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.HouseUsers", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.HouseUsers", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.MessageBoxes", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.MessageBoxes", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.MessageStatus", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.MessageStatus", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Producers", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Producers", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.ProductBatches", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.ProductBatches", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.ProductOrders", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.ProductOrders", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.ProductOrderStatus", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.ProductOrderStatus", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.ProductSinglePartNumbers", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.ProductSinglePartNumbers", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.Shelves", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.Shelves", "UpdatedAt", c => c.DateTime());
            AlterColumn("dbo.UserProfiles", "CreatedAt", c => c.DateTime());
            AlterColumn("dbo.UserProfiles", "UpdatedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfiles", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.UserProfiles", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Shelves", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Shelves", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductSinglePartNumbers", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductSinglePartNumbers", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductOrderStatus", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductOrderStatus", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductOrders", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductOrders", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductBatches", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProductBatches", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Producers", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Producers", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MessageStatus", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MessageStatus", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MessageBoxes", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.MessageBoxes", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HouseUsers", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HouseUsers", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HouseProducts", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HouseProducts", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Features", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Features", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DifferentProducers", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DifferentProducers", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SiUnits", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SiUnits", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FeaturePalettes", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.FeaturePalettes", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Categories", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Brands", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Brands", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HouseTypes", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.HouseTypes", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Houses", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Houses", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AdminOrderStatus", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AdminOrderStatus", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AdminOrders", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AdminOrders", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PrivilegedRoutes", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PrivilegedRoutes", "CreatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AcceptedRouteForRoles", "UpdatedAt", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AcceptedRouteForRoles", "CreatedAt", c => c.DateTime(nullable: false));
        }
    }
}
