using Cinescreen.Tests.DataSeedEndpoints;
using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

public static class TestApplicationDbContext
{
    public static async Task<ApplicationDbContext> CreateAsync()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Svaki test ima unikatni naziv baze
            .Options;

        IHttpContextAccessor httpContextAccessor = TestHttpContextAccessorHelper.CreateWithValidAuthToken();

        var dbContext = new ApplicationDbContext(options, httpContextAccessor);

        // Pokretanje seeder-a
        var seeder = new DataSeedGenerateEndpoint(dbContext);
        await seeder.HandleAsync();

        // Dodavanje testnog tokena
        var user = await dbContext.MyAppUsersAll.FirstAsync();

        var token = new MyAuthenticationToken
        {
            MyAppUser = user,
            Value = TestHttpContextAccessorHelper.ValidTokenValue,
            RecordedAt = DateTime.Now,
            TenantId = user.TenantId
        };

        await dbContext.MyAuthenticationTokensAll.AddAsync(token);
        await dbContext.SaveChangesAsync();

        return dbContext;
    }


}
