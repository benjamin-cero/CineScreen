﻿
using CineScreen.Data;
using CineScreen.Data.Models.TenantSpecificTables.Auth;
using CineScreen.Services;
using RS1_2024_25.API.Helper;

namespace CineScreen.Services;

public class MyAuthService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor) : IMyAuthService
{

    // Generisanje novog tokena za korisnika
    public async Task<MyAuthenticationToken> GenerateSaveAuthToken(MyAppUser user, CancellationToken cancellationToken = default) => await MyAuthServiceHelper.GenerateSaveAuthToken(
            httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString(),
            applicationDbContext,
            user,
            cancellationToken
            );

    // Uklanjanje tokena iz baze podataka
    public async Task<bool> RevokeAuthToken(string tokenValue, CancellationToken cancellationToken = default) => await MyAuthServiceHelper.RevokeAuthToken(applicationDbContext, tokenValue, cancellationToken);

    // Dohvatanje informacija o autentifikaciji korisnika
    public MyAuthInfo GetAuthInfoFromTokenString(string? authToken) => MyAuthServiceHelper.GetAuthInfoFromTokenString(applicationDbContext, authToken);

    // Dohvatanje informacija o autentifikaciji korisnika
    public MyAuthInfo GetAuthInfoFromRequest() => MyAuthServiceHelper.GetAuthInfoFromRequest(applicationDbContext, httpContextAccessor);

    public MyAuthInfo GetAuthInfoFromTokenModel(MyAuthenticationToken? myAuthToken) => MyAuthServiceHelper.GetAuthInfoFromTokenModel(myAuthToken);
}

