using ASP_NET_CORE_API.Models.Entities;
using System.Collections.Generic;

namespace ASP_NET_CORE_API.Models.DTO
{
    public class UserDetails
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public bool IsFacebook { get; set; }
        public bool IsWhatsApp { get; set; }
        public bool IsTwitter { get; set; }
        public string Other { get; set; }
        public List<UserAddresses> UserAddresses { get; set; }
    }
}
