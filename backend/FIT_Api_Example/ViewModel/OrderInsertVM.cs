using FIT_Api_Example.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.ViewModel
{
    public class OrderInsertVM
    {
        public int UserID { get; set; }
        public int MenuID { get; set; }
        public int Quantity { get; set; }
    }
}
