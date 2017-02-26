using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public enum BusinessType
    {
        Coffee,
        Takeaway,
        Restaurant,
        Other
    }
    public enum Foodcourt
    {
        Upper_Campus,
        Middle_Campus,
        Lower_Campus,
        Other      
    }
    public enum City
    {
        Kinsington,
        Kingsford,
        Randwick
    }

    public enum State
    {
        NSW,
        Qld,
        SA,
        Tas,
        Vic,
        WA

    }
   /* public enum cuisine
    {

    }*/
    public class Business
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Display(Name = "Type")]
        public BusinessType BusinesTtype { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }

        [Display(Name = "Name")]
        public String Shop { get; set; }

        [Display(Name = "Building")]
        public string building { get; set; }

        [Display(Name = "Street Number")]
        public string streetNumber { get; set; }

        [Display(Name = "City")]
        public City city { get; set; }

        /*[Display(Name = "State")]
        public State state { get; set; }*/

        [Display(Name = "ABN")]
        public string abn { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Phone")]
        
        public string phone { get; set; }

        [Display(Name = "Mobile")]
        public string mobile { get; set; }

        [Display(Name = "Foodcourt")]
        public Foodcourt foodCourt { get; set; }

        [Display(Name = "Upload Photo")]
        public string photo { get; set; }

     

       

        //relationship with Product
        public virtual ICollection<Product> products { get; set; }

        //Relationship with Business Reviews
        public virtual ICollection<BusinessReview> BusinessReviews { get; set; }

        //Relationship with voucher
        public virtual ICollection<Voucher> Vouchers { get; set; }
        
    }
}
