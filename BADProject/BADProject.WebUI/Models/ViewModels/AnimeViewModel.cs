using BADProject.Domain.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BADProject.WebUI.Models.ViewModels
{
    public class AnimeViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Display(Name = "Image URL")]
        [ValidateNever]
        public string ImageURL { get; set; }

        public IFormFile Image { get; set; }
        [ValidateNever]
        public List<Genre> GenresList { get; set; }
        [ValidateNever]
        public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();

        [ValidateNever]
        public double AverageRating { get; set; }

        [ValidateNever]
        public string GenreName { get; set; }
        public bool IsInWatchList { get; set; }  

    }
}
