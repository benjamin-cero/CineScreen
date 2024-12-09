using FIT_Api_Example.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace FIT_Api_Example.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(
      DbContextOptions options) : base(options)
        {
        }

        // public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }
        // public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        // public DbSet<StudentPredmet> StudentPredmet { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<CinemaHall> CinemaHall { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieActor> MovieActor { get; set; }
        public DbSet<MovieType> MovieType { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<ProductionHouse> ProductionHouse { get; set; }
        public DbSet<Projection> Projection { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<MovieProductionHouse> MovieProductionHouse { get; set; }
        public DbSet<MovieDirector> MovieDirector { get; set; }
        public DbSet<Status> Status { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}