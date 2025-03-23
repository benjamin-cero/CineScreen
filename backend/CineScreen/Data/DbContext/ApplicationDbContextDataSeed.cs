using CineScreen.Data.Models.SharedEnums;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Data.Models.TenantSpecificTables.Auth;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper;
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


namespace CineScreen.Data
{
    partial class ApplicationDbContext
    {


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {

            // Tenants 

            modelBuilder.Entity<Tenant>().HasData(
                  new Tenant { ID = 1,
                      Name = "Cinestar", DatabaseConnection = "db_conn_cinestar", ServerAddress = "192.168.1.1" },
                  new Tenant { ID = 2,
                      Name = "Cineplexx", DatabaseConnection = "db_conn_cineplexx", ServerAddress = "192.168.1.2" }
            );

            // Cities

            modelBuilder.Entity<City>().HasData(
                  new City { ID = 1, Name = "Banja Luka" },
                  new City { ID = 2, Name = "Bihać" },
                  new City { ID = 3, Name = "Bijeljina" },
                  new City { ID = 4, Name = "Bosnaska Krupa" },
                  new City { ID = 5, Name = "Cazin" },
                  new City { ID = 6, Name = "Čapljina" },
                  new City { ID = 7, Name = "Drventa" },
                  new City { ID = 8, Name = "Doboj" },
                  new City { ID = 9, Name = "Goražde" },
                  new City { ID = 10, Name = "Gračanica" },
                  new City { ID = 11, Name = "Gradačac" },
                  new City { ID = 12, Name = "Gradiška" },
                  new City { ID = 13, Name = "Konjic" },
                  new City { ID = 14, Name = "Laktaši" },
                  new City { ID = 15, Name = "Livno" },
                  new City { ID = 16, Name = "Lukavac" },
                  new City { ID = 17, Name = "Ljubuški" },
                  new City { ID = 18, Name = "Mostar" },
                  new City { ID = 19, Name = "Orašje" },
                  new City { ID = 20, Name = "Prijedor" },
                  new City { ID = 21, Name = "Prnjavor" },
                  new City { ID = 22, Name = "Sarajevo" },
                  new City { ID = 23, Name = "Srebrenik" },
                  new City { ID = 24, Name = "Stolac" },
                  new City { ID = 25, Name = "Široki Brijeg" },
                  new City { ID = 26, Name = "Travnik" },
                  new City { ID = 27, Name = "Tuzla" },
                  new City { ID = 28, Name = "Visoko" },
                  new City { ID = 29, Name = "Zavidovići" },
                  new City { ID = 30, Name = "Zenica" },
                  new City { ID = 31, Name = "Zvornik" },
                  new City { ID = 32, Name = "Živinice" },
                  new City { ID = 33, Name = "Donji Vakuf" },
                  new City { ID = 34, Name = "Zavidovići" }
            );


            // Generes
            modelBuilder.Entity<Genre>().HasData(
                new Genre { ID = 1, Name = "Action" },
                new Genre { ID = 2, Name = "Adventure" },
                new Genre { ID = 3, Name = "Drama" },
                new Genre { ID = 4, Name = "Fantasy" },
                new Genre { ID = 5, Name = "Horror" },
                new Genre { ID = 6, Name = "Mystery" },
                new Genre { ID = 7, Name = "Romance" },
                new Genre { ID = 8, Name = "Science Fiction" },
                new Genre { ID = 9, Name = "Sci-Fi" },
                new Genre { ID = 10, Name = "Thriller" },
                new Genre { ID = 11, Name = "Crime" },
                new Genre { ID = 12, Name = "Historical" },
                new Genre { ID = 13, Name = "Superhero" },
                new Genre { ID = 14, Name = "Western" },
                new Genre { ID = 15, Name = "Musical" },
                new Genre { ID = 16, Name = "War" },
                new Genre { ID = 17, Name = "Biographical" },
                new Genre { ID = 18, Name = "Sports" },
                new Genre { ID = 19, Name = "Family" },
                new Genre { ID = 20, Name = "Animation" },
                new Genre { ID = 21, Name = "Documentary" },
                new Genre { ID = 22, Name = "Noir" },
                new Genre { ID = 23, Name = "Fantasy Adventure" },
                new Genre { ID = 24, Name = "Romantic Comedy" },
                new Genre { ID = 25, Name = "Psychological Thriller" },
                new Genre { ID = 26, Name = "Slasher" },
                new Genre { ID = 27, Name = "Parody" },
                new Genre { ID = 28, Name = "Post-Apocalyptic" },
                new Genre { ID = 29, Name = "Found Footage" },
                new Genre { ID = 30, Name = "Martial Arts" },
                new Genre { ID = 31, Name = "Spy" },
                new Genre { ID = 32, Name = "Disaster" },
                new Genre { ID = 33, Name = "Dark Comedy" },
                new Genre { ID = 34, Name = "Teen" },
                new Genre { ID = 35, Name = "Gothic Horror" },
                new Genre { ID = 36, Name = "Cyberpunk" },
                new Genre { ID = 37, Name = "Steampunk" },
                new Genre { ID = 38, Name = "Space Opera" },
                new Genre { ID = 39, Name = "Time Travel" },
                new Genre { ID = 40, Name = "Anime" }
            );

            modelBuilder.Entity<Actor>().HasData(
                new Actor { ID = 1, FirstName = "Auliʻi", LastName = "Cravalho" },
                new Actor { ID = 2, FirstName = "Dwayne", LastName = "Johnson" },
                new Actor { ID = 3, FirstName = "Aaron", LastName = "Pierre" },
                new Actor { ID = 4, FirstName = "Kelvin", LastName = "Harrison Jr." },
                new Actor { ID = 5, FirstName = "Beyoncé", LastName = "" },
                new Actor { ID = 6, FirstName = "Donald", LastName = "Glover" },
                new Actor { ID = 7, FirstName = "Seth", LastName = "Rogen" },
                new Actor { ID = 8, FirstName = "Billy", LastName = "Eichner" },
                new Actor { ID = 9, FirstName = "Anika", LastName = "Noni Rose" },
                new Actor { ID = 10, FirstName = "Mads", LastName = "Mikkelsen" },
                new Actor { ID = 11, FirstName = "Keanu", LastName = "Reeves" },
                new Actor { ID = 12, FirstName = "Jim", LastName = "Carrey" },
                new Actor { ID = 13, FirstName = "Ben", LastName = "Schwartz" },
                new Actor { ID = 14, FirstName = "Brian", LastName = "Cox" },
                new Actor { ID = 15, FirstName = "Gaia", LastName = "Wise" },
                new Actor { ID = 16, FirstName = "Luke", LastName = "Pasqualino" },
                new Actor { ID = 17, FirstName = "Shaun", LastName = "Dooley" },
                new Actor { ID = 18, FirstName = "Miranda", LastName = "Otto" },
                new Actor { ID = 19, FirstName = "Frank", LastName = "Grillo" },
                new Actor { ID = 20, FirstName = "Katrina", LastName = "Law" },
                new Actor { ID = 21, FirstName = "Lou Diamond", LastName = "Phillips" },
                new Actor { ID = 22, FirstName = "Ilfenesh", LastName = "Hadera" },
                new Actor { ID = 23, FirstName = "Kamdynn", LastName = "Gary" },
                new Actor { ID = 24, FirstName = "Aaron", LastName = "Taylor-Johnson" },
                new Actor { ID = 25, FirstName = "Ariana", LastName = "DeBose" },
                new Actor { ID = 26, FirstName = "Fred", LastName = "Hechinger" },
                new Actor { ID = 27, FirstName = "Christopher", LastName = "Abbott" },
                new Actor { ID = 28, FirstName = "Alessandro", LastName = "Nivola" },
                new Actor { ID = 29, FirstName = "Russell", LastName = "Crowe" },
                new Actor { ID = 30, FirstName = "Paul", LastName = "Mescal" },
                new Actor { ID = 31, FirstName = "Connie", LastName = "Nielsen" },
                new Actor { ID = 32, FirstName = "Derek", LastName = "Jacobi" },
                new Actor { ID = 33, FirstName = "Djimon", LastName = "Hounsou" },
                new Actor { ID = 34, FirstName = "Joseph", LastName = "Quinn" },
                new Actor { ID = 35, FirstName = "Denzel", LastName = "Washington" },
                new Actor { ID = 36, FirstName = "Pedro", LastName = "Pascal" },
                new Actor { ID = 37, FirstName = "Jai", LastName = "Courtney" },
                new Actor { ID = 38, FirstName = "Deborah", LastName = "Mailman" },
                new Actor { ID = 39, FirstName = "Jack", LastName = "Thompson" },
                new Actor { ID = 40, FirstName = "Matt", LastName = "Day" },
                new Actor { ID = 41, FirstName = "Geneviève", LastName = "Lemon" },
                new Actor { ID = 42, FirstName = "Celeste", LastName = "Barber" },
                new Actor { ID = 43, FirstName = "Lily", LastName = "LeTorre" },
                new Actor { ID = 44, FirstName = "Ben", LastName = "Wang" },
                new Actor { ID = 45, FirstName = "Ralph", LastName = "Macchio" },
                new Actor { ID = 46, FirstName = "Jackie", LastName = "Chan" },
                new Actor { ID = 47, FirstName = "Joshua", LastName = "Jackson" },
                new Actor { ID = 48, FirstName = "Ming-Na", LastName = "Wen" },
                new Actor { ID = 49, FirstName = "Sadie", LastName = "Stanley" },
                new Actor { ID = 50, FirstName = "Jesse", LastName = "Eisenberg" },
                new Actor { ID = 51, FirstName = "Mark", LastName = "Ruffalo" },
                new Actor { ID = 52, FirstName = "Woody", LastName = "Harrelson" },
                new Actor { ID = 53, FirstName = "Dave", LastName = "Franco" },
                new Actor { ID = 54, FirstName = "Isla", LastName = "Fisher" },
                new Actor { ID = 55, FirstName = "Rosamund", LastName = "Pike" },
                new Actor { ID = 56, FirstName = "Justice", LastName = "Smith" },
                new Actor { ID = 57, FirstName = "Ariana", LastName = "Greenblatt" },
                new Actor { ID = 58, FirstName = "Dominic", LastName = "Sessa" },
                new Actor { ID = 59, FirstName = "Mason", LastName = "Thames" },
                new Actor { ID = 60, FirstName = "Nico", LastName = "Parker" },
                new Actor { ID = 61, FirstName = "Gerard", LastName = "Butler" },
                new Actor { ID = 62, FirstName = "Nick", LastName = "Frost" },
                new Actor { ID = 63, FirstName = "Julian", LastName = "Dennison" },
                new Actor { ID = 64, FirstName = "Gabriel", LastName = "Howell" },
                new Actor { ID = 65, FirstName = "Bronwyn", LastName = "James" },
                new Actor { ID = 66, FirstName = "Jason", LastName = "Momoa" },
                new Actor { ID = 67, FirstName = "Jack", LastName = "Black" },
                new Actor { ID = 68, FirstName = "Danielle", LastName = "Brooks" },
                new Actor { ID = 69, FirstName = "Emma", LastName = "Myers" },
                new Actor { ID = 70, FirstName = "Matt", LastName = "Berry" },
                new Actor { ID = 71, FirstName = "Tom", LastName = "Cruise" },
                new Actor { ID = 72, FirstName = "Kelly", LastName = "McGillis" },
                new Actor { ID = 73, FirstName = "Val", LastName = "Kilmer" },
                new Actor { ID = 74, FirstName = "Anthony", LastName = "Edwards" },
                new Actor { ID = 75, FirstName = "Tom", LastName = "Skerritt" },
                new Actor { ID = 76, FirstName = "Michael", LastName = "Ironside" },
                new Actor { ID = 77, FirstName = "Meg", LastName = "Ryan" },
                new Actor { ID = 78, FirstName = "Roy", LastName = "Scheider" },
                new Actor { ID = 79, FirstName = "Robert", LastName = "Shaw" },
                new Actor { ID = 80, FirstName = "Richard", LastName = "Dreyfuss" },
                new Actor { ID = 81, FirstName = "Lorraine", LastName = "Gary" },
                new Actor { ID = 82, FirstName = "Murray", LastName = "Hamilton" },
                new Actor { ID = 83, FirstName = "Rumi", LastName = "Hiiragi" },
                new Actor { ID = 84, FirstName = "Miyu", LastName = "Irino" },
                new Actor { ID = 85, FirstName = "Bunta", LastName = "Sugawara" },
                new Actor { ID = 86, FirstName = "Mari", LastName = "Natsuki" },
                new Actor { ID = 87, FirstName = "Takehiko", LastName = "Ono" },
                new Actor { ID = 88, FirstName = "Tobey", LastName = "Maguire" },
                new Actor { ID = 89, FirstName = "Willem", LastName = "Dafoe" },
                new Actor { ID = 90, FirstName = "Kirsten", LastName = "Dunst" },
                new Actor { ID = 91, FirstName = "James", LastName = "Franco" },
                new Actor { ID = 92, FirstName = "Cliff", LastName = "Robertson" },
                new Actor { ID = 93, FirstName = "Rosemary", LastName = "Harris" }
            );



            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { ID = 1, Name = "Sultan" },//kola
                new Manufacturer { ID = 2, Name = "Orville Redenbacher" },//kokice
                new Manufacturer { ID = 3, Name = "Nathan's Famous" },//hotdogovi
                new Manufacturer { ID = 4, Name = "Tostitos" },//nachos
                new Manufacturer { ID = 5, Name = "Chio" },//cips
                new Manufacturer { ID = 6, Name = "Kühne" },//pomfrit
                new Manufacturer { ID = 7, Name = "The Hershey Company" }


            );

            modelBuilder.Entity<Menu>().HasData(
                new Menu { ID = 1, TenantId = 1,
                    Name = "Popcorn S", Price = 3, Image = ConvertImageToByteArray("wwwroot", "1. Popcorn S.png") },
                new Menu { ID = 2, TenantId = 1,
                    Name = "Popcorn M", Price = 5, Image = ConvertImageToByteArray("wwwroot", "2. Popcorn M.png")},
                new Menu { ID = 3, TenantId = 1,
                    Name = "Popcorn L", Price = 7,Image = ConvertImageToByteArray("wwwroot", "3. Popcorn L.png")},
                new Menu { ID = 4, TenantId = 1,
                    Name = "Nachos", Price = 5, Image = ConvertImageToByteArray("wwwroot", "4. Nachos.png")},
                new Menu { ID = 5, TenantId = 1,
                    Name = "Soda", Price = 3, Image = ConvertImageToByteArray("wwwroot", "5. Soda.png")},
                new Menu { ID = 6, TenantId = 1,
                    Name = "Chips", Price = 4, Image = ConvertImageToByteArray("wwwroot", "6. Chips.png")},
                new Menu { ID = 7, TenantId = 1,
                    Name = "Hot dog", Price = 5, Image = ConvertImageToByteArray("wwwroot", "7. Hot dog.png")},
                new Menu { ID = 8, TenantId = 1,
                    Name = "French fries", Price = 4, Image = ConvertImageToByteArray("wwwroot", "8. French fries.png")},
                new Menu { ID = 9, TenantId = 1,
                    Name = "Nachos + Soda", Price = 7, Image = ConvertImageToByteArray("wwwroot", "9. Nachos + Soda.png")},
                new Menu { ID = 10, TenantId = 1,
                    Name = "Popcorn L + Soda", Price = 9, Image = ConvertImageToByteArray("wwwroot", "10. Popcorn L + Soda.png")},
                new Menu { ID = 11, TenantId = 1,
                    Name = "Chips + Soda", Price = 6, Image = ConvertImageToByteArray("wwwroot", "11. Chips + Soda.png")},
                new Menu { ID = 12, TenantId = 1,
                    Name = "French fries + Soda", Price = 7, Image = ConvertImageToByteArray("wwwroot", "12. French fries + Soda.png")},
                new Menu { ID = 13, TenantId = 1,
                    Name = "Hot dog + Soda", Price = 7, Image = ConvertImageToByteArray("wwwroot", "13. Hot dog + Soda.png")},
                new Menu { ID = 14, TenantId = 1,
                    Name = "Hershey's chocolate bar", Price = 3, Image = ConvertImageToByteArray("wwwroot", "14. Hershey's Chocholate bar.png")}
            );
            modelBuilder.Entity<MenuManufacturer>().HasData(
                new MenuManufacturer { ID = 1,  TenantId = 1, MenuID = 1 , ManufacturerID = 2},
                new MenuManufacturer { ID = 2,  TenantId = 1, MenuID = 2 , ManufacturerID = 2},
                new MenuManufacturer { ID = 3,  TenantId = 1, MenuID = 3 , ManufacturerID = 2},
                new MenuManufacturer { ID = 4,  TenantId = 1, MenuID = 3 , ManufacturerID = 4},
                new MenuManufacturer { ID = 5,  TenantId = 1, MenuID = 5 , ManufacturerID = 1},
                new MenuManufacturer { ID = 6,  TenantId = 1, MenuID = 6 , ManufacturerID = 5},
                new MenuManufacturer { ID = 7,  TenantId = 1, MenuID = 7 , ManufacturerID = 3},
                new MenuManufacturer { ID = 8,  TenantId = 1, MenuID = 8 , ManufacturerID = 6},
                new MenuManufacturer { ID = 9,  TenantId = 1, MenuID = 9 , ManufacturerID = 4},
                new MenuManufacturer { ID = 10, TenantId = 1,  MenuID = 9 , ManufacturerID = 1},
                new MenuManufacturer { ID = 11, TenantId = 1,  MenuID = 10 , ManufacturerID = 2},
                new MenuManufacturer { ID = 12, TenantId = 1,  MenuID = 10 , ManufacturerID = 1},
                new MenuManufacturer { ID = 13, TenantId = 1,  MenuID = 11 , ManufacturerID = 1},
                new MenuManufacturer { ID = 14, TenantId = 1,  MenuID = 11 , ManufacturerID = 5},
                new MenuManufacturer { ID = 15, TenantId = 1,  MenuID = 12 , ManufacturerID = 1},
                new MenuManufacturer { ID = 16, TenantId = 1,  MenuID = 12 , ManufacturerID = 6},
                new MenuManufacturer { ID = 17, TenantId = 1,  MenuID = 13 , ManufacturerID = 1},
                new MenuManufacturer { ID = 18, TenantId = 1,  MenuID = 13 , ManufacturerID = 3},
                new MenuManufacturer { ID = 19, TenantId = 1,  MenuID = 14 , ManufacturerID = 7}

            );




            modelBuilder.Entity<ProductionHouse>().HasData(
              
               new ProductionHouse { ID = 1, Name = "Walt Disney Studios" },
               new ProductionHouse { ID = 2, Name = "Paramount Pictures" },
               new ProductionHouse { ID = 3, Name = "Blur Studio" },
               new ProductionHouse { ID = 4, Name = "Sega Sammy Holdings" },
               new ProductionHouse { ID = 5, Name = "Marza Animation Planet" },
               new ProductionHouse { ID = 6, Name = "New Line Cinema" },
               new ProductionHouse { ID = 7, Name = "Warner Bros. Animation" },
               new ProductionHouse { ID = 8, Name = "Briarcliff Entertainment" },
               new ProductionHouse { ID = 9, Name = "Sony Pictures" },
               new ProductionHouse { ID = 10, Name = "Marvel Entertainment" },
               new ProductionHouse { ID = 11, Name = "Universal Pictures" },
               new ProductionHouse { ID = 12, Name = "StudioCanal" },
               new ProductionHouse { ID = 13, Name = "Screen Australia" },
               new ProductionHouse { ID = 14, Name = "ScreenWest" },
               new ProductionHouse { ID = 15, Name = "Lotterywest" },
               new ProductionHouse { ID = 16, Name = "Lionsgate" },
               new ProductionHouse { ID = 17, Name = "Studio Ghibli" },
               new ProductionHouse { ID = 18, Name = "Tokuma Shoten" },
               new ProductionHouse { ID = 19, Name = "Nippon Television Network" },
               new ProductionHouse { ID = 20, Name = "Dentsu" },
               new ProductionHouse { ID = 21, Name = "Columbia Pictures" }

            );
            modelBuilder.Entity<Director>().HasData(
                new Director { ID = 1, FirstName = "Steven", LastName = "Spielberg" },
                new Director { ID = 2, FirstName = "David", LastName = "Derrick Jr." },
                new Director { ID = 3, FirstName = "Jason", LastName = "Hand" },
                new Director { ID = 4, FirstName = "Dana Ledoux", LastName = "Miller" },
                new Director { ID = 5, FirstName = "Barry", LastName = "Jenkins" },
                new Director { ID = 6, FirstName = "Jeff", LastName = "Fowler" },
                new Director { ID = 7, FirstName = "Kenji", LastName = "Kamiyama" },
                new Director { ID = 8, FirstName = "Steven C.", LastName = "Miller" },
                new Director { ID = 9, FirstName = "J.C.", LastName = "Chandor" },
                new Director { ID = 10, FirstName = "Ridley", LastName = "Scott" },
                new Director { ID = 11, FirstName = "John", LastName = "Sheedy" },
                new Director { ID = 12, FirstName = "Jonathan", LastName = "Entwistle" },
                new Director { ID = 13, FirstName = "Ruben", LastName = "Fleischer" },
                new Director { ID = 14, FirstName = "Dean", LastName = "DeBlois" },
                new Director { ID = 15, FirstName = "Jared", LastName = "Hess" },
                new Director { ID = 16, FirstName = "Tony", LastName = "Scott" },
                new Director { ID = 17, FirstName = "Hayao", LastName = "Miyazaki" },
                new Director { ID = 18, FirstName = "Sam", LastName = "Raimi" }
            );
            modelBuilder.Entity<MovieType>().HasData(
                new MovieType { ID = 1, Type = "2D" },
                new MovieType { ID = 2, Type = "3D" },
                new MovieType { ID = 3, Type = "IMAX" },
                new MovieType { ID = 4, Type = "4DX" },
                new MovieType { ID = 5, Type = "ScreenX" },
                new MovieType { ID = 6, Type = "D-Box" },
                new MovieType { ID = 7, Type = "Dolby Vision" },
                new MovieType { ID = 8, Type = "Dolby Atmos" },
                new MovieType { ID = 9, Type = "HFR (High Frame Rate)" },
                new MovieType { ID = 10, Type = "VR (Virtual Reality)" }
            );


            modelBuilder.Entity<Movie>().HasData(
                new Movie { ID = 1, Title = "Moana 2",ReleaseDate = new DateTime(2024,11,27,0,0,0), Description = "Moana, Maui, Pua, and Heihei are back in a Disney sequel that takes the gang to uncharted waters. After receiving an unexpected call from her wayfinding ancestors, Moana must journey to the far seas of Oceania for an adventure unlike anything she’s ever faced.",Duration = 100,Poster = ConvertImageToByteArray("wwwroot", "1. Moana 2.jpg"), Trailer = "https://www.youtube.com/watch?v=hDZ7y8RP5HE&t=1s", Status = Status.Active },
               

                new Movie { ID = 2, Title = "Sonic the Hedgehog 3", ReleaseDate = new DateTime(2024, 12, 20, 0, 0, 0), Description = "Sonic, Knuckles, and Tails reunite against a powerful new adversary, Shadow, a mysterious villain with powers unlike anything they have faced before. With their abilities outmatched in every way, Team Sonic must seek out an unlikely alliance in hopes of stopping Shadow and protecting the planet.", Duration = 109, Poster = ConvertImageToByteArray("wwwroot", "3. Sonic 3.png"), Trailer = "https://www.youtube.com/watch?v=qSu6i2iFMO0", Status = Status.Active },
                
               
                new Movie
                {
                    ID = 3,
                    Title = "Kraven the Hunter",
                    ReleaseDate = new DateTime(2024, 12, 13, 0, 0, 0),
                    Description = "The film follows Sergei Kravinoff (Kraven), a skilled big-game hunter, portrayed as an antihero rather than a villain. The story explores his traumatic childhood, his relationship with his father (played by Russell Crowe), and his quest for vengeance. The movie brings a darker and more complex version of Kraven, adding depth to his character as he navigates his moral code and his ambition to become the world's greatest hunter.",
                    Duration = 120,
                    Poster = ConvertImageToByteArray("wwwroot", "6. Kraven the Hunter.jpg"),
                    Trailer = "https://www.youtube.com/watch?v=I8gFw4-2RBM",
                    Status = Status.Active
                },
               
            
                new Movie
                {
                    ID = 4,
                    Title = "Karate Kid: Legends",
                    ReleaseDate = new DateTime(2025, 5, 30, 0, 0, 0),
                    Description = "Karate Kid: Legends follows the story of Li Fong, a Chinese teenager who moves to Brooklyn anddiscovers his love for martial arts, blending kung fu and karate. As Li adjusts to his new life, he meetskey figures such as Daniel LaRusso (Ralph Macchio) and Mr. Han (Jackie Chan), who guide him on his martialarts journey. Set after the events of Cobra Kai, the movie will tie together elements from both the KarateKid movies and the popular Cobra Kai series, introducing a new protagonist while celebrating the franchise' legacy.",
                    Duration = 109,
                    Poster = ConvertImageToByteArray("wwwroot", "9. Karate Kid Legends.png"),
                    Trailer = null, // No trailer provided
                    Status = Status.Upcoming
                },
               
                new Movie
                {
                    ID = 5,
                    Title = "How to Train Your Dragon",
                    ReleaseDate = new DateTime(2025, 6, 13, 0, 0, 0),
                    Description = "This live-action adaptation of the original How to Train Your Dragon film will follow Hiccup, the son of a Viking chief, who forms a unique bond with Toothless, a dragon. In a world where dragons are feared and fought against, Hiccup and Toothless must navigate their friendship and face challenges together. The film promises a mix of emotional depth and stunning visual effects as it brings the beloved characters to life in a new format.",
                    Duration = 92,
                    Poster = ConvertImageToByteArray("wwwroot", "11. How to Train Your Dragon.png"),
                    Trailer = null, // No trailer provided
                    Status = Status.Upcoming
                },
                new Movie
                {
                    ID = 6,
                    Title = "A Minecraft Movie",
                    ReleaseDate = new DateTime(2025, 4, 4, 0, 0, 0),
                    Description = "In this live-action adaptation, a group of adventurers is transported into the blocky world of Minecraft, where they must join forces to stop the destructive Ender Dragon threatening the Overworld. With the help of iconic Minecraft creatures, including Steve, the characters must navigate the dangers of the game world. The film blends action, humor, and a sense of adventure as humans adjust to their new environment​.",
                    Duration = 98,
                    Poster = ConvertImageToByteArray("wwwroot", "12. A Minecraft Movie.jpg"),
                    Trailer = "https://www.youtube.com/watch?v=wJO_vIDZn-I",
                    Status = Status.Active
                },
              

                new Movie
                {
                    ID = 7,
                    Title = "Jaws",
                    ReleaseDate = new DateTime(1975, 6, 20, 0, 0, 0),
                    Description = "Set on the fictional island of Amity, Jaws follows Chief Martin Brody as he investigates a series of mysterious shark attacks that threaten the summer tourist season. With the help of marine biologist Matt Hooper and professional shark hunter Quint, Brody must confront the deadly creature lurking in the waters. As the trio hunts the shark, they face escalating danger, and Brody must confront his own fears to protect the town and his family.",
                    Duration = 124,
                    Poster = ConvertImageToByteArray("wwwroot", "14. Jaws.png"),
                    Trailer = "https://www.youtube.com/watch?v=U1fu_sA7XhE",
                    Status = Status.Classic
                },
                new Movie
                {
                    ID = 8,
                    Title = "Spirited Away",
                    ReleaseDate = new DateTime(2001, 7, 20, 0, 0, 0),
                    Description = "Spirited Away follows Chihiro, a young girl who, while on her way to her new home, stumbles upon a mysterious, seemingly abandoned theme park. As her parents are transformed into pigs, Chihiro is forced to work at a bathhouse run by spirits and strange creatures. She befriends Haku, a mysterious boy, and with his help, attempts to find a way to rescue her parents and return home. The film explores themes of personal growth, environmentalism, and the importance of memory.",
                    Duration = 125,
                    Poster = ConvertImageToByteArray("wwwroot", "15. Spirited Away.png"),
                    Trailer = "https://www.youtube.com/watch?v=ByXuk9QqQkk",
                    Status = Status.Classic

                },
                new Movie
                {
                    ID = 9,
                    Title = "Spider-Man",
                    ReleaseDate = new DateTime(2002, 5, 3, 0, 0, 0),
                    Description = "The film follows Peter Parker, a high school student who gains spider-like abilities after being bitten by a genetically altered spider. As Peter struggles with his newfound powers, he must balance his life as a student and superhero while facing the villainous Green Goblin, whose true identity is tied to Peter’s best friend Harry's father, Norman Osborn. The movie explores themes of responsibility, love, and loss, with Peter learning that with great power comes great responsibility.",
                    Duration = 121,
                    Poster = ConvertImageToByteArray("wwwroot", "16. Spider-Man.jpg"),
                    Trailer = "https://www.youtube.com/watch?v=t06RUxPbp_c",
                    Status = Status.Classic

                }

            );



            modelBuilder.Entity<MovieActor>().HasData(
            // Moana 2
            new MovieActor { ID = 1, ActorID = 1, MovieID = 1 },  // Auli'i Cravalho
            new MovieActor { ID = 2, ActorID = 2, MovieID = 1 },  // Dwayne Johnson

            // Sonic the Hedgehog 3
            new MovieActor { ID = 3, ActorID = 11, MovieID = 2 }, // Keanu Reeves
            new MovieActor { ID = 4, ActorID = 12, MovieID = 2 }, // Jim Carrey
            new MovieActor { ID = 5, ActorID = 13, MovieID = 2 }, // Ben Schwartz

            // Kraven the Hunter
            new MovieActor { ID = 6, ActorID = 24, MovieID = 3 }, // Aaron Taylor-Johnson
            new MovieActor { ID = 7, ActorID = 25, MovieID = 3 }, // Ariana DeBose
            new MovieActor { ID = 8, ActorID = 26, MovieID = 3 }, // Fred Hechinger
            new MovieActor { ID = 9, ActorID = 27, MovieID = 3 }, // Christopher Abbott
            new MovieActor { ID = 10, ActorID = 28, MovieID = 3 }, // Alessandro Nivola
            new MovieActor { ID = 11, ActorID = 29, MovieID = 3 }, // Russell Crowe

            // Karate Kid: Legends
            new MovieActor { ID = 12, ActorID = 44, MovieID = 4 }, // Ben Wang
            new MovieActor { ID = 13, ActorID = 45, MovieID = 4 }, // Ralph Macchio
            new MovieActor { ID = 14, ActorID = 46, MovieID = 4 }, // Jackie Chan
            new MovieActor { ID = 15, ActorID = 47, MovieID = 4 }, // Joshua Jackson
            new MovieActor { ID = 16, ActorID = 48, MovieID = 4 }, // Ming-Na Wen
            new MovieActor { ID = 17, ActorID = 49, MovieID = 4 }, // Sadie Stanley

            // How to Train Your Dragon
            new MovieActor { ID = 18, ActorID = 59, MovieID = 5 }, // Mason Thames
            new MovieActor { ID = 19, ActorID = 60, MovieID = 5 }, // Nico Parker
            new MovieActor { ID = 20, ActorID = 61, MovieID = 5 }, // Gerard Butler
            new MovieActor { ID = 21, ActorID = 62, MovieID = 5 }, // Nick Frost
            new MovieActor { ID = 22, ActorID = 63, MovieID = 5 }, // Julian Dennison
            new MovieActor { ID = 23, ActorID = 64, MovieID = 5 }, // Gabriel Howell
            new MovieActor { ID = 24, ActorID = 65, MovieID = 5 }, // Bronwyn James

            // A Minecraft Movie
            new MovieActor { ID = 25, ActorID = 66, MovieID = 6 }, // Jason Momoa
            new MovieActor { ID = 26, ActorID = 67, MovieID = 6 }, // Jack Black
            new MovieActor { ID = 27, ActorID = 68, MovieID = 6 }, // Danielle Brooks
            new MovieActor { ID = 28, ActorID = 69, MovieID = 6 }, // Emma Myers
            new MovieActor { ID = 29, ActorID = 70, MovieID = 6 }, // Matt Berry

            // Jaws
            new MovieActor { ID = 30, ActorID = 78, MovieID = 7 }, // Roy Scheider
            new MovieActor { ID = 31, ActorID = 79, MovieID = 7 }, // Robert Shaw
            new MovieActor { ID = 32, ActorID = 80, MovieID = 7 }, // Richard Dreyfuss
            new MovieActor { ID = 33, ActorID = 81, MovieID = 7 }, // Lorraine Gary
            new MovieActor { ID = 34, ActorID = 82, MovieID = 7 }, // Murray Hamilton

            // Spirited Away
            new MovieActor { ID = 35, ActorID = 83, MovieID = 8 }, // Rumi Hiiragi
            new MovieActor { ID = 36, ActorID = 84, MovieID = 8 }, // Miyu Irino
            new MovieActor { ID = 37, ActorID = 85, MovieID = 8 }, // Bunta Sugawara
            new MovieActor { ID = 38, ActorID = 86, MovieID = 8 }, // Mari Natsuki
            new MovieActor { ID = 39, ActorID = 87, MovieID = 8 }, // Takehiko Ono

            // Spider-Man
            new MovieActor { ID = 40, ActorID = 88, MovieID = 9 }, // Tobey Maguire
            new MovieActor { ID = 41, ActorID = 89, MovieID = 9 }, // Willem Dafoe
            new MovieActor { ID = 42, ActorID = 90, MovieID = 9 }, // Kirsten Dunst
            new MovieActor { ID = 43, ActorID = 91, MovieID = 9 }, // James Franco
            new MovieActor { ID = 44, ActorID = 92, MovieID = 9 }, // Cliff Robertson
            new MovieActor { ID = 45, ActorID = 93, MovieID = 9 }  // Rosemary Harris
        );


            modelBuilder.Entity<MovieProductionHouse>().HasData(
              new MovieProductionHouse { ID = 1, MovieID = 1, ProductionHouseID = 1 },  // Moana 2: Walt Disney Studios
              new MovieProductionHouse { ID = 2, MovieID = 2, ProductionHouseID = 2 },  // Sonic the Hedgehog 3: Paramount Pictures
              new MovieProductionHouse { ID = 3, MovieID = 2, ProductionHouseID = 3 },  // Sonic the Hedgehog 3: Blur Studio
              new MovieProductionHouse { ID = 4, MovieID = 2, ProductionHouseID = 4 },  // Sonic the Hedgehog 3: Sega Sammy Holdings
              new MovieProductionHouse { ID = 5, MovieID = 2, ProductionHouseID = 5 },  // Sonic the Hedgehog 3: Marza Animation Planet
              new MovieProductionHouse { ID = 6, MovieID = 3, ProductionHouseID = 9 },  // Kraven the Hunter: Sony Pictures
              new MovieProductionHouse { ID = 7, MovieID = 3, ProductionHouseID = 10 }, // Kraven the Hunter: Marvel Entertainment
              new MovieProductionHouse { ID = 8, MovieID = 4, ProductionHouseID = 9 },  // Karate Kid: Legends: Sony Pictures
              new MovieProductionHouse { ID = 9, MovieID = 5, ProductionHouseID = 11 }, // How to Train Your Dragon: Universal Pictures
              new MovieProductionHouse { ID = 10, MovieID = 6, ProductionHouseID = 7 }, // A Minecraft Movie: Warner Bros.
              new MovieProductionHouse { ID = 11, MovieID = 7, ProductionHouseID = 11 }, // Jaws: Universal Pictures
              new MovieProductionHouse { ID = 12, MovieID = 8, ProductionHouseID = 17 }, // Spirited Away: Studio Ghibli
              new MovieProductionHouse { ID = 13, MovieID = 8, ProductionHouseID = 18 }, // Spirited Away: Tokuma Shoten
              new MovieProductionHouse { ID = 14, MovieID = 8, ProductionHouseID = 19 }, // Spirited Away: Nippon Television Network
              new MovieProductionHouse { ID = 15, MovieID = 8, ProductionHouseID = 20 }, // Spirited Away: Dentsu
              new MovieProductionHouse { ID = 16, MovieID = 9, ProductionHouseID = 9 },  // Spider-Man: Sony Pictures
              new MovieProductionHouse { ID = 17, MovieID = 9, ProductionHouseID = 21 }, // Spider-Man: Columbia Pictures
              new MovieProductionHouse { ID = 18, MovieID = 9, ProductionHouseID = 10 }  // Spider-Man: Marvel Entertainment
            );

            modelBuilder.Entity<MovieDirector>().HasData(
              new MovieDirector { ID = 1, DirectorID = 1, MovieID = 7 },  // Steven Spielberg -> Jaws
              new MovieDirector { ID = 2, DirectorID = 2, MovieID = 1 },  // David Derrick Jr. -> Moana 2
              new MovieDirector { ID = 3, DirectorID = 3, MovieID = 1 },  // Jason Hand -> Moana 2
              new MovieDirector { ID = 4, DirectorID = 4, MovieID = 1 },  // Dana Ledoux Miller -> Moana 2
              new MovieDirector { ID = 5, DirectorID = 6, MovieID = 2 },  // Jeff Fowler -> Sonic the Hedgehog 3
              new MovieDirector { ID = 6, DirectorID = 9, MovieID = 3 },  // J.C. Chandor -> Kraven the Hunter
              new MovieDirector { ID = 7, DirectorID = 12, MovieID = 4 }, // Jonathan Entwistle -> Karate Kid
              new MovieDirector { ID = 8, DirectorID = 14, MovieID = 5 }, // Dean DeBlois -> How to Train Your Dragon
              new MovieDirector { ID = 9, DirectorID = 15, MovieID = 6 }, // Jared Hess -> A Minecraft Movie
              new MovieDirector { ID = 10, DirectorID = 17, MovieID = 8 }, // Hayao Miyazaki -> Spirited Away
              new MovieDirector { ID = 11, DirectorID = 18, MovieID = 9 }  // Sam Raimi -> Spider-Mand
            );


            modelBuilder.Entity<CinemaHall>().HasData(
                new CinemaHall { ID = 1, TenantId = 1, Capacity = 60, Name = "Hall 1" },
                new CinemaHall { ID = 2, TenantId = 1, Capacity = 60, Name = "Hall 2" },
                new CinemaHall { ID = 3, TenantId = 1, Capacity = 60, Name = "Hall 3" }
            );

            modelBuilder.Entity<Seat>().HasData(
                new Seat { ID = 1, TenantId = 1 , CinemaHallID = 1, SeatNumber = "A1", SeatType = SeatType.Regular },
                new Seat { ID = 2, TenantId = 1 , CinemaHallID = 1, SeatNumber = "A2", SeatType = SeatType.Regular },
                new Seat { ID = 3, TenantId = 1 , CinemaHallID = 1, SeatNumber = "A3", SeatType = SeatType.Regular },
                new Seat { ID = 4, TenantId = 1 , CinemaHallID = 1, SeatNumber = "A4", SeatType = SeatType.Regular },
                new Seat { ID = 5, TenantId = 1 , CinemaHallID = 1, SeatNumber = "A5", SeatType = SeatType.Regular },
                new Seat { ID = 6, TenantId = 1 , CinemaHallID = 1, SeatNumber = "A6", SeatType = SeatType.Regular },
                new Seat { ID = 7, TenantId = 1 , CinemaHallID = 1, SeatNumber = "A7", SeatType = SeatType.Regular },
                new Seat { ID = 8, TenantId = 1 , CinemaHallID = 1, SeatNumber = "A8", SeatType = SeatType.Regular },
                new Seat { ID = 9, TenantId = 1 , CinemaHallID = 1, SeatNumber = "A9", SeatType = SeatType.Regular },
                new Seat { ID = 10, TenantId = 1,CinemaHallID = 1, SeatNumber = "A10", SeatType = SeatType.Regular },
                                  
                new Seat { ID = 11, TenantId = 1,CinemaHallID = 1, SeatNumber = "W1", SeatType = SeatType.Wheelchair },
                new Seat { ID = 12, TenantId = 1,CinemaHallID = 1, SeatNumber = "W2", SeatType = SeatType.Wheelchair },
                new Seat { ID = 13, TenantId = 1,CinemaHallID = 1, SeatNumber = "B3", SeatType = SeatType.Regular },
                new Seat { ID = 14, TenantId = 1,CinemaHallID = 1, SeatNumber = "B4", SeatType = SeatType.Regular },
                new Seat { ID = 15, TenantId = 1,CinemaHallID = 1, SeatNumber = "B5", SeatType = SeatType.Regular },
                new Seat { ID = 16, TenantId = 1,CinemaHallID = 1, SeatNumber = "B6", SeatType = SeatType.Regular },
                new Seat { ID = 17, TenantId = 1,CinemaHallID = 1, SeatNumber = "B7", SeatType = SeatType.Regular },
                new Seat { ID = 18, TenantId = 1,CinemaHallID = 1, SeatNumber = "B8", SeatType = SeatType.Regular },
                new Seat { ID = 19, TenantId = 1,CinemaHallID = 1, SeatNumber = "B9", SeatType = SeatType.Regular },
                new Seat { ID = 20, TenantId = 1,CinemaHallID = 1, SeatNumber = "B10", SeatType = SeatType.Regular },
                                    
                new Seat { ID = 21, TenantId = 1,CinemaHallID = 1, SeatNumber = "C1", SeatType = SeatType.Regular },
                new Seat { ID = 22, TenantId = 1,CinemaHallID = 1, SeatNumber = "C2", SeatType = SeatType.Regular },
                new Seat { ID = 23, TenantId = 1,CinemaHallID = 1, SeatNumber = "C3", SeatType = SeatType.Regular },
                new Seat { ID = 24, TenantId = 1,CinemaHallID = 1, SeatNumber = "L1", SeatType = SeatType.Love  },
                new Seat { ID = 25, TenantId = 1,CinemaHallID = 1, SeatNumber = "L2", SeatType = SeatType.Love  },
                new Seat { ID = 26, TenantId = 1,CinemaHallID = 1, SeatNumber = "C6", SeatType = SeatType.Love  },
                new Seat { ID = 27, TenantId = 1,CinemaHallID = 1, SeatNumber = "C7", SeatType = SeatType.Love  },
                new Seat { ID = 28, TenantId = 1,CinemaHallID = 1, SeatNumber = "C8", SeatType = SeatType.Love  },
                new Seat { ID = 29, TenantId = 1,CinemaHallID = 1, SeatNumber = "C9", SeatType = SeatType.Love  },
                new Seat { ID = 30, TenantId = 1,CinemaHallID = 1, SeatNumber = "C10", SeatType = SeatType.Love },
                                
                new Seat { ID = 31, TenantId = 1,CinemaHallID = 1, SeatNumber = "D1", SeatType = SeatType.Regular },
                new Seat { ID = 32, TenantId = 1,CinemaHallID = 1, SeatNumber = "D2", SeatType = SeatType.Regular },
                new Seat { ID = 33, TenantId = 1,CinemaHallID = 1, SeatNumber = "D3", SeatType = SeatType.Regular },
                new Seat { ID = 34, TenantId = 1,CinemaHallID = 1, SeatNumber = "D4", SeatType = SeatType.Regular },
                new Seat { ID = 35, TenantId = 1,CinemaHallID = 1, SeatNumber = "D5", SeatType = SeatType.Regular },
                new Seat { ID = 36, TenantId = 1,CinemaHallID = 1, SeatNumber = "L3", SeatType = SeatType.Love },
                new Seat { ID = 37, TenantId = 1,CinemaHallID = 1, SeatNumber = "L4", SeatType = SeatType.Love },
                new Seat { ID = 38, TenantId = 1,CinemaHallID = 1, SeatNumber = "D8", SeatType = SeatType.Regular  },
                new Seat { ID = 39, TenantId = 1,CinemaHallID = 1, SeatNumber = "D9", SeatType = SeatType.Regular  },
                new Seat { ID = 40, TenantId = 1,CinemaHallID = 1, SeatNumber = "D10", SeatType = SeatType.Regular },
                                  
                new Seat { ID = 41, TenantId = 1,CinemaHallID = 1, SeatNumber = "E1", SeatType = SeatType.Regular },
                new Seat { ID = 42, TenantId = 1,CinemaHallID = 1, SeatNumber = "E2", SeatType = SeatType.Regular },
                new Seat { ID = 43, TenantId = 1,CinemaHallID = 1, SeatNumber = "E3", SeatType = SeatType.Regular },
                new Seat { ID = 44, TenantId = 1,CinemaHallID = 1, SeatNumber = "E4", SeatType = SeatType.Regular },
                new Seat { ID = 45, TenantId = 1,CinemaHallID = 1, SeatNumber = "E5", SeatType = SeatType.Regular },
                new Seat { ID = 46, TenantId = 1,CinemaHallID = 1, SeatNumber = "E6", SeatType = SeatType.Regular },
                new Seat { ID = 47, TenantId = 1,CinemaHallID = 1, SeatNumber = "E7", SeatType = SeatType.Regular },
                new Seat { ID = 48, TenantId = 1,CinemaHallID = 1, SeatNumber = "E8", SeatType = SeatType.Regular },
                new Seat { ID = 49, TenantId = 1,CinemaHallID = 1, SeatNumber = "E9", SeatType = SeatType.Regular },
                new Seat { ID = 50, TenantId = 1,CinemaHallID = 1, SeatNumber = "E10", SeatType = SeatType.Regular },
                                 
                new Seat { ID = 51, TenantId = 1,CinemaHallID = 1, SeatNumber = "F1", SeatType = SeatType.Regular },
                new Seat { ID = 52, TenantId = 1,CinemaHallID = 1, SeatNumber = "F2", SeatType = SeatType.Regular },
                new Seat { ID = 53, TenantId = 1,CinemaHallID = 1, SeatNumber = "F3", SeatType = SeatType.Regular },
                new Seat { ID = 54, TenantId = 1,CinemaHallID = 1, SeatNumber = "L5", SeatType = SeatType.Love },
                new Seat { ID = 55, TenantId = 1,CinemaHallID = 1, SeatNumber = "L6", SeatType = SeatType.Love },
                new Seat { ID = 56, TenantId = 1,CinemaHallID = 1, SeatNumber = "L7", SeatType = SeatType.Love },
                new Seat { ID = 57, TenantId = 1,CinemaHallID = 1, SeatNumber = "L8", SeatType = SeatType.Love },
                new Seat { ID = 58, TenantId = 1,CinemaHallID = 1, SeatNumber = "F8", SeatType = SeatType.Regular  },
                new Seat { ID = 59, TenantId = 1,CinemaHallID = 1, SeatNumber = "F9", SeatType = SeatType.Regular  },
                new Seat { ID = 60, TenantId = 1,CinemaHallID = 1, SeatNumber = "F10", SeatType = SeatType.Regular },
                                 
                new Seat { ID = 61, TenantId = 1, CinemaHallID = 2, SeatNumber = "A1", SeatType = SeatType.Regular  },
                new Seat { ID = 62, TenantId = 1, CinemaHallID = 2, SeatNumber = "A2", SeatType = SeatType.Regular  },
                new Seat { ID = 63, TenantId = 1, CinemaHallID = 2, SeatNumber = "A3", SeatType = SeatType.Regular  },
                new Seat { ID = 64, TenantId = 1, CinemaHallID = 2, SeatNumber = "A4", SeatType = SeatType.Regular  },
                new Seat { ID = 65, TenantId = 1, CinemaHallID = 2, SeatNumber = "A5", SeatType = SeatType.Regular  },
                new Seat { ID = 66, TenantId = 1, CinemaHallID = 2, SeatNumber = "A6", SeatType = SeatType.Regular  },
                new Seat { ID = 67, TenantId = 1, CinemaHallID = 2, SeatNumber = "A7", SeatType = SeatType.Regular  },
                new Seat { ID = 68, TenantId = 1, CinemaHallID = 2, SeatNumber = "A8", SeatType = SeatType.Regular  },
                new Seat { ID = 69, TenantId = 1, CinemaHallID = 2, SeatNumber = "A9", SeatType = SeatType.Regular  },
                new Seat { ID = 70, TenantId = 1, CinemaHallID = 2, SeatNumber = "A10", SeatType = SeatType.Regular },
                                              
                new Seat { ID = 71, TenantId = 1, CinemaHallID = 2, SeatNumber = "W1", SeatType = SeatType.Wheelchair },
                new Seat { ID = 72, TenantId = 1, CinemaHallID = 2, SeatNumber = "W2", SeatType = SeatType.Wheelchair },
                new Seat { ID = 73, TenantId = 1, CinemaHallID = 2, SeatNumber = "B3", SeatType = SeatType.Regular  },
                new Seat { ID = 74, TenantId = 1, CinemaHallID = 2, SeatNumber = "B4", SeatType = SeatType.Regular  },
                new Seat { ID = 75, TenantId = 1, CinemaHallID = 2, SeatNumber = "B5", SeatType = SeatType.Regular  },
                new Seat { ID = 76, TenantId = 1, CinemaHallID = 2, SeatNumber = "B6", SeatType = SeatType.Regular  },
                new Seat { ID = 77, TenantId = 1, CinemaHallID = 2, SeatNumber = "B7", SeatType = SeatType.Regular  },
                new Seat { ID = 78, TenantId = 1, CinemaHallID = 2, SeatNumber = "B8", SeatType = SeatType.Regular  },
                new Seat { ID = 79, TenantId = 1, CinemaHallID = 2, SeatNumber = "B9", SeatType = SeatType.Regular  },
                new Seat { ID = 80, TenantId = 1, CinemaHallID = 2, SeatNumber = "B10", SeatType = SeatType.Regular },
                                                
                new Seat { ID = 81, TenantId = 1, CinemaHallID = 2, SeatNumber = "C1", SeatType = SeatType.Regular },
                new Seat { ID = 82, TenantId = 1, CinemaHallID = 2, SeatNumber = "C2", SeatType = SeatType.Regular },
                new Seat { ID = 83, TenantId = 1, CinemaHallID = 2, SeatNumber = "C3", SeatType = SeatType.Regular },
                new Seat { ID = 84, TenantId = 1, CinemaHallID = 2, SeatNumber = "L1", SeatType = SeatType.Love },
                new Seat { ID = 85, TenantId = 1, CinemaHallID = 2, SeatNumber = "L2", SeatType = SeatType.Love },
                new Seat { ID = 86, TenantId = 1, CinemaHallID = 2, SeatNumber = "C6", SeatType = SeatType.Love },
                new Seat { ID = 87, TenantId = 1, CinemaHallID = 2, SeatNumber = "C7", SeatType = SeatType.Love },
                new Seat { ID = 88, TenantId = 1, CinemaHallID = 2, SeatNumber = "C8", SeatType = SeatType.Love },
                new Seat { ID = 89, TenantId = 1, CinemaHallID = 2, SeatNumber = "C9", SeatType = SeatType.Love },
                new Seat { ID = 90, TenantId = 1, CinemaHallID = 2, SeatNumber = "C10",SeatType = SeatType.Love },
                                             
                new Seat { ID = 91, TenantId = 1, CinemaHallID = 2, SeatNumber = "D1", SeatType = SeatType.Regular },
                new Seat { ID = 92, TenantId = 1, CinemaHallID = 2, SeatNumber = "D2", SeatType = SeatType.Regular },
                new Seat { ID = 93, TenantId = 1, CinemaHallID = 2, SeatNumber = "D3", SeatType = SeatType.Regular },
                new Seat { ID = 94, TenantId = 1, CinemaHallID = 2, SeatNumber = "D4", SeatType = SeatType.Regular },
                new Seat { ID = 95, TenantId = 1, CinemaHallID = 2, SeatNumber = "D5", SeatType = SeatType.Regular },
                new Seat { ID = 96, TenantId = 1, CinemaHallID = 2, SeatNumber = "L3", SeatType = SeatType.Love },
                new Seat { ID = 97, TenantId = 1, CinemaHallID = 2, SeatNumber = "L4", SeatType = SeatType.Love },
                new Seat { ID = 98, TenantId = 1, CinemaHallID = 2, SeatNumber = "D8", SeatType = SeatType.Regular },
                new Seat { ID = 99, TenantId = 1, CinemaHallID = 2, SeatNumber = "D9", SeatType = SeatType.Regular },
                new Seat { ID = 100, TenantId = 1 , CinemaHallID = 2, SeatNumber = "D10", SeatType = SeatType.Regular },
                                                 
                new Seat { ID = 101, TenantId = 1 , CinemaHallID = 2, SeatNumber = "E1", SeatType = SeatType.Regular  },
                new Seat { ID = 102, TenantId = 1 , CinemaHallID = 2, SeatNumber = "E2", SeatType = SeatType.Regular  },
                new Seat { ID = 103, TenantId = 1 , CinemaHallID = 2, SeatNumber = "E3", SeatType = SeatType.Regular  },
                new Seat { ID = 104, TenantId = 1 , CinemaHallID = 2, SeatNumber = "E4", SeatType = SeatType.Regular  },
                new Seat { ID = 105, TenantId = 1 , CinemaHallID = 2, SeatNumber = "E5", SeatType = SeatType.Regular  },
                new Seat { ID = 106, TenantId = 1 , CinemaHallID = 2, SeatNumber = "E6", SeatType = SeatType.Regular  },
                new Seat { ID = 107, TenantId = 1 , CinemaHallID = 2, SeatNumber = "E7", SeatType = SeatType.Regular  },
                new Seat { ID = 108, TenantId = 1 , CinemaHallID = 2, SeatNumber = "E8", SeatType = SeatType.Regular  },
                new Seat { ID = 109, TenantId = 1 , CinemaHallID = 2, SeatNumber = "E9", SeatType = SeatType.Regular  },
                new Seat { ID = 110, TenantId = 1 , CinemaHallID = 2, SeatNumber = "E10", SeatType = SeatType.Regular },
                                               
                new Seat { ID = 111, TenantId = 1 , CinemaHallID = 2, SeatNumber = "F1", SeatType = SeatType.Regular },
                new Seat { ID = 112, TenantId = 1 , CinemaHallID = 2, SeatNumber = "F2", SeatType = SeatType.Regular },
                new Seat { ID = 113, TenantId = 1 , CinemaHallID = 2, SeatNumber = "F3", SeatType = SeatType.Regular },
                new Seat { ID = 114, TenantId = 1 , CinemaHallID = 2, SeatNumber = "L5", SeatType = SeatType.Love },
                new Seat { ID = 115, TenantId = 1 , CinemaHallID = 2, SeatNumber = "L6", SeatType = SeatType.Love },
                new Seat { ID = 116, TenantId = 1 , CinemaHallID = 2, SeatNumber = "L7", SeatType = SeatType.Love },
                new Seat { ID = 117, TenantId = 1 , CinemaHallID = 2, SeatNumber = "L8", SeatType = SeatType.Love },
                new Seat { ID = 118, TenantId = 1 , CinemaHallID = 2, SeatNumber = "F8", SeatType = SeatType.Regular  },
                new Seat { ID = 119, TenantId = 1 , CinemaHallID = 2, SeatNumber = "F9", SeatType = SeatType.Regular  },
                new Seat { ID = 120, TenantId = 1 , CinemaHallID = 2, SeatNumber = "F10", SeatType = SeatType.Regular },
                                  
                new Seat { ID = 121, TenantId = 1 , CinemaHallID = 3, SeatNumber = "A1", SeatType = SeatType.Regular  },
                new Seat { ID = 122, TenantId = 1 , CinemaHallID = 3, SeatNumber = "A2", SeatType = SeatType.Regular  },
                new Seat { ID = 123, TenantId = 1 , CinemaHallID = 3, SeatNumber = "A3", SeatType = SeatType.Regular  },
                new Seat { ID = 124, TenantId = 1 , CinemaHallID = 3, SeatNumber = "A4", SeatType = SeatType.Regular  },
                new Seat { ID = 125, TenantId = 1 , CinemaHallID = 3, SeatNumber = "A5", SeatType = SeatType.Regular  },
                new Seat { ID = 126, TenantId = 1 , CinemaHallID = 3, SeatNumber = "A6", SeatType = SeatType.Regular  },
                new Seat { ID = 127, TenantId = 1 , CinemaHallID = 3, SeatNumber = "A7", SeatType = SeatType.Regular  },
                new Seat { ID = 128, TenantId = 1 , CinemaHallID = 3, SeatNumber = "A8", SeatType = SeatType.Regular  },
                new Seat { ID = 129, TenantId = 1 , CinemaHallID = 3, SeatNumber = "A9", SeatType = SeatType.Regular  },
                new Seat { ID = 130, TenantId = 1 , CinemaHallID = 3, SeatNumber = "A10", SeatType = SeatType.Regular },
                                                  
                new Seat { ID = 131, TenantId = 1 , CinemaHallID = 3, SeatNumber = "W1", SeatType = SeatType.Wheelchair },
                new Seat { ID = 132, TenantId = 1 , CinemaHallID = 3, SeatNumber = "W2", SeatType = SeatType.Wheelchair },
                new Seat { ID = 133, TenantId = 1 , CinemaHallID = 3, SeatNumber = "B3", SeatType = SeatType.Regular  },
                new Seat { ID = 134, TenantId = 1 , CinemaHallID = 3, SeatNumber = "B4", SeatType = SeatType.Regular  },
                new Seat { ID = 135, TenantId = 1 , CinemaHallID = 3, SeatNumber = "B5", SeatType = SeatType.Regular  },
                new Seat { ID = 136, TenantId = 1 , CinemaHallID = 3, SeatNumber = "B6", SeatType = SeatType.Regular  },
                new Seat { ID = 137, TenantId = 1 , CinemaHallID = 3, SeatNumber = "B7", SeatType = SeatType.Regular  },
                new Seat { ID = 138, TenantId = 1 , CinemaHallID = 3, SeatNumber = "B8", SeatType = SeatType.Regular  },
                new Seat { ID = 139, TenantId = 1 , CinemaHallID = 3, SeatNumber = "B9", SeatType = SeatType.Regular  },
                new Seat { ID = 140, TenantId = 1 , CinemaHallID = 3, SeatNumber = "B10", SeatType = SeatType.Regular },
                                                   
                new Seat { ID = 141, TenantId = 1 , CinemaHallID = 3, SeatNumber = "C1", SeatType = SeatType.Regular },
                new Seat { ID = 142, TenantId = 1 , CinemaHallID = 3, SeatNumber = "C2", SeatType = SeatType.Regular },
                new Seat { ID = 143, TenantId = 1 , CinemaHallID = 3, SeatNumber = "C3", SeatType = SeatType.Regular },
                new Seat { ID = 144, TenantId = 1 , CinemaHallID = 3, SeatNumber = "L1", SeatType = SeatType.Love  },
                new Seat { ID = 145, TenantId = 1 , CinemaHallID = 3, SeatNumber = "L2", SeatType = SeatType.Love  },
                new Seat { ID = 146, TenantId = 1 , CinemaHallID = 3, SeatNumber = "C6", SeatType = SeatType.Love  },
                new Seat { ID = 147, TenantId = 1 , CinemaHallID = 3, SeatNumber = "C7", SeatType = SeatType.Love  },
                new Seat { ID = 148, TenantId = 1 , CinemaHallID = 3, SeatNumber = "C8", SeatType = SeatType.Love  },
                new Seat { ID = 149, TenantId = 1 , CinemaHallID = 3, SeatNumber = "C9", SeatType = SeatType.Love  },
                new Seat { ID = 150, TenantId = 1 , CinemaHallID = 3, SeatNumber = "C10", SeatType = SeatType.Love },
                                                   
                new Seat { ID = 151, TenantId = 1 , CinemaHallID = 3, SeatNumber = "D1", SeatType = SeatType.Regular },
                new Seat { ID = 152, TenantId = 1 , CinemaHallID = 3, SeatNumber = "D2", SeatType = SeatType.Regular },
                new Seat { ID = 153, TenantId = 1 , CinemaHallID = 3, SeatNumber = "D3", SeatType = SeatType.Regular },
                new Seat { ID = 154, TenantId = 1 , CinemaHallID = 3, SeatNumber = "D4", SeatType = SeatType.Regular },
                new Seat { ID = 155, TenantId = 1 , CinemaHallID = 3, SeatNumber = "D5", SeatType = SeatType.Regular },
                new Seat { ID = 156, TenantId = 1 , CinemaHallID = 3, SeatNumber = "L3", SeatType = SeatType.Love },
                new Seat { ID = 157, TenantId = 1 , CinemaHallID = 3, SeatNumber = "L4", SeatType = SeatType.Love },
                new Seat { ID = 158, TenantId = 1 , CinemaHallID = 3, SeatNumber = "D8", SeatType = SeatType.Regular  },
                new Seat { ID = 159, TenantId = 1 , CinemaHallID = 3, SeatNumber = "D9", SeatType = SeatType.Regular  },
                new Seat { ID = 160, TenantId = 1 , CinemaHallID = 3, SeatNumber = "D10", SeatType = SeatType.Regular },
                                                    
                new Seat { ID = 161, TenantId = 1 , CinemaHallID = 3, SeatNumber = "E1", SeatType = SeatType.Regular  },
                new Seat { ID = 162, TenantId = 1 , CinemaHallID = 3, SeatNumber = "E2", SeatType = SeatType.Regular  },
                new Seat { ID = 163, TenantId = 1 , CinemaHallID = 3, SeatNumber = "E3", SeatType = SeatType.Regular  },
                new Seat { ID = 164, TenantId = 1 , CinemaHallID = 3, SeatNumber = "E4", SeatType = SeatType.Regular  },
                new Seat { ID = 165, TenantId = 1 , CinemaHallID = 3, SeatNumber = "E5", SeatType = SeatType.Regular  },
                new Seat { ID = 166, TenantId = 1 , CinemaHallID = 3, SeatNumber = "E6", SeatType = SeatType.Regular  },
                new Seat { ID = 167, TenantId = 1 , CinemaHallID = 3, SeatNumber = "E7", SeatType = SeatType.Regular  },
                new Seat { ID = 168, TenantId = 1 , CinemaHallID = 3, SeatNumber = "E8", SeatType = SeatType.Regular  },
                new Seat { ID = 169, TenantId = 1 , CinemaHallID = 3, SeatNumber = "E9", SeatType = SeatType.Regular  },
                new Seat { ID = 170, TenantId = 1 , CinemaHallID = 3, SeatNumber = "E10", SeatType = SeatType.Regular },
                                                     
                new Seat { ID = 171, TenantId = 1 , CinemaHallID = 3, SeatNumber = "F1", SeatType = SeatType.Regular },
                new Seat { ID = 172, TenantId = 1 , CinemaHallID = 3, SeatNumber = "F2", SeatType = SeatType.Regular },
                new Seat { ID = 173, TenantId = 1 , CinemaHallID = 3, SeatNumber = "F3", SeatType = SeatType.Regular },
                new Seat { ID = 174, TenantId = 1 , CinemaHallID = 3, SeatNumber = "L5", SeatType = SeatType.Love },
                new Seat { ID = 175, TenantId = 1 , CinemaHallID = 3, SeatNumber = "L6", SeatType = SeatType.Love },
                new Seat { ID = 176, TenantId = 1 , CinemaHallID = 3, SeatNumber = "L7", SeatType = SeatType.Love },
                new Seat { ID = 177, TenantId = 1 , CinemaHallID = 3, SeatNumber = "L8", SeatType = SeatType.Love },
                new Seat { ID = 178, TenantId = 1 , CinemaHallID = 3, SeatNumber = "F8", SeatType = SeatType.Regular  },
                new Seat { ID = 179, TenantId = 1 , CinemaHallID = 3, SeatNumber = "F9", SeatType = SeatType.Regular  },
                new Seat { ID = 180, TenantId = 1 , CinemaHallID = 3, SeatNumber = "F10", SeatType = SeatType.Regular }

            );


            

            // 1. Moana 2
            // 2. Sonic 3
            // 3. Kraven
            // 7. Jaws 
            // 8. Spirited
            // 9. Spider-man

            // 1. 2D
            // 2. 3D

            // 16 : 00 
            // 19 : 15
            // 22 : 00


            modelBuilder.Entity<Projection>().HasData(

                // SVE NA DAN 1 FEB 2025

             new Projection {ID = 1, TenantId = 1, // Moana 2 - 17 00 - 3D - SALA 
                 CinemaHallID = 1,
                 MovieID = 1 ,
                 MovieTypeID = 3 ,
                 StartTime = new DateTime(2025,2,1,16,0,0),
                 Price = 7

             },
             new Projection
                 {
                 ID = 2,
                 TenantId = 1, // Sonic - 17 00 - 3D - SALA 2
                 CinemaHallID = 2,
                     MovieID = 2,
                     MovieTypeID = 2,
                     StartTime = new DateTime(2025, 2, 1, 16, 0, 0),
                     Price = 7

                 },
                 new Projection
                 {
                     ID = 3,
                     TenantId = 1, // Kraven - 17 00 - 2D - SALA 3
                     CinemaHallID = 3,
                     MovieID = 3,
                     MovieTypeID = 1,
                     StartTime = new DateTime(2025, 2, 1, 16, 0, 0),
                     Price = 5


                 },
                     new Projection
                     {
                         ID = 4,
                         TenantId = 1, // Kraven - 21 30 - 2D - SALA 1
                         CinemaHallID = 1,
                         MovieID = 3,
                         MovieTypeID = 1,
                         StartTime = new DateTime(2025, 2, 1, 22, 0, 0),
                         Price = 5


                     },
                      new Projection
                      {
                          ID = 5,
                          TenantId = 1, // Jaws - 21 30 - 2D - SALA 2
                          CinemaHallID = 2,
                          MovieID = 7,
                          MovieTypeID = 1,
                          StartTime = new DateTime(2025, 2, 1, 22, 0, 0),
                          Price = 5

                      },
                       new Projection
                       {
                           ID = 6,
                           TenantId = 1, // Spiderman - 21 30 - 2D - SALA 3
                           CinemaHallID = 3,
                           MovieID = 9,
                           MovieTypeID = 1,
                           StartTime = new DateTime(2025, 2, 1, 22, 0, 0),
                           Price = 5

                       },
                          new Projection
                          {
                              ID = 7,
                              TenantId = 1, // Spirited - 19 : 15 - 2D - SALA 1
                              CinemaHallID = 1,
                              MovieID = 8,
                              MovieTypeID = 1,
                              StartTime = new DateTime(2025, 2, 1, 19, 15, 0),
                              Price = 5


                          },
                               new Projection
                               {
                                   ID = 8,
                                   TenantId = 1, // Spirited - 19 : 15 - 2D - SALA 1
                                   CinemaHallID = 1,
                                   MovieID = 8,
                                   MovieTypeID = 1,
                                   StartTime = new DateTime(2025, 2, 1, 19, 15, 0),
                                   Price = 5


                               },
                                       new Projection
                                       {
                                           ID = 9,
                                           TenantId = 1, // Moana - 19 : 15 - 2D - SALA 2
                                           CinemaHallID = 2,
                                           MovieID = 1,
                                           MovieTypeID = 1,
                                           StartTime = new DateTime(2025, 2, 1, 19, 15, 0),
                                           Price= 5

                                       },

                                         // DRUGI DAN 2 FEB 2025

                                         new Projection
                                         {
                                             ID = 10,
                                             TenantId = 1, // Moana SALA 1 3D 16 00
                                             CinemaHallID = 1,
                                             MovieID = 1,
                                             MovieTypeID = 2,
                                             StartTime = new DateTime(2025, 2, 2, 16, 0, 0),
                                             Price = 7

                                         },
                                          new Projection
                                          {
                                              ID = 11,
                                              TenantId = 1, // Sonic SALA 2 3D 16 00
                                              CinemaHallID = 2,
                                              MovieID = 2,
                                              MovieTypeID = 2,
                                              StartTime = new DateTime(2025, 2, 2, 16, 0, 0),
                                              Price = 7

                                          },

                                            new Projection
                                            {
                                                ID = 12,
                                                TenantId = 1, // Kraven SALA 3 2D 16 00
                                                CinemaHallID = 3,
                                                MovieID = 3,
                                                MovieTypeID = 1,
                                                StartTime = new DateTime(2025, 2, 2, 16, 0, 0),
                                                Price = 5

                                            },
                                                  new Projection
                                                  {
                                                      ID = 13,
                                                      TenantId = 1, // Moana SALA 3 2D 19 15
                                                      CinemaHallID = 3,
                                                      MovieID = 1,
                                                      MovieTypeID = 1,
                                                      StartTime = new DateTime(2025, 2, 2, 19, 15, 0),
                                                      Price = 5

                                                  }




               );

            // Benjamin -> Moana 2 -> Sjediste A1 u Sali 1 

            modelBuilder.Entity<Ticket>().HasData(
          new Ticket { ID = 1,TenantId = 1, OrderDate = new DateTime(2025,1,1,16,0,0), ProjectionID = 1, SeatID = 1, MyAppUserID = 3, Paid = true }
            );


            modelBuilder.Entity<Review>().HasData(
          new Review { ID = 1, TenantId = 1, MovieID = 1, ReviewDate =  new DateTime(2025, 2, 2, 20, 0, 0) , Score = 4, Comment = "I really liked the movie but the main villain was a bit disappointing", MyAppUserID = 3 }
            );


            modelBuilder.Entity<Order>().HasData(
          new Order { ID = 1, TenantId = 1, OrderDate = new DateTime(2025, 2, 1, 15, 47, 0), MenuID = 3, Quantity = 1,Paid = true, MyAppUserID = 3}
            );


            // Hasher i salt za password 

            // Generate salt and hash for each user
            var salt1 = PasswordGenerator.GenerateSalt();
            var hash1 = PasswordGenerator.GenerateHash(salt1, "test");

            var salt2 = PasswordGenerator.GenerateSalt();
            var hash2 = PasswordGenerator.GenerateHash(salt2, "test");

            var salt3 = PasswordGenerator.GenerateSalt();
            var hash3 = PasswordGenerator.GenerateHash(salt3, "test");

            var salt4 = PasswordGenerator.GenerateSalt();
            var hash4 = PasswordGenerator.GenerateHash(salt4, "test");

            modelBuilder.Entity<MyAppUser>().HasData(
                new MyAppUser
                {
                    ID = 1,
                    TenantId = 1,
                    FirstName = "Benjamin",
                    LastName = "Cero",
                    Username = "cero",
                    Email = "benjamin.cero@edu.fit.ba",
                    PasswordHash = hash1,
                    PasswordSalt = salt1,
                    IsAdmin = false,
                    IsUser = true
                },
                new MyAppUser
                {
                    ID = 2,
                    TenantId = 1,
                    FirstName = "Jasmin",
                    LastName = "Jamaković",
                    Username = "jasmin",
                    Email = "jasmin.jamakovic@edu.fit.ba",
                    PasswordHash = hash2,
                    PasswordSalt = salt2,
                    IsAdmin = true,
                    IsUser = false
                },
                new MyAppUser
                {
                    ID = 3,
                    TenantId = 1,
                    FirstName = "Denis",
                    LastName = "Mušić",
                    Username = "denis",
                    Email = "denis.music@edu.fit.ba",
                    PasswordHash = hash3,
                    PasswordSalt = salt3,
                    IsAdmin = false,
                    IsUser = true
                },
                new MyAppUser
                {
                    ID = 4,
                    TenantId = 1,
                    FirstName = "Adil",
                    LastName = "Joldić",
                    Username = "adil",
                    Email = "adil.joldic@edu.fit.ba",
                    PasswordHash = hash4,
                    PasswordSalt = salt4,
                    IsAdmin = true,
                    IsUser = false
                }
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