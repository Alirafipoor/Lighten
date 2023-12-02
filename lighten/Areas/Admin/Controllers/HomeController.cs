using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lighten.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       

    }
}
