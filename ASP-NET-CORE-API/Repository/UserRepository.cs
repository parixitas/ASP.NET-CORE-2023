using ASP_NET_CORE_API.Data.DataContext;
using ASP_NET_CORE_API.Interfaces.RepositoryInterfaces;
using ASP_NET_CORE_API.Models.DTO;
using ASP_NET_CORE_API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;
        public UserRepository(UserDbContext userDbContext) { 
        _userDbContext = userDbContext; 
        }
        public async Task<List<User>> GetAllUser()
        {
            try
            {   
                var users = await _userDbContext.Users.ToListAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> GetUserById(int UserId)
        {
            try
            {
                var users = await _userDbContext.Users.Where(x => x.Id == UserId).FirstOrDefaultAsync();
                return users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<User> AddUserData(UserDetailRequest request)
        {
            try
            {
                User user = new User();
                user.FirstName = request.FirstName; 
                user.LastName = request.LastName;
                user.Email = request.Email;
                user.Phone= request.Phone;
                user.UserName = request.UserName;   
                user.Password=request.Password;
                await _userDbContext.Users.AddAsync(user);
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
