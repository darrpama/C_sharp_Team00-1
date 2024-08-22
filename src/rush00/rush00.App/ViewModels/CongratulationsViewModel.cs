
using System;
using System.Linq;
using System.Text;
using rush00.Data.Models;

namespace rush00.App.ViewModels;

public class CongratulationsViewModel : ViewModelBase
{
    public string Congratulation { get; }
    public event Action? ScreenPressed; 
    public Habit Habit { get; set; }

    public CongratulationsViewModel(Habit habit)
    {
        Habit = habit;
        var sb = new StringBuilder();
        sb.Append("Congratulations!\n");
        sb.Append($"{habit.Checks?.Count(ch => ch.IsChecked)}/{habit.Checks?.Count()} days checked.\n");
        sb.Append($"Finally: {habit.Motivation}");
        Congratulation = sb.ToString();
    }

    public void OnScreenPressed()
    {
        ScreenPressed?.Invoke();
    }
}