using System.Collections.ObjectModel;
using rush00.Data.Models;
using System;
using System.Collections.Generic;

namespace rush00.App.ViewModels;

public class TrackingViewModel : PageViewModelBase, ITracking
{
    public override bool CanNavigateNext { get; protected set; }
    public override bool CanNavigatePrevious { get; protected set; }
    public ObservableCollection<HabitCheckViewModel> ListItems { get; }

    public void AddHabit(Habit habit)
    {
        Habit = habit;
    }
    public Habit Habit { get; set; }
        
    public TrackingViewModel()
    {
        // if (Habit?.Checks != null) ListItems = new ObservableCollection<HabitCheckViewModel>
        // {
        //     new HabitCheckViewModel(new HabitCheck(DateTime.Now.AddDays(1), false)),
        //     new HabitCheckViewModel(new HabitCheck(DateTime.Now.AddDays(2), false))
        // };
        ListItems = new ObservableCollection<HabitCheckViewModel>
        {
            new HabitCheckViewModel(new HabitCheck(DateTime.Now.AddDays(1), false)),
            new HabitCheckViewModel(new HabitCheck(DateTime.Now.AddDays(2), false))
        };
    }
}

public interface ITracking
{
    void AddHabit(Habit habit);
}