using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SklepHkr2025.Data.Entity.Incom;
using SklepHkr2025.Data.Entity.Shop;
using System.Reflection.Emit;

namespace SklepHkr2025.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<GrupyIncom> GrupyIncom { get; set; }
        public DbSet<ShopCategory> ShopCategories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemImage> ItemImages { get; set; }
        public DbSet<PriceGroup> PriceGroups { get; set; }
        public DbSet<ProducentDetail> ProducentDetails { get; set; }
        public DbSet<ResponsiblePersonProducent> ResponsiblePersonProducent { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ProducentDetail>()
                           .HasOne(p => p.ResponsiblePerson)
    .WithOne(r => r.ProducentDetail)
    .HasForeignKey<ResponsiblePersonProducent>(r => r.ProducentDetailId)
    .IsRequired(false); // relacja opcjonalna

           

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "Admin", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "User", Name = "User", NormalizedName = "USER" },
                new IdentityRole { Id = "Manager", Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Id = "Client", Name = "Client", NormalizedName = "CLIENT" }
            );
            base.OnModelCreating(builder);
        }
    }
}
