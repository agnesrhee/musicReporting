using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace musicReporting.Models.Entities
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Item Name")]
        public string ItemName { get; set; } = string.Empty;

        [DisplayName("Description")]
        public string? Description { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
        [DisplayName("Brand")]
        public int BrandId { get; set; }

        public Brand? Brand { get; set; }

        [DisplayName("Price")]
        public decimal Price { get; set; }

        [DisplayName("SKU")]
        public string SKU { get; set; } = string.Empty;

        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;

    }

}
