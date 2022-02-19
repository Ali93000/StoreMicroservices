using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities.FluentValidations
{
    public class ErrorCustomModel
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
}
