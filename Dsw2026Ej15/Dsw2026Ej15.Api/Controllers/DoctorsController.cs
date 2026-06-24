using Dsw2026Ej15.Api.Models;
using Dsw2026Ej15.Domain;
using Dsw2026Ej15.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Dsw2026Ej15.Api.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IPersistence _persistence;
        public DoctorsController(IPersistence persistence)
        {
            _persistence = persistence;
        }


        
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] DoctorModel.Request request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ValidationException("El nombre es requerido.");
            }

            if (string.IsNullOrWhiteSpace(request.LicenseNumber))
            {
                throw new ValidationException("El numero de licencia es requerido.");
            }

            var speciality = await _persistence.GetSpecialityByIdAsync(request.SpecialityId);
            if (speciality == null)
            {
                throw new ValidationException("La especialidad indicada no existe.");
            }

            var doctor = new Doctor(request.Name, request.LicenseNumber, speciality);
            await _persistence.AddDoctorAsync(doctor);

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var activeDoctors = await _persistence.GetActiveDoctorsAsync();

            var response = activeDoctors.Select(d => new DoctorModel.Response(
                d.Name,
                d.LicenseNumber,
                d.Speciality?.Name ?? string.Empty
            ));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var doctor = await _persistence.GetDoctorByIdAsync(id);

            if (doctor == null || !doctor.IsActive)
            {
                return NotFound();
            }

            var response = new DoctorModel.Response(
                doctor.Name,
                doctor.LicenseNumber,
                doctor.Speciality?.Name ?? string.Empty
            );  

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var doctor = await _persistence.GetDoctorByIdAsync(id);

            if (doctor == null || !doctor.IsActive)
            {
                return NotFound();
            }

            doctor.Deactivate();

            await _persistence.UpdateDoctorAsync(doctor);

            return NoContent();
        }
    }
}
