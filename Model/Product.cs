using Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("Products")]
    public class Product : BaseModel
    {
        public int ProductId { get; set; }

        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }


        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(15)]
        public string ProductCode { get; set; }

        [Required]
        [MaxLength(20)]
        public string Type { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public decimal PricePerSale { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public decimal PricePerPurchase { get; set; }

        public IEnumerable<Sale> Sales { get; set; }
    }
}
