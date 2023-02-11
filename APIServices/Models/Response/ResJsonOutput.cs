using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Models.Response
{

    public class ResStatus
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public string? ResponseCode { get; set; }
    }

    public class ResJsonOutput
    {
        public ResJsonOutput()
        {
            Status = new ResStatus();
            data = new object();
        }

        public object data { get; set; }

        public ResStatus Status { get; set; }
    }

    


}
