using System;
using System.Collections.Generic;

namespace BookStoreWeb.Data
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int? pages { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modify { get; set; }
        public int? languageId { get; set; }
        public string coverImagePath { get; set; }
        public virtual Language Language { get; set; }
        public ICollection<BookGallery> BookGallery { get; set; }
    }
}
