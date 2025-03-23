using CineScreen.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace CineScreen.Data.Models.SharedTables
{
    public class Manufacturer : SharedTableBase
    {
        public string Name { get; set; } = string.Empty;
    }
}
