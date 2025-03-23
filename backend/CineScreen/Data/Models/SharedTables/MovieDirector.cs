using CineScreen.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineScreen.Data.Models.SharedTables
{
    public class MovieDirector : SharedTableBase
    {
        public int MovieID { get; set; }
        [ForeignKey(nameof(MovieID))]
        public Movie Movie { get; set; }
        public int DirectorID { get; set; }
        [ForeignKey(nameof(DirectorID))]
        public Director Director { get; set; }
    }
}
