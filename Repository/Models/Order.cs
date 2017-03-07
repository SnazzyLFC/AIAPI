using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class Order
    {

        public Order()
        {
            Products = new List<Product>();
        }

        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}