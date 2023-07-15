using ASP_NET_CORE_API.Models.DTO;
using System.Threading.Tasks;

namespace ASP_NET_CORE_API.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailResponse> GetAllUsers();

        Task<SingleUserResponse> GetUser(int UserId);

        Task<SingleUserResponse> AddUser(UserDetailRequest model);
    }
}
