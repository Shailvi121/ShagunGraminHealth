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
                    ReferenceId = GenerateReferenceId(),
                    Passcode = model.Passcode,
                    IsActive = true,
                    CreatedOn = DateTime.Now,
                };
                await _repository.AddAsync(newUser);
                await _repository.SaveChangesAsync();
                await AssignUserRole(newUser.Id, model.Role);
                return newUser;
            }
            return null;
        }

        private static string GenerateReferenceId()
        {
            Guid guid = Guid.NewGuid();
            string base64Guid = Convert.ToBase64String(guid.ToByteArray());
            string referenceId = base64Guid.Replace("=", "").Replace("+", "").Replace("/", "").Substring(0, 10);
            return referenceId;
        }

        private async Task AssignUserRole(int userId, string role)
        {
            int roleId;

            switch (role)
            {
                case "Member":
                    roleId = 2; 
                    break;
                case "Candidate":
                    roleId = 3; 
                    break;
                default:
                    roleId = 1; 
                    break;
            }
            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = roleId
            };

            await _userRoleRepository.AddAsync(userRole);
            await _userRoleRepository.SaveChangesAsync();
        }
    }
}
