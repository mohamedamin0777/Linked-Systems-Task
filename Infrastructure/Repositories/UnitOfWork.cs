using Core;
using Core.Entities;
using Infrastructure.Interfaces;
using System.Collections;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _dbContext;
        public IGenericRepository<Product> Products { get; private set; }

        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
            Products = new GenericRepository<Product>(_dbContext);
        }


        public int Complete()
            => _dbContext.SaveChanges();

        public void Dispose()
            => _dbContext.Dispose();
    }
}
