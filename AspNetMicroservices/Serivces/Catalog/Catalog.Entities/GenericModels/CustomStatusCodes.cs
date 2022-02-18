using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities.GenericModels
{
    public class CustomStatusCodes
    {
        public static int Success { get; set; } = 5000;
        // Not Found Codes
        public static int Product_Not_Avaliable { get; set; } = 5001;

    }
}
