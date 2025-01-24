using CineScreen.Data;
using FIT_Api_Example.Data.Models;
using FIT_Api_Example.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ReviewController(ApplicationDbContext _DbContext) : ControllerBase
    {

        [HttpGet]

        public ActionResult<List<Review>> Get()
        {
            var review = _DbContext.Review.ToList();

            if (review == null)
            {
                return NotFound();
            }
            return review;
        }

        [HttpGet("ReviewID")]

        public ActionResult<Review> GetById(int ReviewId)
        {
            var review = _DbContext.Review.Find(ReviewId);
            if (review == null)
            {
                return NotFound();
            }
            return review;
        }

        [HttpDelete("ReviewID")]

        public ActionResult<Review> Delete(int ReviewId)
        {
            var review = _DbContext.Review.Find(ReviewId);
            if (review == null)
            {
                return NotFound();
            }
            _DbContext.Remove(review);
            _DbContext.SaveChanges();
            return review;
        }

        [HttpPost]

        public ActionResult<Review> Insert([FromBody] ReviewInsertVM x)
        {
            var NewReview = new Review()
            {
               UserID = x.UserID,
               MovieID = x.MovieID,
               Score = x.Score,
               Comment = x.Comment,
               ReviewDate = DateTime.Now,
            };
            _DbContext.Review.Add(NewReview);
            _DbContext.SaveChanges();
            return NewReview;
        }

        [HttpPut("ReviewID")]

        public ActionResult<Review> Update(int ReviewId, ReviewUpdateVM x)
        {
            var UpdateReview = _DbContext.Review.Find(ReviewId);
            if (UpdateReview == null)
            {
                return NotFound();
            }
            UpdateReview.Score = x.Score;
            UpdateReview.Comment = x.Comment;
            UpdateReview.ReviewDate = DateTime.Now;
            _DbContext.SaveChanges();
            return UpdateReview;

        }
    }
}
