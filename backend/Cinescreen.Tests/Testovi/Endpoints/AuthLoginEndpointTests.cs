﻿using Xunit;
using Microsoft.AspNetCore.Mvc;
using CineScreen.Data;
using CineScreen.Services;
using CineScreen.Endpoints.AuthEndpoints;

public class AuthLoginEndpointTests
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMyAuthService _authService;
    private readonly AuthLoginEndpoint _authLoginEndpoint;

    public AuthLoginEndpointTests()
    {
        _dbContext = TestApplicationDbContext.CreateAsync().GetAwaiter().GetResult();
        _authService = new MyAuthService(_dbContext, TestHttpContextAccessorHelper.CreateWithValidAuthToken());
        _authLoginEndpoint = new AuthLoginEndpoint(_dbContext, _authService);
    }

    [Fact]
    public async Task Should_Return_Token_When_Valid_Credentials()
    {
        // Arrange
        var request = new AuthLoginEndpoint.LoginRequest
        {
            Email = "adil.joldic@edu.fit.ba",
            Password = "test"
        };

        // Act
        ActionResult<AuthLoginEndpoint.LoginResponse> result = await _authLoginEndpoint.HandleAsync(request);

        // Assert
        OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
        AuthLoginEndpoint.LoginResponse response = Assert.IsType<AuthLoginEndpoint.LoginResponse>(okResult.Value);

        Assert.NotNull(response.Token);
        Assert.NotNull(response.MyAuthInfo);
        Assert.True(response.MyAuthInfo.IsLoggedIn);
        Assert.Equal("adil.joldic@edu.fit.ba", response.MyAuthInfo.Email);
    }

    [Fact]
    public async Task Should_Return_Unauthorized_When_Invalid_Credentials()
    {
        // Arrange
        var request = new AuthLoginEndpoint.LoginRequest
        {
            Email = "admin",
            Password = "wrongpassword"
        };

        // Act
        var result = await _authLoginEndpoint.HandleAsync(request);

        // Assert
        Assert.IsType<UnauthorizedObjectResult>(result.Result);
    }
}
