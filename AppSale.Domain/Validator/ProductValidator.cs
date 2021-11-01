using AppSale.Domain.Model.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Domain.Validator
{
    public class ProductValidator : AbstractValidator<ProductRequest>
    {
        public ProductValidator() {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Informe o Nome do Produto");
            RuleFor(c => c.Description).NotEmpty().WithMessage("Informe a Descrição do Produto");
            RuleFor(c => c.Value).GreaterThan(0).WithMessage("Informe um valor acima de 0");
        }
    }
}
