namespace ImsForPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class t1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcceptedRouteForRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.String(maxLength: 128),
                        RoutePrivilegeId = c.Int(nullable: false),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.PrivilegedRoutes", t => t.RoutePrivilegeId, cascadeDelete: true)
                .Index(t => t.CreatedBy)
                .Index(t => t.RoleId)
                .Index(t => t.RoutePrivilegeId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PrivilegedRoutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RouteName = c.String(nullable: false, maxLength: 500),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.AdminOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FromHouseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ToHouseId = c.Int(),
                        AdminOrderStatusId = c.Int(nullable: false),
                        ReceivedById = c.String(maxLength: 128),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AdminOrderStatus", t => t.AdminOrderStatusId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.Houses", t => t.FromHouseId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ReceivedById)
                .ForeignKey("dbo.Houses", t => t.ToHouseId)
                .Index(t => t.AdminOrderStatusId)
                .Index(t => t.CreatedBy)
                .Index(t => t.FromHouseId)
                .Index(t => t.ProductId)
                .Index(t => t.ReceivedById)
                .Index(t => t.ToHouseId);
            
            CreateTable(
                "dbo.AdminOrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusValue = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Houses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseTypeId = c.Int(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        WebSiteUrl = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.HouseTypes", t => t.HouseTypeId, cascadeDelete: true)
                .Index(t => t.CreatedBy)
                .Index(t => t.HouseTypeId);
            
            CreateTable(
                "dbo.HouseTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        House = c.String(),
                        Logo = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        ProductModel = c.String(),
                        CategoryId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        SiUnitId = c.Int(nullable: false),
                        FeaturePaletteId = c.Int(nullable: false),
                        Stock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.FeaturePalettes", t => t.FeaturePaletteId, cascadeDelete: true)
                .ForeignKey("dbo.SiUnits", t => t.SiUnitId, cascadeDelete: true)
                .Index(t => t.CreatedBy)
                .Index(t => t.BrandId)
                .Index(t => t.CategoryId)
                .Index(t => t.FeaturePaletteId)
                .Index(t => t.SiUnitId);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BrandName = c.String(),
                        BrandLogo = c.String(),
                        BrandWebSiteUrl = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryLogo = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.FeaturePalettes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeatureName = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.SiUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitName = c.String(),
                        Sign = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.DifferentProducers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProducerType = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeaturePalette = c.Int(nullable: false),
                        ProductFeatureName = c.String(),
                        ProductFeature = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.HouseProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        ProductBatchId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ShelfId = c.Int(nullable: false),
                        ShelfRow = c.String(),
                        ShelfCol = c.String(),
                        ProductStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.HouseUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Houses", t => t.HouseId, cascadeDelete: true)
                .Index(t => t.CreatedBy)
                .Index(t => t.UserId)
                .Index(t => t.HouseId);
            
            CreateTable(
                "dbo.MessageBoxes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseId = c.Int(nullable: false),
                        RoleId = c.String(maxLength: 128),
                        MessageStatusId = c.Int(nullable: false),
                        ReceivedBy = c.String(maxLength: 128),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.Houses", t => t.HouseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.ReceivedBy)
                .ForeignKey("dbo.MessageStatus", t => t.MessageStatusId, cascadeDelete: true)
                .Index(t => t.CreatedBy)
                .Index(t => t.HouseId)
                .Index(t => t.RoleId)
                .Index(t => t.ReceivedBy)
                .Index(t => t.MessageStatusId);
            
            CreateTable(
                "dbo.MessageStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusValue = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.Producers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DifferentProducerId = c.Int(nullable: false),
                        Name = c.String(),
                        Website = c.String(),
                        Contact = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.DifferentProducers", t => t.DifferentProducerId, cascadeDelete: true)
                .Index(t => t.CreatedBy)
                .Index(t => t.DifferentProducerId);
            
            CreateTable(
                "dbo.ProductBatches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchInfo = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.ProductListInOrderScripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.ProductOrders", t => t.ProductOrderId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.ProductOrderId);
            
            CreateTable(
                "dbo.ProductOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductOrderStatusId = c.Int(nullable: false),
                        ProducerId = c.Int(nullable: false),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.Producers", t => t.ProducerId, cascadeDelete: true)
                .ForeignKey("dbo.ProductOrderStatus", t => t.ProductOrderStatusId, cascadeDelete: true)
                .Index(t => t.CreatedBy)
                .Index(t => t.ProducerId)
                .Index(t => t.ProductOrderStatusId);
            
            CreateTable(
                "dbo.ProductOrderStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StatusValue = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.ProductSinglePartNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Batch = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.HouseProducts", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.CreatedBy)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Shelves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShelfName = c.String(),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        WebSiteUrl = c.String(maxLength: 100),
                        ImageUrl = c.String(maxLength: 100),
                        Description = c.String(),
                        ActiveStatus = c.Boolean(nullable: false),
                        CreatedBy = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .Index(t => t.CreatedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfiles", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Shelves", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductSinglePartNumbers", "ProductId", "dbo.HouseProducts");
            DropForeignKey("dbo.ProductSinglePartNumbers", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductListInOrderScripts", "ProductOrderId", "dbo.ProductOrders");
            DropForeignKey("dbo.ProductOrders", "ProductOrderStatusId", "dbo.ProductOrderStatus");
            DropForeignKey("dbo.ProductOrderStatus", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductOrders", "ProducerId", "dbo.Producers");
            DropForeignKey("dbo.ProductOrders", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductListInOrderScripts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductBatches", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Producers", "DifferentProducerId", "dbo.DifferentProducers");
            DropForeignKey("dbo.Producers", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageBoxes", "MessageStatusId", "dbo.MessageStatus");
            DropForeignKey("dbo.MessageStatus", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageBoxes", "ReceivedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.MessageBoxes", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.MessageBoxes", "HouseId", "dbo.Houses");
            DropForeignKey("dbo.MessageBoxes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.HouseUsers", "HouseId", "dbo.Houses");
            DropForeignKey("dbo.HouseUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.HouseUsers", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.HouseProducts", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Features", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.DifferentProducers", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdminOrders", "ToHouseId", "dbo.Houses");
            DropForeignKey("dbo.AdminOrders", "ReceivedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdminOrders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "SiUnitId", "dbo.SiUnits");
            DropForeignKey("dbo.SiUnits", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "FeaturePaletteId", "dbo.FeaturePalettes");
            DropForeignKey("dbo.FeaturePalettes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.Brands", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdminOrders", "FromHouseId", "dbo.Houses");
            DropForeignKey("dbo.Houses", "HouseTypeId", "dbo.HouseTypes");
            DropForeignKey("dbo.HouseTypes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Houses", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdminOrders", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AdminOrders", "AdminOrderStatusId", "dbo.AdminOrderStatus");
            DropForeignKey("dbo.AdminOrderStatus", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AcceptedRouteForRoles", "RoutePrivilegeId", "dbo.PrivilegedRoutes");
            DropForeignKey("dbo.PrivilegedRoutes", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AcceptedRouteForRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AcceptedRouteForRoles", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserProfiles", new[] { "CreatedBy" });
            DropIndex("dbo.Shelves", new[] { "CreatedBy" });
            DropIndex("dbo.ProductSinglePartNumbers", new[] { "ProductId" });
            DropIndex("dbo.ProductSinglePartNumbers", new[] { "CreatedBy" });
            DropIndex("dbo.ProductListInOrderScripts", new[] { "ProductOrderId" });
            DropIndex("dbo.ProductOrders", new[] { "ProductOrderStatusId" });
            DropIndex("dbo.ProductOrderStatus", new[] { "CreatedBy" });
            DropIndex("dbo.ProductOrders", new[] { "ProducerId" });
            DropIndex("dbo.ProductOrders", new[] { "CreatedBy" });
            DropIndex("dbo.ProductListInOrderScripts", new[] { "ProductId" });
            DropIndex("dbo.ProductBatches", new[] { "CreatedBy" });
            DropIndex("dbo.Producers", new[] { "DifferentProducerId" });
            DropIndex("dbo.Producers", new[] { "CreatedBy" });
            DropIndex("dbo.MessageBoxes", new[] { "MessageStatusId" });
            DropIndex("dbo.MessageStatus", new[] { "CreatedBy" });
            DropIndex("dbo.MessageBoxes", new[] { "ReceivedBy" });
            DropIndex("dbo.MessageBoxes", new[] { "RoleId" });
            DropIndex("dbo.MessageBoxes", new[] { "HouseId" });
            DropIndex("dbo.MessageBoxes", new[] { "CreatedBy" });
            DropIndex("dbo.HouseUsers", new[] { "HouseId" });
            DropIndex("dbo.HouseUsers", new[] { "UserId" });
            DropIndex("dbo.HouseUsers", new[] { "CreatedBy" });
            DropIndex("dbo.HouseProducts", new[] { "CreatedBy" });
            DropIndex("dbo.Features", new[] { "CreatedBy" });
            DropIndex("dbo.DifferentProducers", new[] { "CreatedBy" });
            DropIndex("dbo.AdminOrders", new[] { "ToHouseId" });
            DropIndex("dbo.AdminOrders", new[] { "ReceivedById" });
            DropIndex("dbo.AdminOrders", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "SiUnitId" });
            DropIndex("dbo.SiUnits", new[] { "CreatedBy" });
            DropIndex("dbo.Products", new[] { "FeaturePaletteId" });
            DropIndex("dbo.FeaturePalettes", new[] { "CreatedBy" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Categories", new[] { "CreatedBy" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Brands", new[] { "CreatedBy" });
            DropIndex("dbo.Products", new[] { "CreatedBy" });
            DropIndex("dbo.AdminOrders", new[] { "FromHouseId" });
            DropIndex("dbo.Houses", new[] { "HouseTypeId" });
            DropIndex("dbo.HouseTypes", new[] { "CreatedBy" });
            DropIndex("dbo.Houses", new[] { "CreatedBy" });
            DropIndex("dbo.AdminOrders", new[] { "CreatedBy" });
            DropIndex("dbo.AdminOrders", new[] { "AdminOrderStatusId" });
            DropIndex("dbo.AdminOrderStatus", new[] { "CreatedBy" });
            DropIndex("dbo.AcceptedRouteForRoles", new[] { "RoutePrivilegeId" });
            DropIndex("dbo.PrivilegedRoutes", new[] { "CreatedBy" });
            DropIndex("dbo.AcceptedRouteForRoles", new[] { "RoleId" });
            DropIndex("dbo.AcceptedRouteForRoles", new[] { "CreatedBy" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Shelves");
            DropTable("dbo.ProductSinglePartNumbers");
            DropTable("dbo.ProductOrderStatus");
            DropTable("dbo.ProductOrders");
            DropTable("dbo.ProductListInOrderScripts");
            DropTable("dbo.ProductBatches");
            DropTable("dbo.Producers");
            DropTable("dbo.MessageStatus");
            DropTable("dbo.MessageBoxes");
            DropTable("dbo.HouseUsers");
            DropTable("dbo.HouseProducts");
            DropTable("dbo.Features");
            DropTable("dbo.DifferentProducers");
            DropTable("dbo.SiUnits");
            DropTable("dbo.FeaturePalettes");
            DropTable("dbo.Categories");
            DropTable("dbo.Brands");
            DropTable("dbo.Products");
            DropTable("dbo.HouseTypes");
            DropTable("dbo.Houses");
            DropTable("dbo.AdminOrderStatus");
            DropTable("dbo.AdminOrders");
            DropTable("dbo.PrivilegedRoutes");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AcceptedRouteForRoles");
        }
    }
}
