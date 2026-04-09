using Microsoft.AspNetCore.Mvc.Rendering;
using musicReporting.Models.Entities;
using System.Collections.Generic;

namespace musicReporting.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<User>? Users { get; set; }

    }
}
