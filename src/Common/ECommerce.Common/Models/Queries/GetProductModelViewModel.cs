using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common.Models.Queries
{
    public class GetProductModelViewModel
    {
        public Guid Id { get; set; }
        public Guid CategoryID { get; set; } 
        public Guid ProductBrandID { get; set; }

        public string ProductModelName { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
