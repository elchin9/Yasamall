using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yasamall.Models;

namespace Yasamall.DAL
{
    public class Db_Yasamall : IdentityDbContext<AppUser>
    {
        public Db_Yasamall(DbContextOptions<Db_Yasamall> options) : base(options)
        {    
        }
        public DbSet<BackgroundImages> BackgroundImages { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Halls> Halls { get; set; }
        public DbSet<MailBox> MailBox { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Floor> Floor { get; set; }
        public DbSet<NewsPhotos> NewsPhotos { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<BrandTags> BrandTags { get; set; }
        public DbSet<NewProducts> NewProducts { get; set; }
        public DbSet<ProductColors> ProductColors { get; set; }
        public DbSet<ProductPhoto> ProductPhoto { get; set; }
        public DbSet<Sizes> Sizes { get; set; }
        public DbSet<ProductSizes> ProductSizes { get; set; }
        public DbSet<StaticData> StaticData { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //seeding Background Images table
            builder.Entity(typeof(BackgroundImages)).HasData(
                new BackgroundImages { Id = 1, PhotoURLOne = "prlx3.jpg", PhotoURLTwo = "prlx7.jpg", PhotoURLThree = "prlx8.jpg",
                                               PhotoURLFour = "prlx10.jpg", PhotoURLFive = "prlx13.jpg"}
            );

            //seeding Category table
            builder.Entity(typeof(Category)).HasData(
                new Category { Id = 1, Name = "Mağaza" },
                new Category { Id = 2, Name = "Restoran" },
                new Category { Id = 3, Name = "Əyləncə" }
            );

            //seeding Floor table
            builder.Entity(typeof(Floor)).HasData(
                new Floor { Id = 1, Name = "1-ci" },
                new Floor { Id = 2, Name = "2-ci" },
                new Floor { Id = 3, Name = "3-cü" },
                new Floor { Id = 4, Name = "4-cü" }
            );


            //seeding BrandTags table
            builder.Entity(typeof(Tags)).HasData(
                new Tags { Id = 1, Name = "Qadın Geyimləri", CategoryId = 1},
                new Tags { Id = 2, Name = "Kişi Geyimləri", CategoryId = 1 },
                new Tags { Id = 3, Name = "Uşaq Geyimləri", CategoryId = 1 },
                new Tags { Id = 4, Name = "Qadın Ayaqqabıları", CategoryId = 1 },
                new Tags { Id = 5, Name = "Kişi Ayaqqabıları", CategoryId = 1 },
                new Tags { Id = 6, Name = "Kitab", CategoryId = 1 },
                new Tags { Id = 7, Name = "Aksesuarlar", CategoryId = 1 },
                new Tags { Id = 8, Name = "Milli Mətbəx", CategoryId = 2 },
                new Tags { Id = 9, Name = "Fast Food", CategoryId = 2 },
                new Tags { Id = 10, Name = "Pizza", CategoryId = 2 },
                new Tags { Id = 11, Name = "İsti Yeməklər", CategoryId = 2 },
                new Tags { Id = 12, Name = "Kofe", CategoryId = 2 },
                new Tags { Id = 13, Name = "Şirniyyat", CategoryId = 2 },
                new Tags { Id = 14, Name = "Xarici Mətbəx", CategoryId = 2 },
                new Tags { Id = 15, Name = "Cinema", CategoryId = 3 },
                new Tags { Id = 16, Name = "Bowling", CategoryId = 3 }
            );

            //seeding Colors table
            builder.Entity(typeof(Colors)).HasData(
                new Colors { Id = 1, Color = "Qara", ColorCode = "black"},
                new Colors { Id = 2, Color = "Qırmızı" ,ColorCode = "red" },
                new Colors { Id = 3, Color = "Mavi", ColorCode = "blue" },
                new Colors { Id = 4, Color = "Narıncı", ColorCode = "orange"},
                new Colors { Id = 5, Color = "Çəhrayı", ColorCode = "pink" },
                new Colors { Id = 6, Color = "Tünd Göy", ColorCode = "darkBlue" },
                new Colors { Id = 7, Color = "Bordo", ColorCode = "bordo" },
                new Colors { Id = 8, Color = "Haki", ColorCode = "khaki" },
                new Colors { Id = 9, Color = "Ağ", ColorCode = "white" },
                new Colors { Id = 10, Color = "Boz", ColorCode = "gray" },
                new Colors { Id = 11, Color = "Sarı", ColorCode = "yellow" },
                new Colors { Id = 12, Color = "Qəhvəyi", ColorCode = "brown" },
                new Colors { Id = 13, Color = "Yaşıl", ColorCode = "green" },
                new Colors { Id = 14, Color = "Tünd Yaşıl", ColorCode = "darkGreen" },
                new Colors { Id = 15, Color = "Bənövşəyi", ColorCode = "violet" }
            );


            //seeding Sizes table
            builder.Entity(typeof(Sizes)).HasData(
                new Sizes { Id = 1, Size = "XS" },
                new Sizes { Id = 2, Size = "S" },
                new Sizes { Id = 3, Size = "M" },
                new Sizes { Id = 4, Size = "L" },
                new Sizes { Id = 5, Size = "XL" }
            );
            

            //seeding StaticData table
            builder.Entity(typeof(StaticData)).HasData(
                new StaticData { Id = 1,
                                 Map = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d48625.60582523336!2d49.77600605509767!3d40.3844681682866!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x40307d8c33c62a3f%3A0x77807ca915edd570!2zWWFzYW1hbCwgQmFrw7w!5e0!3m2!1str!2s!4v1566417631661!5m2!1str!2s",
                                 FacebookLink = "www.facebook.com",
                                 InstagramLink = "www.instagram.com",
                                 TwitterLink = "www.twitter.com",
                                 YoutubeLink = "www.youtube.com",
                                 Phone = "012 555 55 55",
                                 Mobile ="+994 55 555 55 55",
                                 Email = "yasa@mall.az"
                }
            );
   
        }
    }
}
