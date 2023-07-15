using ASP_NET_CORE_API.Models.DTO;
using ASP_NET_CORE_API.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP_NET_CORE_API.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(int UserId);
        Task<User> AddUserData(UserDetailRequest request);
    }
}
