using AppSale.Domain.Common;
using AppSale.Domain.Model.Response;
using MediatR;
using System.Collections.Generic;

namespace AppSale.Domain.Model.Request
{
    public class OrderQueryRequest : IRequest<PaginatedList<OrderResponse>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
