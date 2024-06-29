using System.Threading.Tasks;
using Avalonia.Controls;
using MeuPrimeiroAppAvalonia.Interfaces;
using MeuPrimeiroAppAvalonia.ViewModels;

namespace MeuPrimeiroAppAvalonia.Views;

public partial class MainView : UserControl
{
    public MainView(INavigationService navigationService)
    {
        InitializeComponent();
        navigationService.Initialize(ContentHost);
        Task.Delay(1000).Wait();
        navigationService.NavigateToRoot<MenuViewModel>();
    }
}