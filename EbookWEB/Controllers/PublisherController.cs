using Microsoft.AspNetCore.Mvc;

namespace EbookWEB.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
