using VetHospital_API.Models;

namespace VetHospital_API.Repositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAll();
        Appointment? Get(int id);
        Appointment Add(Appointment appointment);
        void Remove(int id);
        bool Update(Appointment appointment);
    }
}
