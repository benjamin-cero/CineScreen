using CineScreen.Data.Models.TenantSpecificTables.Auth;
using CineScreen.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineScreen.Data.Models.TenantSpecificTables.Basic
{
    public class Ticket : TenantSpecificTable
    {
        public int MyAppUserID { get; set; }
        [ForeignKey(nameof(MyAppUserID))]
        public MyAppUser MyAppUser { get; set; }
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
