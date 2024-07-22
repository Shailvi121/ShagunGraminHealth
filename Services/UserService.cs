using Microsoft.EntityFrameworkCore;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Models;
using System.Linq.Expressions;
using System.Security.Claims;

namespace ShagunGraminHealth.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;
        private readonly IGenericRepository<UserRole> _userRoleRepository;
        private readonly IGenericRepository<Role> _roleRepository;

        public UserService(IGenericRepository<User> repository, IGenericRepository<UserRole> userRoleRepository, IGenericRepository<Role> roleRepository)
        {
            _repository = repository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
        }

        public async Task<User> SignInAsync(LoginModel model)
        {
            var user = await _repository.FindAsync(u => u.Email == model.Email && u.Password == model.Password);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<List<string>> GetRoles(int userId)
        {
            var userRoles = await _repository.GetRolesByUserIdAsync(userId);
            
            return userRoles;
        }


        public async Task<User> SignUp(RegistrationModel model)
        {
            var existingUser = await _repository.FindAsync(u => u.Email == model.Email);
            if (existingUser == null)
            {
                var newUser = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    Mobile = model.Mobile,
                    ReferenceId = model.ReferenceId,
                    Passcode = model.Passcode,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                };
                await _repository.AddAsync(newUser);
                await _repository.SaveChangesAsync();
                return newUser;
            }
            return null;
        }
    }
}
