using Microsoft.EntityFrameworkCore;

namespace PriceOfMilk.Models
{
    public class MilkTypeContext : DbContext
    {
        public MilkTypeContext(DbContextOptions<MilkTypeContext> options)
            : base(options)
        {
        }

        public DbSet<MilkType> MilkTypes { get; set; } = null!;
    }
}
