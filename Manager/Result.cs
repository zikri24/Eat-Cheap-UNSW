using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public class Result<T> where T: class
    {
        public T Data { get; set; }
        public ResultStatus Ststus { get; set; }

    }
    public enum ResultStatus
    {
        Success,
        Error,
        NotFound
    }
}
