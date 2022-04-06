using Microsoft.EntityFrameworkCore;

namespace APIRestfulEntity.Data
{
    public class BrugereDbContext : DbContext
    {
        public BrugereDbContext(DbContextOptions<BrugereDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Brugeres> brugeres { get; set; }
    }
}
