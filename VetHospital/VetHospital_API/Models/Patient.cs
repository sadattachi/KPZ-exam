using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetHospital_API.Models
{
    public class Patient
    {
        [Key]
        public int Patient_ID { get; set; }
        public string Type { get; set; }
        public string OwnerLastname { get; set; }
        public string BirthDate { get; set; }
        public string Diagnosis { get; set; }

    }
}
