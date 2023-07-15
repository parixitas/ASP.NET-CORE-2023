using System.Collections.Generic;

namespace ASP_NET_CORE_API.Models.DTO
{
    public class UserDetailResponse : Response
    {
        public List<UserDetails> Details { get; set; }  
    }
}
