using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GlobalECommerce.Infrastructure.Repositories
{
    public interface IUnitOfWork
    {
        IDbTransaction BeginTransaction();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
