using ASP_NET_CORE_API.Interfaces;
using ASP_NET_CORE_API.Interfaces.RepositoryInterfaces;
using ASP_NET_CORE_API.Models.DTO;
using ASP_NET_CORE_API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_NET_CORE_API.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IUserSocialMediaRepository _userSocialMediaRepository;

        public UserService(IUserRepository userRepository, IUserAddressRepository userAddressRepository, IUserSocialMediaRepository userSocialMediaRepository)
        {
            _userRepository = userRepository;
            _userAddressRepository = userAddressRepository;
            _userSocialMediaRepository = userSocialMediaRepository;
        }

        public async Task<UserDetailResponse> GetAllUsers()
        {
            try
            {
                UserDetailResponse response = new UserDetailResponse();
                List<UserDetails> userDetails = new List<UserDetails>();
                var users = await _userRepository.GetAllUser();
                foreach (var item in users)
                {
                    UserDetails user = new UserDetails();
                    user.FirstName = item.FirstName;
                    user.LastName = item.LastName;
                    user.Email = item.LastName;
                    user.UserName = item.UserName;
                    user.Phone = item.Phone;

                    var useraddress = await _userAddressRepository.GetUserAddress(item.Id);
                    if (useraddress != null) {
                        user.UserAddresses = useraddress;
                    }

                    var socailmedia = await _userSocialMediaRepository.GetUserSocialMedia(item.Id);
                    if (socailmedia != null)
                    {
                        user.IsFacebook = socailmedia.IsFacebook;
                        user.IsWhatsApp = socailmedia.IsWhatsApp;
                        user.IsTwitter = socailmedia.IsTwitter;
                        user.Other = socailmedia.Other;
                    }
                    userDetails.Add(user);
                }

                if (userDetails.Count() > 0)
                {
                    response.Success = true;
                    response.Message = "User Details Get Successfully";
                    response.Details = userDetails;
                }
                else
                {
                    response.Success = false;
                    response.Message = "User Details Not Available";
                    response.Details = null;
                }


                return response;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public async Task<SingleUserResponse> GetUser(int UserId)
        {
            try
            {
                SingleUserResponse response = new SingleUserResponse();
                UserDetails userDetails = new UserDetails();
                var user = await _userRepository.GetUserById(UserId);
                if(user != null)
                {
                    userDetails.FirstName = user.FirstName;
                    userDetails.LastName = user.LastName;
                    userDetails.Email = user.LastName;
                    userDetails.UserName = user.UserName;
                    userDetails.Phone = user.Phone;

                    var useraddress = await _userAddressRepository.GetUserAddress(UserId);
                    if (useraddress != null)
                    {
                        userDetails.UserAddresses = useraddress;
                    }

                    var socailmedia = await _userSocialMediaRepository.GetUserSocialMedia(UserId);
                    if (socailmedia != null)
                    {
                        userDetails.IsFacebook = socailmedia.IsFacebook;
                        userDetails.IsWhatsApp = socailmedia.IsWhatsApp;
                        userDetails.IsTwitter = socailmedia.IsTwitter;
                        userDetails.Other = socailmedia.Other;
                    }

                    response.Success = true;
                    response.Message = "User Details Get Successfully";
                    response.Details = userDetails;
                }
                else
                {
                    response.Success = false;
                    response.Message = "User Details Not Available";
                    response.Details = null;
                }
               

                return response;
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        public async Task<SingleUserResponse> AddUser(UserDetailRequest model)
        {
            try
            {
                SingleUserResponse response = new SingleUserResponse();
                UserDetails userDetails = new UserDetails();
                if (model != null) {

                    var user = await _userRepository.AddUserData(model);
                    if (user != null)
                    {
                        userDetails.FirstName = user.FirstName;
                        userDetails.LastName = user.LastName;
                        userDetails.Email = user.LastName;
                        userDetails.UserName = user.UserName;
                        userDetails.Phone = user.Phone;
                        userDetails.UserId = user.Id;

                        SocialMediaRequest socialMediaRequest = new SocialMediaRequest();   
                        socialMediaRequest.UserId = user.Id;
                        socialMediaRequest.IsFacebook = model.IsFacebook;
                        socialMediaRequest.IsWhatsApp=model.IsWhatsApp;
                        socialMediaRequest.IsTwitter=model.IsTwitter;
                        socialMediaRequest.Other = model.Other;

                        var social = await _userSocialMediaRepository.AddUserSocialMediaData(socialMediaRequest);
                        if(social != null) {

                            userDetails.IsFacebook = social.IsFacebook;
                            userDetails.IsWhatsApp = social.IsWhatsApp;
                            userDetails.IsTwitter = social.IsTwitter;
                            userDetails.Other = social.Other;
                        }
                        List<UserAddresses> userAddresses = new List<UserAddresses>();
                        foreach (var item in model.UserAddresses)
                        {
                            AddAddressRequest addAddressRequest = new AddAddressRequest();
                            addAddressRequest.Address = item.Address;   
                            addAddressRequest.City = item.City;
                            addAddressRequest.State = item.State;
                            addAddressRequest.Country = item.Country;   
                            addAddressRequest.Address2= item.Address2;  
                            addAddressRequest.UserId=user.Id;   

                            var address =await _userAddressRepository.AddUserAddressData(addAddressRequest);
                            if(address != null)
                            {
                                userAddresses.Add(address);
                            }

                        }

                        if(userAddresses.Count() > 0)
                        {
                            userDetails.UserAddresses = userAddresses;
                        }


                    }
                    response.Success = true;
                    response.Message = "User Details Add Successfully";
                    response.Details = userDetails;

                }
                else
                {
                    response.Success = false;
                    response.Message = "User Details Not Add Successfully.";
                    response.Details = null;
                }

                return response;

            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
