using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_NET_CORE_API.Models.Entities
{
    [Table("UserSocialMedia")]
    public class UserSocialMedia
    {

        [Key]
        [Required]
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool IsFacebook { get; set; }
        public bool IsWhatsApp { get; set; }
        public bool IsTwitter { get; set; }
        public string Other { get; set; }   
    }
}
