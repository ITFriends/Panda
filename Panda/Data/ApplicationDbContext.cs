using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using Panda.Models;

namespace Panda.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
            : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var keysProperties = builder.Model.GetEntityTypes()
                                .Select(x => x.FindPrimaryKey())
                                .Where(key => key is { })
                                .SelectMany(x => x.Properties);

            foreach (var property in keysProperties)
            {
                property.ValueGenerated = ValueGenerated.OnAdd;
            }
        }

        public DbSet<Pet> Pets { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<House> Houses { get; set; }

        public DbSet<Owner> Owners { get; set; }
    }
}