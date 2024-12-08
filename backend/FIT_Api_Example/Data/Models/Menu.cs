using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models
{
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[]? Image { get; set; }
    }
}
