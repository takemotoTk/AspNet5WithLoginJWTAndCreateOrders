using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSale.Domain.Entities.Base
{
    public class EntityBase
    {
        public DateTime CreatedUTC { get; set; } = DateTime.UtcNow;

        public bool Active { get; set; } = true;
    }
}
