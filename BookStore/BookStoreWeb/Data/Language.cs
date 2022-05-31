using System.Collections.Generic;

namespace BookStoreWeb.Data
{
    public class Language
    {
        public int id { get; set; }
        public string name { get; set; }
        public ICollection<Book> Book { get; set; }
    }
}
