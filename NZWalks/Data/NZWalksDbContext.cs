using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;

namespace NZWalks.Data;

public class NZWalksDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Region> Region { get; set; }
    public DbSet<Difficulty> Difficulty { get; set; }
    public DbSet<Walk> Walk { get; set; }
}