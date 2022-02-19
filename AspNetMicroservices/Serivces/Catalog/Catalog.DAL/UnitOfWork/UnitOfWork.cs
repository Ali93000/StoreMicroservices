using Catalog.DAL.Domain;
using Catalog.DAL.Repository;
using Catalog.Entities.Interfaces.Repository;
using Catalog.Entities.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogDBContext _dbContext;

        public UnitOfWork(CatalogDBContext dBContext)
        {
            this._dbContext = dBContext;
            ProductRepository = new ProductRepository(dBContext);
        }
        
        public async Task<int> SaveAsync()
        {
            return await this._dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
        public IProductRepository ProductRepository { get; }
    }
}
