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
        _startButtonVisible = true;
        _CurrentPage = Pages[0];
        var canNavNext = this.WhenAnyValue(x => x._CurrentPage.CanNavigateNext);

        NavigateNextCommand = ReactiveCommand.Create(NavigateNext, canNavNext);
        
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
    
    private bool _startButtonVisible;
    public bool StartButtonVisible
    {
        get => _startButtonVisible;
        protected set => this.RaiseAndSetIfChanged(ref _startButtonVisible, value);
    }

    
    private readonly PageViewModelBase[] Pages =
    {
        new SetHabitViewModel(),
        new TrackingViewModel()
    };
    
    private PageViewModelBase _CurrentPage;


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
}
