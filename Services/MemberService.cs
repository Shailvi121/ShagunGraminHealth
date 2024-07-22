using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Razorpay.Api;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Models;
using ShagunGraminHealth.ViewModel;

namespace ShagunGraminHealth.Services
{
    public class MemberService : IMemberService
    {
        private readonly IGenericRepository<MembershipPlan> _membershipPlanRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<MembershipForm> _membershipFormRepository;
        private readonly IGenericRepository<PaymentOrder> _paymentRepository;
        private readonly IGenericRepository<Orders> _orderRepository;
        private readonly IWebHostEnvironment _environment;

        public MemberService(
            IGenericRepository<MembershipPlan> membershipPlanRepository,
            IGenericRepository<User> userRepository,
            IGenericRepository<MembershipForm> membershipFormRepository,
            IGenericRepository<PaymentOrder> paymentRepository,
             IGenericRepository<Orders> orderRepository,
            IWebHostEnvironment environment)
        {
            _membershipPlanRepository = membershipPlanRepository;
            _userRepository = userRepository;
            _membershipFormRepository = membershipFormRepository;
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _environment = environment;
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

        public async Task ApplyMembershipFormAsync(MembershipFormViewModel model)
        {
            if (model.Photo != null && model.Signature != null && model.age_photo != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");

                model.PhotoPath = await SaveFileAsync(model.Photo, uploadsFolder);
                model.SignaturePath = await SaveFileAsync(model.Signature, uploadsFolder);
                model.AgePhotoPath = await SaveFileAsync(model.age_photo, uploadsFolder);
            }

            string key = "rzp_test_h6khePiEN5pLb5";
            string secret = "aa79deq6RzqONUxz2lnJPmhc";
            RazorpayClient client = new RazorpayClient(key, secret);

            string transactionId = Guid.NewGuid().ToString();
            int paymentAmount = 500;

            Dictionary<string, object> input = new Dictionary<string, object>
            {
                { "amount", paymentAmount },
                { "currency", "INR" },
                { "receipt", transactionId }
            };

            Razorpay.Api.Order order = client.Order.Create(input);
            model.OrderId = order["id"].ToString();

            OrderVM orderViewModel = new OrderVM
            {
                PaymentAmount = paymentAmount,
                PaymentStatus = "Initiate",
                UserId = model.UserId,
                OrderId = model.OrderId,
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
            };

            Orders orders = new Orders
            {
                PaymentAmount = orderViewModel.PaymentAmount,
                PaymentStatus = orderViewModel.PaymentStatus,
                UserId = orderViewModel.UserId,
                OrderId = orderViewModel.OrderId,
                CreatedDate = orderViewModel.CreatedDate,
                IsActive = orderViewModel.IsActive,
            };

            await _orderRepository.AddAsync(orders);
            await _orderRepository.SaveChangesAsync();

            MembershipForm membershipForm = new MembershipForm
            {
                Application_Id = model.Application_Id,
                PlanNumber = model.PlanNumber,
                Reference = model.Reference,
                Candidate_Name = model.Candidate_Name,
                Father_Name = model.Father_Name,
                Parmanent_Address = model.Parmanent_Address,
                Current_Address = model.Current_Address,
                Mobile = model.Mobile,
                Date_of_Birth_Days = model.Date_of_Birth_Days,
                Date_of_Birth_Months = model.Date_of_Birth_Months,
                Date_of_Birth_Years = model.Date_of_Birth_Years,
                Sex = model.Sex,
                Educational_Level = model.Educational_Level,
                Marriage = model.Marriage,
                Category = model.Category,
                Ration_Card = model.Ration_Card,
                Aadhar_Card = model.Aadhar_Card,
                Bank_Account = model.Bank_Account,
                IFSC = model.IFSC,
                Bank_Name = model.Bank_Name,
                age_proof = model.age_proof,
                age_photo = model.AgePhotoPath,
                old_member_name = model.old_member_name,
                old_application_no = model.old_application_no,
                Photo = model.PhotoPath,
                Signature = model.SignaturePath,
                Place = model.Place,
                Form_Date = DateTime.Now,
                OrderId = model.OrderId,
                UserId = model.UserId,
            };

            await _membershipFormRepository.AddAsync(membershipForm);
            await _membershipFormRepository.SaveChangesAsync();
        }

        private async Task<string> SaveFileAsync(IFormFile file, string uploadsFolder)
        {
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return uniqueFileName;
        }

        public async Task<IEnumerable<MembershipFormViewModel>> GetAppliedPlansAsync()
        {
            var appliedPlans = await _membershipFormRepository.GetAllAsync();
            var viewModelList = appliedPlans.Select(m => new MembershipFormViewModel
            {
                Id = m.Id,
                Application_Id = m.Application_Id,
                PlanNumber = m.PlanNumber,
                Candidate_Name = m.Candidate_Name,
                Father_Name = m.Father_Name,
                Sex = m.Sex,
                Category = m.Category,
                //Payment = m.Payment
            });
            return viewModelList;
        }

        public async Task ProcessPaymentAsync(PaymentViewModel model)
        {
            Dictionary<string, string> attributes = new Dictionary<string, string>
            {
                { "razorpay_payment_id", model.razorpay_payment_id },
                { "razorpay_order_id", model.razorpay_order_id },
                { "razorpay_signature", model.razorpay_signature }
            };

            Utils.verifyPaymentSignature(attributes);

            var paymentOrder = new PaymentOrder
            {
                RazorPaymentId = model.razorpay_payment_id,
                OrderId = model.razorpay_order_id,
                PaymentStatus = "Success",
                UserId = model.UserId,
                CreatedDate = DateTime.Now
            };

            await _paymentRepository.AddAsync(paymentOrder);
            await _paymentRepository.SaveChangesAsync();
        }

        public Task ProcessPaymentAsync(string razorpayPaymentId, string razorpayOrderId, string razorpaySignature, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetDetailsAsync()
        {
            
            var details = await _userRepository.GetAllAsync();
            return details;
        }
    }
}
