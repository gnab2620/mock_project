using AutoMapper;
using Learning_Managerment_SystemMarket_Core.Contracts;
using Learning_Managerment_SystemMarket_Core.Models;
using Learning_Managerment_SystemMarket_Core.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Learning_Managerment_SystemMarket_Services.AdminFunction.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ServiceResponse<User>> Create(User newUser, string password)
        {
            var userFromDb = await Find(x => x.Email == newUser.Email);
            if (userFromDb == null)
            {
                var result = await _userManager.CreateAsync(newUser, password);
                if (result.Succeeded)
                {
                    return new ServiceResponse<User> { Success = true, Message = "Add User Success" };
                }
                else
                {
                    return new ServiceResponse<User> { Success = false, Message = "An error while creating User" };
                }
            }
            else
            {
                return new ServiceResponse<User> { Success = false, Message = "User is Exist" };
            }
        }

        public async Task<ServiceResponse<User>> Delete(User user)
        {
            var userFromDb = await Find(x => x.Id == user.Id);
            if (userFromDb != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return new ServiceResponse<User> { Success = true, Message = "Delete User Success" };
                }
                else
                {
                    return new ServiceResponse<User> { Success = false, Message = "An error while deleting User" };
                }
            }
            else
            {
                return new ServiceResponse<User> { Success = false, Message = "Not Found User" };
            }
        }

        public async Task<User> Find(Expression<Func<User, bool>> expression)
            => await _userManager.Users.FirstOrDefaultAsync(expression);

        public async Task<IList<User>> FindAll()
            => await _userManager.Users.ToListAsync();

        public async Task<bool> IsExisted(string userName)
            => await Find(x => x.UserName == userName) != null;

        public async Task<bool> SaveChange()
            => await _unitOfWork.Save();

        public async Task<ServiceResponse<User>> Update(User updateUser)
        {
            var userFromDb = await Find(x => x.Id == updateUser.Id);
            if (userFromDb != null)
            {
                var result = await _userManager.UpdateAsync(updateUser);
                if (result.Succeeded)
                {
                    return new ServiceResponse<User> { Success = true, Message = "Update User Success" };
                }
                else
                {
                    return new ServiceResponse<User> { Success = false, Message = "An error while updating User" };
                }
            }
            else
            {
                return new ServiceResponse<User> { Success = false, Message = "Not Found User" };
            }
        }

        public async Task<ICollection<string>> GetUserRoles(User user)
            => await _userManager.GetRolesAsync(user);

        public async Task<ServiceResponse<User>> RemoveFromRoles(User user, IEnumerable<string> roles)
        {
            var result = await _userManager.RemoveFromRolesAsync(user, roles);
            if (result.Succeeded)
            {
                return new ServiceResponse<User> { Success = true, Message = "Remove User's Roles Success" };
            }
            else
            {
                return new ServiceResponse<User> { Success = false, Message = "Remove User's Roles Failed" };
            }
        }

        public async Task<ServiceResponse<User>> AddToRoles(User user, IEnumerable<string> roles)
        {
            var result = await _userManager.AddToRolesAsync(user, roles);
            if (result.Succeeded)
            {
                return new ServiceResponse<User> { Success = true, Message = "Add User's Roles Success" };
            }
            else
            {
                return new ServiceResponse<User> { Success = false, Message = "Add User's Roles Failed" };
            }
        }

        public async Task<IList<User>> FindAll(Expression<Func<User, bool>> expression = null)
            => await _userManager.Users.Where(expression).ToListAsync();
    }
}