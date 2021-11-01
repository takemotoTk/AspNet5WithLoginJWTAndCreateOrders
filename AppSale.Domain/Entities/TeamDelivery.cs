using AppSale.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppSale.Domain.Entities
{
    public class TeamDelivery : EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string VehicleLicensePlate { get; set; }

        public virtual IList<Order> Order { get; set; }
    }
}
