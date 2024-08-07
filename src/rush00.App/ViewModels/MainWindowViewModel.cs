using System.Windows.Input;
using DynamicData;
using ReactiveUI;

namespace rush00.App.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        _CurrentPage = Pages[0];
        var canNavNext = this.WhenAnyValue(x => x._CurrentPage.CanNavigateNext);
        var canNavPrev = this.WhenAnyValue(x => x._CurrentPage.CanNavigatePrevious);

        NavigateNextCommand = ReactiveCommand.Create(NavigateNext, canNavNext);
        NavigatePreviousCommand = ReactiveCommand.Create(NavigatePrevious, canNavPrev);
    }

    private readonly PageViewModelBase[] Pages =
    {
        new SetHabitViewModel(),
    };
    
    private PageViewModelBase _CurrentPage;

    public PageViewModelBase CurrentPage
    {
        get { return _CurrentPage; }
        private set { this.RaiseAndSetIfChanged(ref _CurrentPage, value); }
    }
    
    public ICommand NavigateNextCommand { get; }

    private void NavigateNext()
    {
        var index = Pages.IndexOf(CurrentPage) + 1;
        CurrentPage = Pages[index];
    }
    
    public ICommand NavigatePreviousCommand { get; }

    private void NavigatePrevious()
    {
        var index = Pages.IndexOf(CurrentPage) - 1;
        CurrentPage = Pages[index];
    }
}
