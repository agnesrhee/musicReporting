using musicReporting.Models.Entities;
using System.Collections.Generic;

namespace musicReporting.ViewModels
{
    public class CategoryViewModel
    {
        public Category? Category { get; set; }
        public IEnumerable<Category>? Categories { get; set; } = new List<Category>();
    }
}
