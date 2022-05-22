using System;

namespace BookStoreWeb.Models
{
    public class BookVM
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int? pages { get; set; }

        public DateTime? created { get; set; }
        public DateTime? modify { get; set; }
    }
}
