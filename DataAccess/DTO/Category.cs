using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
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
