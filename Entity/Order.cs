using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }

        //Relationship with OrderItem
        public ICollection<OrderItem> OrederItems { get; set; }

        
    }
}
