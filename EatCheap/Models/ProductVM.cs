using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EatCheap.Models
{
    public class ProductVM
    {
       
        public int businessId { get; set; }

        [Display(Name = "Type")]
        public Type type { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Original Price")]
        public double price { get; set; }

        [Display(Name = "Our Price")]
        [DataType(DataType.Currency)]
        public double ourPrice { get; set; }
    }
}