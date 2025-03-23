using CineScreen.Data.Models.TenantSpecificTables.Auth;
using CineScreen.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CineScreen.Data.Models.TenantSpecificTables.Basic
{
    public class Order : TenantSpecificTable
    {
        public int MyAppUserID { get; set; }
        [ForeignKey(nameof(MyAppUserID))]
        public MyAppUser MyAppUser { get; set; }
        public int MenuID { get; set; }
        [ForeignKey(nameof(MenuID))]
        public Menu Menu { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }
    }
}
