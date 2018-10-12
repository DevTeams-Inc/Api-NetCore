using Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class SalesProducts : BaseModel
    {
        public int Id  { get; set; }

        public int SaleId { get; set; }

        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public Sale Ventas { get; set; }
        public Product Producto { get; set; }

    }
}
