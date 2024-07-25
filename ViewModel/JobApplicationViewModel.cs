using Microsoft.AspNetCore.Http;
using System;

namespace ShagunGraminHealth.ViewModel
{
    public class JobApplicationViewModel
    {
        public string? ApplicationId { get; set; }
        public string? AdvertisementNo { get; set; }
        public string CategoryNo { get; set; }
        public string Post { get; set; }
        public string CandidateName { get; set; }
        public string FatherName { get; set; }
        public int DateOfBirthDays { get; set; }
        public int DateOfBirthMonths { get; set; }
        public int DateOfBirthYears { get; set; }
        public string Sex { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Category { get; set; }
        public string? PhysicallyHandicapped { get; set; }
        public string? Domicile { get; set; }
        public string? Nationality { get; set; }
        public string? Pincode { get; set; }
        public string? Address { get; set; }
        public string? VisibleIdentification { get; set; }
        public string? Agree { get; set; }
        public string? Place { get; set; }
        public IFormFile? Photo { get; set; }
        public IFormFile? Signature { get; set; }
        public IFormFile? AgePhoto { get; set; }

        // Educational qualifications properties
        public string EducationalQualifications_8th { get; set; }
        public string YearOfPassing_8th { get; set; }
        public string MarksObtained_8th { get; set; }
        public string TotalMarks_8th { get; set; }
        public string Percentage_8th { get; set; }
        public string Division_8th { get; set; }
        public string BoardUniversity_8th { get; set; }
        public string Subjects_8th { get; set; }

        public string EducationalQualifications_10th { get; set; }
        public string YearOfPassing_10th { get; set; }
        public string MarksObtained_10th { get; set; }
        public string TotalMarks_10th { get; set; }
        public string Percentage_10th { get; set; }
        public string Division_10th { get; set; }
        public string BoardUniversity_10th { get; set; }
        public string Subjects_10th { get; set; }

        public string EducationalQualifications_12th { get; set; }
        public string YearOfPassing_12th { get; set; }
        public string MarksObtained_12th { get; set; }
        public string TotalMarks_12th { get; set; }
        public string Percentage_12th { get; set; }
        public string Division_12th { get; set; }
        public string BoardUniversity_12th { get; set; }
        public string Subjects_12th { get; set; }

        public string EducationalQualifications_ITI { get; set; }
        public string YearOfPassing_ITI { get; set; }
        public string MarksObtained_ITI { get; set; }
        public string TotalMarks_ITI { get; set; }
        public string Percentage_ITI { get; set; }
        public string Division_ITI { get; set; }
        public string BoardUniversity_ITI { get; set; }
        public string Subjects_ITI { get; set; }
    }
}
