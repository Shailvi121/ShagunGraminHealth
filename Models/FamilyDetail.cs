using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShagunGraminHealth.Models
{
    public class FamilyDetail
    {
       
        public int Serial { get; set; }
        public string FamilyMemberName { get; set; }
        public string Relation { get; set; }
        public int Age { get; set; }
        public string AadharNumber { get; set; }
        public string EducationalLevel { get; set; }
        public string SchoolName { get; set; }
    }
}
