using Dsw2026Ej15.Domain;
using Dsw2026Ej15.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dsw2026Ej15.Data
{
    internal class PercistenceEf : IPersistence
    {
        private readonly Dsw2026Ej15DbContext _context;

        public PercistenceEf(Dsw2026Ej15DbContext context)
        {
            _context = context;
        }
        public async Task AddDoctorAsync(Doctor doctor)
        {
             _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Doctor>> GetActiveDoctorsAsync()
        {
            return _context.Doctors.Where(d => d.IsActive);
        }

        public async Task<Doctor?> GetDoctorByIdAsync(Guid id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id && d.IsActive);
        }

        public Task<Speciality?> GetSpecialityByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDoctorAsync(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
