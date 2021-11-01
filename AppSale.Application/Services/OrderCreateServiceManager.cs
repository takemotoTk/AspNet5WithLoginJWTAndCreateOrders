using AppSale.Businness.Services.Base;
using AppSale.Common.Helper;
using AppSale.Domain.Adapters;
using AppSale.Domain.Entities;
using AppSale.Domain.Model;
using AppSale.Domain.Model.Request;
using AppSale.Domain.Validator;
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
    public class OrderCreateServiceManager : ServiceManagerBase, IRequestHandler<OrderRequest, int>
    {
        public OrderCreateServiceManager(IUnitOfWorkRepository uow) : base(uow)
        {
        }

        public async Task<int> Handle(OrderRequest request, CancellationToken cancellationToken)
        {
            List<ValidateError> errors = null;
            try
            {
                errors = Helper.Instance.ValidateObj<OrderValidator>(request);
                if (errors != null)
                {
                    throw new Exception();
                }

                var entity = Helper.Instance.MappingEntity<Order>(request);
                entity.DateDelivery = DateTime.Now.AddDays(3);
                entity.TeamDelivery = RandomChoseTeamDeliveryByOrder();
                entity.TotalOrder = (entity.Products != null && entity.Products.Any() ? entity.Products.Sum(p => p.Value) : 0);

                var customer = GetCustomerByEmailAndName(request.Customer.Name, request.Customer.Email);
                if (customer != null)
                {
                    entity.Customer = customer;
                }
                else
                {
                    this._uow.Customer.Add(entity.Customer);
                }

                this._uow.Product.AddRange(entity.Products);
                this._uow.Order.Add(entity);
                await _uow.Commit(cancellationToken);

                return entity.Id;
            }
            catch (Exception err)
            {
                err = Helper.Instance.MapperException(err, errors);
                throw;
            }
        }

        private TeamDelivery RandomChoseTeamDeliveryByOrder()
        {
            try
            {
                TeamDelivery response = null;
                var teamsDelivery = this._uow.TeamDelivery.Where(t => t.Active).AsEnumerable();
                if (teamsDelivery != null && teamsDelivery.Any())
                {
                    response = teamsDelivery.OrderBy(n => Guid.NewGuid()).Take(1).FirstOrDefault();
                }

                return response;
            }
            catch (Exception err)
            {
                throw;
            }
        }

        private Customer GetCustomerByEmailAndName(string name, string email)
        {
            try
            {
                Customer response = null;
                var customer = this._uow.Customer.Where(t => t.Name == name && t.Email == email).FirstOrDefault();
                if (customer != null)
                {
                    response = customer;
                }

                return response;
            }
            catch (Exception err)
            {
                throw;
            }
        }
    }
}
