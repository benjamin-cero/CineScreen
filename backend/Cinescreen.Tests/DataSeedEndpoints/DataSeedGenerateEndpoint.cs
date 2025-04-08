namespace Cinescreen.Tests.DataSeedEndpoints;

using CineScreen.Data;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Data.Models.TenantSpecificTables.Auth;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

[Route("data-seed")]
public class DataSeedGenerateEndpoint(ApplicationDbContext db)
    : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<string>
{
    [HttpPost]
    public override async Task<string> HandleAsync(CancellationToken cancellationToken = default)
    {
        if (db.MyAppUsersAll.Any())
        {
            return "Podaci su vec generisani";
        }


        // Kreiranje tenant-a (univerziteta)
        var tenants = new List<Tenant>
        {
           new Tenant {
                      Name = "Cinestar", DatabaseConnection = "db_conn_cinestar", ServerAddress = "192.168.1.1" },
                  new Tenant {
                      Name = "Cineplexx", DatabaseConnection = "db_conn_cineplexx", ServerAddress = "192.168.1.2" }
        };

        await db.Tenants.AddRangeAsync(tenants, cancellationToken);

        await db.SaveChangesAsync(cancellationToken);

        db.CurrentTenantId = tenants[0].ID;


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

        // Kreiranje korisnika s ulogama
        var users = new List<MyAppUser>
        {
           new MyAppUser
                {
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
        };

        var cities = new List<City>
        {
              new City { Name = "Banja Luka" },
                  new City { Name = "Bihać" },
                  new City { Name = "Bijeljina" },
                  new City { Name = "Bosnaska Krupa" },
                  new City { Name = "Cazin" },
                  new City { Name = "Čapljina" },
                  new City { Name = "Drventa" }

        };




        // Dodavanje podataka u bazu    
        await db.AddRangeAsync(users, cancellationToken);
        await db.AddRangeAsync(cities, cancellationToken);
        await db.SaveChangesAsync(cancellationToken);

        return "Data generation completed successfully.";
    }
}
