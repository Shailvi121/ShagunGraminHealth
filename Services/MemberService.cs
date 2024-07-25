using Newtonsoft.Json;
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
        private readonly IGenericRepository<JobApplication> _jobApplicationRepository;
        private readonly IGenericRepository<NominatedDetail> _nominatedDetailRepository;
        private readonly IGenericRepository<PaymentOrder> _paymentRepository;
        private readonly IGenericRepository<Orders> _orderRepository;
        private readonly IWebHostEnvironment _environment;

        public MemberService(
            IGenericRepository<MembershipPlan> membershipPlanRepository,
            IGenericRepository<User> userRepository,
            IGenericRepository<MembershipForm> membershipFormRepository,
            IGenericRepository<JobApplication> jobApplicationRepository,
            IGenericRepository<NominatedDetail> nominatedDetailRepository,
            IGenericRepository<PaymentOrder> paymentRepository,
             IGenericRepository<Orders> orderRepository,
            IWebHostEnvironment environment)
        {
            _membershipPlanRepository = membershipPlanRepository;
            _userRepository = userRepository;
            _membershipFormRepository = membershipFormRepository;
            _jobApplicationRepository= jobApplicationRepository;
            _paymentRepository = paymentRepository;
            _orderRepository = orderRepository;
            _environment = environment;
            _nominatedDetailRepository = nominatedDetailRepository;
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
            if (model.Photo != null && model.Signature != null )
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
            decimal paymentAmountInINR = model.PaymentAmount;
            int paymentAmountInPaise = (int)(paymentAmountInINR * 100);

            Dictionary<string, object> input = new Dictionary<string, object>
            {

                { "amount", paymentAmountInPaise },
                { "currency", "INR" },
                { "receipt", transactionId }
            };

            Razorpay.Api.Order order = client.Order.Create(input);
            model.OrderId = order["id"].ToString();

            OrderVM orderViewModel = new OrderVM
            {
                PaymentAmount = model.PaymentAmount,
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
                //NominatedDetailsJson = ,
                //FamilyDetailsJson = 
        
                //FamilyDetails = model.FamilyDetails?.Select(fd => new FamilyDetail
                //{
                //    Serial = fd.Serial,
                //    FamilyMemberName = fd.FamilyMemberName,
                //    Relation = fd.Relation,
                //    Age = fd.Age,
                //    AadharNumber = fd.AadharNumber,
                //    EducationalLevel = fd.EducationalLevel,
                //    SchoolName = fd.SchoolName
                //}).ToList(),
                //NominatedDetails = model.NominatedDetails?.Select(nd => new NominatedDetail
                //{
                //    Serial = nd.Serial,
                //    NominatedPersonName = nd.NominatedPersonName,
                //    Relation = nd.Relation,
                //    Age = nd.Age,
                //    Percentage = nd.Percentage
                //}).ToList()

            };

            await _membershipFormRepository.AddAsync(membershipForm);
            await _membershipFormRepository.SaveChangesAsync();
        }
        public async Task ApplyJobAsync(JobApplicationViewModel model)
        {
            if (model.Photo != null && model.Signature != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");

                string photoPath = await SaveFileAsync(model.Photo, uploadsFolder);
                string signaturePath = await SaveFileAsync(model.Signature, uploadsFolder);

                JobApplication jobApplication = new JobApplication
                {
                    ApplicationId = model.ApplicationId,
                    AdvertisementNo = model.AdvertisementNo,
                    CategoryNo = model.CategoryNo,
                    Post = model.Post,
                    CandidateName = model.CandidateName,
                    FatherName = model.FatherName,
                    DateOfBirthDays = model.DateOfBirthDays,
                    DateOfBirthMonths = model.DateOfBirthMonths,
                    DateOfBirthYears = model.DateOfBirthYears,
                    Sex = model.Sex,
                    EmailAddress = model.EmailAddress,
                    PhoneNumber = model.PhoneNumber,
                    Category = model.Category,
                    PhysicallyHandicapped = model.PhysicallyHandicapped,
                    Domicile = model.Domicile,
                    Nationality = model.Nationality,
                    Pincode = model.Pincode,
                    Address = model.Address,
                    VisibleIdentification = model.VisibleIdentification,
                    Agree = model.Agree,
                    Place = model.Place,
                    FormDate = DateTime.Now,
                    Photo = photoPath,
                    Signature = signaturePath,
                  
                    EducationalQualifications_8th = model.EducationalQualifications_8th,
                    YearOfPassing_8th = model.YearOfPassing_8th,
                    MarksObtained_8th = model.MarksObtained_8th,
                    TotalMarks_8th = model.TotalMarks_8th,
                    Percentage_8th = model.Percentage_8th,
                    Division_8th = model.Division_8th,
                    BoardUniversity_8th = model.BoardUniversity_8th,
                    Subjects_8th = model.Subjects_8th,
                    EducationalQualifications_Diploma = model.EducationalQualifications_Diploma,
                    YearOfPassing_Diploma = model.YearOfPassing_Diploma,
                    MarksObtained_Diploma = model.MarksObtained_Diploma,
                    TotalMarks_Diploma = model.TotalMarks_Diploma,
                    Percentage_Diploma = model.Percentage_Diploma,
                    Division_Diploma = model.Division_Diploma,
                    BoardUniversity_Diploma = model.BoardUniversity_Diploma,
                    Subjects_Diploma = model.Subjects_Diploma,

                    EducationalQualifications_Bachelor = model.EducationalQualifications_Bachelor,
                    YearOfPassing_Bachelor = model.YearOfPassing_Bachelor,
                    MarksObtained_Bachelor = model.MarksObtained_Bachelor,
                    TotalMarks_Bachelor = model.TotalMarks_Bachelor,
                    Percentage_Bachelor = model.Percentage_Bachelor,
                    Division_Bachelor = model.Division_Bachelor,
                    BoardUniversity_Bachelor = model.BoardUniversity_Bachelor,
                    Subjects_Bachelor = model.Subjects_Bachelor,

                    EducationalQualifications_Master = model.EducationalQualifications_Master,
                    YearOfPassing_Master = model.YearOfPassing_Master,
                    MarksObtained_Master = model.MarksObtained_Master,
                    TotalMarks_Master = model.TotalMarks_Master,
                    Percentage_Master = model.Percentage_Master,
                    Division_Master = model.Division_Master,
                    BoardUniversity_Master = model.BoardUniversity_Master,
                    Subjects_Master = model.Subjects_Master,

                    Higher_Qualification = model.Higher_Qualification,
                    Experience_Years = model.Experience_Years,
                    Experience_Months = model.Experience_Months,
                    Experience_Days = model.Experience_Days,

                    Visible_Identification = model.Visible_Identification,

                    // Add other educational qualifications similarly
                };

                await _jobApplicationRepository.AddAsync(jobApplication);
                await _jobApplicationRepository.SaveChangesAsync();
            }
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

        //public async Task<IEnumerable<MembershipFormViewModel>> GetAppliedPlansAsync()
        //{
        //    var appliedPlans = await _membershipFormRepository.GetAllAsync();
        //    var viewModelList = appliedPlans.Select(m => new MembershipFormViewModel
        //    {
        //        Id = m.Id,
        //        Application_Id = m.Application_Id,
        //        PlanNumber = m.PlanNumber,
        //        Candidate_Name = m.Candidate_Name,
        //        Father_Name = m.Father_Name,
        //        Sex = m.Sex,
        //        Category = m.Category,
        //        //Payment = m.Payment
        //    });
        //    return viewModelList;
        //}


        public async Task<IEnumerable<MembershipFormViewModel>> GetAppliedPlansAsync()
        {
            var appliedPlans = await _membershipFormRepository.GetAllAsync();
            var orderDetails = await _orderRepository.GetAllAsync(); 

            var viewModelList = appliedPlans.Select(m =>
            {
                var orderDetail = orderDetails.FirstOrDefault(o => o.OrderId == m.OrderId); 
                return new MembershipFormViewModel
                {
                    Id = m.Id,
                    Application_Id = m.Application_Id,
                    PlanNumber = m.PlanNumber,
                    Candidate_Name = m.Candidate_Name,
                    Father_Name = m.Father_Name,
                    Sex = m.Sex,
                    Category = m.Category,
                    PaymentStatus = orderDetail?.PaymentStatus ?? "Pending",
                    PaymentAmount = orderDetail?.PaymentAmount ?? 0
                };
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
            var orderId = model.razorpay_order_id;
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

            var orders = await _orderRepository.GetByOrderIdAsync(model.razorpay_order_id);
            if (orders != null && orders.Count > 0)
            {
                foreach (var order in orders)
                {
                    order.PaymentStatus = "Success";
                    await _orderRepository.Update(order);
                }
                await _orderRepository.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Order not found.");
            }

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

       
        public async Task<IEnumerable<MembershipFormViewModel>> GetMemberApplictionIdAsync(string Application_Id)
        {
            var allMembershipForms = await _membershipFormRepository.GetAllAsync();
            var orderDetails = await _orderRepository.GetAllAsync();
            var membershipForms = allMembershipForms.Where(m => m.Application_Id == Application_Id);
            var viewModels = membershipForms.Select(m =>
            {
                
                var orderDetail = orderDetails.FirstOrDefault(o => o.OrderId == m.OrderId);

                return new MembershipFormViewModel
                {
                    Id = m.Id,
                    Application_Id = m.Application_Id,
                    PlanNumber = m.PlanNumber,
                    Candidate_Name = m.Candidate_Name,
                    PaymentAmount = orderDetail.PaymentAmount,
                    OrderId = m.OrderId,
                    PaymentStatus = orderDetail?.PaymentStatus 
                };
            });

                            return viewModels;
        }


    }
}
