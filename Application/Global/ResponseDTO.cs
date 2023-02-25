using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Global
{
    public class ResponseDTO
    {
        public bool success { get; set; }
        public object result { get; set; }
        public string message { get; set; }
    }
}
