using musicReporting.Models.Entities;
using System.Collections.Generic;

namespace musicReporting.ViewModels
{
    public class RoleViewModel
    {
        public Role? Role { get; set; }
        public IEnumerable<Role>? Roles { get; set; } = new List<Role>();
    }
}
