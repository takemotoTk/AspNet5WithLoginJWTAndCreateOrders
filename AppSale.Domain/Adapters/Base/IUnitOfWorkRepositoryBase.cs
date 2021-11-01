using AppSale.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Domain.Adapters.Base
{
    public interface IUnitOfWorkRepositoryBase
    {
        DbSet<Order> Order { get; set; }
        DbSet<Address> Address { get; set; }
        DbSet<TeamDelivery> TeamDelivery { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<Customer> Customer { get; set; }
    }
}
