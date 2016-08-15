namespace cbbmsR3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class image_imageDescription_Change_To_ImageName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "ImageName", c => c.String());
            DropColumn("dbo.Images", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "Description", c => c.String());
            DropColumn("dbo.Images", "ImageName");
        }
    }
}
