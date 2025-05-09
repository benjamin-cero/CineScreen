﻿using Azure.Core;
using CineScreen.Data;
using CineScreen.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineScreen.Services;
using System.Threading;
using System.Threading.Tasks;
using static CineScreen.Endpoints.AuthEndpoints.AuthLogoutEndpoint;
using CineScreen.Helper.Api;

namespace CineScreen.Endpoints.AuthEndpoints;

[Route("auth")]
public class AuthLogoutEndpoint(ApplicationDbContext db, MyAuthService authService) : MyEndpointBaseAsync
    .WithoutRequest
    .WithResult<LogoutResponse>
{
    [HttpPost("logout")]
    public override async Task<LogoutResponse> HandleAsync(CancellationToken cancellationToken = default)
    {
        // Dohvatanje tokena iz headera
        string? authToken = Request.Headers["my-auth-token"];

        if (string.IsNullOrEmpty(authToken))
        {
            return new LogoutResponse
            {
                IsSuccess = false,
                Message = "Token is missing in the request header."
            };
        }

        // Pokušaj revokacije tokena
        bool isRevoked = await authService.RevokeAuthToken(authToken, cancellationToken);

        return new LogoutResponse
        {
            IsSuccess = isRevoked,
            Message = isRevoked ? "Logout successful." : "Invalid token or already logged out."
        };
    }

    public class LogoutResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
