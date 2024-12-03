using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
        public int MovieID { get; set; }
        [ForeignKey(nameof(MovieID))]
        public Movie Movie { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
