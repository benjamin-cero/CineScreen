using FIT_Api_Example.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.ViewModel
{
    public class TicketInsertVM
    {
        public int MyAppUserID { get; set; }
        public int SeatID { get; set; }
        public int ProjectionID { get; set; }
    }
}
