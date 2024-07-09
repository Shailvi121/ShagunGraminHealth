using ShagunGraminHealth.Models;
using System.Linq.Expressions;

namespace ShagunGraminHealth.Interface
{
    public interface IUserService
    {
        Task SignIn(LoginModel model);

        Task SignUp(User model);


    }
}
