using System;
using System.Threading;
using System.Windows.Input;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using rush00.Data.Models;

namespace rush00.App.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        _CurrentPage = Pages[0];
        var canNavNext = this.WhenAnyValue(x => x._CurrentPage.CanNavigateNext);
        // var canNavPrev = this.WhenAnyValue(x => x._CurrentPage.CanNavigatePrevious);

        NavigateNextCommand = ReactiveCommand.Create(NavigateNext, canNavNext);
        // NavigatePreviousCommand = ReactiveCommand.Create(NavigatePrevious, canNavPrev);
        
        this.WhenPropertyChanged(x => x.CurrentPage).Subscribe(_ => UpdateStartButtonVisibility());
    }

    private void UpdateStartButtonVisibility()
    {
        if (this.CurrentPage.GetType() == Pages[0].GetType())
        {
            StartButtonVisible = true;
        }
        else
        {
            StartButtonVisible = false;
        }
    }
    
    private bool _StartButtonVisible;
    public bool StartButtonVisible
    {
        get => _StartButtonVisible;
        protected set => this.RaiseAndSetIfChanged(ref _StartButtonVisible, value);
    }
 

    private readonly PageViewModelBase[] Pages =
    {
        new SetHabitViewModel(),
        new TrackingViewModel(MainHabit)
    };
    
    private PageViewModelBase _CurrentPage;

    public static Habit MainHabit;

    public PageViewModelBase CurrentPage
    {
        get { return _CurrentPage; }
        private set
        {
            this.RaiseAndSetIfChanged(ref _CurrentPage, value);
        }
    }
    
    public ICommand NavigateNextCommand { get; }

    private void NavigateNext()
    {
        var index = Pages.IndexOf(CurrentPage) + 1;
        CurrentPage = Pages[index];
    }
    
    // public ICommand NavigatePreviousCommand { get; }
    //
    // private void NavigatePrevious()
    // {
    //     var index = Pages.IndexOf(CurrentPage) - 1;
    //     CurrentPage = Pages[index];
    // }
}
