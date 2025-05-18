using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SklepHkr2025.Data.Entity.Incom;
using SklepHkr2025.Data.Entity.Shop;

namespace SklepHkr2025.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<GrupyIncom> GrupyIncom { get; set; }
        public DbSet<ShopCategory> ShopCategories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "Admin", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "User", Name = "User", NormalizedName = "USER" },
                new IdentityRole { Id = "Manager", Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Id = "Client", Name = "Client", NormalizedName = "CLIENT" }
            );
        }
    }
}
