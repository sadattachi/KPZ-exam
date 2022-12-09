using System.Data.Entity.Migrations;
using VetHospital_API.Models;

namespace VetHospital_API.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private int _nextID = 1;
        public Patient Add(Patient patient)
        {
            if (patient == null)
                throw new ArgumentNullException("patient");
            patient.Patient_ID = _nextID++;
            using (var db = new HospitalContext())
            {
                db.Patients.Add(patient);
                db.SaveChanges();
            }
            return patient;
        }

        public Patient? Get(int id)
        {
            using (var db = new HospitalContext())
                return db.Patients.Find(id);
        }

        public IEnumerable<Patient> GetAll()
        {
            List<Patient> patients = new List<Patient>();
            using (var db = new HospitalContext())
                foreach (var item in db.Patients)
                    patients.Add(item);
            return patients;
        }

        public void Remove(int id)
        {
            using (var db = new HospitalContext())
            {
                db.Patients.Remove(db.Patients.Find(id));
                db.SaveChanges();
            }
        }

        public bool Update(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException("patient");
            }
            using (var db = new HospitalContext())
            {
                Patient cl = db.Patients.Find(patient.Patient_ID);
                if (cl == null)
                    return false;
                db.Patients.AddOrUpdate(patient);
                db.SaveChanges();
            }
            return true;
        }
    }
}
