using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CineScreen.Data.Models.SharedEnums;
using CineScreen.Helper.BaseClasses;

namespace CineScreen.Data.Models.SharedTables
{
    public class Movie : SharedTableBase
    {
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string? Trailer { get; set; }
        public byte[]? Poster { get; set; }
        public Status Status { get; set; }

        // Navigation properties
        public virtual ICollection<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
        public virtual ICollection<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
        public virtual ICollection<MovieDirector> MovieDirectors { get; set; } = new List<MovieDirector>();
        public virtual ICollection<MovieProductionHouse> MovieProductionHouses { get; set; } = new List<MovieProductionHouse>();
    }
}
