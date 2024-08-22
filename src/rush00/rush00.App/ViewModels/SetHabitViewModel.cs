using System;
using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using rush00.Data.Models;

namespace rush00.App.ViewModels;

public class SetHabitViewModel : ViewModelBase
{
    public event Action<Habit>? HabitCreated;
    public ReactiveCommand<Unit, Unit> StartCommand { get; }
    
    public SetHabitViewModel()
    {
        var canStart = this.WhenAnyValue(x => x.HabitName,
            x => x.HabitMotivation,
            x => x.StartDate,
            x => x.ChallengeDays,
            (title, motivation, startDate, challengeDays) =>
                !string.IsNullOrWhiteSpace(title) &&
                !string.IsNullOrWhiteSpace(motivation) &&
                startDate != null &&
                startDate >= DateTimeOffset.Now.Date &&
                challengeDays > 0);
        
        StartCommand = ReactiveCommand.Create(() =>
        {
            Habit newHabit = StartHabit();
            HabitCreated?.Invoke(newHabit);
        },
        canExecute: canStart);
    }

    private Habit StartHabit()
    {
        var habit = new Habit(HabitName, HabitMotivation, ChallengeDays);
        return habit;
    }
    
    private string _habitName;
    
    [Required]
    public string HabitName
    {
        get  => _habitName;
        set => this.RaiseAndSetIfChanged(ref _habitName, value);
    }
    
    private string _habitMotivation;
    public string HabitMotivation
    {
        get => _habitMotivation;
        set => this.RaiseAndSetIfChanged(ref _habitMotivation, value);
    }
    
    private DateTimeOffset? _startDate = DateTimeOffset.Now;
    public DateTimeOffset? StartDate
    {
        get => _startDate;
        set => this.RaiseAndSetIfChanged(ref _startDate, value);
    }
    
    private int _challengeDays;

    public int ChallengeDays
    {
        get => _challengeDays;
        set => this.RaiseAndSetIfChanged(ref _challengeDays, value);
    }
    
}