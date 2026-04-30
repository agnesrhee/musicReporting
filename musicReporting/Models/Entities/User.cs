using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace musicReporting.Models.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("StoreId")]
        public int? StoreId { get; set; }

        public Store? Store { get; set; }

        [DisplayName("RoleId")]
        public int? RoleId { get; set; }

        public Role? Role { get; set; }

        [DisplayName("UserId")]
        public string UserId { get; set; } = string.Empty;

        [DisplayName("UserName")]
        public string UserName { get; set; } = string.Empty;

        [DisplayName("IpAddress")]
        public string IpAddress { get; set; } = string.Empty;

        [DisplayName("Email")]
        public string Email { get; set; } = string.Empty;

        [DisplayName("FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [DisplayName("LastName")]
        public string LastName { get; set; } = string.Empty;
    }
}
