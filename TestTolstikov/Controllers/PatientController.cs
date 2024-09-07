using Microsoft.AspNetCore.Mvc;
using Application.DTO;
using Application.Services;
using DAL.Enums;
using DAL.Entity;

namespace TestTolstikov.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController(PatientService patientService) : ControllerBase
    {
        private readonly PatientService _patientService = patientService;

        [HttpGet("/Patients")]
        public ActionResult<IEnumerable<PatientEditDTO>> Get(string SortOption)
        {
            try
            {
                PacientSortOptions opt = (PacientSortOptions)(Enum.Parse(typeof(PacientSortOptions), SortOption));
                return Ok(_patientService.GetPatients(opt).AsEnumerable());
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpGet("/Patient/{id}")]
        public ActionResult<Patient> Get(int id)
        {
            try
            {
                return Ok(_patientService.GetPatient(id));
            }
            catch
            {
                return BadRequest("Пользователь не найден.");
            }
        }

        [HttpPost("/Patient")]
        public ActionResult<Patient> Post([FromBody]PatientDTO patient)
        {
            try
            {
                _patientService.AddPatient(patient);
                return Ok(patient);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("/Patient/{id}")]
        public ActionResult<Patient> Put([FromBody] PatientDTO patient,int id)
        {
            try
            {
                patient.Id = id;
                _patientService.EditPatient(patient);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("/Patient/{id}")]
        public ActionResult Delete(int id) 
        {
            try
            {
                Patient p = _patientService.GetPatient(id);
                _patientService.DeletePatient(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

    }
}
