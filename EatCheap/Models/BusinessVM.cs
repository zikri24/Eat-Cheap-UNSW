using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EatCheap.Models
{
    public class BusinessVM
    {
        //public int id { get; set; }

        [Display(Name = "Business Name")]
        public string name { get; set; }

        [Display(Name = "Business Type")]
        public BusinessType businesTtype { get; set; }

        [Display(Name = "Street No")]        
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

        [Display(Name = "Location in Campus")]
        public Foodcourt foodCourt { get; set; }

        [Display(Name = "Building")]
        public string building { get; set; }

        [Display(Name = "Upload Photo")]
        public string photo { get; set; }
    }
}