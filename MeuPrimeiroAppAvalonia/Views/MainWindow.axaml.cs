using Avalonia.Controls;
using MeuPrimeiroAppAvalonia.Interfaces;
using MeuPrimeiroAppAvalonia.ViewModels;

namespace MeuPrimeiroAppAvalonia.Views;

public partial class MainWindow : Window
{
    private INavigationService navigationService;

    public MainWindow(MainWindowViewModel viewModel, INavigationService navigationService)
    {
        this.SizeToContent = SizeToContent.Manual;
        this.Width = 1280;
        this.Height = 720;
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        this.CanResize = false;

        InitializeComponent();
        DataContext = viewModel;
        
        this.navigationService = navigationService;
        navigationService.Initialize(ContentHost);
        navigationService.NavigateTo<MainViewModel>();
    }
}