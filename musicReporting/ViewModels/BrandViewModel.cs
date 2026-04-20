using musicReporting.Models.Entities;
using System.Collections.Generic;

namespace musicReporting.ViewModels
{
    public class BrandViewModel
    {
        public Brand? Brand { get; set; }
        public IEnumerable<Brand>? Brands { get; set; } = new List<Brand>();
    }
}
