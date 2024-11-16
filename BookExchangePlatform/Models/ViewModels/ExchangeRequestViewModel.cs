using System.ComponentModel.DataAnnotations;

namespace BookExchangePlatform.Models.ViewModels
{
    public class ExchangeRequestViewModel
    {
        [Key]
        public int ExchangeRequestId { get; set; }

        public int BookId { get; set; }

        [Required(ErrorMessage = "Book Title is required")]
        [Display(Name = "Book Title")]
        [MaxLength(100)]
        public string Title { get; set; }

        public string RequesterId { get; set; }

        [Required(ErrorMessage = "Requester Name is required")]
        [Display(Name = "Requester Name")]
        [MaxLength(100)]
        public string RequesterName { get; set; }

        public string OwnerId { get; set; }

        [Required(ErrorMessage = "Owner Name is required")]
        [Display(Name = "Owner Name")]
        [MaxLength(100)]
        public string OwnerName { get; set; }

        [Display(Name = "Terms")]
        [MaxLength(255)]
        public string Terms { get; set; }

        [Required]
        [Display(Name = "Status")]
        [AllowedValues(["Pending", "Accepted", "Rejected"])]
        public string Status { get; set; } // Pending, Accepted, Rejected

        [Display(Name = "Delivery Method")]
        public string DeliveryMethod { get; set; }

        [Display(Name = "Duration")]
        public string Duration { get; set; }

        [Display(Name = "Requested Date")]
        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}
