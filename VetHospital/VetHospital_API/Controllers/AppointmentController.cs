using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
using VetHospital_API.DTO;
using VetHospital_API.Models;
using VetHospital_API.Repositories;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace VetHospital_API.Controllers
{
    [ApiController]
    [Route("appointment")]
    public class AppointmentController : Controller
    {
        private IAppointmentRepository _appointmentRepository;
        public AppointmentController(IAppointmentRepository repository)
        {
            _appointmentRepository = repository;
        }

        [HttpGet]
        public IEnumerable<Appointment> Index()
        {
            return _appointmentRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Appointment Show(int id)
        {
            Appointment appointment = _appointmentRepository.Get(id);
            if (appointment == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return appointment;
        }
        [HttpPost]
        public ObjectResult PostAppointment(AppointmentDTO appointmentDTO)
        {
            Appointment toAdd = new Appointment()
            {
                Date = appointmentDTO.Date,
                Time = appointmentDTO.Time,
                Patient_ID = appointmentDTO.Patient_ID
            };
            Appointment appointment = _appointmentRepository.Add(toAdd);
            var response = this.StatusCode(201, appointment);

            return response;
        }
        [HttpPut]
        public void PutAppointment(int id, AppointmentDTO appointmentDTO)
        {
            Appointment toUpdate = new Appointment()
            {
                Appointment_ID = id,
                Date = appointmentDTO.Date,
                Time = appointmentDTO.Time,
                Patient_ID = appointmentDTO.Patient_ID
            };
            if (!_appointmentRepository.Update(toUpdate))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        [HttpDelete]
        public void DeleteAppointment(int id)
        {
            Appointment appointment = _appointmentRepository.Get(id);
            if (appointment == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _appointmentRepository.Remove(id);
        }
    }
}
