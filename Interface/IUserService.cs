using ShagunGraminHealth.Models;
using System.Linq.Expressions;

namespace ShagunGraminHealth.Interface
{
    public interface IUserService
    {
        Task<User> SignInAsync(LoginModel model);

        Task SignUp(User model);
        Task<List<string>> GetRoles(int userId);


    }
}
