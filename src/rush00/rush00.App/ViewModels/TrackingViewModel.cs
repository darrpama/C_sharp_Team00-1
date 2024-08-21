using System.Collections.ObjectModel;
using DynamicData;
using rush00.Data.Models;

namespace rush00.App.ViewModels;

public class TrackingViewModel : ViewModelBase
{
    public ObservableCollection<HabitCheckViewModel> ListItems { get; set; }

    public Habit Habit { get; set; }
    private MainWindowViewModel _mainWindowViewModel;
        
    public TrackingViewModel(Habit habit)
    {
        ListItems = new ObservableCollection<HabitCheckViewModel>();
        foreach (HabitCheck check in habit.Checks)
        {
            ListItems.Add(new HabitCheckViewModel(check));
        }
    }
}
