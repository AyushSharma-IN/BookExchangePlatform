using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookExchangePlatform.Models
{
    [Table(name: "ExchangeRequest")]
    public class ExchangeRequest
    {
        [Key]
        [Column("ExchangeRequestId")]
        public int ExchangeRequestId { get; set; }
        
        [Required]
        [Column("BookId")]
        [ForeignKey(nameof(Book))]
        [Display(Name = "BookId")]
        public int BookId { get; set; }

        [Display(Name = "Title")]
        public virtual Book Book { get; set; }

        [Required]
        [Column("RequestId")]
        [Display(Name = "RequesterId")]
        public string RequesterId { get; set; }

        [Display(Name = "Requester Name")]
        [ForeignKey(nameof(RequesterId))]
        public virtual User Requester { get; set; }

        [Required]
        [Column("OwnerId")]
        [Display(Name = "OwnerId")]
        public string OwnerId { get; set; }

        [Display(Name = "Owner Name")]
        [ForeignKey(nameof(OwnerId))]
        public virtual User Owner { get; set; }

        [Display(Name = "Terms")]
        [Column("Terms")]
        public string? Terms { get; set; }

        [Required]
        [Column("Status")]
        [Display(Name = "Status")]
        public string Status { get; set; } // Pending, Accepted, Rejected, Modified

        [Required]
        [Column("DeliveryMethod")]
        [Display(Name = "Delivery Method")]
        public string DeliveryMethod { get; set; } // Pickup, Delivery

        [Column("Duration")]
        [Display(Name = "Duration")]
        public string? Duration { get; set; } // 1 day, 2 day, 1 week, 1 month etc

        [Display(Name = "Rquested Date")]
        [Column("RequestDate")]
        public DateTime RequestDate { get; set; } = DateTime.Now;
    }
}
