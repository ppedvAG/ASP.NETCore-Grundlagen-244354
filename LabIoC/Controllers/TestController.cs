using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LabIoC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Hello World");
        }
    }
}
