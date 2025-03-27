using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Data.Models.TenantSpecificTables.Auth;
using CineScreen.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using CineScreen.Helper;

namespace CineScreen.Services
{
    public class MyAuthService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor, MyTokenGenerator myTokenGenerator)
    {

        // Generisanje novog tokena za korisnika
        public async Task<MyAuthenticationToken> GenerateSaveAuthToken(MyAppUser user, CancellationToken cancellationToken = default)
        {
            string randomToken = myTokenGenerator.Generate(10);

            var authToken = new MyAuthenticationToken
            {
                IpAddress = httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? string.Empty,
                Value = randomToken,
                MyAppUser = user,
                RecordedAt = DateTime.Now,
                TenantId = user.TenantId,
            };

            applicationDbContext.Add(authToken);
            await applicationDbContext.SaveChangesAsync(cancellationToken);

            return authToken;
        }

        // Uklanjanje tokena iz baze podataka
        public async Task<bool> RevokeAuthToken(string tokenValue, CancellationToken cancellationToken = default)
        {
            var authToken = await applicationDbContext.MyAuthenticationTokens
                .FirstOrDefaultAsync(t => t.Value == tokenValue, cancellationToken);

            if (authToken == null)
                return false;

            applicationDbContext.Remove(authToken);
            await applicationDbContext.SaveChangesAsync(cancellationToken);

            return true;
        }

        // Dohvatanje informacija o autentifikaciji korisnika
        public MyAuthInfo GetAuthInfoFromTokenString(string? authToken)
        {
            if (string.IsNullOrEmpty(authToken))
            {
                return GetAuthInfoFromTokenModel(null);
            }

            MyAuthenticationToken? myAuthToken = applicationDbContext.MyAuthenticationTokens
                .IgnoreQueryFilters()
                .Include(x => x.MyAppUser!.Tenant)
                .SingleOrDefault(x => x.Value == authToken);

            return GetAuthInfoFromTokenModel(myAuthToken);
        }


        // Dohvatanje informacija o autentifikaciji korisnika
        public MyAuthInfo GetAuthInfoFromRequest()
        {
            string? authToken = httpContextAccessor.HttpContext?.Request.Headers["my-auth-token"];
            return GetAuthInfoFromTokenString(authToken);
        }

        public MyAuthInfo GetAuthInfoFromTokenModel(MyAuthenticationToken? myAuthToken)
        {
            if (myAuthToken == null)
            {
                return new MyAuthInfo
                {
                    IsAdmin = false,
                    IsUser = false,
                    IsLoggedIn = false,
                };
            }

            return new MyAuthInfo
            {
                UserId = myAuthToken.MyAppUserId,
                Email = myAuthToken.MyAppUser!.Email,
                FirstName = myAuthToken.MyAppUser.FirstName,
                LastName = myAuthToken.MyAppUser.LastName,
                IsAdmin = myAuthToken.MyAppUser.IsAdmin,
                IsUser = myAuthToken.MyAppUser.IsUser,
                IsLoggedIn = true,
                Tenant = myAuthToken.MyAppUser.Tenant,
                TenantId = myAuthToken.MyAppUser.TenantId,
            };
        }
    }

    // DTO to hold authentication information
    public class MyAuthInfo
    {
        public int TenantId { get; set; }
        [JsonIgnore]
        public Tenant? Tenant { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsUser { get; set; }

        public bool IsLoggedIn { get; set; }
        public string SlikaPath { get; set; }
    }
}
