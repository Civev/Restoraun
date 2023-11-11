using Mango.Servicies.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mango.Servicies.ProductAPI
{
    public class ApplicationDbContests : DbContext
    {
        public ApplicationDbContests(DbContextOptions<ApplicationDbContests> options) : base(options) {

        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Name = "Samosa",
                Price = 15,
                Description = "Ladno",
                ImageUrl = "https://www.gamberorossointernational.com/wp-content/uploads/2022/11/samosas.jpg",
                CategoryName = "Appetizer",

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Name = "Paneer Tikka",
                Price = 13.99,
                Description = "Ok",
                ImageUrl = "https://i.pinimg.com/originals/ba/e6/81/bae681e42f19849474d825e5a0ca6f3f.jpg",
                CategoryName = "Appetizer"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Name = "Sweet pie",
                Price = 10.99,
                Description = "Norm",
                ImageUrl = "https://i.pinimg.com/originals/70/cd/54/70cd5435c438141df65542d33340f98e.jpg",
                CategoryName = "Dessert"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 4,
                Name = "Shaurma",
                Price = 5.50,
                Description = "lll",
                ImageUrl = "https://storage.myseldon.com/news-pict-e7/E762CB007B23468FE0B8D7FD994EEEE2",
                CategoryName = "Snacks"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 5,
                Name = "Vodka",
                Price = 1,
                Description = "Privet From Russia",
                ImageUrl = "https://fikiwiki.com/uploads/posts/2022-02/1645022844_34-fikiwiki-com-p-kartinki-vodka-36.jpg",
                CategoryName = "Alcochool"
            });

        }
    }
}
