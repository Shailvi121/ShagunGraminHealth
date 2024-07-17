using System.Threading.Tasks;
using ShagunGraminHealth.Models;
using ShagunGraminHealth.ViewModel;

namespace ShagunGraminHealth.Interface
{
    public interface IMemberService
    {
        Task<IEnumerable<MembershipPlan>> GetAllMembershipPlansAsync();
        Task<User> GetUserByIdAsync(int id);
        Task UpdateUserProfileAsync(User user);
        Task ApplyMembershipFormAsync(MembershipFormViewModel model);


    }
}
