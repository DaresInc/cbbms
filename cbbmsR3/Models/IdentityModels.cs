using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using cbbmsRnD.Models.InvMgt;
using cbbmsRnD.Models.SysMgt;
using cbbmsRnD.Models.UsrMgt;
using cbbmsRnD.Models.ProjMgt;
using cbbmsRnD.Models.CnfMgt;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace cbbmsR3.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
        public System.Data.Entity.DbSet<Item> Items { get; set; }

        public System.Data.Entity.DbSet<ItemCategory> ItemCategories { get; set; }

        public System.Data.Entity.DbSet<Status> Status { get; set; }

        public System.Data.Entity.DbSet<UoM> UoMs { get; set; }

        public System.Data.Entity.DbSet<Inventory> Inventories { get; set; }

        public System.Data.Entity.DbSet<AppUser> AppUsers { get; set; }

        public System.Data.Entity.DbSet<Location> Locations { get; set; }

        public System.Data.Entity.DbSet<InventoryItem> InventoryItems { get; set; }

        public System.Data.Entity.DbSet<Project> Projects { get; set; }

        public System.Data.Entity.DbSet<StockIssueVoucher> StockIssueVouchers { get; set; }

        public System.Data.Entity.DbSet<StockIssuedItem> StockIssuedItems { get; set; }

        public System.Data.Entity.DbSet<StockRecieveVoucher> StockRecieveVouchers { get; set; }

        public System.Data.Entity.DbSet<StockRecievedItem> StockRecievedItems { get; set; }

        public System.Data.Entity.DbSet<StockReturnVoucher> StockReturnVouchers { get; set; }

        public System.Data.Entity.DbSet<StockReturnedItem> StockReturnedItems { get; set; }

        public System.Data.Entity.DbSet<Product> Products { get; set; }

        public System.Data.Entity.DbSet<Module> Modules { get; set; }

        public System.Data.Entity.DbSet<Component> Components { get; set; }

        public System.Data.Entity.DbSet<BuildHistory> BuildHistories { get; set; }

        public System.Data.Entity.DbSet<EngineeringChangeRequest> EngineeringChangeRequests { get; set; }

        public System.Data.Entity.DbSet<SwiftInventoryTransfer> SwiftInventoryTransfers { get; set; }

        public System.Data.Entity.DbSet<StockTransferVoucher> StockTransferVouchers { get; set; }

        public System.Data.Entity.DbSet<ToDo> ToDoes { get; set; }

        public System.Data.Entity.DbSet<cbbmsRnD.Models.SysMgt.AppFile> AppFiles { get; set; }

        public System.Data.Entity.DbSet<cbbmsRnD.Models.InvMgt.StockTransferedItem> StockTransferedItems { get; set; }

        public System.Data.Entity.DbSet<cbbmsR3.Models.LabMgt.BloodSample> BloodSamples { get; set; }

        public System.Data.Entity.DbSet<cbbmsR3.Models.LabMgt.BloodSampleTest> BloodSampleTests { get; set; }

        public System.Data.Entity.DbSet<cbbmsR3.Models.LabMgt.BloodTest> BloodTests { get; set; }

        public System.Data.Entity.DbSet<cbbmsR3.Models.LabMgt.BloodTestType> BloodTestTypes { get; set; }

        public System.Data.Entity.DbSet<cbbmsR3.Models.LabMgt.BloodTestDefaultValue> BloodTestDefaultValues { get; set; }

        public System.Data.Entity.DbSet<cbbmsR3.Models.LabMgt.BloodTestDetail> BloodTestDetails { get; set; }
    }
}