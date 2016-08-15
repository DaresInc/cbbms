namespace cbbmsR3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class labmanagement_model_Addition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BloodSamples",
                c => new
                    {
                        BloodSampleId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(),
                        InventoryItemId = c.Int(),
                        CreatedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BloodSampleId)
                .ForeignKey("dbo.InventoryItems", t => t.InventoryItemId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.InventoryItemId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.BloodSampleTests",
                c => new
                    {
                        BloodSampleTestId = c.Int(nullable: false, identity: true),
                        BloodTestId = c.Int(nullable: false),
                        BloodSampleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BloodSampleTestId)
                .ForeignKey("dbo.BloodSamples", t => t.BloodSampleId)
                .ForeignKey("dbo.BloodTests", t => t.BloodTestId)
                .Index(t => t.BloodTestId)
                .Index(t => t.BloodSampleId);
            
            CreateTable(
                "dbo.BloodTests",
                c => new
                    {
                        BloodTestId = c.Int(nullable: false, identity: true),
                        BloodTestTypeId = c.Int(nullable: false),
                        BloodSampleId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Remarks = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BloodTestId)
                .ForeignKey("dbo.BloodSamples", t => t.BloodSampleId)
                .ForeignKey("dbo.BloodTestTypes", t => t.BloodTestTypeId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.BloodTestTypeId)
                .Index(t => t.BloodSampleId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.BloodTestDetails",
                c => new
                    {
                        BloodTestDetailId = c.Int(nullable: false, identity: true),
                        BloodTestId = c.Int(nullable: false),
                        Value = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.BloodTestDetailId)
                .ForeignKey("dbo.BloodTests", t => t.BloodTestId)
                .Index(t => t.BloodTestId);
            
            CreateTable(
                "dbo.BloodTestTypes",
                c => new
                    {
                        BloodTestTypeId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Abbreviation = c.String(),
                    })
                .PrimaryKey(t => t.BloodTestTypeId);
            
            CreateTable(
                "dbo.BloodTestDefaultValues",
                c => new
                    {
                        BloodTestDefaultValueId = c.Int(nullable: false, identity: true),
                        BloodTestTypeId = c.Int(nullable: false),
                        Attribute = c.String(),
                        DefaultValue = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BloodTestDefaultValueId)
                .ForeignKey("dbo.BloodTestTypes", t => t.BloodTestTypeId)
                .Index(t => t.BloodTestTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BloodSamples", "StatusId", "dbo.Status");
            DropForeignKey("dbo.BloodSamples", "InventoryItemId", "dbo.InventoryItems");
            DropForeignKey("dbo.BloodSampleTests", "BloodTestId", "dbo.BloodTests");
            DropForeignKey("dbo.BloodTests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.BloodTests", "BloodTestTypeId", "dbo.BloodTestTypes");
            DropForeignKey("dbo.BloodTestDefaultValues", "BloodTestTypeId", "dbo.BloodTestTypes");
            DropForeignKey("dbo.BloodTestDetails", "BloodTestId", "dbo.BloodTests");
            DropForeignKey("dbo.BloodTests", "BloodSampleId", "dbo.BloodSamples");
            DropForeignKey("dbo.BloodSampleTests", "BloodSampleId", "dbo.BloodSamples");
            DropIndex("dbo.BloodTestDefaultValues", new[] { "BloodTestTypeId" });
            DropIndex("dbo.BloodTestDetails", new[] { "BloodTestId" });
            DropIndex("dbo.BloodTests", new[] { "StatusId" });
            DropIndex("dbo.BloodTests", new[] { "BloodSampleId" });
            DropIndex("dbo.BloodTests", new[] { "BloodTestTypeId" });
            DropIndex("dbo.BloodSampleTests", new[] { "BloodSampleId" });
            DropIndex("dbo.BloodSampleTests", new[] { "BloodTestId" });
            DropIndex("dbo.BloodSamples", new[] { "StatusId" });
            DropIndex("dbo.BloodSamples", new[] { "InventoryItemId" });
            DropTable("dbo.BloodTestDefaultValues");
            DropTable("dbo.BloodTestTypes");
            DropTable("dbo.BloodTestDetails");
            DropTable("dbo.BloodTests");
            DropTable("dbo.BloodSampleTests");
            DropTable("dbo.BloodSamples");
        }
    }
}
