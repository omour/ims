using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ImsForPresentation.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<PrivilegedRoute> PrivilegedRoutes { get; set; }
        public DbSet<AcceptedRouteForRole> AcceptedRouteForRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<SiUnit> SiUnits { get; set; }
        public DbSet<FeaturePalette> FeaturePalettes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<HouseType> HouseTypes { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<HouseUser> HouseUsers { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<ProductBatch> ProductBatches { get; set; }
        public DbSet<HouseProduct> HouseProducts { get; set; }
        public DbSet<ProductSinglePartNumber> ProductSinglePartNumbers { get; set; }
        public DbSet<MessageStatus> MessageStatuses { get; set; }
        public DbSet<MessageBox> MessageBoxs { get; set; }
        public DbSet<AdminOrderStatus> AdminOrderStatuses { get; set; }
        public DbSet<AdminOrder> AdminOrders { get; set; }
        public DbSet<DifferentProducer> DifferentProducers { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ProductOrderStatus> ProductOrderStatuses { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<ProductListInOrderScript> ProductListInOrderScripts { get; set; }

      //  public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }

        //public System.Data.Entity.DbSet<ImsForPresentation.Models.ApplicationUser> IdentityUsers { get; set; }
    }
}