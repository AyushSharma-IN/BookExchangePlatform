using System.ComponentModel.DataAnnotations;

namespace BookExchangePlatform.Models.ViewModels
{
    public class BookViewModel
    {
        [Key]
        [Display(Name = "BookId")]
        public int BookId { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [Display(Name = "Author")]
        [MaxLength(100)]
        public string Author { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [Display(Name = "Genre")]
        [MaxLength(100)]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Condition is required")]
        [Display(Name = "Condition")]
        [MaxLength(30)]
        public string Condition { get; set; } // New, Good, Used

        [Required]
        [Display(Name = "Availability")]
        public bool IsAvailable { get; set; } = true;

        [Display(Name = "Owner Id")]
        public string OwnerId { get; set; }

        //[Display(Name = "Owner Name")]
        //public string OwnerName { get; set; }
    }
}
