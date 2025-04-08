using CineScreen.Data;
using CineScreen.Endpoints.CityEndpoints;
using FluentValidation.TestHelper;

public class CityUpdateOrInsertValidatorTests
{
    private readonly ApplicationDbContext _dbContext;
    private readonly CityUpdateOrInsertValidator _validator;

    public CityUpdateOrInsertValidatorTests()
    {
        // Kreiranje TestApplicationDbContext
        _dbContext = TestApplicationDbContext.CreateAsync().GetAwaiter().GetResult();

        // Kreiraj validator
        _validator = new CityUpdateOrInsertValidator(_dbContext);
    }

    [Fact]
    public async Task Should_Have_Error_When_Name_Is_Empty()
    {


        // Testira da li validator vraća grešku za prazan Name.
        var request = new CityUpdateOrInsertEndpoint.CityUpdateOrInsertRequest
        {
            Name = "",
        };

        var result = await _validator.TestValidateAsync(request);
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public async Task Should_Not_Have_Error_When_Request_Is_Valid()
    { 

        // Testira validan zahtjev (bez grešaka).
        var request = new CityUpdateOrInsertEndpoint.CityUpdateOrInsertRequest
        {
            Name = "Test City",

        };

        var result = await _validator.TestValidateAsync(request);
        result.ShouldNotHaveAnyValidationErrors();
    }




}
