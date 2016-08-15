namespace cbbmsR3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Images_Changes_To_Files : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FilePath = c.String(),
                        ContentType = c.String(),
                        FileName = c.String(),
                        Caption = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId);
            
            AddColumn("dbo.ItemCategories", "FileId", c => c.Int());
            CreateIndex("dbo.ItemCategories", "FileId");
            AddForeignKey("dbo.ItemCategories", "FileId", "dbo.Files", "FileId");
            DropColumn("dbo.ItemCategories", "Picture");
            DropTable("dbo.Images");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        ImageId = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        ContentType = c.String(),
                        ImageName = c.String(),
                        Caption = c.String(),
                    })
                .PrimaryKey(t => t.ImageId);
            
            AddColumn("dbo.ItemCategories", "Picture", c => c.Binary());
            DropForeignKey("dbo.ItemCategories", "FileId", "dbo.Files");
            DropIndex("dbo.ItemCategories", new[] { "FileId" });
            DropColumn("dbo.ItemCategories", "FileId");
            DropTable("dbo.Files");
        }
    }
}
