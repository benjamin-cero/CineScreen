using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CineScreen.Helper.BaseClasses;

namespace CineScreen.Data.Models.SharedTables
{
    public class MovieActor : SharedTableBase
    {

        public int MovieID { get; set; }
        [ForeignKey(nameof(MovieID))]
        public Movie Movie { get; set; }
        public int ActorID { get; set; }
        [ForeignKey(nameof(ActorID))]
        public Actor Actor { get; set; }
    }
}
