using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Domain.Models
{
    public class ProductBrand : BaseEntity
    {
        public Guid CategoryID { get; set; } // Category ID (Foreign Key)
        //public Guid CreatedByID { get; set; }
        public string ProductBrandName { get; set; } // Product Name


        public virtual Category Categories { get; set; }
        //public virtual User CreatedBy { get; set; }
        public virtual ICollection<ProductModel> ProductModels { get; set; }
    }
}
