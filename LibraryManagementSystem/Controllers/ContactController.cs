using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class ContactController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}