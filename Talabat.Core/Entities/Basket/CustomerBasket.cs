using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Basket
{
    public class CustomerBasket
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public List<BasketItem> Item { get; set; }

        public CustomerBasket(string id)
        {
            Id = id;
            Item = new List<BasketItem>();
        }

    }
}
