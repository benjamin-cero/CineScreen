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