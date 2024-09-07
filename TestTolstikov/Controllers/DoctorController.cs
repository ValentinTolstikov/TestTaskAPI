using Application.DTO;
using Application.Services;
using DAL.Entity;
using DAL.Enums;
using Microsoft.AspNetCore.Mvc;

namespace TestTolstikov.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController(DoctorService doctorService) : ControllerBase
    {
        private readonly DoctorService _doctorService = doctorService;

        [HttpGet("/Doctors")]
        public ActionResult<IEnumerable<PatientEditDTO>> Get(string SortOption)
        {
            try
            {
                DoctorSortOptions opt = (DoctorSortOptions)(Enum.Parse(typeof(DoctorSortOptions), SortOption));
                return Ok(_doctorService.GetDoctors(opt).AsEnumerable());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("/Doctor/{id}")]
        public ActionResult<Patient> Get(int id)
        {
            try
            {
                return Ok(_doctorService.GetDoctor(id));
            }
            catch
            {
                return BadRequest("Пользователь не найден.");
            }
        }

        [HttpPost("/Doctor")]
        public ActionResult<Patient> Post([FromBody] DoctorDTO doctor)
        {
            try
            {
                _doctorService.AddDoctor(doctor);
                return Ok(doctor);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("/Doctor/{id}")]
        public ActionResult<Patient> Put([FromBody] DoctorDTO doctor, int id)
        {
            try
            {
                doctor.Id = id;
                _doctorService.EditDoctor(doctor);
                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("/Doctor/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                Doctor d = _doctorService.GetDoctor(id);
                _doctorService.DeleteDoctor(d);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
