using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CineScreen.Data.Models.SharedTables;
using CineScreen.Data.Models.TenantSpecificTables.Auth;
using CineScreen.Helper.BaseClasses;

namespace CineScreen.Data.Models.TenantSpecificTables.Basic
{
    public class Review : TenantSpecificTable
    {
        public int MyAppUserID { get; set; }
        [ForeignKey(nameof(MyAppUserID))]
        public MyAppUser MyAppUser { get; set; }
        public int MovieID { get; set; }
        [ForeignKey(nameof(MovieID))]
        public Movie Movie { get; set; }
        public int Score { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
