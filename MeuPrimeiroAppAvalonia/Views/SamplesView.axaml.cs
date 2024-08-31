using System;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MeuPrimeiroAppAvalonia.ViewModels;

namespace MeuPrimeiroAppAvalonia.Views;

public partial class SamplesView : UserControl
{
    private int counter = 0;
    public SamplesView()
    {
        InitializeComponent();
    }

    private void OnButtonClick(object? sender, RoutedEventArgs e)
    {
        counter++;
        Debug.WriteLine("Button was clicked {0}!", counter);
    }
}