using CineScreen.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace CineScreen.Data.Models.SharedTables
{
    public class MovieType : SharedTableBase
    {
        public string Type { get; set; } = string.Empty;
    }
}
