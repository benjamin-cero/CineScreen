using CineScreen.Data.Models;
using CineScreen.Data.Models.SharedEnums;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Data.Models.TenantSpecificTables.Auth;
using CineScreen.Data.Models.TenantSpecificTables.Basic;
using CineScreen.Helper;
using CineScreen.Helper.BaseClasses;
using CineScreen.Services;
using FIT_Api_Example.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace CineScreen.Data;

public partial class ApplicationDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : DbContext(options)
{

    // Shared tables for all tenants

    public DbSet<Actor> Actors { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }
    public DbSet<MovieDirector> MovieDirectors { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<MovieProductionHouse> MovieProductionHouses { get; set; }
    public DbSet<MovieType> MovieTypes { get; set; }
    public DbSet<ProductionHouse> ProductionHouses { get; set; }
    public DbSet<Tenant> Tenants { get; set; }


    // Tenant Specific Tables with All Data
    public DbSet<MyAppUser> MyAppUsersAll { get; set; }
    public DbSet<MyAuthenticationToken> MyAuthenticationTokensAll { get; set; }
    public DbSet<CinemaHall> CinemaHallsAll { get; set; }
    public DbSet<Menu> MenusAll { get; set; }
    public DbSet<Projection> ProjectionsAll { get; set; }
    public DbSet<Seat> SeatsAll { get; set; }
    public DbSet<Order> OrdersAll { get; set; }
    public DbSet<Review> ReviewsAll { get; set; }
    public DbSet<Ticket> TicketsAll { get; set; }
    public DbSet<MenuManufacturer> MenuManufacturersAll { get; set; }

    // Tenant Specific Tables with Specific Data

    public IQueryable<MyAppUser> MyAppUsers => Set<MyAppUser>().Where(e => e.TenantId == CurrentTenantIdThrowIfFail);
    public IQueryable<MyAuthenticationToken> MyAuthenticationTokens => Set<MyAuthenticationToken>();

    public IQueryable<CinemaHall> CinemaHalls => Set<CinemaHall>();
    public IQueryable<Menu> Menus => Set<Menu>();
    public IQueryable<Projection> Projections => Set<Projection>();
    public IQueryable<Seat> Seats => Set<Seat>();
    public IQueryable<Order> Orders => Set<Order>();
    public IQueryable<Review> Reviews => Set<Review>();
    public IQueryable<Ticket> Tickets => Set<Ticket>();
    public IQueryable<MenuManufacturer> MenuManufacturers => Set<MenuManufacturer>();




    #region METHODS
    public int? _CurrentTenantId = null;

    public int CurrentTenantIdThrowIfFail
    {
        get
        {
            var result = CurrentTenantId;
            if (result == null || result == 0)
            {
                throw new UnauthorizedAccessException();
            }

            return result.Value;
        }
    }
    public int? CurrentTenantId
    {
        get
        {
            if (_CurrentTenantId == null)
            {
                MyAuthInfo myAuthInfo = MyAuthServiceHelper.GetAuthInfoFromRequest(this, httpContextAccessor);
                _CurrentTenantId = myAuthInfo.TenantId;
            }
            return _CurrentTenantId;
        }
        set
        {
            _CurrentTenantId = value;
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.NoAction;
        }

        // opcija kod nasljeđivanja
        // modelBuilder.Entity<NekaBaznaKlasa>().UseTpcMappingStrategy();

        // Iteracija kroz sve entitete u modelu
        // U EF-u defaultno naziv tabele je jednak nazivu dbseta.
        // S obzirom što smo izmjenili nazive dbsetova zbog tenanata i zbog dodatnih queryable
        // onda u narednoj petlji postavljamo da nazivi tabela budu nazivi atributa "table"
        // Ako nema atributa "table" onda se koristi naziv klase.

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var clrType = entityType.ClrType;

            // Provjera da li postoji [Table("TblNekoIme")] atribut
            var tableAttribute = clrType.GetCustomAttributes(typeof(TableAttribute), inherit: false)
                                        .FirstOrDefault() as TableAttribute;

            if (tableAttribute == null)
            {
                // Ako nema TableAttribute, automatski pluralizuj naziv tabele
                var tableName = clrType.Name.Pluralize();
                modelBuilder.Entity(clrType).ToTable(tableName);
            }
            else
            {
                // Ako postoji TableAttribute, koristi navedeni naziv tabele
                modelBuilder.Entity(clrType).ToTable(tableAttribute.Name);
            }
        }
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public override int SaveChanges()
    {
        AddTenantIdToNewEntities();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AddTenantIdToNewEntities();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void AddTenantIdToNewEntities()
    {
        // Iteracija kroz sve promjene u DbContext
        foreach (var entry in ChangeTracker.Entries()
                     .Where(e => e.State == EntityState.Added && e.Entity is TenantSpecificTable))
        {
            // Postavljanje TenantId za nove entitete
            var entity = (TenantSpecificTable)entry.Entity;
            entity.TenantId = CurrentTenantIdThrowIfFail;
        }
    }
    #endregion


}