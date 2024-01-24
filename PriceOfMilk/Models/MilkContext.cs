using Microsoft.EntityFrameworkCore;

namespace PriceOfMilk.Models
{
    public class MilkContext : DbContext
    {
        public MilkContext(DbContextOptions<MilkContext> options)
            : base(options)
        {
        }

        public DbSet<Milk> Milks { get; set; } = null!;
    }
}
