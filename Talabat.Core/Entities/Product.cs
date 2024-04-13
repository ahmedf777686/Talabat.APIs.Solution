using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities
{
    public class Product :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set;}

        public int Brand { get; set; } //foreign key
        public ProductBrand BroductBrand { get; set; } // Navigational Property



        public int ProductCategoryId { get; set; } //foreign key
        public ProductCategory BroductCategory { get; set; } // Navigational Property


    }
}
