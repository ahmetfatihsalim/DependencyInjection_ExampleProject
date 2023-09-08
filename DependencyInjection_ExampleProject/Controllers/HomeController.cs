using DependencyInjection_ExampleProject.Models;
using DependencyInjection_ExampleProject.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text;

namespace DependencyInjection_ExampleProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISingletonGuidService _singletonGuidService1;
        private readonly ISingletonGuidService _singletonGuidService2;

        private readonly IScopedGuidService _scopedGuidService1;
        private readonly IScopedGuidService _scopedGuidService2;

        private readonly ITransientGuidService _transientGuidService1;
        private readonly ITransientGuidService _transientGuidService2;
        public HomeController(ISingletonGuidService singletonGuidService1,
                            ISingletonGuidService singletonGuidService2,
                            IScopedGuidService scopedGuidService1,
                            IScopedGuidService scopedGuidService2,
                            ITransientGuidService transientGuidService1,
                            ITransientGuidService transientGuidService2)
        {
            _singletonGuidService1 = singletonGuidService1;// assing our implementations to local variables
            _singletonGuidService2 = singletonGuidService2;
            _scopedGuidService1 = scopedGuidService1;
            _scopedGuidService2 = scopedGuidService2;
            _transientGuidService1 = transientGuidService1;  
            _transientGuidService2 = transientGuidService2;
        }

        public IActionResult Index()
        {
            StringBuilder messages = new StringBuilder();
            messages.Append("Transient Lifetime is simplest one. Whenever a service is requested, a new implementation is created\n");
            messages.Append("These two Guids will be different\n");
            messages.Append($"Transient 1 :  { _transientGuidService1.GetGuid()}\n");
            messages.Append($"Transient 2 :  { _transientGuidService2.GetGuid()}\n\n\n");

            messages.Append("Scoped Lifetime depends on HTTP Request. Whenever a HTTP Request is sent to server, one scoped lifetime is created\n");
            messages.Append("These two Guids will be the same. However they'll change when we reload the page.\n");
            messages.Append("Mostly this lifetime type is recommended\n");
            messages.Append($"Scoped 1 :  {_scopedGuidService1.GetGuid()}\n");
            messages.Append($"Scoped 2 :  {_scopedGuidService2.GetGuid()}\n\n\n");

            messages.Append("In singleton Lifetime, one implementation is created for the lifetime of the application\n");
            messages.Append("These two Guids will be the same. They'll only change when we restart the application\n");
            messages.Append($"Singleton 1 :  {_singletonGuidService1.GetGuid()}\n");
            messages.Append($"Singleton 2 :  {_singletonGuidService2.GetGuid()}\n\n\n");
            return Ok(messages.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}