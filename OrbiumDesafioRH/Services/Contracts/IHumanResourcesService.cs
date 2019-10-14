using OrbiumDesafioRH.Models;
using OrbiumDesafioRH.Services.Responses.Implementations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrbiumDesafioRH.Services.Contracts
{
    public interface IHumanResourcesService
    {
        public Task<IEnumerable<Employee>> FindAllEmployees();
        public Task<HttpEmployeeResponse> FindEmployeeById(int id);
        public Task<HttpEmployeeResponse> FindEmployeeByEmail(string email);
        public Task<HttpEmployeeResponse> AddEmployee(Employee employee);
        public Task<HttpEmployeeResponse> UpdateEmployee(int id, Employee employee);
        public Task<HttpEmployeeResponse> RemoveEmployee(int id);
    }
}
