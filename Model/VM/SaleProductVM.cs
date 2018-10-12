using System;
using System.Collections.Generic;
using System.Text;

namespace Model.VM
{
    public class SaleProductVM
    {
        public Sale Sale { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
