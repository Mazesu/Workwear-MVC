using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Workwear.Models;

namespace Workwear.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Company> Companies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Штаны" },
                new Category { Id = 2, Name = "Обувь" },
                new Category { Id = 3, Name = "Комбинезон" }
                );
            modelBuilder.Entity<Company>().HasData(
               new Company
               {
                   Id = 4,
                   FullName = "ООО Компания",
                   ShortName = "Компания",
                   INN = "323123",
                   KPP = "666666",
                   OGRN = "4325432",
                   City = "Набережные Челны",
                   LegalAddress = "авыпывп",
                   ActualAddress = " ghfghgf",
                   PostalCode = "dsadas",
                   PhoneNumber = "898888"
               });
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "Штаны", Description = "sdadasd", Price = 500, CategoryId = 1, ImageUrl = "",
                },
                new Product
                {
                    Id = 2,
                    Title = "Обувь",
                    Description = "aaaaaaaaaa",
                    Price = 200,
                    Price20 = 180,
                    Price50 = 175,
                    Price100 = 150,
                    CategoryId = 2,
                    ImageUrl = "",    
                },
                new Product { Id = 3, Title = "Комбинезон", Description = "bbbbbb", Price = 350, CategoryId = 3, ImageUrl = ""});
            modelBuilder.Entity<ProductSize>().HasData(
                new ProductSize { Id = 1, SizeName = "S", Quantity = 10, ProductId = 1 },
                new ProductSize { Id = 2, SizeName = "M", Quantity = 15, ProductId = 1 },
                new ProductSize { Id = 3, SizeName = "39", Quantity = 5, ProductId = 2 },
                new ProductSize { Id = 4, SizeName = "40", Quantity = 8, ProductId = 2 },
                new ProductSize { Id = 5, SizeName = "L", Quantity = 12, ProductId = 3 },
                new ProductSize { Id = 6, SizeName = "XL", Quantity = 7, ProductId = 3 }
            );
        }
    }
}
