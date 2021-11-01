using AppSale.Businness.Services.Base;
using AppSale.Common.Helper;
using AppSale.Domain.Adapters;
using AppSale.Domain.Common;
using AppSale.Domain.Model.Request;
using AppSale.Domain.Model.Response;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppSale.Application.Services
{
    public class OrderQueryServiceManager : ServiceManagerBase, IRequestHandler<OrderQueryRequest, PaginatedList<OrderResponse>>
    {
        public OrderQueryServiceManager(IUnitOfWorkRepository uow) : base(uow)
        {
        }

        public async Task<PaginatedList<OrderResponse>> Handle(OrderQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var getOrders = this._uow.Order
                                .OrderBy(o => o.Id)
                                .Include(o => o.Customer)
                                    .ThenInclude(c => c.Address)
                                .Include(o => o.Products)
                                .Include(o => o.TeamDelivery)
                                .AsNoTracking();

                List<OrderResponse> ordersResponse = new List<OrderResponse>();
                foreach (var order in getOrders)
                {
                    var objMapped = Helper.Instance.MappingEntity<OrderResponse>(order);
                    ordersResponse.Add(objMapped);
                }

                return new PaginatedList<OrderResponse>(ordersResponse, request.PageNumber, request.PageSize);
            }
            catch (Exception err)
            {
                err = Helper.Instance.MapperException(err);
                throw;
            }
        }
    }
}
