using System.ComponentModel.DataAnnotations;
using VintageGameLibrary.Models.Enums;

namespace VintageGameLibrary.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        //public string Description { get; set; }
        public string Genre { get; set; } = null!;
        public string Platform { get; set; } = null!;
        public string Publisher { get; set; } = null!;
        public string Developer { get; set; } = null!;
        public int ReleaseYear { get; set; }
        public int? Barcode { get; set; }
        public Media MediaType { get; set; }
        public Packaging Packaging { get; set; }
        public string Shelf { get; set; } = null!;
        public string? Borrower { get; set; }
    }
}
