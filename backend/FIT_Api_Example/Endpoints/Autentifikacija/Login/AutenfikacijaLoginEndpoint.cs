using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.Helper;
using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.Autentifikacija.Login
{
    public class AutenfikacijaLoginEndpoint : MyBaseEndpoint<AutenfikacijaLoginRequest, AutenfikacijaLoginResponse>
    {
        [HttpPost]
        public override AutenfikacijaLoginResponse MyAction([FromBody] AutenfikacijaLoginRequest request)
        {
            //KorisnickiNalog? logiraniKorisnik = _dbContext.KorisnickiNalog
            //    .FirstOrDefault(k =>
            //        k.KorisnickoIme == request.KorisnickoIme && k.Lozinka == request.Lozinka);

            //if (logiraniKorisnik == null)
            //{
            //    //pogresan username i password
            //    return new AutenfikacijaLoginResponse
            //    {
            //        Informacije  = new MyAuthTokenExtension.LoginInformacije(null)
            //    };
            //}

            ////2- generisati random string
            //string randomString = TokenGenerator.Generate(10);

            ////3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
            //var noviToken = new AutentifikacijaToken()
            //{
            //    ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
            //    vrijednost = randomString,
            //    korisnickiNalog = logiraniKorisnik,
            //    vrijemeEvidentiranja = DateTime.Now
            //};

            //_dbContext.Add(noviToken);
            //_dbContext.SaveChanges();

            ////4- vratiti token string
            //return new AutenfikacijaLoginResponse
            //{
            //    Informacije = new MyAuthTokenExtension.LoginInformacije(noviToken)
            //};

            return null;
        }
    }
}
