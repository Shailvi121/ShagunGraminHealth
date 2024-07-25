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
        Task<IEnumerable<MembershipFormViewModel>> GetAppliedPlansAsync();
        Task<IEnumerable<User>> GetDetailsAsync();
        Task ProcessPaymentAsync(string razorpayPaymentId, string razorpayOrderId, string razorpaySignature, int userId);

        Task ProcessPaymentAsync(PaymentViewModel model);
        Task<IEnumerable<MembershipFormViewModel>> GetMemberApplicationIdAsync(string Application_Id);
        

        Task ApplyJobAsync(JobApplicationViewModel model);
        Task<List<JobAdvertisement>> GetJobAdvertisementsAsync(int page, int pageSize);


    }
}
