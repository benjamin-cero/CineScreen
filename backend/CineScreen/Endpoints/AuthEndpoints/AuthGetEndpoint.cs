using Azure;
using CineScreen.Services;
using Microsoft.AspNetCore.Mvc;
using CineScreen.Services;
using System.Threading;
using System.Threading.Tasks;
using static CineScreen.Endpoints.AuthEndpoints.AuthGetEndpoint;
using CineScreen.Helper.Api;

namespace CineScreen.Endpoints.AuthEndpoints
{
    [Route("auth")]
    public class AuthGetEndpoint(MyAuthService authService) : MyEndpointBaseAsync
        .WithoutRequest
        .WithActionResult<AuthGetResponse>
    {
        [HttpGet]
        public override async Task<ActionResult<AuthGetResponse>> HandleAsync(CancellationToken cancellationToken = default)
        {
            // Retrieve user info based on the token
            var authInfo = authService.GetAuthInfoFromRequest();

            if (!authInfo.IsLoggedIn)
            {
                return Unauthorized("Invalid or expired token");
            }

            // Return user information if the token is valid
            return Ok(new AuthGetResponse
            {
                MyAuthInfo = authInfo
            });
        }

        public class AuthGetResponse
        {
            public required MyAuthInfo MyAuthInfo { get; set; }
        }
    }
}
