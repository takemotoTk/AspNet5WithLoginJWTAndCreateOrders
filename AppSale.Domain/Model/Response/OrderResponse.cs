using AppSale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppSale.Domain.Model.Response
{
    public class OrderResponse
    {
        [JsonPropertyName("idOrder")]
        public int Id { get; set; }

        public virtual CustomerResponse Customer { get; set; }

        public List<ProductResponse> Products { get; set; }

        public DateTime? DateDelivery { get; set; }

        public TeamDeliveryResponse TeamDelivery { get; set; }

        public decimal TotalOrder { get; set; }
    }
}
