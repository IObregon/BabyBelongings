using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class BabyBelongingsContext : DbContext
{
    public BabyBelongingsContext(DbContextOptions<BabyBelongingsContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=../MyDatabase.db");
    }
    

    public virtual DbSet<Belonging> Belongings { get; set; }
}