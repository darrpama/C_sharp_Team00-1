using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using rush00.Data;
using rush00.Data.Models;

namespace rush00.App.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly IDAOHabitRepository? _db;
    private readonly SetHabitViewModel? _setHabitViewModel;

    private Habit? _habit;

    private Habit? Habit
    {
        get => _habit;
        set
        {
            if (_habit == value) return;
            this.RaiseAndSetIfChanged(ref _habit, value);
            _habit?.Checks?.ForEach(x => x.PropertyChanged += HabitCheckOnPropertyChanged);
            // Console.WriteLine(_habit.IsFinished);
            UpdateCurrentPage();
        }
    }

    private void HabitCheckOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (Habit == null) return;
        _db?.UpdateHabit(Habit);
        UpdateCurrentPage();
    }
    
    public MainWindowViewModel()
    {
        _db = new HabitRepository(new HabitDbContext());
        Habit = _db.GetActual();
        Console.WriteLine(Habit?.IsFinished);
        
        _setHabitViewModel = new SetHabitViewModel();
        _setHabitViewModel.HabitCreated += OnHabitCreated;
        
        UpdateCurrentPage();
    }

    private void OnHabitCreated(Habit habit)
    {
        Habit = habit;
        _db?.AddHabit(habit);
        UpdateCurrentPage();
    }
    
    private bool _startButtonVisible;
    public bool StartButtonVisible
    {
        get => _startButtonVisible;
        protected set => this.RaiseAndSetIfChanged(ref _startButtonVisible, value);
    }
    
    
    private ViewModelBase? _currentPage;

    public MainWindowViewModel(IDAOHabitRepository? db)
    {
        _db = db;
    }

    public ViewModelBase? CurrentPage
    {
        get { return _currentPage; }
        private set
        {
            this.RaiseAndSetIfChanged(ref _currentPage, value);
        }
    }
    
    private void UpdateCurrentPage()
    {
        if (Habit == null)
        {
            Console.WriteLine("Habit is null");
            CurrentPage = _setHabitViewModel;
        }
        else if (!Habit.IsFinished)
        {
            Console.WriteLine("Habit is not finished");
            CurrentPage = new TrackingViewModel(Habit);
        }
        else
        {
            Console.WriteLine("Habit is finished");
            var congratulations = new CongratulationsViewModel(Habit);
            if (congratulations == null) throw new ArgumentNullException(nameof(congratulations));
            congratulations.ScreenPressed += UpdateCurrentPage;
            CurrentPage = congratulations;
            _db?.RemoveHabit(Habit);
            _habit = null;
        }
            
    }
}
