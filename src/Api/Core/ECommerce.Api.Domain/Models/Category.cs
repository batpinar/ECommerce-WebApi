using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Domain.Models
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; } // Category Name
        public Guid CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual ICollection<ProductBrand> ProductBrands { get; set; }
        public virtual ICollection<ProductModel> ProductModels { get; set; } // çıkartılabilir
    }
}
