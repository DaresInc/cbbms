namespace cbbmsR3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class File_Changes_AppFile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ItemCategories", "FileId", "dbo.Files");
            DropIndex("dbo.ItemCategories", new[] { "FileId" });
            CreateTable(
                "dbo.AppFiles",
                c => new
                    {
                        AppFileId = c.Int(nullable: false, identity: true),
                        FilePath = c.String(),
                        ContentType = c.String(),
                        FileName = c.String(),
                        Caption = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppFileId);
            
            AddColumn("dbo.ItemCategories", "AppFileId", c => c.Int());
            CreateIndex("dbo.ItemCategories", "AppFileId");
            AddForeignKey("dbo.ItemCategories", "AppFileId", "dbo.AppFiles", "AppFileId");
            DropColumn("dbo.ItemCategories", "FileId");
            DropTable("dbo.Files");
        }
        
        public override void Down()
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
            DropForeignKey("dbo.ItemCategories", "AppFileId", "dbo.AppFiles");
            DropIndex("dbo.ItemCategories", new[] { "AppFileId" });
            DropColumn("dbo.ItemCategories", "AppFileId");
            DropTable("dbo.AppFiles");
            CreateIndex("dbo.ItemCategories", "FileId");
            AddForeignKey("dbo.ItemCategories", "FileId", "dbo.Files", "FileId");
        }
    }
}
