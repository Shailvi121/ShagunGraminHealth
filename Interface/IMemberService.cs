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
        Task<IEnumerable<JobApplicationViewModel>> GetAppliedJobAsync();
        Task<User> GetUserDetailsByIdAsync(int userId);
        Task ProcessPaymentAsync(string razorpayPaymentId, string razorpayOrderId, string razorpaySignature, int userId);
        Task ProcessPaymentAsync(PaymentViewModel model);
        Task<IEnumerable<MembershipFormViewModel>> GetMemberApplicationIdAsync(string Application_Id);
        Task ApplyJobAsync(JobApplicationViewModel model);
        Task<List<JobAdvertisement>> GetJobAdvertisementsAsync(int page, int pageSize);
        Task<List<WalletViewModel>> GetWalletDetailsAsync();
        Task<WalletViewModel> GetWalletDetailsAsync(int userId);
        Task UpdateWalletAsync(int userId, decimal amount, string userRefId);
        Task AddWalletPaymentDetailsAsync(WalletPaymentDetails paymentDetails);
        //Task RefundPaymentAsync(string paymentId, string orderId);
        Task RefundPaymentsAsync(List<string> paymentIds, List<string> orderIds);


    }
}
