using ASP_NET_CORE_API.Models.DTO;
using ASP_NET_CORE_API.Models.Entities;
using System.Threading.Tasks;

namespace ASP_NET_CORE_API.Interfaces.RepositoryInterfaces
{
    public interface IUserSocialMediaRepository
    {
        Task<UserSocialMedia> GetUserSocialMedia(int UserId);

        Task<UserSocialMedia> AddUserSocialMediaData(SocialMediaRequest request);
    }
}
