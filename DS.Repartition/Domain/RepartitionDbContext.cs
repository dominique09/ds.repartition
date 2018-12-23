using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DS.Repartition.Domain
{
    public class RepartitionDbContext : IdentityDbContext
    {
        public RepartitionDbContext(DbContextOptions<RepartitionDbContext> options)
            :base(options)
        { }
        //public DbSet<Patate> Patates { get; set; }

    }
}
