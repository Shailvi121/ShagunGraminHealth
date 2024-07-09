using Microsoft.EntityFrameworkCore;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Models;
using System.Linq.Expressions;

namespace ShagunGraminHealth.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;
        public UserService(IGenericRepository<User> repository)
        {
            this._repository = repository;
        }
        public async Task SignIn(LoginModel model)
        {
            var user = _repository.FindAsync(u => u.Email == model.Email);
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
