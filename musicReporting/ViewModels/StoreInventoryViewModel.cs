using Microsoft.AspNetCore.Mvc.Rendering;
using musicReporting.Models.Entities;

namespace musicReporting.ViewModels
{
    public class StoreInventoryViewModel
    {
        public StoreInventory? StoreInventory { get; set; }
        public IEnumerable<StoreInventory>? StoreInventories { get; set; }

        public List<SelectListItem>? Stores { get; set; }
        public List<SelectListItem>? Items { get; set; }
    }
}
