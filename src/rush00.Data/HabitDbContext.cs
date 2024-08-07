/*
using team_00;
using Microsoft.EntityFrameworkCore;

class HabitDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Habit> Habits;
    public DbSet<HabitCheck> HabitChecks;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename=habits.db");
    }
}
*/