namespace PrimusFlex.Data.Models
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

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
        
        public IDbSet<KitchenRecord> Kitchens { get; set; }

        public IDbSet<DayworkRecord> Dayworks { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<MorDItem> MorDItems { get; set; }

        public IDbSet<Site> Sites { get; set; }
    }
}
