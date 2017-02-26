using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class BusinessReview
    {
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        [Required]
        public String Review { get; set; }

        public int BusinessId { get; set; }
    }
}
