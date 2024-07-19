using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _environment;

        public MemberService(
            IGenericRepository<MembershipPlan> membershipPlanRepository,
            IGenericRepository<User> userRepository,
            IGenericRepository<MembershipForm> membershipFormRepository,
            IWebHostEnvironment environment)
        {
            _membershipPlanRepository = membershipPlanRepository;
            _userRepository = userRepository;
            _membershipFormRepository = membershipFormRepository;
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
                string uniquePhotoFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo.FileName);
                string photoFilePath = Path.Combine(uploadsFolder, uniquePhotoFileName);
                using (var photoStream = new FileStream(photoFilePath, FileMode.Create))
                {
                    await model.Photo.CopyToAsync(photoStream);
                }
                model.PhotoPath = uniquePhotoFileName;

                string uniqueSignatureFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Signature.FileName);
                string signatureFilePath = Path.Combine(uploadsFolder, uniqueSignatureFileName);
                using (var signatureStream = new FileStream(signatureFilePath, FileMode.Create))
                {
                    await model.Signature.CopyToAsync(signatureStream);
                }
                model.SignaturePath = uniqueSignatureFileName;

                string uniqueAgePhotoFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.age_photo.FileName);
                string agePhotoFilePath = Path.Combine(uploadsFolder, uniqueAgePhotoFileName);
                using (var agePhotoStream = new FileStream(agePhotoFilePath, FileMode.Create))
                {
                    await model.age_photo.CopyToAsync(agePhotoStream);
                }
                model.AgePhotoPath = uniqueAgePhotoFileName;
            }
            string key = "rzp_test_h6khePiEN5pLb5";
            string secret = "aa79deq6RzqONUxz2lnJPmhc";
            RazorpayClient client = new RazorpayClient(key, secret);


            string TransactionId = Guid.NewGuid().ToString();

            Dictionary<string, object> input = new Dictionary<string, object>
            {
                    { "amount", 100 }, 
                    { "currency", "INR" },
                    { "receipt", TransactionId }
            };

            Razorpay.Api.Order order = client.Order.Create(input);
            model.OrderId = order["id"].ToString();
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
            };


            await _membershipFormRepository.AddAsync(membershipForm);
        }


        //private async Task ProcessFileAsync(IFormFile file, string uploadsFolder, string modelProperty)
        //{
        //    if (file != null)
        //    {
        //        string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await file.CopyToAsync(stream);
        //        }
        //        modelProperty = uniqueFileName;
        //    }
        //}
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

       
        
    }
}