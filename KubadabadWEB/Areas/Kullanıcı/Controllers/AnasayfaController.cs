using Microsoft.AspNetCore.Mvc;

namespace Kubadabad.Areas.Kullanıcı.Controllers
{
    [Area("Kullanıcı")]
    public class AnasayfaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
