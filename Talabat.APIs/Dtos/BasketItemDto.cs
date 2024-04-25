using System.ComponentModel.DataAnnotations;

namespace Talabat.APIs.Dtos
{
    public class BasketItemDto
    {

        [Required]
        public int id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]

        public string PictureUrl { get; set; }
        [Required]

        public string Brand { get; set; }
        [Required]

        public string Category { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price Must be greater than zero!!.  ")]
        public decimal Price { get; set; }
        [Required]

        [Range(1, int.MaxValue, ErrorMessage = "Quantity Must be greater than zero!!.  ")]

        public int Quantity { get; set; }
    }
}
