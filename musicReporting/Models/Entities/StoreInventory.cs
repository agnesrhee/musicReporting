using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace musicReporting.Models.Entities
{
    public class StoreInventory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Store")]
        public int StoreId { get; set; }
        public Store? Store { get; set; }

        [DisplayName("Item")]
        public int ItemId { get; set; }
        public Item? Item { get; set; }

        [DisplayName("Quantity On Hand")]
        public int QuantityOnHand { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; } = true;
    }
}
