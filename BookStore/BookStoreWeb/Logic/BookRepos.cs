using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
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
            return await _db.Books.Select(book => new BookVM {
                author = book.author,
                id = book.id,
                pages = book.pages,
                title = book.title,
                created = book.created,
                modify = book.modify,
                language = book.Language.name,
                coverImagePath = book.coverImagePath,
            }).ToListAsync();
        }

        public async Task<BookVM> GetBookById(int id)
        {
            return await _db.Books.Where(a=> a.id == id).Select(book => new BookVM {
                author = book.author,
                id = book.id,
                pages = book.pages,
                title = book.title,
                created = book.created,
                modify = book.modify,
                language = book.Language.name,
                galleryImagesPaths = book.BookGallery.Select(b=> new BookGalleryVM
                {
                    name = b.name,
                    path = b.path,
                }).ToList()
            }).FirstOrDefaultAsync();
        }
        public async Task<BookVM> GetBookByTitleOrAuther(string titleOrAuther)
        {
            return await _db.Books.Where(a=> a.title == titleOrAuther ||a.author == titleOrAuther).Select(book => new BookVM
            {
                author = book.author,
                id = book.id,
                pages = book.pages,
                title = book.title,
                created = book.created,
                modify = book.modify,
                language = book.Language.name,
                galleryImagesPaths = book.BookGallery.Select(b => new BookGalleryVM
                {
                    name = b.name,
                    path = b.path,
                }).ToList()
            }).FirstOrDefaultAsync();
        }
        public async Task<int> AddBook(BookVM bookVM)
        {
            var book = new Book()
            {
                author = bookVM.author,
                pages = bookVM.pages,
                title = bookVM.title,
                created = DateTime.Now,
                modify = DateTime.Now,
                languageId = bookVM.languageId,
                coverImagePath = bookVM.coverImagePath,
            };
            book.BookGallery = new List<BookGallery>();
            foreach (var file in bookVM.galleryImagesPaths)
            {
                book.BookGallery.Add(new BookGallery()
                {
                    name = file.name,
                    path = file.path
                });
            }
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
            return book.id;
        }
    }
}
