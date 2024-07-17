using System.ComponentModel.DataAnnotations;

namespace ShagunGraminHealth.Models
{
    public class MembershipFormViewModel
    {
        [Key]
        public int Id { get; set; }
        public string? Application_Id { get; set; }
        public string? PlanNumber { get; set; }
        public string? Reference { get; set; }
        public string? Candidate_Name { get; set; }
        public string? Father_Name { get; set; }
        public string? Parmanent_Address { get; set; }
        public string? Current_Address { get; set; }
        public string? Mobile { get; set; }
        public int Date_of_Birth_Days { get; set; }
        public int Date_of_Birth_Months { get; set; }
        public int Date_of_Birth_Years { get; set; }
        public string? Sex { get; set; }
        public string? Educational_Level { get; set; }
        public string? Marriage { get; set; }
        public string? Category { get; set; }
        public string? Ration_Card { get; set; }
        public string? Aadhar_Card { get; set; }
        public string? Bank_Account { get; set; }
        public string? IFSC { get; set; }
        public string? Bank_Name { get; set; }
        public string? age_proof { get; set; }
        public IFormFile age_photo { get; set; }
        public string? old_member_name { get; set; }
        public string? old_application_no { get; set; }
        public IFormFile Photo { get; set; }
        public IFormFile Signature { get; set; }
        public string? Place { get; set; }
        public DateTime Form_Date { get; set; }

        public string PhotoPath { get; set; }
        public string SignaturePath { get; set; }
        public string AgePhotoPath { get; set; }

    }
}