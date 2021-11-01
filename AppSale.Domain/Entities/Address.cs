using AppSale.Domain.Entities.Base;
using AppSale.Domain.Entities.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppSale.Domain.Entities
{
    public class Address : EntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public virtual IList<Customer> Customer { get; set; }
    }
}
