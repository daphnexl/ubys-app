using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ubys_app.Data;
using ubys_app.MVVM.Model;

namespace ubys_app.Services
{
    public class EnrollmentService
    {
        private readonly AppDbContext _context;

        public EnrollmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _context.Enrollments
                .Include(e => e.Student).ThenInclude(s => s.User)
                .Include(e => e.Course).ThenInclude(c => c.Teacher)
                .Include(e => e.Semester)
                .ToListAsync();
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(int id)
        {
            return await _context.Enrollments
                .Include(e => e.Student).ThenInclude(s => s.User)
                .Include(e => e.Course)
                .Include(e => e.Semester)
                .FirstOrDefaultAsync(e => e.Enrollment_id == id);
        }

        public async Task AddEnrollmentAsync(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEnrollmentAsync(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEnrollmentAsync(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                await _context.SaveChangesAsync();
            }
        }
    }

}
