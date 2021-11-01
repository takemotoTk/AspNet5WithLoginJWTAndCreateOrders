using AppSale.Domain.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Businness.Services.Base
{
    public class ServiceManagerBase
    {
        public readonly IUnitOfWorkRepository _uow;
        public ServiceManagerBase(IUnitOfWorkRepository uow) {
            _uow = uow;
        }
    }
}
