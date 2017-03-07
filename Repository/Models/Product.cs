using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}