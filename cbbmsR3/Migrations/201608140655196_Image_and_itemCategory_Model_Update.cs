namespace cbbmsR3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image_and_itemCategory_Model_Update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ItemCategories", "ContentType", c => c.String());
            AddColumn("dbo.Images", "ContentType", c => c.String());
            AddColumn("dbo.Images", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "Description");
            DropColumn("dbo.Images", "ContentType");
            DropColumn("dbo.ItemCategories", "ContentType");
        }
    }
}
