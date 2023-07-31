using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Domain.Models
{
    public class Payment : BaseEntity
    {
        public Guid CategoryID { get; set; } // Category ID (Foreign Key)


        public virtual Category Category { get; set; }
    }
}
