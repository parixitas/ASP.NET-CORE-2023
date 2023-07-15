using ASP_NET_CORE_API.Data.DataContext;
using ASP_NET_CORE_API.Interfaces.RepositoryInterfaces;
using ASP_NET_CORE_API.Models.DTO;
using ASP_NET_CORE_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_API.Repository
{
    public class UserSocialMediaRepository : IUserSocialMediaRepository
    {
        private readonly UserDbContext _userDbContext;

        public UserSocialMediaRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public async Task<UserSocialMedia> GetUserSocialMedia(int UserId)
        {
            try
            {
                UserSocialMedia userSocialMedia = await _userDbContext.UserSocialMedias.Where(x => x.UserId == UserId).FirstOrDefaultAsync();
                return userSocialMedia;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserSocialMedia> AddUserSocialMediaData(SocialMediaRequest request)
        {
            try
            {
                UserSocialMedia user = new UserSocialMedia();
                user.IsTwitter = request.IsTwitter;
                user.IsFacebook = request.IsFacebook;
                user.IsWhatsApp = request.IsWhatsApp;
                user.Other = request.Other;     
                user.UserId = request.UserId;
                await _userDbContext.UserSocialMedias.AddAsync(user);
                await _userDbContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
