using FIT_Api_Example.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.ViewModel
{
    public class MovieGenreUpsertVM
    {
        public int MovieID { get; set; }
       
        public int GenreID { get; set; }
        
    }
}
