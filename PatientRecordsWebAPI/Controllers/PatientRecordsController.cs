using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PatientRecordsWebAPI.Interface;
using PatientRecordsWebAPI.Model;
using PatientRecordsWebAPI.Repository;

namespace PatientRecordsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientRecordsController : ControllerBase
    {
        private IPatient patientRepository = new PatientRepository();

        [HttpGet]
        public IActionResult GetAllPatients()
        {
            try 
            {
                return Ok(patientRepository.RetrieveAllPatients());
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id) 
        {
            try
            {
                return Ok(patientRepository.RetrievePatient(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddPatient(Patient patient) 
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created,patientRepository.AddPatient(patient));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatient(int id, Patient patient)
        {
            try
            {
                return Ok(patientRepository.UpdatePatient(id, patient));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePatient(int id)
        {
            try
            {
                return Ok(patientRepository.DeletePatient(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
