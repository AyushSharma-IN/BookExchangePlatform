using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookExchangePlatform.Models
{
    [Table(name: "Book")]
    public class Book
    {
        [Key]
        [Column("BookId")]
        [Display(Name = "BookId")]
        public int BookId { get; set; }

        [Column("Title", TypeName = "nvarchar(100)")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [Display(Name = "Author")]
        [MaxLength(100)]
        [Column("Author", TypeName = "nvarchar(100)")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [Display(Name = "Genre")]
        [Column("Genre", TypeName = "nvarchar(100)")]
        [MaxLength(100)]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Condition is required")]
        [Display(Name = "Condition")]
        [Column("Condition", TypeName = "nvarchar(30)")]
        [MaxLength(30)]
        public string Condition { get; set; } // New, Good, Used

        [Required]
        [Column("IsAvailable")]
        [Display(Name = "Availability")]
        public bool IsAvailable { get; set; } = true;

        [Required]
        [Column("UserId")]
        [ForeignKey(nameof(Owner))]
        [Display(Name = "Owner Id")] 
        public string OwnerId { get; set; }

        [Display(Name = "Owner Name")]
        public virtual User Owner { get; set; }

        public virtual ICollection<ExchangeRequest> ExchangeRequests { get; set; }
    }
}
