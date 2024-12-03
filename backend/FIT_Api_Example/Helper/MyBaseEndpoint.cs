using FIT_Api_Example.Data;
using FIT_Api_Example.Modul2_IspitOcjene;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace FIT_Api_Example.Helper
{
    [ApiController]
    [Route("[controller]")]
    public abstract class MyBaseEndpoint<TRequest, TResponse> : ControllerBase
    {
        protected readonly ApplicationDbContext _dbContext;

        protected MyBaseEndpoint()
        {
            _dbContext = HttpContext.RequestServices.GetService<ApplicationDbContext>()!;
        }

        public abstract TResponse MyAction(TRequest request);

    }
}
