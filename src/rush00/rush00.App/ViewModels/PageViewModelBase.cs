namespace rush00.App.ViewModels;

//  Каждая View, которая будет перелистываться должна быть унаследована от этого класса, который
//  требует реализации двух флагов, говорящих о возможности перелистывания вперёд и назад
public abstract class PageViewModelBase : ViewModelBase
{
    public abstract bool CanNavigateNext { get; protected set; }
    public abstract bool CanNavigatePrevious { get; protected set; }
}