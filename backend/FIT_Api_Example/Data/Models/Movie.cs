using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public byte[] Poster { get; set; }
        public int DirectorID { get; set; }
        [ForeignKey(nameof(DirectorID))]
        public Director Director { get; set; }
        public int ProductionHouseID { get; set; }
        [ForeignKey(nameof(ProductionHouseID))]
        public ProductionHouse ProductionHouse { get; set; }
  
    }
}
