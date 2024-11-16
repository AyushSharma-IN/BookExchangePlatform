using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookExchangePlatform.Models.ViewModels;

namespace BookExchangePlatform.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<ExchangeRequest> ExchangeRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ExchangeRequest>()
                .HasOne(e => e.Book)
                .WithMany(b => b.ExchangeRequests)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<ExchangeRequest>()
                .HasOne(e => e.Requester)
                .WithMany(u => u.ERRequester)
                .HasForeignKey(e => e.RequesterId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<ExchangeRequest>()
                .HasOne(e => e.Owner)
                .WithMany(u => u.EROwner)
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Entity<Book>()
                .HasOne(b => b.Owner)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.OwnerId)
                .OnDelete(DeleteBehavior.ClientCascade);

            //builder.HasDefaultSchema("Identity");
            builder.Entity<User>(entity => entity.ToTable("User"));
            //builder.Entity<IdentityUser>(entity =>
            //{
            //    entity.ToTable(name: "IUser");
            //});
            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}
