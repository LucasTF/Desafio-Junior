using Newtonsoft.Json;
using OrbiumDesafioRH.Models;
using OrbiumDesafioRH.Resources;
using OrbiumDesafioRH.Services.Contracts;
using OrbiumDesafioRH.Services.Responses;
using OrbiumDesafioRH.Services.Responses.Implementations;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OrbiumDesafioRH.Services.Implementations
{
    public class HttpClientService : IHttpClientService
    {

        private readonly HttpClient _client;

        public HttpClientService(HttpClient client)
        {
            _client = client;
        }

        public Task<HttpEmployeeResponse> Delete(int id, string url)
        {
            throw new System.NotImplementedException();
        }

        public async Task<HttpEmployeeListResponse> Get(string url)
        {
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var employees = JsonConvert.DeserializeObject<IEnumerable<Employee>>(json);
                return new HttpEmployeeListResponse(employees);
            }
            else
            {
                return new HttpEmployeeListResponse("Não foi possível recuperar os funcionários.");
            }
        }

        public async Task<HttpEmployeeResponse> Get(int id, string url)
        {
            var response = await _client.GetAsync(url + "/" + id);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var employee = JsonConvert.DeserializeObject<Employee>(result);
                return new HttpEmployeeResponse(employee);
            }
            else
            {
                return new HttpEmployeeResponse(result);
            }
        }

        public async Task<HttpEmployeeResponse> Post(EmployeeResource resource, string url)
        {
            var json = JsonConvert.SerializeObject(resource);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var employee = JsonConvert.DeserializeObject<Employee>(result);
                return new HttpEmployeeResponse(employee);
            }
            else
            {
                return new HttpEmployeeResponse(result);
            }
        }

        public async Task<HttpEmployeeResponse> Put(int id, EmployeeResource resource, string url)
        {
            var json = JsonConvert.SerializeObject(resource);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(url + "/" + id, content);
            var result = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var employee = JsonConvert.DeserializeObject<Employee>(result);
                return new HttpEmployeeResponse(employee);
            }
            else
            {
                return new HttpEmployeeResponse(result);
            }
        }
    }
}
