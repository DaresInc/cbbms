namespace cbbmsR3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changing_UserID_Type_Int_To_String : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AppFiles", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AppFiles", "UserId", c => c.Int(nullable: false));
        }
    }
}
