using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Web.Http;
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
    [Route("patient")]
    public class PatientController : Controller
    {
        private IPatientRepository _patientRepository;
        public PatientController(IPatientRepository repository)
        {
            _patientRepository = repository;
        }

        [HttpGet]
        public IEnumerable<Patient> Index()
        {
            return _patientRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Patient Show(int id)
        {
            Patient patient = _patientRepository.Get(id);
            if (patient == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return patient;
        }
        [HttpPost]
        public ObjectResult PostPatient(Patient patient)
        {
            patient = _patientRepository.Add(patient);
            var response = this.StatusCode(201, patient);

            return response;
        }
        [HttpPut]
        public void PutPatient(int id, Patient patient)
        {
            patient.Patient_ID = id;
            if (!_patientRepository.Update(patient))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        [HttpDelete]
        public void DeletePatient(int id)
        {
            Patient patient = _patientRepository.Get(id);
            if (patient == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _patientRepository.Remove(id);
        }
    }
}
