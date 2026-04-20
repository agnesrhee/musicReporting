using Microsoft.AspNetCore.Mvc.Rendering;
using musicReporting.Models.Entities;

namespace musicReporting.ViewModels
{
    public class ItemViewModel
    {
        public Item? Item { get; set; }
        public IEnumerable<Item>? Items { get; set; } = new List<Item>();
        public List<SelectListItem>? Categories { get; set; }
        public List<SelectListItem>? Brands { get; set; }
    }
}
