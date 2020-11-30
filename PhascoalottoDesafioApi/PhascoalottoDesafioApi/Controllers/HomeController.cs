using Microsoft.AspNetCore.Mvc;

namespace PhascoalottoDesafioApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}