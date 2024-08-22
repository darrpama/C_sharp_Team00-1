using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using rush00.App.ViewModels;

namespace rush00.App.Views;

public partial class CongratulationsView : UserControl
{
    public CongratulationsView()
    {
        InitializeComponent();
    }

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (DataContext is CongratulationsViewModel viewModel)
        {
            Console.WriteLine("Screen pressed");
            viewModel.OnScreenPressed();
        }
    }
}