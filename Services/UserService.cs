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
        public UserService(IGenericRepository<User> repository, IGenericRepository<UserRole> userRoleRepository,
            IGenericRepository<Role> roleRepository)
        {
            this._repository = repository;
            this._userRoleRepository = userRoleRepository;
            this._roleRepository = roleRepository;
        }
        public async Task<User> SignInAsync(LoginModel model)
        {
            try
            {
                var user = await _repository.FindAsync(u => u.Email == model.Email);
                if (user != null)
                {
                    var userRoles = await GetRoles(user.Id);

                    var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var claimsIdentity = new ClaimsIdentity(authClaims, "login");

                    return user;
                }
                else
                {
                    return null;

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sign in failed.", ex);
            }
        }


        public async Task<List<string>> GetRoles(int userId)
        {
            try
            {
                var userRoles = await _userRoleRepository.GetAllAsync();

                if (userRoles == null)
                {
                    throw new Exception("User roles not found.");
                }

                var roles = userRoles
                    .Where(ur => ur.UserId == userId && ur.Role != null)
                    .Select(ur => ur.Role.Name)
                    .ToList();

                return roles;
            }
            catch (Exception ex)
            {
                throw new Exception("Error fetching roles.", ex);
            }
        }


        public async Task SignUp(User model)
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
                };
                await _repository.AddAsync(newUser);
                await _repository.SaveChangesAsync();
            }
        }
    }
}
