using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Town.Models
{
    public class TownContext: IdentityDbContext
    {
        public TownContext(DbContextOptions<TownContext> options):base(options) { }
        public DbSet<IconSection> IconSections { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}
