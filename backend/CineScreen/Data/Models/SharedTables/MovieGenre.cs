using CineScreen.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineScreen.Data.Models.SharedTables
{
    public class MovieGenre : SharedTableBase
    {
        public int MovieID { get; set; }
        [ForeignKey(nameof(MovieID))]
        public Movie Movie { get; set; }
        public int GenreID { get; set; }
        [ForeignKey(nameof(GenreID))]
        public Genre Genre { get; set; }
    }
}
