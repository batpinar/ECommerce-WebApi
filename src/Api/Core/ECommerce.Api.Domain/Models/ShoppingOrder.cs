using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Domain.Models
{
    public class ShoppingOrder : BaseEntity
    {
        public Guid CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }
    }
}
