using AppSale.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace AppSale.Domain.Entities
{
    public class Order : EntityBase
    {
        [Key]
        public int Id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual IList<Product> Products { get; set; }

        public DateTime? DateDelivery { get; set; }

        public virtual TeamDelivery TeamDelivery { get; set; }

        public decimal TotalOrder { get; set; }
    }
}
