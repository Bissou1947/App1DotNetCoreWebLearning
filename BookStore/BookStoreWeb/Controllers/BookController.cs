using BookStoreWeb.Logic;
using BookStoreWeb.Models;
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
        public IActionResult AddBook(bool isadded=false,int id=0)
        {
            ViewBag.isadded = isadded;
            ViewBag.id = id;
            return  View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook(BookVM bookVM) 
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("","Error: inputs is wrong.");
                return View(bookVM);
            }
            var check = await _bookRepos.AddBook(bookVM);
            if (check > 0)
            {
                return RedirectToAction("AddBook", new { isadded = true,id = check });
            }
            ModelState.AddModelError("", "Error: Record did not added.");
            return View(bookVM);
        }
    }
}
