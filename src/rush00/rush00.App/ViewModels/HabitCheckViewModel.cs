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

    private DateTime _date;

    public HabitCheckViewModel(HabitCheck item)
    {
        _isChecked = item.IsChecked;
        _date = item.Date;
    }

    public HabitCheck GetHabitCheck()
    {
        return new HabitCheck(this._date, this._isChecked) {};
    }
}