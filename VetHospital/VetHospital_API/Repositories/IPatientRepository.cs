using VetHospital_API.Models;

namespace VetHospital_API.Repositories
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAll();
        Patient? Get(int id);
        Patient Add(Patient patient);
        void Remove(int id);
        bool Update(Patient patient);
    }
}
