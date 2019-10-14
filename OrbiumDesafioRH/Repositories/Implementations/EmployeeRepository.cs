using Microsoft.EntityFrameworkCore;
using OrbiumDesafioRH.Models;
using OrbiumDesafioRH.Models.Context;
using OrbiumDesafioRH.Repositories.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrbiumDesafioRH.Repositories.Implementations
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly RhContext _ctx;

        public EmployeeRepository(RhContext ctx)
        {
            _ctx = ctx;
        }

        public async Task Add(Employee employee)
        {
            await _ctx.Employees.AddAsync(employee);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> FindAll()
        {
            return await _ctx.Employees.ToListAsync();
        }

        public async Task<Employee> FindById(int id)
        {
            return await _ctx.Employees.FindAsync(id);
        }

        public async Task<Employee> FindByEmail(string email)
        {
            return await _ctx.Employees.FirstOrDefaultAsync(emp => emp.Email == email);
        }

        public async Task Remove(Employee employee)
        {
            _ctx.Remove(employee);
            await _ctx.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            _ctx.Employees.Update(employee);
            await _ctx.SaveChangesAsync();
        }
    }
}
