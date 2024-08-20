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
        return habits?.Where(habit => !habit.IsFinihed).FirstOrDefault(defaultValue: null) ?? null;
    }

    public void RemoveHabit(Habit habit)
    {
        var habitChecksToRemove = _db.HabitChecks.Where(x => x.HabitId == habit.Id);
        _db.HabitChecks.RemoveRange(habitChecksToRemove);

        var habitToRemove = _db.Habits.SingleOrDefault(x => x.Id == habit.Id);
        if (habitToRemove != null)
        {
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
        if (habit.Checks == null) return;
        var habitToUpdate = _db.Habits.SingleOrDefault(x => x.Id == habit.Id);
        if (habitToUpdate == null) return;
        
        habitToUpdate.Title = habit.Title;
        habitToUpdate.Motivation = habit.Motivation;
        habitToUpdate.NumDays = habit.NumDays;

        foreach (var item in habit.Checks)
        {
            var habitCheckToUpdate = _db.HabitChecks.SingleOrDefault(x => (x.HabitId == habit.Id) && (x.Id == item.Id));
            if (habitCheckToUpdate != null)
            {
                habitCheckToUpdate.IsChecked = item.IsChecked;
            }
        }

        _db.SaveChanges();


    }
}