using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWeb.Logic
{
    public class BookRepos
    {
        private readonly BookStoreWebContext _db;
        public BookRepos(BookStoreWebContext db)
        {
            _db = db;
        }

        public async Task<List<BookVM>> AllBooks()
        {
            var books = await _db.Books.ToListAsync();
            if (books?.Any() == true)
            {
                var booksVm = new List<BookVM>();
                foreach (var book in books)
                {
                    booksVm.Add(new BookVM()
                    {
                        author = book.author,
                        id = book.id,
                        pages = book.pages,
                        title = book.title,
                    });
                }
                return booksVm;
            }
            return null;
        }
    }
}
