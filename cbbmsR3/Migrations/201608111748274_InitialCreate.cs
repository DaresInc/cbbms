namespace cbbmsR3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        AppUserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        SecurityStamp = c.String(),
                        SecurityQuestion = c.String(),
                        SecurityQuestionAnswer = c.String(),
                        PrimaryEmail = c.String(),
                        StatusId = c.Int(nullable: false),
                        CreateOn = c.DateTime(nullable: false),
                        Notifications = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppUserID)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        InventoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        LocationId = c.Int(nullable: false),
                        AppUserID = c.Int(nullable: false),
                        StandbyCustodian = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.InventoryId)
                .ForeignKey("dbo.AppUsers", t => t.AppUserID)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .Index(t => t.LocationId)
                .Index(t => t.AppUserID);
            
            CreateTable(
                "dbo.InventoryItems",
                c => new
                    {
                        InventoryItemId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        QtyRecieved = c.Decimal(precision: 18, scale: 2),
                        QtyIssued = c.Decimal(precision: 18, scale: 2),
                        ReferenceDocument = c.String(),
                        ReferenceDocumentType = c.String(),
                        InventoryId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Remarks = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryItemId)
                .ForeignKey("dbo.Inventories", t => t.InventoryId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.ItemId)
                .Index(t => t.InventoryId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        UoMId = c.Int(nullable: false),
                        ItemCategoryId = c.Int(nullable: false),
                        Picture = c.Binary(),
                        UnitPrice = c.Decimal(precision: 18, scale: 2),
                        StatusID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.ItemCategories", t => t.ItemCategoryId)
                .ForeignKey("dbo.Status", t => t.StatusID)
                .ForeignKey("dbo.UoMs", t => t.UoMId)
                .Index(t => t.UoMId)
                .Index(t => t.ItemCategoryId)
                .Index(t => t.StatusID);
            
            CreateTable(
                "dbo.ItemCategories",
                c => new
                    {
                        ItemCategoryId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Picture = c.Binary(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ItemCategoryId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.StatusID);
            
            CreateTable(
                "dbo.UoMs",
                c => new
                    {
                        UoMId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Abbriviation = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.UoMId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.LogIns",
                c => new
                    {
                        LogInId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Login = c.DateTime(nullable: false),
                        Logout = c.DateTime(nullable: false),
                        IPAddress = c.String(),
                        MACAddress = c.String(),
                        StatusId = c.Int(nullable: false),
                        Remarks = c.String(),
                        AppUser_AppUserID = c.Int(),
                    })
                .PrimaryKey(t => t.LogInId)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_AppUserID)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId)
                .Index(t => t.AppUser_AppUserID);
            
            CreateTable(
                "dbo.BuildHistories",
                c => new
                    {
                        BuildHistoryId = c.Int(nullable: false, identity: true),
                        ComponentId = c.Int(nullable: false),
                        Description = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BuildHistoryId)
                .ForeignKey("dbo.Components", t => t.ComponentId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.ComponentId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        ComponentId = c.Int(nullable: false, identity: true),
                        ModuleId = c.Int(nullable: false),
                        Description = c.String(),
                        Title = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        StatusId = c.Int(nullable: false),
                        Version = c.String(),
                        Build = c.String(),
                    })
                .PrimaryKey(t => t.ComponentId)
                .ForeignKey("dbo.Modules", t => t.ModuleId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.ModuleId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Modules",
                c => new
                    {
                        ModuleId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Description = c.String(),
                        Title = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        StatusId = c.Int(nullable: false),
                        Version = c.String(),
                        Build = c.String(),
                    })
                .PrimaryKey(t => t.ModuleId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.ProductId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Title = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        Remarks = c.String(),
                        StatusId = c.Int(nullable: false),
                        Version = c.String(),
                        Build = c.String(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Projects", t => t.ProjectId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.ProjectId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Motive = c.String(),
                        Satrt = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Owner = c.String(),
                        Sponsor = c.String(),
                        ProgramManager = c.Int(nullable: false),
                        AppUser_AppUserID = c.Int(),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_AppUserID)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId)
                .Index(t => t.AppUser_AppUserID);
            
            CreateTable(
                "dbo.EngineeringChangeRequests",
                c => new
                    {
                        EngineeringChangeRequestId = c.Int(nullable: false, identity: true),
                        ComponentId = c.Int(nullable: false),
                        Description = c.String(),
                        ChangeType = c.String(),
                        RequesteeId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Remarks = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EngineeringChangeRequestId)
                .ForeignKey("dbo.Components", t => t.ComponentId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.ComponentId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StockIssuedItems",
                c => new
                    {
                        StockIssuedItemId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Qty = c.Decimal(precision: 18, scale: 2),
                        StrockIssueVoucherId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Remarks = c.String(),
                        StockIssueVoucher_StockIssueVoucherId = c.Int(),
                    })
                .PrimaryKey(t => t.StockIssuedItemId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.StockIssueVouchers", t => t.StockIssueVoucher_StockIssueVoucherId)
                .Index(t => t.ItemId)
                .Index(t => t.StatusId)
                .Index(t => t.StockIssueVoucher_StockIssueVoucherId);
            
            CreateTable(
                "dbo.StockIssueVouchers",
                c => new
                    {
                        StockIssueVoucherId = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        StockIssuedFromInventoryId = c.Int(nullable: false),
                        StockIssuedToUserId = c.Int(nullable: false),
                        StockIssuedByUserId = c.Int(nullable: false),
                        Remarks = c.String(),
                        StatusId = c.Int(nullable: false),
                        AppUser_AppUserID = c.Int(),
                        Inventory_InventoryId = c.Int(),
                    })
                .PrimaryKey(t => t.StockIssueVoucherId)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_AppUserID)
                .ForeignKey("dbo.Inventories", t => t.Inventory_InventoryId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId)
                .Index(t => t.AppUser_AppUserID)
                .Index(t => t.Inventory_InventoryId);
            
            CreateTable(
                "dbo.StockRecievedItems",
                c => new
                    {
                        StockRecievedItemId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Qty = c.Decimal(precision: 18, scale: 2),
                        StrockRecieveVoucherId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Remarks = c.String(),
                        StockRecieveVoucher_StockRecieveVoucherId = c.Int(),
                    })
                .PrimaryKey(t => t.StockRecievedItemId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.StockRecieveVouchers", t => t.StockRecieveVoucher_StockRecieveVoucherId)
                .Index(t => t.ItemId)
                .Index(t => t.StatusId)
                .Index(t => t.StockRecieveVoucher_StockRecieveVoucherId);
            
            CreateTable(
                "dbo.StockRecieveVouchers",
                c => new
                    {
                        StockRecieveVoucherId = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        StockRecieveingInventoryId = c.Int(nullable: false),
                        StockRecievedFromUserId = c.Int(nullable: false),
                        StockRecievedByUserId = c.Int(nullable: false),
                        Remarks = c.String(),
                        StatusId = c.Int(nullable: false),
                        AppUser_AppUserID = c.Int(),
                    })
                .PrimaryKey(t => t.StockRecieveVoucherId)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_AppUserID)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId)
                .Index(t => t.AppUser_AppUserID);
            
            CreateTable(
                "dbo.StockReturnedItems",
                c => new
                    {
                        StockReturnedItemId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Qty = c.Decimal(precision: 18, scale: 2),
                        StockReturnVoucherId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.StockReturnedItemId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.StockReturnVouchers", t => t.StockReturnVoucherId)
                .Index(t => t.ItemId)
                .Index(t => t.StockReturnVoucherId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.StockReturnVouchers",
                c => new
                    {
                        StockReturnVoucherId = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        StockIssueVoucherId = c.Int(nullable: false),
                        StockReturnedByUserId = c.Int(nullable: false),
                        Remarks = c.String(),
                        StatusId = c.Int(nullable: false),
                        AppUser_AppUserID = c.Int(),
                        Inventory_InventoryId = c.Int(),
                    })
                .PrimaryKey(t => t.StockReturnVoucherId)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_AppUserID)
                .ForeignKey("dbo.Inventories", t => t.Inventory_InventoryId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.StockIssueVouchers", t => t.StockIssueVoucherId)
                .Index(t => t.StockIssueVoucherId)
                .Index(t => t.StatusId)
                .Index(t => t.AppUser_AppUserID)
                .Index(t => t.Inventory_InventoryId);
            
            CreateTable(
                "dbo.StockTransferVouchers",
                c => new
                    {
                        StockTransferVoucherId = c.Int(nullable: false, identity: true),
                        CreatedOn = c.DateTime(nullable: false),
                        StockTransferedFromInventoryId = c.Int(nullable: false),
                        StockTransferedToInventoryId = c.Int(nullable: false),
                        StockRecievedByUserId = c.Int(nullable: false),
                        StockTransferdByUserId = c.Int(nullable: false),
                        Remarks = c.String(),
                        StatusId = c.Int(nullable: false),
                        AppUser_AppUserID = c.Int(),
                        Inventory_InventoryId = c.Int(),
                    })
                .PrimaryKey(t => t.StockTransferVoucherId)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_AppUserID)
                .ForeignKey("dbo.Inventories", t => t.Inventory_InventoryId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .Index(t => t.StatusId)
                .Index(t => t.AppUser_AppUserID)
                .Index(t => t.Inventory_InventoryId);
            
            CreateTable(
                "dbo.StockTransferedItems",
                c => new
                    {
                        StockTransferedItemId = c.Int(nullable: false, identity: true),
                        ItemId = c.Int(nullable: false),
                        Qty = c.Decimal(precision: 18, scale: 2),
                        StrockTransferVoucherId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Remarks = c.String(),
                        StockTransferVoucher_StockTransferVoucherId = c.Int(),
                    })
                .PrimaryKey(t => t.StockTransferedItemId)
                .ForeignKey("dbo.Items", t => t.ItemId)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.StockTransferVouchers", t => t.StockTransferVoucher_StockTransferVoucherId)
                .Index(t => t.ItemId)
                .Index(t => t.StatusId)
                .Index(t => t.StockTransferVoucher_StockTransferVoucherId);
            
            CreateTable(
                "dbo.SwiftInventoryTransfers",
                c => new
                    {
                        SwiftInventoryTransferId = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        PIN = c.Int(nullable: false),
                        StockTransferVoucherId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        RecievingUserId = c.Int(nullable: false),
                        SendingUserId = c.Int(nullable: false),
                        ExpiredOn = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        AppUser_AppUserID = c.Int(),
                    })
                .PrimaryKey(t => t.SwiftInventoryTransferId)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_AppUserID)
                .ForeignKey("dbo.Status", t => t.StatusId)
                .ForeignKey("dbo.StockTransferVouchers", t => t.StockTransferVoucherId)
                .Index(t => t.StockTransferVoucherId)
                .Index(t => t.StatusId)
                .Index(t => t.AppUser_AppUserID);
            
            CreateTable(
                "dbo.ToDoes",
                c => new
                    {
                        ToDoId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        AssignToId = c.Int(nullable: false),
                        AssignedById = c.Int(nullable: false),
                        CompletedById = c.Int(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        Remarks = c.String(),
                        Parent_ToDoId = c.Int(),
                        AppUser_AppUserID = c.Int(),
                        ToDos_ToDoId = c.Int(),
                    })
                .PrimaryKey(t => t.ToDoId)
                .ForeignKey("dbo.AppUsers", t => t.AppUser_AppUserID)
                .ForeignKey("dbo.ToDoes", t => t.ToDos_ToDoId)
                .Index(t => t.AppUser_AppUserID)
                .Index(t => t.ToDos_ToDoId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ToDoes", "ToDos_ToDoId", "dbo.ToDoes");
            DropForeignKey("dbo.ToDoes", "AppUser_AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.SwiftInventoryTransfers", "StockTransferVoucherId", "dbo.StockTransferVouchers");
            DropForeignKey("dbo.SwiftInventoryTransfers", "StatusId", "dbo.Status");
            DropForeignKey("dbo.SwiftInventoryTransfers", "AppUser_AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.StockTransferedItems", "StockTransferVoucher_StockTransferVoucherId", "dbo.StockTransferVouchers");
            DropForeignKey("dbo.StockTransferedItems", "StatusId", "dbo.Status");
            DropForeignKey("dbo.StockTransferedItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.StockTransferVouchers", "StatusId", "dbo.Status");
            DropForeignKey("dbo.StockTransferVouchers", "Inventory_InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.StockTransferVouchers", "AppUser_AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.StockReturnedItems", "StockReturnVoucherId", "dbo.StockReturnVouchers");
            DropForeignKey("dbo.StockReturnVouchers", "StockIssueVoucherId", "dbo.StockIssueVouchers");
            DropForeignKey("dbo.StockReturnVouchers", "StatusId", "dbo.Status");
            DropForeignKey("dbo.StockReturnVouchers", "Inventory_InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.StockReturnVouchers", "AppUser_AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.StockReturnedItems", "StatusId", "dbo.Status");
            DropForeignKey("dbo.StockReturnedItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.StockRecievedItems", "StockRecieveVoucher_StockRecieveVoucherId", "dbo.StockRecieveVouchers");
            DropForeignKey("dbo.StockRecieveVouchers", "StatusId", "dbo.Status");
            DropForeignKey("dbo.StockRecieveVouchers", "AppUser_AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.StockRecievedItems", "StatusId", "dbo.Status");
            DropForeignKey("dbo.StockRecievedItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.StockIssuedItems", "StockIssueVoucher_StockIssueVoucherId", "dbo.StockIssueVouchers");
            DropForeignKey("dbo.StockIssueVouchers", "StatusId", "dbo.Status");
            DropForeignKey("dbo.StockIssueVouchers", "Inventory_InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.StockIssueVouchers", "AppUser_AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.StockIssuedItems", "StatusId", "dbo.Status");
            DropForeignKey("dbo.StockIssuedItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.EngineeringChangeRequests", "StatusId", "dbo.Status");
            DropForeignKey("dbo.EngineeringChangeRequests", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.BuildHistories", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Components", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Modules", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Products", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Products", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Projects", "AppUser_AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.Modules", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Components", "ModuleId", "dbo.Modules");
            DropForeignKey("dbo.BuildHistories", "ComponentId", "dbo.Components");
            DropForeignKey("dbo.AppUsers", "StatusId", "dbo.Status");
            DropForeignKey("dbo.LogIns", "StatusId", "dbo.Status");
            DropForeignKey("dbo.LogIns", "AppUser_AppUserID", "dbo.AppUsers");
            DropForeignKey("dbo.Inventories", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.InventoryItems", "StatusId", "dbo.Status");
            DropForeignKey("dbo.InventoryItems", "ItemId", "dbo.Items");
            DropForeignKey("dbo.Items", "UoMId", "dbo.UoMs");
            DropForeignKey("dbo.Items", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Items", "ItemCategoryId", "dbo.ItemCategories");
            DropForeignKey("dbo.InventoryItems", "InventoryId", "dbo.Inventories");
            DropForeignKey("dbo.Inventories", "AppUserID", "dbo.AppUsers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ToDoes", new[] { "ToDos_ToDoId" });
            DropIndex("dbo.ToDoes", new[] { "AppUser_AppUserID" });
            DropIndex("dbo.SwiftInventoryTransfers", new[] { "AppUser_AppUserID" });
            DropIndex("dbo.SwiftInventoryTransfers", new[] { "StatusId" });
            DropIndex("dbo.SwiftInventoryTransfers", new[] { "StockTransferVoucherId" });
            DropIndex("dbo.StockTransferedItems", new[] { "StockTransferVoucher_StockTransferVoucherId" });
            DropIndex("dbo.StockTransferedItems", new[] { "StatusId" });
            DropIndex("dbo.StockTransferedItems", new[] { "ItemId" });
            DropIndex("dbo.StockTransferVouchers", new[] { "Inventory_InventoryId" });
            DropIndex("dbo.StockTransferVouchers", new[] { "AppUser_AppUserID" });
            DropIndex("dbo.StockTransferVouchers", new[] { "StatusId" });
            DropIndex("dbo.StockReturnVouchers", new[] { "Inventory_InventoryId" });
            DropIndex("dbo.StockReturnVouchers", new[] { "AppUser_AppUserID" });
            DropIndex("dbo.StockReturnVouchers", new[] { "StatusId" });
            DropIndex("dbo.StockReturnVouchers", new[] { "StockIssueVoucherId" });
            DropIndex("dbo.StockReturnedItems", new[] { "StatusId" });
            DropIndex("dbo.StockReturnedItems", new[] { "StockReturnVoucherId" });
            DropIndex("dbo.StockReturnedItems", new[] { "ItemId" });
            DropIndex("dbo.StockRecieveVouchers", new[] { "AppUser_AppUserID" });
            DropIndex("dbo.StockRecieveVouchers", new[] { "StatusId" });
            DropIndex("dbo.StockRecievedItems", new[] { "StockRecieveVoucher_StockRecieveVoucherId" });
            DropIndex("dbo.StockRecievedItems", new[] { "StatusId" });
            DropIndex("dbo.StockRecievedItems", new[] { "ItemId" });
            DropIndex("dbo.StockIssueVouchers", new[] { "Inventory_InventoryId" });
            DropIndex("dbo.StockIssueVouchers", new[] { "AppUser_AppUserID" });
            DropIndex("dbo.StockIssueVouchers", new[] { "StatusId" });
            DropIndex("dbo.StockIssuedItems", new[] { "StockIssueVoucher_StockIssueVoucherId" });
            DropIndex("dbo.StockIssuedItems", new[] { "StatusId" });
            DropIndex("dbo.StockIssuedItems", new[] { "ItemId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.EngineeringChangeRequests", new[] { "StatusId" });
            DropIndex("dbo.EngineeringChangeRequests", new[] { "ComponentId" });
            DropIndex("dbo.Projects", new[] { "AppUser_AppUserID" });
            DropIndex("dbo.Projects", new[] { "StatusId" });
            DropIndex("dbo.Products", new[] { "StatusId" });
            DropIndex("dbo.Products", new[] { "ProjectId" });
            DropIndex("dbo.Modules", new[] { "StatusId" });
            DropIndex("dbo.Modules", new[] { "ProductId" });
            DropIndex("dbo.Components", new[] { "StatusId" });
            DropIndex("dbo.Components", new[] { "ModuleId" });
            DropIndex("dbo.BuildHistories", new[] { "StatusId" });
            DropIndex("dbo.BuildHistories", new[] { "ComponentId" });
            DropIndex("dbo.LogIns", new[] { "AppUser_AppUserID" });
            DropIndex("dbo.LogIns", new[] { "StatusId" });
            DropIndex("dbo.Items", new[] { "StatusID" });
            DropIndex("dbo.Items", new[] { "ItemCategoryId" });
            DropIndex("dbo.Items", new[] { "UoMId" });
            DropIndex("dbo.InventoryItems", new[] { "StatusId" });
            DropIndex("dbo.InventoryItems", new[] { "InventoryId" });
            DropIndex("dbo.InventoryItems", new[] { "ItemId" });
            DropIndex("dbo.Inventories", new[] { "AppUserID" });
            DropIndex("dbo.Inventories", new[] { "LocationId" });
            DropIndex("dbo.AppUsers", new[] { "StatusId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ToDoes");
            DropTable("dbo.SwiftInventoryTransfers");
            DropTable("dbo.StockTransferedItems");
            DropTable("dbo.StockTransferVouchers");
            DropTable("dbo.StockReturnVouchers");
            DropTable("dbo.StockReturnedItems");
            DropTable("dbo.StockRecieveVouchers");
            DropTable("dbo.StockRecievedItems");
            DropTable("dbo.StockIssueVouchers");
            DropTable("dbo.StockIssuedItems");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.EngineeringChangeRequests");
            DropTable("dbo.Projects");
            DropTable("dbo.Products");
            DropTable("dbo.Modules");
            DropTable("dbo.Components");
            DropTable("dbo.BuildHistories");
            DropTable("dbo.LogIns");
            DropTable("dbo.Locations");
            DropTable("dbo.UoMs");
            DropTable("dbo.Status");
            DropTable("dbo.ItemCategories");
            DropTable("dbo.Items");
            DropTable("dbo.InventoryItems");
            DropTable("dbo.Inventories");
            DropTable("dbo.AppUsers");
        }
    }
}
