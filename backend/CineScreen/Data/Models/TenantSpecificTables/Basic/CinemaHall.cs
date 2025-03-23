using CineScreen.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace CineScreen.Data.Models.TenantSpecificTables.Basic
{
    public class CinemaHall : TenantSpecificTable
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
