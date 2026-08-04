using Microsoft.EntityFrameworkCore;
using NZWalks.Models.Domain;

namespace NZWalks.Data;

public class NZWalksDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    DbSet<Region> Region { get; set; }
    DbSet<Difficulty> Difficulty { get; set; }
    DbSet<Walk> Walk { get; set; }
}