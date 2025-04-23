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
    public class SemesterService
    {
        private readonly AppDbContext _context;

        public SemesterService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Semester>> GetAllSemestersAsync()
        {
            return await _context.Semesters.ToListAsync();
        }

        public async Task<Semester> GetSemesterByIdAsync(int id)
        {
            return await _context.Semesters.FindAsync(id);
        }

        public async Task AddSemesterAsync(Semester semester)
        {
            _context.Semesters.Add(semester);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSemesterAsync(Semester semester)
        {
            _context.Semesters.Update(semester);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSemesterAsync(int id)
        {
            var semester = await _context.Semesters.FindAsync(id);
            if (semester != null)
            {
                _context.Semesters.Remove(semester);
                await _context.SaveChangesAsync();
            }
        }
    }

}