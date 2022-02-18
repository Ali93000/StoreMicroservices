using Catalog.Entities.DBEntities;
using Catalog.Entities.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.Repository
{
    public class ProductRepository : GenericRepository<DB_Product>, IProductRepository
    {
        private readonly DbContext _dbContext;
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
