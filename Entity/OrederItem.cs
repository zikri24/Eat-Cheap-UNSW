using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class OrderItem
    {
        public int Id { get; set; }
        
        //Relationships
        public int OrderId { get; set; }

        public int ProductId { get; set; }
    }
}
