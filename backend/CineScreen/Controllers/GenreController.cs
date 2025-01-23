using Azure.Core;
using FIT_Api_Example.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class GenreController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public GenreController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Genre>> Get()
        {
            var genres = _dbContext.Genre.ToList();

            if (genres == null)
            {
                return NotFound();
            }

            return genres;
        }
        [HttpGet("GenreID")]
        public ActionResult<Genre> GetById(int GenreID)
        {
            var Genre = _dbContext.Genre.Find(GenreID);
            if (Genre == null)
            {
                return NotFound();
            }

            return Genre;
        }

        [HttpDelete("GenreID")]
        public ActionResult<Genre> Delete(int GenreID) {
            var Genre = _dbContext.Genre.Find(GenreID);


            if (Genre == null)
            {
                return NotFound();
            }
            _dbContext.Genre.Remove(Genre);
            _dbContext.SaveChanges();
            return Genre;
        }
        [HttpPost]
        public ActionResult<Genre> Insert([FromBody] GenreUpsertVM x)
        {
            var NewGenre = new Genre()
            {
                Name = x.Name
            };
            _dbContext.Genre.Add(NewGenre);
            _dbContext.SaveChanges();
            return NewGenre;
        }

        [HttpPut("GenreID")]
        public ActionResult<Genre> Update(int GenreID, GenreUpsertVM x)
        {
            var UpdateGenre = _dbContext.Genre.Find(GenreID);
            if(UpdateGenre == null)
            {
                return NotFound();
            }
            UpdateGenre.Name = x.Name;
            _dbContext.SaveChanges();
            return UpdateGenre;
        }


    }
}
