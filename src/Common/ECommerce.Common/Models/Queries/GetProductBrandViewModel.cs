using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common.Models.Queries
{
    public class GetProductBrandViewModel
    {
        public Guid Id { get; set; }
        public string ProductBrandName { get; set; }
        public int ProductModelCount { get; set; }
    }
}
