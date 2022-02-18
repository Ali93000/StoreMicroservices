using Catalog.Entities.DBEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Entities.Interfaces.Repository
{
    public interface IProductRepository : IGenericRepository<DB_Product>
    {
    }
}
