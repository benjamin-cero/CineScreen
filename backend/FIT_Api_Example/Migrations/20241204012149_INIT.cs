﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIT_Api_Example.Migrations
{
    public partial class INIT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actor",
                columns: table => new
                {
                    ActorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actor", x => x.ActorID);
                });

            migrationBuilder.CreateTable(
                name: "CinemaHall",
                columns: table => new
                {
                    CinemaHallID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaHall", x => x.CinemaHallID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                });

            migrationBuilder.CreateTable(
                name: "Director",
                columns: table => new
                {
                    DirectorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Director", x => x.DirectorID);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreID);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.ManufacturerID);
                });

            migrationBuilder.CreateTable(
                name: "MovieType",
                columns: table => new
                {
                    MovieTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieType", x => x.MovieTypeID);
                });

            migrationBuilder.CreateTable(
                name: "ProductionHouse",
                columns: table => new
                {
                    ProductionHouseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionHouse", x => x.ProductionHouseID);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    SeatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    CinemaHallID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.SeatID);
                    table.ForeignKey(
                        name: "FK_Seat_CinemaHall_CinemaHallID",
                        column: x => x.CinemaHallID,
                        principalTable: "CinemaHall",
                        principalColumn: "CinemaHallID");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityID = table.Column<int>(type: "int", nullable: true),
                    GenderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Account_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID");
                    table.ForeignKey(
                        name: "FK_Account_Gender_GenderID",
                        column: x => x.GenderID,
                        principalTable: "Gender",
                        principalColumn: "GenderID");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ManufacturerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Product_Manufacturer_ManufacturerID",
                        column: x => x.ManufacturerID,
                        principalTable: "Manufacturer",
                        principalColumn: "ManufacturerID");
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    MovieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Poster = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DirectorID = table.Column<int>(type: "int", nullable: false),
                    ProductionHouseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.MovieID);
                    table.ForeignKey(
                        name: "FK_Movie_Director_DirectorID",
                        column: x => x.DirectorID,
                        principalTable: "Director",
                        principalColumn: "DirectorID");
                    table.ForeignKey(
                        name: "FK_Movie_ProductionHouse_ProductionHouseID",
                        column: x => x.ProductionHouseID,
                        principalTable: "ProductionHouse",
                        principalColumn: "ProductionHouseID");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Order_Account_UserID",
                        column: x => x.UserID,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_Order_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateTable(
                name: "MovieActor",
                columns: table => new
                {
                    MovieActorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    ActorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActor", x => x.MovieActorID);
                    table.ForeignKey(
                        name: "FK_MovieActor_Actor_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actor",
                        principalColumn: "ActorID");
                    table.ForeignKey(
                        name: "FK_MovieActor_Movie_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movie",
                        principalColumn: "MovieID");
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    MovieGenreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => x.MovieGenreID);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "GenreID");
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movie_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movie",
                        principalColumn: "MovieID");
                });

            migrationBuilder.CreateTable(
                name: "Projection",
                columns: table => new
                {
                    ProjectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    CinemaHallID = table.Column<int>(type: "int", nullable: false),
                    MovieTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projection", x => x.ProjectionID);
                    table.ForeignKey(
                        name: "FK_Projection_CinemaHall_CinemaHallID",
                        column: x => x.CinemaHallID,
                        principalTable: "CinemaHall",
                        principalColumn: "CinemaHallID");
                    table.ForeignKey(
                        name: "FK_Projection_Movie_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movie",
                        principalColumn: "MovieID");
                    table.ForeignKey(
                        name: "FK_Projection_MovieType_MovieTypeID",
                        column: x => x.MovieTypeID,
                        principalTable: "MovieType",
                        principalColumn: "MovieTypeID");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    MovieID = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewID);
                    table.ForeignKey(
                        name: "FK_Review_Account_UserID",
                        column: x => x.UserID,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_Review_Movie_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movie",
                        principalColumn: "MovieID");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    SeatID = table.Column<int>(type: "int", nullable: false),
                    ProjectionID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Ticket_Account_UserID",
                        column: x => x.UserID,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_Ticket_Projection_ProjectionID",
                        column: x => x.ProjectionID,
                        principalTable: "Projection",
                        principalColumn: "ProjectionID");
                    table.ForeignKey(
                        name: "FK_Ticket_Seat_SeatID",
                        column: x => x.SeatID,
                        principalTable: "Seat",
                        principalColumn: "SeatID");
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "ActorID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Leonardo", "DiCaprio" },
                    { 2, "Brad", "Pitt" },
                    { 3, "Tom", "Cruise" },
                    { 4, "Robert", "Downey Jr." },
                    { 5, "Chris", "Hemsworth" },
                    { 6, "Dwayne", "Johnson" },
                    { 7, "Ryan", "Reynolds" },
                    { 8, "Keanu", "Reeves" },
                    { 9, "Chris", "Evans" },
                    { 10, "Joaquin", "Phoenix" },
                    { 11, "Timothée", "Chalamet" },
                    { 12, "Zendaya", "" },
                    { 13, "Florence", "Pugh" },
                    { 14, "Margot", "Robbie" },
                    { 15, "Christian", "Bale" },
                    { 16, "Will", "Smith" },
                    { 17, "Matt", "Damon" },
                    { 18, "Benedict", "Cumberbatch" },
                    { 19, "Hugh", "Jackman" },
                    { 20, "Scarlett", "Johansson" },
                    { 21, "Emma", "Stone" },
                    { 22, "Jennifer", "Lawrence" },
                    { 23, "Gal", "Gadot" },
                    { 24, "Anne", "Hathaway" },
                    { 25, "Cillian", "Murphy" },
                    { 26, "Tom", "Holland" },
                    { 27, "Andrew", "Garfield" },
                    { 28, "Zac", "Efron" },
                    { 29, "Jake", "Gyllenhaal" },
                    { 30, "Oscar", "Isaac" },
                    { 31, "Eddie", "Redmayne" },
                    { 32, "Pedro", "Pascal" },
                    { 33, "Millie", "Bobby Brown" },
                    { 34, "Natalie", "Portman" },
                    { 35, "Javier", "Bardem" },
                    { 36, "Daniel", "Craig" },
                    { 37, "Michael", "Fassbender" },
                    { 38, "Idris", "Elba" },
                    { 39, "Paul", "Rudd" },
                    { 40, "Jared", "Leto" },
                    { 41, "Emma", "Watson" },
                    { 42, "Saoirse", "Ronan" }
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "ActorID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 43, "Daniel", "Radcliffe" },
                    { 44, "Ryan", "Gosling" },
                    { 45, "Robert", "Pattinson" },
                    { 46, "Jason", "Momoa" },
                    { 47, "Angelina", "Jolie" },
                    { 48, "Anne", "Hathaway" },
                    { 49, "Meryl", "Streep" },
                    { 50, "Reese", "Witherspoon" },
                    { 51, "Cate", "Blanchett" },
                    { 52, "Viola", "Davis" },
                    { 53, "Julia", "Roberts" },
                    { 54, "Sandra", "Bullock" },
                    { 55, "Halle", "Berry" },
                    { 56, "Nicole", "Kidman" },
                    { 57, "Amy", "Adams" },
                    { 58, "Jessica", "Chastain" },
                    { 59, "Tom", "Hanks" },
                    { 60, "Billie", "Eilish" },
                    { 61, "Robin", "Wright" },
                    { 62, "Winona", "Ryder" },
                    { 63, "Chadwick", "Boseman" },
                    { 64, "Ewan", "McGregor" },
                    { 65, "Sam", "Rockwell" },
                    { 66, "Mahershala", "Ali" },
                    { 67, "Elizabeth", "Olsen" },
                    { 68, "Mark", "Ruffalo" },
                    { 69, "Tilda", "Swinton" },
                    { 70, "Eva", "Green" },
                    { 71, "John", "Boyega" },
                    { 72, "Natalie", "Dormer" },
                    { 73, "David", "Harbour" },
                    { 74, "Anya", "Taylor-Joy" },
                    { 75, "Rami", "Malek" },
                    { 76, "Sophia", "Lillis" },
                    { 77, "Finn", "Wolfhard" },
                    { 78, "Noah", "Schnapp" },
                    { 79, "Sadie", "Sink" },
                    { 80, "Maya", "Hawke" },
                    { 81, "Steve", "Carell" },
                    { 82, "Jonah", "Hill" },
                    { 83, "Seth", "Rogen" },
                    { 84, "James", "Franco" }
                });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "ActorID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 85, "Emily", "Blunt" },
                    { 86, "Lupita", "Nyong'o" },
                    { 87, "Danai", "Gurira" },
                    { 88, "Chloë", "Grace Moretz" },
                    { 89, "Haley", "Bennett" },
                    { 90, "Zoe", "Kravitz" },
                    { 91, "Rosamund", "Pike" },
                    { 92, "Charlize", "Theron" },
                    { 93, "Jessica", "Alba" },
                    { 94, "Mila", "Kunis" },
                    { 95, "Ashton", "Kutcher" },
                    { 96, "Hugh", "Grant" },
                    { 97, "Colin", "Firth" },
                    { 98, "Jude", "Law" },
                    { 99, "Jamie", "Foxx" },
                    { 100, "Morgan", "Freeman" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "Name" },
                values: new object[,]
                {
                    { 1, "Banja Luka" },
                    { 2, "Bihać" },
                    { 3, "Bijeljina" },
                    { 4, "Bosnaska Krupa" },
                    { 5, "Cazin" },
                    { 6, "Čapljina" },
                    { 7, "Drventa" },
                    { 8, "Doboj" },
                    { 9, "Goražde" },
                    { 10, "Gračanica" },
                    { 11, "Gradačac" },
                    { 12, "Gradiška" },
                    { 13, "Konjic" },
                    { 14, "Laktaši" },
                    { 15, "Livno" },
                    { 16, "Lukavac" },
                    { 17, "Ljubuški" },
                    { 18, "Mostar" },
                    { 19, "Orašje" },
                    { 20, "Prijedor" },
                    { 21, "Prnjavor" },
                    { 22, "Sarajevo" },
                    { 23, "Srebrenik" },
                    { 24, "Stolac" },
                    { 25, "Široki Brijeg" },
                    { 26, "Travnik" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityID", "Name" },
                values: new object[,]
                {
                    { 27, "Tuzla" },
                    { 28, "Visoko" },
                    { 29, "Zavidovići" },
                    { 30, "Zenica" },
                    { 31, "Zvornik" },
                    { 32, "Živinice" },
                    { 33, "Donji Vakuf" },
                    { 34, "Zavidovići" }
                });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "DirectorID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Steven", "Spielberg" },
                    { 2, "Martin", "Scorsese" },
                    { 3, "Quentin", "Tarantino" },
                    { 4, "Christopher", "Nolan" },
                    { 5, "Alfred", "Hitchcock" },
                    { 6, "James", "Cameron" },
                    { 7, "Stanley", "Kubrick" },
                    { 8, "Ridley", "Scott" },
                    { 9, "Francis", "Ford Coppola" },
                    { 10, "Tim", "Burton" },
                    { 11, "Wes", "Anderson" },
                    { 12, "David", "Fincher" },
                    { 13, "George", "Lucas" },
                    { 14, "Woody", "Allen" },
                    { 15, "Roman", "Polanski" },
                    { 16, "Michael", "Bay" },
                    { 17, "Zack", "Snyder" },
                    { 18, "Peter", "Jackson" },
                    { 19, "Christopher", "McQuarrie" },
                    { 20, "Paul", "Thomas Anderson" },
                    { 21, "Joel", "Coen" },
                    { 22, "Ethan", "Coen" },
                    { 23, "John", "Carpenter" },
                    { 24, "Spike", "Lee" },
                    { 25, "Hayao", "Miyazaki" },
                    { 26, "Guillermo", "del Toro" },
                    { 27, "Jean-Pierre", "Jeunet" },
                    { 28, "Frank", "Darabont" },
                    { 29, "Ang", "Lee" },
                    { 30, "Barry", "Jenkins" },
                    { 31, "Kathryn", "Bigelow" },
                    { 32, "Danny", "Boyle" },
                    { 33, "Martin", "McDonagh" },
                    { 34, "Taika", "Waititi" }
                });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "DirectorID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 35, "J.J.", "Abrams" },
                    { 36, "Danny", "DeVito" },
                    { 37, "Lana", "Wachowski" },
                    { 38, "Lilly", "Wachowski" },
                    { 39, "Robert", "Zemeckis" },
                    { 40, "Richard", "Linklater" },
                    { 41, "Steven", "Soderbergh" },
                    { 42, "James", "Wan" },
                    { 43, "M. Night", "Shyamalan" },
                    { 44, "Bong", "Joon-ho" },
                    { 45, "Terry", "Gilliam" },
                    { 46, "Richard", "Curtis" },
                    { 47, "Ron", "Howard" },
                    { 48, "Oliver", "Stone" },
                    { 49, "Sam", "Mendes" },
                    { 50, "Robert", "Rodriguez" },
                    { 51, "John", "Hughes" },
                    { 52, "Paul", "Verhoeven" },
                    { 53, "Michael", "Mann" },
                    { 54, "Rian", "Johnson" },
                    { 55, "Bryan", "Singer" },
                    { 56, "Lenny", "Abrahamson" },
                    { 57, "Joe", "Wright" },
                    { 58, "Terry", "Gilliam" },
                    { 59, "Greta", "Gerwig" },
                    { 60, "Ethan", "Coen" },
                    { 61, "Joel", "Coen" },
                    { 62, "Jason", "Reitman" },
                    { 63, "Bryan", "Singer" },
                    { 64, "Stephen", "King" },
                    { 65, "Guy", "Ritchie" },
                    { 66, "Paul", "Greengrass" },
                    { 67, "Ron", "Howard" },
                    { 68, "John", "Woo" },
                    { 69, "Sylvester", "Stallone" },
                    { 70, "Stephen", "Spielberg" },
                    { 71, "James", "Cameron" },
                    { 72, "Ridley", "Scott" },
                    { 73, "Peter", "Jackson" },
                    { 74, "Tim", "Burton" },
                    { 75, "J.J.", "Abrams" },
                    { 76, "M. Night", "Shyamalan" }
                });

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "DirectorID", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 77, "Ang", "Lee" },
                    { 78, "John", "Hughes" },
                    { 79, "Greta", "Gerwig" },
                    { 80, "Guillermo", "del Toro" },
                    { 81, "Martin", "Scorsese" },
                    { 82, "Christopher", "Nolan" },
                    { 83, "Spike", "Lee" },
                    { 84, "Hayao", "Miyazaki" },
                    { 85, "Quentin", "Tarantino" },
                    { 86, "Alfred", "Hitchcock" },
                    { 87, "Wes", "Anderson" },
                    { 88, "Stanley", "Kubrick" },
                    { 89, "Ridley", "Scott" },
                    { 90, "David", "Fincher" },
                    { 91, "James", "Wan" },
                    { 92, "Danny", "Boyle" },
                    { 93, "M. Night", "Shyamalan" },
                    { 94, "Terry", "Gilliam" },
                    { 95, "Frank", "Darabont" },
                    { 96, "Rian", "Johnson" },
                    { 97, "Paul", "Greengrass" },
                    { 98, "Bryan", "Singer" },
                    { 99, "Ron", "Howard" },
                    { 100, "Stephen", "Spielberg" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "GenderID", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Fmale" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreID", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Drama" },
                    { 4, "Fantasy" },
                    { 5, "Horror" },
                    { 6, "Mystery" },
                    { 7, "Romance" },
                    { 8, "Science Fiction" },
                    { 9, "Sci-Fi" },
                    { 10, "Thriller" },
                    { 11, "Crime" },
                    { 12, "Historical" },
                    { 13, "Superhero" },
                    { 14, "Western" },
                    { 15, "Musical" },
                    { 16, "War" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreID", "Name" },
                values: new object[,]
                {
                    { 17, "Biographical" },
                    { 18, "Sports" },
                    { 19, "Family" },
                    { 20, "Animation" },
                    { 21, "Documentary" },
                    { 22, "Noir" },
                    { 23, "Fantasy Adventure" },
                    { 24, "Romantic Comedy" },
                    { 25, "Psychological Thriller" },
                    { 26, "Slasher" },
                    { 27, "Parody" },
                    { 28, "Post-Apocalyptic" },
                    { 29, "Found Footage" },
                    { 30, "Martial Arts" },
                    { 31, "Spy" },
                    { 32, "Disaster" },
                    { 33, "Dark Comedy" },
                    { 34, "Teen" },
                    { 35, "Gothic Horror" },
                    { 36, "Cyberpunk" },
                    { 37, "Steampunk" },
                    { 38, "Space Opera" },
                    { 39, "Time Travel" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "ManufacturerID", "Name" },
                values: new object[,]
                {
                    { 1, "Orville Redenbacher’s" },
                    { 2, "Act II" },
                    { 3, "Lay’s" },
                    { 4, "Pringles" },
                    { 5, "Doritos" },
                    { 6, "Cheetos" },
                    { 7, "Ruffles" },
                    { 8, "Tostitos" },
                    { 9, "M&M’s" },
                    { 10, "Snickers" },
                    { 11, "Twix" },
                    { 12, "Reese’s" },
                    { 13, "KitKat" },
                    { 14, "Nestlé" },
                    { 15, "Haribo" },
                    { 16, "Sour Patch Kids" },
                    { 17, "Skittles" },
                    { 18, "Coca-Cola" },
                    { 19, "Pepsi" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "ManufacturerID", "Name" },
                values: new object[,]
                {
                    { 20, "Sprite" },
                    { 21, "Fanta" },
                    { 22, "Dr. Pepper" },
                    { 23, "7UP" },
                    { 24, "Red Bull" },
                    { 25, "Ben & Jerry’s" },
                    { 26, "Häagen-Dazs" },
                    { 27, "Magnum" },
                    { 28, "Boomchickapop" },
                    { 29, "Smartfood" },
                    { 30, "Pop Secret" },
                    { 31, "Kernel Season’s" },
                    { 32, "Blue Bell" },
                    { 33, "Kind Bars" },
                    { 34, "Nature Valley" },
                    { 35, "Clif Bars" },
                    { 36, "Veggie Straws" },
                    { 37, "Bare Snacks" },
                    { 38, "Jolly Time" },
                    { 39, "Mars" },
                    { 40, "Trolli" },
                    { 41, "Mondelez International" },
                    { 42, "Frito-Lay" },
                    { 43, "Dr Pepper Snapple Group" },
                    { 44, "Unilever" },
                    { 45, "Blue Bell Creameries" },
                    { 46, "Kellogg's" }
                });

            migrationBuilder.InsertData(
                table: "MovieType",
                columns: new[] { "MovieTypeID", "Type" },
                values: new object[,]
                {
                    { 1, "2D" },
                    { 2, "3D" },
                    { 3, "IMAX" },
                    { 4, "4DX" },
                    { 5, "ScreenX" },
                    { 6, "D-Box" },
                    { 7, "Dolby Vision" },
                    { 8, "Dolby Atmos" },
                    { 9, "HFR (High Frame Rate)" },
                    { 10, "VR (Virtual Reality)" }
                });

            migrationBuilder.InsertData(
                table: "ProductionHouse",
                columns: new[] { "ProductionHouseID", "Name" },
                values: new object[,]
                {
                    { 1, "Warner Bros." },
                    { 2, "Universal Pictures" },
                    { 3, "20th Century Studios" },
                    { 4, "Paramount Pictures" },
                    { 5, "Walt Disney Pictures" }
                });

            migrationBuilder.InsertData(
                table: "ProductionHouse",
                columns: new[] { "ProductionHouseID", "Name" },
                values: new object[,]
                {
                    { 6, "Columbia Pictures" },
                    { 7, "Sony Pictures" },
                    { 8, "Lionsgate" },
                    { 9, "Metro-Goldwyn-Mayer (MGM)" },
                    { 10, "New Line Cinema" },
                    { 11, "DreamWorks Pictures" },
                    { 12, "Warner Independent Pictures" },
                    { 13, "Fox Searchlight Pictures" },
                    { 14, "A24" },
                    { 15, "Lionsgate Films" },
                    { 16, "Blumhouse Productions" },
                    { 17, "TriStar Pictures" },
                    { 18, "Legendary Entertainment" },
                    { 19, "Focus Features" },
                    { 20, "Studio Ghibli" },
                    { 21, "Paramount Vantage" },
                    { 22, "Village Roadshow Pictures" },
                    { 23, "New Regency Productions" },
                    { 24, "Amblin Entertainment" },
                    { 25, "Castle Rock Entertainment" },
                    { 26, "The Weinstein Company" },
                    { 27, "Miramax Films" },
                    { 28, "Aardman Animations" },
                    { 29, "Blue Sky Studios" },
                    { 30, "Pixar Animation Studios" },
                    { 31, "The Walt Disney Company" },
                    { 32, "Illumination Entertainment" },
                    { 33, "GK Films" },
                    { 34, "Bleecker Street" },
                    { 35, "Open Road Films" },
                    { 36, "Film4 Productions" },
                    { 37, "STX Entertainment" },
                    { 38, "Pathé" },
                    { 39, "Cineplex Entertainment" },
                    { 40, "Toho" },
                    { 41, "The Asylum" },
                    { 42, "United Artists" },
                    { 43, "TriStar Pictures" },
                    { 44, "Castle Rock Entertainment" },
                    { 45, "Broad Green Pictures" },
                    { 46, "FilmDistrict" },
                    { 47, "Hammer Films" }
                });

            migrationBuilder.InsertData(
                table: "ProductionHouse",
                columns: new[] { "ProductionHouseID", "Name" },
                values: new object[,]
                {
                    { 48, "Lions Gate Entertainment" },
                    { 49, "Sam Raimi's Ghost House Pictures" },
                    { 50, "Sundance Institute" },
                    { 51, "Shudder" },
                    { 52, "Aardman Animations" },
                    { 53, "Laika Studios" },
                    { 54, "Constantin Film" },
                    { 55, "DreamWorks Animation" },
                    { 56, "Saban Films" },
                    { 57, "Blue Sky Studios" },
                    { 58, "Walt Disney Television Animation" },
                    { 59, "Warner Bros. Animation" },
                    { 60, "Big Beach Films" },
                    { 61, "Pinewood Studios" },
                    { 62, "Boll KG" },
                    { 63, "Red Hour Films" },
                    { 64, "MadRiver Pictures" },
                    { 65, "Ink Factory" },
                    { 66, "Crackle" },
                    { 67, "Elevation Pictures" },
                    { 68, "Nighthawk Pictures" },
                    { 69, "Wild Bunch" },
                    { 70, "Yash Raj Films" },
                    { 71, "Eros International" },
                    { 72, "T-Series" },
                    { 73, "Balaji Telefilms" },
                    { 74, "Reliance Entertainment" },
                    { 75, "Fox Film Corporation" },
                    { 76, "Filmax" },
                    { 77, "Cineworld" },
                    { 78, "Polygon Pictures" },
                    { 79, "StudioCanal" },
                    { 80, "Bauer Media Group" },
                    { 81, "Koch Media" },
                    { 82, "IFC Films" },
                    { 83, "Tokyo Movie Shinsha" },
                    { 84, "Toei Animation" },
                    { 85, "Shinji Aramaki" },
                    { 86, "Manga Entertainment" },
                    { 87, "Studio Ponoc" },
                    { 88, "Toho Company" },
                    { 89, "Sega Sammy Holdings" }
                });

            migrationBuilder.InsertData(
                table: "ProductionHouse",
                columns: new[] { "ProductionHouseID", "Name" },
                values: new object[,]
                {
                    { 90, "Marvel Studios" },
                    { 91, "DC Films" },
                    { 92, "Pixar Animation Studios" },
                    { 93, "Studio Ghibli" },
                    { 94, "The Jim Henson Company" },
                    { 95, "Legendary Entertainment" },
                    { 96, "Blumhouse Productions" },
                    { 97, "Bad Robot Productions" },
                    { 98, "Chernin Entertainment" },
                    { 99, "Silver Pictures" },
                    { 100, "Platinum Dunes" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "ManufacturerID", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Orville Redenbacher’s Popcorn", 3.5 },
                    { 2, 2, "Act II Popcorn", 2.5 },
                    { 3, 3, "Lay’s Potato Chips", 1.99 },
                    { 4, 4, "Pringles Chips", 2.9900000000000002 },
                    { 5, 5, "Doritos Nachos", 2.4900000000000002 },
                    { 6, 6, "Cheetos Cheese Puffs", 1.8899999999999999 },
                    { 7, 7, "Ruffles Potato Chips", 2.9900000000000002 },
                    { 8, 8, "Tostitos Tortilla Chips", 3.29 },
                    { 9, 9, "M&M’s Chocolate Candies", 4.0 },
                    { 10, 10, "Snickers Bars", 1.5 },
                    { 11, 11, "Twix Bars", 1.7 },
                    { 12, 12, "Reese’s Peanut Butter Cups", 1.6000000000000001 },
                    { 13, 13, "KitKat Bars", 1.3999999999999999 },
                    { 14, 14, "Nestlé Chocolate", 2.2000000000000002 },
                    { 15, 15, "Haribo Gummy Bears", 2.5 },
                    { 16, 16, "Sour Patch Kids", 1.8 },
                    { 17, 17, "Skittles Candy", 2.0 },
                    { 18, 18, "Coca-Cola Soft Drink", 1.2 },
                    { 19, 19, "Pepsi Soft Drink", 1.2 },
                    { 20, 20, "Sprite Soft Drink", 1.1000000000000001 },
                    { 21, 21, "Fanta Soft Drink", 1.1000000000000001 },
                    { 22, 22, "Dr. Pepper Soft Drink", 1.3 },
                    { 23, 23, "7UP Soft Drink", 1.1000000000000001 },
                    { 24, 24, "Red Bull Energy Drink", 2.5 },
                    { 25, 25, "Ben & Jerry’s Ice Cream", 5.0 },
                    { 26, 26, "Häagen-Dazs Ice Cream", 5.5 },
                    { 27, 27, "Magnum Ice Cream", 4.5 },
                    { 28, 28, "Boomchickapop Popcorn", 3.0 },
                    { 29, 29, "Smartfood Popcorn", 3.5 },
                    { 30, 30, "Pop Secret Popcorn", 2.75 },
                    { 31, 31, "Kernel Season’s Popcorn Seasoning", 1.5 },
                    { 32, 32, "Blue Bell Ice Cream", 4.75 },
                    { 33, 33, "Kind Bars", 2.0 },
                    { 34, 34, "Nature Valley Granola Bars", 2.5 },
                    { 35, 35, "Clif Bars", 2.2000000000000002 },
                    { 36, 36, "Veggie Straws", 3.0 },
                    { 37, 37, "Bare Snacks", 2.7999999999999998 },
                    { 38, 38, "Jolly Time Popcorn", 2.5 },
                    { 39, 39, "Mars Chocolate", 1.8999999999999999 },
                    { 40, 40, "Trolli Gummy Worms", 1.8 },
                    { 41, 41, "Mondelez International Snacks", 2.5 },
                    { 42, 42, "Frito-Lay Chips", 3.0 }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductID", "ManufacturerID", "Name", "Price" },
                values: new object[,]
                {
                    { 43, 43, "Dr Pepper Snapple Group Drinks", 1.3999999999999999 },
                    { 44, 44, "Unilever Snacks", 2.6000000000000001 },
                    { 45, 45, "Blue Bell Creameries Ice Cream", 4.7999999999999998 },
                    { 46, 46, "Kellogg's Snacks", 2.2999999999999998 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_CityID",
                table: "Account",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_GenderID",
                table: "Account",
                column: "GenderID");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_DirectorID",
                table: "Movie",
                column: "DirectorID");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_ProductionHouseID",
                table: "Movie",
                column: "ProductionHouseID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_ActorID",
                table: "MovieActor",
                column: "ActorID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActor_MovieID",
                table: "MovieActor",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_GenreID",
                table: "MovieGenre",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_MovieID",
                table: "MovieGenre",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductID",
                table: "Order",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserID",
                table: "Order",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ManufacturerID",
                table: "Product",
                column: "ManufacturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Projection_CinemaHallID",
                table: "Projection",
                column: "CinemaHallID");

            migrationBuilder.CreateIndex(
                name: "IX_Projection_MovieID",
                table: "Projection",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Projection_MovieTypeID",
                table: "Projection",
                column: "MovieTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_MovieID",
                table: "Review",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Review_UserID",
                table: "Review",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_CinemaHallID",
                table: "Seat",
                column: "CinemaHallID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ProjectionID",
                table: "Ticket",
                column: "ProjectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SeatID",
                table: "Ticket",
                column: "SeatID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UserID",
                table: "Ticket",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieActor");

            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Actor");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Projection");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Gender");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "MovieType");

            migrationBuilder.DropTable(
                name: "CinemaHall");

            migrationBuilder.DropTable(
                name: "Director");

            migrationBuilder.DropTable(
                name: "ProductionHouse");
        }
    }
}