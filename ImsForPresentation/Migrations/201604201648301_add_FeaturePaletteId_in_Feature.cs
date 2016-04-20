namespace ImsForPresentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_FeaturePaletteId_in_Feature : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Features", "FeaturePaletteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Features", "FeaturePaletteId");
            AddForeignKey("dbo.Features", "FeaturePaletteId", "dbo.FeaturePalettes", "Id", cascadeDelete: true);
            DropColumn("dbo.Features", "FeaturePalette");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Features", "FeaturePalette", c => c.Int(nullable: false));
            DropForeignKey("dbo.Features", "FeaturePaletteId", "dbo.FeaturePalettes");
            DropIndex("dbo.Features", new[] { "FeaturePaletteId" });
            DropColumn("dbo.Features", "FeaturePaletteId");
        }
    }
}
