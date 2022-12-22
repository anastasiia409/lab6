using lab6.Data;
using lab6.Database;
using Microsoft.EntityFrameworkCore;

namespace lab6.Services
{
    public class ProjectServices
    {
        protected readonly DbConnection _db;
        public ProjectServices(DbConnection db)
        {
            _db = db;
        }

        public async Task<List<Project>> GetProjects()
        {

            return await _db.Projects.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Project> GetProject(int id)
        {
            return await _db.Projects.FirstAsync(p => p.Id == id);
        }

        public async Task AddProject(Project project)
        {
            await _db.Projects.AddAsync(project);
            await _db.SaveChangesAsync();
        }

        public async Task EditProject(Project project)
        {
            _db.Projects.Update(project);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteProject(Project project)
        {
            _db.Projects.Remove(project);
            await _db.SaveChangesAsync();
        }
    }
}
