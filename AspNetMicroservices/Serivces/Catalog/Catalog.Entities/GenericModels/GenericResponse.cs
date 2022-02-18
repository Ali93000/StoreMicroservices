using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities.GenericModels
{
    public class GenericResponse
    {
        public GenericResponse()
        {
            ResponseMessages = new List<string>();
        }
        public bool IsSuccessful { get; set; } = true;
        public int ResponseCode { get; set; } = 5000;
        public List<string> ResponseMessages { get; set; } = new List<string>() { "Success" };
    }
}
