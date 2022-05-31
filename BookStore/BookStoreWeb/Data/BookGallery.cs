namespace BookStoreWeb.Data
{
    public class BookGallery
    {
        public int id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public int? bookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
