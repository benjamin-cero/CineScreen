using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models
{
    public class MovieActor
    {
        [Key]
        public int MovieActorID { get; set; }
        public int MovieID { get; set; }
        [ForeignKey(nameof(MovieID))]
        public Movie Movie { get; set; }
        public int ActorID { get; set; }
        [ForeignKey(nameof(ActorID))]
        public Actor Actor { get; set; }
    }
}
