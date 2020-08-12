using Microsoft.AspNetCore.Mvc;

namespace ApiDrapper.Api.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("rota/01")]
        public IActionResult Get()
        {
            throw new System.Exception("Teste do LOG - ILMAH --https://app.elmah.io/logsetup?logId=2eaaa070-351e-4d8b-b957-c292824aa821#aspnetcore");
        }

        [HttpPost]
        [Route("rota/01")]
        public IActionResult Post()
        {
            return View();
        }

        [HttpPut]
        [Route("rota/01")]
        public IActionResult Put()
        {
            return View();
        }

        [HttpDelete]
        [Route("rota/01")]
        public IActionResult Delete()
        {
            return View();
        }
    }
}