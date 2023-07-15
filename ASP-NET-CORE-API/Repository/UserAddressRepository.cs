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
    public class UserAddressRepository : IUserAddressRepository
    {
        private readonly UserDbContext _userDbContext;

        public UserAddressRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task<List<UserAddresses>> GetUserAddress(int UserId)
        {
            try
            {
                var userAddresses = await _userDbContext.UserAddresses.Where(x => x.UserId == UserId).ToListAsync();
                return userAddresses;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<UserAddresses> AddUserAddressData(AddAddressRequest request)
        {
            try
            {
                UserAddresses user = new UserAddresses();
                user.Address = request.Address;
                user.Address2 = request.Address2;
                user.State = request.State;
                user.City = request.City;
                user.Country = request.Country;
                user.UserId = request.UserId;
                user.ZipCode = request.ZipCode;

                await _userDbContext.UserAddresses.AddAsync(user);
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
