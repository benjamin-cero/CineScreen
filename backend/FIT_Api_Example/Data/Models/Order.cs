using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
        public int MenuID { get; set; }
        [ForeignKey(nameof(MenuID))]
        public Menu Menu { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }
    }
}
