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
                new Genre { GenreID = 39, Name = "Time Travel" },
                new Genre { GenreID = 40, Name = "Anime" }
            );

            modelBuilder.Entity<Actor>().HasData(
                new Actor { ActorID = 1, FirstName = "Auliʻi", LastName = "Cravalho" },
                new Actor { ActorID = 2, FirstName = "Dwayne", LastName = "Johnson" },
                new Actor { ActorID = 3, FirstName = "Aaron", LastName = "Pierre" },
                new Actor { ActorID = 4, FirstName = "Kelvin", LastName = "Harrison Jr." },
                new Actor { ActorID = 5, FirstName = "Beyoncé", LastName = "" },
                new Actor { ActorID = 6, FirstName = "Donald", LastName = "Glover" },
                new Actor { ActorID = 7, FirstName = "Seth", LastName = "Rogen" },
                new Actor { ActorID = 8, FirstName = "Billy", LastName = "Eichner" },
                new Actor { ActorID = 9, FirstName = "Anika", LastName = "Noni Rose" },
                new Actor { ActorID = 10, FirstName = "Mads", LastName = "Mikkelsen" },
                new Actor { ActorID = 11, FirstName = "Keanu", LastName = "Reeves" },
                new Actor { ActorID = 12, FirstName = "Jim", LastName = "Carrey" },
                new Actor { ActorID = 13, FirstName = "Ben", LastName = "Schwartz" },
                new Actor { ActorID = 14, FirstName = "Brian", LastName = "Cox" },
                new Actor { ActorID = 15, FirstName = "Gaia", LastName = "Wise" },
                new Actor { ActorID = 16, FirstName = "Luke", LastName = "Pasqualino" },
                new Actor { ActorID = 17, FirstName = "Shaun", LastName = "Dooley" },
                new Actor { ActorID = 18, FirstName = "Miranda", LastName = "Otto" },
                new Actor { ActorID = 19, FirstName = "Frank", LastName = "Grillo" },
                new Actor { ActorID = 20, FirstName = "Katrina", LastName = "Law" },
                new Actor { ActorID = 21, FirstName = "Lou Diamond", LastName = "Phillips" },
                new Actor { ActorID = 22, FirstName = "Ilfenesh", LastName = "Hadera" },
                new Actor { ActorID = 23, FirstName = "Kamdynn", LastName = "Gary" },
                new Actor { ActorID = 24, FirstName = "Aaron", LastName = "Taylor-Johnson" },
                new Actor { ActorID = 25, FirstName = "Ariana", LastName = "DeBose" },
                new Actor { ActorID = 26, FirstName = "Fred", LastName = "Hechinger" },
                new Actor { ActorID = 27, FirstName = "Christopher", LastName = "Abbott" },
                new Actor { ActorID = 28, FirstName = "Alessandro", LastName = "Nivola" },
                new Actor { ActorID = 29, FirstName = "Russell", LastName = "Crowe" },
                new Actor { ActorID = 30, FirstName = "Paul", LastName = "Mescal" },
                new Actor { ActorID = 31, FirstName = "Connie", LastName = "Nielsen" },
                new Actor { ActorID = 32, FirstName = "Derek", LastName = "Jacobi" },
                new Actor { ActorID = 33, FirstName = "Djimon", LastName = "Hounsou" },
                new Actor { ActorID = 34, FirstName = "Joseph", LastName = "Quinn" },
                new Actor { ActorID = 35, FirstName = "Denzel", LastName = "Washington" },
                new Actor { ActorID = 36, FirstName = "Pedro", LastName = "Pascal" },
                new Actor { ActorID = 37, FirstName = "Jai", LastName = "Courtney" },
                new Actor { ActorID = 38, FirstName = "Deborah", LastName = "Mailman" },
                new Actor { ActorID = 39, FirstName = "Jack", LastName = "Thompson" },
                new Actor { ActorID = 40, FirstName = "Matt", LastName = "Day" },
                new Actor { ActorID = 41, FirstName = "Geneviève", LastName = "Lemon" },
                new Actor { ActorID = 42, FirstName = "Celeste", LastName = "Barber" },
                new Actor { ActorID = 43, FirstName = "Lily", LastName = "LeTorre" },
                new Actor { ActorID = 44, FirstName = "Ben", LastName = "Wang" },
                new Actor { ActorID = 45, FirstName = "Ralph", LastName = "Macchio" },
                new Actor { ActorID = 46, FirstName = "Jackie", LastName = "Chan" },
                new Actor { ActorID = 47, FirstName = "Joshua", LastName = "Jackson" },
                new Actor { ActorID = 48, FirstName = "Ming-Na", LastName = "Wen" },
                new Actor { ActorID = 49, FirstName = "Sadie", LastName = "Stanley" },
                new Actor { ActorID = 50, FirstName = "Jesse", LastName = "Eisenberg" },
                new Actor { ActorID = 51, FirstName = "Mark", LastName = "Ruffalo" },
                new Actor { ActorID = 52, FirstName = "Woody", LastName = "Harrelson" },
                new Actor { ActorID = 53, FirstName = "Dave", LastName = "Franco" },
                new Actor { ActorID = 54, FirstName = "Isla", LastName = "Fisher" },
                new Actor { ActorID = 55, FirstName = "Rosamund", LastName = "Pike" },
                new Actor { ActorID = 56, FirstName = "Justice", LastName = "Smith" },
                new Actor { ActorID = 57, FirstName = "Ariana", LastName = "Greenblatt" },
                new Actor { ActorID = 58, FirstName = "Dominic", LastName = "Sessa" },
                new Actor { ActorID = 59, FirstName = "Mason", LastName = "Thames" },
                new Actor { ActorID = 60, FirstName = "Nico", LastName = "Parker" },
                new Actor { ActorID = 61, FirstName = "Gerard", LastName = "Butler" },
                new Actor { ActorID = 62, FirstName = "Nick", LastName = "Frost" },
                new Actor { ActorID = 63, FirstName = "Julian", LastName = "Dennison" },
                new Actor { ActorID = 64, FirstName = "Gabriel", LastName = "Howell" },
                new Actor { ActorID = 65, FirstName = "Bronwyn", LastName = "James" },
                new Actor { ActorID = 66, FirstName = "Jason", LastName = "Momoa" },
                new Actor { ActorID = 67, FirstName = "Jack", LastName = "Black" },
                new Actor { ActorID = 68, FirstName = "Danielle", LastName = "Brooks" },
                new Actor { ActorID = 69, FirstName = "Emma", LastName = "Myers" },
                new Actor { ActorID = 70, FirstName = "Matt", LastName = "Berry" },
                new Actor { ActorID = 71, FirstName = "Tom", LastName = "Cruise" },
                new Actor { ActorID = 72, FirstName = "Kelly", LastName = "McGillis" },
                new Actor { ActorID = 73, FirstName = "Val", LastName = "Kilmer" },
                new Actor { ActorID = 74, FirstName = "Anthony", LastName = "Edwards" },
                new Actor { ActorID = 75, FirstName = "Tom", LastName = "Skerritt" },
                new Actor { ActorID = 76, FirstName = "Michael", LastName = "Ironside" },
                new Actor { ActorID = 77, FirstName = "Meg", LastName = "Ryan" },
                new Actor { ActorID = 78, FirstName = "Roy", LastName = "Scheider" },
                new Actor { ActorID = 79, FirstName = "Robert", LastName = "Shaw" },
                new Actor { ActorID = 80, FirstName = "Richard", LastName = "Dreyfuss" },
                new Actor { ActorID = 81, FirstName = "Lorraine", LastName = "Gary" },
                new Actor { ActorID = 82, FirstName = "Murray", LastName = "Hamilton" },
                new Actor { ActorID = 83, FirstName = "Rumi", LastName = "Hiiragi" },
                new Actor { ActorID = 84, FirstName = "Miyu", LastName = "Irino" },
                new Actor { ActorID = 85, FirstName = "Bunta", LastName = "Sugawara" },
                new Actor { ActorID = 86, FirstName = "Mari", LastName = "Natsuki" },
                new Actor { ActorID = 87, FirstName = "Takehiko", LastName = "Ono" },
                new Actor { ActorID = 88, FirstName = "Tobey", LastName = "Maguire" },
                new Actor { ActorID = 89, FirstName = "Willem", LastName = "Dafoe" },
                new Actor { ActorID = 90, FirstName = "Kirsten", LastName = "Dunst" },
                new Actor { ActorID = 91, FirstName = "James", LastName = "Franco" },
                new Actor { ActorID = 92, FirstName = "Cliff", LastName = "Robertson" },
                new Actor { ActorID = 93, FirstName = "Rosemary", LastName = "Harris" }
            );



            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { ManufacturerID = 1, Name = "Sultan" },//kola
                new Manufacturer { ManufacturerID = 2, Name = "Orville Redenbacher" },//kokice
                new Manufacturer { ManufacturerID = 3, Name = "Nathan's Famous" },//hotdogovi
                new Manufacturer { ManufacturerID = 4, Name = "Tostitos" },//nachos
                new Manufacturer { ManufacturerID = 5, Name = "Chio" },//cips
                new Manufacturer { ManufacturerID = 6, Name = "Kühne" },//pomfrit
                new Manufacturer { ManufacturerID = 7, Name = "The Hershey Company" }


            );

            modelBuilder.Entity<Menu>().HasData(
                new Menu { MenuID = 1, Name = "Popcorn S", Price = 3, Image = ConvertImageToByteArray("wwwroot", "1. Popcorn S.png") },
                new Menu { MenuID = 2, Name = "Popcorn M", Price = 5, Image = ConvertImageToByteArray("wwwroot", "2. Popcorn M.png")},
                new Menu { MenuID = 3, Name = "Popcorn L", Price = 7,Image = ConvertImageToByteArray("wwwroot", "3. Popcorn L.png")},
                new Menu { MenuID = 4, Name = "Nachos", Price = 5, Image = ConvertImageToByteArray("wwwroot", "4. Nachos.png")},
                new Menu { MenuID = 5, Name = "Soda", Price = 3, Image = ConvertImageToByteArray("wwwroot", "5. Soda.png")},
                new Menu { MenuID = 6, Name = "Chips", Price = 4, Image = ConvertImageToByteArray("wwwroot", "6. Chips.png")},
                new Menu { MenuID = 7, Name = "Hot dog", Price = 5, Image = ConvertImageToByteArray("wwwroot", "7. Hot dog.png")},
                new Menu { MenuID = 8, Name = "French fries", Price = 4, Image = ConvertImageToByteArray("wwwroot", "8. French fries.png")},
                new Menu { MenuID = 9, Name = "Nachos + Soda", Price = 7, Image = ConvertImageToByteArray("wwwroot", "9. Nachos + Soda.png")},
                new Menu { MenuID = 10, Name = "Popcorn L + Soda", Price = 9, Image = ConvertImageToByteArray("wwwroot", "10. Popcorn L + Soda.png")},
                new Menu { MenuID = 11, Name = "Chips + Soda", Price = 6, Image = ConvertImageToByteArray("wwwroot", "11. Chips + Soda.png")},
                new Menu { MenuID = 12, Name = "French fries + Soda", Price = 7, Image = ConvertImageToByteArray("wwwroot", "12. French fries + Soda.png")},
                new Menu { MenuID = 13, Name = "Hot dog + Soda", Price = 7, Image = ConvertImageToByteArray("wwwroot", "13. Hot dog + Soda.png")},
                new Menu { MenuID = 14, Name = "Hershey's chocolate bar", Price = 3, Image = ConvertImageToByteArray("wwwroot", "14. Hershey's Chocholate bar.png")}
            );
            modelBuilder.Entity<MenuManufacturer>().HasData(
                new MenuManufacturer { MenuManufacturerID = 1, MenuID = 1 , ManufacturerID = 2},
                new MenuManufacturer { MenuManufacturerID = 2, MenuID = 2 , ManufacturerID = 2},
                new MenuManufacturer { MenuManufacturerID = 3, MenuID = 3 , ManufacturerID = 2},
                new MenuManufacturer { MenuManufacturerID = 4, MenuID = 3 , ManufacturerID = 4},
                new MenuManufacturer { MenuManufacturerID = 5, MenuID = 5 , ManufacturerID = 1},
                new MenuManufacturer { MenuManufacturerID = 6, MenuID = 6 , ManufacturerID = 5},
                new MenuManufacturer { MenuManufacturerID = 7, MenuID = 7 , ManufacturerID = 3},
                new MenuManufacturer { MenuManufacturerID = 8, MenuID = 8 , ManufacturerID = 6},
                new MenuManufacturer { MenuManufacturerID = 9, MenuID = 9 , ManufacturerID = 4},
                new MenuManufacturer { MenuManufacturerID = 10, MenuID = 9 , ManufacturerID = 1},
                new MenuManufacturer { MenuManufacturerID = 11, MenuID = 10 , ManufacturerID = 2},
                new MenuManufacturer { MenuManufacturerID = 12, MenuID = 10 , ManufacturerID = 1},
                new MenuManufacturer { MenuManufacturerID = 13, MenuID = 11 , ManufacturerID = 1},
                new MenuManufacturer { MenuManufacturerID = 14, MenuID = 11 , ManufacturerID = 5},
                new MenuManufacturer { MenuManufacturerID = 15, MenuID = 12 , ManufacturerID = 1},
                new MenuManufacturer { MenuManufacturerID = 16, MenuID = 12 , ManufacturerID = 6},
                new MenuManufacturer { MenuManufacturerID = 17, MenuID = 13 , ManufacturerID = 1},
                new MenuManufacturer { MenuManufacturerID = 18, MenuID = 13 , ManufacturerID = 3},
                new MenuManufacturer { MenuManufacturerID = 19, MenuID = 14 , ManufacturerID = 7}

            );




            modelBuilder.Entity<ProductionHouse>().HasData(
              
               new ProductionHouse { ProductionHouseID = 1, Name = "Walt Disney Studios" },
               new ProductionHouse { ProductionHouseID = 2, Name = "Paramount Pictures" },
               new ProductionHouse { ProductionHouseID = 3, Name = "Blur Studio" },
               new ProductionHouse { ProductionHouseID = 4, Name = "Sega Sammy Holdings" },
               new ProductionHouse { ProductionHouseID = 5, Name = "Marza Animation Planet" },
               new ProductionHouse { ProductionHouseID = 6, Name = "New Line Cinema" },
               new ProductionHouse { ProductionHouseID = 7, Name = "Warner Bros. Animation" },
               new ProductionHouse { ProductionHouseID = 8, Name = "Briarcliff Entertainment" },
               new ProductionHouse { ProductionHouseID = 9, Name = "Sony Pictures" },
               new ProductionHouse { ProductionHouseID = 10, Name = "Marvel Entertainment" },
               new ProductionHouse { ProductionHouseID = 11, Name = "Universal Pictures" },
               new ProductionHouse { ProductionHouseID = 12, Name = "StudioCanal" },
               new ProductionHouse { ProductionHouseID = 13, Name = "Screen Australia" },
               new ProductionHouse { ProductionHouseID = 14, Name = "ScreenWest" },
               new ProductionHouse { ProductionHouseID = 15, Name = "Lotterywest" },
               new ProductionHouse { ProductionHouseID = 16, Name = "Lionsgate" },
               new ProductionHouse { ProductionHouseID = 17, Name = "Studio Ghibli" },
               new ProductionHouse { ProductionHouseID = 18, Name = "Tokuma Shoten" },
               new ProductionHouse { ProductionHouseID = 19, Name = "Nippon Television Network" },
               new ProductionHouse { ProductionHouseID = 20, Name = "Dentsu" },
               new ProductionHouse { ProductionHouseID = 21, Name = "Columbia Pictures" }

            );
            modelBuilder.Entity<Director>().HasData(
                new Director { DirectorID = 1, FirstName = "Steven", LastName = "Spielberg" },
                new Director { DirectorID = 2, FirstName = "David", LastName = "Derrick Jr." },
                new Director { DirectorID = 3, FirstName = "Jason", LastName = "Hand" },
                new Director { DirectorID = 4, FirstName = "Dana Ledoux", LastName = "Miller" },
                new Director { DirectorID = 5, FirstName = "Barry", LastName = "Jenkins" },
                new Director { DirectorID = 6, FirstName = "Jeff", LastName = "Fowler" },
                new Director { DirectorID = 7, FirstName = "Kenji", LastName = "Kamiyama" },
                new Director { DirectorID = 8, FirstName = "Steven C.", LastName = "Miller" },
                new Director { DirectorID = 9, FirstName = "J.C.", LastName = "Chandor" },
                new Director { DirectorID = 10, FirstName = "Ridley", LastName = "Scott" },
                new Director { DirectorID = 11, FirstName = "John", LastName = "Sheedy" },
                new Director { DirectorID = 12, FirstName = "Jonathan", LastName = "Entwistle" },
                new Director { DirectorID = 13, FirstName = "Ruben", LastName = "Fleischer" },
                new Director { DirectorID = 14, FirstName = "Dean", LastName = "DeBlois" },
                new Director { DirectorID = 15, FirstName = "Jared", LastName = "Hess" },
                new Director { DirectorID = 16, FirstName = "Tony", LastName = "Scott" },
                new Director { DirectorID = 17, FirstName = "Hayao", LastName = "Miyazaki" },
                new Director { DirectorID = 18, FirstName = "Sam", LastName = "Raimi" }
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

            modelBuilder.Entity<Status>().HasData(
               new Status { StatusID = 1, Name = "Active" },
               new Status { StatusID = 2, Name = "Upcoming" },
               new Status { StatusID = 3, Name = "Classic" },
               new Status { StatusID = 4, Name = "Hidden" }
           );
            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieID = 1, Title = "Moana 2",ReleaseDate = new DateTime(2024,11,27,0,0,0), Description = "Moana, Maui, Pua, and Heihei are back in a Disney sequel that takes the gang to uncharted waters. After receiving an unexpected call from her wayfinding ancestors, Moana must journey to the far seas of Oceania for an adventure unlike anything she’s ever faced.",Duration = 100,Poster = ConvertImageToByteArray("wwwroot", "1. Moana 2.jpg"), Trailer = "https://www.youtube.com/watch?v=hDZ7y8RP5HE&t=1s",StatusID = 1 },
               

                new Movie { MovieID = 2, Title = "Sonic the Hedgehog 3", ReleaseDate = new DateTime(2024, 12, 20, 0, 0, 0), Description = "Sonic, Knuckles, and Tails reunite against a powerful new adversary, Shadow, a mysterious villain with powers unlike anything they have faced before. With their abilities outmatched in every way, Team Sonic must seek out an unlikely alliance in hopes of stopping Shadow and protecting the planet.", Duration = 109, Poster = ConvertImageToByteArray("wwwroot", "3. Sonic 3.png"), Trailer = "https://www.youtube.com/watch?v=qSu6i2iFMO0", StatusID = 1 },
                
               
                new Movie
                {
                    MovieID = 3,
                    Title = "Kraven the Hunter",
                    ReleaseDate = new DateTime(2024, 12, 13, 0, 0, 0),
                    Description = "The film follows Sergei Kravinoff (Kraven), a skilled big-game hunter, portrayed as an antihero rather than a villain. The story explores his traumatic childhood, his relationship with his father (played by Russell Crowe), and his quest for vengeance. The movie brings a darker and more complex version of Kraven, adding depth to his character as he navigates his moral code and his ambition to become the world's greatest hunter.",
                    Duration = 120,
                    Poster = ConvertImageToByteArray("wwwroot", "6. Kraven the Hunter.jpg"),
                    Trailer = "https://www.youtube.com/watch?v=I8gFw4-2RBM",
                    StatusID = 1
                },
               
            
                new Movie
                {
                    MovieID = 4,
                    Title = "Karate Kid: Legends",
                    ReleaseDate = new DateTime(2025, 5, 30, 0, 0, 0),
                    Description = "Karate Kid: Legends follows the story of Li Fong, a Chinese teenager who moves to Brooklyn anddiscovers his love for martial arts, blending kung fu and karate. As Li adjusts to his new life, he meetskey figures such as Daniel LaRusso (Ralph Macchio) and Mr. Han (Jackie Chan), who guide him on his martialarts journey. Set after the events of Cobra Kai, the movie will tie together elements from both the KarateKid movies and the popular Cobra Kai series, introducing a new protagonist while celebrating the franchise' legacy.",
                    Duration = 109,
                    Poster = ConvertImageToByteArray("wwwroot", "9. Karate Kid Legends.png"),
                    Trailer = null, // No trailer provided
                    StatusID = 2
                },
               
                new Movie
                {
                    MovieID = 5,
                    Title = "How to Train Your Dragon",
                    ReleaseDate = new DateTime(2025, 6, 13, 0, 0, 0),
                    Description = "This live-action adaptation of the original How to Train Your Dragon film will follow Hiccup, the son of a Viking chief, who forms a unique bond with Toothless, a dragon. In a world where dragons are feared and fought against, Hiccup and Toothless must navigate their friendship and face challenges together. The film promises a mix of emotional depth and stunning visual effects as it brings the beloved characters to life in a new format.",
                    Duration = 92,
                    Poster = ConvertImageToByteArray("wwwroot", "11. How to Train Your Dragon.png"),
                    Trailer = null, // No trailer provided
                    StatusID = 2
                },
                new Movie
                {
                    MovieID = 6,
                    Title = "A Minecraft Movie",
                    ReleaseDate = new DateTime(2025, 4, 4, 0, 0, 0),
                    Description = "In this live-action adaptation, a group of adventurers is transported into the blocky world of Minecraft, where they must join forces to stop the destructive Ender Dragon threatening the Overworld. With the help of iconic Minecraft creatures, including Steve, the characters must navigate the dangers of the game world. The film blends action, humor, and a sense of adventure as humans adjust to their new environment​.",
                    Duration = 98,
                    Poster = ConvertImageToByteArray("wwwroot", "12. A Minecraft Movie.jpg"),
                    Trailer = "https://www.youtube.com/watch?v=wJO_vIDZn-I",
                    StatusID = 2
                },
              

                new Movie
                {
                    MovieID = 7,
                    Title = "Jaws",
                    ReleaseDate = new DateTime(1975, 6, 20, 0, 0, 0),
                    Description = "Set on the fictional island of Amity, Jaws follows Chief Martin Brody as he investigates a series of mysterious shark attacks that threaten the summer tourist season. With the help of marine biologist Matt Hooper and professional shark hunter Quint, Brody must confront the deadly creature lurking in the waters. As the trio hunts the shark, they face escalating danger, and Brody must confront his own fears to protect the town and his family.",
                    Duration = 124,
                    Poster = ConvertImageToByteArray("wwwroot", "14. Jaws.png"),
                    Trailer = "https://www.youtube.com/watch?v=U1fu_sA7XhE",
                    StatusID = 3
                },
                new Movie
                {
                    MovieID = 8,
                    Title = "Spirited Away",
                    ReleaseDate = new DateTime(2001, 7, 20, 0, 0, 0),
                    Description = "Spirited Away follows Chihiro, a young girl who, while on her way to her new home, stumbles upon a mysterious, seemingly abandoned theme park. As her parents are transformed into pigs, Chihiro is forced to work at a bathhouse run by spirits and strange creatures. She befriends Haku, a mysterious boy, and with his help, attempts to find a way to rescue her parents and return home. The film explores themes of personal growth, environmentalism, and the importance of memory.",
                    Duration = 125,
                    Poster = ConvertImageToByteArray("wwwroot", "15. Spirited Away.png"),
                    Trailer = "https://www.youtube.com/watch?v=ByXuk9QqQkk",
                    StatusID = 3
                },
                new Movie
                {
                    MovieID = 9,
                    Title = "Spider-Man",
                    ReleaseDate = new DateTime(2002, 5, 3, 0, 0, 0),
                    Description = "The film follows Peter Parker, a high school student who gains spider-like abilities after being bitten by a genetically altered spider. As Peter struggles with his newfound powers, he must balance his life as a student and superhero while facing the villainous Green Goblin, whose true identity is tied to Peter’s best friend Harry's father, Norman Osborn. The movie explores themes of responsibility, love, and loss, with Peter learning that with great power comes great responsibility.",
                    Duration = 121,
                    Poster = ConvertImageToByteArray("wwwroot", "16. Spider-Man.jpg"),
                    Trailer = "https://www.youtube.com/watch?v=t06RUxPbp_c",
                    StatusID = 3
                }

            );



            modelBuilder.Entity<MovieActor>().HasData(
            // Moana 2
            new MovieActor { MovieActorID = 1, ActorID = 1, MovieID = 1 },  // Auli'i Cravalho
            new MovieActor { MovieActorID = 2, ActorID = 2, MovieID = 1 },  // Dwayne Johnson

            // Sonic the Hedgehog 3
            new MovieActor { MovieActorID = 3, ActorID = 11, MovieID = 2 }, // Keanu Reeves
            new MovieActor { MovieActorID = 4, ActorID = 12, MovieID = 2 }, // Jim Carrey
            new MovieActor { MovieActorID = 5, ActorID = 13, MovieID = 2 }, // Ben Schwartz

            // Kraven the Hunter
            new MovieActor { MovieActorID = 6, ActorID = 24, MovieID = 3 }, // Aaron Taylor-Johnson
            new MovieActor { MovieActorID = 7, ActorID = 25, MovieID = 3 }, // Ariana DeBose
            new MovieActor { MovieActorID = 8, ActorID = 26, MovieID = 3 }, // Fred Hechinger
            new MovieActor { MovieActorID = 9, ActorID = 27, MovieID = 3 }, // Christopher Abbott
            new MovieActor { MovieActorID = 10, ActorID = 28, MovieID = 3 }, // Alessandro Nivola
            new MovieActor { MovieActorID = 11, ActorID = 29, MovieID = 3 }, // Russell Crowe

            // Karate Kid: Legends
            new MovieActor { MovieActorID = 12, ActorID = 44, MovieID = 4 }, // Ben Wang
            new MovieActor { MovieActorID = 13, ActorID = 45, MovieID = 4 }, // Ralph Macchio
            new MovieActor { MovieActorID = 14, ActorID = 46, MovieID = 4 }, // Jackie Chan
            new MovieActor { MovieActorID = 15, ActorID = 47, MovieID = 4 }, // Joshua Jackson
            new MovieActor { MovieActorID = 16, ActorID = 48, MovieID = 4 }, // Ming-Na Wen
            new MovieActor { MovieActorID = 17, ActorID = 49, MovieID = 4 }, // Sadie Stanley

            // How to Train Your Dragon
            new MovieActor { MovieActorID = 18, ActorID = 59, MovieID = 5 }, // Mason Thames
            new MovieActor { MovieActorID = 19, ActorID = 60, MovieID = 5 }, // Nico Parker
            new MovieActor { MovieActorID = 20, ActorID = 61, MovieID = 5 }, // Gerard Butler
            new MovieActor { MovieActorID = 21, ActorID = 62, MovieID = 5 }, // Nick Frost
            new MovieActor { MovieActorID = 22, ActorID = 63, MovieID = 5 }, // Julian Dennison
            new MovieActor { MovieActorID = 23, ActorID = 64, MovieID = 5 }, // Gabriel Howell
            new MovieActor { MovieActorID = 24, ActorID = 65, MovieID = 5 }, // Bronwyn James

            // A Minecraft Movie
            new MovieActor { MovieActorID = 25, ActorID = 66, MovieID = 6 }, // Jason Momoa
            new MovieActor { MovieActorID = 26, ActorID = 67, MovieID = 6 }, // Jack Black
            new MovieActor { MovieActorID = 27, ActorID = 68, MovieID = 6 }, // Danielle Brooks
            new MovieActor { MovieActorID = 28, ActorID = 69, MovieID = 6 }, // Emma Myers
            new MovieActor { MovieActorID = 29, ActorID = 70, MovieID = 6 }, // Matt Berry

            // Jaws
            new MovieActor { MovieActorID = 30, ActorID = 78, MovieID = 7 }, // Roy Scheider
            new MovieActor { MovieActorID = 31, ActorID = 79, MovieID = 7 }, // Robert Shaw
            new MovieActor { MovieActorID = 32, ActorID = 80, MovieID = 7 }, // Richard Dreyfuss
            new MovieActor { MovieActorID = 33, ActorID = 81, MovieID = 7 }, // Lorraine Gary
            new MovieActor { MovieActorID = 34, ActorID = 82, MovieID = 7 }, // Murray Hamilton

            // Spirited Away
            new MovieActor { MovieActorID = 35, ActorID = 83, MovieID = 8 }, // Rumi Hiiragi
            new MovieActor { MovieActorID = 36, ActorID = 84, MovieID = 8 }, // Miyu Irino
            new MovieActor { MovieActorID = 37, ActorID = 85, MovieID = 8 }, // Bunta Sugawara
            new MovieActor { MovieActorID = 38, ActorID = 86, MovieID = 8 }, // Mari Natsuki
            new MovieActor { MovieActorID = 39, ActorID = 87, MovieID = 8 }, // Takehiko Ono

            // Spider-Man
            new MovieActor { MovieActorID = 40, ActorID = 88, MovieID = 9 }, // Tobey Maguire
            new MovieActor { MovieActorID = 41, ActorID = 89, MovieID = 9 }, // Willem Dafoe
            new MovieActor { MovieActorID = 42, ActorID = 90, MovieID = 9 }, // Kirsten Dunst
            new MovieActor { MovieActorID = 43, ActorID = 91, MovieID = 9 }, // James Franco
            new MovieActor { MovieActorID = 44, ActorID = 92, MovieID = 9 }, // Cliff Robertson
            new MovieActor { MovieActorID = 45, ActorID = 93, MovieID = 9 }  // Rosemary Harris
        );


            modelBuilder.Entity<MovieProductionHouse>().HasData(
           new MovieProductionHouse { MovieProductionHouseID = 1, MovieID = 1, ProductionHouseID = 1 },  // Moana 2: Walt Disney Studios
           new MovieProductionHouse { MovieProductionHouseID = 2, MovieID = 2, ProductionHouseID = 2 },  // Sonic the Hedgehog 3: Paramount Pictures
           new MovieProductionHouse { MovieProductionHouseID = 3, MovieID = 2, ProductionHouseID = 3 },  // Sonic the Hedgehog 3: Blur Studio
           new MovieProductionHouse { MovieProductionHouseID = 4, MovieID = 2, ProductionHouseID = 4 },  // Sonic the Hedgehog 3: Sega Sammy Holdings
           new MovieProductionHouse { MovieProductionHouseID = 5, MovieID = 2, ProductionHouseID = 5 },  // Sonic the Hedgehog 3: Marza Animation Planet
           new MovieProductionHouse { MovieProductionHouseID = 6, MovieID = 3, ProductionHouseID = 9 },  // Kraven the Hunter: Sony Pictures
           new MovieProductionHouse { MovieProductionHouseID = 7, MovieID = 3, ProductionHouseID = 10 }, // Kraven the Hunter: Marvel Entertainment
           new MovieProductionHouse { MovieProductionHouseID = 8, MovieID = 4, ProductionHouseID = 9 },  // Karate Kid: Legends: Sony Pictures
           new MovieProductionHouse { MovieProductionHouseID = 9, MovieID = 5, ProductionHouseID = 11 }, // How to Train Your Dragon: Universal Pictures
           new MovieProductionHouse { MovieProductionHouseID = 10, MovieID = 6, ProductionHouseID = 7 }, // A Minecraft Movie: Warner Bros.
           new MovieProductionHouse { MovieProductionHouseID = 11, MovieID = 7, ProductionHouseID = 11 }, // Jaws: Universal Pictures
           new MovieProductionHouse { MovieProductionHouseID = 12, MovieID = 8, ProductionHouseID = 17 }, // Spirited Away: Studio Ghibli
           new MovieProductionHouse { MovieProductionHouseID = 13, MovieID = 8, ProductionHouseID = 18 }, // Spirited Away: Tokuma Shoten
           new MovieProductionHouse { MovieProductionHouseID = 14, MovieID = 8, ProductionHouseID = 19 }, // Spirited Away: Nippon Television Network
           new MovieProductionHouse { MovieProductionHouseID = 15, MovieID = 8, ProductionHouseID = 20 }, // Spirited Away: Dentsu
           new MovieProductionHouse { MovieProductionHouseID = 16, MovieID = 9, ProductionHouseID = 9 },  // Spider-Man: Sony Pictures
           new MovieProductionHouse { MovieProductionHouseID = 17, MovieID = 9, ProductionHouseID = 21 }, // Spider-Man: Columbia Pictures
           new MovieProductionHouse { MovieProductionHouseID = 18, MovieID = 9, ProductionHouseID = 10 }  // Spider-Man: Marvel Entertainment
       );

            modelBuilder.Entity<MovieDirector>().HasData(
      new MovieDirector { MovieDirectorID = 1, DirectorID = 1, MovieID = 7 },  // Steven Spielberg -> Jaws
      new MovieDirector { MovieDirectorID = 2, DirectorID = 2, MovieID = 1 },  // David Derrick Jr. -> Moana 2
      new MovieDirector { MovieDirectorID = 3, DirectorID = 3, MovieID = 1 },  // Jason Hand -> Moana 2
      new MovieDirector { MovieDirectorID = 4, DirectorID = 4, MovieID = 1 },  // Dana Ledoux Miller -> Moana 2
      new MovieDirector { MovieDirectorID = 5, DirectorID = 6, MovieID = 2 },  // Jeff Fowler -> Sonic the Hedgehog 3
      new MovieDirector { MovieDirectorID = 6, DirectorID = 9, MovieID = 3 },  // J.C. Chandor -> Kraven the Hunter
      new MovieDirector { MovieDirectorID = 7, DirectorID = 12, MovieID = 4 }, // Jonathan Entwistle -> Karate Kid
      new MovieDirector { MovieDirectorID = 8, DirectorID = 14, MovieID = 5 }, // Dean DeBlois -> How to Train Your Dragon
      new MovieDirector { MovieDirectorID = 9, DirectorID = 15, MovieID = 6 }, // Jared Hess -> A Minecraft Movie
      new MovieDirector { MovieDirectorID = 10, DirectorID = 17, MovieID = 8 }, // Hayao Miyazaki -> Spirited Away
      new MovieDirector { MovieDirectorID = 11, DirectorID = 18, MovieID = 9 }  // Sam Raimi -> Spider-Man
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