using Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    [Table("Sales")]
    public class Sale : BaseModel
    {
        public int SaleId { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [Required]
        public decimal Discount { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public decimal SubTotal { get; set; }

        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        public decimal Total { get; set; }

    }
}
