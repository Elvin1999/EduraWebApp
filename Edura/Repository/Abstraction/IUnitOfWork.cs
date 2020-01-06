using System;

namespace Edura.Repository.Abstraction
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        int SaveChanges();
    }
}
