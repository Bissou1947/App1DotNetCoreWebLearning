using BookStoreWeb.Logic;
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BookStoreWeb.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepos _bookRepos;
        private readonly LanguageRepos _languageRepos;
        private readonly IWebHostEnvironment _env;

        public BookController(BookRepos bookRepos, LanguageRepos languageRepos,
            IWebHostEnvironment env)
        {
            _bookRepos = bookRepos;
            _languageRepos = languageRepos;
            _env = env;
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
        public async Task<IActionResult> AddBook(bool isadded = false, int id = 0)
        {
            ViewBag.isadded = isadded;
            ViewBag.id = id;
            ViewBag.language = await _languageRepos.AllDropDawnLists();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook(BookVM bookVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.language = await _languageRepos.AllDropDawnLists();
                ModelState.AddModelError("", "Error: inputs is wrong.");
                return View(bookVM);
            }
            if (bookVM.coverPhoto != null)
            {
                string folder = "book/cover/";
                bookVM.coverImagePath = await StoredCoverAndGalleryPhotosInApp(folder, bookVM.coverPhoto);
            }
            if (bookVM.galleryPhotos != null)
            {
                string folder = "book/gallery/";
                bookVM.galleryImagesPaths = new List<BookGalleryVM>();

                foreach (var file in bookVM.galleryPhotos)
                {
                    bookVM.galleryImagesPaths.Add(new BookGalleryVM()
                    {
                        path = await StoredCoverAndGalleryPhotosInApp(folder, file),
                        name = file.FileName
                    });
                }
            }
            var check = await _bookRepos.AddBook(bookVM);
            if (check > 0)
            {
                return RedirectToAction("AddBook", new { isadded = true, id = check });
            }
            ViewBag.language = await _languageRepos.AllDropDawnLists();
            ModelState.AddModelError("", "Error: Record did not added.");
            return View(bookVM);
        }

        private async Task<string> StoredCoverAndGalleryPhotosInApp(string folder, IFormFile formFile)
        {
            folder += Guid.NewGuid().ToString() + "_" + formFile.FileName;
            string serverPath = Path.Combine(_env.WebRootPath, folder);
            await formFile.CopyToAsync(new FileStream(serverPath, FileMode.Create));
            return "/" + folder;
        }
    }
}
