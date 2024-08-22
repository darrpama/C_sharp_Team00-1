using System.Net;
using Microsoft.EntityFrameworkCore;
using rush00.Data.Models;

namespace rush00.Data;

public class HabitRepository : IDAOHabitRepository
{
    private readonly HabitDbContext _db;

    public HabitRepository(HabitDbContext db)
    {
        _db = db;
    }


    public void AddHabit(Habit? habit)
    {
        if (habit is not { Checks: not null }) return;
        _db.Add(habit);
        foreach (var check in habit.Checks)
        {
            _db.Add(check);
        }
        _db.SaveChanges();
    }
    
    public Habit? GetActual()
    {
        var habits = GetAllHabit();
        Habit? actualHabit = habits?.Where(habit => !habit.IsFinished).FirstOrDefault(defaultValue: null) ?? null;
        if (actualHabit != null)
        {
            var habitChecks = _db.HabitChecks.Where(x => (x.HabitId == actualHabit.Id)).OrderBy(x => x.Date);
            actualHabit.Checks = habitChecks.ToList();
        }
        return actualHabit;
    }

    public void RemoveHabit(Habit habit)
    {

        var habitToRemove = _db.Habits.SingleOrDefault(x => x.Id == habit.Id);
        if (habitToRemove != null)
        {
            var habitChecksToRemove = _db.HabitChecks.Where(x => x.HabitId == habit.Id);
            _db.HabitChecks.RemoveRange(habitChecksToRemove);
            _db.Habits.Remove(habitToRemove);
        }

        _db.SaveChanges();
    }

    public List<Habit>? GetAllHabit()
    {
        return _db.Habits.Include(x => x.Checks).ToList();
    }

    public void UpdateHabit(Habit habit)
    {
        RemoveHabit(habit);
        AddHabit(habit);
    }
}