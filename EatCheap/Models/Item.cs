using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EatCheap.Models
{
    public class Item
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public Item()
        {

        }

        public Item(Product product)
        {
            this.Product = product;
            
        }
    }
}