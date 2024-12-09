using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models
{
    public class MovieDirector
    {
        [Key]
        public int MovieDirectorID { get; set; }
        public int MovieID { get; set; }
        [ForeignKey(nameof(MovieID))]
        public Movie Movie { get; set; }
        public int DirectorID { get; set; }
        [ForeignKey(nameof(DirectorID))]
        public Director Director { get; set; }
    }
}
