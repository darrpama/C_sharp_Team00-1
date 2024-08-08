using System.Collections.ObjectModel;
using rush00.Data.Models;
using System;

namespace rush00.App.ViewModels;

public class TrackingViewModel : PageViewModelBase
{
    public override bool CanNavigateNext { get; protected set; }
    public override bool CanNavigatePrevious { get; protected set; }
    public ObservableCollection<HabitCheck> ListItems { get; }
    public Habit Habit { get; }
        
    public TrackingViewModel(Habit habit)
    {
        Habit = habit;
        ListItems = new ObservableCollection<HabitCheck>();
    }
}