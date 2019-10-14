using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrbiumDesafioRH.Converters;
using OrbiumDesafioRH.Resources;
using OrbiumDesafioRH.Services.Contracts;
using OrbiumDesafioRH.Settings;

namespace OrbiumDesafioRH.Controllers
{
    public class RhController : Controller
    {
        private readonly ILogger<RhController> _logger;
        private readonly IHttpClientService _service;
        private readonly EmployeeConverter _converter;
        private readonly AppSettings _appSetings;

        public RhController(ILogger<RhController> logger, IHttpClientService service, EmployeeConverter converter, IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            _service = service;
            _converter = converter;
            _appSetings = appSettings.Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _service.Get(id, _appSetings.RestApiUrl);
            if (!response.Success)
            {
                return View("NotFound");
            }
            var employeeResource = _converter.ConvertFromModel(response.Employee);
            return View(employeeResource);

        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] EmployeeResource employeeResource)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeResource);
            }
            var response = await _service.Post(employeeResource, _appSetings.RestApiUrl);
            if (!response.Success)
            {
                ModelState.AddModelError("Email", response.Message);
                return View(employeeResource);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [FromForm] EmployeeResource employeeResource)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeResource);
            }
            var response = await _service.Put(id, employeeResource, _appSetings.RestApiUrl);
            if (!response.Success)
            {
                ModelState.AddModelError("Email", response.Message);
                return View(employeeResource);
            }
            return RedirectToAction("Index");
        }
    }
}
