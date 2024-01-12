using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class Patient
    {
        public int PATIENT_ID { get; set; }
        public string? PATIENT_NAME { get; set; }
        public string? PATIENT_LNAME { get; set; }
        public string? PAT_TELEPHONE { get; set; }
        public string? TC_NO { get; set; }
        public string? GENDER { get; set; }
        public DateTime? BIRTH_DATE { get; set; }
        public DateTime? RECORD_DATE { get; set; }
    }
}
