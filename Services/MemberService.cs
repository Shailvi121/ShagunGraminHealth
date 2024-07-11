using ShagunGraminHealth.Areas.Admin.Models;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Models;
using ShagunGraminHealth.Repository;

namespace ShagunGraminHealth.Services
{
    public class MemberService : IMemberService
    {
        private readonly IGenericRepository<MembershipPlan> _repository;
        public MemberService(IGenericRepository<MembershipPlan> repository)
        {
            this._repository = repository;
        }
        public async Task<IEnumerable<MembershipPlan>> GetAllMembershipPlansAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
