using CineScreen.Data;
using CineScreen.Helper;
using CineScreen.Helper.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CineScreen.Endpoints.StudentEndpoints.StudentGetAllEndpoint;

namespace CineScreen.Endpoints.StudentEndpoints;

// Endpoint za vraćanje liste studenata s filtriranjem i paginacijom
[Route("students")]
public class StudentGetAllEndpoint(ApplicationDbContext db) : MyEndpointBaseAsync
    .WithRequest<StudentGetAllRequest>
    .WithResult<MyPagedList<StudentGetAllResponse>>
{
    [HttpGet("filter")]
    public override async Task<MyPagedList<StudentGetAllResponse>> HandleAsync([FromQuery] StudentGetAllRequest request, CancellationToken cancellationToken = default)
    {
        // Osnovni upit za studente
        var query = db.MyAppUsers
                   .AsQueryable();

        // Primjena filtera po imenu, prezimenu, student broju ili državi
        if (!string.IsNullOrWhiteSpace(request.Q))
        {
            query = query.Where(s =>
                s.FirstName.Contains(request.Q) ||
                s.LastName.Contains(request.Q) ||
                s.Email.Contains(request.Q) 
            );
        }

        // Projektovanje u DTO tip za rezultat
        var projectedQuery = query.Select(s => new StudentGetAllResponse
        {
            ID = s.ID,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email,

        });

        // Kreiranje paginiranog rezultata
        var result = await MyPagedList<StudentGetAllResponse>.CreateAsync(projectedQuery, request, cancellationToken);

        return result;
    }

    // DTO za zahtjev s podrškom za paginaciju i filtriranje
    public class StudentGetAllRequest : MyPagedRequest
    {
        public string? Q { get; set; } = string.Empty; // Tekstualni upit za pretragu
    }

    // DTO za odgovor
    public class StudentGetAllResponse
    {
        public required int ID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
    }
}
