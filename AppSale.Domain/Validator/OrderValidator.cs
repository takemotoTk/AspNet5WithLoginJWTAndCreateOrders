using AppSale.Domain.Model.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Domain.Validator
{
    public class OrderValidator : AbstractValidator<OrderRequest>
    {
        public OrderValidator()
        {
            RuleFor(c => c.Customer).NotNull().WithMessage("Informe o Cliente");
            RuleFor(c => c.Customer.Name).NotNull().NotEmpty().WithMessage("Informe o Cliente");
            RuleFor(c => c.Customer.Email).EmailAddress().WithMessage("Informe um E-mail válido");
            RuleFor(c => c.Customer.Address).NotNull().WithMessage("Informe o Endereço");
            RuleFor(c => c.Customer.Address.Name).NotEmpty().WithMessage("Informe o nome para o Endereço");
            RuleFor(c => c.Customer.Address.Street).NotEmpty().WithMessage("Informe o nome da Rua/Avenida");
            RuleFor(c => c.Customer.Address.Neighborhood).NotEmpty().WithMessage("Informe o nome do Bairro");
            RuleFor(c => c.Customer.Address.City).NotEmpty().WithMessage("Informe a Cidade");
            RuleFor(c => c.Customer.Address.State).NotEmpty().WithMessage("Informe o Estado");
            RuleForEach(c => c.Products).SetValidator(new ProductValidator());
        }
    }
}
