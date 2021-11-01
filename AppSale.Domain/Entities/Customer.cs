using AppSale.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AppSale.Domain.Entities
{
    public class Customer : EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public virtual Address Address { get; set; }

        public virtual IList<Order> Order { get; set; }
    }
}
