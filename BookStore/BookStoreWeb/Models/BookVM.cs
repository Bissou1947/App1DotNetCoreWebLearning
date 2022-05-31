using BookStoreWeb.CustomesValidationsHelpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWeb.Models
{
    public class BookVM
    {
        public int id { get; set; }
        [Required]
        [StringLength(100,MinimumLength =3)]
        //[Validation1("bissou",ErrorMessage = "Book name dose not contain bissou word")]
        public string title { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string author { get; set; }
        [Required]
        [Range(1,3000)]
        public int? pages { get; set; }
        [Required]
        [Range(1, 6)]
        [Display(Name ="language")]
        public int? languageId { get; set; }
        public string language { get; set; }
        public string category { get; set; }
        public DateTime? created { get; set; }
        public DateTime? modify { get; set; }
        [Required]
        [Display(Name = "Cover Photo")]
        public IFormFile coverPhoto { get; set; }
        public string coverImagePath { get; set; }
        [Required]
        [Display(Name = "Gallery Photos")]
        public IFormFileCollection galleryPhotos { get; set; }
        public List<BookGalleryVM> galleryImagesPaths { get; set; }
    }
}
