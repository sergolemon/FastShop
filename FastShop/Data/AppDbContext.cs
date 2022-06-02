using FastShop.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastShop.Data.ViewModels;
using Microsoft.EntityFrameworkCore.Storage;

namespace FastShop.Data
{
	public class AppDbContext : IdentityDbContext<User>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<MainCategory> MainCategories { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Subcategory> Subcategories { get; set; }
		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
        {
			builder.Entity<MainCategory>().HasData(new MainCategory[] {
				new MainCategory { Id = 1, Name = "Електроніка", EngName = "electronic", Img = "1.jpg" },
				new MainCategory { Id = 2, Name = "Аксесуари", EngName = "accessories", Img = "28.jpg" }
			});

			builder.Entity<Category>().HasData(new Category[] {
				new Category { Id = 1, Name = "Аудіотехніка", EngName = "audio", Img = "1.jpg", ParentCatId = 1 },
				new Category { Id = 2, Name = "Павер банк", EngName = "powerbank", Img = "25.jpg", ParentCatId = 1 },
				new Category { Id = 3, Name = "Чохли", EngName = "cases", Img = "13.jpg", ParentCatId = 2 },
				new Category { Id = 4, Name = "Дроти", EngName = "cord", Img = "28.jpg", ParentCatId = 2 }
			});

			builder.Entity<Subcategory>().HasData(new Subcategory[] {
				new Subcategory { Id = 1, Name = "Навушники", EngName = "headphones", Img = "1.jpg", ParentCatId = 1 },
				new Subcategory { Id = 2, Name = "Колонки", EngName = "speaker", Img = "7.jpg", ParentCatId = 1 }
			});

			builder.Entity<Product>().HasData(new Product[] {
				new Product 
				{ 
					Id = 1, 
					Name = "Навушники i20", 
					Manufacturer = "China", 
					Count = 20, 
					Desc = "Найкраща репліка AirPods на сьогодні.", 
					Img = "1.jpg,2.jpg,3.jpg",
					IsFavorite = true,
					IsSale = true,
					OldPrice = 1200,
					Price = 999,
					Tags = "headphones навушники i20",
					Video = String.Empty,
					MainCatId = 1,
					CatId = 1,
					SubcatId = 1
				},
				new Product
				{
					Id = 2,
					Name = "Колонка портатив JBL1",
					Manufacturer = "China",
					Count = 12,
					Desc = "Найзручніша та найгучніша колонка для Вас та вашої компанії =)",
					Img = "4.jpg,5.jpg,6.jpg",
					IsFavorite = true,
					IsSale = false,
					OldPrice = 1300,
					Price = 1299,
					Tags = "колонка jbl speaker",
					Video = String.Empty,
					MainCatId = 1,
					CatId = 1,
					SubcatId = 2
				},
				new Product
				{
					Id = 3,
					Name = "Колонка портатив JBL-3",
					Manufacturer = "China",
					Count = 18,
					Desc = "Найзручніша та найгучніша колонка для Вас та вашої компанії =)",
					Img = "7.jpg,8.jpg,9.jpg",
					IsFavorite = false,
					IsSale = true,
					OldPrice = 1500,
					Price = 1300,
					Tags = "колонка jbl speaker",
					Video = String.Empty,
					MainCatId = 1,
					CatId = 1,
					SubcatId = 2
				},
				new Product
				{
					Id = 4,
					Name = "Колонка портатив JBL-2",
					Manufacturer = "China",
					Count = 12,
					Desc = "Найзручніша та найгучніша колонка для Вас та вашої компанії =)",
					Img = "10.jpg,11.jpg,12.jpg",
					IsFavorite = true,
					IsSale = false,
					OldPrice = 1350,
					Price = 1200,
					Tags = "колонка jbl speaker",
					Video = String.Empty,
					MainCatId = 1,
					CatId = 1,
					SubcatId = 2
				},
				new Product
				{
					Id = 5,
					Name = "Чохол IPhone",
					Manufacturer = "China",
					Count = 12,
					Desc = "Силіконовий приємний на дотик чохол захистить ваш гаджет від неприємних несподіванок",
					Img = "13.jpg,14.jpg,15.jpg,16.jpg",
					IsFavorite = true,
					IsSale = false,
					OldPrice = 1350,
					Price = 299,
					Tags = "чохол iphone",
					Video = String.Empty,
					MainCatId = 2,
					CatId = 3
				},
				new Product
				{
					Id = 6,
					Name = "Чохол IPhone",
					Manufacturer = "China",
					Count = 12,
					Desc = "Силіконовий приємний на дотик чохол захистить ваш гаджет від неприємних несподіванок",
					Img = "17.jpg,18.jpg,19.jpg,20.jpg,21.jpg,22.jpg",
					IsFavorite = false,
					IsSale = false,
					OldPrice = 1350,
					Price = 249,
					Tags = "чохол iphone",
					Video = String.Empty,
					MainCatId = 2,
					CatId = 3
				},
				new Product
				{
					Id = 7,
					Name = "Павербанк White",
					Manufacturer = "China",
					Count = 12,
					Desc = "Стильний та компактний павербанк - саме те, чтого вам бракує у подорожі.",
					Img = "24.jpg,25.jpg,26.jpg",
					IsFavorite = true,
					IsSale = false,
					OldPrice = 1350,
					Price = 799,
					Tags = "power bank павер банк",
					Video = String.Empty,
					MainCatId = 1,
					CatId = 2
				},
				new Product
				{
					Id = 8,
					Name = "Павербанк Black",
					Manufacturer = "China",
					Count = 12,
					Desc = "Стильний та компактний павербанк - саме те, чтого вам бракує у подорожі.",
					Img = "23.jpg",
					IsFavorite = false,
					IsSale = true,
					OldPrice = 799,
					Price = 649,
					Tags = "power bank павер банк",
					Video = String.Empty,
					MainCatId = 1,
					CatId = 2
				},
				new Product
				{
					Id = 9,
					Name = "USB-usb mini дріт",
					Manufacturer = "China",
					Count = 12,
					Desc = "Стильний та такий необхідний для майже будь-якого сучасного гаджета.",
					Img = "27.jpg,28.jpg",
					IsFavorite = false,
					IsSale = false,
					OldPrice = 799,
					Price = 99,
					Tags = "юсб usb дріт",
					Video = String.Empty,
					MainCatId = 2,
					CatId = 4
				}
			});

			base.OnModelCreating(builder);
        }
	}
}
