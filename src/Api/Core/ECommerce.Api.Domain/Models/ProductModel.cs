using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Domain.Models
{
    public class ProductModel : BaseEntity
    {
        public Guid CategoryID { get; set; } // Category ID (Foreign Key)
        public Guid ProductBrandID { get; set; }
        //public Guid CreatedByID { get; set; }
        public string ProductModelName { get; set; } // Product Name
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }


        public virtual Category Categories { get; set; }
        public virtual ProductBrand ProductBrands { get; set; }
        //public virtual User CreatedBy { get; set; }
    }
}
