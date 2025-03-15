using RS1_2024_25.API.Helper;
using System.ComponentModel.DataAnnotations;

namespace CineScreen.Data.Models
{
    public class City : IMyBaseEntity
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

    }
}
