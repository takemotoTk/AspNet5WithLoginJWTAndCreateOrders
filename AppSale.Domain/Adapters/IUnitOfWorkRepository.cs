using AppSale.Domain.Adapters.Base;
using AppSale.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppSale.Domain.Adapters
{
    public interface IUnitOfWorkRepository : IUnitOfWorkRepositoryBase
    {
        Task<int> Commit(CancellationToken cancellationToken);
    }
}
