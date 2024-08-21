using System;
using System.ComponentModel;
using System.Windows.Input;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using rush00.Data;
using rush00.Data.Models;

namespace rush00.App.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private IDAOHabitRepository? _db;
    private SetHabitViewModel _setHabitViewModel;
    private CongratulationsViewModel _congratulationsViewModel;

    private Habit? _habit;
    public Habit? Habit
    {
        get => _habit;
        set
        {
            if (_habit == value) return;
            this.RaiseAndSetIfChanged(ref _habit, value);
            _habit?.Checks.ForEach(x => x.PropertyChanged += HabitCheckOnPropertyChanged);
            UpdateCurrentPage();
        }
    }

    private void HabitCheckOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (_habit == null) return;
        _db.UpdateHabit(_habit);
        if (_habit.IsFinihed)
        {
            CurrentPage = new CongratulationsViewModel();
        }
    }
    
    public MainWindowViewModel()
    {
        _db = new HabitRepository(new HabitDbContext());
        Habit = _db.GetActual();
        
        _setHabitViewModel = new SetHabitViewModel();
        _congratulationsViewModel = new CongratulationsViewModel();
        
        _setHabitViewModel.HabitCreated += OnHabitCreated;
        
        Pages = [_setHabitViewModel, _congratulationsViewModel];
        
        UpdateCurrentPage();
    }

    private void OnHabitCreated(Habit habit)
    {
        Habit = habit;
        _db.AddHabit(habit);
        UpdateCurrentPage();
    }
    
    private bool _startButtonVisible;
    public bool StartButtonVisible
    {
        get => _startButtonVisible;
        protected set => this.RaiseAndSetIfChanged(ref _startButtonVisible, value);
    }
    
    private readonly ViewModelBase[] Pages;
    
    private ViewModelBase _CurrentPage;
    public ViewModelBase CurrentPage
    {
        get { return _CurrentPage; }
        private set
        {
            this.RaiseAndSetIfChanged(ref _CurrentPage, value);
        }
    }
    
    public ICommand NavigateNextCommand { get; }

    private void UpdateCurrentPage()
    {
        if (Habit == null)
        {
            CurrentPage = Pages[0];
        }
        else if (!Habit.IsFinihed)
        {
            CurrentPage = new TrackingViewModel(Habit);
        }
        else
        {
            CurrentPage = Pages[2];
        }
            
    }
}
