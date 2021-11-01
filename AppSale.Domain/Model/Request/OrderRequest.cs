using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Domain.Model.Request
{
    public class OrderRequest : IRequest<int>
    {
        public CustomerRequest Customer { get; set; }

        public ICollection<ProductRequest> Products { get; set; }
    }
}
