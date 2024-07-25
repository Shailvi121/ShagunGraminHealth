using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShagunGraminHealth.Models
{
    public class NominatedDetail
    {
       
        public int Serial { get; set; }
        public string NominatedPersonName { get; set; }
        public string Relation { get; set; }
        public int Age { get; set; }
        public string Percentage { get; set; }
       
    }
}
