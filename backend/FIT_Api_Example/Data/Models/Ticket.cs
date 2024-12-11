using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.Data.Models
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
        public int UserID { get; set; }
        [ForeignKey(nameof(UserID))]
        public User User { get; set; }
        public int SeatID { get; set; }
        [ForeignKey(nameof(SeatID))]
        public Seat Seat { get; set; }

        public int ProjectionID { get; set; }
        [ForeignKey(nameof(ProjectionID))]
        public Projection Projection { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }


    }
}
