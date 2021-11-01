using System;

namespace AppSale.Domain.Model.Request
{
    public class ProductRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}
