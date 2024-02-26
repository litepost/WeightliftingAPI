using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace WeightliftingAPI;

public class LiftListDbContext : DbContext
{
    public LiftListDbContext(DbContextOptions<LiftListDbContext> options) : base(options) {

    }

    public DbSet<Lift> LiftList { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
