using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EatCheap.Models
{
    public class ReviewVM
    {
        [DataType(DataType.MultilineText)]
        public String Review { get; set; }
    }
}