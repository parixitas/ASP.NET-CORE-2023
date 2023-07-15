using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_NET_CORE_API.Models.Entities
{
    [Table("UserAddresses")]
    public class UserAddresses
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
