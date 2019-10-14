using OrbiumDesafioRH.Converters.Implementations;
using OrbiumDesafioRH.Models;
using OrbiumDesafioRH.Resources;
using System;

namespace OrbiumDesafioRH.Converters
{
    public class EmployeeConverter : AbstractConverter<Employee, EmployeeResource>
    {

        protected override EmployeeResource NullSafeConvertFromModel(Employee model)
        {
            var employeeResource = new EmployeeResource
            {
                Name = model.Name,
                Job = model.Job,
                Email = model.Email,
                Salary = model.Salary
            };

            return employeeResource;
        }

        protected override Employee NullSafeConvertToModel(EmployeeResource viewItem)
        {
            var employee = new Employee
            {
                Name = viewItem.Name,
                Job = viewItem.Job,
                Email = viewItem.Email,
                Salary = Math.Round(viewItem.Salary, 2),
                HiringDate = DateTime.Now,
            };
            return employee;
        }
    }
}
