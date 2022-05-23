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
            return View(await _bookRepos.AllBooks());
        }
        public async Task<IActionResult> GetBookById(int id)
        {
            if (id > 0)
            {
                return View(await _bookRepos.GetBookById(id));
            }
            return View(null);
        }
        public async Task<IActionResult> GetBookByTitleOrAuther(string titleOrAuther)
        {
            if (!string.IsNullOrEmpty(titleOrAuther))
            {
                return View(await _bookRepos.GetBookByTitleOrAuther(titleOrAuther));
            }
            return View(null);
        }
    }
}
