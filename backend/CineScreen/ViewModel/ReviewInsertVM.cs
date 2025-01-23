using FIT_Api_Example.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.ViewModel
{
    public class ReviewInsertVM
    {
        public int UserID { get; set; }
        public int MovieID { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
    }
}
