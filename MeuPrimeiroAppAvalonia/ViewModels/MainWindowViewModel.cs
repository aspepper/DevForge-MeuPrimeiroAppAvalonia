using MeuPrimeiroAppAvalonia.Interfaces;

namespace MeuPrimeiroAppAvalonia.ViewModels;

public class MainWindowViewModel
{
    private readonly INavigationService navigationService;

    public MainWindowViewModel(INavigationService navigationService)
    {
        this.navigationService = navigationService;
    }
}
