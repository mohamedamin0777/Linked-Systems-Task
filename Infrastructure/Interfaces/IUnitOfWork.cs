using Core.Entities;

namespace Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> Products { get; } 
        int Complete();
    }
}
