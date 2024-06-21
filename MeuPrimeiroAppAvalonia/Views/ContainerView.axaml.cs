using Avalonia.Controls;
using MeuPrimeiroAppAvalonia.Interfaces;
using MeuPrimeiroAppAvalonia.ViewModels;

namespace MeuPrimeiroAppAvalonia.Views;

public partial class ContainerView : UserControl
{
    public ContainerView(INavigationService navigationService)
    {
        InitializeComponent();

        navigationService.Initialize(ContentHost);
        navigationService.NavigateTo<MainViewModel>();
    }
}
