using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace musicReporting.Models.Entities
{
    public class Store
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Store Name")]
        public string StoreName { get; set; } = string.Empty;

        [DataType(DataType.PhoneNumber)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [DisplayName("Address Line 1")]

        public string? AddressLine1 { get; set; }

        [DisplayName("Address Line 2")]
        public string? AddressLine2 { get; set; }

        [DisplayName("City")]
        public string? City { get; set; }

        [DisplayName("State")]
        public string? State { get; set; }

        [DisplayName("Zip Code")]
        public string? ZipCode { get; set; }


        public ICollection<User> Users { get; set; } = new List<User>();

    }
}
