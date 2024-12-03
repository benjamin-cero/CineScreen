using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.Autentifikacija.Logout
{

    public class AutentifikacijaLogoutEndpoint : MyBaseEndpoint<AutentifikacijaLogoutRequest, AutentifikacijaLogoutResponse>
    {
 
        [HttpPost]
        public override AutentifikacijaLogoutResponse MyAction([FromBody] AutentifikacijaLogoutRequest request)
        {
            AutentifikacijaToken? autentifikacijaToken = HttpContext.GetAuthToken();

            if (autentifikacijaToken == null)
                return new ();

            _dbContext.Remove(autentifikacijaToken);
            _dbContext.SaveChanges();
            return new ();
        }
    }
}
