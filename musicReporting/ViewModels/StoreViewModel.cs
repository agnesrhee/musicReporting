using musicReporting.Models.Entities;
using System.Collections.Generic;

namespace musicReporting.ViewModels
{
    public class StoreViewModel
    {
        public Store? Store { get; set; }
        public IEnumerable<Store>? Stores { get; set; } = new List<Store>();
    }
}
