using LibraryManagementSystem.Data.Handlers;
using LibraryManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                AuthorCount = new AuthorHandler().GetAuthorCount(),
                CustomerCount = new CustomerHandler().GetCustomerCount(),
                BookCount = new BookHandler().GetBookCount(),
                LendBookCount = new BookHandler().GetLendCount(x => x.Customer != null)
            };
            return View(homeViewModel);
        }
    }
}