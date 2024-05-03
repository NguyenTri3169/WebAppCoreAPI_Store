using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCoreMVC.Models
{
    [Table("Category")]
    public class Category
    {
        [Column("CategoryId")]
        public byte Id { get; set; }
        [Column("CategoryName")]
        public string Name { get; set; } = null!;
    }
}
