using Avalonia.Controls;
using MeuPrimeiroAppAvalonia.ViewModels;

namespace MeuPrimeiroAppAvalonia.Views;

public partial class MainView : UserControl
{
    public MainView(MainViewModel viewModel)
    {
        InitializeComponent();
        this.DataContext = viewModel;
    }
}