using FIT_Api_Example.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.ViewModel
{
    public class MovieActorUpsertVM
    {
        public int MovieID { get; set; }
     
        public int ActorID { get; set; }
    }
}
