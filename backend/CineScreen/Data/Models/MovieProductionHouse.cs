using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models
{
    public class MovieProductionHouse
    {
        [Key]
        public int MovieProductionHouseID { get; set; }
        public int MovieID { get; set; }
        [ForeignKey(nameof(MovieID))]
        public Movie Movie { get; set; }
        public int ProductionHouseID { get; set; }
        [ForeignKey(nameof(ProductionHouseID))]
        public ProductionHouse ProductionHouse { get; set; }
    }
}
