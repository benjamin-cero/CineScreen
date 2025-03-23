using CineScreen.Helper.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace CineScreen.Data.Models.SharedTables
{
    public class Genre : SharedTableBase
    {
        public string Name { get; set; } = string.Empty;
    }
}
