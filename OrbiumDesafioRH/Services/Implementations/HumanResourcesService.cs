using OrbiumDesafioRH.Models;
using OrbiumDesafioRH.Repositories.Contracts;
using OrbiumDesafioRH.Services.Contracts;
using OrbiumDesafioRH.Services.Responses.Implementations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrbiumDesafioRH.Services.Implementations
{
    public class HumanResourcesService : IHumanResourcesService
    {

        private readonly IEmployeeRepository _repository;

        public HumanResourcesService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<HttpEmployeeResponse> AddEmployee(Employee employee)
        {
            try
            {
                await _repository.Add(employee);
                return new HttpEmployeeResponse(employee);
            }
            catch(Exception ex)
            {
                return new HttpEmployeeResponse($"Um erro ocorreu durante a inserção do novo funcionário: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Employee>> FindAllEmployees()
        {
            return await _repository.FindAll();
        }

        public async Task<HttpEmployeeResponse> FindEmployeeById(int id)
        {
            var foundEmployee = await _repository.FindById(id);
            if(foundEmployee == null)
            {
                return new HttpEmployeeResponse("Funcionário não encontrado.");
            }
            return new HttpEmployeeResponse(foundEmployee);
        }

        public async Task<HttpEmployeeResponse> FindEmployeeByEmail(string email)
        {
            var foundEmployee = await _repository.FindByEmail(email);
            if(foundEmployee == null)
            {
                return new HttpEmployeeResponse("Funcionário não encontrado.");
            }
            return new HttpEmployeeResponse(foundEmployee);
        }

        public async Task<HttpEmployeeResponse> RemoveEmployee(int id)
        {
            var foundEmployee = await _repository.FindById(id);
            if(foundEmployee == null)
            {
                return new HttpEmployeeResponse("Funcionário não encontrado.");
            }
            try
            {
                await _repository.Remove(foundEmployee);
                return new HttpEmployeeResponse(foundEmployee);
            }
            catch(Exception ex)
            {
                return new HttpEmployeeResponse($"Um erro ocorreu ao tentar deletar o funcionário: {ex.Message}");
            }
        }

        public async Task<HttpEmployeeResponse> UpdateEmployee(int id, Employee employee)
        {
            var foundEmployee = await _repository.FindById(id);
            if(foundEmployee == null)
            {
                return new HttpEmployeeResponse("Funcionário não encontrado.");
            }

            foundEmployee.Name = employee.Name;
            foundEmployee.Email = employee.Email;
            foundEmployee.Job = employee.Job;
            foundEmployee.Salary = employee.Salary;

            try
            {
                await _repository.Update(foundEmployee);
                return new HttpEmployeeResponse(foundEmployee);
            }
            catch(Exception ex)
            {
                return new HttpEmployeeResponse($"Um erro ocorreu ao tentar atualizar o funcionário: {ex.Message}");
            }
        }
    }
}
