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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>() { 
                new Difficulty()
                {
                    Id = Guid.Parse("935bf6a2-2854-402c-af80-0ee1840db2f3"),
                    Name ="Easy"
                },
                new Difficulty()
                {
                    Id =Guid.Parse("2f9b1cb4-0c72-42dc-a2b1-d052a8f80367"),
                    Name="Medium"
                },
                new Difficulty()
                {
                    Id =Guid.Parse("6d2d6b66-19ef-416d-b58b-d0fcabff8f0b"),
                    Name = "High"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

        }
    }
}
