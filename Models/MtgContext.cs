using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab4new.Models
{


    public class MtgContext : IdentityDbContext
    {
        public virtual DbSet<TcgUser> TcgUsers { get; set; }
        public virtual DbSet<Card> Cards { get; set; }

        public MtgContext(DbContextOptions<MtgContext> opt) : base(opt)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

    }
}