using OrbiumDesafioRH.Models;
using OrbiumDesafioRH.Services.Responses.Contracts;

namespace OrbiumDesafioRH.Services.Responses.Implementations
{
    public class HttpEmployeeResponse : AbstractResponse
    {

        public Employee Employee { get; private set; }

        private HttpEmployeeResponse(bool success, string message, Employee employee) : base(success, message)
        {
            Employee = employee;
        }

        public HttpEmployeeResponse(Employee employee) : this(true, string.Empty, employee)
        {

        }

        public HttpEmployeeResponse(string message) : this(false, message, null)
        {

        }
    }
}
