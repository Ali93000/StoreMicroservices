using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities.GenericModels
{
    public class ValidationMessages
    {
        public static string NotAvaliableProducts { get; set; } = "Not Avaliable Products";
        public static string ProductCreatedSuccessfuly { get; set; } = "Product Created Successfuly";
        public static string ProductNotFound { get; set; } = "Product Not Found";
        public static string ProductDeletedSuccessfuly { get; set; } = "Product Deleted Successfuly";
    }
}
