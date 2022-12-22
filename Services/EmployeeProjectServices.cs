using lab6.Data;
using lab6.Database;
using Microsoft.EntityFrameworkCore;

namespace lab6.Services
{
    public class EmployeeProjectServices
    {
        protected readonly DbConnection _db;
        public EmployeeProjectServices(DbConnection db)
        {
            _db = db;
        }

        public async Task<List<EmployeeProject>> GetEmployeeProjects()
        {

            return await _db.EmployeeProjects.
                    OrderBy(p => p.Id).
                    Include(p => p.Employee).
                    Include(p => p.Project).
                    Include(p => p.Position).
                    ToListAsync();
        }

        public async Task<EmployeeProject> GetEmployeeProject(int id)
        {
            return await _db.EmployeeProjects.FirstAsync(p => p.Id == id);
        }

        public async Task AddEmployeeProject(EmployeeProject eproject)
        {
            await _db.EmployeeProjects.AddAsync(eproject);
            await _db.SaveChangesAsync();
        }

        public async Task EditEmployeeProject(EmployeeProject eproject)
        {
            _db.EmployeeProjects.Update(eproject);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteEmployeeProject(EmployeeProject eproject)
        {
            _db.EmployeeProjects.Remove(eproject);
            await _db.SaveChangesAsync();
        }
    }
}
