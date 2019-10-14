using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OrbiumDesafioRH.Models;
using OrbiumDesafioRH.Services.Contracts;
using OrbiumDesafioRH.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrbiumDesafioRH.Views.ViewComponents
{
    public class EmployeeTableViewComponent : ViewComponent
    {
        private readonly IHttpClientService _service;
        private readonly AppSettings _appSettings;

        public EmployeeTableViewComponent(IHttpClientService service, IOptions<AppSettings> appSettings)
        {
            _service = service;
            _appSettings = appSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _service.Get(_appSettings.RestApiUrl);
            if (!response.Success)
            {
                return View(new List<Employee>());
            }
            return View(response.EmployeeList);
        }
    }
}
