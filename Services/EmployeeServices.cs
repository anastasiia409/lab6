using lab6.Data;
using lab6.Database;
using Microsoft.EntityFrameworkCore;

namespace lab6.Services
{
    public class EmployeeServices
    {
        protected readonly DbConnection _db;
        public EmployeeServices(DbConnection db)
        {
            _db = db;
        }

        public async Task<List<Employee>> GetEmployees()
        {

            return await _db.Employees.OrderBy(p => p.Name).ToListAsync(); 
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _db.Employees.FirstAsync(p => p.Id == id);
        }

        public async Task AddEmployee(Employee employee)
        {
            await _db.Employees.AddAsync(employee);
            await _db.SaveChangesAsync();
        }

        public async Task EditEmployee(Employee employee)
        {
            _db.Employees.Update(employee);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteEmployee(Employee employee)
        {
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
        }
    }
}
