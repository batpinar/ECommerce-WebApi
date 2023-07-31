using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Common.Models.Queries
{
    public class GetCategoryViewModel
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public Guid CreatedById { get; set; }
        public int ProductBrandCount { get; set; }
    }
}
