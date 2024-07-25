namespace ShagunGraminHealth.Models
{
    public class JobAdvertisement
    {
        public int Id { get; set; }
        public string AdvertisementNo { get; set; }
        public DateTime AdvertisementDate { get; set; }
        public DateTime LastDate { get; set; }
        public string Category { get; set; }
        public string Post { get; set; }
        public decimal ApplicationFeeGEN { get; set; }
        public decimal ApplicationFeeOTH { get; set; }  // Assuming this field is also needed
        public string FileUrl { get; set; }
        public string Status { get; set; }
    }
}
