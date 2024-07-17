using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Models;

namespace ShagunGraminHealth.Services
{
    public class MemberService : IMemberService
    {
        private readonly IGenericRepository<MembershipPlan> _membershipPlanRepository;
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<MembershipForm> _generic;
        private readonly IWebHostEnvironment _environment;

        public MemberService(
            IGenericRepository<MembershipPlan> membershipPlanRepository,
            IGenericRepository<User> userRepository,
            IGenericRepository<MembershipForm> generic,
            IWebHostEnvironment environment)
        {
            _membershipPlanRepository = membershipPlanRepository;
            _userRepository = userRepository;
            _generic = generic;
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

        public async Task SaveMembershipFormAsync(MembershipForm model)
        {
            await _generic.AddAsync(model);
            await _generic.SaveChangesAsync();
        }

        public async Task ApplyMembershipFormAsync(MembershipFormViewModel model)
        {
            if (model.Photo != null && model.Signature != null && model.age_photo != null)
            {
                // Process Photo file
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                string uniquePhotoFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Photo.FileName);
                string photoFilePath = Path.Combine(uploadsFolder, uniquePhotoFileName);
                using (var photoStream = new FileStream(photoFilePath, FileMode.Create))
                {
                    await model.Photo.CopyToAsync(photoStream);
                }
                model.PhotoPath = uniquePhotoFileName; // Save the unique file name or path in the model

                // Process Signature file
                string uniqueSignatureFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Signature.FileName);
                string signatureFilePath = Path.Combine(uploadsFolder, uniqueSignatureFileName);
                using (var signatureStream = new FileStream(signatureFilePath, FileMode.Create))
                {
                    await model.Signature.CopyToAsync(signatureStream);
                }
                model.SignaturePath = uniqueSignatureFileName;

                // Process age_photo file
                string uniqueAgePhotoFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.age_photo.FileName);
                string agePhotoFilePath = Path.Combine(uploadsFolder, uniqueAgePhotoFileName);
                using (var agePhotoStream = new FileStream(agePhotoFilePath, FileMode.Create))
                {
                    await model.age_photo.CopyToAsync(agePhotoStream);
                }
                model.AgePhotoPath = uniqueAgePhotoFileName;
            }

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
                Form_Date = DateTime.Now
            };

            await SaveMembershipFormAsync(membershipForm);
        }
    }
}
