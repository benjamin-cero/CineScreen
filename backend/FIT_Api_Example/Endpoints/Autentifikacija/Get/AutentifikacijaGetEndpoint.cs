using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Endpoints.Autentifikacija.Logout;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.Autentifikacija.Get
{

    public class AutentifikacijaGetEndpoint : MyBaseEndpoint<AutentifikacijaGetRequest, AutentifikacijaGetResponse>
    {

        [HttpGet]
        public override AutentifikacijaGetResponse MyAction([FromBody] AutentifikacijaGetRequest request)
        {
            AutentifikacijaToken? autentifikacijaToken = HttpContext.GetAuthToken();

            return new AutentifikacijaGetResponse
            {
                Token = autentifikacijaToken
            };

        }
    }
}
