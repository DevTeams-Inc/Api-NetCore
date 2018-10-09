using Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("Suppliers")]
    public class Supplier : BaseModel
    {
        public int SupplierId { get; set; }

        [Required]
        [MaxLength(13)]
        public string Dni { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(12)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
