using System;
using System.Collections.ObjectModel;
using rush00.Data.Models;

namespace rush00.App.ViewModels;

public class TrackingViewModel : ViewModelBase
{
    public ObservableCollection<HabitCheck> ListItems { get; set; }
    public TrackingViewModel(Habit habit)
    {
        ListItems = new ObservableCollection<HabitCheck>(habit.Checks != null ? habit.Checks : Array.Empty<HabitCheck>());
    }

}
