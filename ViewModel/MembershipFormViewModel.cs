using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ShagunGraminHealth.ViewModel
{
    public class MembershipFormViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Application Id is required")]
        public string? Application_Id { get; set; }

        [Required(ErrorMessage = "Plan Number is required")]
        [StringLength(20, ErrorMessage = "Plan Number can't be longer than 20 characters")]
        public string PlanNumber { get; set; }

        public string? Reference { get; set; }

        [Required(ErrorMessage = "Candidate Name is required")]
        [StringLength(100, ErrorMessage = "Candidate Name can't be longer than 100 characters")]
        public string? Candidate_Name { get; set; }

        [Required(ErrorMessage = "Father Name is required")]
        [StringLength(100, ErrorMessage = "Father Name can't be longer than 100 characters")]
        public string? Father_Name { get; set; }

        [Required(ErrorMessage = "Permanent Address is required")]
        public string? Parmanent_Address { get; set; }

        [Required(ErrorMessage = "Current Address is required")]
        public string? Current_Address { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [Phone(ErrorMessage = "Invalid Mobile number")]
        public string? Mobile { get; set; }

        [Range(1, 31, ErrorMessage = "Invalid day")]
        public int Date_of_Birth_Days { get; set; }

        [Range(1, 12, ErrorMessage = "Invalid month")]
        public int Date_of_Birth_Months { get; set; }

        [Range(1900, 2100, ErrorMessage = "Invalid year")]
        public int Date_of_Birth_Years { get; set; }

        [Required(ErrorMessage = "Sex is required")]
        public string? Sex { get; set; }

        public string? Educational_Level { get; set; }

        public string? Marriage { get; set; }

        public string? Category { get; set; }

        public string? Ration_Card { get; set; }

        [Required(ErrorMessage = "Aadhar Card is required")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Aadhar Card must be 12 digits")]
        public string? Aadhar_Card { get; set; }

        [Required(ErrorMessage = "Bank Account is required")]
        public string? Bank_Account { get; set; }

        [Required(ErrorMessage = "IFSC is required")]
        public string? IFSC { get; set; }

        public string? Bank_Name { get; set; }

        public string? age_proof { get; set; }

        [Required(ErrorMessage = "Age photo is required")]
        public IFormFile age_photo { get; set; }

        public string? old_member_name { get; set; }

        public string? old_application_no { get; set; }

        [Required(ErrorMessage = "Photo is required")]
        public IFormFile Photo { get; set; }

        [Required(ErrorMessage = "Signature is required")]
        public IFormFile Signature { get; set; }

        [Required(ErrorMessage = "Place is required")]
        public string? Place { get; set; }

        [Required(ErrorMessage = "Form Date is required")]
        public DateTime Form_Date { get; set; }

        public string PhotoPath { get; set; }
        public string SignaturePath { get; set; }
        public string AgePhotoPath { get; set; }
        public string OrderId { get; set; }

    }
}
