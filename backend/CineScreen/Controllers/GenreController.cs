using CineScreen.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;
using RS1_2024_25.API.Services;

namespace FIT_Api_Example.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GenreController(ApplicationDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Genre>> Get()
        {
            var genres = dbContext.Genre.ToList();

            if (genres == null)
            {
                return NotFound();
            }

            return genres;
        }
        [HttpGet("GenreID")]
        public ActionResult<Genre> GetById(int GenreID)
        {
            var Genre = dbContext.Genre.Find(GenreID);
            if (Genre == null)
            {
                return NotFound();
            }

            return Genre;
        }

        [HttpDelete("GenreID")]
        public ActionResult<Genre> Delete(int GenreID) {
            var Genre = dbContext.Genre.Find(GenreID);


            if (Genre == null)
            {
                return NotFound();
            }
            dbContext.Genre.Remove(Genre);
            dbContext.SaveChanges();
            return Genre;
        }
        [HttpPost]
        public ActionResult<Genre> Insert([FromBody] GenreUpsertVM x)
        {
            var NewGenre = new Genre()
            {
                Name = x.Name
            };
            dbContext.Genre.Add(NewGenre);
            dbContext.SaveChanges();
            return NewGenre;
        }

        [HttpPut("GenreID")]
        public ActionResult<Genre> Update(int GenreID, GenreUpsertVM x)
        {
            var UpdateGenre = dbContext.Genre.Find(GenreID);
            if(UpdateGenre == null)
            {
                return NotFound();
            }
            UpdateGenre.Name = x.Name;
            dbContext.SaveChanges();
            return UpdateGenre;
        }


    }
}
