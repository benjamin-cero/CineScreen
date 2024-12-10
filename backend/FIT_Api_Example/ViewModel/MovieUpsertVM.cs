using FIT_Api_Example.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIT_Api_Example.ViewModel
{
    public class MovieUpsertVM
    {
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string? Trailer { get; set; }
        public byte[]? Poster { get; set; }
        public int StatusID { get; set; }
        
    }
}
