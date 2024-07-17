using System.Collections.Generic;
using System.Threading.Tasks;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Models;

namespace ShagunGraminHealth.Services
{
    public class MemberService : IMemberService
    {
        private readonly IGenericRepository<MembershipPlan> _membershipPlanRepository;
        private readonly IGenericRepository<User> _userRepository;
		private readonly IGenericRepository<MembershipForm> _generic;


		public MemberService(IGenericRepository<MembershipPlan> membershipPlanRepository, IGenericRepository<User> userRepository, IGenericRepository<MembershipForm> generic   )
        {
            _membershipPlanRepository = membershipPlanRepository;
            _userRepository = userRepository;
			_generic= generic;

		}

        public async Task<IEnumerable<MembershipPlan>> GetAllMembershipPlansAsync()
        {
            return await _membershipPlanRepository.GetAllAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task UpdateUserProfileAsync(User user)
        {
            var existingUser = await _userRepository.GetByIdAsync(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Mobile = user.Mobile;
                existingUser.Email = user.Email;

                await _userRepository.Update(existingUser);
            }
        }
		public async Task SaveMembershipFormAsync(MembershipForm model)
		{
			 _generic.AddAsync(model);
			await _generic.SaveChangesAsync();
		}


	}
}
