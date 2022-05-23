using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWeb.Models
{
    public class BookVM
    {
        public int id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =3)]
        public string title { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string author { get; set; }
        [Required]
        [Range(1,3000)]
        public int? pages { get; set; }

        public DateTime? created { get; set; }
        public DateTime? modify { get; set; }
    }
}
