using System;
using ReactiveUI;
using Avalonia;
using Avalonia.ReactiveUI;
using CommunityToolkit.Mvvm.ComponentModel;
using rush00.Data.Models;

namespace rush00.App.ViewModels;

public class HabitCheckViewModel : ViewModelBase
{
    private bool _isChecked;


    public HabitCheckViewModel(HabitCheck item)
    {
        _isChecked = item.IsChecked;
        _date = item.Date;
    }

    public bool IsChecked
    {
        get
        {
            return _isChecked;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _isChecked, value);
        }
    }

    private DateTime _date;
    public DateTime Date
    {
        get
        {
            return _date;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _date, value);
        }
    }

    public HabitCheck GetHabitCheck()
    {
        return new HabitCheck(this._date, this._isChecked) {};
    }
}