﻿using CineScreen.Data;
using CineScreen.Endpoints.CityEndpoints;
using CineScreen.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

public class CityUpdateOrInsertEndpointTests
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMyAuthService _authService;
    private readonly CityUpdateOrInsertEndpoint _endpoint;

    public CityUpdateOrInsertEndpointTests()
    {
        // Kreiranje TestApplicationDbContext sa seedanim podacima
        _dbContext = TestApplicationDbContext.CreateAsync().GetAwaiter().GetResult();

        // Inicijalizacija auth servisa
        _authService = new MyAuthService(_dbContext, TestHttpContextAccessorHelper.CreateWithValidAuthToken());

        // Inicijalizacija endpoint-a
        _endpoint = new CityUpdateOrInsertEndpoint(_dbContext, _authService);
    }

    [Fact]
    public async Task Should_Insert_New_City_When_Request_Is_Valid()
    {
        // Arrange
        var request = new CityUpdateOrInsertEndpoint.CityUpdateOrInsertRequest
        {
            Name = "New City",

        };

        // Act
        var result = await _endpoint.HandleAsync(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var response = Assert.IsType<CityUpdateOrInsertEndpoint.CityUpdateOrInsertResponse>(okResult.Value);

        Assert.Equal(request.Name, response.Name);

    }

    [Fact]
    public async Task Should_Update_Existing_City_When_Request_Is_Valid()
    {
        // Arrange
        var existingCity = await _dbContext.Cities.FirstAsync();
        var request = new CityUpdateOrInsertEndpoint.CityUpdateOrInsertRequest
        {
            ID = existingCity.ID,
            Name = "Updated City",

        };

        // Act
        var result = await _endpoint.HandleAsync(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var response = Assert.IsType<CityUpdateOrInsertEndpoint.CityUpdateOrInsertResponse>(okResult.Value);

        Assert.Equal(request.ID, response.ID);
        Assert.Equal(request.Name, response.Name);
    }

    [Fact]
    public async Task Should_Return_NotFound_When_City_To_Update_Does_Not_Exist()
    {
        // Arrange
        var request = new CityUpdateOrInsertEndpoint.CityUpdateOrInsertRequest
        {
            ID = 999999, // ID koji ne postoji
            Name = "Non-existing City",

        };

        // Act
        var result = await _endpoint.HandleAsync(request);

        // Assert
        Assert.IsType<NotFoundObjectResult>(result.Result);
    }

    [Fact]
    public async Task Should_Return_Unauthorized_When_User_Is_Not_Logged_In()
    {
        // Arrange
        var invalidAuthService = new MyAuthService(_dbContext, TestHttpContextAccessorHelper.CreateWithInvalidAuthToken());
        var endpointWithInvalidAuth = new CityUpdateOrInsertEndpoint(_dbContext, invalidAuthService);

        var request = new CityUpdateOrInsertEndpoint.CityUpdateOrInsertRequest
        {
            Name = "New City",

        };

        // Act
        var result = await endpointWithInvalidAuth.HandleAsync(request);

        // Assert
        Assert.IsType<UnauthorizedResult>(result.Result);
    }
}
