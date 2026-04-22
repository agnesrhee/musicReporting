using Microsoft.AspNetCore.Mvc.Rendering;
using musicReporting.Models.Entities;

namespace musicReporting.ViewModels
{
    public class SaleViewModel
    {
        public Sale? Sale { get; set; }
        public IEnumerable<Sale>? Sales { get; set; }
        public int StoreId { get; set; }
        public int UserId { get; set; }

        public List<SaleLineItemInput> LineItems { get; set; } = new();

        public List<SelectListItem>? Stores { get; set; }
        public List<SelectListItem>? Items { get; set; }
    }

    public class SaleLineItemInput
    {
        public int? ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
