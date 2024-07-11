using ShagunGraminHealth.Areas.Admin.Models;
using ShagunGraminHealth.Models;

namespace ShagunGraminHealth.Interface
{
    public interface IMemberService
    {
        Task<IEnumerable<MembershipPlan>> GetAllMembershipPlansAsync();
    }
}
