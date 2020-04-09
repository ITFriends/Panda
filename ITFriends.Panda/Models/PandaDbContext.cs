using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITFriends.Panda.Models
{
    public class PandaDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public PandaDbContext(DbContextOptions<PandaDbContext> options) : base(options)
        {
        }
    }
}