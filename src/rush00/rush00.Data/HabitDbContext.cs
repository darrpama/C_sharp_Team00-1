using rush00.Data.Models;
using Microsoft.EntityFrameworkCore;

public sealed class HabitDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Habit> Habits => Set<Habit>();
    public DbSet<HabitCheck> HabitChecks => Set<HabitCheck>();

    public HabitDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=habits.db");
    }
}