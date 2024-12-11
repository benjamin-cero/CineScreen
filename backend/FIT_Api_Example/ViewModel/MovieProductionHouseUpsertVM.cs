using FIT_Api_Example.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.ViewModel
{
    public class MovieProductionHouseUpsertVM
    {
        public int MovieID { get; set; }
        public int ProductionHouseID { get; set; }
       
    }
}
