using FIT_Api_Example.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.ViewModel
{
    public class MovieDirectorUpsertVM
    {
        public int MovieID { get; set; }
        
        public int DirectorID { get; set; }
        
    }
}
