using Microsoft.AspNetCore.Mvc;

namespace Vspt.BackEnd.Api.Controllers
{
    public class FlagmanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
