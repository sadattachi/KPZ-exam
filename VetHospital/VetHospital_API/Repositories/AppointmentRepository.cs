using Microsoft.AspNetCore.Routing.Matching;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using VetHospital_API.Models;

namespace VetHospital_API.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        
        private int _nextID = 1;
        public Appointment Add(Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException("appointment");
            appointment.Appointment_ID = _nextID++;
            using (var db = new HospitalContext())
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
            }
            return appointment;
        }

        public Appointment? Get(int id)
        {
            using (var db = new HospitalContext())
                return db.Appointments.Include(a => a.Patient).FirstOrDefault(a => a.Appointment_ID == id);
        }

        public IEnumerable<Appointment> GetAll()
        {
            List<Appointment> appointments = new List<Appointment>();
            using (var db = new HospitalContext())
                return db.Appointments.Include(a => a.Patient).ToList();
        }

        public void Remove(int id)
        {
            using (var db = new HospitalContext())
            {
                db.Appointments.Remove(db.Appointments.Find(id));
                db.SaveChanges();
            }
        }

        public bool Update(Appointment appointment)
        {
            if (appointment == null)
            {
                throw new ArgumentNullException("appointment");
            }
            using (var db = new HospitalContext())
            {
                Appointment a = db.Appointments.Find(appointment.Appointment_ID);
                if (a == null)
                    return false;
                db.Appointments.AddOrUpdate(appointment);
                db.SaveChanges();
            }
            return true;
        }
    }
}
