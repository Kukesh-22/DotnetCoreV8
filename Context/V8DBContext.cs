using Dotnet_v8.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_v8.Context
{
    public class V8DBContext(DbContextOptions<V8DBContext> options) : DbContext(options)
    {
        public DbSet<Difficulty> Difficulties { get; set; } 
        public DbSet<Region> Regions { get; set; }  
        public DbSet<Walk> Walks { get; set; }
        public DbSet<Run> Runs { get; set; }
    }
}
