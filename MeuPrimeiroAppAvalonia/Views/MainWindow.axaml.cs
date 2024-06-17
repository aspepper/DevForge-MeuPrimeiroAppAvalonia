using Avalonia.Controls;

namespace MeuPrimeiroAppAvalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainWindowViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}