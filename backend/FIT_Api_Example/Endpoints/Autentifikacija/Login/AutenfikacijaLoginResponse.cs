using FIT_Api_Example.Helper.AutentifikacijaAutorizacija;

namespace FIT_Api_Example.Endpoints.Autentifikacija.Login
{
    public class AutenfikacijaLoginResponse
    {
        public MyAuthTokenExtension.LoginInformacije Informacije { get; set; }
    }
}
