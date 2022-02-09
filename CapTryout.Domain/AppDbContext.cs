using CapTryout.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CapTryout.Domain;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Meal>? Meals { get; set; }
}
