using OrbiumDesafioRH.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrbiumDesafioRH.Repositories.Contracts
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> FindAll();
        public Task<Employee> FindById(int id);
        public Task<Employee> FindByEmail(string email);
        public Task Add(Employee employee);
        public Task Update(Employee employee);
        public Task Remove(Employee employee);
    }
}
