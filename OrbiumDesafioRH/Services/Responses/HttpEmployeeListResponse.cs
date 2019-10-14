using OrbiumDesafioRH.Models;
using OrbiumDesafioRH.Services.Responses.Contracts;
using System.Collections.Generic;

namespace OrbiumDesafioRH.Services.Responses
{
    public class HttpEmployeeListResponse : AbstractResponse
    {
        public IEnumerable<Employee> EmployeeList { get; private set; }

        private HttpEmployeeListResponse(bool success, string message, IEnumerable<Employee> employeeList) : base(success, message)
        {
            EmployeeList = employeeList;
        }

        public HttpEmployeeListResponse(IEnumerable<Employee> employeeList) : this(true, string.Empty, employeeList)
        {

        }

        public HttpEmployeeListResponse(string message) : this(false, message, null)
        {

        }
    }
}
