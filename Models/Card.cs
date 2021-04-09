

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4new.Models
{
    public class Card
    {
        public uint CardID { get; set; }
        public string RemoteId { get; set; }
        [Required]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Picture { get; set; }
    }
}