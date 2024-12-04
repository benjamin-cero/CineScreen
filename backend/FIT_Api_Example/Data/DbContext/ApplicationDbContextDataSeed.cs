using FIT_Api_Example.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace FIT_Api_Example.Data
{
    partial class ApplicationDbContext
    {


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

            // Cities

            modelBuilder.Entity<City>().HasData(
                  new City { CityID = 1, Name = "Banja Luka" },
                  new City { CityID = 2, Name = "Bihać" },
                  new City { CityID = 3, Name = "Bijeljina" },
                  new City { CityID = 4, Name = "Bosnaska Krupa" },
                  new City { CityID = 5, Name = "Cazin" },
                  new City { CityID = 6, Name = "Čapljina" },
                  new City { CityID = 7, Name = "Drventa" },
                  new City { CityID = 8, Name = "Doboj" },
                  new City { CityID = 9, Name = "Goražde" },
                  new City { CityID = 10, Name = "Gračanica" },
                  new City { CityID = 11, Name = "Gradačac" },
                  new City { CityID = 12, Name = "Gradiška" },
                  new City { CityID = 13, Name = "Konjic" },
                  new City { CityID = 14, Name = "Laktaši" },
                  new City { CityID = 15, Name = "Livno" },
                  new City { CityID = 16, Name = "Lukavac" },
                  new City { CityID = 17, Name = "Ljubuški" },
                  new City { CityID = 18, Name = "Mostar" },
                  new City { CityID = 19, Name = "Orašje" },
                  new City { CityID = 20, Name = "Prijedor" },
                  new City { CityID = 21, Name = "Prnjavor" },
                  new City { CityID = 22, Name = "Sarajevo" },
                  new City { CityID = 23, Name = "Srebrenik" },
                  new City { CityID = 24, Name = "Stolac" },
                  new City { CityID = 25, Name = "Široki Brijeg" },
                  new City { CityID = 26, Name = "Travnik" },
                  new City { CityID = 27, Name = "Tuzla" },
                  new City { CityID = 28, Name = "Visoko" },
                  new City { CityID = 29, Name = "Zavidovići" },
                  new City { CityID = 30, Name = "Zenica" },
                  new City { CityID = 31, Name = "Zvornik" },
                  new City { CityID = 32, Name = "Živinice" },
                  new City { CityID = 33, Name = "Donji Vakuf" },
                  new City { CityID = 34, Name = "Zavidovići" }
            );

            // Genders 
            modelBuilder.Entity<Gender>().HasData(
                new Gender { GenderID = 1, Name = "Male" },
                new Gender { GenderID = 2, Name = "Fmale" }
            );

            // Generes
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreID = 1, Name = "Action" },
                new Genre { GenreID = 2, Name = "Adventure" },
                new Genre { GenreID = 3, Name = "Drama" },
                new Genre { GenreID = 4, Name = "Fantasy" },
                new Genre { GenreID = 5, Name = "Horror" },
                new Genre { GenreID = 6, Name = "Mystery" },
                new Genre { GenreID = 7, Name = "Romance" },
                new Genre { GenreID = 8, Name = "Science Fiction" },
                new Genre { GenreID = 9, Name = "Sci-Fi" },
                new Genre { GenreID = 10, Name = "Thriller" },
                new Genre { GenreID = 11, Name = "Crime" },
                new Genre { GenreID = 12, Name = "Historical" },
                new Genre { GenreID = 13, Name = "Superhero" },
                new Genre { GenreID = 14, Name = "Western" },
                new Genre { GenreID = 15, Name = "Musical" },
                new Genre { GenreID = 16, Name = "War" },
                new Genre { GenreID = 17, Name = "Biographical" },
                new Genre { GenreID = 18, Name = "Sports" },
                new Genre { GenreID = 19, Name = "Family" },
                new Genre { GenreID = 20, Name = "Animation" },
                new Genre { GenreID = 21, Name = "Documentary" },
                new Genre { GenreID = 22, Name = "Noir" },
                new Genre { GenreID = 23, Name = "Fantasy Adventure" },
                new Genre { GenreID = 24, Name = "Romantic Comedy" },
                new Genre { GenreID = 25, Name = "Psychological Thriller" },
                new Genre { GenreID = 26, Name = "Slasher" },
                new Genre { GenreID = 27, Name = "Parody" },
                new Genre { GenreID = 28, Name = "Post-Apocalyptic" },
                new Genre { GenreID = 29, Name = "Found Footage" },
                new Genre { GenreID = 30, Name = "Martial Arts" },
                new Genre { GenreID = 31, Name = "Spy" },
                new Genre { GenreID = 32, Name = "Disaster" },
                new Genre { GenreID = 33, Name = "Dark Comedy" },
                new Genre { GenreID = 34, Name = "Teen" },
                new Genre { GenreID = 35, Name = "Gothic Horror" },
                new Genre { GenreID = 36, Name = "Cyberpunk" },
                new Genre { GenreID = 37, Name = "Steampunk" },
                new Genre { GenreID = 38, Name = "Space Opera" },
                new Genre { GenreID = 39, Name = "Time Travel" }
            );

            modelBuilder.Entity<Actor>().HasData(

                new Actor { ActorID = 1, FirstName = "Leonardo", LastName = "DiCaprio" },
                new Actor { ActorID = 2, FirstName = "Brad", LastName = "Pitt" },
                new Actor { ActorID = 3, FirstName = "Tom", LastName = "Cruise" },
                new Actor { ActorID = 4, FirstName = "Robert", LastName = "Downey Jr." },
                new Actor { ActorID = 5, FirstName = "Chris", LastName = "Hemsworth" },
                new Actor { ActorID = 6, FirstName = "Dwayne", LastName = "Johnson" },
                new Actor { ActorID = 7, FirstName = "Ryan", LastName = "Reynolds" },
                new Actor { ActorID = 8, FirstName = "Keanu", LastName = "Reeves" },
                new Actor { ActorID = 9, FirstName = "Chris", LastName = "Evans" },
                new Actor { ActorID = 10, FirstName = "Joaquin", LastName = "Phoenix" },
                new Actor { ActorID = 11, FirstName = "Timothée", LastName = "Chalamet" },
                new Actor { ActorID = 12, FirstName = "Zendaya", LastName = "" },
                new Actor { ActorID = 13, FirstName = "Florence", LastName = "Pugh" },
                new Actor { ActorID = 14, FirstName = "Margot", LastName = "Robbie" },
                new Actor { ActorID = 15, FirstName = "Christian", LastName = "Bale" },
                new Actor { ActorID = 16, FirstName = "Will", LastName = "Smith" },
                new Actor { ActorID = 17, FirstName = "Matt", LastName = "Damon" },
                new Actor { ActorID = 18, FirstName = "Benedict", LastName = "Cumberbatch" },
                new Actor { ActorID = 19, FirstName = "Hugh", LastName = "Jackman" },
                new Actor { ActorID = 20, FirstName = "Scarlett", LastName = "Johansson" },
                new Actor { ActorID = 21, FirstName = "Emma", LastName = "Stone" },
                new Actor { ActorID = 22, FirstName = "Jennifer", LastName = "Lawrence" },
                new Actor { ActorID = 23, FirstName = "Gal", LastName = "Gadot" },
                new Actor { ActorID = 24, FirstName = "Anne", LastName = "Hathaway" },
                new Actor { ActorID = 25, FirstName = "Cillian", LastName = "Murphy" },
                new Actor { ActorID = 26, FirstName = "Tom", LastName = "Holland" },
                new Actor { ActorID = 27, FirstName = "Andrew", LastName = "Garfield" },
                new Actor { ActorID = 28, FirstName = "Zac", LastName = "Efron" },
                new Actor { ActorID = 29, FirstName = "Jake", LastName = "Gyllenhaal" },
                new Actor { ActorID = 30, FirstName = "Oscar", LastName = "Isaac" },
                new Actor { ActorID = 31, FirstName = "Eddie", LastName = "Redmayne" },
                new Actor { ActorID = 32, FirstName = "Pedro", LastName = "Pascal" },
                new Actor { ActorID = 33, FirstName = "Millie", LastName = "Bobby Brown" },
                new Actor { ActorID = 34, FirstName = "Natalie", LastName = "Portman" },
                new Actor { ActorID = 35, FirstName = "Javier", LastName = "Bardem" },
                new Actor { ActorID = 36, FirstName = "Daniel", LastName = "Craig" },
                new Actor { ActorID = 37, FirstName = "Michael", LastName = "Fassbender" },
                new Actor { ActorID = 38, FirstName = "Idris", LastName = "Elba" },
                new Actor { ActorID = 39, FirstName = "Paul", LastName = "Rudd" },
                new Actor { ActorID = 40, FirstName = "Jared", LastName = "Leto" },
                new Actor { ActorID = 41, FirstName = "Emma", LastName = "Watson" },
                new Actor { ActorID = 42, FirstName = "Saoirse", LastName = "Ronan" },
                new Actor { ActorID = 43, FirstName = "Daniel", LastName = "Radcliffe" },
                new Actor { ActorID = 44, FirstName = "Ryan", LastName = "Gosling" },
                new Actor { ActorID = 45, FirstName = "Robert", LastName = "Pattinson" },
                new Actor { ActorID = 46, FirstName = "Jason", LastName = "Momoa" },
                new Actor { ActorID = 47, FirstName = "Angelina", LastName = "Jolie" },
                new Actor { ActorID = 48, FirstName = "Anne", LastName = "Hathaway" },
                new Actor { ActorID = 49, FirstName = "Meryl", LastName = "Streep" },
                new Actor { ActorID = 50, FirstName = "Reese", LastName = "Witherspoon" },
                new Actor { ActorID = 51, FirstName = "Cate", LastName = "Blanchett" },
                new Actor { ActorID = 52, FirstName = "Viola", LastName = "Davis" },
                new Actor { ActorID = 53, FirstName = "Julia", LastName = "Roberts" },
                new Actor { ActorID = 54, FirstName = "Sandra", LastName = "Bullock" },
                new Actor { ActorID = 55, FirstName = "Halle", LastName = "Berry" },
                new Actor { ActorID = 56, FirstName = "Nicole", LastName = "Kidman" },
                new Actor { ActorID = 57, FirstName = "Amy", LastName = "Adams" },
                new Actor { ActorID = 58, FirstName = "Jessica", LastName = "Chastain" },
                new Actor { ActorID = 59, FirstName = "Tom", LastName = "Hanks" },
                new Actor { ActorID = 60, FirstName = "Billie", LastName = "Eilish" },
                new Actor { ActorID = 61, FirstName = "Robin", LastName = "Wright" },
                new Actor { ActorID = 62, FirstName = "Winona", LastName = "Ryder" },
                new Actor { ActorID = 63, FirstName = "Chadwick", LastName = "Boseman" },
                new Actor { ActorID = 64, FirstName = "Ewan", LastName = "McGregor" },
                new Actor { ActorID = 65, FirstName = "Sam", LastName = "Rockwell" },
                new Actor { ActorID = 66, FirstName = "Mahershala", LastName = "Ali" },
                new Actor { ActorID = 67, FirstName = "Elizabeth", LastName = "Olsen" },
                new Actor { ActorID = 68, FirstName = "Mark", LastName = "Ruffalo" },
                new Actor { ActorID = 69, FirstName = "Tilda", LastName = "Swinton" },
                new Actor { ActorID = 70, FirstName = "Eva", LastName = "Green" },
                new Actor { ActorID = 71, FirstName = "John", LastName = "Boyega" },
                new Actor { ActorID = 72, FirstName = "Natalie", LastName = "Dormer" },
                new Actor { ActorID = 73, FirstName = "David", LastName = "Harbour" },
                new Actor { ActorID = 74, FirstName = "Anya", LastName = "Taylor-Joy" },
                new Actor { ActorID = 75, FirstName = "Rami", LastName = "Malek" },
                new Actor { ActorID = 76, FirstName = "Sophia", LastName = "Lillis" },
                new Actor { ActorID = 77, FirstName = "Finn", LastName = "Wolfhard" },
                new Actor { ActorID = 78, FirstName = "Noah", LastName = "Schnapp" },
                new Actor { ActorID = 79, FirstName = "Sadie", LastName = "Sink" },
                new Actor { ActorID = 80, FirstName = "Maya", LastName = "Hawke" },
                new Actor { ActorID = 81, FirstName = "Steve", LastName = "Carell" },
                new Actor { ActorID = 82, FirstName = "Jonah", LastName = "Hill" },
                new Actor { ActorID = 83, FirstName = "Seth", LastName = "Rogen" },
                new Actor { ActorID = 84, FirstName = "James", LastName = "Franco" },
                new Actor { ActorID = 85, FirstName = "Emily", LastName = "Blunt" },
                new Actor { ActorID = 86, FirstName = "Lupita", LastName = "Nyong'o" },
                new Actor { ActorID = 87, FirstName = "Danai", LastName = "Gurira" },
                new Actor { ActorID = 88, FirstName = "Chloë", LastName = "Grace Moretz" },
                new Actor { ActorID = 89, FirstName = "Haley", LastName = "Bennett" },
                new Actor { ActorID = 90, FirstName = "Zoe", LastName = "Kravitz" },
                new Actor { ActorID = 91, FirstName = "Rosamund", LastName = "Pike" },
                new Actor { ActorID = 92, FirstName = "Charlize", LastName = "Theron" },
                new Actor { ActorID = 93, FirstName = "Jessica", LastName = "Alba" },
                new Actor { ActorID = 94, FirstName = "Mila", LastName = "Kunis" },
                new Actor { ActorID = 95, FirstName = "Ashton", LastName = "Kutcher" },
                new Actor { ActorID = 96, FirstName = "Hugh", LastName = "Grant" },
                new Actor { ActorID = 97, FirstName = "Colin", LastName = "Firth" },
                new Actor { ActorID = 98, FirstName = "Jude", LastName = "Law" },
                new Actor { ActorID = 99, FirstName = "Jamie", LastName = "Foxx" },
                new Actor { ActorID = 100, FirstName = "Morgan", LastName = "Freeman" }
            );

            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { ManufacturerID = 1, Name = "Orville Redenbacher’s" },
                new Manufacturer { ManufacturerID = 2, Name = "Act II" },
                new Manufacturer { ManufacturerID = 3, Name = "Lay’s" },
                new Manufacturer { ManufacturerID = 4, Name = "Pringles" },
                new Manufacturer { ManufacturerID = 5, Name = "Doritos" },
                new Manufacturer { ManufacturerID = 6, Name = "Cheetos" },
                new Manufacturer { ManufacturerID = 7, Name = "Ruffles" },
                new Manufacturer { ManufacturerID = 8, Name = "Tostitos" },
                new Manufacturer { ManufacturerID = 9, Name = "M&M’s" },
                new Manufacturer { ManufacturerID = 10, Name = "Snickers" },
                new Manufacturer { ManufacturerID = 11, Name = "Twix" },
                new Manufacturer { ManufacturerID = 12, Name = "Reese’s" },
                new Manufacturer { ManufacturerID = 13, Name = "KitKat" },
                new Manufacturer { ManufacturerID = 14, Name = "Nestlé" },
                new Manufacturer { ManufacturerID = 15, Name = "Haribo" },
                new Manufacturer { ManufacturerID = 16, Name = "Sour Patch Kids" },
                new Manufacturer { ManufacturerID = 17, Name = "Skittles" },
                new Manufacturer { ManufacturerID = 18, Name = "Coca-Cola" },
                new Manufacturer { ManufacturerID = 19, Name = "Pepsi" },
                new Manufacturer { ManufacturerID = 20, Name = "Sprite" },
                new Manufacturer { ManufacturerID = 21, Name = "Fanta" },
                new Manufacturer { ManufacturerID = 22, Name = "Dr. Pepper" },
                new Manufacturer { ManufacturerID = 23, Name = "7UP" },
                new Manufacturer { ManufacturerID = 24, Name = "Red Bull" },
                new Manufacturer { ManufacturerID = 25, Name = "Ben & Jerry’s" },
                new Manufacturer { ManufacturerID = 26, Name = "Häagen-Dazs" },
                new Manufacturer { ManufacturerID = 27, Name = "Magnum" },
                new Manufacturer { ManufacturerID = 28, Name = "Boomchickapop" },
                new Manufacturer { ManufacturerID = 29, Name = "Smartfood" },
                new Manufacturer { ManufacturerID = 30, Name = "Pop Secret" },
                new Manufacturer { ManufacturerID = 31, Name = "Kernel Season’s" },
                new Manufacturer { ManufacturerID = 32, Name = "Blue Bell" },
                new Manufacturer { ManufacturerID = 33, Name = "Kind Bars" },
                new Manufacturer { ManufacturerID = 34, Name = "Nature Valley" },
                new Manufacturer { ManufacturerID = 35, Name = "Clif Bars" },
                new Manufacturer { ManufacturerID = 36, Name = "Veggie Straws" },
                new Manufacturer { ManufacturerID = 37, Name = "Bare Snacks" },
                new Manufacturer { ManufacturerID = 38, Name = "Jolly Time" },
                new Manufacturer { ManufacturerID = 39, Name = "Mars" },
                new Manufacturer { ManufacturerID = 40, Name = "Trolli" },
                new Manufacturer { ManufacturerID = 41, Name = "Mondelez International" },
                new Manufacturer { ManufacturerID = 42, Name = "Frito-Lay" },
                new Manufacturer { ManufacturerID = 43, Name = "Dr Pepper Snapple Group" },
                new Manufacturer { ManufacturerID = 44, Name = "Unilever" },
                new Manufacturer { ManufacturerID = 45, Name = "Blue Bell Creameries" },
                new Manufacturer { ManufacturerID = 46, Name = "Kellogg's" }
            );

                        modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, Name = "Orville Redenbacher’s Popcorn", Price = 3.50, ManufacturerID = 1 },
                new Product { ProductID = 2, Name = "Act II Popcorn", Price = 2.50, ManufacturerID = 2 },
                new Product { ProductID = 3, Name = "Lay’s Potato Chips", Price = 1.99, ManufacturerID = 3 },
                new Product { ProductID = 4, Name = "Pringles Chips", Price = 2.99, ManufacturerID = 4 },
                new Product { ProductID = 5, Name = "Doritos Nachos", Price = 2.49, ManufacturerID = 5 },
                new Product { ProductID = 6, Name = "Cheetos Cheese Puffs", Price = 1.89, ManufacturerID = 6 },
                new Product { ProductID = 7, Name = "Ruffles Potato Chips", Price = 2.99, ManufacturerID = 7 },
                new Product { ProductID = 8, Name = "Tostitos Tortilla Chips", Price = 3.29, ManufacturerID = 8 },
                new Product { ProductID = 9, Name = "M&M’s Chocolate Candies", Price = 4.00, ManufacturerID = 9 },
                new Product { ProductID = 10, Name = "Snickers Bars", Price = 1.50, ManufacturerID = 10 },
                new Product { ProductID = 11, Name = "Twix Bars", Price = 1.70, ManufacturerID = 11 },
                new Product { ProductID = 12, Name = "Reese’s Peanut Butter Cups", Price = 1.60, ManufacturerID = 12 },
                new Product { ProductID = 13, Name = "KitKat Bars", Price = 1.40, ManufacturerID = 13 },
                new Product { ProductID = 14, Name = "Nestlé Chocolate", Price = 2.20, ManufacturerID = 14 },
                new Product { ProductID = 15, Name = "Haribo Gummy Bears", Price = 2.50, ManufacturerID = 15 },
                new Product { ProductID = 16, Name = "Sour Patch Kids", Price = 1.80, ManufacturerID = 16 },
                new Product { ProductID = 17, Name = "Skittles Candy", Price = 2.00, ManufacturerID = 17 },
                new Product { ProductID = 18, Name = "Coca-Cola Soft Drink", Price = 1.20, ManufacturerID = 18 },
                new Product { ProductID = 19, Name = "Pepsi Soft Drink", Price = 1.20, ManufacturerID = 19 },
                new Product { ProductID = 20, Name = "Sprite Soft Drink", Price = 1.10, ManufacturerID = 20 },
                new Product { ProductID = 21, Name = "Fanta Soft Drink", Price = 1.10, ManufacturerID = 21 },
                new Product { ProductID = 22, Name = "Dr. Pepper Soft Drink", Price = 1.30, ManufacturerID = 22 },
                new Product { ProductID = 23, Name = "7UP Soft Drink", Price = 1.10, ManufacturerID = 23 },
                new Product { ProductID = 24, Name = "Red Bull Energy Drink", Price = 2.50, ManufacturerID = 24 },
                new Product { ProductID = 25, Name = "Ben & Jerry’s Ice Cream", Price = 5.00, ManufacturerID = 25 },
                new Product { ProductID = 26, Name = "Häagen-Dazs Ice Cream", Price = 5.50, ManufacturerID = 26 },
                new Product { ProductID = 27, Name = "Magnum Ice Cream", Price = 4.50, ManufacturerID = 27 },
                new Product { ProductID = 28, Name = "Boomchickapop Popcorn", Price = 3.00, ManufacturerID = 28 },
                new Product { ProductID = 29, Name = "Smartfood Popcorn", Price = 3.50, ManufacturerID = 29 },
                new Product { ProductID = 30, Name = "Pop Secret Popcorn", Price = 2.75, ManufacturerID = 30 },
                new Product { ProductID = 31, Name = "Kernel Season’s Popcorn Seasoning", Price = 1.50, ManufacturerID = 31 },
                new Product { ProductID = 32, Name = "Blue Bell Ice Cream", Price = 4.75, ManufacturerID = 32 },
                new Product { ProductID = 33, Name = "Kind Bars", Price = 2.00, ManufacturerID = 33 },
                new Product { ProductID = 34, Name = "Nature Valley Granola Bars", Price = 2.50, ManufacturerID = 34 },
                new Product { ProductID = 35, Name = "Clif Bars", Price = 2.20, ManufacturerID = 35 },
                new Product { ProductID = 36, Name = "Veggie Straws", Price = 3.00, ManufacturerID = 36 },
                new Product { ProductID = 37, Name = "Bare Snacks", Price = 2.80, ManufacturerID = 37 },
                new Product { ProductID = 38, Name = "Jolly Time Popcorn", Price = 2.50, ManufacturerID = 38 },
                new Product { ProductID = 39, Name = "Mars Chocolate", Price = 1.90, ManufacturerID = 39 },
                new Product { ProductID = 40, Name = "Trolli Gummy Worms", Price = 1.80, ManufacturerID = 40 },
                new Product { ProductID = 41, Name = "Mondelez International Snacks", Price = 2.50, ManufacturerID = 41 },
                new Product { ProductID = 42, Name = "Frito-Lay Chips", Price = 3.00, ManufacturerID = 42 },
                new Product { ProductID = 43, Name = "Dr Pepper Snapple Group Drinks", Price = 1.40, ManufacturerID = 43 },
                new Product { ProductID = 44, Name = "Unilever Snacks", Price = 2.60, ManufacturerID = 44 },
                new Product { ProductID = 45, Name = "Blue Bell Creameries Ice Cream", Price = 4.80, ManufacturerID = 45 },
                new Product { ProductID = 46, Name = "Kellogg's Snacks", Price = 2.30, ManufacturerID = 46 }
            );




            modelBuilder.Entity<ProductionHouse>().HasData(
                new ProductionHouse { ProductionHouseID = 1, Name = "Warner Bros." },
                new ProductionHouse { ProductionHouseID = 2, Name = "Universal Pictures" },
                new ProductionHouse { ProductionHouseID = 3, Name = "20th Century Studios" },
                new ProductionHouse { ProductionHouseID = 4, Name = "Paramount Pictures" },
                new ProductionHouse { ProductionHouseID = 5, Name = "Walt Disney Pictures" },
                new ProductionHouse { ProductionHouseID = 6, Name = "Columbia Pictures" },
                new ProductionHouse { ProductionHouseID = 7, Name = "Sony Pictures" },
                new ProductionHouse { ProductionHouseID = 8, Name = "Lionsgate" },
                new ProductionHouse { ProductionHouseID = 9, Name = "Metro-Goldwyn-Mayer (MGM)" },
                new ProductionHouse { ProductionHouseID = 10, Name = "New Line Cinema" },
                new ProductionHouse { ProductionHouseID = 11, Name = "DreamWorks Pictures" },
                new ProductionHouse { ProductionHouseID = 12, Name = "Warner Independent Pictures" },
                new ProductionHouse { ProductionHouseID = 13, Name = "Fox Searchlight Pictures" },
                new ProductionHouse { ProductionHouseID = 14, Name = "A24" },
                new ProductionHouse { ProductionHouseID = 15, Name = "Lionsgate Films" },
                new ProductionHouse { ProductionHouseID = 16, Name = "Blumhouse Productions" },
                new ProductionHouse { ProductionHouseID = 17, Name = "TriStar Pictures" },
                new ProductionHouse { ProductionHouseID = 18, Name = "Legendary Entertainment" },
                new ProductionHouse { ProductionHouseID = 19, Name = "Focus Features" },
                new ProductionHouse { ProductionHouseID = 20, Name = "Studio Ghibli" },
                new ProductionHouse { ProductionHouseID = 21, Name = "Paramount Vantage" },
                new ProductionHouse { ProductionHouseID = 22, Name = "Village Roadshow Pictures" },
                new ProductionHouse { ProductionHouseID = 23, Name = "New Regency Productions" },
                new ProductionHouse { ProductionHouseID = 24, Name = "Amblin Entertainment" },
                new ProductionHouse { ProductionHouseID = 25, Name = "Castle Rock Entertainment" },
                new ProductionHouse { ProductionHouseID = 26, Name = "The Weinstein Company" },
                new ProductionHouse { ProductionHouseID = 27, Name = "Miramax Films" },
                new ProductionHouse { ProductionHouseID = 28, Name = "Aardman Animations" },
                new ProductionHouse { ProductionHouseID = 29, Name = "Blue Sky Studios" },
                new ProductionHouse { ProductionHouseID = 30, Name = "Pixar Animation Studios" },
                new ProductionHouse { ProductionHouseID = 31, Name = "The Walt Disney Company" },
                new ProductionHouse { ProductionHouseID = 32, Name = "Illumination Entertainment" },
                new ProductionHouse { ProductionHouseID = 33, Name = "GK Films" },
                new ProductionHouse { ProductionHouseID = 34, Name = "Bleecker Street" },
                new ProductionHouse { ProductionHouseID = 35, Name = "Open Road Films" },
                new ProductionHouse { ProductionHouseID = 36, Name = "Film4 Productions" },
                new ProductionHouse { ProductionHouseID = 37, Name = "STX Entertainment" },
                new ProductionHouse { ProductionHouseID = 38, Name = "Pathé" },
                new ProductionHouse { ProductionHouseID = 39, Name = "Cineplex Entertainment" },
                new ProductionHouse { ProductionHouseID = 40, Name = "Toho" },
                new ProductionHouse { ProductionHouseID = 41, Name = "The Asylum" },
                new ProductionHouse { ProductionHouseID = 42, Name = "United Artists" },
                new ProductionHouse { ProductionHouseID = 43, Name = "TriStar Pictures" },
                new ProductionHouse { ProductionHouseID = 44, Name = "Castle Rock Entertainment" },
                new ProductionHouse { ProductionHouseID = 45, Name = "Broad Green Pictures" },
                new ProductionHouse { ProductionHouseID = 46, Name = "FilmDistrict" },
                new ProductionHouse { ProductionHouseID = 47, Name = "Hammer Films" },
                new ProductionHouse { ProductionHouseID = 48, Name = "Lions Gate Entertainment" },
                new ProductionHouse { ProductionHouseID = 49, Name = "Sam Raimi's Ghost House Pictures" },
                new ProductionHouse { ProductionHouseID = 50, Name = "Sundance Institute" },
                new ProductionHouse { ProductionHouseID = 51, Name = "Shudder" },
                new ProductionHouse { ProductionHouseID = 52, Name = "Aardman Animations" },
                new ProductionHouse { ProductionHouseID = 53, Name = "Laika Studios" },
                new ProductionHouse { ProductionHouseID = 54, Name = "Constantin Film" },
                new ProductionHouse { ProductionHouseID = 55, Name = "DreamWorks Animation" },
                new ProductionHouse { ProductionHouseID = 56, Name = "Saban Films" },
                new ProductionHouse { ProductionHouseID = 57, Name = "Blue Sky Studios" },
                new ProductionHouse { ProductionHouseID = 58, Name = "Walt Disney Television Animation" },
                new ProductionHouse { ProductionHouseID = 59, Name = "Warner Bros. Animation" },
                new ProductionHouse { ProductionHouseID = 60, Name = "Big Beach Films" },
                new ProductionHouse { ProductionHouseID = 61, Name = "Pinewood Studios" },
                new ProductionHouse { ProductionHouseID = 62, Name = "Boll KG" },
                new ProductionHouse { ProductionHouseID = 63, Name = "Red Hour Films" },
                new ProductionHouse { ProductionHouseID = 64, Name = "MadRiver Pictures" },
                new ProductionHouse { ProductionHouseID = 65, Name = "Ink Factory" },
                new ProductionHouse { ProductionHouseID = 66, Name = "Crackle" },
                new ProductionHouse { ProductionHouseID = 67, Name = "Elevation Pictures" },
                new ProductionHouse { ProductionHouseID = 68, Name = "Nighthawk Pictures" },
                new ProductionHouse { ProductionHouseID = 69, Name = "Wild Bunch" },
                new ProductionHouse { ProductionHouseID = 70, Name = "Yash Raj Films" },
                new ProductionHouse { ProductionHouseID = 71, Name = "Eros International" },
                new ProductionHouse { ProductionHouseID = 72, Name = "T-Series" },
                new ProductionHouse { ProductionHouseID = 73, Name = "Balaji Telefilms" },
                new ProductionHouse { ProductionHouseID = 74, Name = "Reliance Entertainment" },
                new ProductionHouse { ProductionHouseID = 75, Name = "Fox Film Corporation" },
                new ProductionHouse { ProductionHouseID = 76, Name = "Filmax" },
                new ProductionHouse { ProductionHouseID = 77, Name = "Cineworld" },
                new ProductionHouse { ProductionHouseID = 78, Name = "Polygon Pictures" },
                new ProductionHouse { ProductionHouseID = 79, Name = "StudioCanal" },
                new ProductionHouse { ProductionHouseID = 80, Name = "Bauer Media Group" },
                new ProductionHouse { ProductionHouseID = 81, Name = "Koch Media" },
                new ProductionHouse { ProductionHouseID = 82, Name = "IFC Films" },
                new ProductionHouse { ProductionHouseID = 83, Name = "Tokyo Movie Shinsha" },
                new ProductionHouse { ProductionHouseID = 84, Name = "Toei Animation" },
                new ProductionHouse { ProductionHouseID = 85, Name = "Shinji Aramaki" },
                new ProductionHouse { ProductionHouseID = 86, Name = "Manga Entertainment" },
                new ProductionHouse { ProductionHouseID = 87, Name = "Studio Ponoc" },
                new ProductionHouse { ProductionHouseID = 88, Name = "Toho Company" },
                new ProductionHouse { ProductionHouseID = 89, Name = "Sega Sammy Holdings" },
                new ProductionHouse { ProductionHouseID = 90, Name = "Marvel Studios" },
                new ProductionHouse { ProductionHouseID = 91, Name = "DC Films" },
                new ProductionHouse { ProductionHouseID = 92, Name = "Pixar Animation Studios" },
                new ProductionHouse { ProductionHouseID = 93, Name = "Studio Ghibli" },
                new ProductionHouse { ProductionHouseID = 94, Name = "The Jim Henson Company" },
                new ProductionHouse { ProductionHouseID = 95, Name = "Legendary Entertainment" },
                new ProductionHouse { ProductionHouseID = 96, Name = "Blumhouse Productions" },
                new ProductionHouse { ProductionHouseID = 97, Name = "Bad Robot Productions" },
                new ProductionHouse { ProductionHouseID = 98, Name = "Chernin Entertainment" },
                new ProductionHouse { ProductionHouseID = 99, Name = "Silver Pictures" },
                new ProductionHouse { ProductionHouseID = 100, Name = "Platinum Dunes" }
            );
            modelBuilder.Entity<Director>().HasData(
                new Director { DirectorID = 1, FirstName = "Steven", LastName = "Spielberg" },
                new Director { DirectorID = 2, FirstName = "Martin", LastName = "Scorsese" },
                new Director { DirectorID = 3, FirstName = "Quentin", LastName = "Tarantino" },
                new Director { DirectorID = 4, FirstName = "Christopher", LastName = "Nolan" },
                new Director { DirectorID = 5, FirstName = "Alfred", LastName = "Hitchcock" },
                new Director { DirectorID = 6, FirstName = "James", LastName = "Cameron" },
                new Director { DirectorID = 7, FirstName = "Stanley", LastName = "Kubrick" },
                new Director { DirectorID = 8, FirstName = "Ridley", LastName = "Scott" },
                new Director { DirectorID = 9, FirstName = "Francis", LastName = "Ford Coppola" },
                new Director { DirectorID = 10, FirstName = "Tim", LastName = "Burton" },
                new Director { DirectorID = 11, FirstName = "Wes", LastName = "Anderson" },
                new Director { DirectorID = 12, FirstName = "David", LastName = "Fincher" },
                new Director { DirectorID = 13, FirstName = "George", LastName = "Lucas" },
                new Director { DirectorID = 14, FirstName = "Woody", LastName = "Allen" },
                new Director { DirectorID = 15, FirstName = "Roman", LastName = "Polanski" },
                new Director { DirectorID = 16, FirstName = "Michael", LastName = "Bay" },
                new Director { DirectorID = 17, FirstName = "Zack", LastName = "Snyder" },
                new Director { DirectorID = 18, FirstName = "Peter", LastName = "Jackson" },
                new Director { DirectorID = 19, FirstName = "Christopher", LastName = "McQuarrie" },
                new Director { DirectorID = 20, FirstName = "Paul", LastName = "Thomas Anderson" },
                new Director { DirectorID = 21, FirstName = "Joel", LastName = "Coen" },
                new Director { DirectorID = 22, FirstName = "Ethan", LastName = "Coen" },
                new Director { DirectorID = 23, FirstName = "John", LastName = "Carpenter" },
                new Director { DirectorID = 24, FirstName = "Spike", LastName = "Lee" },
                new Director { DirectorID = 25, FirstName = "Hayao", LastName = "Miyazaki" },
                new Director { DirectorID = 26, FirstName = "Guillermo", LastName = "del Toro" },
                new Director { DirectorID = 27, FirstName = "Jean-Pierre", LastName = "Jeunet" },
                new Director { DirectorID = 28, FirstName = "Frank", LastName = "Darabont" },
                new Director { DirectorID = 29, FirstName = "Ang", LastName = "Lee" },
                new Director { DirectorID = 30, FirstName = "Barry", LastName = "Jenkins" },
                new Director { DirectorID = 31, FirstName = "Kathryn", LastName = "Bigelow" },
                new Director { DirectorID = 32, FirstName = "Danny", LastName = "Boyle" },
                new Director { DirectorID = 33, FirstName = "Martin", LastName = "McDonagh" },
                new Director { DirectorID = 34, FirstName = "Taika", LastName = "Waititi" },
                new Director { DirectorID = 35, FirstName = "J.J.", LastName = "Abrams" },
                new Director { DirectorID = 36, FirstName = "Danny", LastName = "DeVito" },
                new Director { DirectorID = 37, FirstName = "Lana", LastName = "Wachowski" },
                new Director { DirectorID = 38, FirstName = "Lilly", LastName = "Wachowski" },
                new Director { DirectorID = 39, FirstName = "Robert", LastName = "Zemeckis" },
                new Director { DirectorID = 40, FirstName = "Richard", LastName = "Linklater" },
                new Director { DirectorID = 41, FirstName = "Steven", LastName = "Soderbergh" },
                new Director { DirectorID = 42, FirstName = "James", LastName = "Wan" },
                new Director { DirectorID = 43, FirstName = "M. Night", LastName = "Shyamalan" },
                new Director { DirectorID = 44, FirstName = "Bong", LastName = "Joon-ho" },
                new Director { DirectorID = 45, FirstName = "Terry", LastName = "Gilliam" },
                new Director { DirectorID = 46, FirstName = "Richard", LastName = "Curtis" },
                new Director { DirectorID = 47, FirstName = "Ron", LastName = "Howard" },
                new Director { DirectorID = 48, FirstName = "Oliver", LastName = "Stone" },
                new Director { DirectorID = 49, FirstName = "Sam", LastName = "Mendes" },
                new Director { DirectorID = 50, FirstName = "Robert", LastName = "Rodriguez" },
                new Director { DirectorID = 51, FirstName = "John", LastName = "Hughes" },
                new Director { DirectorID = 52, FirstName = "Paul", LastName = "Verhoeven" },
                new Director { DirectorID = 53, FirstName = "Michael", LastName = "Mann" },
                new Director { DirectorID = 54, FirstName = "Rian", LastName = "Johnson" },
                new Director { DirectorID = 55, FirstName = "Bryan", LastName = "Singer" },
                new Director { DirectorID = 56, FirstName = "Lenny", LastName = "Abrahamson" },
                new Director { DirectorID = 57, FirstName = "Joe", LastName = "Wright" },
                new Director { DirectorID = 58, FirstName = "Terry", LastName = "Gilliam" },
                new Director { DirectorID = 59, FirstName = "Greta", LastName = "Gerwig" },
                new Director { DirectorID = 60, FirstName = "Ethan", LastName = "Coen" },
                new Director { DirectorID = 61, FirstName = "Joel", LastName = "Coen" },
                new Director { DirectorID = 62, FirstName = "Jason", LastName = "Reitman" },
                new Director { DirectorID = 63, FirstName = "Bryan", LastName = "Singer" },
                new Director { DirectorID = 64, FirstName = "Stephen", LastName = "King" },
                new Director { DirectorID = 65, FirstName = "Guy", LastName = "Ritchie" },
                new Director { DirectorID = 66, FirstName = "Paul", LastName = "Greengrass" },
                new Director { DirectorID = 67, FirstName = "Ron", LastName = "Howard" },
                new Director { DirectorID = 68, FirstName = "John", LastName = "Woo" },
                new Director { DirectorID = 69, FirstName = "Sylvester", LastName = "Stallone" },
                new Director { DirectorID = 70, FirstName = "Stephen", LastName = "Spielberg" },
                new Director { DirectorID = 71, FirstName = "James", LastName = "Cameron" },
                new Director { DirectorID = 72, FirstName = "Ridley", LastName = "Scott" },
                new Director { DirectorID = 73, FirstName = "Peter", LastName = "Jackson" },
                new Director { DirectorID = 74, FirstName = "Tim", LastName = "Burton" },
                new Director { DirectorID = 75, FirstName = "J.J.", LastName = "Abrams" },
                new Director { DirectorID = 76, FirstName = "M. Night", LastName = "Shyamalan" },
                new Director { DirectorID = 77, FirstName = "Ang", LastName = "Lee" },
                new Director { DirectorID = 78, FirstName = "John", LastName = "Hughes" },
                new Director { DirectorID = 79, FirstName = "Greta", LastName = "Gerwig" },
                new Director { DirectorID = 80, FirstName = "Guillermo", LastName = "del Toro" },
                new Director { DirectorID = 81, FirstName = "Martin", LastName = "Scorsese" },
                new Director { DirectorID = 82, FirstName = "Christopher", LastName = "Nolan" },
                new Director { DirectorID = 83, FirstName = "Spike", LastName = "Lee" },
                new Director { DirectorID = 84, FirstName = "Hayao", LastName = "Miyazaki" },
                new Director { DirectorID = 85, FirstName = "Quentin", LastName = "Tarantino" },
                new Director { DirectorID = 86, FirstName = "Alfred", LastName = "Hitchcock" },
                new Director { DirectorID = 87, FirstName = "Wes", LastName = "Anderson" },
                new Director { DirectorID = 88, FirstName = "Stanley", LastName = "Kubrick" },
                new Director { DirectorID = 89, FirstName = "Ridley", LastName = "Scott" },
                new Director { DirectorID = 90, FirstName = "David", LastName = "Fincher" },
                new Director { DirectorID = 91, FirstName = "James", LastName = "Wan" },
                new Director { DirectorID = 92, FirstName = "Danny", LastName = "Boyle" },
                new Director { DirectorID = 93, FirstName = "M. Night", LastName = "Shyamalan" },
                new Director { DirectorID = 94, FirstName = "Terry", LastName = "Gilliam" },
                new Director { DirectorID = 95, FirstName = "Frank", LastName = "Darabont" },
                new Director { DirectorID = 96, FirstName = "Rian", LastName = "Johnson" },
                new Director { DirectorID = 97, FirstName = "Paul", LastName = "Greengrass" },
                new Director { DirectorID = 98, FirstName = "Bryan", LastName = "Singer" },
                new Director { DirectorID = 99, FirstName = "Ron", LastName = "Howard" },
                new Director { DirectorID = 100, FirstName = "Stephen", LastName = "Spielberg" }
            );
            modelBuilder.Entity<MovieType>().HasData(
                new MovieType { MovieTypeID = 1, Type = "2D" },
                new MovieType { MovieTypeID = 2, Type = "3D" },
                new MovieType { MovieTypeID = 3, Type = "IMAX" },
                new MovieType { MovieTypeID = 4, Type = "4DX" },
                new MovieType { MovieTypeID = 5, Type = "ScreenX" },
                new MovieType { MovieTypeID = 6, Type = "D-Box" },
                new MovieType { MovieTypeID = 7, Type = "Dolby Vision" },
                new MovieType { MovieTypeID = 8, Type = "Dolby Atmos" },
                new MovieType { MovieTypeID = 9, Type = "HFR (High Frame Rate)" },
                new MovieType { MovieTypeID = 10, Type = "VR (Virtual Reality)" }
            );




        }








        public static byte[] HexToByteArray(string hex)
        {
            hex = hex.Replace("0x", "");
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return bytes;
        }


        private string ConvertImageToBase64String(string folder, string imageName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string imagePath = Path.Combine(currentDirectory, folder, imageName);




            try
            {
                if (File.Exists(imagePath))
                {
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    return Convert.ToBase64String(imageBytes);
                }
                else
                {
                    Console.WriteLine("Image file not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading image file: {ex.Message}");
                return null;
            }
        }



        private byte[] ConvertImageToByteArray(string folder, string imageName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string imagePath = Path.Combine(currentDirectory, folder, imageName);


            try
            {
                if (File.Exists(imagePath))
                {
                    return File.ReadAllBytes(imagePath);
                }
                else
                {
                    Console.WriteLine("Image file not found.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading image file: {ex.Message}");
                return null;
            }
        }






    }
}