using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ShagunGraminHealth.Models
{
    public class MembershipForm
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
        public string? age_photo { get; set; }
        public string? old_member_name { get; set; }
        public string? old_application_no { get; set; }
        public string Photo { get; set; }
        public string? Signature { get; set; }
        public string? Place { get; set; }
        public DateTime Form_Date { get; set; }
        [NotMapped]
        public IFormFile? FileToUpload { get; set; }
        public string? OrderId { get; set; }
        public int UserId { get; set; }
        public string? NominatedDetailsJson { get; set; }
        public string? FamilyDetailsJson { get; set; }



    }
}
