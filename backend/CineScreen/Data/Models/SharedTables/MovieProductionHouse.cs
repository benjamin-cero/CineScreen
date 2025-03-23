using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CineScreen.Helper.BaseClasses;

namespace CineScreen.Data.Models.SharedTables
{
    public class MovieProductionHouse : SharedTableBase
    {
        public int MovieID { get; set; }
        [ForeignKey(nameof(MovieID))]
        public Movie Movie { get; set; }
        public int ProductionHouseID { get; set; }
        [ForeignKey(nameof(ProductionHouseID))]
        public ProductionHouse ProductionHouse { get; set; }
    }
}
