using System.Threading.Tasks;
using Avalonia.Controls;
using MeuPrimeiroAppAvalonia.Interfaces;
using MeuPrimeiroAppAvalonia.ViewModels;

namespace MeuPrimeiroAppAvalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow(INavigationService navigationService)
    {
        this.SizeToContent = SizeToContent.Manual;
        this.Width = 1280;
        this.Height = 720;
        this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        this.CanResize = false;

        InitializeComponent();
        
        navigationService.Initialize(ContentHostWindow);
        Task.Delay(1000).Wait();
        navigationService.NavigateToRoot<MenuViewModel>();
    }
}
