using System;
using System.ComponentModel.DataAnnotations;
using ReactiveUI;
using rush00.Data;

namespace rush00.App.ViewModels;

public class SetHabitViewModel : PageViewModelBase
{
    public SetHabitViewModel()
    {
        this.WhenAnyValue(x => x.HabitName,
        x => x.HabitMotivation,
        x => x.StartDate,
        x => x.ChallengeDays)
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
    
    private DateTimeOffset? _StartDate = DateTimeOffset.Now;
    
    public DateTimeOffset? StartDate
    {
        get
        {
            return _StartDate;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _StartDate, value);
        }
    }
    
    private int _ChallengeDays;

    public int ChallengeDays
    {
        get
        {
            return _ChallengeDays;
        }
        set
        {
            this.RaiseAndSetIfChanged(ref _ChallengeDays, value);
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
        get => false;
        protected set => throw new NotSupportedException();
    }

    private void UpdateCanNavigateNext()
    {
        CanNavigateNext =
            !string.IsNullOrEmpty(_HabitName)
            && !string.IsNullOrEmpty(_HabitMotivation)
            && _StartDate != null
            && _StartDate >= DateTimeOffset.Now.Date
            && _ChallengeDays > 0;
    }


}