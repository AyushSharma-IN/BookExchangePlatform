using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookExchangePlatform.Models
{
    [Table(name: "User")]
    public class User : IdentityUser
    {
        [Required]
        [Column("FullName")]
        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(255)]
        [Column("FavoriteGenres")]
        public string? FavoriteGenres { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<ExchangeRequest> ERRequester { get; set; }
        public virtual ICollection<ExchangeRequest> EROwner { get; set; }
    }

    /*
        [Index(nameof(Email), IsUnique = true)]
        [Index(nameof(UserName), IsUnique = true)]
        [Table(name: "User")]
        public class User : IdentityUser
        {
            [Key]
            [Column("UserId")]
            public int UserId { get; set; }

            [Required]
            [Column("FullName")]
            [MaxLength(50)]
            public string FullName { get; set; }

            [Required]
            [MaxLength(50)]
            [Column("UserName")]
            public string UserName { get; set; }

            [Required, MaxLength(255)]
            [Column("Email")]
            public string Email { get; set; }

            [Required]
            [Column("Password")]
            public string Password { get; set; }

            [Required]
            [Column("PKey")]
            public string PKey { get; set; }

            [MaxLength(255)]
            [Column("FavoriteGenres")]
            public string? FavoriteGenres { get; set; }
        }
    */
}
