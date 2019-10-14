using OrbiumDesafioRH.Resources;
using OrbiumDesafioRH.Services.Responses;
using OrbiumDesafioRH.Services.Responses.Implementations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrbiumDesafioRH.Services.Contracts
{
    public interface IHttpClientService
    {
        public Task<HttpEmployeeListResponse> Get(string url);
        public Task<HttpEmployeeResponse> Get(int id, string url);
        public Task<HttpEmployeeResponse> Post(EmployeeResource resource, string url);
        public Task<HttpEmployeeResponse> Put(int id, EmployeeResource resource, string url);
        public Task<HttpEmployeeResponse> Delete(int id, string url);
    }
}
