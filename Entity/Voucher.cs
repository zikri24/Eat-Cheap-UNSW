using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Voucher
    {
        public int Id { get; set; }
        public double Value { get; set; }

        //Relationship
        public int BusinessId { get; set; }
    }
}
