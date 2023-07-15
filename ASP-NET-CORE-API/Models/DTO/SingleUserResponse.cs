using System.Collections.Generic;

namespace ASP_NET_CORE_API.Models.DTO
{
    public class SingleUserResponse : Response
    {
        public UserDetails Details { get; set; }
    }
}
