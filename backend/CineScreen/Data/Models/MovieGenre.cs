using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models
{
    public class MovieGenre
    {
        public int MovieGenreID { get; set; }
        public int MovieID { get; set; }
        [ForeignKey(nameof(MovieID))]
        public Movie Movie { get; set; }
        public int GenreID { get; set; }
        [ForeignKey(nameof(GenreID))]
        public Genre Genre { get; set; }
    }
}
