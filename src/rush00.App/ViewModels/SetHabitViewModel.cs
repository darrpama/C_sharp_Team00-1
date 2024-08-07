using System;
using System.ComponentModel.DataAnnotations;
using ReactiveUI;

namespace rush00.App.ViewModels;

public class SetHabitViewModel : PageViewModelBase
{
    public SetHabitViewModel()
    {
        this.WhenAnyValue(x => x.HabitName, x => x.HabitMotivation)
            .Subscribe(_ => UpdateCanNavigateNext());
    }

    private string _HabitName;
    
    [Required]
    public string? HabitName
    {
        get
        {
            return _HabitName;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _HabitName, value);
        }
    }
    
    private string _HabitMotivation;
    
    public string? HabitMotivation
    {
        get
        {
            return _HabitMotivation;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _HabitMotivation, value);
        }
    }
    
    private bool _CanNavigateNext;
    public override bool CanNavigateNext
    {
        get => _CanNavigateNext;
        protected set => this.RaiseAndSetIfChanged(ref _CanNavigateNext, value);
    }
    
    public override bool CanNavigatePrevious
    {
        get => true;
        protected set => throw new NotSupportedException();
    }

    private void UpdateCanNavigateNext()
    {
        CanNavigateNext =
            !string.IsNullOrEmpty(_HabitName)
            && !string.IsNullOrEmpty(_HabitMotivation);
    }
    
}