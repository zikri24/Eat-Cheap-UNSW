
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public enum Type
    {
        Beverage,
        Sandwich,
        Dish,
        Wrap,
        Burger ,
        Roll ,
        Salad,
        Other
    }
    public class Product
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Type")]
        
        public Type type { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }

        [Display(Name = "Description")]
        
        [DataType(DataType.MultilineText)]
        public string description { get; set; }

        [Display(Name = "Original Price")]
        [Required]
        [DataType(DataType.Currency)]
        public double price { get; set; }

        [Display(Name = "Our Price")]
        [DataType(DataType.Currency)]
        public double ourPrice { get; set; }

        [Display(Name = "Upload Photo")]
        public string photo { get; set; }


        //Relationship
        public int businessId { get; set; }

        //Relationship with Reviews
        public ICollection<ProductReview> Reviews { get; set; }

        //Relationship with OrderItems
        public ICollection<OrderItem> OrderItems { get; set; }


    }
}
