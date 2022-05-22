using BookStoreWeb.Logic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStoreWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepos _bookRepos;
        public BookController(BookRepos bookRepos)
        {
            _bookRepos = bookRepos;
        }
        public async Task<IActionResult> AllBooks()
        {
            return Json(await _bookRepos.AllBooks());
        }
    }
}
