using rush00.Data.Models;

namespace rush00.Data;

public interface IDAOHabitRepository
{
    public Habit? GetActual();
    public void AddHabit(Habit habit);
    public void RemoveHabit(Habit habit);
    public List<Habit>? GetAllHabit();
    public void UpdateHabit(Habit habit);
}