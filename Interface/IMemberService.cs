using System.Threading.Tasks;
using ShagunGraminHealth.Models;

namespace ShagunGraminHealth.Interface
{
    public interface IMemberService
    {
        Task<IEnumerable<MembershipPlan>> GetAllMembershipPlansAsync();
        Task<User> GetUserByIdAsync(int id);
        Task UpdateUserProfileAsync(User user);
		Task SaveMembershipFormAsync(MembershipForm model);
        Task ApplyMembershipFormAsync(MembershipFormViewModel model);


    }
}
