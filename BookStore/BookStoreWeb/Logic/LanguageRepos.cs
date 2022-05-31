using BookStoreWeb.Data;
using BookStoreWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWeb.Logic
{
    public class LanguageRepos
    {
        private readonly BookStoreWebContext _db;
        public LanguageRepos(BookStoreWebContext db)
        {
            _db = db;
        }
        public async Task<GeneralDropDawnVM> AllDropDawnLists()
        {
            return new GeneralDropDawnVM()
            {
                language = new SelectList(await _db.languages.Select(a=> new LanguageVM()
                {
                    id = a.id,
                    name = a.name,
                }).ToListAsync(),"id","name")
            };
        }
    }
}
