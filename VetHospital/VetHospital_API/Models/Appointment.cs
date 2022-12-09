using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetHospital_API.Models
{
    public class Appointment
    {
        [Key]
        public int Appointment_ID { get; set; }
        public string Date{ get; set; }
        public string Time{ get; set; }

        public int Patient_ID { get; set; }
        [ForeignKey(nameof(Patient_ID))]
        public Patient Patient { get; set; }
    }
}
