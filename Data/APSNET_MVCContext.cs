using Microsoft.EntityFrameworkCore;

namespace APS.NET_MVC.Data
{
    public class APSNET_MVCContext : DbContext
    {
        public APSNET_MVCContext (DbContextOptions<APSNET_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<APS.NET_MVC.Models.Engine> Engine { get; set; } = default!;

        public DbSet<APS.NET_MVC.Models.Car> Car { get; set; } = default!;
    }
}
