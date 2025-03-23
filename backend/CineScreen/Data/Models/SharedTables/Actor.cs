using CineScreen.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace CineScreen.Data.Models.SharedTables
{
    public class Actor : SharedTableBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
    }
}
