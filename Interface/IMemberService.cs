using ShagunGraminHealth.Areas.Admin.Models;

namespace ShagunGraminHealth.Interface
{
    public interface IMemberService
    {
        Task<IEnumerable<MembershipPlan>> GetAllMembershipPlansAsync();
    }
}
